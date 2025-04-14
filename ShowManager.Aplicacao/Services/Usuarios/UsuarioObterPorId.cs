using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Usuarios;
using System.Threading;
using System.Threading.Tasks;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioObterPorId
{
    public class Query : IRequest<Usuario>
    {
        public int Id { get; set; }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(q => q.Id)
                    .GreaterThan(0).WithMessage("O ID do usuário deve ser maior que zero");
            }
        }
    }

    public class Handler : IRequestHandler<Query, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public Handler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Usuario> Handle(Query request, CancellationToken cancellationToken)
        {
            var usurio = _mapper.Map<Usuario>(request);
            await _usuarioRepository.BuscarPorIdAsync(request.Id);
            return usurio;
        }
    }
}