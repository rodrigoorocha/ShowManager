using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowManager.Aplicacao.features.Usuarios;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController(IShowService showService, IMapper _mapper) : ControllerBase
    {
        [Route("Criar")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ShowAdicionarDTO showAdicionarDTO)
        {
            var show = _mapper.Map<Show>(showAdicionarDTO);

            await showService.CriarAsync(show);

            return Ok();
        }

        [Route("ObterPorID/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var show = await showService.BuscarPorIDAsync(id);

            return Ok(show);
        }

        [Route("Editar")]
        [HttpPost]
        public async Task<IActionResult> Editar([FromBody] ShowEditarDTO showEditarDTO)
        {
            var show = _mapper.Map<Show>(showEditarDTO);

            await showService.AtualizarAsync(show);

            return Ok();
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await showService.DeletarAsync(id);

            return Ok();
        }
    }
}
