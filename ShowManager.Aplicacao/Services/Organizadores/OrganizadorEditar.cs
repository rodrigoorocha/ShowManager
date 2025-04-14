using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using System.Threading;
using System.Threading.Tasks;

namespace ShowManager.Aplicacao.Services.Organizadores;

public class OrganizadorEditar
{
    public class Command : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0).WithMessage("O ID do organizador deve ser maior que zero");

                RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("O nome do organizador é obrigatório")
                    .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres");
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
            var organizador = _mapper.Map<Organizador>(request);
            await _organizadorRepository.AtualizarAsync(organizador);
            return Unit.Value;
        }
    }
}