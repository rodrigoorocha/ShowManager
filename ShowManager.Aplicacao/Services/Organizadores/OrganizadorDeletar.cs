using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using System.Threading;
using System.Threading.Tasks;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorDeletar
{
    public class Command : IRequest<Unit>
    {
        public int Id { get; set; }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0).WithMessage("O ID do organizador deve ser maior que zero");
            }
        }
    }

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IOrganizadorRepository _organizadorRepository;
        private readonly IMapper _mapper;

        public Handler(IOrganizadorRepository organizadorRepository, IMapper mapper)
        {
            _organizadorRepository = organizadorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var show = _mapper.Map<Show>(request);
            await _organizadorRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}