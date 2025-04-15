using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowManager.Aplicacao.features.Usuarios;
using ShowManager.Aplicacao.Services.Shows;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController(IMediator mediator) : ControllerBase
    {
        [Route("Criar")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ShowCriar.Command showCriarCommand)
        {
            await mediator.Send(showCriarCommand);
            return Ok();
        }

        [Route("ObterPorID/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var show = await mediator.Send(new ShowObterPorId { Id = id });
            return Ok(show);
        }

        [Route("Editar")]
        [HttpPost]
        public async Task<IActionResult> Editar([FromBody] ShowEditar showEditarCommand)
        {
            await mediator.Send(showEditarCommand);
            return Ok();
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await mediator.Send(new ShowDeletar { Id = id });
            return Ok();
        }
    }
}