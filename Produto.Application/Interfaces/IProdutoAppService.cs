using Produto.Domain.Entities;

namespace Produto.Service.Interfaces
{
    public interface IProdutoAppService : IBaseService<TB_PRODUTOS>
    {
        public Task<IEnumerable<TB_PRODUTOS>> ListarProdutosAtivos();
    }
}
