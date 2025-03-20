using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
    {
        [Route("ObterTodos")]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {

            return Ok(await usuarioService.Buscar());
        }

        [Route("ObterPorID/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterLista([FromRoute] int id)
        {

            return Ok(await usuarioService.BuscarPorID(id));
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            return Ok(await usuarioService.Deletar(id));
        }


        [Route("CriarUsuario")]
        [HttpPost] 
        public async Task<IActionResult> Criar([FromBody] UsuarioAdicionarDTO usuarioAdicionarDTO)
        {
            return Ok(await usuarioService.Criar(usuarioAdicionarDTO));
        }


        [Route("EditarUsuario/{id}")]
        [HttpPost]
        public async Task<IActionResult> Editar([FromBody] UsuarioEditarDTO usuarioEditarDTO, int id)
        {
            return Ok(await usuarioService.Atualizar(usuarioEditarDTO, id));
        }
    }
}
