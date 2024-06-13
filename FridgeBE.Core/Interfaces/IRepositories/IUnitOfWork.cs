using FridgeBE.Core.Entities.Common;

namespace FridgeBE.Core.Interfaces.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        Task<int> CompleteAsync();
        IGenericRepository<T>? Repository<T>() where T : EntityBase;
    }
}