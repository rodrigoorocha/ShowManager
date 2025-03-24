using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.DataBase.Repository.Shows;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.Aplicacao.Services.Shows
{
    public class ShowService(ShowRepository _showRepository) : IShowService
    {
        public async Task AtualizarAsync(Show showAtualizado)
        {
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
