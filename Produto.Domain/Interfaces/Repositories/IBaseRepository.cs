namespace Produto.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
        void Dispose();
    }
}
