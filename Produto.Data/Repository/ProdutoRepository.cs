using Microsoft.EntityFrameworkCore;
using Produto.Data.Context;
using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Repositories;

namespace Produto.Data.Repository
{
    public class ProdutoRepository : BaseRepository<TB_PRODUTOS>, IProdutoRepository
    {
        DB_PRODUTOContext _context = null;

        public ProdutoRepository(DB_PRODUTOContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TB_PRODUTOS>> ListarProdutosAtivos()
        {
            return await _context.TB_PRODUTOS.Where(x => x.STATUS_PRODUTO == "Ativo").AsNoTracking().ToListAsync();
        }
    }
}
