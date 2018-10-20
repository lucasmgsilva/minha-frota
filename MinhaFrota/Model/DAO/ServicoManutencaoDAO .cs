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
    public class ServicoManutencaoDAO
    {
        SqlConnection connection;
        
        public ServicoManutencaoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaServicoManutencao (ServicoManutencao servicoManutencao)
        {
            string query = "EXECUTE SP_INSERE_SERVICO_MANUTENCAO " +
                           "@IdManutencao, @IdServico, @Valor";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", servicoManutencao.Manutencao.IdManutencao);
                cmd.Parameters.AddWithValue("@IdServico", servicoManutencao.Servico.IdServico);
                cmd.Parameters.AddWithValue("@Valor", servicoManutencao.Valor);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O SERVIÇO DE MANUTENÇÃO foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraServicoManutencao(ServicoManutencao servicoManutencao)
        {
            string query = "EXECUTE SP_ALTERA_SERVICO_MANUTENCAO " +
                           "@IdManutencao, @IdServico, @Valor";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", servicoManutencao.Manutencao.IdManutencao);
                cmd.Parameters.AddWithValue("@IdServico", servicoManutencao.Servico.IdServico);
                cmd.Parameters.AddWithValue("@Valor", servicoManutencao.Valor);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O SERVIÇO DE MANUTENÇÃO foi alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaServicoManutencao (int idManutencao, int idServico)
        {
            string query = "EXECUTE SP_DELETA_SERVICO_MANUTENCAO @IdManutencao, @IdServico";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", idManutencao);
                cmd.Parameters.AddWithValue("@IdServico", idServico);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O SERVIÇO DE MANUTENÇÃO foi excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<ServicoManutencao> GetListaProdutoManutencao (int idManutencao)
        {
            string query = "EXECUTE SP_OBTEM_SERVICOS_MANUTENCAO @IdManutencao";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", idManutencao);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<ServicoManutencao> listaServicosManutencao = new List<ServicoManutencao>();

                while(dtr.Read()){
                    ServicoManutencao servicoManutencao = new ServicoManutencao()
                    {
                        Manutencao = new Manutencao()
                        {
                            IdManutencao = Convert.ToInt32(dtr["idManutencao"])
                        },
                        Servico = new Servico()
                        {
                            IdServico = Convert.ToInt32(dtr["idServico"]),
                            servico = dtr["servico"].ToString()
                        },
                        Valor = Convert.ToDouble(dtr["valor"])
                    };

                    listaServicosManutencao.Add(servicoManutencao);
                }

                dtr.Close();
                this.connection.Close();

                return listaServicosManutencao;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
