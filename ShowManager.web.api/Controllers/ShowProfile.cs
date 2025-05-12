using AutoMapper;
using ShowManager.Aplicacao.Services.Shows;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<ShowCriar.Command, Show>();
            CreateMap<ShowEditar.Command, Show>();
            CreateMap<ShowDeletar.Command, Show>();
            CreateMap<ShowAdicionarDTO, Show>();
            CreateMap<ShowEditarDTO, Show>();
        }
    }
}