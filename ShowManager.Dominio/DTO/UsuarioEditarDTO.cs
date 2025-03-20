

using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Dominio.DTO;

public class UsuarioEditarDTO
{
    
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public TipoUsuarioEnum TipoUsuarioEnum { get; set; }
}
