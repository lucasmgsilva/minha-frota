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
    public class CargoDAO
    {
        SqlConnection connection;
        
        public CargoDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaCargo (Cargo cargo)
        {
            string query = "EXECUTE SP_INSERE_CARGO " + 
                           "@Cargo, @Permissoes";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@Cargo", cargo.cargo);
                cmd.Parameters.AddWithValue("@Permissoes", cargo.Permissoes);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O cargo foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este CARGO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraCargo(Cargo cargo)
        {
            string query = "EXECUTE SP_ALTERA_CARGO " +
                           "@IdCargo, @Cargo, @Permissoes";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdCargo", cargo.IdCargo);
                cmd.Parameters.AddWithValue("@Cargo", cargo.cargo);
                cmd.Parameters.AddWithValue("@Permissoes", cargo.Permissoes);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O cargo foi alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este CARGO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletaCargo(int idCargo)
        {
            string query = "EXECUTE SP_DELETA_CARGO @IdCargo";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdCargo", idCargo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O Cargo foi excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Não foi possível realizar a operação.\nEste CARGO está sendo referenciado em algum USUÁRIO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Cargo> GetListaCargos()
        {
            string query = "SELECT * FROM VW_SELECIONA_CARGO";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Cargo> listaCargos = new List<Cargo>();

                while(dtr.Read()){
                    Cargo cargo = new Cargo();
                    cargo.IdCargo = Convert.ToInt32(dtr["idCargo"]);
                    cargo.cargo = dtr["cargo"].ToString();
                    cargo.Permissoes = dtr["permissoes"].ToString();

                    listaCargos.Add(cargo);
                }

                dtr.Close();
                this.connection.Close();

                return listaCargos;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }
    }
}
