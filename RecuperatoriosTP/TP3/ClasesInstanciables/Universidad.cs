using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(Universitario))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]
    public class Universidad
    {
        #region Fields
        List<Alumno> alumnos;
        List<Jornada> jornadas;
        List<Profesor> profesores;
        #endregion

        #region Enums
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Set y get del campo alumnos (verifica que no se setee null).
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                try
                {
                    alumnos = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo setear la lista de alumnos", ex);
                }
            }
        }

        /// <summary>
        /// Set y get de la lista de Profesores (verifica que no se setee null).
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return profesores;
            }
            set
            {
                try
                {
                    profesores = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo setear la lista de profesores", ex);
                }

            }
        }

        /// <summary>
        /// Set y get de la lista de Jornadas (verifica que no se setee null).
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return jornadas;
            }
            set
            {
                try
                {
                    jornadas = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo setear la lista de jornadas", ex);
                }
            }
        }

        /// <summary>
        /// Indexador de lista de jornadas (verifica que no se setee null).
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }
            set
            {
                try
                {
                    jornadas[i] = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo setear la jornada", ex);
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Serializa una universidad en un archivo XML.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> archivo = new Xml<Universidad>();
                return archivo.Guardar("Universidad.xml", uni);
            }
            catch (Exception ex)
            {
                throw new ArchivosException("no se pudo serializar el archivo", ex);
            }

        }

        /// <summary>
        /// Deserializa un archivo Xml a un objeto universidad en memoria.
        /// </summary>
        /// <returns>Retorna un objeto Universidad</returns>
        public static Universidad Leer()
        {
            Universidad universidad;

            try
            {
                Xml<Universidad> archivo = new Xml<Universidad>();
                archivo.Leer("Universidad.xml", out universidad);
                return universidad;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("No se pudo deserializar el archivo.", ex);
            }

        }

        /// <summary>
        /// Metodo que muestra los datos de Universidad en formato string.
        /// </summary>
        /// <param name="universidad"></param>
        /// <returns></returns>
        static string MostrarDatos(Universidad universidad)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                if (universidad.Jornadas.Count > 0)
                {
                    sb.AppendLine("JORNADA:");

                    foreach (Jornada item in universidad.Jornadas)
                    {
                        sb.AppendLine(item.ToString());
                    }
                }
                else
                {
                    sb.AppendLine("No hay jornadas cargadas");
                }

                return sb.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("Error en MostrarDatos", ex);
            }

        }

        /// <summary>
        /// Muestra los datos de la universidad en formato string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Sobrecarga del operador == con parametros Universidad y Alumno.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool valorRetorno = false;

            try
            {
                foreach (Alumno item in g.Alumnos)
                {
                    if (item == a)
                    {
                        valorRetorno = true;
                    }
                }

                return valorRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Referencia nula a la instancia de Universidad, Alumno o Alumnos", ex);
            }
        }

        /// <summary>
        /// Sobrecarga del operador != con parametros Universidad y Alumno.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga del operador == con parametros Universidad y Profesor.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool valorRetorno = false;

            try
            {
                foreach (Profesor item in g.Instructores)
                {
                    if (item == i)
                    {
                        valorRetorno = true;
                    }
                }

                return valorRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Referencia nula a la instancia de Universidad, Profesor o Instructores", ex);
            }
        }

        /// <summary>
        /// Sobrecarga del operador != con parametros Universidad y Profesor.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga del operador == con parametros Universidad y EClases.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Sobrecarga del operador != con parametros Universidad y EClases.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            try
            {
                foreach (Profesor item in u.Instructores)
                {
                    if (item != clase)
                    {
                        return item;
                    }
                }

                throw new SinProfesorException("No se encontraron profesores que no puedan dar la clase");
            }
            catch (Exception ex)
            {
                throw new Exception("Error durante la comparación de desigualdad de universidad y EClase", ex);
            }
        }

        /// <summary>
        /// Sobrecarga del operador + con parametros Universidad y EClases.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            try
            {
                Jornada jornada = new Jornada(clase, (g == clase));

                foreach (Alumno item in g.Alumnos)
                {
                    if (item == jornada.Clase)
                    {
                        jornada.Alumnos.Add(item);
                    }
                }
                g.Jornadas.Add(jornada);
                return g;
            }
            catch (SinProfesorException ex)
            {
                throw new SinProfesorException(ex);
            }
        }

        /// <summary>
        /// Sobrecarga del operador + con parametros Universidad y Alumno.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            foreach (Alumno item in u.Alumnos)
            {
                if (item == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }

            u.Alumnos.Add(a);
            return u;
        }

        /// <summary>
        /// Sobrecarga del operador + con parametros Universidad y Profesor.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            try
            {
                foreach (Profesor item in u.Instructores)
                {
                    if (item == i)
                    {
                        return u;
                    }
                }

                u.Instructores.Add(i);
                return u;
            }
            catch (Exception e)
            {
                throw new Exception("Error al agregar profesor a la universidad.", e);
            }
        }
        #endregion
    }
}
