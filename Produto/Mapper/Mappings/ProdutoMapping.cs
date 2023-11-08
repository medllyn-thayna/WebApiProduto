using AutoMapper;
using Produto.Domain.Entities;
using Produto.Models.Input;
using Produto.Models.View;

namespace Produto.Mapper.Mappings
{
    public class ProdutoMapping : Profile
    {
        public ProdutoMapping()
        {
            CreateMap<TB_PRODUTOS, ProdutoViewModel>().ReverseMap();
            CreateMap<TB_PRODUTOS, ProdutoInputModel>().ReverseMap();
        }
    }
}
