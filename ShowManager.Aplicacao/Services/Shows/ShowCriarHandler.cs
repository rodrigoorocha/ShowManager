using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.DataBase.Repository.Shows;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowCriarHandler : IRequestHandler<ShowCriarCommand, Unit>
{
    private readonly IShowRepository _showRepository;
    private readonly IMapper _mapper;

    public ShowCriarHandler(IShowRepository showRepository, IMapper mapper)
    {
        _showRepository = showRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ShowCriarCommand request, CancellationToken cancellationToken)
    {
        var show = _mapper.Map<Show>(request);
        await _showRepository.Adicionar(show, true);
        return Unit.Value;
    }
}
