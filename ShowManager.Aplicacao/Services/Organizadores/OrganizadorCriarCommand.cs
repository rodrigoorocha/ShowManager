using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorCriarCommand : IRequest<Unit>
{
    public string Apelido { get; set; }
    public List<Show> ListaShows { get; set; }
}
