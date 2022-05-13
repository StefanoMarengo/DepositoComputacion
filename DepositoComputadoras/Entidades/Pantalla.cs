using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pantalla : Producto
    {
        public Pantalla(string modelo, string marca, int nroSerie, int añoFabricacion, bool flag, int? pulgadas) : base(modelo, marca, nroSerie)
        {
            AñoFabricacion = añoFabricacion;
            EsNuevo = flag;
            Pulgadas = pulgadas;
        }

        public int AñoFabricacion { get; set; }
        public bool EsNuevo { get; private set; } //true if año actual=añofabric
        public int? Pulgadas { get; set; }
    }
}
