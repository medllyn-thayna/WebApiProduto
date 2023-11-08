using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Repositories;
using Produto.Domain.Interfaces.Service;

namespace Produto.Domain.Services
{
    public class ProdutoService : BaseService<TB_PRODUTOS>, IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TB_PRODUTOS>> ListarProdutosAtivos()
        {
            return await _repository.ListarProdutosAtivos();
        }
    }
}
