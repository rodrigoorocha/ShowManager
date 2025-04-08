using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowManager.Aplicacao.features.Usuarios;
using ShowManager.Aplicacao.Services.Organizadores;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizadorController(IMediator mediator) : ControllerBase
    {
        [Route("Criar")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] OrganizadorCriarCommand organizadorCriarCommand)
        {
            await mediator.Send(organizadorCriarCommand);
            return Ok();
        }

        //[Route("ObterPorID/{id}")]
        //[HttpGet]
        //public async Task<IActionResult> ObterPorId([FromRoute] int id)
        //{
        //    var organizador = await mediator.Send(new OrganizadorObterPorIdQuery { Id = id });
        //    return Ok(organizador);
        //}

        [Route("EditarUsuario")]
        [HttpPost]
        public async Task<IActionResult> Editar([FromBody] OrganizadorEditarCommand organizadorEditarCommand)
        {
            await mediator.Send(organizadorEditarCommand);
            return Ok();
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await mediator.Send(new OrganizadorDeletarCommand { Id = id });
            return Ok();
        }
    }
}

