using Produto.Mapper.Mappings;

namespace Produto.Mapper
{
    public static class MapperConfig
    {
        public static IServiceCollection AddMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProdutoMapping));

            return services;
        }
    }
}
