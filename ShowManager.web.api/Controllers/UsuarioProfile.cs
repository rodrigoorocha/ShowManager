using AutoMapper;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioAdicionarDTO, Usuario>();
            CreateMap<UsuarioEditarDTO, Usuario>();
        }
    }
}
