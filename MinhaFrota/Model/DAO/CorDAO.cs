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
    public class CorDAO
    {
        SqlConnection connection;
        
        public CorDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaCor (Cor cor)
        {
            string query = "EXECUTE SP_INSERE_COR " + 
                           "@Cor";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@Cor", cor.cor);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A COR foi cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com esta COR!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraCor(Cor cor)
        {
            string query = "EXECUTE SP_ALTERA_COR " +
                           "@IdCor, @Cor";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdCor", cor.IdCor);
                cmd.Parameters.AddWithValue("@Cor", cor.cor);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A COR foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com esta COR!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaCor(int idCor)
        {
            string query = "EXECUTE SP_DELETA_COR @IdCor";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdCor", idCor);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A COR foi excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEsta COR está sendo referenciado em algum VEÍCULO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Cor> GetListaCores()
        {
            string query = "SELECT * FROM VW_SELECIONA_COR";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Cor> listaCores = new List<Cor>();

                while(dtr.Read()){
                    Cor cor = new Cor();
                    cor.IdCor = Convert.ToInt32(dtr["idCor"]);
                    cor.cor = dtr["cor"].ToString();
                    listaCores.Add(cor);
                }

                dtr.Close();
                this.connection.Close();

                return listaCores;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
