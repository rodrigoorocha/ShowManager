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
        Task<Usuario> Criar(UsuarioAdicionarDTO usuarioAdicionarDTO);
        Task<int> Deletar(int id);
        Task<Usuario> Atualizar(UsuarioEditarDTO usuarioEditarDTO, int id );
        Task<IEnumerable<Usuario>?> Buscar();
        Task<Usuario?> BuscarPorID(int id);

    }
}
