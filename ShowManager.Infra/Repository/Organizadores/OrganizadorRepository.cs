using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Infra.Context;

namespace ShowManager.Infra.DataBase.Repository.Organizadores;

public class OrganizadorRepository : Repository<Organizador>, IOrganizadorRepository
{
    public OrganizadorRepository(ShowManagerContext context) : base(context)
    {
    }
}
