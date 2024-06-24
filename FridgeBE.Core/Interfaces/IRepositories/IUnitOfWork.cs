using FridgeBE.Core.Entities.Common;

namespace FridgeBE.Core.Interfaces.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangeAsync();
        IGenericRepository<T>? Repository<T>() where T : EntityBase;
    }
}