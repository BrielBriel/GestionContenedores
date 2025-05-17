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
        Pila pMenorIgual;
        Pila pMayor;
        Cola cx;
        public Form1()
        {
            InitializeComponent();
            pMenorIgual = new Pila(1000);
            pMayor = new Pila(1000);
            cx = new Cola(1000);
            int[] camionesCarga = new int[] { 100 };
            
        }
        public string MostrarContenedorPorID(string idBuscado)
        {
            Contenedor encontrado = null;

            // Buscar en pMenorIgual
            encontrado = BuscarEnPilaPorID(pMenorIgual, idBuscado);
            if (encontrado != null)
                return encontrado.ToString();

            // Si no encontrado, buscar en pMayor
            encontrado = BuscarEnPilaPorID(pMayor, idBuscado);
            if (encontrado != null)
                return encontrado.ToString();

            return $"No se encontró contenedor con ID: {idBuscado}";
        }

        private Contenedor BuscarEnPilaPorID(Pila pila, string idBuscado)
        {
            Contenedor encontrado = null;
            Pila pilaTemporal = new Pila(pila.Size);

            while (!pila.EstaVacia())
            {
                Contenedor c = (Contenedor)pila.Desapilar();
                if (c._IdUnico == idBuscado)
                    encontrado = c;
                pilaTemporal.Apilar(c);
            }

            // Restaurar pila
            while (!pilaTemporal.EstaVacia())
                pila.Apilar(pilaTemporal.Desapilar());

            return encontrado;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTp.Text))
            {
                MessageBox.Show("Por favor, ingrese el tipo de contenedor.");
                return;
            }

            if (!double.TryParse(txtKg.Text, out double peso))
            {
                MessageBox.Show("Ingrese un peso válido.");
                return;
            }

            // Asumiendo que el constructor de Contenedor asigna la fecha actual a DateRegister
            c = new Contenedor(peso, txtTp.Text.Trim());
            c.GenerarID();

            if (peso <= 1000)
            {
                if (!pMenorIgual.EstaLLena())
                {
                    pMenorIgual.Apilar(c);
                    MessageBox.Show($"Contenedor agregado a livianos. ID: {c._IdUnico}");
                }
                else
                {
                    MessageBox.Show("La pila de contenedores ≤ 1000kg está llena.");
                }
            }
            else
            {
                if (!pMayor.EstaLLena())
                {
                    pMayor.Apilar(c);
                    MessageBox.Show($"Contenedor agregado a pesados. ID: {c._IdUnico}");
                }
                else
                {
                    MessageBox.Show("La pila de contenedores > 1000kg está llena.");
                }
            }

            // Limpieza de campos
            txtTp.Clear();
            txtKg.Clear();
        }



        private void TransferirPilasACola()
        {
            while (!pMayor.EstaVacia())
                cx.Ingresar(pMayor.Desapilar());

            while (!pMenorIgual.EstaVacia())
                cx.Ingresar(pMenorIgual.Desapilar());

            MessageBox.Show("Transferencia completada (pMayor + pMenorIgual → cola).");
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
            string id = txtIdBuscar.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }
            txtReporte.Text = MostrarContenedorPorID(id);
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
            txtReporte.Clear();
            txtReporte.AppendText(pMayor.MostrarReporte());
            txtReporte.AppendText("\n");
            txtReporte.AppendText(pMenorIgual.MostrarReporte());
            txtReporte.AppendText("\n");
        }


        private void BuscarYForzarCargaPorID(string idBuscado)
        {
            Cola colaTemporal = new Cola(1000);
            bool encontrado = false;
            string idBuscadoTrim = idBuscado.Trim();

            while (!cx.EstaVacia())
            {
                var obj = cx.Retirar();
                if (obj is Contenedor cont)
                {
                    if (string.Equals(cont._IdUnico.Trim(), idBuscadoTrim, StringComparison.OrdinalIgnoreCase))
                    {
                        if (cont.PesoEnKg <= 1000)
                            cont.FechaSalida = DateTime.Now.AddDays(1);
                        else
                            cont.FechaSalida = DateTime.Now.AddDays(3);

                        txtReporte.AppendText($"[CARGA FORZADA MANUALMENTE]{Environment.NewLine}{cont.ToString()}\n\n");
                        encontrado = true;

                        // Reingresar el contenedor modificado para que siga en la cola
                        colaTemporal.Ingresar(cont);
                        continue;
                    }
                }

                colaTemporal.Ingresar(obj);
            }

            // Restaurar cola con todos los elementos (incluyendo el modificado)
            while (!colaTemporal.EstaVacia())
                cx.Ingresar(colaTemporal.Retirar());

            if (!encontrado)
                MessageBox.Show("No se encontró el contenedor con ese ID.");
            else
                MessageBox.Show("Carga forzada por ID realizada.");
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = txtForzarCarga.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            TransferirPilasACola();
            BuscarYForzarCargaPorID(id);
           
        }

    }
}
