using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContenedores
{
    public class Contenedor
    {
        public static int contadorID = 0;
        public string IdUnico { get; set; }
        public double PesoEnKg { get; set; }
        public string TipoContendor { get; set; }
        public double PrecioCont;
        public DateTime DateRegister { get; set; }
        public DateTime FechaSalida { get; set; }

        public Contenedor()
        {
            this.IdUnico = "na";
            this.PesoEnKg = 0;
            this.TipoContendor = "na";
            this.PrecioCont = 0;
            this.DateRegister = DateTime.Now;
        }
        public string _IdUnico
        {
            get
            {
                return this.IdUnico;
            }
            set
            {
                this.IdUnico = value;
            }
        }
        public DateTime GetDateRegister()
        {
            return this.DateRegister;
        }

        public Contenedor(double pesoEnKg, string tipoContendor)
        {
            this.IdUnico = "na";
            this.PesoEnKg = pesoEnKg;
            this.TipoContendor = tipoContendor;
            this.DateRegister = DateTime.Now;
        }

        public void GenerarID()
        {
            contadorID++;
            IdUnico = $"C{contadorID:D3}";

            // Calcular fecha de salida automáticamente
            int diasEspera = PesoEnKg > 1000 ? 8 : 3;
            FechaSalida = DateRegister.AddDays(diasEspera);
        }


        public double CalcularPrecio(double PesoEnKg)
        {
            return PrecioCont = this.PesoEnKg * 2;
        }

        public override string ToString()
        {
            return
                $"ID Contenedor : {IdUnico.PadRight(6)}" + Environment.NewLine +
                $"Tipo Producto : {TipoContendor.PadRight(15)}" + Environment.NewLine +
                $"Peso (kg)     : {PesoEnKg,8:F2}" + Environment.NewLine +
                $"Fecha Ingreso : {DateRegister:dd/MM/yyyy HH:mm}" + Environment.NewLine +
                $"Fecha Salida  : {(FechaSalida == DateTime.MinValue ? "No asignada" : FechaSalida.ToString("dd/MM/yyyy HH:mm"))}" + Environment.NewLine +
                new string('-', 70) + Environment.NewLine;
        }



    }
}
