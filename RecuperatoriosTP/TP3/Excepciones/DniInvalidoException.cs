using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor con mensaje fijo.
        /// </summary>
        public DniInvalidoException() : base("Dni invalido")
        {

        }

        /// <summary>
        /// Constructor con mensaje fijo.
        /// </summary>
        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor con mensaje fijo y una innerExcepcion.
        /// </summary>
        public DniInvalidoException(Exception innerExcepxion) : base("Dni invalido", innerExcepxion)
        {

        }

        /// <summary>
        /// Constructor con mensaje personalizado y una innerExcepcion.
        /// </summary>
        public DniInvalidoException(string mensaje, Exception innerExcepxion) : base(mensaje, innerExcepxion)
        {

        }
    }
}
