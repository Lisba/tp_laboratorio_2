using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor con mensaje fijo.
        /// </summary>
        public SinProfesorException() : base("No hay profesores para la clase.")
        {

        }

        /// <summary>
        /// Constructor con mensaje personalizado.
        /// </summary>
        public SinProfesorException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor con mensaje fijo y una innerExcepcion.
        /// </summary>
        public SinProfesorException(Exception innerExcepcion) : base("No hay profesores para la clase.", innerExcepcion)
        {

        }

        /// <summary>
        /// Constructor con mensaje personalizado y una innerExcepcion.
        /// </summary>
        public SinProfesorException(string mensaje, Exception innerExcepcion) : base(mensaje, innerExcepcion)
        {

        }

    }
}
