using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Para evaluar si el numero en label es un Binario o un Decimal compuesto de unos y ceros.
        /// </summary>
        private bool binary;

        /// <summary>
        /// Constructor (entre otras cosas inicializa la variable binary a false).
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.binary = false;
        }

        /// <summary>
        /// Desactiva los botones convertir a Binario y a Decimal al iniciar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Limpia el formulario llamando al método Limpiar() y desactiva los botones convertir a binario y a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.binary = false;
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// Cierra el formulario llamando al método Close().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Muestra en el label el resultado de la operacion y habilita el boton convertir a Binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Limpia la pantalla del formulario.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// Crea 2 instancias de la clase "Numero" y llama al metodo estatico "Operar" de la clase "Calculadora".
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado de la operacion recibida por parámetros.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numberOne = new Numero(numero1);
            Numero numberTwo = new Numero(numero2);

            return Calculadora.Operar(numberOne, numberTwo, operador);
        }

        /// <summary>
        /// Convierte el numero en el label a Binario previa validacion (habilita y desabilita botones en concordancia).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.lblResultado.Text) && !this.binary)
            {
                this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
                this.binary = true;
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }

        /// <summary>
        /// Convierte el numero en el label a Decimal previa validacion (habilita y desabilita botones en concordancia).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.lblResultado.Text) && this.binary)
            {
                this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
                this.binary = false;
                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;
            }
        }
    }
}
