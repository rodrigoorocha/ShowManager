using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Shows;
using System.Threading;
using System.Threading.Tasks;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowDeletar
{
    public class Command : IRequest<Unit>
    {
        public int Id { get; set; }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0).WithMessage("O ID do show deve ser maior que zero");
            }
        }
    }

    public class Handler() : IRequestHandler<Command, Unit>
    {
        private readonly IShowRepository _showRepository;
        private readonly IMapper _mapper;

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var show = _mapper.Map<Show>(request);
            await _showRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}