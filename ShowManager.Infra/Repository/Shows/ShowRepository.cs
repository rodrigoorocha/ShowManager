using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.Context;

namespace ShowManager.Infra.DataBase.Repository.Shows;

public class ShowRepository : Repository<Show>, IShowRepository
{
    public ShowRepository(ShowManagerContext context) : base(context)
    {
    }
}
