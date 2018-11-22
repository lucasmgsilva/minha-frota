using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Manutencao : Pessoa
    {
        public int IdManutencao { get; set; }
        public DateTime DataManutencao { get; set; }
        public Veiculo Veiculo { get; set; }
        public Motorista Motorista { get; set; }
        public String Tipo { get; set; }
        public Double ValorTotal { get; set; }
        public List<ProdutoManutencao> ListaProdutoManutencao { get; set; }
        public List<ServicoManutencao> ListaServicoManutencao { get; set; }
    }
}
