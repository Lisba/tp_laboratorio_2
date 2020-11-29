using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor con mensaje fijo.
        /// </summary>
        public ArchivosException() : base("No se pudo leer o escribir el archivo")
        {

        }

        /// <summary>
        /// Constructor con mensaje personalizado.
        /// </summary>
        public ArchivosException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor con mensaje fijo y una innerExcepcion.
        /// </summary>
        public ArchivosException(Exception innerExcepcion) : base("No se pudo leer o escribir el archivo", innerExcepcion)
        {

        }

        /// <summary>
        /// Constructor con mensaje personalizado y una innerExcepcion.
        /// </summary>
        public ArchivosException(string mensaje, Exception innerExcepcion) : base(mensaje, innerExcepcion)
        {

        }
    }
}
