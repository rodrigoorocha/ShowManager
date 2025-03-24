using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Infra.DataBase.Repository.Usuarios;

public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
{

    private readonly ShowManagerContext _context;
    public UsuarioRepository(ShowManagerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> AtualizarAsync(Usuario usuario)
    {
        return await _context.Usuarios.Where(o => o.Id == usuario.Id)
            .ExecuteUpdateAsync(x =>
                x.SetProperty(o => o.Nome, usuario.Nome)
        //.SetProperty(o => o.ListaShows, organizador.ListaShows)
        );
    }


}
