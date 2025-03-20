using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.DataBase.Repository.Shows;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.Aplicacao.Services.Shows
{
    public class ShowService : IShowService
    {

        private readonly ShowRepository showRepository ;

        public async Task<Show> Atualizar(ShowEditarDTO showEditarDTO, int id)
        {
            var show = new Show
            {
                Id = id,
                NomeShow = showEditarDTO.NomeShow,
                DataInicio = showEditarDTO.DataInicio,
                DataFim = showEditarDTO.DataFim,
                NumeroParticipantes = showEditarDTO.NumeroParticipantes,
                Duracao = showEditarDTO.Duracao,
                OrganizadorId = showEditarDTO.OrganizadorId,
                Organizador = showEditarDTO.Organizador
            };
            return await showRepository.SaveAsync(show);
           
        }

        public async Task<IEnumerable<Show>?> Buscar()
        {
            return await showRepository.GetAllAsync();
        }

        public Task<Show?> BuscarPorID(int id)
        {
            return showRepository.GetByIdAsync(id);
        }

        public async Task<Show> Criar(ShowAdicionarDTO showAdicionarDTO)
        {
            var show = new Show
            {
                NomeShow = showAdicionarDTO.NomeShow,
                DataInicio = showAdicionarDTO.DataInicio,
                DataFim = showAdicionarDTO.DataFim,
                NumeroParticipantes = showAdicionarDTO.NumeroParticipantes,
                Duracao = showAdicionarDTO.Duracao,
                OrganizadorId = showAdicionarDTO.OrganizadorId,
                Organizador = showAdicionarDTO.Organizador
            };
            return await showRepository.SaveAsync(show);
        }

        public async Task<int> Deletar(int id)
        {

            await showRepository.DeleteAsync(id);
            return id;
        }
    }
}
