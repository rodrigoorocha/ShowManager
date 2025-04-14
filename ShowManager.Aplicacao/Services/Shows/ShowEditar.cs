using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Shows;
using System.Threading;
using System.Threading.Tasks;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowEditar
{
    public class Command : IRequest<Unit>
    {
        public int Id { get; set; }
        public string NomeShow { get; set; } = string.Empty;
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int OrganizadorId { get; set; }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0).WithMessage("O ID do show deve ser maior que zero");

                RuleFor(c => c.NomeShow)
                    .NotEmpty().WithMessage("O nome do show é obrigatório")
                    .MaximumLength(200).WithMessage("O nome do show deve ter no máximo 200 caracteres");

                RuleFor(c => c.DataInicio)
                    .NotEmpty().WithMessage("A data de início é obrigatória");

                RuleFor(c => c.DataFim)
                    .GreaterThanOrEqualTo(c => c.DataInicio)
                    .WithMessage("A data de fim deve ser maior ou igual à data de início");

                RuleFor(c => c.OrganizadorId)
                    .GreaterThan(0).WithMessage("O ID do organizador é obrigatório e deve ser maior que zero");
            }
        }
    }

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IShowRepository _showRepository;
        private readonly IMapper _mapper;

        public Handler(IShowRepository showRepository, IMapper mapper)
        {
            _showRepository = showRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var show = _mapper.Map<Show>(request);
            await _showRepository.AtualizarAsync(show);
            return Unit.Value;
        }
    }
}