using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioCriar
{
    public class Command : IRequest<Unit>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O email é obrigatório")
                .EmailAddress().WithMessage("O email deve ser válido");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória");
        }
    }

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly SenhaHash _senhaHash;

        public Handler(IUsuarioRepository usuarioRepository, IMapper mapper, SenhaHash senhaHash)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _senhaHash = senhaHash;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Usuario>(request);
            usuario.Senha = _senhaHash.Encriptar(usuario.Senha);

            await _usuarioRepository.Adicionar(usuario, true);
            return Unit.Value;
        }
    }
}