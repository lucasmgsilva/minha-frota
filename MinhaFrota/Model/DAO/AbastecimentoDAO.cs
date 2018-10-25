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
    public class AbastecimentoDAO
    {
        SqlConnection connection;

        public AbastecimentoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaAbastecimento(Abastecimento abastecimento)
        {
            string sql = "EXECUTE SP_INSERE_ABASTECIMENTO @IdMotorista, @IdVeiculo, @DataAbastecimento, @Litros, @ValorLitro, @KmAnterior, @KmAtual";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@IdMotorista", abastecimento.Motorista.IdMotorista);
                cmd.Parameters.AddWithValue("@IdVeiculo", abastecimento.Veiculo.IdVeiculo);
                cmd.Parameters.AddWithValue("@DataAbastecimento", abastecimento.DataAbastecimento);
                cmd.Parameters.AddWithValue("@Litros", abastecimento.Litros);
                cmd.Parameters.AddWithValue("@ValorLitro", abastecimento.ValorLitro);
                cmd.Parameters.AddWithValue("@KmAnterior", abastecimento.KmAnterior);
                cmd.Parameters.AddWithValue("@KmAtual", abastecimento.KmAtual);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O abastecimento foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este CARGO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally
            {
                this.connection.Close();
            }
        }

        public List<Abastecimento> GetListaAbastecimento(int IdVeiculo)
        {
            string sql = "EXECUTE SP_OBTEM_ABASTECIMENTOS @IdVeiculo";
            List<Abastecimento> listaAbastecimentos = new List<Abastecimento>();
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@IdVeiculo", IdVeiculo);
                SqlDataReader dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    Abastecimento abastecimento = new Abastecimento()
                    {
                        Motorista = new Motorista()
                        {
                            Nome = dtr["nome"].ToString()
                        },
                        Veiculo = new Veiculo()
                        {
                            Placa = dtr["placa"].ToString()
                        },
                        DataAbastecimento = Convert.ToDateTime(dtr["dataAbastecimento"].ToString()),
                        Litros = float.Parse(dtr["litros"].ToString()),
                        ValorLitro = float.Parse(dtr["valorLitro"].ToString()),
                        KmAnterior = Convert.ToInt32(dtr["kmAnterior"].ToString()),
                        KmAtual = Convert.ToInt32(dtr["kmAtual"].ToString())
                    };

                    listaAbastecimentos.Add(abastecimento);
                }

                dtr.Close();
                return listaAbastecimentos;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
