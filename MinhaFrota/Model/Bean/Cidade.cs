using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Cidade
    {
        public int IdCidade { get; set; }
        public string cidade { get; set; }
        public Estado Estado { get; set; }
    }
}
