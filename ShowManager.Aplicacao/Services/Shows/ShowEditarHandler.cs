using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.DataBase.Repository.Shows;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowEditarHandler : IRequestHandler<ShowEditarCommand, Unit>
{
    private readonly IShowRepository _showRepository;
    private readonly IMapper _mapper;
    private readonly IOrganizadorService _organizadorService;

    public ShowEditarHandler(IShowRepository showRepository, IMapper mapper, IOrganizadorService organizadorService)
    {
        _showRepository = showRepository;
        _mapper = mapper;
        _organizadorService = organizadorService;
    }

    public async Task<Unit> Handle(ShowEditarCommand request, CancellationToken cancellationToken)
    {
        var organizador = await _organizadorService.BuscarPorIDAsync(request.OrganizadorId);
        if (organizador == null)
        {
            throw new Exception("Organizador não encontrado");
        }

        var show = await _showRepository.BuscarPorIdAsync(request.Id);
        if (show == null)
        {
            throw new KeyNotFoundException("Show não encontrado.");
        }

        _mapper.Map(request, show);

        await _showRepository.AtualizarAsync(show);
        return Unit.Value;
    }
}
