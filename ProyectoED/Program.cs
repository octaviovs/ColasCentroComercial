using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProyectoED;
namespace ProyectoED
{
    class Program
    {
       public static DateTime fecha = DateTime.Now;

        public static int totalClientes = 1;
        public static int noCliente1=1;
        public static int noCliente2 = 1;
        public static int noCliente3 = 1;
        public static int noCliente4 = 1;
        public  static  string cliente;
        public static  Queue ColaCaja1 = new Queue();
        public static Queue ColaCaja2 = new Queue();
        public static Queue ColaCaja3 = new Queue();
        public static Queue ColaCaja4 = new Queue();

        static Thread proceso = new Thread(HiloProceso);

        static Thread Caja1 = new Thread(MetodoCaja1);
        static Thread Caja2 = new Thread(MetodoCaja2);
        static Thread Caja3 = new Thread(MetodoCaja3);
        static Thread Caja4 = new Thread(MetodoCaja4);
        static Thread AgregarClientes = new Thread(AgregarCliente);
        static Random ranTiempos = new Random();

        static String[] VectorNombres = new string[] { "Carlos   ", "Pedro   ", "Aurelio","Octavio","Karla  ","Monze  ","Luis   ","Laura  "};
        static int[] TamañoColas = new int[3];
        static int[] TamañoColasAux = new int[3];
        static Random rnd = new Random();


        public static int entrada = 1;
        public static int paso = 1;

        public static int variableFinalista = 0;
        public static int[] finalistas = new int[3];
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "Super mercado la esperanza";
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine("|█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████|");                                                                                    
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                            S U P E R M E R C A D O    L   A    E S P E R A N Z A                                    |");
            Console.WriteLine("|                                              SIMULADOR V1.1                                                         |");
            Console.WriteLine("|                                         El mejor lugar para comprar                                                 |");
            Console.WriteLine("|_____________________________________________________________________________________________________________________|");
            Console.WriteLine("|_____________________________________________________________________________________________________________________|");
            Console.WriteLine("|   Tulancingo Hgo.       Central de Tulancingo-Col. el Centro No12. C:P:125    Fecha y hora:{0,5}|",fecha);
            Console.WriteLine("|_____________________________________________________________________________________________________________________|");
            Console.WriteLine("|_____________________________________________________________________________________________________________________|");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|_____________________________________________________________________________________________________________________|");
            Console.WriteLine("|                             |                              |                               |                        |");
            Console.WriteLine("|                             |                              |                               |                        |");
            Console.WriteLine("|                             |                              |                               |                        |");
            Console.WriteLine("|           Caja 1            |           Caja 2             |            Caja 3             |        Caja 4          |");
            Console.WriteLine("|                             |                              |                               |                        |");
            Console.WriteLine("|                             |                              |                               |                        |");
            Console.WriteLine("|_____________________________|______________________________|_______________________________|________________________|");
            Console.WriteLine("|██████████████████████       ████████████████████████        ███████████████████████        ███████████████████      |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████|");
            Console.WriteLine("|_____________________________________________________________________________________________________________________|");


            // se inician las cajas

            Caja1.Start();
            Caja2.Start();
            Caja3.Start();
            DateTime inicioTiempo = DateTime.Now;
            
            int inicioFin = inicioTiempo.Minute+1;
            int inicio = 0;
            do
            {
            if (!proceso.IsAlive)
            {
                proceso.Start();
            }
            DateTime i = DateTime.Now;
              inicio = i.Minute;
            } while (inicio<=inicioFin);
            proceso.Suspend();
            
            do
            {

                if (ColaCaja1.Count==0)
                {
                    Caja1.Abort();
                    finalistas[variableFinalista] = 0;
                    variableFinalista++;
                }
                else
                     if (ColaCaja2.Count == 0)
                {
                    Caja3.Abort();
                    finalistas[variableFinalista] = 0;
                    variableFinalista++;
                }
                else
                     if (ColaCaja3.Count == 0)
                {
                    // Caja3.Suspend();
                    Caja3.Abort();
                    finalistas[variableFinalista] = 0;
                    variableFinalista++;
                }

                else
                     if (ColaCaja4.Count == 0)
                {
                    Caja4.Abort();
                    finalistas[variableFinalista] = 0;
                    variableFinalista++;
                }
            } while ((ColaCaja1.Count + ColaCaja2.Count + ColaCaja3.Count+ColaCaja4.Count)==0);
            

          
            Console.Clear();
            Console.WriteLine("                                dFin de la simulacion");
            Estadistcas();

            Console.ReadKey();
        }

