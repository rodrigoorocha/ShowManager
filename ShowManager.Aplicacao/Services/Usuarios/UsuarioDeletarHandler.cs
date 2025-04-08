using MediatR;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioDeletarHandler: IRequestHandler<UsuarioDeletarCommand, Unit>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioDeletarHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Unit> Handle(UsuarioDeletarCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.BuscarPorIdAsync(request.Id);
        if (usuario == null)
        {
            throw new KeyNotFoundException("Usuário não encontrado.");
        }

        await _usuarioRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
