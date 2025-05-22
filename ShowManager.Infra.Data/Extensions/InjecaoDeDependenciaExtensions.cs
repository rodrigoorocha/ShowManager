using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Context;
using ShowManager.Infra.DataBase.Repository.Organizadores;
using ShowManager.Infra.DataBase.Repository.Shows;
using ShowManager.Infra.DataBase.Repository.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Infra.Extensions;

public static class InjecaoDeDependenciaExtensions
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ShowManagerContext>(options =>
            options.UseSqlServer(connectionString));

        // Registrando os repositórios
        services.AddScoped<IOrganizadorRepository, OrganizadorRepository>();
        services.AddScoped<IShowRepository, ShowRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
}