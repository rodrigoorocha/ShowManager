using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.DataBase.Repository.Shows;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.Aplicacao.Services.Shows
{
    public class ShowService : IShowService
    {

        private readonly ShowRepository showRepository ;

        public ShowService(ShowRepository showRepository)
        {
            this.showRepository = showRepository;
        }
        public Task<string> Atulizar(Show show)
        {
            throw new NotImplementedException();
        }

        public Task<string> Buscar()
        {
            throw new NotImplementedException();
        }

        public Task<string> BuscarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Criar(Show show)
        {
            throw new NotImplementedException();
        }

        public Task<string> Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
