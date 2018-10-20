using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class ServicoManutencao : Pessoa
    {
        public Manutencao Manutencao { get; set; }
        public Servico Servico { get; set; }
        public Double Valor { get; set; }
    }
}
