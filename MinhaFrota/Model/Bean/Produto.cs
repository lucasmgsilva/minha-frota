using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Produto
    {
        public int idProduto { get; set; }
        public String produto { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
