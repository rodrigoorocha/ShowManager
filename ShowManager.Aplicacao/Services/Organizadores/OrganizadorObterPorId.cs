using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Usuarios;
using System.Threading;
using System.Threading.Tasks;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorObterPorId
{
    public class Query : IRequest<Organizador>
    {
        public int Id { get; set; }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(q => q.Id)
                    .GreaterThan(0).WithMessage("O ID do organizador deve ser maior que zero");
            }
        }
    }

    public class Handler : IRequestHandler<Query, Organizador>
    {
        private readonly IOrganizadorRepository _organizadorRepository;
        private readonly IMapper _mapper;

        public Handler(IOrganizadorRepository organizadorRepository, IMapper mapper)
        {
            _organizadorRepository = organizadorRepository;
            _mapper = mapper;
        }

        public async Task<Organizador> Handle(Query request, CancellationToken cancellationToken)
        {
            var organizador = _mapper.Map<Organizador>(request);
            await _organizadorRepository.BuscarPorIdAsync(request.Id);
            return organizador;
        }
    }
}