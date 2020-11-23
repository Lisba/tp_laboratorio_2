using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        #region Fields
        int id;
        string nombre;
        int cantidad;
        double precioUnidad;
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }
        }

        public double PrecioUnidad
        {
            get
            {
                return precioUnidad;
            }
            set
            {
                precioUnidad = value;
            }
        }
        #endregion

        #region Constructors
        public Producto() { }

        /// <summary>
        /// Instancia un Producto.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="cantidad"></param>
        /// <param name="precioUnidad"></param>
        public Producto(string nombre, int cantidad, double precioUnidad)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precioUnidad = precioUnidad;
        }

        /// <summary>
        /// (Solo usado al importar de Base de Datos) Instancia un producto con ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="cantidad"></param>
        /// <param name="precioUnidad"></param>
        public Producto(int id, string nombre, int cantidad, double precioUnidad) : this(nombre, cantidad, precioUnidad)
        {
            this.id = id;
        }
        #endregion
    }
}