        public static void Estadistcas() {
            totalClientes = noCliente1 + noCliente2 + noCliente3 + noCliente4;

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("____________________________________________________________________________________________________");
            Console.WriteLine("                                   Clientes ");
            Console.WriteLine("Total de clientes:"+totalClientes);
            Console.WriteLine("Total de clientes en caja 1: "+noCliente1);
            Console.WriteLine("Total de clientes en caja 2: " + noCliente2);
            Console.WriteLine("Total de clientes en caja 3: " + noCliente3);
            Console.WriteLine("Total de clientes en caja 4: " + noCliente4);
            Console.WriteLine("");
            Console.WriteLine("                            Tiempo ");
            Random rnd = new Random();

            Console.WriteLine("Total de clientes:" + 60000);
            Console.WriteLine("Total de clientes en caja 1: " + rnd.Next(1500, 2501));
            Console.WriteLine("Total de clientes en caja 2: " + rnd.Next(2000, 5001));
            Console.WriteLine("Total de clientes en caja 3: " + rnd.Next(2000, 4001));
            Console.WriteLine("Total de clientes en caja 4: " + rnd.Next(2000, 4501));
        }
        public static void HiloProceso() {
            do
            {
                Thread.Sleep(500);
                AgregarCliente();
            }
            while (true);


        }

        public static void AgregarCliente() {
             Console.SetCursorPosition(3, 13);
            Console.WriteLine("Caja 1: " + ColaCaja1.Count);
            Console.SetCursorPosition(3, 14);
            Console.WriteLine("Caja 2: " + ColaCaja2.Count);
            Console.SetCursorPosition(3, 15);
            Console.WriteLine("Caja 3: " + ColaCaja3.Count);
            Console.SetCursorPosition(3, 16);
            Console.WriteLine("Caja 4: " + ColaCaja4.Count);
            Random rn = new Random();

            cliente = VectorNombres[rn.Next(0, VectorNombres.Length)];

          
            if ((ColaCaja1.Count + ColaCaja2.Count + ColaCaja3.Count) ==60)
            {
                Console.SetCursorPosition(37, 13);
                Console.WriteLine("Cliente " + cliente + " pasa a la Caja 4           ");
                ColaCaja4.Enqueue(cliente);
                if (entrada==1)
                {
                    ColaCaja4.Enqueue(cliente);
                    Caja4.Start();
                    entrada = 0;
                }
             
                
               
              
            }
            else
            {

                TamañoColas[0] = ColaCaja1.Count;
                TamañoColas[1] = ColaCaja2.Count;
                TamañoColas[2] = ColaCaja3.Count;
                //TamañoColas[3] = ColaCaja4.Count;
                TamañoColasAux[0] = ColaCaja1.Count;
                TamañoColasAux[1] = ColaCaja2.Count;
                TamañoColasAux[2] = ColaCaja3.Count;
               // TamañoColasAux[3] = ColaCaja4.Count;
                QuickSort obj = new QuickSort(TamañoColasAux, 0, TamañoColas.Length - 1);

                int c = obj.ObtenerColaMenor();
                int menor = 0;
                for (int i = 0; i < TamañoColas.Length; i++)
                {
                    if (TamañoColas[i]==c)
                    {
                        menor = i;
                    }
                }
               Console.SetCursorPosition(20, 13);
                Console.WriteLine("                                                                                                  ");
                switch (menor)
                {
                    case 0:
                        Console.SetCursorPosition(37, 13);
                        Console.WriteLine("Cliente " + cliente + " pasa a la Caja 1");
                        ColaCaja1.Enqueue(cliente);
                        break;
                    case 1:
                        Console.SetCursorPosition(37, 13);
                        Console.WriteLine("Cliente " + cliente + " pasa a la Caja 2");
                        ColaCaja2.Enqueue(cliente);
                        break;
                    case 2:
                        Console.SetCursorPosition(37, 13);
                        Console.WriteLine("Cliente " + cliente + " pasa a la Caja 3");
                        ColaCaja3.Enqueue(cliente);             
                        break;
            

                }
                totalClientes++;
            }


        }
        public static void MetodoCaja4()
        {
        
            while (true)
            {
                if (ColaCaja4.Count!=0 )
                {
                    Thread.Sleep(ranTiempos.Next(2000,4501));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(90, 30);
                    Console.WriteLine("Se atendio a: " + ColaCaja4.Dequeue());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    noCliente4++;
                }
            }
        }

        public static void MetodoCaja3()
        {
            while (true)
            {
                if (ColaCaja3.Count != 0)
                {
                    Thread.Sleep(ranTiempos.Next(2000, 4001));
                    Console.SetCursorPosition(65, 30);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Se atendio a: " + ColaCaja3.Dequeue());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    noCliente3++;
                }

            }
        }

        public static void MetodoCaja2()
        {

            while (true)
            {
                if (ColaCaja2.Count != 0)
                {
                    Thread.Sleep(ranTiempos.Next(2000, 5001));
                    Console.SetCursorPosition(33, 30);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Se atendio a: " + ColaCaja2.Dequeue());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    noCliente2++;
                }

            }
        }

        public static void MetodoCaja1()
        {
            while (true)
            {
                if (ColaCaja1.Count != 0)
                {
                    Thread.Sleep(ranTiempos.Next(1500, 2501));
                    Console.SetCursorPosition(2, 30);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Se atendio a: " + ColaCaja1.Dequeue());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    noCliente1++;
                }
            }
        }
    }
}
