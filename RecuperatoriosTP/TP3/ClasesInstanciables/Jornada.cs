using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Fields
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Asigna los campos clase e Instructor y llama al constructor sin parámetros.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            Clase = clase;
            Instructor = instructor;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get y set para el campo alumnos.
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
                    throw new Exception("Error al cargar la lista de alumnos", ex);
                }
            }
        }

        /// <summary>
        /// Get y set para el campo clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return clase;
            }
            set
            {
                try
                {
                    clase = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar la clase", ex);
                }
            }
        }

        /// <summary>
        /// Get y ser para el campo instructor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return instructor;
            }
            set
            {
                try
                {
                    instructor = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar la clase", ex);
                }
            }
        }
        #endregion
        
        #region Methods
        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool valorRetorno = false;

            try
            {
                Texto texto = new Texto();
                if(texto.Guardar("Jornada.txt", jornada.ToString()))
                {
                    valorRetorno = true;
                }

                return valorRetorno;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("No se pudo guardar el archivo.", ex);
            }

        }

        /// <summary>
        /// Retorna los datos de la jornada como texto.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            try
            {
                string datos;
                Texto texto = new Texto();
                texto.Leer("Jornada.txt", out datos);
                return datos;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("No se pudo leer el archivo.", ex);
            }

        }

        /// <summary>
        /// Muestra todos los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.Append($"CLASE DE {clase} POR ");
                sb.AppendLine(Instructor.ToString());
                sb.AppendLine("ALUMNOS:");

                if (Alumnos.Count > 0)
                {
                    foreach (Alumno a in Alumnos)
                    {
                        sb.AppendLine(a.ToString());
                    }
                }
                else
                {
                    sb.AppendLine("No hay alumnos en esta clase");
                }

                sb.Append("<------------------------------------------------->");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron interpretar correctamente los datos", ex);
            }

        }

        /// <summary>
        /// Verifica si el alumno esta presente en la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            try
            {
                foreach (Alumno al in j.Alumnos)
                {
                    if (a == al)
                    {
                        return true;
                    }
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("Error en la comparacion == de Jornada y Alumno", ex);
            }

        }

        /// <summary>
        /// Verifica si el alumno no esta presente en la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada si no esta presente en ella.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            try
            {
                if (j != a)
                {
                    j.Alumnos.Add(a);
                }

                return j;

            }
            catch (Exception ex)
            {
                throw new Exception("Error en sobrecarga del operador + de Jornada y Alumno", ex);
            }
        }
        #endregion
    }
}
