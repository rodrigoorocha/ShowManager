using Microsoft.VisualBasic;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Infra.DataBase.Repository.Organizadores;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorService : IOrganizadorService
{
    private readonly IOrganizadorRepository _organizadorRepository;

    public OrganizadorService(IOrganizadorRepository organizadorRepository)
    {
        _organizadorRepository = organizadorRepository;
    }

    public async Task AtualizarAsync(Organizador organizadoroAtualizado)
    {
        var OrganizadorDoBanco = await BuscarPorIDAsync(organizadoroAtualizado.Id);

        OrganizadorDoBanco.Atualizar(organizadoroAtualizado);

        await _organizadorRepository.SaveChangesAsync();
    }

    public async Task<Organizador> BuscarPorIDAsync(int id)
    {
        var organizador = await _organizadorRepository.BuscarPorIdAsync(id);

        if (organizador is null)
        {
            //NotFound
            throw new Exception();
        }

        return organizador;
    }

    public async Task CriarAsync(Organizador organizador)
    {
        await _organizadorRepository.Adicionar(organizador, true);
    }

    public async Task DeletarAsync(int id)
    {
        var registrosDeletados = await _organizadorRepository.DeleteAsync(id);

        if (registrosDeletados == 0)
        {
            //NotFound
            throw new Exception();
        }
    }
}
