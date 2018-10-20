using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trinity.Factory;
using Trinity.Model.Bean;

namespace Trinity.Model.DAO
{
    public class MotoristaDAO
    {
        SqlConnection connection;

        public MotoristaDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaMotorista(Motorista motorista)
        {
                string query = "EXECUTE SP_INSERE_MOTORISTA " +
                "@Logradouro, @Numero, @Complemento, @Bairro, @IdCidade, @Cep, @TelefoneFixo, @TelefoneCelular, @DataCadastro, @Nome, @Apelido, @Sexo, @Cpf, @Rg, @DataNascimento, @NumeroRegistro, @DataValidade, @Categoria";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@Logradouro", motorista.Logradouro);
                cmd.Parameters.AddWithValue("@Numero", motorista.Numero);
                cmd.Parameters.AddWithValue("@Complemento", motorista.Complemento);
                cmd.Parameters.AddWithValue("@Bairro", motorista.Bairro);
                cmd.Parameters.AddWithValue("@IdCidade", motorista.Cidade.IdCidade);
                cmd.Parameters.AddWithValue("@Cep", motorista.Cep);
                cmd.Parameters.AddWithValue("@TelefoneFixo", motorista.TelefoneFixo);
                cmd.Parameters.AddWithValue("@TelefoneCelular", motorista.TelefoneCelular);
                cmd.Parameters.AddWithValue("@DataCadastro", motorista.DataCadastro);
                cmd.Parameters.AddWithValue("@Nome", motorista.Nome);
                cmd.Parameters.AddWithValue("@Apelido", motorista.Apelido);
                cmd.Parameters.AddWithValue("@Sexo", motorista.Sexo);
                cmd.Parameters.AddWithValue("@Cpf", motorista.Cpf);
                cmd.Parameters.AddWithValue("@Rg", motorista.Rg);
                cmd.Parameters.AddWithValue("@DataNascimento", motorista.DataNascimento);
                cmd.Parameters.AddWithValue("@NumeroRegistro", motorista.Cnh.NumeroRegistro);
                cmd.Parameters.AddWithValue("@DataValidade", motorista.Cnh.DataValidade);
                cmd.Parameters.AddWithValue("@Categoria", motorista.Cnh.Categoria);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O MOTORISTA foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este CPF!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraMotorista(Motorista motorista)
        {
            string query = "SP_ALTERA_MOTORISTA " +
            "@IdPessoa, @IdMotorista, @IdCNH, @Logradouro, @Numero, @Complemento, @Bairro, @IdCidade, @Cep, @TelefoneFixo, @TelefoneCelular, @DataCadastro, @Nome, @Apelido, @Sexo, @Cpf, @Rg, @DataNascimento, @NumeroRegistro, @DataValidade, @Categoria";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdPessoa", motorista.IdPessoa);
                cmd.Parameters.AddWithValue("@IdMotorista", motorista.IdMotorista);
                cmd.Parameters.AddWithValue("@IdCNH", motorista.Cnh.IdCNH);
                cmd.Parameters.AddWithValue("@Logradouro", motorista.Logradouro);
                cmd.Parameters.AddWithValue("@Numero", motorista.Numero);
                cmd.Parameters.AddWithValue("@Complemento", motorista.Complemento);
                cmd.Parameters.AddWithValue("@Bairro", motorista.Bairro);
                cmd.Parameters.AddWithValue("@IdCidade", motorista.Cidade.IdCidade);
                cmd.Parameters.AddWithValue("@Cep", motorista.Cep);
                cmd.Parameters.AddWithValue("@TelefoneFixo", motorista.TelefoneFixo);
                cmd.Parameters.AddWithValue("@TelefoneCelular", motorista.TelefoneCelular);
                cmd.Parameters.AddWithValue("@DataCadastro", motorista.DataCadastro);
                cmd.Parameters.AddWithValue("@Nome", motorista.Nome);
                cmd.Parameters.AddWithValue("@Apelido", motorista.Apelido);
                cmd.Parameters.AddWithValue("@Sexo", motorista.Sexo);
                cmd.Parameters.AddWithValue("@Cpf", motorista.Cpf);
                cmd.Parameters.AddWithValue("@Rg", motorista.Rg);
                cmd.Parameters.AddWithValue("@DataNascimento", motorista.DataNascimento);
                cmd.Parameters.AddWithValue("@NumeroRegistro", motorista.Cnh.NumeroRegistro);
                cmd.Parameters.AddWithValue("@DataValidade", motorista.Cnh.DataValidade);
                cmd.Parameters.AddWithValue("@Categoria", motorista.Cnh.Categoria);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O MOTORISTA foi atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este CPF!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaMotorista(int idMotorista)
        {
            string query = "EXECUTE SP_DELETA_MOTORISTA @idMotorista";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@idMotorista", idMotorista);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O MOTORISTA foi excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEste MOTORISTA está sendo referenciado em alguma MANUTENÇÃO, VIAGEM ou ABASTECIMENTO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Motorista> GetListaMotoristas()
        {
            string query = "SELECT * FROM VW_SELECIONA_MOTORISTA";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Motorista> listaMotoristas = new List<Motorista>();

                while (dtr.Read())
                {
                    Motorista motorista = new Motorista();

                    motorista.IdPessoa = Convert.ToInt32(dtr["idPessoa"]);
                    motorista.Logradouro = dtr["logradouro"].ToString();
                    motorista.Numero = dtr["numero"].ToString();
                    motorista.Complemento = dtr["complemento"].ToString();
                    motorista.Bairro = dtr["bairro"].ToString();
                    motorista.Cep = dtr["cep"].ToString();
                    motorista.TelefoneFixo = dtr["telefoneFixo"].ToString();
                    motorista.TelefoneCelular = dtr["telefoneCelular"].ToString();

                    motorista.IdMotorista = Convert.ToInt32(dtr["idMotorista"]);
                    motorista.DataCadastro = Convert.ToDateTime(dtr["dataCadastro"]);
                    motorista.Nome = dtr["nome"].ToString();
                    motorista.Sexo = Convert.ToChar(dtr["sexo"]);
                    motorista.Cpf = dtr["cpf"].ToString();
                    motorista.Rg = dtr["rg"].ToString();
                    motorista.DataNascimento = Convert.ToDateTime(dtr["dataNascimento"]);
                    motorista.Apelido = dtr["apelido"].ToString();

                    CNH cnh = new CNH()
                    {
                        IdCNH = Convert.ToInt32(dtr["idCNH"]),
                        NumeroRegistro = dtr["numeroRegistro"].ToString(),
                        DataValidade = Convert.ToDateTime(dtr["dataValidade"].ToString()),
                        Categoria = dtr["categoria"].ToString()
                    };

                    motorista.Cnh = cnh;
                
                    Estado estado = new Estado();
                    estado.IdEstado = Convert.ToInt32(dtr["idEstado"].ToString());
                    estado.estado = dtr["estado"].ToString();
                    estado.Uf = dtr["uf"].ToString();

                    Cidade cidade = new Cidade();
                    cidade.IdCidade = Convert.ToInt32(dtr["idCidade"].ToString());
                    cidade.cidade = dtr["cidade"].ToString();
                    cidade.Estado = estado;

                    motorista.Cidade = cidade;

                    listaMotoristas.Add(motorista);
                }

                dtr.Close();
                this.connection.Close();

                return listaMotoristas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
