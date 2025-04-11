using MediatR;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioObterPorIdQuery : IRequest<Usuario>
{
    public int Id { get; set; }
    public TipoUsuarioEnum TipoUsuario { get; set; }
}
