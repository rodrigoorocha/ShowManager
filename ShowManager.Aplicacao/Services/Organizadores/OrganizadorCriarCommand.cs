using MediatR;
using ShowManager.Dominio.Features.Organizadores;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorCriarCommand : IRequest<Unit>
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
