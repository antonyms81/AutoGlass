using AutoGlass.Infra.Dados.Contexto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoGlass.Aplicacao.Configuracoes
{
    public static class ContextoConfiguracao
    {
        public static IServiceCollection AdicionarContexto(this IServiceCollection services,  IConfiguration configuration)
        {
            services.AddDbContext<AutoGlassContexto>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:AutoGlass"]);

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}
