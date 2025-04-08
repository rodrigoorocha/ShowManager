using MediatR;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorEditarCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
