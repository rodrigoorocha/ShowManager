using MediatR;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowEditarCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Local { get; set; } = string.Empty;
    public int OrganizadorId { get; set; } 
}
