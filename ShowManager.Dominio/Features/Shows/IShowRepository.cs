using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shared;

namespace ShowManager.Dominio.Features.Shows;

    public  interface IShowRepository : IRepositoryBase<Show>
{
    //public Task<int> AtualizarAsync(Show show);

    public Task<IEnumerable<Show>> BuscarTodos();
}
