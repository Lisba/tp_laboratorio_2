using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Fields
        private int legajo;
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad get y set del legajo.
        /// </summary>
        public int Legajo
        {
            set
            {
                this.legajo = value;
            }
            get
            {
                return this.legajo;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor por defecto, llama al de la clase base.
        /// </summary>
        public Universitario() : base()
        {

        }

        /// <summary>
        /// Setea el legajo y usa el contructor de la clase base.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Override del Metodo Equals, castea el objeto a tipo Universitario.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this == (Universitario)obj;
        }

        /// <summary>
        /// Retorna los datos del universitario para ser mostrados.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(base.ToString());
                sb.AppendLine($"LEGAJO NÚMERO: {Legajo}");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron interpretar los datos.", ex);
            }
        }

        /// <summary>
        /// Metodo Abstracto.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobrecarga del operador == para comprar si dos instancias de Universitario son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool valorDeRetorno = false;

            try
            {
                if (pg1.GetType() == pg2.GetType())
                {
                    if ((pg1.DNI == pg2.DNI) || (pg1.legajo == pg2.legajo))
                    {
                        valorDeRetorno = true;
                    }
                }

                return valorDeRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Error comparando ambas instancias de universitario.", ex);
            }
        }

        /// <summary>
        /// Sobrecarga del Operador de desigualdad para comprobar que dos instancias de universitario no sean iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
