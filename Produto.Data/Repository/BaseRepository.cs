using Microsoft.EntityFrameworkCore;
using Produto.Data.Context;
using Produto.Domain.Interfaces.Repositories;

namespace Produto.Data.Repository
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DB_PRODUTOContext _db = null;

        public BaseRepository(DB_PRODUTOContext context)
        {
            _db = context;
        }

        public async Task Add(TEntity obj)
        {
            _db.Set<TEntity>().AddAsync(obj);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _db.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public async Task Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
            await _db.SaveChangesAsync();
        }

        public async Task Update(TEntity obj)
        {
            // _db.Set<TEntity>().Update(obj);
            _db.Entry(obj).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
