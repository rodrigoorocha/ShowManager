using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.DataBase.Repository.Shows;
using ShowManager.Infra.DataBase.Repository.Usuarios;
using ShowManager.Aplicacao.Services.Organizadores;
using ShowManager.Dominio.Features.Organizadores; // Add this line

namespace ShowManager.Aplicacao.Services.Shows
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository _showRepository;
        private readonly IOrganizadorService _organizadorService; // Add this line

        public ShowService(IShowRepository showRepository, IOrganizadorService organizadorService) // Modify constructor
        {
            _showRepository = showRepository;
        }

        public async Task AtualizarAsync(Show showAtualizado)
        {

            var organizador = await _organizadorService.BuscarPorIDAsync(showAtualizado.OrganizadorId);
            if (organizador == null)
            {
                throw new Exception("Organizador not found");
            }

            var showDoBanco = await BuscarPorIDAsync(showAtualizado.Id);
            showDoBanco.Atualizar(showAtualizado);
            await _showRepository.SaveChangesAsync();
        }

        public async Task<Show> BuscarPorIDAsync(int id)
        {
            var show = await _showRepository.BuscarPorIdAsync(id);

            if (show is null)
            {
                //NotFound
                throw new Exception();
            }

            return show;
        }

        public async Task CriarAsync(Show show)
        {
            // Verify if OrganizadorId exists
            var organizador = await _organizadorService.BuscarPorIDAsync(show.OrganizadorId);
            if (organizador == null)
            {
                throw new Exception("Organizador not found");
            }

            show.Organizador = organizador; // Inject Organizador
            await _showRepository.Adicionar(show, true);
        }

        public async Task DeletarAsync(int id)
        {
            var registrosDeletados = await _showRepository.DeleteAsync(id);

            if (registrosDeletados == 0)
            {
                //NotFound
                throw new Exception();
            }
        }
    }
}
