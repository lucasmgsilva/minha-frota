using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Modelo
    {
        public int IdModelo { get; set; }
        public String modelo { get; set; }
        public Marca Marca { get; set; }
    }
}
