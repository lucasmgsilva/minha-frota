using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Abastecimento
    {
        public int IdAbastecimento { get; set; }
        public Motorista Motorista { get; set; }
        public Veiculo Veiculo { get; set; }
        public DateTime DataAbastecimento { get; set; }
        public float Litros { get; set; }
        public float ValorLitro { get; set; }
        public int KmAnterior { get; set; }
        public int KmAtual { get; set; }
        public int KmPercorridos { get; set; }
        public float Consumo { get; set; }
    }
}
