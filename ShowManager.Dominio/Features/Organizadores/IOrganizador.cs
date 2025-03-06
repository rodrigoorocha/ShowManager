

namespace ShowManager.Dominio.Features.Organizadores;

public interface IOrganizador
    {

    Task<string> Criar(Organizador organizador);
    Task<string> Deletar(int id);
    Task<string> Atulizar(Organizador organizador );
    Task<string> Buscar();
    Task<string> BuscarPorID(int id);
}
