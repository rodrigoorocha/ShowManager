using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.DataBase.Repository.Shows;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowEditarHandler : IRequestHandler<ShowEditarCommand, Unit>
{
    private readonly IShowRepository _showRepository;
    private readonly IMapper _mapper;

    public ShowEditarHandler(IShowRepository showRepository, IMapper mapper)
    {
        _showRepository = showRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ShowEditarCommand request, CancellationToken cancellationToken)
    {
        var show = await _showRepository.BuscarPorIdAsync(request.Id);
        if (show == null)
        {
            throw new KeyNotFoundException("Show não encontrado.");
        }

        _mapper.Map(request, show);

        
        if (request.OrganizadorId != 0)
        {
            show.OrganizadorId = request.OrganizadorId;
           
        }

        await _showRepository.AtualizarAsync(show);
        return Unit.Value;
    }
}
