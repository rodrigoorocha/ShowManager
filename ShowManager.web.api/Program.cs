using Microsoft.EntityFrameworkCore;
using ShowManager.Infra.Context;
using ShowManager.Infra.DataBase.Repository.Organizadores;
using ShowManager.Infra.DataBase.Repository.Shows;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.web.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicionando o DbContext com SQL Server
            builder.Services.AddDbContext<ShowManagerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Registrando os repositórios
            builder.Services.AddScoped<IOrganizadorRepository, OrganizadorRepository>();
            builder.Services.AddScoped<IShowRepository, ShowRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configuração do pipeline HTTP
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
