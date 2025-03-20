using ShowManager.Dominio.Features.Organizadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Dominio.DTO
{
    public class ShowAdicionarDTO
    {
        public string NomeShow { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int? NumeroParticipantes { get; set; }
        public TimeSpan? Duracao { get; set; }
        public int OrganizadorId { get; set; }
        public Organizador Organizador { get; set; }
    }
}
