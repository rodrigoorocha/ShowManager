using ShowManager.Dominio.Features.Shared;

namespace ShowManager.Dominio.Features.Organizadores
{
    public interface IOrganizadorRepository : IRepositoryBase<Organizador>
    {

        public Task<int> AtualizarAsync(Organizador organizador);

        public Task<IEnumerable<Organizador>> BuscarTodos();
    }
}
