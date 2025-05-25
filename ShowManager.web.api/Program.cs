using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShowManager.Aplicacao.Extensions;
using ShowManager.Aplicacao.features.Usuarios;
using ShowManager.Aplicacao.Services.Organizadores;
using ShowManager.Aplicacao.Services.Shows;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Context;
using ShowManager.Infra.DataBase.Repository.Organizadores;
using ShowManager.Infra.DataBase.Repository.Shows;
using ShowManager.Infra.DataBase.Repository.Usuarios;
using ShowManager.Infra.Extensions;
using ShowManager.web.api.Filters;

namespace ShowManager.web.api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddInfra(builder.Configuration);
        builder.Services.AddApplication();

        // Registrando os serviços
        builder.Services.AddScoped<IUsuarioService, UsuarioService>();
        builder.Services.AddScoped<IShowService, ShowService>();
        builder.Services.AddScoped<IOrganizadorService, OrganizadorService>();

        // Adiciona um filtro global para tratar exceções e retornar erros padronizados
        builder.Services.AddMvc(options => options.Filters.Add<FiltroParaExcecoes>());

        builder.Services.AddControllers();

        // Configuração do Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "Show Manager API", 
                Version = "v1",
                Description = "API para gerenciamento de shows e eventos"
            });
        });

        var app = builder.Build();

        // Apply migrations at startup
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ShowManagerContext>();
            dbContext.Database.Migrate();
        }

        // Configuração do pipeline HTTP
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Show Manager API V1");
                c.RoutePrefix = string.Empty; // Para servir o Swagger UI na raiz
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}