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
    public class ProdutoManutencaoDAO
    {
        SqlConnection connection;
        
        public ProdutoManutencaoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaProdutoManutencao (ProdutoManutencao produtoManutencao)
        {
            string query = "EXECUTE SP_INSERE_PRODUTO_MANUTENCAO " +
                           "@IdManutencao, @IdProduto, @Quantidade, @ValorUnitario";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", produtoManutencao.Manutencao.IdManutencao);
                cmd.Parameters.AddWithValue("@IdProduto", produtoManutencao.Produto.idProduto);
                cmd.Parameters.AddWithValue("@Quantidade", produtoManutencao.Quantidade);
                cmd.Parameters.AddWithValue("@ValorUnitario", produtoManutencao.ValorUnitario);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O PRODUTO DE MANUTENÇÃO foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraProdutoManutencao (ProdutoManutencao produtoManutencao)
        {
            string query = "EXECUTE SP_ALTERA_PRODUTO_MANUTENCAO " +
                           "@IdManutencao, @IdProduto, @Quantidade, @ValorUnitario";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", produtoManutencao.Manutencao.IdManutencao);
                cmd.Parameters.AddWithValue("@IdProduto", produtoManutencao.Produto.idProduto);
                cmd.Parameters.AddWithValue("@Quantidade", produtoManutencao.Quantidade);
                cmd.Parameters.AddWithValue("@ValorUnitario", produtoManutencao.ValorUnitario);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O PRODUTO DE MANUTENÇÃO foi alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaProdutoManutencao (int idManutencao, int idProduto)
        {
            string query = "EXECUTE SP_DELETA_PRODUTO_MANUTENCAO @IdManutencao, @IdProduto";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", idManutencao);
                cmd.Parameters.AddWithValue("@IdProduto", idProduto);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O PRODUTO DE MANUTENÇÃO foi excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<ProdutoManutencao> GetListaProdutoManutencao (int idManutencao)
        {
            string query = "EXECUTE SP_OBTEM_PRODUTOS_MANUTENCAO @IdManutencao";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", idManutencao);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<ProdutoManutencao> listaProdutosManutencao = new List<ProdutoManutencao>();

                while(dtr.Read()){
                    ProdutoManutencao produtoManutencao = new ProdutoManutencao()
                    {
                        Manutencao = new Manutencao()
                        {
                            IdManutencao = Convert.ToInt32(dtr["idManutencao"])
                        },
                        Produto = new Produto()
                        {
                            idProduto = Convert.ToInt32(dtr["idProduto"]),
                            produto = dtr["produto"].ToString(),
                            UnidadeMedida = new UnidadeMedida()
                            {
                                IdUnidadeMedida = Convert.ToInt32(dtr["idUnidadeMedida"]),
                                unidadeMedida = dtr["unidadeMedida"].ToString()
                            }
                        },
                        Quantidade = Convert.ToDouble(dtr["quantidade"]),
                        ValorUnitario = Convert.ToDouble(dtr["valorUnitario"]),
                    };
                    produtoManutencao.ValorTotal = produtoManutencao.Quantidade * produtoManutencao.ValorUnitario;
                    listaProdutosManutencao.Add(produtoManutencao);
                }

                dtr.Close();
                this.connection.Close();

                return listaProdutosManutencao;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
