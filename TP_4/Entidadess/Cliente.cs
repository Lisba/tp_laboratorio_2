using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : IPersona
    {
        #region Fields
        int id;
        string nombre;
        string apellido;
        int dni;
        string email;
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
        }

        public int Dni
        {
            get
            {
                return dni;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Instancia un cliente con email vacío.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        public Cliente(string nombre, string apellido, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }

        /// <summary>
        /// Instancia un cliente con todos sus datos (utiliza sobrecarga de constructores).
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="email"></param>
        public Cliente(string nombre, string apellido, int dni, string email) : this(nombre, apellido, dni)
        {
            this.email = email;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Devuelve el nombre y apellido en un mismo string de un cliente (sobreescritura del metodo de clase padre).
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <returns>El string concatenando el tipo, nombre y apellido.</returns>
        public string ConcatNombreApellido(string nombre, string apellido)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{nombre} {apellido}");
            return sb.ToString();
        }
        #endregion
    }
}
