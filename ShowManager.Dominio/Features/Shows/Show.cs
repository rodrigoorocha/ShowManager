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

    //public void Update(ShowEditarDTO showEditarDTO)
    //{
    //    NomeShow = showEditarDTO.NomeShow;
    //    DataInicio = showEditarDTO.DataInicio;
    //    DataFim = showEditarDTO.DataFim;
    //    NumeroParticipantes = showEditarDTO.NumeroParticipantes;
    //    Duracao = showEditarDTO.Duracao;
    //    OrganizadorId = showEditarDTO.OrganizadorId;
    //    Organizador = showEditarDTO.Organizador;
    //}

    public void Atualizar(Show showAtualizado)
    {
        NomeShow = showAtualizado.NomeShow;
        DataInicio = showAtualizado.DataInicio;
        DataFim = showAtualizado.DataFim;
        NumeroParticipantes = showAtualizado.NumeroParticipantes;
        Duracao = showAtualizado.Duracao;
        OrganizadorId = showAtualizado.OrganizadorId;
        Organizador = showAtualizado.Organizador;
    }
}
