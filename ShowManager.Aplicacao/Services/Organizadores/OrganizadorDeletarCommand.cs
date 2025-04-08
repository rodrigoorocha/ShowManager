using MediatR;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorDeletarCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
