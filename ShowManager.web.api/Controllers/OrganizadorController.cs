using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowManager.Aplicacao.features.Usuarios;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.web.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizadorController(IOrganizadorService organizadorService , IMapper _mapper) : ControllerBase
    {
        [Route("Criar")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] OrganizadorAdicionarDTO organizadorAdicionarDTO)
        {
            var organizador = _mapper.Map<Organizador>(organizadorAdicionarDTO);

            await organizadorService.CriarAsync(organizador);

            return Ok();
        }

        [Route("ObterPorID/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var organizador = await organizadorService.BuscarPorIDAsync(id);

            return Ok(organizador);
        }

        [Route("EditarUsuario")]
        [HttpPost]
        public async Task<IActionResult> Editar([FromBody] OrganizadorEditarDTO organizadorEditarDTO)
        {
            var organizador = _mapper.Map<Organizador>(organizadorEditarDTO);

            await organizadorService.AtualizarAsync(organizador);

            return Ok();
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await organizadorService.DeletarAsync(id);

            return Ok();
        }
    }

}

