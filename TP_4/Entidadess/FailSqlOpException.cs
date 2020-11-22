using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion personalizada para fallas durante operaciones con la base de datos, se utiliza innerExceptions.
    /// </summary>
    public class FailSqlOpException : Exception
    {
        public FailSqlOpException(string mensaje) : base(mensaje)
        {

        }

        public FailSqlOpException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
