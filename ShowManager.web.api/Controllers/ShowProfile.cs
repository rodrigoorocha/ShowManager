using AutoMapper;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<ShowAdicionarDTO, Show>();
            CreateMap<ShowEditarDTO, Show>();
        }
    }
}
