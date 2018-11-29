using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public Cidade Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
    }
}
