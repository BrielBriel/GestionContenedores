using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContenedores
{
    class Contenedor
    {
        private static int contadorID = 0;
        private string IdUnico { get; set; }
        private double PesoEnKg { get; set; }
        private string TipoContendor { get; set; }
        private double PrecioCont;
        private DateTime DateRegister;

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
            IdUnico = contadorID.ToString("D4");
        }
        public double CalcularPrecio(double PesoEnKg)
        {
            return PrecioCont = this.PesoEnKg * 2;
        }

        public override string ToString()
        {
            return $"ID Contenedor: {IdUnico}, Tipo Producto: {this.TipoContendor}, " +
                   $"Peso: {PesoEnKg}kg, Fecha de ingreso: {DateRegister:dd/MM/yyyy HH:mm:ss}";
        }
    }
}
