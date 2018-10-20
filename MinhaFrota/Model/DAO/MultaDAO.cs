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
    public class MultaDAO
    {
        SqlConnection connection;
        
        public MultaDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaMulta (Multa multa)
        {
            string query = "EXECUTE SP_INSERE_MULTA " +
                           "@IdVeiculo, @IdMotorista, @DataInfracao, @IdInfracao, @Valor, @DataVencimento, @DataPagamento, @idCidade";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdVeiculo", multa.Veiculo.IdVeiculo);
                cmd.Parameters.AddWithValue("@IdMotorista", multa.Motorista.IdMotorista);
                cmd.Parameters.AddWithValue("@DataInfracao", multa.DataInfracao);
                cmd.Parameters.AddWithValue("@IdInfracao", multa.Infracao.IdInfracao);
                cmd.Parameters.AddWithValue("@Valor", multa.Valor);
                cmd.Parameters.AddWithValue("@DataVencimento", multa.DataVencimento);
                cmd.Parameters.AddWithValue("@DataPagamento", multa.DataVencimento);
                cmd.Parameters.AddWithValue("@idCidade", multa.Cidade.IdCidade);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A MULTA foi cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraMulta (Multa multa)
        {
            string query = "EXECUTE SP_ALTERA_MULTA " +
                           "@IdMulta, @IdVeiculo, @IdMotorista, @DataInfracao, @IdInfracao, @Valor, @DataVencimento, @DataPagamento, @idCidade";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdMulta", multa.IdMulta);
                cmd.Parameters.AddWithValue("@IdVeiculo", multa.Veiculo.IdVeiculo);
                cmd.Parameters.AddWithValue("@IdMotorista", multa.Motorista.IdMotorista);
                cmd.Parameters.AddWithValue("@DataInfracao", multa.DataInfracao);
                cmd.Parameters.AddWithValue("@IdInfracao", multa.Infracao.IdInfracao);
                cmd.Parameters.AddWithValue("@Valor", multa.Valor);
                cmd.Parameters.AddWithValue("@DataVencimento", multa.DataVencimento);
                cmd.Parameters.AddWithValue("@DataPagamento", multa.DataVencimento);
                cmd.Parameters.AddWithValue("@idCidade", multa.Cidade.IdCidade);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A MULTA foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaMulta (int idMulta)
        {
            string query = "EXECUTE SP_DELETA_MULTA @IdMulta";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdMulta", idMulta);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A MULTA foi excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Multa> GetListaMultas ()
        {
            string query = "SELECT * FROM VW_SELECIONA_MULTAS";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Multa> listaMultas = new List<Multa>();

                while(dtr.Read()){
                    Multa multa = new Multa();
                    multa.IdMulta = Convert.ToInt32(dtr["idMulta"]);
                    multa.Veiculo = new Veiculo()
                    {
                        IdVeiculo = Convert.ToInt32(dtr["idVeiculo"]),
                        Placa = dtr["placa"].ToString()
                    };

                    multa.Motorista = new Motorista()
                    {
                        IdMotorista = Convert.ToInt32(dtr["idMotorista"]),
                        Nome = dtr["nome"].ToString()
                    };

                    multa.DataInfracao = Convert.ToDateTime(dtr["dataInfracao"]);

                    multa.Infracao = new Infracao()
                    {
                        IdInfracao = Convert.ToInt32(dtr["idInfracao"]),
                        infracao = dtr["infracao"].ToString()
                    };

                    multa.Valor = Convert.ToDouble(dtr["valor"]);
                    multa.DataVencimento = Convert.ToDateTime(dtr["dataVencimento"]);
                    multa.DataPagamento = Convert.ToDateTime(dtr["dataPagamento"]);

                    multa.Cidade = new Cidade()
                    {
                        IdCidade = Convert.ToInt32(dtr["idCidade"]),
                        Estado = new Estado()
                        {
                            IdEstado = Convert.ToInt32(dtr["idEstado"])
                        }
                    };

                    listaMultas.Add(multa);
                }

                dtr.Close();
                this.connection.Close();

                return listaMultas;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
