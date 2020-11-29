using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Methods
        /// <summary>
        /// Serializa los datos en un XML.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool valorDeRetorno = false;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                    valorDeRetorno = true;
                }

                return valorDeRetorno;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("No se pudo serializar el archivo xml.", ex);
            }

        }

        /// <summary>
        /// Deserializa un xml y almacena dichos datos en la variable recibida por parametro.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool valorDeRetorno = false;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                    valorDeRetorno = true;
                }

                return valorDeRetorno;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("No se pudo deserializar el archivo XML.", ex);
            }

        }
        #endregion
    }
}
