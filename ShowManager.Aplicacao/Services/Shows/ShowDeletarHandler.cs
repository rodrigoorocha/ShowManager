using MediatR;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.DataBase.Repository.Shows;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowDeletarHandler : IRequestHandler<ShowDeletarCommand, Unit>
{
    private readonly IShowRepository _showRepository;

    public ShowDeletarHandler(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    public async Task<Unit> Handle(ShowDeletarCommand request, CancellationToken cancellationToken)
    {
        var show = await _showRepository.BuscarPorIdAsync(request.Id);
        if (show == null)
        {
            throw new KeyNotFoundException("Show não encontrado.");
        }

        await _showRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
