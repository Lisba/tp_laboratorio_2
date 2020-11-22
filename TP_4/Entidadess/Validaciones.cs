using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public static class Validaciones
    {
        #region Methods
        /// <summary>
        /// Valida que el string ingresado sea un entero válido.
        /// </summary>
        /// <param name="strInt"></param>
        /// <returns>Retorna el numero entero ó -1 en caso de no ser un entero.</returns>
        static public int ValidarInt(string strValue)
        {
            int returnValue;

            if (int.TryParse(strValue, out returnValue))
            {
                return returnValue;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Valida que el string ingresado sea un double válido.
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns>Retorna el numero double ó -1 en caso de no ser un double.</returns>
        static public double ValidarDouble(string strValue)
        {
            double returnValue;

            if (double.TryParse(strValue, out returnValue))
            {
                return returnValue;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Valida que el string ingresado sea un long válido.
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns>Retorna el numero long ó -1 en caso de no ser un long.</returns>
        static public long ValidarLong(string strValue)
        {
            long returnValue;

            if (long.TryParse(strValue, out returnValue))
            {
                return returnValue;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Valida que el string ingresado posea 2 ó mas caracteres.
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns>Retorna true si el string posee 2 ó mas caracteres, caso contrario retorna false.</returns>
        static public bool ValidarString(string strValue)
        {
            bool returnValue = false;

            if (strValue.Length > 1)
            {
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Valida una dirección de email utilizando una expresion regular.
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns>Retorna true si el email es válido, caso contrario retorna false.</returns>
        static public bool ValidarEmail(string strValue)
        {
            bool returnValue = false;
            string regex = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"; // Expresion Regular para determinar un email válido.

            if (Regex.IsMatch(strValue, regex))
            {
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Valida si el cliente recibido por parametros se apellida Ojeda.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>True o false si el cliente se apellida Simpson.</returns>
        public static bool ValidarClienteOjeda(Cliente cliente)
        {
            bool returnValue = false;

            if (cliente.Apellido.ToUpper() == "OJEDA")
            {
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Valida si el producto posee disponible la cantidad deseada a comprar.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cantidadDeseada"></param>
        /// <returns>True o False si posee o no la cantidad deseada a comprar.</returns>
        public static bool StockDisponibleDeProducto(Producto producto, int cantidadDeseada)
        {
            bool returnValue = true;

            if (cantidadDeseada > producto.Cantidad)
            {
                returnValue = false;
            }

            return returnValue;
        }

        /// <summary>
        /// Valida si la cantidad de productos requeridos en el carrito de compras existe disponible en el comercio.
        /// </summary>
        /// <returns>True o False si hay stock suficiente para efectuar la compra.</returns>
        public static bool StockDisponibleParaComprar()
        {
            bool returnValue = true;
            int count;

            foreach (Producto productoEnCarrito in CarritoCompras.ListaProductosCarrito)
            {
                count = 0;

                for (int i = 0; i < CarritoCompras.ListaProductosCarrito.Count; i++)
                {
                    if (productoEnCarrito.Id == CarritoCompras.ListaProductosCarrito[i].Id)
                    {
                        count++;
                    }
                }

                if (count > productoEnCarrito.Cantidad)
                {
                    returnValue = false;
                    break;
                }
            }

            return returnValue;
        }
        #endregion
    }
}
