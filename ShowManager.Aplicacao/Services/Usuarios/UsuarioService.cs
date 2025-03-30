using Microsoft.VisualBasic;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.Aplicacao.features.Usuarios;

public class UsuarioService : IUsuarioService
{

    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public async Task CriarAsync(Usuario usuario)
    {
        await _usuarioRepository.Adicionar(usuario, true);
    }

    public async Task<Usuario> BuscarPorIDAsync(int id)
    {
        var usuario = await _usuarioRepository.BuscarPorIdAsync(id);

        if (usuario is null)
        {
            //NotFound
            throw new Exception();
        }

        return usuario;
    }

    public async Task AtualizarAsync(Usuario usuarioEditado)
    {
        var usuarioDoBanco = await BuscarPorIDAsync(usuarioEditado.Id);

        usuarioDoBanco.AtualizarNome(usuarioEditado.Nome);

        await _usuarioRepository.SaveChangesAsync();
    }

    public async Task DeletarAsync(int id)
    {
        var registrosDeletados = await _usuarioRepository.DeleteAsync(id);

        if (registrosDeletados == 0)
        {
            //NotFound
            throw new Exception();
        }
    }
}
