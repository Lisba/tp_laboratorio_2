using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Archivos<T> where T : class
    {
        /// <summary>
        /// Serializa un objeto recibido por parámetro (Utiliza Generic para lograr su funcionalidad).
        /// </summary>
        /// <param name="objeto"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public bool SerializarVenta(T objeto, string nombre)
        {
            string rutaDelArchivo = AppDomain.CurrentDomain.BaseDirectory + nombre + ".xml";

            try
            {
                using(XmlTextWriter escritor = new XmlTextWriter(rutaDelArchivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(escritor, objeto);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
