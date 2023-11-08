using Produto.Domain.Interfaces.Repositories;
using Produto.Domain.Interfaces.Service;

namespace Produto.Domain.Services
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task Add(TEntity obj)
        {
            await _repository.Add(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Remove(TEntity obj)
        {
            await _repository.Remove(obj);
        }

        public async Task Update(TEntity obj)
        {
            await _repository.Update(obj);
        }
    }
}
