using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Infra;

public class SenhaHash(string _chaveAdicional)
{
    public virtual string Encriptar(string senha)
    {
        var novaSenha = $"{senha}{_chaveAdicional}";

        var bytes = Encoding.UTF8.GetBytes(novaSenha);

        var hashBytes = SHA512.HashData(bytes);

        return StringBytes(hashBytes);
    }

    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(b);
        }

        return sb.ToString();
    }
}