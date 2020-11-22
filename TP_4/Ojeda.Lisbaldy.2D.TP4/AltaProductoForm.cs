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
    public partial class AltaProductoForm : Form
    {
        #region Fields
        Producto producto;
        #endregion

        #region Properties
        public Producto Producto
        {
            get
            {
                return producto;
            }
        }
        #endregion

        #region Constructors
        public AltaProductoForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Al recibir click sobre el boton adecuado valida los campos de textBox e instancia un Producto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaProducto_Click(object sender, EventArgs e)
        {
            if (Validaciones.ValidarString(txtNombreProducto.Text) && Validaciones.ValidarInt(txtCantidadProducto.Text) != -1 && Validaciones.ValidarDouble(txtPrecioUnidadProducto.Text) != -1)
            {
                producto = new Producto(txtNombreProducto.Text, Validaciones.ValidarInt(txtCantidadProducto.Text), Validaciones.ValidarDouble(txtPrecioUnidadProducto.Text));
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }
        #endregion
    }
}
