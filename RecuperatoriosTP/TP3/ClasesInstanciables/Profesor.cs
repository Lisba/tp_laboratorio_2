using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Fields
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;
        #endregion

        #region Constructors
        /// <summary>
        /// Inicializa el campo random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Inicializa la lista de clases y las carga al campo.
        /// </summary>
        public Profesor() : base()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Agrega los datos por parametro a una nueva instancia de Profesor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Genera y asigna dos clases aleatorias a la cola de clases.
        /// </summary>
        private void _randomClases()
        {
            int maximo = Enum.GetNames(typeof(Universidad.EClases)).Length;
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, maximo));
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, maximo));
        }

        /// <summary>
        /// Muestra los datos del Profesor en forma string (Sobreecribe el metodo MostrarDatos de la clase base).
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.Append(base.MostrarDatos());
                sb.AppendLine("CLASES DEL DIA:");

                foreach (Universidad.EClases item in clasesDelDia)
                {
                    sb.AppendLine(Enum.GetName(typeof(Universidad.EClases), item));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar los datos correctamente", ex);
            }
        }

        /// <summary>
        /// Retorna el nombre de las clases que el profesor da con el formato "CLASES DEL DIA".
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendLine($"CLASES DEL DIA: ");

                foreach (Universidad.EClases item in clasesDelDia)
                {
                    sb.AppendLine($"{item}");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error durante la ejecución de ParticiparEnClase", ex);
            }

        }

        /// <summary>
        /// Muestra públicamente los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Verifica si el profesor dicta una clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            try
            {
                if (i.clasesDelDia.Count <= 0)
                {
                    return false;
                }

                foreach (Universidad.EClases cla in i.clasesDelDia)
                {
                    if (cla == clase)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el operador de comparacion == de profesor y clase", ex);
            }

            return false;
        }

        /// <summary>
        /// Verifica si el profesor no dicta una clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
