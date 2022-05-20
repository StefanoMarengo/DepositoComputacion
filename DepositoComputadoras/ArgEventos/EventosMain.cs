using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArgEventos
{
    public class EventosMain : EventArgs
    {
        public List<string> Lista { get; set; }
        public string Mensaje { get; set; }
        public int CantComputadoras { get; set; }
        public int CantMonitores { get; set; }
    }

}
