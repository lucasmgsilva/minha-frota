using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Multa
    {
        public int IdMulta { get; set; }
        public Veiculo Veiculo { get; set; }
        public Motorista Motorista { get; set; }
        public DateTime DataInfracao { get; set; }
        public Infracao Infracao { get; set; }
        public Double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public Cidade Cidade { get; set; }
    }
}
