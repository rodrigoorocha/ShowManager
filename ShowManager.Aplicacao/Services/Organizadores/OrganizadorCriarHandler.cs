using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Infra.DataBase.Repository.Organizadores;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorCriarHandler : IRequestHandler<OrganizadorCriarCommand, Unit>
{
    private readonly IOrganizadorRepository _organizadorRepository;
    private readonly IMapper _mapper;

    public OrganizadorCriarHandler(IOrganizadorRepository organizadorRepository, IMapper mapper)
    {
        _organizadorRepository = organizadorRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(OrganizadorCriarCommand request, CancellationToken cancellationToken)
    {
        var organizador = _mapper.Map<Organizador>(request);
        await _organizadorRepository.Adicionar(organizador, true);
        return Unit.Value;
    }
}
