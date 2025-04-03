using AutoMapper;
using ShowManager.Aplicacao.Services.Usuarios;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioCriarCommand, Usuario>();
            //CreateMap<UsuarioEditarCommand, Usuario>();
        }
    }
}
