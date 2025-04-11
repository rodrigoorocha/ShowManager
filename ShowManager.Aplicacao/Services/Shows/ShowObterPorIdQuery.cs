using MediatR;
using ShowManager.Dominio.Features.Shows;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowObterPorIdQuery : IRequest<Show>
{
    public int Id { get; set; }
}
