using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.DataBase.Repository.Usuarios;

namespace ShowManager.Aplicacao.Services.Usuarios;

public class UsuarioCriarHandler(): IRequestHandler<UsuarioCriarCommand, Unit>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

 

    public async Task<Unit> Handle(UsuarioCriarCommand request, CancellationToken cancellationToken)
    {
        var usuario = _mapper.Map<Usuario>(request);
        await _usuarioRepository.Adicionar(usuario, true);
        return Unit.Value;
    }
}