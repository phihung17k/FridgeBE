using FridgeBE.Core.Entities;
using FridgeBE.Core.Entities.Common;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace FridgeBE.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;
        private IDbContextTransaction? _transaction;

        private readonly Dictionary<Type, object> _repositoriesLookup;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repositoriesLookup = new Dictionary<Type, object>
            {
                { typeof(Ingredient), new IngredientRepository(_context) },
                { typeof(UserAccount), new UserAccountRepository(_context) },
                { typeof(UserLogin), new UserLoginRepository(_context) },
                { typeof(Category), new CategoryResponsitory(_context) }
            };
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // transaction
        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        // commit
        public void Commit()
        {
            if (_transaction == null)
            {
                //throw TransactionException.TransactionNotCommitException();
            }
            try
            {
                _context.SaveChanges();
                _transaction!.Commit();
            }
            finally
            {
                _transaction!.Dispose();
                _transaction = null;
            }
        }

        public async Task CommitAsync(CancellationToken token)
        {
            if (_transaction == null)
            {
                //throw TransactionException.TransactionNotCommitException();
            }

            try
            {
                await _context.SaveChangesAsync(token);
                _transaction!.Commit();
            }
            finally
            {
                _transaction!.Dispose();
                _transaction = null;
            }
        }

        // rollback
        public void Rollback()
        {
            if (_transaction == null)
            {
                //throw TransactionException.TransactionNotCommitException();
            }

            _transaction!.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
            {
                //throw TransactionException.TransactionNotCommitException();
            }

            await _transaction!.RollbackAsync();
            _transaction.Dispose();
            _transaction = null;
        }

        // execute transaction
        public async Task ExecuteTransactionAsync(Action action, CancellationToken token)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                action();
                await _context.SaveChangesAsync(token);
                await transaction.CommitAsync(token);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(token);
                //throw TransactionException.TransactionNotExecuteException(ex);
            }
        }

        public async Task ExecuteTransactionAsync(Func<Task> action, CancellationToken token)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await action();
                await _context.SaveChangesAsync(token);
                await transaction.CommitAsync(token);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(token);
                //throw TransactionException.TransactionNotExecuteException(ex);
            }
        }

        public IGenericRepository<T>? Repository<T>() where T : EntityBase
        {
            return _repositoriesLookup[typeof(T)] as IGenericRepository<T>;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}