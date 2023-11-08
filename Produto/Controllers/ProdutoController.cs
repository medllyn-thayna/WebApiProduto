using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Service;
using Produto.Models.Input;
using Produto.Models.View;
using Produto.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace Produto.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;

        }
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponseErrors), 400)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [SwaggerOperation(Summary = "Lista produtos ",
         Description = "Lista todos os produtos")]
        [HttpGet("ListarProdutosAtivos")]
        public async Task<IEnumerable<ProdutoViewModel>> ListarProdutosAtivos()
        {
            var produtoModel = await _produtoService.ListarProdutosAtivos();
            if (produtoModel == null) throw new KeyNotFoundException("Ops! Ocorreu um erro ao listar produtos");
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtoModel);
        }

        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponseErrors), 400)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [SwaggerOperation(Summary = "Lista produtos",
      Description = "Lista todos os produtos")]
        [HttpGet("ListarProdutos")]
        public async Task<IEnumerable<ProdutoViewModel>> ListarProdutos()
        {
            var produtoModel = await _produtoService.GetAll();
            if (produtoModel == null) throw new KeyNotFoundException("Ops! Ocorreu um erro ao listar os produtos");
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtoModel);
        }

        [ProducesResponseType(typeof(ResponseSuccessMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponseErrors), 400)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [SwaggerOperation(Summary = "Cadastra produto",
                Description = "Cadastra novo produto")]
        [HttpPost("CadastrarProduto")]
        public async Task<ActionResult> CadastrarProduto(ProdutoInputModel produto)
        {
            var produtoModel = _mapper.Map<TB_PRODUTOS>(produto);
            await _produtoService.Add(produtoModel);
            if (produtoModel == null) throw new Exception("Ops! Ocorreu um erro ao cadastrar o produto");

            return Ok(new { message = "Produto cadastrado com sucesso." });
        }

        [ProducesResponseType(typeof(ResponseSuccessMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponseErrors), 400)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [SwaggerOperation(Summary = "Deleta produto",
             Description = "Deleta produto a partir de um ID")]
        [HttpDelete("DeletarProduto")]
        public async Task<ActionResult> DeletarProduto(int idProduto)
        {

            var produtoModel = await _produtoService.GetById(idProduto);
            if (produtoModel == null) throw new Exception("Ops! Ocorreu um erro ao deletar o produto");

            await _produtoService.Remove(produtoModel);

            return Ok(new { message = "Produto deletado com sucesso." });
        }

        [ProducesResponseType(typeof(ResponseSuccessMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponseErrors), 400)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [SwaggerOperation(Summary = "Atualiza produto",
            Description = "Atualiza um produto existente")]
        [HttpPut("AtualizarProduto")]
        public async Task<ActionResult> AtualizarProduto(ProdutoViewModel produto)
        {

            var produtoModel = _mapper.Map<TB_PRODUTOS>(produto);
            await _produtoService.Update(produtoModel);

            if (produtoModel == null) throw new Exception("Ops! Ocorreu um erro ao atualizar o procuto");

            return Ok(new { message = "Produto atualizado com sucesso." });

        }
    }
}
