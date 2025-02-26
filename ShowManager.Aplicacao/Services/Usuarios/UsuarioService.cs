using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Repository.Usuarios;

namespace ShowManager.Aplicacao.features.Usuarios;

public  class UsuarioService : IUsuarioService
{
    private readonly UsuarioRepository usuarioRepository;

    public UsuarioService(UsuarioRepository usuarioRepository)
    {
        this.usuarioRepository = usuarioRepository;
    }

    public Task<string> Atulizar(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task<string> Buscar()
    {
        throw new NotImplementedException();
    }

    public Task<string> BuscarPorID(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> Criar(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task<string> Deletar(int id)
    {
        throw new NotImplementedException();
    }
}
