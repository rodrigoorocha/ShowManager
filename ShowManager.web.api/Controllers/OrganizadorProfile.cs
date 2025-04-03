using AutoMapper;
using ShowManager.Aplicacao.Services.Organizadores;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    public class OrganizadorProfile : Profile
    {

        public OrganizadorProfile()
        {
            CreateMap<OrganizadorCriarCommand, Organizador>();
            //CreateMap<OrganizadorEditarDTO, Organizador>();

        }

    }
}
