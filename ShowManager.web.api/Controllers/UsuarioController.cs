using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService usuarioService, IMapper _mapper) : ControllerBase
    {
        [Route("CriarUsuario")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] UsuarioAdicionarDTO usuarioAdicionarDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioAdicionarDTO);

            await usuarioService.CriarAsync(usuario);

            return Ok();
        }

        [Route("ObterPorID/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var usuario = await usuarioService.BuscarPorIDAsync(id);

            return Ok(usuario);
        }

        [Route("EditarUsuario")]
        [HttpPost]
        public async Task<IActionResult> Editar([FromBody] UsuarioEditarDTO usuarioEditarDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioEditarDTO);

            await usuarioService.AtualizarAsync(usuario);

            return Ok();
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await usuarioService.DeletarAsync(id);

            return Ok();
        }
    }
}
