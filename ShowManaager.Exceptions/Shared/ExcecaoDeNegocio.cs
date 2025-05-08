using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManaager.Exceptions.Shared
{
    public class ExcecaoDeNegocio : Exception
    {
        public ExcecaoDeNegocio(string mensagem) : base(mensagem)
        {
        }
    }
}