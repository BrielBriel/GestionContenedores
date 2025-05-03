using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContenedores
{
    class Cola
    {
        Object[] Arreglo;
        int Size;
        int NE { get;set; }
        int Inicio;
        int Final;

        public Cola(int size )
        {
            Size = size;
            Arreglo = new Object[Size];
            NE = 0;
            Inicio = 0;
            Final = 0;
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

        public void Ingresar(Object elemento)
        {
            if(EstaLLena() == false)
            {
                Arreglo[Final++] = elemento;
                NE++;

                if(Final == Size)
                    Final = 0;
            }
        }

        public object Retirar()
        {
            object aux = null;
            if (!EstaVacia())
            {
                aux = Arreglo[Inicio];
                Inicio++;
                NE--;
                if (Inicio == Size)
                    Inicio = 0;
            }
            return aux;
        }
        public int _NE
        {
            get
            {
                return NE;
            }
            set
            {
                NE = value;
            }
        }

        public object Cima()
        {
            return Arreglo[NE-1];
        }
    }
}
