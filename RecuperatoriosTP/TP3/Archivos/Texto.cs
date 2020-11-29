using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Constructors
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Texto() { }
        #endregion

        #region Methods
        /// <summary>
        /// Guarda en un archivo los datos recibidos por parametro.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool valorDeRetorno = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(datos);
                    valorDeRetorno = true;
                }

                return valorDeRetorno;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("No se pudo guardar el archivo de texto.", ex);
            }
        }

        /// <summary>
        /// Lee un archivo de texto y lo devuelve en el string recibido por parametro.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool valorDeRetorno = false;

            try
            {
                using (StreamReader reader = new StreamReader(archivo, Encoding.UTF8))
                {
                    datos = reader.ReadToEnd();
                    valorDeRetorno = true;
                }

                return valorDeRetorno;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("No se pudo leer el archivo de texto.", ex);
            }
        }
        #endregion
    }
}
