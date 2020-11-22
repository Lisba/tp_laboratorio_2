using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Ojeda.Lisbaldy._2D.TP4
{
    public partial class HomeForm : Form
    {
        string idDoubleClickedRow;

        public HomeForm()
        {
            InitializeComponent();
        }

        #region Methods
        private void HomeForm_Load(object sender, EventArgs e)
        {
            CargaDataGridProductos();
        }

        /// <summary>
        /// Carga el DataGridView de productos (Setea null para refrescar).
        /// </summary>
        private void CargaDataGridProductos()
        {
            try
            {
                this.dataGridViewProductos.DataSource = null;
                Comercio.ActualizarListaComercio();
                this.dataGridViewProductos.DataSource = Comercio.ListaProductos;
            }
            catch(FailSqlOpException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaProductoForm altaProductoForm = new AltaProductoForm();
            if (altaProductoForm.ShowDialog() == DialogResult.OK)
            {
                if (altaProductoForm.Producto + Comercio.ListaProductos)
                {
                    CargaDataGridProductos();
                    MessageBox.Show("Carga de datos exitosa!", "Carga Exitosa");
                }
                else
                {
                    MessageBox.Show("No se pudo completar la carga!", "Operación incompleta");
                }
            }
            else
            {
                MessageBox.Show("No se pudo concretar la carga de datos!", "Operación incompleta");
            }
        }

        /// <summary>
        /// Obtiene la fila seleccionada de la lista de productos al hacer click y valida que no sea la fila head.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private string ObtenerIdFilaSeleccionadaProductos(DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return "Click incorrecto";
            }
            else
            {
                return this.dataGridViewProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        /// <summary>
        /// Obtiene la fila seleccionada del carrito al hacer click y valida que no sea la fila head
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private string ObtenerIdFilaSeleccionadaCarrito(DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return "Click incorrecto";
            }
            else
            {
                return this.dataGridViewCarrito.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        /// <summary>
        /// Obtiene la fila selecciona al hacer solo un click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idDoubleClickedRow = ObtenerIdFilaSeleccionadaProductos(e);
        }

        /// <summary>
        /// Obtiene la fila seleccionada al hacer doble click y llama al metodo para cargar dicho producto al carrito de compras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewProductos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idDoubleClickedRow = ObtenerIdFilaSeleccionadaProductos(e);
            CargarProductoACarritoCompras(1);
        }

        /// <summary>
        /// Remueve un producto del carrito al hacer doble click sobre el.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCarrito_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idDoubleClickedRow = ObtenerIdFilaSeleccionadaCarrito(e);

            foreach (Producto producto in Comercio.ListaProductos)
            {
                if (producto.Id.ToString() == idDoubleClickedRow)
                {
                    CarritoCompras.RemoveItemFromShopCar(producto);
                    CargarDataGridViewCarritoCompras();
                    break;
                }
            }
        }

        /// <summary>
        /// Carga el producto al carrito de compras segun la cantidad deseada.
        /// </summary>
        /// <param name="cantidadDeseada"></param>
        private void CargarProductoACarritoCompras(int cantidadDeseada)
        {
            foreach (Producto producto in Comercio.ListaProductos)
            {
                if (producto.Id.ToString() == idDoubleClickedRow)
                {
                    if (Validaciones.StockDisponibleDeProducto(producto, cantidadDeseada))
                    {
                        for (int i = 0; i < cantidadDeseada; i++)
                        {
                            CarritoCompras.ListaProductosCarrito.Add(producto);
                        }

                        CargarDataGridViewCarritoCompras();
                    }
                    else
                    {
                        MessageBox.Show("Stock insuficiente!", "Insuficiente");
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Carga datos al DataGridView del carrito de compras y configura las columnas a mostrar (Setea null para refrescar).
        /// </summary>
        private void CargarDataGridViewCarritoCompras()
        {
            this.dataGridViewCarrito.DataSource = null;
            this.dataGridViewCarrito.DataSource = CarritoCompras.ListaProductosCarrito;
            this.dataGridViewCarrito.Columns["Id"].Visible = false;
            this.dataGridViewCarrito.Columns["Cantidad"].Visible = false;
            this.lblSubTotalCifraHome.Text = Math.Round(CarritoCompras.GetPrecioSubTotal(), 2).ToString();
        }
        #endregion

        private void btnResetCar_Click(object sender, EventArgs e)
        {
            if (CarritoCompras.ListaProductosCarrito.Count > 0)
            {
                CarritoCompras.RemoveAllItemsFromShopCar();
                CargarDataGridViewCarritoCompras();
            }
        }

        private void btnComprarHome_Click(object sender, EventArgs e)
        {
            //if (CarritoCompras.ListaProductosCarrito.Count > 0)
            //{
            //    if (Validaciones.StockDisponibleParaComprar())
            //    {
            //        SeleccionarClienteForm seleccionarClienteForm = new SeleccionarClienteForm();

            //        if (seleccionarClienteForm.ShowDialog() == DialogResult.OK)
            //        {
            //            CarritoCompras.RemoveAllItemsFromShopCar();
            //            CargarDataGridViewCarritoCompras();
            //            CargaDataGridProductos();
            //            RepodrucirSonidoDeCompra();
            //            MessageBox.Show("Gracias!! Vuelva Prontosss", "¡Gracias por su compra!");
            //        }
            //        else
            //        {
            //            MessageBox.Show("No se pudo concretar la compra!", "Operación incompleta");
            //        }
            //    }
            //    else
            //    {

            //        MessageBox.Show("¡Parece que te emocionaste demasiado!", "¡Saca productos del carrito!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Tu carrito esta vacío!", "Carrito vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void btbAgregarAlCarro_Click(object sender, EventArgs e)
        {
            int cantidadDeseada = Validaciones.ValidarInt(txtCantidadHome.Text);

            if(idDoubleClickedRow is null)
            {
                idDoubleClickedRow = "1";
            }

            if (cantidadDeseada > 0)
            {
                CargarProductoACarritoCompras(cantidadDeseada);
            }
            else
            {
                MessageBox.Show("Ingrese un número válido!", "¡Valor Inválido!");
            }
        }
    }
}
