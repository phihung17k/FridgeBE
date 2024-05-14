namespace FridgeBE.Core.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IReadOnlyList<T> GetReadOnlyList();
        Task<IReadOnlyList<T>> GetReadOnlyListAsync();
        Task<IReadOnlyList<T>> GetPaginatedData();
        Task<T> GetById<Tid>(Tid id);

        Task<bool> IsExists();

        Task<T> Create(T model);
        Task<bool> Update(T model);
        Task<bool> Delete(T model);
    }
}