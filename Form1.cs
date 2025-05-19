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
        FechaSimulada fechaSimulada;
        List<Contenedor> entregados;
        private const int MAX_CONTENEDORES = 1000;
        private Timer resizeTimer;

        public Form1()
        {
            InitializeComponent();
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered",
        System.Reflection.BindingFlags.SetProperty |
        System.Reflection.BindingFlags.Instance |
        System.Reflection.BindingFlags.NonPublic,
        null, tableLayoutPanel1, new object[] { true });

            pMenorIgual = new Pila(1000);
            pMayor = new Pila(1000);
            cx = new Cola(1000);
            int[] camionesCarga = new int[] { 100 };
            fechaSimulada = new FechaSimulada();
            entregados = new List<Contenedor>();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            pictureBox1.SendToBack();
            tableLayoutPanel1.BringToFront();
            this.Refresh();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                e.Graphics.DrawImage(pictureBox1.Image, 0, 0, this.Width, this.Height);
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblFechaSimulada.Text = $"Fecha: {fechaSimulada}";
            txtReporte.ReadOnly = true;
            txtReporte.BackColor = SystemColors.Control;
            txtReporte.TabStop = false;

            // Ajustar los controles con Anchor para que se expandan con el formulario
            txtTp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKg.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtReporte.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            btnIngresar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.DoubleBuffered = true; // Habilitar el doble buffer para evitar parpadeos
            // Suscribirse al evento Resize para ajuste dinámico
            this.Resize += new EventHandler(Form1_Resize);
            this.ResizeBegin += new EventHandler(Form1_ResizeBegin);
            this.ResizeEnd += new EventHandler(Form1_ResizeEnd);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Ajustar los TextBox al tamaño del formulario
            txtReporte.Width = this.ClientSize.Width - 40;
            txtReporte.Height = this.ClientSize.Height - 150;

            // Ajustar GroupBox para mantener la organización
            groupBox1.Width = this.ClientSize.Width - 40;
            groupBox2.Width = this.ClientSize.Width - 40;
            groupBox3.Width = this.ClientSize.Width - 40;

            
            if (resizeTimer != null) resizeTimer.Stop(); // Detener el temporizador si ya está activo
            resizeTimer = new Timer();
            resizeTimer.Interval = 100; // Tiempo de espera para reducir repintados
            resizeTimer.Tick += (s, args) =>
            {
                resizeTimer.Stop(); // Detener el temporizador después de ejecutar el ajuste
                AjustarTamanos(); // Llamar a la función para ajustar los controles
            };
            resizeTimer.Start();
        }
        private void AjustarTamanos()
        {
            txtReporte.Width = this.ClientSize.Width - 40;
            txtReporte.Height = this.ClientSize.Height - 150;
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout(); // Suspende la actualización del formulario
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate(); // Redibuja la imagen con el nuevo tamaño
        }

        private int ContarContenedoresActuales()
        {
            int count = 0;

            // Contar en pila pesada
            Pila tempMayor = new Pila(pMayor.Size);
            while (!pMayor.EstaVacia())
            {
                var cont = (Contenedor)pMayor.Desapilar();
                count++;
                tempMayor.Apilar(cont);
            }
            while (!tempMayor.EstaVacia())
                pMayor.Apilar(tempMayor.Desapilar());

            // Contar en pila liviana
            Pila tempMenor = new Pila(pMenorIgual.Size);
            while (!pMenorIgual.EstaVacia())
            {
                var cont = (Contenedor)pMenorIgual.Desapilar();
                count++;
                tempMenor.Apilar(cont);
            }
            while (!tempMenor.EstaVacia())
                pMenorIgual.Apilar(tempMenor.Desapilar());

            // Contar en cola (en tránsito)
            Cola tempCola = new Cola(cx.Size);
            while (!cx.EstaVacia())
            {
                var cont = (Contenedor)cx.Retirar();
                count++;
                tempCola.Ingresar(cont);
            }
            while (!tempCola.EstaVacia())
                cx.Ingresar(tempCola.Retirar());

            // No contar los entregados porque ya salieron del sistema

            return count;
        }

        private void DespachoAutomatico(int maxDespachos = 10)
        {
            int despachados = 0;

            while (despachados < maxDespachos && (!pMenorIgual.EstaVacia() || !pMayor.EstaVacia()))
            {
                Contenedor cont = null;

                if (!pMenorIgual.EstaVacia())
                    cont = (Contenedor)pMenorIgual.Desapilar();
                else if (!pMayor.EstaVacia())
                    cont = (Contenedor)pMayor.Desapilar();

                if (cont != null)
                {
                    // Asignar fecha de salida simulada (si quieres)
                    cont.FechaSalida = fechaSimulada.FechaActual.AddDays(cont.PesoEnKg <= 1000 ? 1 : 3);

                    cx.Ingresar(cont);
                    despachados++;
                }
            }

            if (despachados > 0)
                MessageBox.Show($"{despachados} contenedores despachados automáticamente.");
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

            int capacidadMaxima = 1000;
            int contActuales = ContarContenedoresActuales();

            if (contActuales >= capacidadMaxima)
            {
                MessageBox.Show("No hay espacio disponible para agregar más contenedores.");
                return;
            }

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

            txtTp.Clear();
            txtKg.Clear();
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

        private void button2_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtDias.Text.Trim(), out int dias))
            {
                MessageBox.Show("Ingrese un número válido de días.");
                return;
            }

            DateTime fechaTentativa = fechaSimulada.FechaActual.AddDays(dias);

            if (fechaTentativa < DateTime.Now.Date)
            {
                MessageBox.Show("No se puede retroceder antes de la fecha actual del sistema.");
                return;
            }

            if (dias > 0)
            {
                fechaSimulada.AvanzarDias(dias);
                EliminarContenedoresEntregados();
                MessageBox.Show($"Avanzaste {dias} día(s).");
            }
            else if (dias < 0)
            {
                fechaSimulada.RetrocederDias(-dias);
                MessageBox.Show($"Retrocediste {-dias} día(s).");
            }
            else
            {
                MessageBox.Show("La fecha no ha cambiado.");
            }

            lblFechaSimulada.Text = $"Fecha simulada: {fechaSimulada}";
            txtDias.Clear();

        }

        public string MostrarContenedorPorID(string idBuscado)
        {
            Contenedor encontrado = null;

            // Buscar en entregados
            encontrado = entregados.FirstOrDefault(c => c._IdUnico == idBuscado);
            if (encontrado != null)
                return $"[CONTENEDOR YA ENTREGADO]{Environment.NewLine}{encontrado}";

            // Buscar en pilas
            encontrado = BuscarEnPilaPorID(pMenorIgual, idBuscado);
            if (encontrado != null)
                return encontrado.ToString();

            encontrado = BuscarEnPilaPorID(pMayor, idBuscado);
            if (encontrado != null)
                return encontrado.ToString();

            // Buscar en cola (en tránsito)
            Cola colaTemporal = new Cola(1000);
            string resultado = null;
            while (!cx.EstaVacia())
            {
                var obj = cx.Retirar();
                if (obj is Contenedor c && c._IdUnico == idBuscado)
                    resultado = c.ToString();

                colaTemporal.Ingresar(obj);
            }

            while (!colaTemporal.EstaVacia())
                cx.Ingresar(colaTemporal.Retirar());

            return resultado ?? $"No se encontró contenedor con ID: {idBuscado}";
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

            
            while (!pilaTemporal.EstaVacia())
                pila.Apilar(pilaTemporal.Desapilar());

            return encontrado;
        }

        private void TransferirPilasACola()
        {
            
            DateTime fechaEntrega = fechaSimulada.FechaActual.AddDays(1);
            Dictionary<DateTime, int> entregasPorDia = new Dictionary<DateTime, int>();

            void AsignarFecha(Contenedor cont, int diasExtra)
            {
                DateTime fechaTentativa = fechaEntrega.AddDays(diasExtra);

                while (entregasPorDia.ContainsKey(fechaTentativa) && entregasPorDia[fechaTentativa] >= 50)
                {
                    fechaTentativa = fechaTentativa.AddDays(1);
                }

                cont.FechaSalida = fechaTentativa;
                if (!entregasPorDia.ContainsKey(fechaTentativa))
                    entregasPorDia[fechaTentativa] = 0;
                entregasPorDia[fechaTentativa]++;
            }

            
            List<Contenedor> tempPesados = new List<Contenedor>();
            while (!pMayor.EstaVacia())
                tempPesados.Add((Contenedor)pMayor.Desapilar());

            tempPesados.Reverse(); 
            foreach (var cont in tempPesados)
            {
                AsignarFecha(cont, 3); 
                cx.Ingresar(cont);
            }

            List<Contenedor> tempLivianos = new List<Contenedor>();
            while (!pMenorIgual.EstaVacia())
                tempLivianos.Add((Contenedor)pMenorIgual.Desapilar());

            tempLivianos.Reverse(); 
            foreach (var cont in tempLivianos)
            {
                AsignarFecha(cont, 1); 
                cx.Ingresar(cont);
            }

            MessageBox.Show("Transferencia con asignación de fechas completada.");
        }
        private Pila EliminarEntregadosDePila(Pila pila)
        {
            Pila temp = new Pila(pila.Size);
            while (!pila.EstaVacia())
            {
                Contenedor c = (Contenedor)pila.Desapilar();
                if (c.FechaSalida != DateTime.MinValue && c.FechaSalida.Date <= fechaSimulada.FechaActual.Date)
                {
                    entregados.Add(c);
                }
                else
                {
                    temp.Apilar(c);
                }
            }
            while (!temp.EstaVacia())
                pila.Apilar(temp.Desapilar());

            return pila;
        }
       
        private Cola EliminarEntregadosDeCola(Cola cola)
        {
            Cola temp = new Cola(cola.Size);
            while (!cola.EstaVacia())
            {
                Contenedor c = (Contenedor)cola.Retirar();
                if (c.FechaSalida != DateTime.MinValue && c.FechaSalida.Date <= fechaSimulada.FechaActual.Date)
                {
                    entregados.Add(c);
                }
                else
                {
                    temp.Ingresar(c);
                }
            }
            return temp;
        }

        private void ActualizarReporteEntregados()
        {
            txtReporte.Clear();
            foreach (var c in entregados)
            {
                txtReporte.AppendText("[ENTREGADO]" + Environment.NewLine);
                txtReporte.AppendText(c.ToString());
                txtReporte.AppendText("\n\n");
            }
        }

        private void EliminarContenedoresEntregados()
        {
            entregados.Clear();

            pMayor = EliminarEntregadosDePila(pMayor);
            pMenorIgual = EliminarEntregadosDePila(pMenorIgual);
            cx = EliminarEntregadosDeCola(cx);

            ActualizarReporteEntregados();
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

                        txtReporte.AppendText($"CARGA FORZADA MANUALMENTE{Environment.NewLine}{cont.ToString()}\n\n");
                        encontrado = true;


                        colaTemporal.Ingresar(cont);
                        continue;
                    }
                }

                colaTemporal.Ingresar(obj);
            }


            while (!colaTemporal.EstaVacia())
                cx.Ingresar(colaTemporal.Retirar());

            if (!encontrado)
                MessageBox.Show("No se encontró el contenedor con ese ID.");
            else
                MessageBox.Show("Carga forzada por ID realizada.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtReporte.Clear();
            txtReporte.AppendText("CONTENEDORES ENTREGADOS" + Environment.NewLine);

            if (entregados.Count == 0)
            {
                txtReporte.AppendText("No hay contenedores entregados aún.\n");
                return;
            }

            foreach (var cont in entregados)
            {
                txtReporte.AppendText(cont.ToString() + Environment.NewLine);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenerarContenedoresAleatorios();

        }

        private void GenerarContenedoresAleatorios()
        {
            if (!int.TryParse(txtCantidadContenedores.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida de contenedores.");
                return;
            }

            // Despacho automático para liberar espacio
            DespachoAutomatico();

            int capacidadMaxima = 1000;
            int contActuales = ContarContenedoresActuales();

            if (cantidad + contActuales > capacidadMaxima)
            {
                MessageBox.Show("No se puede generar más de 1000 contenedores en total.");
                return;
            }

            Random rnd = new Random();
            string[] tipos = { "Alimentos", "Textiles", "Electrónicos", "Químicos", "Maquinaria", "Otros" };

            for (int i = 0; i < cantidad; i++)
            {
                double peso = rnd.Next(500, 5000);
                string tipo = tipos[rnd.Next(tipos.Length)];

                Contenedor cont = new Contenedor(peso, tipo);
                cont.GenerarID();

                if (peso <= 1000)
                {
                    if (!pMenorIgual.EstaLLena())
                        pMenorIgual.Apilar(cont);
                    else if (!pMayor.EstaLLena())
                        pMayor.Apilar(cont);
                    else
                        break;
                }
                else
                {
                    if (!pMayor.EstaLLena())
                        pMayor.Apilar(cont);
                    else if (!pMenorIgual.EstaLLena())
                        pMenorIgual.Apilar(cont);
                    else
                        break;
                }
            }

            MessageBox.Show($"{cantidad} contenedores aleatorios generados.");
        }



        private void button6_Click(object sender, EventArgs e)
        {
            txtReporte.Clear();

            // Transferir a la cola primero (si aún no se hizo)
            TransferirPilasACola();
            txtReporte.AppendText("=== Contenedores Registrados ===" + Environment.NewLine);
            Cola temporal = new Cola(cx.Size);

            while (!cx.EstaVacia())
            {
                var obj = cx.Retirar();
                if (obj is Contenedor cont)
                {
                    txtReporte.AppendText(cont.ToString() + Environment.NewLine);
                }
                temporal.Ingresar(obj);
            }

            while (!temporal.EstaVacia())
            {
                cx.Ingresar(temporal.Retirar());
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
