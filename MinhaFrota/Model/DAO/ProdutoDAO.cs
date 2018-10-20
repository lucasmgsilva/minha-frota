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
    public class ProdutoDAO
    {
        SqlConnection connection;
        
        public ProdutoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaProduto (Produto produto)
        {
            string query = "EXECUTE SP_INSERE_PRODUTO " + 
                           "@IdUnidadeMedida, @Produto";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdUnidadeMedida", produto.UnidadeMedida.IdUnidadeMedida);
                cmd.Parameters.AddWithValue("@Produto", produto.produto);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O PRODUTO foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este PRODUTO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraProduto (Produto produto)
        {
            string query = "EXECUTE SP_ALTERA_PRODUTO " +
                           "@IdProduto, @IdUnidadeMedida, @Produto";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdProduto", produto.idProduto);
                cmd.Parameters.AddWithValue("@IdUnidadeMedida", produto.UnidadeMedida.IdUnidadeMedida);
                cmd.Parameters.AddWithValue("@Produto", produto.produto);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O PRODUTO foi alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este PRODUTO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaProduto (int idProduto)
        {
            string query = "EXECUTE SP_DELETA_PRODUTO @IdProduto";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdProduto", idProduto);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O PRODUTO foi excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEste PRODUTO está sendo referenciado em alguma MANUTENÇÃO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Produto> GetListaProdutos ()
        {
            string query = "SELECT * FROM VW_SELECIONA_PRODUTO";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Produto> listaProdutos = new List<Produto>();

                while(dtr.Read()){
                    Produto produto = new Produto();
                    produto.idProduto = Convert.ToInt32(dtr["idProduto"]);
                    produto.produto = dtr["produto"].ToString();

                    UnidadeMedida unidadeMedida = new UnidadeMedida();
                    unidadeMedida.IdUnidadeMedida = Convert.ToInt32(dtr["idUnidadeMedida"]);
                    unidadeMedida.unidadeMedida = dtr["unidadeMedida"].ToString();

                    produto.UnidadeMedida = unidadeMedida;
                    listaProdutos.Add(produto);
                }

                dtr.Close();
                this.connection.Close();

                return listaProdutos;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
