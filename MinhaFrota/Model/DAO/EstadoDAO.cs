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
    public class EstadoDAO
    {
        SqlConnection connection;

        public EstadoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public List<Estado> GetListaEstados()
        {
            string query = "SELECT * FROM VW_SELECIONA_ESTADO";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Estado> listaEstados = new List<Estado>();

                while (dtr.Read())
                {
                    Estado estado = new Estado();
                    estado.IdEstado = Convert.ToInt32(dtr["idEstado"].ToString());
                    estado.estado = dtr["estado"].ToString();
                    estado.Uf = dtr["uf"].ToString();
                    listaEstados.Add(estado);
                }

                dtr.Close();
                this.connection.Close();

                return listaEstados;
            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
