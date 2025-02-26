using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Dominio.Features.Usuarios
{
    public interface IUsuarioService
    {
        Task<string> Criar(Usuario usuario);
        Task<string> Deletar(int id);
        Task<string> Atulizar(Usuario usuario);
        Task<string> Buscar();
        Task<string> BuscarPorID(int id);

    }
}
