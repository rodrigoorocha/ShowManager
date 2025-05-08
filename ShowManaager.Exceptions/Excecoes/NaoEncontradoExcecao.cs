using ShowManaager.Exceptions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManaager.Exceptions.Excecoes
{
    public class NaoEncontradoExcecao : ExcecaoDeNegocio
    {
        public NaoEncontradoExcecao(string mensagem) : base(mensagem)
        {
        }
    }
}