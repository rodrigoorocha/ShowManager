using MediatR;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowDeletarCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
