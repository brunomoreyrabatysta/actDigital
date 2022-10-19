using APIMsFinanceiro.API.Infra.Repositories;
using APIMsFinanceiro.API.Models.Repositories;
using APIMsFinanceiro.Data;
using APIMsFinanceiro.Services;
using Microsoft.EntityFrameworkCore;

namespace APIMsFinanceiro.API.Extensions
{
    public static class DependenciesExtension
    {
        public static void AddSqlConnection(
            this IServiceCollection services,
            string connecitonString)
        {
            services.AddDbContext<APIMsFinanceiroDataContext>(options => options.UseSqlServer(connecitonString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITipoLancamentoRepository, TipoLancamentoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<TokenService>();
        }
    }
}
