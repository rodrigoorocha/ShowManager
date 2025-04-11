using MediatR;
using ShowManager.Dominio.Features.Organizadores;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorObterPorIdQuery : IRequest<Organizador>
{
    public int Id { get; set; }
}
