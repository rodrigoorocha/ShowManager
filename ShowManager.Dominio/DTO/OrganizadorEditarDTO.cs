using ShowManager.Dominio.Features.Shows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Dominio.DTO
{
    public class OrganizadorEditarDTO
    {
        public string Apelido { get; set; }
        public List<Show> ListaShows { get; set; }
    }
}
