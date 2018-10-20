using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.Factory;
using Trinity.Model.Bean;

namespace Trinity.Model.DAO
{
    public class CidadeDAO
    {
        SqlConnection connection;

        public CidadeDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public List<Cidade> GetListaCidade (Estado estado)
        {
            string query = "EXECUTE SP_OBTEM_CIDADES " + 
                           "@IdEstado";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdEstado", estado.IdEstado);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Cidade> listaCidades = new List<Cidade>();

                while (dtr.Read())
                {
                    Cidade cidade = new Cidade();
                    cidade.IdCidade = Convert.ToInt32(dtr["idCidade"].ToString());
                    cidade.cidade = dtr["cidade"].ToString();

                    listaCidades.Add(cidade);
                }

                dtr.Close();
                this.connection.Close();

                return listaCidades;
            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
