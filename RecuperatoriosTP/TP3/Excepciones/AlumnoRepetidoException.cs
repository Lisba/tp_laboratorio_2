using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor con mensaje fijo.
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {

        }

        /// <summary>
        /// Constructor con mensaje personalizado.
        /// </summary>
        public AlumnoRepetidoException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor con mensaje fijo y una innerExcepcion.
        /// </summary>
        public AlumnoRepetidoException(Exception innerExcepcion) : base("Alumno repetido.", innerExcepcion)
        {

        }

        /// <summary>
        /// Constructor con mensaje personalizado y una innerExcepcion.
        /// </summary>
        public AlumnoRepetidoException(string mensaje, Exception innerExcepcion) : base(mensaje, innerExcepcion)
        {

        }
        
    }
}
