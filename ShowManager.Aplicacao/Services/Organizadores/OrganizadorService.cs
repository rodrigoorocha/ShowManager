using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Infra.DataBase.Repository.Organizadores;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorService : IOrganizador
{

    private readonly OrganizadorRepository organizadoresRepository;

    public OrganizadorService(OrganizadorRepository organizadoresRepository)
    {
        this.organizadoresRepository = organizadoresRepository;
    }

    public Task<string> Atulizar(Organizador organizador)
    {
        throw new NotImplementedException();
    }

    public Task<string> Buscar()
    {
        throw new NotImplementedException();
    }

    public Task<string> BuscarPorID(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> Criar(Organizador organizador)
    {
        throw new NotImplementedException();
    }

    public Task<string> Deletar(int id)
    {
        throw new NotImplementedException();
    }
}
