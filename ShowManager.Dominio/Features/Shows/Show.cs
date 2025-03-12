using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shared;

namespace ShowManager.Dominio.Features.Shows;

public class Show : Entidade
{
    public string NomeShow { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public int? NumeroParticipantes { get; set; }
    public TimeSpan? Duracao { get; set; }
    public int OrganizadorId { get; set; }
    public Organizador Organizador { get; set; }
}
