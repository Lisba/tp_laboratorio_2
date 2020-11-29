using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor con mensaje fijo.
        /// </summary>
        public NacionalidadInvalidaException() : base("Nacionalidad inválida")
        {

        }

        /// <summary>
        /// Constructor con mensaje personalizado.
        /// </summary>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor con mensaje fijo y una innerExcepcion.
        /// </summary>
        public NacionalidadInvalidaException(Exception innerExcepcion) : base("Nacionalidad inválida", innerExcepcion)
        {

        }

        /// <summary>
        /// Constructor con mensaje personalizado y una innerExcepcion.
        /// </summary>
        public NacionalidadInvalidaException(string mensaje, Exception innerExcepcion) : base(mensaje, innerExcepcion)
        {

        }
    }
}
