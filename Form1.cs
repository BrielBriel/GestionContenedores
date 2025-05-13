using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionContenedores
{
    public partial class Form1 : Form
    {
        Contenedor c;
        Pila p;
        Cola cx;
        public Form1()
        {
            InitializeComponent();
            p = new Pila(1000);
            cx = new Cola(1000);
            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!p.EstaLLena())
            {
                string tipo = txtTp.Text;
                double xd = Convert.ToDouble(txtKg.Text);
                c = new Contenedor(xd, tipo);
                c.GenerarID();
                c.GetDateRegister();
                p.Apilar(c);
            } else
            {
                MessageBox.Show("El sistema ha llegado a su limite de ingresos");
            }   
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtReporte_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtReporte.Text = p.MostrarReporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar el reporte.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
