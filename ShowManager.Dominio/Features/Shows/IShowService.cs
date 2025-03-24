using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Dominio.Features.Shows;

public interface IShowService
{
    Task CriarAsync(Show show);

    Task<Show> BuscarPorIDAsync(int id);
    Task AtualizarAsync(Show showAtualizado);
    Task DeletarAsync(int id);

}
