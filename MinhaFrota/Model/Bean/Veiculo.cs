using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Veiculo
    {
        public int IdVeiculo { get; set; }
        public Modelo Modelo { get; set; }
        public Combustivel Combustivel { get; set; }
        public String Placa { get; set; }
        public Cor Cor { get; set; }
        public DateTime AnoFabricacao { get; set; }
        public DateTime AnoModelo { get; set; }
        public int KmAtual { get; set; }
        public String Renavam { get; set; }
        public String CategoriaExigida { get; set; }
    }
}
