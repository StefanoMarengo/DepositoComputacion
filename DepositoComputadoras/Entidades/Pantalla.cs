using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pantalla
    {
        public int AñoFabricacion { get; set; }
        public bool EsNuevo { get; private set; } //true if año actual=añofabric
        public int? Pulgadas { get; set; }
    }
}
