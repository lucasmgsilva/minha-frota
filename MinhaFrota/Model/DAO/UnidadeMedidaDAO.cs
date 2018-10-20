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
    public class UnidadeMedidaDAO
    {
        SqlConnection connection;
        
        public UnidadeMedidaDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaUnidadeMedida (UnidadeMedida unidadeMedida)
        {
            string query = "EXECUTE SP_INSERE_UNIDADEMEDIDA " + 
                           "@UnidadeMedida";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@UnidadeMedida", unidadeMedida.unidadeMedida);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A UNIDADE DE MEDIDA foi cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com esta UNIDADE DE MEDIDA!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraUnidadeMedida (UnidadeMedida unidadeMedida)
        {
            string query = "EXECUTE SP_ALTERA_UNIDADEMEDIDA " +
                           "@IdUnidadeMedida, @UnidadeMedida";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdUnidadeMedida", unidadeMedida.IdUnidadeMedida);
                cmd.Parameters.AddWithValue("@UnidadeMedida", unidadeMedida.unidadeMedida);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A UNIDADE DE MEDIDA foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com esta UNIDADE DE MEDIDA!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaUnidadeMedida (int idUnidadeMedida)
        {
            string query = "EXECUTE SP_DELETA_UNIDADEMEDIDA @IdUnidadeMedida";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdUnidadeMedida", idUnidadeMedida);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A UNIDADE DE MEDIDA foi excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEsta UNIDADE DE MEDIDA está sendo referenciado em algum PRODUTO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<UnidadeMedida> GetListaUnidadeMedida()
        {
            string query = "SELECT * FROM VW_SELECIONA_UNIDADEMEDIDA";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<UnidadeMedida> listaUnidadeMedida = new List<UnidadeMedida>();

                while(dtr.Read()){
                    UnidadeMedida unidadeMedida= new UnidadeMedida();
                    unidadeMedida.IdUnidadeMedida = Convert.ToInt32(dtr["idUnidadeMedida"]);
                    unidadeMedida.unidadeMedida = dtr["unidadeMedida"].ToString();
                    listaUnidadeMedida.Add(unidadeMedida);
                }

                dtr.Close();
                this.connection.Close();

                return listaUnidadeMedida;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
