using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Infra.DataBase.Repository.Usuarios;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DbContext _context;

    public UsuarioRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> ObterPorIdAsync(int id, TipoUsuarioEnum tipoUsuario)
    {
        return await _context.Set<Usuario>()
            .Where(u => u.Id == id && u.TipoUsuarioEnum == tipoUsuario)
            .FirstOrDefaultAsync();
    }
}
