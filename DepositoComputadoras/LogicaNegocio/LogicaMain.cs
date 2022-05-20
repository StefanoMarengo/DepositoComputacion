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
    public class LogicaMain
    {
        //Singleton
        #region
        private static LogicaMain _instance = null;
        private LogicaMain() { }
        public static LogicaMain Instance { get { if (_instance == null) _instance = new LogicaMain(); return _instance; } }
        #endregion

        public EventHandler<EventosMain> OperacionRealizada;

        List<Pantalla> pantallas = new List<Pantalla>();
        List<Computadora> computadoras = new List<Computadora>();
        List<Producto> productos = new List<Producto>();

        private void NuevoEvento(string mensaje, List<string> lista, int cantComputadoras, int cantMonitores)
        {
            if (OperacionRealizada != null)
            {
                OperacionRealizada(this, new EventosMain() { Lista = lista, Mensaje = mensaje, CantComputadoras = cantComputadoras, CantMonitores = cantMonitores });
            }
        }
        public void AgregarProducto(string modelo, string marca, int nroSerie, int añoFabricacion, int? pulgadas)
        {
            pantallas.Add(new Pantalla(modelo, marca, nroSerie, añoFabricacion, pulgadas));
            NuevoEvento("", GetListaDescripciones(), computadoras.Count, pantallas.Count);
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
            computadoras.Add(new Computadora(modelo, marca, nroSerie, descripcion, capacidad, fabricante));
            NuevoEvento("", GetListaDescripciones(), computadoras.Count, pantallas.Count);
        }
        public List<Producto> GetListaProductos()
        {
            productos.Clear();
            productos.AddRange(pantallas);
            productos.AddRange(computadoras);
            return productos;
        }
        public List<string> GetListaDescripciones()
        {
            List<string> xlista = new List<string>();
            foreach (Producto producto in GetListaProductos())
            {
                xlista.Add(producto.CadenaListado());
            }
            return xlista;
        }
        private Producto BuscarProducto(string modelo, string marca, int numeroDeSerie)
        {
            return GetListaProductos().Find(x => x.Identificador == $"{modelo}-{marca}-{numeroDeSerie}");
        }
        public void EliminarProducto(string modelo, string marca, int nroSerie)
        {
            Producto productoBuscado = BuscarProducto(modelo, marca, nroSerie);
            if (productoBuscado != null)
            {
                if (productoBuscado is Computadora)
                    computadoras.Remove(computadoras.Find(x => x.Identificador == productoBuscado.Identificador));
                else
                    pantallas.Remove(pantallas.Find(x => x.Identificador == productoBuscado.Identificador));
                productos.Remove(productoBuscado);
                NuevoEvento($"Eliminado: {productoBuscado.CadenaListado()}", null, computadoras.Count, pantallas.Count);
            }
            else
                NuevoEvento("No se encontró un producto que coincida", null, computadoras.Count, pantallas.Count);
        }
    }
}
