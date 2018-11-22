using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class ProdutoManutencao : Pessoa
    {
        public Manutencao Manutencao { get; set; }
        public Produto Produto { get; set; }
        public Double Quantidade { get; set; }
        public Double ValorUnitario { get; set; }
        public Double ValorTotal { get; set; }
        public int idProduto { get; set; }
        public string produto_nome { get; set; }
        public string unidadeMedida { get; set; }
    }
}