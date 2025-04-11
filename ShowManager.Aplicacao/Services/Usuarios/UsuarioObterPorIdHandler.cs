using MediatR;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioObterPorIdHandler : IRequestHandler<UsuarioObterPorIdQuery, Usuario>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioObterPorIdHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario> Handle(UsuarioObterPorIdQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.BuscarPorIdAsync(request.Id);
        if (usuario == null)
        {
            throw new KeyNotFoundException("Usuário não encontrado.");
        }

        return usuario;
        
    }
}
