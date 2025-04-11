using MediatR;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.DataBase.Repository.Shows;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowObterPorIdHandler : IRequestHandler<ShowObterPorIdQuery, Show>
{
    private readonly IShowRepository _showRepository;

    public ShowObterPorIdHandler(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    public async Task<Show> Handle(ShowObterPorIdQuery request, CancellationToken cancellationToken)
    {
        var show = await _showRepository.BuscarPorIdAsync(request.Id);
        if (show == null)
        {
            throw new KeyNotFoundException("Show não encontrado.");
        }

        return show;
    }
}
