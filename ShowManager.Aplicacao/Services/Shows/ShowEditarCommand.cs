using MediatR;
using ShowManager.Dominio.Features.Organizadores;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowEditarCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string NomeShow { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public int? NumeroParticipantes { get; set; }
    public int OrganizadorId { get; set; }
}



 