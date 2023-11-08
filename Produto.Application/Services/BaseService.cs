using Produto.Domain.Interfaces.Service;


namespace Produto.Services
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseService<TEntity> _service;

        public BaseService(IBaseService<TEntity> service)
        {
            _service = service;
        }

        public async Task Add(TEntity obj)
        {
            await _service.Add(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _service.GetById(id);
        }

        public async Task Remove(TEntity obj)
        {
            await _service.Remove(obj);
        }

        public async Task Update(TEntity obj)
        {
            await _service.Update(obj);
        }
    }
}
