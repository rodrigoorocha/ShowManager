using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Infra.DataBase.Repository.Usuarios;

public interface IUsuarioRepository
{
    Task<Usuario> ObterPorIdAsync(int id, TipoUsuarioEnum tipoUsuario);
}
