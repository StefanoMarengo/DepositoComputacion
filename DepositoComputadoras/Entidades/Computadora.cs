using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum CapacidadRAM { DOSGB, CUATROGB, OCHOGB, DIECISEISGB }
    public class Computadora
    {
        public string DescripcionCPU { get; set; }
        public CapacidadRAM RAM { get; set; }
        public string Fabricante { get; set; }
    }
}
