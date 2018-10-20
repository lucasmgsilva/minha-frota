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
    public class InfracaoDAO
    {
        SqlConnection connection;
        
        public InfracaoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaInfracao (Infracao infracao)
        {
            string query = "EXECUTE SP_INSERE_INFRACAO " + 
                           "@Infracao, @Classificacao";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@Infracao", infracao.infracao);
                cmd.Parameters.AddWithValue("@Classificacao", infracao.Classificacao);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A INFRAÇÃO foi cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com esta INFRAÇÃO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraInfracao (Infracao infracao)
        {
            string query = "EXECUTE SP_ALTERA_INFRACAO " +
                           "@IdInfracao, @Infracao, @Classificacao";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdInfracao", infracao.IdInfracao);
                cmd.Parameters.AddWithValue("@Infracao", infracao.infracao);
                cmd.Parameters.AddWithValue("@Classificacao", infracao.Classificacao);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A INFRAÇÃO foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com esta INFRAÇÃO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaInfracao (int idInfracao)
        {
            string query = "EXECUTE SP_DELETA_INFRACAO @IdInfracao";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdInfracao", idInfracao);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A INFRAÇÃO foi excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEsta INFRAÇÃO está sendo referenciado em alguma MULTA de VEÍCULO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Infracao> GetListaInfracoes()
        {
            string query = "SELECT * FROM VW_SELECIONA_INFRACOES";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Infracao> listaInfracoes = new List<Infracao>();

                while(dtr.Read()){
                    Infracao infracao = new Infracao();
                    infracao.IdInfracao = Convert.ToInt32(dtr["idInfracao"]);
                    infracao.infracao = dtr["infracao"].ToString();
                    infracao.Classificacao = dtr["classificacao"].ToString();
                    listaInfracoes.Add(infracao);
                }

                dtr.Close();
                this.connection.Close();

                return listaInfracoes;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
