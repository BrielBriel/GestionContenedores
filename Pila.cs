using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContenedores
{
    class Pila
    {
        int NE { get; set; }
        int Size;
        object[] Arreglo;

        public Pila(int size)
        {
            Size = 1000;
            Arreglo = new object[Size];
            NE = 0;
        }

        public void Apilar(object elemento)
        {
            Arreglo[NE++] = elemento;
            Contenedor c;
        }

        public object Desapilar()
        {
            return Arreglo[--NE];
        }

        public bool EstaVacia()
        {
            if (NE == 0)
            {
                return true;
            }
            return false;
        }

        public bool EstaLLena()
        {
            if (NE == Size) 
            {
                return true;
            }
            return false;
        }

        public string MostrarReporte()
        {
            string Reporte = "";
            Contenedor c;
            for (int i = 0; i < this.NE; i++)
            {
                c = (Contenedor)Arreglo[i];
                Reporte = c.ToString() + Reporte;
            }
            return Reporte;
        }
        public object Buscar(int i)
        {
            return Arreglo[i];
        }
    }
}
