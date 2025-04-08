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
        var existingShow = await _context.Shows.FindAsync(show.Id);
        if (existingShow == null)
        {
            throw new KeyNotFoundException("Show não encontrado.");
        }

        existingShow.Atualizar(show);

        
        if (show.OrganizadorId != 0)
        {
            existingShow.OrganizadorId = show.OrganizadorId;
           
        }

        return await _context.SaveChangesAsync();
    }

    public  async Task<IEnumerable<Show>> BuscarTodos()
    {
        return await _context.Shows.ToListAsync();
    }
}
