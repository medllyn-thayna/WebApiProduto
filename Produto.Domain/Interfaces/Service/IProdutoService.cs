using Produto.Domain.Entities;

namespace Produto.Domain.Interfaces.Service
{
    public interface IProdutoService : IBaseService<TB_PRODUTOS>
    {
        public Task<IEnumerable<TB_PRODUTOS>> ListarProdutosAtivos();

    }
}
