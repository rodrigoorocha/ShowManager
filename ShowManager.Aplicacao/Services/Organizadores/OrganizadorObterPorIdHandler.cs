using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Infra.DataBase.Repository.Organizadores;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorObterPorIdHandler : IRequestHandler<OrganizadorObterPorIdQuery, Organizador>
{
    private readonly IOrganizadorRepository _organizadorRepository;

    public OrganizadorObterPorIdHandler(IOrganizadorRepository organizadorRepository)
    {
        _organizadorRepository = organizadorRepository;
    }

    public async Task<Organizador> Handle(OrganizadorObterPorIdQuery request, CancellationToken cancellationToken)
    {
        var organizador = await _organizadorRepository.BuscarPorIdAsync(request.Id);
        if (organizador == null)
        {
            throw new KeyNotFoundException("Organizador não encontrado.");
        }

        return organizador;
    }
}
