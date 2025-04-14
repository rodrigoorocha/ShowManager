using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Usuarios;
using System.Threading;
using System.Threading.Tasks;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioEditar
{
    public class Command : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0).WithMessage("O ID do usuário deve ser maior que zero");

                RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("O nome é obrigatório")
                    .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres");

                RuleFor(c => c.Email)
                    .NotEmpty().WithMessage("O email é obrigatório")
                    .EmailAddress().WithMessage("O email deve ser válido");
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
            var usuario = _mapper.Map<Usuario>(request);
            await _usuarioRepository.AtualizarAsync(usuario);
            return Unit.Value;
        }
    }
}