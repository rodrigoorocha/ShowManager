using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shared;

namespace ShowManager.Dominio.Features.Usuarios
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {

        public Task<int> AtualizarAsync(Usuario usuario);

        
    }
}
