using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.Context;

namespace ShowManager.Infra.DataBase.Repository.Shows;

public class ShowRepository : RepositoryBase<Show>, IShowRepository
{
    private readonly ShowManagerContext _context;
    public ShowRepository(ShowManagerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> AtualizarAsync(Show show)
    {
        return await _context.Shows.Where(o => o.Id == show.Id)
            .ExecuteUpdateAsync(x =>
                x.SetProperty(o => o.Duracao, show.Duracao)
                 .SetProperty(o => o.NomeShow, show.NomeShow)
                 .SetProperty(o => o.DataInicio, show.DataInicio)
                 .SetProperty(o => o.DataFim, show.DataFim)
                 .SetProperty(o => o.NumeroParticipantes, show.NumeroParticipantes)
                 .SetProperty(o => o.OrganizadorId, show.OrganizadorId)
        );
    }

    public  async Task<IEnumerable<Show>> BuscarTodos()
    {
        return await _context.Shows.ToListAsync();
    }
}
