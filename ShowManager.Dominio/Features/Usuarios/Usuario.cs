using ShowManager.Dominio.Features.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Dominio.Features.Usuarios;

public class Usuario : Entidade
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public TipoUsuarioEnum TipoUsuarioEnum { get; set; }


    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }
}
