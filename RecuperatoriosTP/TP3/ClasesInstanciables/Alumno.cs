using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Fields
        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;
        #endregion

        #region Enums
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Alumno() : base() { }

        /// <summary>
        /// Setea el campo claseQueToma y llama al constructor de la clase base.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Setea el campo estadoCuenta y utiliza sobrecarga de constructores para el resto de los campos.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Muestra los datos del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            string estado;

            try
            {
                sb.AppendLine(base.MostrarDatos());

                if (estadoCuenta == EEstadoCuenta.AlDia)
                {
                    estado = "Cuota al día";
                }
                else
                {
                    estado = Enum.GetName(typeof(EEstadoCuenta), estadoCuenta).ToString();
                }

                sb.AppendLine($"ESTADO DE CUENTA: {estado}");
                sb.AppendLine($"TOMA CLASES DE: {claseQueToma}");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron interpretar los datos adecuadamente", ex);
            }

        }

        /// <summary>
        /// Retorna la clase que toma el alumno con el formato "TOMA CLASE DE [clase que toma]."
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"TOMA CLASE DE: {claseQueToma}");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron interpretar los datos adecuadamente", ex);
            }

        }

        /// <summary>
        /// Hace publicos los datos del alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Un alumno es igual a la clase si la toma.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool valorRetorno = false;

            try
            {
                if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                {
                    valorRetorno = true;
                }

                return valorRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("La referencia a la instancia del Alumno es nula", ex);
            }
        }

        /// <summary>
        /// Un alumno es distinto a la clase si no la toma.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }
        #endregion
    }
}
