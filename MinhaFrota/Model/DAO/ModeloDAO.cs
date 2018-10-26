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
    public class ModeloDAO
    {
        SqlConnection connection;
        
        public ModeloDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaModelo (Modelo modelo)
        {
            string query = "EXECUTE SP_INSERE_MODELO " + 
                           "@IdMarca, @Modelo";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdMarca", modelo.Marca.IdMarca);
                cmd.Parameters.AddWithValue("@Modelo", modelo.modelo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O MODELO foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este MODELO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraModelo(Modelo modelo)
        {
            string query = "EXECUTE SP_ALTERA_MODELO " +
                           "@IdModelo, @IdMarca, @Modelo";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdModelo", modelo.IdModelo);
                cmd.Parameters.AddWithValue("@IdMarca", modelo.Marca.IdMarca);
                cmd.Parameters.AddWithValue("@Modelo", modelo.modelo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O MODELO foi alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este MODELO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaModelo (int idModelo)
        {
            string query = "EXECUTE SP_DELETA_MODELO @IdModelo";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdModelo", idModelo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O MODELO foi excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEste MODELO está sendo referenciado em algum VEÍCULO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Modelo> GetListaModelos(int idMarca)
        {
            string query = "EXECUTE SP_OBTEM_MODELOS @IdMarca";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdMarca", idMarca);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Modelo> listaModelos = new List<Modelo>();

                while(dtr.Read()){
                    Modelo modelo = new Modelo();
                    modelo.IdModelo = Convert.ToInt32(dtr["idModelo"]);
                    modelo.modelo = dtr["modelo"].ToString();

                    Marca marca = new Marca();
                    modelo.Marca = marca;
                    modelo.Marca.IdMarca = Convert.ToInt32(dtr["idMarca"]);
                    modelo.Marca.marca = dtr["marca"].ToString();
                    listaModelos.Add(modelo);
                }

                dtr.Close();
                this.connection.Close();

                return listaModelos;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}