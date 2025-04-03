using MediatR;
using ShowManager.Dominio.Features.Shows;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowCriarCommand : IRequest<Unit>
{
    public string Nome { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Local { get; set; } = string.Empty;
}
