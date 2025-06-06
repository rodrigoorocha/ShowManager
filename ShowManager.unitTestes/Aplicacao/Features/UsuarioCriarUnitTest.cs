using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Moq;
using ShowManager.Aplicacao.Services.Usuarios;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.unitTestes.Aplicacao.Features;

public class UsuarioCriarUnitTest
{
    private readonly Mock<IUsuarioRepository> _usuariosRepositorioMock;
    private readonly Mock<SenhaHash> _senhaEncriptador;
    private readonly Mock<IMapper> _mapperMock;
    private readonly UsuarioCriar.Handler _Handler;

    // O construtor inicializa os mocks e instancia o Handler com as dependências simuladas.
    public UsuarioCriarUnitTest()
    {
        _usuariosRepositorioMock = new Mock<IUsuarioRepository>();
        _senhaEncriptador = new Mock<SenhaHash>("minhaChaveSecreta");
        _mapperMock = new Mock<IMapper>();
        _Handler = new UsuarioCriar.Handler(_usuariosRepositorioMock.Object, _mapperMock.Object, _senhaEncriptador.Object);
    }

    [Fact]
    public async Task CriarUsuario_Com_Dados_Corretos_Deve_CriarUsuario()
    {
        var command = new UsuarioCriar.Command
        {
            Nome = "João Silva",
            Email = "email",
            Senha = "senha123"
        };

        var usuario = new Usuario(command.Nome, command.Email, command.Senha);

        _mapperMock
            .Setup(m => m.Map<Usuario>(command))
            .Returns(usuario);

        _usuariosRepositorioMock
            .Setup(r => r.Adicionar(usuario, true))
            .Returns(Task.CompletedTask);

        _senhaEncriptador
            .Setup(s => s.Encriptar(It.IsAny<string>()))
            .Returns("senhaEncriptada");

        // Act
        var result = await _Handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(Unit.Value, result);

        _mapperMock.Verify(m => m.Map<Usuario>(command), Times.Once);
        _usuariosRepositorioMock.Verify(r => r.Adicionar(usuario, true), Times.Once);
        _senhaEncriptador.Verify(s => s.Encriptar(command.Senha), Times.Once);
        _senhaEncriptador.Verify(s => s.Encriptar(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task CriarUsuario_Com_ErroAoSalvarNoBanco_Deve_RetornarExcecao()
    {
        // Arrange
        var command = new UsuarioCriar.Command
        {
            Nome = "Test",
            Email = "test@example.com",
            Senha = "secret"
        };

        var usuario = new Usuario(command.Nome, command.Email, command.Senha);

        _mapperMock
            .Setup(m => m.Map<Usuario>(command))
            .Returns(usuario);

        _senhaEncriptador
            .Setup(s => s.Encriptar(It.IsAny<string>()))
            .Returns("senhacriptografada");

        _usuariosRepositorioMock
            .Setup(r => r.Adicionar(usuario, true))
            .ThrowsAsync(new Exception("Database error"));

        //Assert
        var result = _Handler.Handle(command, CancellationToken.None);
        // Assert
        await Assert.ThrowsAsync<Exception>(() => result);
    }
}