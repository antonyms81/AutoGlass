using AutoGlass.Dominio.Interfaces.Repositorios;
using AutoGlass.Dominio.Interfaces.Servicos;
using AutoGlass.Infra.Dados.Repositorios;
using AutoGlass.Servico.Servicos;
using AutoMapper;

namespace AutoGlass.Aplicacao.Configuracoes
{
    public static class InjecaoDeDependenciaConfiguracao
    {
        public static IServiceCollection AdicionarInjecaoDeDependencia(this IServiceCollection services)
        {
            services.AddScoped<IServicoProduto, ServicoProduto>();
            services.AddScoped<IRepositorioProduto, RepositorioProduto>();

            return services;
        }
    }
}
