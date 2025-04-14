using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioCriar
{
    public class Command : IRequest<Unit>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
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
        }
    }

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public Handler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Usuario>(request);
            await _usuarioRepository.Adicionar(usuario, true);
            return Unit.Value;
        }
    }
}