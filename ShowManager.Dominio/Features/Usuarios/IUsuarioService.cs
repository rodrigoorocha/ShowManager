using ShowManager.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Dominio.Features.Usuarios
{
    public interface IUsuarioService
    {
        Task CriarAsync(Usuario usuario);

        Task<Usuario> BuscarPorIDAsync(int id);

        Task AtualizarAsync(Usuario usuarioAtualizado);

        Task DeletarAsync(int id);

    }
}
