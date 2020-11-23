using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contador = System.Windows.Forms.Timer;
using System.Threading;
using Entidades;

namespace Ojeda.Lisbaldy._2D.TP4
{
    #region Delegates
    public delegate void ManejadorTiempo(string mensaje);
    #endregion

    public partial class HomeForm : Form
    {
        #region Events
        public event ManejadorTiempo segundosCumplidos;
        #endregion

        #region Fields
        string idDoubleClickedRow;
        bool resultadoOpBaseDatos;
        List<Thread> listaHilosSecundarios;
        Contador contador;
        #endregion

        #region Constructors
        public HomeForm()
        {
            InitializeComponent();
            segundosCumplidos += ManejadorSegundosCumplidos;
        }
        #endregion

        #region Methods
        private void HomeForm_Load(object sender, EventArgs e)
        {
            CargaDataGridProductos();
            listaHilosSecundarios = new List<Thread>();
            contador = new Contador();
            ContadorDeSegundos();
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

        /// <summary>
        /// Inicia y maneja el proceso de insertar un nuevo producto a la base de datos.
        /// </summary>
        private void comenzarHiloSecundario()
        {
            AltaProductoForm altaProductoForm = new AltaProductoForm();
            if (altaProductoForm.ShowDialog() == DialogResult.OK)
            {
                resultadoOpBaseDatos = Convert.ToBoolean(BaseDatos.InsertarProducto(altaProductoForm.Producto.Nombre, altaProductoForm.Producto.Cantidad, altaProductoForm.Producto.PrecioUnidad));
                if (resultadoOpBaseDatos)
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
        /// Instancia e inicia un hilo secundario para insertar un nuevo producto aunque ya haya otros hilos corriendo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaHilosSecundarios.Add(new Thread(comenzarHiloSecundario));
            listaHilosSecundarios[listaHilosSecundarios.Count()-1].Start();
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

        /// <summary>
        /// Limpia el Carrito de compras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetCar_Click(object sender, EventArgs e)
        {
            if (CarritoCompras.ListaProductosCarrito.Count > 0)
            {
                CarritoCompras.RemoveAllItemsFromShopCar();
                CargarDataGridViewCarritoCompras();
            }
        }

        /// <summary>
        /// Inicia el proceso de compra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprarHome_Click(object sender, EventArgs e)
        {
            if (CarritoCompras.ListaProductosCarrito.Count > 0)
            {
                if (Validaciones.StockDisponibleParaComprar())
                {
                    CargarDatosCliente seleccionarClienteForm = new CargarDatosCliente();

                    if (seleccionarClienteForm.ShowDialog() == DialogResult.OK)
                    {
                        RestarCantidadProductos();
                        generarVenta(seleccionarClienteForm.Cliente);
                        CarritoCompras.RemoveAllItemsFromShopCar();
                        CargarDataGridViewCarritoCompras();
                        CargaDataGridProductos();
                        MessageBox.Show("¡Gracias por su compra! ", "¡Compra procesada!");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo concretar la compra!", "Operación incompleta");
                    }
                }
                else
                {
                    MessageBox.Show("¡Parece que te emocionaste demasiado!", "¡Saca productos del carrito!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Tu carrito esta vacío!", "Carrito vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Instancia una venta y llama al metodo correspondiente para serializarla.
        /// </summary>
        /// <param name="cliente"></param>
        private void generarVenta(Cliente cliente)
        {
            if(!serializarVenta(new Venta(CarritoCompras.ListaProductosCarrito, CarritoCompras.GetPrecioTotalAPagar(CarritoCompras.GetPrecioSubTotal(), cliente), cliente)))
            {
                MessageBox.Show("No se pudo serializar la venta", "Error");
            }
        }

        /// <summary>
        /// Obtiene la fecha, hora actual y llama al metodo correspondiente para serializar una venta.
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        private bool serializarVenta(Venta venta)
        {
            DateTime fecha = DateTime.Now;
            string fechaString = String.Format("{0:D}", fecha);
            Archivos<Venta> serializadorVenta = new Archivos<Venta>();
            return serializadorVenta.SerializarVenta(venta, $"Venta {fechaString}");
        }

        /// <summary>
        /// Recorre la lista de productos en el carrito de compras y llama a DisminuirCantidadProducto() para modificar la base de datos.
        /// </summary>
        private void RestarCantidadProductos()
        {
            foreach(Producto producto in CarritoCompras.ListaProductosCarrito)
            {
                BaseDatos.DisminuirCantidadProducto(producto);
            }
        }

        /// <summary>
        /// Agrega al carro de compras el producto de la fila seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Cierra todos los hilos abiertos antes de cerrar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(Thread hilo in listaHilosSecundarios)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }

        /// <summary>
        /// Cuenta 20 segundos utilizando un timer.
        /// </summary>
        private void ContadorDeSegundos()
        {
            contador.Interval = 20000;
            contador.Tick += ProcesadorDeContador;
            contador.Start();
        }

        /// <summary>
        /// Dispara al evento segundosCumplidos una vez cumplido el tiempo correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcesadorDeContador(Object sender, EventArgs e)
        {
            segundosCumplidos.Invoke("Hey!! Ya pasaste 20 segundos dentro de mi app, quieres cerrarla?");
        }

        /// <summary>
        /// Se ejecuta una vez disparado el evento segundosCumplidos.
        /// </summary>
        /// <param name="mensaje"></param>
        private void ManejadorSegundosCumplidos(string mensaje)
        {
            if(MessageBox.Show(mensaje, "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                contador.Stop();
            }
            
        }
        #endregion
    }
}
