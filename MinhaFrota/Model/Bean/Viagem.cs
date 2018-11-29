using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Viagem
    {
        public int IdViagem { get; set; }
        public Veiculo Veiculo { get; set; }
        public int KmSaida { get; set; }
        public int KmChegada { get; set; }
        public Motorista Motorista { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public DateTime DataHoraChegada { get; set; }
        public List<Endereco> ListaEndereco { get; set; }
    }
}
