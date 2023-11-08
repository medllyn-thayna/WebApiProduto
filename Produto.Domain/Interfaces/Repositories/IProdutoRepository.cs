using Produto.Domain.Entities;

namespace Produto.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IBaseRepository<TB_PRODUTOS>
    {
        public Task<IEnumerable<TB_PRODUTOS>> ListarProdutosAtivos();
    }
}
