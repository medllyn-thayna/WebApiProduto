using Microsoft.Extensions.DependencyInjection;
using Produto.Service.Interfaces;
using Produto.Service.Services;

namespace Produto.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoAppService, ProdutoService>();
            return services;
        }
    }
}
