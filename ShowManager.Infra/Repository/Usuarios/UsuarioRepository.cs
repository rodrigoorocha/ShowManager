using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Infra.DataBase.Repository.Usuarios;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ShowManagerContext context) : base(context)
    {
    }
}
