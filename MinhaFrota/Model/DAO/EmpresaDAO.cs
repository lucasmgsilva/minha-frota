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
    public class EmpresaDAO
    {
        SqlConnection connection;

        public EmpresaDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AlteraEmpresa(Empresa empresa)
        {
            string query = "EXECUTE SP_ALTERA_EMPRESA " +
                "@IdPessoa, @IdEmpresa, @Logradouro, @Numero, @Complemento, @Bairro, @IdCidade, @Cep, @TelefoneFixo, @TelefoneCelular, @RazaoSocial, @NomeFantasia, @Cnpj, @Ie, @Im, @DataAbertura";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdPessoa", empresa.IdPessoa);
                cmd.Parameters.AddWithValue("@IdEmpresa", empresa.IdEmpresa);
                cmd.Parameters.AddWithValue("@Logradouro", empresa.Logradouro);
                cmd.Parameters.AddWithValue("@Numero", empresa.Numero);
                cmd.Parameters.AddWithValue("@Complemento", empresa.Complemento);
                cmd.Parameters.AddWithValue("@Bairro", empresa.Bairro);
                cmd.Parameters.AddWithValue("@IdCidade", empresa.Cidade.IdCidade);
                cmd.Parameters.AddWithValue("@Cep", empresa.Cep);
                cmd.Parameters.AddWithValue("@TelefoneFixo", empresa.TelefoneFixo);
                cmd.Parameters.AddWithValue("@TelefoneCelular", empresa.TelefoneCelular);
                cmd.Parameters.AddWithValue("@RazaoSocial", empresa.RazaoSocial);
                cmd.Parameters.AddWithValue("@NomeFantasia", empresa.NomeFantasia);
                cmd.Parameters.AddWithValue("@Cnpj", empresa.Cnpj);
                cmd.Parameters.AddWithValue("@Ie", empresa.Ie);
                cmd.Parameters.AddWithValue("@Im", empresa.Im);
                cmd.Parameters.AddWithValue("@DataAbertura", empresa.DataAbertura);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A Empresa foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Empresa> GetListaEmpresas()
        {
            string query = "SELECT * FROM VW_SELECIONA_EMPRESA";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Empresa> listaEmpresas = new List<Empresa>();

                while (dtr.Read())
                {
                    Empresa empresa = new Empresa();
                    empresa.IdEmpresa = Convert.ToInt32(dtr["idEmpresa"].ToString());
                    empresa.Logradouro = dtr["logradouro"].ToString();
                    empresa.Numero = dtr["numero"].ToString();
                    empresa.Complemento = dtr["complemento"].ToString();
                    empresa.Bairro = dtr["bairro"].ToString();
                    empresa.Cep = dtr["cep"].ToString();
                    empresa.TelefoneFixo = dtr["telefoneFixo"].ToString();
                    empresa.TelefoneCelular = dtr["telefoneCelular"].ToString();
                    empresa.RazaoSocial = dtr["razaoSocial"].ToString();
                    empresa.NomeFantasia = dtr["nomeFantasia"].ToString();
                    empresa.Cnpj = dtr["cnpj"].ToString();
                    empresa.Ie = dtr["ie"].ToString();
                    empresa.Im = dtr["im"].ToString();
                    empresa.DataAbertura = Convert.ToDateTime(dtr["dataAbertura"].ToString());

                    Estado estado = new Estado();
                    estado.IdEstado = Convert.ToInt32(dtr["idEstado"].ToString());
                    estado.estado = dtr["estado"].ToString();
                    estado.Uf = dtr["uf"].ToString();

                    Cidade cidade = new Cidade();
                    cidade.IdCidade = Convert.ToInt32(dtr["idCidade"].ToString());
                    cidade.cidade = dtr["cidade"].ToString();
                    cidade.Estado = estado;

                    empresa.Cidade = cidade;

                    listaEmpresas.Add(empresa);
                }

                dtr.Close();
                this.connection.Close();

                return listaEmpresas;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
              throw ex;
            }
        }
    }
}
