using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.DataBase.Repository.Shows;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowEditarHandler : IRequestHandler<ShowEditarCommand, Unit>
{
    private readonly IShowRepository _showRepository;
    private readonly IMapper _mapper;
    private readonly IOrganizadorService _organizadorService;
    private readonly IOrganizadorRepository _organizadorRepository;

    public ShowEditarHandler(IShowRepository showRepository, IMapper mapper, IOrganizadorService organizadorService, IOrganizadorRepository organizadorRepository)
    {
        _showRepository = showRepository;
        _mapper = mapper;
        _organizadorService = organizadorService;
        _organizadorRepository = organizadorRepository;
    }


    public async Task<Unit> Handle(ShowEditarCommand request, CancellationToken cancellationToken)
    {
        var organizadorExiste = await _organizadorRepository.AnyAsync(o => o.Id == request.OrganizadorId);
        if (!organizadorExiste)
        {
            throw new KeyNotFoundException("Organizador não encontrado.");
        }

        var show = _mapper.Map<Show>(request);



        await _showRepository.AtualizarAsync(show);
        return Unit.Value;
    }
}
