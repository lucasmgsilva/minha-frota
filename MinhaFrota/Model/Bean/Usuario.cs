using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string usuario { get; set; }
        public string Senha { get; set; }
        public Cargo Cargo { get; set; }
        public Empresa Empresa { get; set; }
    }
}
