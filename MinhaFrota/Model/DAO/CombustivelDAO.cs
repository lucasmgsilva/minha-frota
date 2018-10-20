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
    public class CombustivelDAO
    {
        SqlConnection connection;
        
        public CombustivelDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaCombustivel (Combustivel combustivel)
        {
            string query = "EXECUTE SP_INSERE_COMBUSTIVEL " + 
                           "@Combustivel";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@Combustivel", combustivel.combustivel);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O COMBUSTÍVEL foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este COMBUSTÍVEL!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraCombustivel (Combustivel combustivel)
        {
            string query = "EXECUTE SP_ALTERA_COMBUSTIVEL " +
                           "@IdCombustivel, @Combustivel";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdCombustivel", combustivel.IdCombustivel);
                cmd.Parameters.AddWithValue("@Combustivel", combustivel.combustivel);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O COMBUSTÍVEL foi alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este COMBUSTÍVEL!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaCombustivel (int idCombustivel)
        {
            string query = "EXECUTE SP_DELETA_COMBUSTIVEL @IdCombustivel";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdCombustivel", idCombustivel);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O COMBUSTÍVEL foi excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEste COMBUSTÍVEL está sendo referenciado em algum VEÍCULO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Combustivel> GetListaCombustiveis()
        {
            string query = "SELECT * FROM VW_SELECIONA_COMBUSTIVEL";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Combustivel> listaCombustiveis = new List<Combustivel>();

                while(dtr.Read()){
                    Combustivel combustivel = new Combustivel();
                    combustivel.IdCombustivel = Convert.ToInt32(dtr["idCombustivel"]);
                    combustivel.combustivel = dtr["combustivel"].ToString();
                    listaCombustiveis.Add(combustivel);
                }

                dtr.Close();
                this.connection.Close();

                return listaCombustiveis;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
