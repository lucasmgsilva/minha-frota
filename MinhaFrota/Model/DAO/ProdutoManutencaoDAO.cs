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
