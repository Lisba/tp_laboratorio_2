using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Comercio
    {
        #region Fields
        static List<Producto> listaProductos;
        #endregion

        #region Properties
        /// <summary>
        /// Actualiza la lista de productos y la retorna (cualquier excepcion deberá ser capturada en la función que llama a esta propiedad).
        /// </summary>
        public static List<Producto> ListaProductos
        {
            get
            {
                return listaProductos;
            }
        }
        #endregion

        #region Constructor
        static Comercio()
        {
            listaProductos = new List<Producto>();
        }
        #endregion

        #region Methods
        public static void ActualizarListaComercio()
        {
            listaProductos = BaseDatos.TraerProductos();
        }
        #endregion
    }
}
