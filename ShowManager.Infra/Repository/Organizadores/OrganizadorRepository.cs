using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Infra.Context;

namespace ShowManager.Infra.DataBase.Repository.Organizadores;

public class OrganizadorRepository : RepositoryBase<Organizador>, IOrganizadorRepository
{
    private readonly ShowManagerContext _context;

    public OrganizadorRepository(ShowManagerContext context) : base(context)
    {
        _context = context;

    }

    public async Task<int> AtualizarAsync(Organizador organizador)
    {
        return await _context.Organizadores.Where(o => o.Id == organizador.Id)
            .ExecuteUpdateAsync(x =>
                x.SetProperty(o => o.Apelido, organizador.Apelido)
        //.SetProperty(o => o.ListaShows, organizador.ListaShows)
        );
    }

    public async Task<IEnumerable<Organizador>> BuscarTodos()
    {
        return await _context.Organizadores.ToListAsync();
    }
}
