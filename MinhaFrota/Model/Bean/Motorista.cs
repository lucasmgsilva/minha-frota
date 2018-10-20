using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Model.Bean
{
    public class Motorista : Pessoa
    {
        public int IdMotorista { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public char Sexo { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public CNH Cnh { get; set; }
    }
}
