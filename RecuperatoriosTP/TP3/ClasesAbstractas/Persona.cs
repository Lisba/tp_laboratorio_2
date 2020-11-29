using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Fields
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;
        #endregion

        #region Enums
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad get y set del campo apellido.
        /// </summary>
        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad get y set del campo nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad get y set del campo dni.
        /// </summary>
        public int DNI
        {
            get
            {
                return dni;
            }
            set
            {
                dni = ValidarDni(Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad get y set del campo dni en caso de ser de tipo string.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                int numero = ValidarDni(Nacionalidad, value);
                dni = ValidarDni(Nacionalidad, numero);
            }
        }

        /// <summary>
        /// Propiedad get y set del campo nombre.
        /// </summary>
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = ValidarNombreApellido(value);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor de Persona.
        /// </summary>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="nombre"></param>
        public Persona(string apellido, ENacionalidad nacionalidad, string nombre)
        {
            Apellido = apellido;
            Nacionalidad = nacionalidad;
            Nombre = nombre;
        }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string apellido, int dni, ENacionalidad nacionalidad, string nombre) : this(apellido, nacionalidad, nombre)
        {
            DNI = dni;
        }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string apellido, string dni, ENacionalidad nacionalidad, string nombre) : this(apellido, nacionalidad, nombre)
        {
            StringToDNI = dni;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Override del metodo ToString. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            try
            {
                StringBuilder stringDeRetorno = new StringBuilder();
                stringDeRetorno.AppendLine($"NOMBRE COMPLETO: {Apellido}, {Nombre}");
                stringDeRetorno.AppendLine($"NACIONALIDAD: {Nacionalidad}");

                return stringDeRetorno.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron interpretar los datos", ex);
            }

        }

        /// <summary>
        /// Valida que el dni ingresado contenga el formato establecido tanto para Argentinos como para extranjeros.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato > 0 && dato < 90000000)
            {
                if (nacionalidad == ENacionalidad.Argentino)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            else if (dato >= 90000000 && dato <= 99999999)
            {
                if (nacionalidad == ENacionalidad.Extranjero)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            else
            {
                throw new DniInvalidoException("DNI inválido, ingresar enteros positivos de 8 digitos o menos.");
            }
        }

        /// <summary>
        /// Sobrecarga de ValidarDni en caso de que el dato sea de tipo string.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniNumerico;

            if (int.TryParse(dato, out dniNumerico))
            {
                try
                {
                    return ValidarDni(nacionalidad, dniNumerico);
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
                catch (DniInvalidoException ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new DniInvalidoException("El formato ingresado debe ser numérico.");
            }
        }

        /// <summary>
        /// Valida que el dato ingresado sea un nombre o apellido válido.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string regex = @"[\wñÑ\s]";

            if (Regex.IsMatch(dato, regex))
            {
                return dato;
            }
            else
            {
                return String.Empty;
            }
        }
        #endregion
    }
}
