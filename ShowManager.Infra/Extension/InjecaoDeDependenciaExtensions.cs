using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShowManager.Infra.Extension;

public static class InjecaoDeDependenciaExtensions
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var chaveAdicional = configuration.GetValue<string>("Settings:Password:AdditionalKey");

        services.AddScoped(opt => new Hash(chaveAdicional!));
    }
}