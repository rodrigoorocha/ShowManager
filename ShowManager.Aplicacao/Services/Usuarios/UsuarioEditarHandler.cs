using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioEditarHandler : IRequestHandler<UsuarioEditarCommand, Unit>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioEditarHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UsuarioEditarCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.BuscarPorIdAsync(request.Id);
        if (usuario == null)
        {
            throw new KeyNotFoundException("Usuário não encontrado.");
        }

        _mapper.Map(request, usuario);
        await _usuarioRepository.AtualizarAsync(usuario);
        return Unit.Value;
    }
}
