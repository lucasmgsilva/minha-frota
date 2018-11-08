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
    class VeiculoDAO
    {
        SqlConnection connection;

        public VeiculoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaVeiculo (Veiculo veiculo)
        {
            string query = "EXECUTE SP_INSERE_VEICULO " +
                "@idModelo, @placa, @idCor, @anoFabricacao, @anoModelo, @km, @renavam, @idCombustivel, @categoriaExigida";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@idModelo", veiculo.Modelo.IdModelo);
                cmd.Parameters.AddWithValue("@placa", veiculo.Placa);
                cmd.Parameters.AddWithValue("@idCor", veiculo.Cor.IdCor);
                cmd.Parameters.AddWithValue("@anoFabricacao", veiculo.AnoFabricacao);
                cmd.Parameters.AddWithValue("@anoModelo", veiculo.AnoModelo);
                cmd.Parameters.AddWithValue("@km", veiculo.KmInicial);
                cmd.Parameters.AddWithValue("@renavam", veiculo.Renavam);
                cmd.Parameters.AddWithValue("@idCombustivel", veiculo.Combustivel.IdCombustivel);
                cmd.Parameters.AddWithValue("@categoriaExigida", veiculo.CategoriaExigida);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O VEÍCULO foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este VEÍCULO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraVeiculo(Veiculo veiculo)
        {
            string query = "EXECUTE SP_ALTERA_VEICULO " +
                "@idVeiculo, @idModelo, @placa, @idCor, @anoFabricacao, @anoModelo, @km, @renavam, @idCombustivel, @categoriaExigida";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@idVeiculo", veiculo.IdVeiculo);
                cmd.Parameters.AddWithValue("@idModelo", veiculo.Modelo.IdModelo);
                cmd.Parameters.AddWithValue("@placa", veiculo.Placa);
                cmd.Parameters.AddWithValue("@idCor", veiculo.Cor.IdCor);
                cmd.Parameters.AddWithValue("@anoFabricacao", veiculo.AnoFabricacao);
                cmd.Parameters.AddWithValue("@anoModelo", veiculo.AnoModelo);
                cmd.Parameters.AddWithValue("@km", veiculo.KmInicial);
                cmd.Parameters.AddWithValue("@renavam", veiculo.Renavam);
                cmd.Parameters.AddWithValue("@idCombustivel", veiculo.Combustivel.IdCombustivel);
                cmd.Parameters.AddWithValue("@categoriaExigida", veiculo.CategoriaExigida);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O VEÍCULO foi alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este VEÍCULO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaVeiculo(int idVeiculo)
        {
            string query = "EXECUTE SP_DELETA_VEICULO @idVeiculo";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O VEÍCULO foi excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEste VEÍCULO está sendo referenciado em alguma VIAGEM ou MANUTENÇÃO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Veiculo> GetListaVeiculos()
        {
            string query = "SELECT * FROM VW_SELECIONA_VEICULO";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Veiculo> listaVeiculos = new List<Veiculo>();

                while (dtr.Read())
                {
                    Veiculo veiculo = new Veiculo();
                    veiculo.IdVeiculo = Convert.ToInt32(dtr["idVeiculo"]);

                    veiculo.Modelo = new Modelo()
                    {
                        IdModelo = Convert.ToInt32(dtr["idModelo"]),
                        modelo = dtr["modelo"].ToString(),
                        Marca = new Marca()
                        {
                            IdMarca = Convert.ToInt32(dtr["idMarca"]),
                            marca = dtr["marca"].ToString()
                        }
                    };

                    veiculo.Combustivel = new Combustivel()
                    {
                        IdCombustivel = Convert.ToInt32(dtr["idCombustivel"]),
                        combustivel = dtr["combustivel"].ToString()
                    };

                    veiculo.Placa = dtr["placa"].ToString();

                    veiculo.Cor = new Cor()
                    {
                        IdCor = Convert.ToInt32(dtr["idCor"]),
                        cor = dtr["cor"].ToString()
                    };

                    veiculo.AnoFabricacao = Convert.ToDateTime(dtr["anoFabricacao"]);
                    veiculo.AnoModelo = Convert.ToDateTime(dtr["anoModelo"]);
                    veiculo.KmInicial = Convert.ToInt32(dtr["km"]);
                    veiculo.Renavam = dtr["renavam"].ToString();
                    veiculo.CategoriaExigida = dtr["categoriaExigida"].ToString();

                    listaVeiculos.Add(veiculo);
                }

                dtr.Close();
                this.connection.Close();

                return listaVeiculos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }

        public List<Veiculo> BuscaListaVeiculos(string palavraChave)
        {
            string query = "EXECUTE SP_BUSCA_VEICULO @PalavraChave";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@PalavraChave", palavraChave.Replace(" ", "%"));
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Veiculo> listaVeiculos = new List<Veiculo>();

                while (dtr.Read())
                {
                    Veiculo veiculo = new Veiculo();
                    veiculo.IdVeiculo = Convert.ToInt32(dtr["idVeiculo"]);

                    veiculo.Modelo = new Modelo()
                    {
                        IdModelo = Convert.ToInt32(dtr["idModelo"]),
                        modelo = dtr["modelo"].ToString(),
                        Marca = new Marca()
                        {
                            IdMarca = Convert.ToInt32(dtr["idMarca"]),
                            marca = dtr["marca"].ToString()
                        }
                    };

                    veiculo.Combustivel = new Combustivel()
                    {
                        IdCombustivel = Convert.ToInt32(dtr["idCombustivel"]),
                        combustivel = dtr["combustivel"].ToString()
                    };

                    veiculo.Placa = dtr["placa"].ToString();

                    veiculo.Cor = new Cor()
                    {
                        IdCor = Convert.ToInt32(dtr["idCor"]),
                        cor = dtr["cor"].ToString()
                    };

                    veiculo.AnoFabricacao = Convert.ToDateTime(dtr["anoFabricacao"]);
                    veiculo.AnoModelo = Convert.ToDateTime(dtr["anoModelo"]);
                    veiculo.KmInicial = Convert.ToInt32(dtr["km"]);
                    veiculo.Renavam = dtr["renavam"].ToString();
                    veiculo.CategoriaExigida = dtr["categoriaExigida"].ToString();

                    listaVeiculos.Add(veiculo);
                }

                dtr.Close();
                this.connection.Close();

                return listaVeiculos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
