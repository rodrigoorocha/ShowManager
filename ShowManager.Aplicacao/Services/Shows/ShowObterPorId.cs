using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;
using System.Threading;
using System.Threading.Tasks;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowObterPorId
{
    public class Query : IRequest<Show>
    {
        public int Id { get; set; }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(q => q.Id)
                    .GreaterThan(0).WithMessage("O ID do show deve ser maior que zero");
            }
        }
    }

    public class Handler : IRequestHandler<Query, Show>
    {
        private readonly IShowRepository _showRepository;
        private readonly IMapper _mapper;

        public Handler(IShowRepository showRepository, IMapper mapper)
        {
            _showRepository = showRepository;
            _mapper = mapper;
        }

        public async Task<Show> Handle(Query request, CancellationToken cancellationToken)
        {
            var show = _mapper.Map<Show>(request);
            show.Duracao = show.CalcularDuracao();
            await _showRepository.BuscarPorIdAsync(request.Id);
            return show;
        }
    }
}