using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoED
{
  public class QuickSort
    {
        public int NumeroColaMenor;
        private int[] sort;
        private int iteracion = 0;
        int[] VectorOriginal;
        int[] VectorOrdenado;
        public QuickSort(int[] paso, int bajo, int alto)
        {
            VectorOriginal = paso;
            DateTime inicio = DateTime.Now;

           // Console.ForegroundColor = ConsoleColor.Green;
         //   Console.WriteLine("Inicio-QuickSort");

            quick(paso,bajo,alto);

            DateTime final = DateTime.Now;
            TimeSpan duracion = final - inicio;
            double segundosTotales = duracion.TotalSeconds;
            int segundos = duracion.Seconds;
            VectorOrdenado = sort;
            ///fin del algoritmo
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Fin");
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine("Resultados");
            //Console.WriteLine("Tiempo en segudos:" + duracion);
            //Console.WriteLine("Numero de iteraciones" + iteracion);
            //Console.WriteLine("vector ordenado");
            //for (int i = 0; i < VectorOrdenado.Length; i++)
            //{
            //    Console.Write(VectorOrdenado[i] + " ");
            //}
            //Console.WriteLine();
           
        }
        public void quick(int[] paso, int bajo, int alto) {


            sort = paso;
            if (sort == null || sort.Length == 0)
                return;
            if (bajo >= alto)
                return;

            int izquierda_indice = bajo;
            int derecha_indice = alto;

            int mitad = bajo + (alto - bajo) / 2;
            int pivote = sort[mitad];

            while (izquierda_indice <= derecha_indice)
            {
                iteracion++;
                while (sort[izquierda_indice] < pivote)
                {
                    izquierda_indice++;
                }

                while (sort[derecha_indice] > pivote)
                {
                    derecha_indice--;
                }

                if (izquierda_indice <= derecha_indice)
                {

                    int temp = sort[izquierda_indice];
                    sort[izquierda_indice] = sort[derecha_indice];
                    sort[derecha_indice] = temp;
                    izquierda_indice++;
                    derecha_indice--;
                }

            }


            // Recursivo
            if (bajo < derecha_indice)
            {
                quick(sort, bajo, derecha_indice);

            }
            if (alto > izquierda_indice)
            {
                quick(sort, izquierda_indice, alto);

            }

          
        }

        public int ObtenerColaMenor() {
   
            
            return VectorOrdenado[0];
        }

    }
}
