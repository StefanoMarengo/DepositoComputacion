using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ArgEventos;
using Persistencia;
using Entidades;

namespace LogicaNegocio
{
    //HANDLER 2
    //EVENTO 1
    public class LogicaMain //Hacer singleton?
    {
        public void AgregarProducto(string modelo, string marca, int nroSerie, int añoFabricacion, int? pulgadas)
        {
            Pantalla pantalla = new Pantalla(modelo, marca, nroSerie, añoFabricacion, añoFabricacion == DateTime.Today.Year ? true : false, pulgadas);
        }
        public void AgregarProducto(string modelo, string marca, int nroSerie, string descripcion, int capacidadRam, string fabricante)
        {
            CapacidadRAM capacidad;
            switch (capacidadRam)
            {
                case 4:
                    capacidad = CapacidadRAM.CUATROGB;
                    break;
                case 8:
                    capacidad = CapacidadRAM.OCHOGB;
                    break;
                case 16:
                    capacidad = CapacidadRAM.DIECISEISGB;
                    break;
                default:
                    capacidad = CapacidadRAM.DOSGB;
                    break;
            }
            Computadora computadora = new Computadora(modelo, marca, nroSerie, descripcion, capacidad, fabricante);
        }
    }
}
