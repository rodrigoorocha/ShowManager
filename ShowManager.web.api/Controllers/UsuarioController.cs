using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowManager.Aplicacao.Services.Usuarios;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IMediator mediator) : ControllerBase
    {
        [Route("CriarUsuario")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] UsuarioCriarCommand usuarioCriarCommand)
        {
            await mediator.Send(usuarioCriarCommand);
            return Ok();
        }

        //[Route("ObterPorID/{id}")]
        //[HttpGet]
        //public async Task<IActionResult> ObterPorId([FromRoute] int id)
        //{
        //    var usuario = await mediator.Send(new UsuarioObterPorIdQuery { Id = id });
        //    return Ok(usuario);
        //}

        [Route("ObterOrganizadorPorID/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterOrganizadorPorId([FromRoute] int id)
        {
            var organizador = await mediator.Send(new UsuarioObterPorIdQuery { Id = id, TipoUsuario = TipoUsuarioEnum.Organizador });
            return Ok(organizador);
        }

        [Route("EditarUsuario")]
        [HttpPost]
        public async Task<IActionResult> Editar([FromBody] UsuarioEditarCommand usuarioEditarCommand)
        {
            await mediator.Send(usuarioEditarCommand);
            return Ok();
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await mediator.Send(new UsuarioDeletarCommand { Id = id });
            return Ok();
        }
    }
}
