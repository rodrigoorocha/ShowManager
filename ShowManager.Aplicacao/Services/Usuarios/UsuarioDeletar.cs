using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;
using System.Threading;
using System.Threading.Tasks;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioDeletar
{
    public class Command : IRequest<Unit>
    {
        public int Id { get; set; }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0).WithMessage("O ID do usuário deve ser maior que zero");
            }
        }
    }

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public Handler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var show = _mapper.Map<Usuario>(request);
            await _usuarioRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}