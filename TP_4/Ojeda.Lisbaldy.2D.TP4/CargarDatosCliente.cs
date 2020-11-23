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
    public partial class CargarDatosCliente : Form
    {
        #region Fields
        Cliente cliente;
        #endregion

        #region Constructors
        public CargarDatosCliente()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Valida los datos ingresados en los textBox e instancia un cliente con dichos datos al recibir el click sobre el boton adecuado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaCliente_Click_1(object sender, EventArgs e)
        {
            if (txtEmailCliente.Text == "")
            {
                if (Validaciones.ValidarString(txtNombreCliente.Text) && Validaciones.ValidarString(txtApellidoCliente.Text) && Validaciones.ValidarInt(txtDniCliente.Text) != -1)
                {
                    cliente = new Cliente(this.txtNombreCliente.Text, this.txtApellidoCliente.Text, Validaciones.ValidarInt(txtDniCliente.Text));
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {
                if (Validaciones.ValidarString(txtNombreCliente.Text) && Validaciones.ValidarString(txtApellidoCliente.Text) && Validaciones.ValidarInt(txtDniCliente.Text) != -1 && Validaciones.ValidarEmail(txtEmailCliente.Text))
                {
                    cliente = new Cliente(this.txtNombreCliente.Text, this.txtApellidoCliente.Text, Validaciones.ValidarInt(txtDniCliente.Text), txtEmailCliente.Text);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
        }
        #endregion
    }
}
