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
        }

        public string Nombre
        {
            get
            {
                return nombre;
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
        }
        #endregion

        #region Constructors
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

        #region Methods
        /// <summary>
        /// Sobrecarga del operador + para agregar un producto a la lista de productos.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="listaProductos"></param>
        /// <returns>Retorna True o False si la operacion es exitosa o no.</returns>
        public static bool operator +(Producto producto, List<Producto> listaProductos)
        {
            bool returnValue = true;

            foreach (Producto productoDeLista in listaProductos)
            {
                if (productoDeLista.Nombre.ToUpper() == producto.Nombre.ToUpper())
                {
                    returnValue = false;
                    break;
                }
            }

            if (returnValue)
            {
                listaProductos.Add(producto);
            }

            return returnValue;
        }

        /// <summary>
        /// Setea el nombre del producto, no se utiliza propiedad para no permitir cambios desde el DataGridView.
        /// </summary>
        /// <param name="nombre"></param>
        public void SetNombreProducto(string nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Setea la cantidad del producto, no se utiliza propiedad para no permitir cambios desde el DataGridView.
        /// </summary>
        /// <param name="cantidad"></param>
        public void SetCantidadProducto(int cantidad)
        {
            this.cantidad = cantidad;
        }

        /// <summary>
        /// Setea el precio por unidad del producto, no se utiliza propiedad para no permitir cambios desde el DAtaGridView.
        /// </summary>
        /// <param name="precioUnidad"></param>
        public void SetPrecioProducto(double precioUnidad)
        {
            this.precioUnidad = precioUnidad;
        }

        /// <summary>
        /// Resta una unidad del producto en el stock total del comercio.
        /// </summary>
        public static void RestarStockAProducto()
        {
            foreach (Producto producto in CarritoCompras.ListaProductosCarrito)
            {
                producto.cantidad--;
            }
        }
        #endregion
    }
}
