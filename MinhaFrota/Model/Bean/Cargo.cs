using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Cargo
    {
        public int IdCargo { get; set; }
        public string cargo { get; set; }
        public string Permissoes { get; set; }


        public override string ToString()
        {
            return this.cargo;
        }
    }
}
