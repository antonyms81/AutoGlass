using AutoGlass.Dominio.DTOs;
using AutoGlass.Dominio.Entidades;
using AutoMapper;

namespace AutoGlass.Aplicacao.Configuracoes
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<ProdutoDTO, Produto>();
        }
    }
}
