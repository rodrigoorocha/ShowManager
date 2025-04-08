using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Infra.DataBase.Repository.Organizadores;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorEditarHandler : IRequestHandler<OrganizadorEditarCommand, Unit>
{
    private readonly IOrganizadorRepository _organizadorRepository;
    private readonly IMapper _mapper;

    public OrganizadorEditarHandler(IOrganizadorRepository organizadorRepository, IMapper mapper)
    {
        _organizadorRepository = organizadorRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(OrganizadorEditarCommand request, CancellationToken cancellationToken)
    {
        var organizador = await _organizadorRepository.BuscarPorIdAsync(request.Id);
        if (organizador == null)
        {
            throw new KeyNotFoundException("Organizador não encontrado.");
        }

        _mapper.Map(request, organizador);
        await _organizadorRepository.AtualizarAsync(organizador);
        return Unit.Value;
    }
}
