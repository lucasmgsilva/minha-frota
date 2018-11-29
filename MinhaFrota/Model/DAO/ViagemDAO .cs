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
    public class ViagemDAO
    {
        SqlConnection connection;

        public ViagemDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaViagem(Viagem viagem)
        {
            string sql = "EXECUTE SP_INSERE_VIAGEM @IdVeiculo, @KmSaida, @KmChegada, @IdMotorista, @DataHoraSaida, @DataHoraChegada, @Cep_Origem,  @IdCidade_Origem, @Logradouro_Origem, @Numero_Origem, @Bairro_Origem, @Cep_Destino, @IdCidade_Destino, @Logradouro_Destino, @Numero_Destino, @Bairro_Destino";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@IdVeiculo", viagem.Veiculo.IdVeiculo);
                cmd.Parameters.AddWithValue("@KmSaida", viagem.KmSaida);
                cmd.Parameters.AddWithValue("@KmChegada", viagem.KmChegada);
                cmd.Parameters.AddWithValue("@IdMotorista", viagem.Motorista.IdMotorista);
                cmd.Parameters.AddWithValue("@DataHoraSaida", viagem.DataHoraSaida);
                cmd.Parameters.AddWithValue("@DataHoraChegada", viagem.DataHoraChegada);

                cmd.Parameters.AddWithValue("@Cep_Origem", viagem.ListaEndereco[0].Cep);
                cmd.Parameters.AddWithValue("@IdCidade_Origem", viagem.ListaEndereco[0].Cidade.IdCidade);
                cmd.Parameters.AddWithValue("@Logradouro_Origem", viagem.ListaEndereco[0].Logradouro);
                cmd.Parameters.AddWithValue("@Numero_Origem", viagem.ListaEndereco[0].Numero);
                cmd.Parameters.AddWithValue("@Bairro_Origem", viagem.ListaEndereco[0].Bairro);

                cmd.Parameters.AddWithValue("@Cep_Destino", viagem.ListaEndereco[1].Cep);
                cmd.Parameters.AddWithValue("@IdCidade_Destino", viagem.ListaEndereco[1].Cidade.IdCidade);
                cmd.Parameters.AddWithValue("@Logradouro_Destino", viagem.ListaEndereco[1].Logradouro);
                cmd.Parameters.AddWithValue("@Numero_Destino", viagem.ListaEndereco[1].Numero);
                cmd.Parameters.AddWithValue("@Bairro_Destino", viagem.ListaEndereco[1].Bairro);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A VIAGEM foi cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally
            {
                this.connection.Close();
            }
        }

        public void AlteraViagem(Viagem viagem)
        {
            string sql = "EXECUTE SP_ALTERA_VIAGEM @IdViagem, @IdVeiculo, @KmSaida, @KmChegada, @IdMotorista, @DataHoraSaida, @DataHoraChegada, @idEndereco_Origem, @Cep_Origem,  @IdCidade_Origem, @Logradouro_Origem, @Numero_Origem, @Bairro_Origem, @idEndereco_Destino, @Cep_Destino, @IdCidade_Destino, @Logradouro_Destino, @Numero_Destino, @Bairro_Destino";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@IdViagem", viagem.IdViagem);
                cmd.Parameters.AddWithValue("@IdVeiculo", viagem.Veiculo.IdVeiculo);
                cmd.Parameters.AddWithValue("@KmSaida", viagem.KmSaida);
                cmd.Parameters.AddWithValue("@KmChegada", viagem.KmChegada);
                cmd.Parameters.AddWithValue("@IdMotorista", viagem.Motorista.IdMotorista);
                cmd.Parameters.AddWithValue("@DataHoraSaida", viagem.DataHoraSaida);
                cmd.Parameters.AddWithValue("@DataHoraChegada", viagem.DataHoraChegada);

                cmd.Parameters.AddWithValue("@idEndereco_Origem", viagem.ListaEndereco[0].IdEndereco);
                cmd.Parameters.AddWithValue("@Cep_Origem", viagem.ListaEndereco[0].Cep);
                cmd.Parameters.AddWithValue("@IdCidade_Origem", viagem.ListaEndereco[0].Cidade.IdCidade);
                cmd.Parameters.AddWithValue("@Logradouro_Origem", viagem.ListaEndereco[0].Logradouro);
                cmd.Parameters.AddWithValue("@Numero_Origem", viagem.ListaEndereco[0].Numero);
                cmd.Parameters.AddWithValue("@Bairro_Origem", viagem.ListaEndereco[0].Bairro);

                cmd.Parameters.AddWithValue("@idEndereco_Destino", viagem.ListaEndereco[1].IdEndereco);
                cmd.Parameters.AddWithValue("@Cep_Destino", viagem.ListaEndereco[1].Cep);
                cmd.Parameters.AddWithValue("@IdCidade_Destino", viagem.ListaEndereco[1].Cidade.IdCidade);
                cmd.Parameters.AddWithValue("@Logradouro_Destino", viagem.ListaEndereco[1].Logradouro);
                cmd.Parameters.AddWithValue("@Numero_Destino", viagem.ListaEndereco[1].Numero);
                cmd.Parameters.AddWithValue("@Bairro_Destino", viagem.ListaEndereco[1].Bairro);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A VIAGEM foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void DeletaViagem(int idViagem)
        {
            string query = "EXECUTE SP_DELETA_VIAGEM @IdViagem";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdViagem", idViagem);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A VIAGEM foi excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        public List<Viagem> GetListaViagem()
        {
            string sql = "SELECT * FROM VW_SELECIONA_VIAGEM";
            List<Viagem> listaViagens = new List<Viagem>();
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(sql, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    Viagem viagem = new Viagem()
                    {
                        IdViagem = Convert.ToInt32(dtr["idViagem"].ToString()),
                        KmSaida = Convert.ToInt32(dtr["kmSaida"].ToString()),
                        KmChegada = Convert.ToInt32(dtr["kmChegada"].ToString()),
                        DataHoraSaida = Convert.ToDateTime(dtr["dataHoraSaida"].ToString()),
                        DataHoraChegada = Convert.ToDateTime(dtr["dataHoraChegada"].ToString()),
                        Veiculo = new Veiculo()
                        {
                            IdVeiculo = Convert.ToInt32(dtr["idVeiculo"].ToString()),
                            Placa = dtr["placa"].ToString()
                        },
                        Motorista = new Motorista()
                        {
                            IdMotorista = Convert.ToInt32(dtr["idMotorista"].ToString()),
                            Nome = dtr["nome"].ToString()
                        }
                    };
                    listaViagens.Add(viagem);
                }

                dtr.Close();
                return listaViagens;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public List<Viagem> BuscaListaViagens(string palavraChave)
        {
            string query = "EXECUTE SP_BUSCA_VIAGEM @PalavraChave";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@PalavraChave", palavraChave.Replace(" ", "%"));
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Viagem> listaViagens = new List<Viagem>();

                while (dtr.Read())
                {
                    Viagem viagem = new Viagem()
                    {
                        IdViagem = Convert.ToInt32(dtr["idViagem"].ToString()),
                        KmSaida = Convert.ToInt32(dtr["kmSaida"].ToString()),
                        KmChegada = Convert.ToInt32(dtr["kmChegada"].ToString()),
                        DataHoraSaida = Convert.ToDateTime(dtr["dataHoraSaida"].ToString()),
                        DataHoraChegada = Convert.ToDateTime(dtr["dataHoraChegada"].ToString()),
                        Veiculo = new Veiculo()
                        {
                            IdVeiculo = Convert.ToInt32(dtr["idVeiculo"].ToString()),
                            Placa = dtr["placa"].ToString()
                        },
                        Motorista = new Motorista()
                        {
                            IdMotorista = Convert.ToInt32(dtr["idMotorista"].ToString()),
                            Nome = dtr["nome"].ToString()
                        }
                    };
                    listaViagens.Add(viagem);
                }

                dtr.Close();
                this.connection.Close();

                return listaViagens;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }

        public void BuscaEnderecosViagens(Viagem viagem)
        {
            string query = "EXECUTE SP_BUSCA_ENDERECO @IdViagem";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdViagem", viagem.IdViagem);
                SqlDataReader dtr = cmd.ExecuteReader();

                viagem.ListaEndereco = new List<Endereco>();

                while (dtr.Read())
                {
                    Endereco endereco = new Endereco();
                    endereco.IdEndereco = Convert.ToInt32(dtr["idEndereco"]);
                    endereco.Cep = dtr["cep"].ToString();
                    endereco.Logradouro = dtr["logradouro"].ToString();
                    endereco.Numero = dtr["numero"].ToString();
                    endereco.Bairro = dtr["bairro"].ToString();
                    endereco.Cidade = new Cidade()
                    {
                        IdCidade = Convert.ToInt32(dtr["idCidade"]),
                        Estado = new Estado()
                        {
                            IdEstado = Convert.ToInt32(dtr["idEstado"])
                        }
                    };
                    viagem.ListaEndereco.Add(endereco);
                }

                dtr.Close();
                this.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
