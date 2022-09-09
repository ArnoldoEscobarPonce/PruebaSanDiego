using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanDiegoBE
{
    public class LecturaContadorBE
    {
        public int? IdLectura { get; set; }
        public string NumContador { get; set; }
        public DateTime? Fecha { get; set; }
        public Decimal? Valor { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
    }
}
