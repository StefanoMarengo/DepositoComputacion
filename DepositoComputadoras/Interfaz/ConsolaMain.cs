using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNegocio;
using ArgEventos;
using System.Threading;

namespace Interfaz
{
    //HANDLER 1
    //IMPRIMIR
    internal class ConsolaMain
    {
        static void Main(string[] args)
        {
            bool loop = true;
            LogicaMain instancia = LogicaMain.Instance;
            instancia.OperacionRealizada += ProductoAgregadoEliminado;

            while (loop)
            {
                Console.WriteLine("Elije la operación: \n 1 - Alta \n 2 - Baja \n 0 - Salir");
                int operac = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la marca:");
                string marca = Console.ReadLine();
                Console.WriteLine("Ingrese el Modelo");
                string modelo = Console.ReadLine();
                Console.WriteLine("Ingrese el Nro de serie");
                int nroSerie = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (operac)
                {
                    case 1:
                        Console.WriteLine("Ingrese Tipo \n 1 = Monitor \n 2 = Computadora");
                        int tipo = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("MONITOR \n Ingrese Año de fabricacion:");
                                int añoFabricacion = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Ingrese Pulgadas (0 -> Desconozco):");
                                int pulgadas = Convert.ToInt32(Console.ReadLine());

                                instancia.AgregarProducto(modelo, marca, nroSerie, añoFabricacion, pulgadas);
                                break;
                            case 2:
                                Console.WriteLine("COMPUTADORA \n Ingrese Descripción del procesador:");
                                string descripcion = Console.ReadLine();
                                Console.WriteLine("Ingrese Nombre del fabricante:");
                                string fabricante = Console.ReadLine();
                                Console.WriteLine("Ingrese RAM (Default: 2GB): ~ 4 GB - 8 GB - 16 GB ~");
                                int cantidadDeRam = Convert.ToInt32(Console.ReadLine());

                                instancia.AgregarProducto(modelo, marca, nroSerie, descripcion, cantidadDeRam, fabricante);
                                break;
                        }
                        break;
                    case 2:
                        instancia.EliminarProducto(modelo, marca, nroSerie);
                        break;
                    case 0:
                        loop = false;
                        break;

                }
                Console.Clear();
            }

            //Handler
            void ProductoAgregadoEliminado(object sender, EventosMain e)
            {
                Console.Clear();

                if (e.Mensaje == "")
                {
                    foreach (string valor in e.Lista)
                    {
                        if (valor == e.Lista.Last())
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{valor}. Total de MONITORES: {e.CantMonitores}.\n Total de COMPUTADORAS: {e.CantComputadoras}.\n Monitores: {(e.CantMonitores * 100) / e.Lista.Count}.\n Computadoras: {(e.CantComputadoras * 100) / e.Lista.Count}");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                            Console.WriteLine(valor);
                    }
                }
                else
                    Console.WriteLine(e.Mensaje);

                Thread.Sleep(2000);
            }
        }

    }
}
