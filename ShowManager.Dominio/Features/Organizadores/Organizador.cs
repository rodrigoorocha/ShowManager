using ShowManager.Dominio.Features.Shared;
using ShowManager.Dominio.Features.Shows;


namespace ShowManager.Dominio.Features.Organizadores;

public class Organizador : Entidade
{
    public string Apelido { get; set; }
    public List<Show> ListaShows { get; set; }

}
