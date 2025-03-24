
namespace ShowManager.Dominio.Features.Organizadores;

public interface IOrganizadorService
    {

    Task CriarAsync(Organizador organizador);

    Task<Organizador> BuscarPorIDAsync(int id);

    Task AtualizarAsync(Organizador organizadoroAtualizado);

    Task DeletarAsync(int id);
}
