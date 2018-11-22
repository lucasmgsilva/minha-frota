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
    public class ServicoManutencaoDAO
    {
        SqlConnection connection;
        
        public ServicoManutencaoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public List<ServicoManutencao> GetListaProdutoManutencao (int idManutencao)
        {
            string query = "EXECUTE SP_OBTEM_SERVICOS_MANUTENCAO @IdManutencao";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdManutencao", idManutencao);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<ServicoManutencao> listaServicosManutencao = new List<ServicoManutencao>();

                while(dtr.Read()){
                    ServicoManutencao servicoManutencao = new ServicoManutencao()
                    {
                        Manutencao = new Manutencao()
                        {
                            IdManutencao = Convert.ToInt32(dtr["idManutencao"])
                        },
                        Servico = new Servico()
                        {
                            IdServico = Convert.ToInt32(dtr["idServico"]),
                            servico = dtr["servico"].ToString()
                        },
                        Valor = Convert.ToDouble(dtr["valor"])
                    };
                    servicoManutencao.idServico = servicoManutencao.Servico.IdServico;
                    listaServicosManutencao.Add(servicoManutencao);
                }

                dtr.Close();
                this.connection.Close();

                return listaServicosManutencao;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
