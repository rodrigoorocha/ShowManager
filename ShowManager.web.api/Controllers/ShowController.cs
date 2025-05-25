using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShowManager.Aplicacao.Services.Shows;
using ShowManager.Dominio.Features.Shows;

namespace ShowManager.web.api.Controllers
{
    /// <summary>
    /// Controller para gerenciamento de Shows
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cria um novo show
        /// </summary>
        /// <param name="showCriarCommand">Dados do show a ser criado</param>
        /// <returns>Show criado com sucesso</returns>
        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] ShowCriar.Command showCriarCommand)
        {
            await _mediator.Send(showCriarCommand);
            return Ok();
        }

        /// <summary>
        /// Obtém um show pelo ID
        /// </summary>
        /// <param name="id">ID do show</param>
        /// <returns>Dados do show</returns>
        [HttpGet("ObterPorID/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var show = await _mediator.Send(new ShowObterPorId.Query { Id = id });
            return Ok(show);
        }

        /// <summary>
        /// Edita um show existente
        /// </summary>
        /// <param name="showEditarCommand">Dados do show a ser editado</param>
        /// <returns>Show editado com sucesso</returns>
        [HttpPost("Editar")]
        public async Task<IActionResult> Editar([FromBody] ShowEditar.Command showEditarCommand)
        {
            await _mediator.Send(showEditarCommand);
            return Ok();
        }

        /// <summary>
        /// Deleta um show
        /// </summary>
        /// <param name="id">ID do show a ser deletado</param>
        /// <returns>Show deletado com sucesso</returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new ShowDeletar.Command { Id = id });
            return Ok();
        }
    }
}