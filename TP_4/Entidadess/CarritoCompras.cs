using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class CarritoCompras
    {
        #region Fields
        static List<Producto> listaProductosCarrito;
        #endregion

        #region Properties
        public static List<Producto> ListaProductosCarrito
        {
            get
            {
                return listaProductosCarrito;
            }
        }
        #endregion

        #region Constructor
        static CarritoCompras()
        {
            listaProductosCarrito = new List<Producto>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Remueve un producto el carrito de compras.
        /// </summary>
        /// <param name="producto"></param>
        public static void RemoveItemFromShopCar(Producto producto)
        {
            listaProductosCarrito.Remove(producto);
        }

        /// <summary>
        /// Vacía el carrito de compras.
        /// </summary>
        public static void RemoveAllItemsFromShopCar()
        {
            listaProductosCarrito.Clear();
        }

        /// <summary>
        /// Obtiene el subtotal del carrito de compras.
        /// </summary>
        /// <returns>El subtotal</returns>
        public static double GetPrecioSubTotal()
        {
            double subTotal = 0;

            foreach (Producto producto in listaProductosCarrito)
            {
                subTotal += producto.PrecioUnidad;
            }

            return subTotal;
        }

        /// <summary>
        /// Valida si el cliente se apellida Ojeda y devuelve el valor de descuento del 13% del subtotal recibido por parametro.
        /// </summary>
        /// <param name="subTotal"></param>
        /// <param name="cliente"></param>
        /// <returns>El descuento del 13% del subtotal recibido.</returns>
        public static double GetDescuento(double subTotal, Cliente cliente)
        {
            double returnValue = 0;

            if (Validaciones.ValidarClienteOjeda(cliente))
            {
                returnValue = subTotal / 100 * 13;
            }

            return returnValue;
        }

        /// <summary>
        /// Resta el descuento al subtotal calculando el total a pagar.
        /// </summary>
        /// <param name="subTotal"></param>
        /// <param name="cliente"></param>
        /// <returns>Valor total a pagar con descuento aplicado.</returns>
        public static double GetPrecioTotalAPagar(double subTotal, Cliente cliente)
        {
            subTotal -= GetDescuento(subTotal, cliente);
            return subTotal;
        }
        #endregion
    }
}
