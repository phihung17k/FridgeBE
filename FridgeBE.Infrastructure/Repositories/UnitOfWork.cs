using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FridgeBE.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;
        private IIngredientRepository _ingredientRepository;
        private IDbContextTransaction? _transaction;
        public IIngredientRepository IngredientRepository
        {
            get
            {
                if (_ingredientRepository == null)
                {
                    _ingredientRepository = new IngredientRepository(_context);
                }
                return _ingredientRepository;
            }
        }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
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
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
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
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
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

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
            {
                //throw TransactionException.TransactionNotCommitException();
            }

            await _transaction.RollbackAsync();
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                await transaction.RollbackAsync(token);
                //throw TransactionException.TransactionNotExecuteException(ex);
            }
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