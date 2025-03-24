using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Context;
using ShowManager.Infra.DataBase.Repository.Organizadores;
using ShowManager.Infra.DataBase.Repository.Shows;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.web.api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Adicionando o DbContext com SQL Server
        builder.Services.AddDbContext<ShowManagerContext>(options =>
            options.UseSqlServer(connectionString));

        //config do automapper
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        builder.Services.AddAutoMapper(assemblies);

        // Registrando os repositórios
        builder.Services.AddScoped<IOrganizadorRepository, OrganizadorRepository>();
        builder.Services.AddScoped<IShowRepository, ShowRepository>();
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        builder.Services.AddControllers();

        var app = builder.Build();

        // Apply migrations at startup
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ShowManagerContext>();
            dbContext.Database.Migrate();
        }

        // Configuração do pipeline HTTP
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
