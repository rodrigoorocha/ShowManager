namespace ShowManager.Dominio.Features.Shows;

public interface IShowService
{
    Task<string> Criar(Show show );
    Task<string> Deletar(int id);
    Task<string> Atulizar(Show show);
    Task<string> Buscar();
    Task<string> BuscarPorID(int id);
}
