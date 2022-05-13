using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum CapacidadRAM { DOSGB, CUATROGB, OCHOGB, DIECISEISGB }
    public class Computadora : Producto
    {
        public Computadora(string modelo, string marca, int nroSerie, string descripcion, CapacidadRAM ram, string fabricante) : base(modelo, marca, nroSerie)
        {
            DescripcionCPU = descripcion;
            RAM = ram;
            Fabricante = fabricante;
        }

        public string DescripcionCPU { get; set; }
        public CapacidadRAM RAM { get; set; }
        public string Fabricante { get; set; }
    }
}
