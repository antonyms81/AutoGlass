using AutoMapper;

namespace AutoGlass.Aplicacao.Configuracoes
{
    public static class AutoMapperConfiguracao
    {
        public static IServiceCollection AdicionarAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddAutoMapper();

            return services;
        }
    }
}
