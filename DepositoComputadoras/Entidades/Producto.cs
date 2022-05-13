using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int NroSerie { get; set; }
        public string Identificador { get; private set; }
    }
}
