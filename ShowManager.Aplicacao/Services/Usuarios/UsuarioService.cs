using Microsoft.VisualBasic;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.Aplicacao.features.Usuarios;

public class UsuarioService : IUsuarioService
{
    private readonly UsuarioRepository _usuarioRepository;

    public UsuarioService(UsuarioRepository usuarioRepository)
    {
        this._usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario> Atualizar(UsuarioEditarDTO usuarioEditarDTO, int id)
    {

        var usuario = new Usuario
        {
            Id = id,
            Nome = usuarioEditarDTO.Nome,
            Email = usuarioEditarDTO.Email,
            Senha = usuarioEditarDTO.Senha,
            TipoUsuarioEnum = usuarioEditarDTO.TipoUsuarioEnum
        };
        var usuarioAtualizado = await _usuarioRepository.SaveAsync(usuario);
        return usuarioAtualizado;
    }

    public async Task<IEnumerable<Usuario>?> Buscar()
    {
        return await _usuarioRepository.GetAllAsync();
    }

    public async Task<Usuario?> BuscarPorID(int id)
    {
        return await _usuarioRepository.GetByIdAsync(id);
    }

    public async Task<Usuario> Criar(UsuarioAdicionarDTO usuarioAdicionarDTO)
    {
        var usuario = new Usuario
        {
            Nome = usuarioAdicionarDTO.Nome,
            Email = usuarioAdicionarDTO.Email,
            Senha = usuarioAdicionarDTO.Senha,
            TipoUsuarioEnum = usuarioAdicionarDTO.TipoUsuarioEnum
        };
        return await _usuarioRepository.SaveAsync(usuario);
    }

    public async Task<int> Deletar(int id)
    {
        await _usuarioRepository.DeleteAsync(id);
        return id;
    }
}
