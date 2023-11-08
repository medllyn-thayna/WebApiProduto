using Produto.Domain.Entities;
using Produto.Service.Interfaces;
using Produto.Domain.Interfaces.Service;
using Produto.Services;

namespace Produto.Service.Services
{
    public class ProdutoService : BaseService<TB_PRODUTOS>, IProdutoAppService
    {
        private readonly IProdutoService _serviceProduto;

        public ProdutoService(IProdutoService service) : base(service)
        {
            _serviceProduto = service;
        }
        public async Task<IEnumerable<TB_PRODUTOS>> ListarProdutosAtivos()
        {
            return await _serviceProduto.ListarProdutosAtivos();
        }


    }
}
