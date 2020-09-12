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
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numberOne = new Numero(numero1);
            Numero numberTwo = new Numero(numero2);

            return Calculadora.Operar(numberOne, numberTwo, operador);
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.lblResultado.Text))
            {
                Numero conversor = new Numero();
                this.lblResultado.Text = conversor.DecimalBinario(this.lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.lblResultado.Text))
            {
                Numero conversor = new Numero();
                this.lblResultado.Text = conversor.BinarioDecimal(this.lblResultado.Text);
            }
        }
    }
}
