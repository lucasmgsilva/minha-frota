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
    public class MarcaDAO
    {
        SqlConnection connection;
        
        public MarcaDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaMarca (Marca marca)
        {
            string query = "EXECUTE SP_INSERE_MARCA " + 
                           "@Marca";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@Marca", marca.marca);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A MARCA foi cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com esta MARCA!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraMarca(Marca marca)
        {
            string query = "EXECUTE SP_ALTERA_MARCA " +
                           "@IdMarca, @Marca";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdMarca", marca.IdMarca);
                cmd.Parameters.AddWithValue("@Marca", marca.marca);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A MARCA foi alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com esta MARCA!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaMarca(int idMarca)
        {
            string query = "EXECUTE SP_DELETA_MARCA @IdMarca";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdMarca", idMarca);
                cmd.ExecuteNonQuery();
                MessageBox.Show("A MARCA foi excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEsta MARCA está sendo referenciado em algum MODELO de VEÍCULO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Marca> GetListaMarcas()
        {
            string query = "SELECT * FROM VW_SELECIONA_MARCA";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Marca> listaMarcas = new List<Marca>();

                while(dtr.Read()){
                    Marca marca = new Marca();
                    marca.IdMarca = Convert.ToInt32(dtr["idMarca"]);
                    marca.marca = dtr["marca"].ToString();
                    listaMarcas.Add(marca);
                }

                dtr.Close();
                this.connection.Close();

                return listaMarcas;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
