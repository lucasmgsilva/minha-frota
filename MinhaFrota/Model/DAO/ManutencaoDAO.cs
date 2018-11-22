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

        public void AdicionaManutencao (Manutencao manutencao)
        {
            string query = "EXECUTE SP_INSERE_MANUTENCAO " +
                           "@DataManutencao, @IdVeiculo, @IdMotorista, @Tipo";
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
                    int idManutencao = Convert.ToInt32(dtr["idManutencao"].ToString());
                    dtr.Close();
                    query = "EXECUTE SP_INSERE_PRODUTO_MANUTENCAO " +
                           "@IdManutencao, @IdProduto, @Quantidade, @ValorUnitario";
                    foreach (var produtoManutencao in manutencao.ListaProdutoManutencao)
                    {
                        cmd = new SqlCommand(query, this.connection);
                        cmd.Parameters.AddWithValue("@IdManutencao", idManutencao);
                        cmd.Parameters.AddWithValue("@IdProduto", produtoManutencao.Produto.idProduto);
                        cmd.Parameters.AddWithValue("@Quantidade", produtoManutencao.Quantidade);
                        cmd.Parameters.AddWithValue("@ValorUnitario", produtoManutencao.ValorUnitario);
                        cmd.ExecuteNonQuery();
                    }

                    query = "EXECUTE SP_INSERE_SERVICO_MANUTENCAO " +
                           "@IdManutencao, @IdServico, @Valor";
                    foreach (var servicoManutencao in manutencao.ListaServicoManutencao)
                    {
                        cmd = new SqlCommand(query, this.connection);
                        cmd.Parameters.AddWithValue("@IdManutencao", idManutencao);
                        cmd.Parameters.AddWithValue("@IdServico", servicoManutencao.Servico.IdServico);
                        cmd.Parameters.AddWithValue("@Valor", servicoManutencao.Valor);
                        cmd.ExecuteNonQuery();
                    }
                }
                this.connection.Close();
                MessageBox.Show("A MANUTENÇÃO foi cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraManutencao (Manutencao manutencao, 
            List<ProdutoManutencao> listaProdutoManutencaoNovo, List<ProdutoManutencao> listaProdutoManutencaoAlterado, List<ProdutoManutencao> listaProdutoManutencaoDeletado,
            List<ServicoManutencao> listaServicoManutencaoNovo, List<ServicoManutencao> listaServicoManutencaoAlterado, List<ServicoManutencao> listaServicoManutencaoDeletado)
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

                //Produtos
                query = "EXECUTE SP_INSERE_PRODUTO_MANUTENCAO " +
                                           "@IdManutencao, @IdProduto, @Quantidade, @ValorUnitario";
                foreach (ProdutoManutencao item in listaProdutoManutencaoNovo)
                {
                    cmd = new SqlCommand(query, this.connection);
                    cmd.Parameters.AddWithValue("@IdManutencao", manutencao.IdManutencao);
                    cmd.Parameters.AddWithValue("@IdProduto", item.Produto.idProduto);
                    cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                    cmd.Parameters.AddWithValue("@ValorUnitario", item.ValorUnitario);
                    cmd.ExecuteNonQuery();
                }

                query = "EXECUTE SP_ALTERA_PRODUTO_MANUTENCAO " +
                           "@IdManutencao, @IdProduto, @Quantidade, @ValorUnitario";
                foreach (ProdutoManutencao item in listaProdutoManutencaoAlterado)
                {
                    cmd = new SqlCommand(query, this.connection);
                    cmd.Parameters.AddWithValue("@IdManutencao", manutencao.IdManutencao);
                    cmd.Parameters.AddWithValue("@IdProduto", item.Produto.idProduto);
                    cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                    cmd.Parameters.AddWithValue("@ValorUnitario", item.ValorUnitario);
                    cmd.ExecuteNonQuery();
                }

                query = "EXECUTE SP_DELETA_PRODUTO_MANUTENCAO @IdManutencao, @IdProduto";
                foreach (ProdutoManutencao item in listaProdutoManutencaoDeletado)
                {
                    cmd = new SqlCommand(query, this.connection);
                    cmd.Parameters.AddWithValue("@IdManutencao", manutencao.IdManutencao);
                    cmd.Parameters.AddWithValue("@IdProduto", item.Produto.idProduto);
                    cmd.ExecuteNonQuery();
                }

                //Serviços
                query = "EXECUTE SP_INSERE_SERVICO_MANUTENCAO " +
                           "@IdManutencao, @IdServico, @Valor";
                foreach (ServicoManutencao item in listaServicoManutencaoNovo)
                {
                    cmd = new SqlCommand(query, this.connection);
                    cmd.Parameters.AddWithValue("@IdManutencao", manutencao.IdManutencao);
                    cmd.Parameters.AddWithValue("@IdServico", item.Servico.IdServico);
                    cmd.Parameters.AddWithValue("@Valor", item.Valor);
                    cmd.ExecuteNonQuery();
                }

                query = "EXECUTE SP_ALTERA_SERVICO_MANUTENCAO " +
                           "@IdManutencao, @IdServico, @Valor";
                foreach (ServicoManutencao item in listaServicoManutencaoAlterado)
                {
                    cmd = new SqlCommand(query, this.connection);
                    cmd.Parameters.AddWithValue("@IdManutencao", manutencao.IdManutencao);
                    cmd.Parameters.AddWithValue("@IdServico", item.Servico.IdServico);
                    cmd.Parameters.AddWithValue("@Valor", item.Valor);
                    cmd.ExecuteNonQuery();
                }

                query = "EXECUTE SP_DELETA_SERVICO_MANUTENCAO @IdManutencao, @IdServico";
                foreach (ServicoManutencao item in listaServicoManutencaoDeletado)
                {
                    cmd = new SqlCommand(query, this.connection);
                    cmd.Parameters.AddWithValue("@IdManutencao", manutencao.IdManutencao);
                    cmd.Parameters.AddWithValue("@IdServico", item.Servico.IdServico);
                    cmd.ExecuteNonQuery();
                }

                this.connection.Close();
                MessageBox.Show("A MANUTENÇÃO foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
