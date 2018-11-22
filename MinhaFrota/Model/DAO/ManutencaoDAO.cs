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
    public class ManutencaoDAO
    {
        SqlConnection connection;
        
        public ManutencaoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public int AdicionaManutencao (Manutencao manutencao)
        {
            string query = "EXECUTE SP_INSERE_MANUTENCAO " +
                           "@DataManutencao, @IdVeiculo, @IdMotorista, @Tipo";
            int id = -1;
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@DataManutencao", manutencao.DataManutencao);
                cmd.Parameters.AddWithValue("@IdVeiculo", manutencao.Veiculo.IdVeiculo);
                cmd.Parameters.AddWithValue("@IdMotorista", manutencao.Motorista.IdMotorista);
                cmd.Parameters.AddWithValue("@Tipo", manutencao.Tipo);
                SqlDataReader dtr = cmd.ExecuteReader();

                if (dtr.Read())
                {
                    id = Convert.ToInt32(dtr[0].ToString());
                }
                
                //MessageBox.Show("A MANUTENÇÃO foi cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;
        }

        public void AlteraManutencao (Manutencao manutencao)
        {
            string query = "EXECUTE SP_ALTERA_MANUTENCAO " +
                           "@IdManutencao, @DataManutencao, @IdVeiculo, @IdMotorista, @Tipo";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", manutencao.IdManutencao);
                cmd.Parameters.AddWithValue("@DataManutencao", manutencao.DataManutencao);
                cmd.Parameters.AddWithValue("@IdVeiculo", manutencao.Veiculo.IdVeiculo);
                cmd.Parameters.AddWithValue("@IdMotorista", manutencao.Motorista.IdMotorista);
                cmd.Parameters.AddWithValue("@Tipo", manutencao.Tipo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A MANUTENÇÃO foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaManutencao (int idManutencao)
        {
            string query = "EXECUTE SP_DELETA_MANUTENCAO @IdManutencao";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", idManutencao);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A MANUTENÇÃO foi excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Manutencao> GetListaManutencao ()
        {
            string query = "SELECT * FROM VW_SELECIONA_MANUTENCAO";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Manutencao> listaManutencoes = new List<Manutencao>();

                while(dtr.Read()){
                    Manutencao manutencao = new Manutencao();
                    manutencao.IdManutencao = Convert.ToInt32(dtr["idManutencao"]);
                    manutencao.DataManutencao = Convert.ToDateTime(dtr["dataManutencao"]);
                    manutencao.Tipo = dtr["tipo"].ToString();
                    
                    try
                    {
                        manutencao.ValorTotal = Convert.ToDouble(dtr["valorTotal"]);
                    } catch (InvalidCastException)
                    {
                        manutencao.ValorTotal = 0;
                    }

                    manutencao.Veiculo = new Veiculo()
                    {
                        IdVeiculo = Convert.ToInt32(dtr["idVeiculo"]),
                        Placa = dtr["placa"].ToString()
                    };

                    manutencao.Motorista = new Motorista()
                    {
                        IdMotorista = Convert.ToInt32(dtr["idMotorista"]),
                        Nome = dtr["nome"].ToString()
                    };

                    listaManutencoes.Add(manutencao);
                }

                dtr.Close();
                this.connection.Close();

                return listaManutencoes;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }

        public List<Manutencao> BuscaListaManutencao(string palavraChave)
        {
            string query = "EXECUTE SP_BUSCA_MANUTENCAO @PalavraChave";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@PalavraChave", palavraChave.Replace(" ", "%"));
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Manutencao> listaManutencoes = new List<Manutencao>();

                while (dtr.Read())
                {
                    Manutencao manutencao = new Manutencao();
                    manutencao.IdManutencao = Convert.ToInt32(dtr["idManutencao"]);
                    manutencao.DataManutencao = Convert.ToDateTime(dtr["dataManutencao"]);
                    manutencao.Tipo = dtr["tipo"].ToString();

                    try
                    {
                        manutencao.ValorTotal = Convert.ToDouble(dtr["valorTotal"]);
                    }
                    catch (InvalidCastException)
                    {
                        manutencao.ValorTotal = 0;
                    }

                    manutencao.Veiculo = new Veiculo()
                    {
                        IdVeiculo = Convert.ToInt32(dtr["idVeiculo"]),
                        Placa = dtr["placa"].ToString()
                    };

                    manutencao.Motorista = new Motorista()
                    {
                        IdMotorista = Convert.ToInt32(dtr["idMotorista"]),
                        Nome = dtr["nome"].ToString()
                    };

                    listaManutencoes.Add(manutencao);
                }

                dtr.Close();
                this.connection.Close();

                return listaManutencoes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
