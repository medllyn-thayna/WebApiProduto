using Microsoft.Extensions.DependencyInjection;
using Produto.Data.Context;
using Produto.Data.Repository;
using Produto.Domain.Interfaces.Repositories;

namespace Produto.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureRepository(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }

        public static IServiceCollection AddInfrastructureDatabaseContext(this IServiceCollection services)
        {
            services.AddDbContext<DB_PRODUTOContext>(ServiceLifetime.Transient);

            return services;
        }
    }
}
