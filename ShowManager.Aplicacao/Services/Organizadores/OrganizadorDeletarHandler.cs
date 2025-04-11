using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Infra.DataBase.Repository.Organizadores;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorDeletarHandler : IRequestHandler<OrganizadorDeletarCommand, Unit>
{
    private readonly IOrganizadorRepository _organizadorRepository;

    public OrganizadorDeletarHandler(IOrganizadorRepository organizadorRepository)
    {
        _organizadorRepository = organizadorRepository;
    }

    public async Task<Unit> Handle(OrganizadorDeletarCommand request, CancellationToken cancellationToken)
    {
        var registrosDeletados = await _organizadorRepository.DeleteAsync(request.Id);

        if (registrosDeletados == 0)
        {
            throw new KeyNotFoundException("Organizador não encontrado.");
        }

        return Unit.Value;
    }
}
