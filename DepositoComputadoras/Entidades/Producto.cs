using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int NroSerie { get; set; }
        public string Identificador { get; private set; } //se autocraftea con modelo-marca-serie
        public Producto(string modelo, string marca, int nroSerie)
        {
            Modelo = modelo;
            Marca = marca;
            NroSerie = nroSerie;
        }
    }
}
