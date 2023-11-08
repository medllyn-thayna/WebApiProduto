using Microsoft.Extensions.DependencyInjection;
using Produto.Domain.Interfaces.Service;
using Produto.Domain.Services;

namespace Produto.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            return services;
        }
    }
}
