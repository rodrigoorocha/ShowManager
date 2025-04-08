using MediatR;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioEditarCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public TipoUsuarioEnum TipoUsuarioEnum { get; set; }
}
