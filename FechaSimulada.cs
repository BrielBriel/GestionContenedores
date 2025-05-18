using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContenedores
{
    public class FechaSimulada
    {
        public DateTime FechaActual { get; private set; }

        public FechaSimulada()
        {
            FechaActual = DateTime.Now.Date; 
        }

        public void AvanzarDias(int dias)
        {
            FechaActual = FechaActual.AddDays(dias);
        }

        public void RetrocederDias(int dias)
        {
            FechaActual = FechaActual.AddDays(-dias);
        }

        public void Reiniciar()
        {
            FechaActual = DateTime.Now.Date;
        }

        public override string ToString()
        {
            return FechaActual.ToString("dd/MM/yyyy");
        }
    }
}
