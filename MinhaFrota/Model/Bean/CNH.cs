using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class CNH
    {
        public int IdCNH { get; set; }
        public String Categoria { get; set; }
        public String NumeroRegistro { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
