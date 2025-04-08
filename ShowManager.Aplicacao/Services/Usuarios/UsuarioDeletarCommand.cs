using MediatR;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioDeletarCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
