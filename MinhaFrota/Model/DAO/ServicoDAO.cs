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
    public class ServicoDAO
    {
        SqlConnection connection;
        
        public ServicoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaServico (Servico servico)
        {
            string query = "EXECUTE SP_INSERE_SERVICO " + 
                           "@Servico";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@Servico", servico.servico);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O SERVIÇO foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este SERVIÇO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraServico (Servico servico)
        {
            string query = "EXECUTE SP_ALTERA_SERVICO " +
                           "@IdServico, @Servico";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdServico", servico.IdServico);
                cmd.Parameters.AddWithValue("@Servico", servico.servico);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O SERVIÇO foi alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este SERVIÇO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaServico (int idServico)
        {
            string query = "EXECUTE SP_DELETA_SERVICO @IdServico";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdServico", idServico);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O SERVIÇO foi excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEste SERVIÇO está sendo referenciado em alguma MANUTENÇÃO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Servico> GetListaServicos()
        {
            string query = "SELECT * FROM VW_SELECIONA_SERVICO";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Servico> listaServicos = new List<Servico>();

                while(dtr.Read()){
                    Servico servico = new Servico();
                    servico.IdServico = Convert.ToInt32(dtr["idServico"]);
                    servico.servico = dtr["servico"].ToString();
                    listaServicos.Add(servico);
                }

                dtr.Close();
                this.connection.Close();

                return listaServicos;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
