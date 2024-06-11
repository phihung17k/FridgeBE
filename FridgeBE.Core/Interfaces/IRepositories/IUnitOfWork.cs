namespace FridgeBE.Core.Interfaces.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IIngredientRepository IngredientRepository { get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}