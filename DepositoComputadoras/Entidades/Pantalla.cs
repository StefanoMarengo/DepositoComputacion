using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pantalla : Producto
    {
        public Pantalla(string modelo, string marca, int nroSerie, int añoFabricacion, int? pulgadas) : base(modelo, marca, nroSerie)
        {
            AñoFabricacion = añoFabricacion;
            EsNuevo = AñoFabricacion == DateTime.Now.Year;
            Pulgadas = pulgadas == 0 ? null : pulgadas;
        }

        public int AñoFabricacion { get; set; }
        public bool EsNuevo { get; private set; } //true if año actual=añofabric
        public int? Pulgadas { get; set; }

        public override string CadenaListado()
        {
            return Pulgadas.HasValue ? $"Monitor {Marca} - {Modelo} - {Pulgadas}" : $"Monitor {Marca} - {Modelo}";
        }
    }
}
