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
    class UsuarioDAO
    {
        SqlConnection connection;

        public UsuarioDAO()
        {
            this.connection = new ConnectionFactory().getConnection();
        }

        public void AdicionaUsuario (Usuario usuario)
        {
            string query = "EXECUTE SP_INSERE_USUARIO " +
                "@Usuario, @Senha, @IdCargo, @IdEmpresa";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@Usuario", usuario.usuario);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@IdCargo", usuario.Cargo.IdCargo);
                cmd.Parameters.AddWithValue("@IdEmpresa", usuario.Empresa.IdEmpresa);
                cmd.ExecuteNonQuery();

                MessageBox.Show("O Usuário foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este USUÁRIO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlteraUsuario(Usuario usuario)
        {
            string query = "EXECUTE SP_ALTERA_USUARIO " +
                "@IdUsuario, @Usuario, @Senha, @IdCargo, @IdEmpresa";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Usuario", usuario.usuario);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@IdCargo", usuario.Cargo.IdCargo);
                cmd.Parameters.AddWithValue("@IdEmpresa", usuario.Empresa.IdEmpresa);
                cmd.ExecuteNonQuery();
                MessageBox.Show("O Usuário foi alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Não foi possível realizar a operação.\nJá existe um cadastro com este USUÁRIO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Usuario> GetListaUsuarios ()
        {
            string query = "SELECT * FROM VW_SELECIONA_USUARIO";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Usuario> listaUsuarios = new List<Usuario>();

                while (dtr.Read())
                    listaUsuarios.Add(CriaObjetoUsuario(dtr));

                dtr.Close();
                this.connection.Close();

                return listaUsuarios;
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }

        public List<Usuario> BuscaListaUsuarios(string palavraChave)
        {
            string query = "EXECUTE SP_BUSCA_USUARIO @PalavraChave";
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@PalavraChave", palavraChave.Replace(" ", "%"));
                SqlDataReader dtr = cmd.ExecuteReader();

                List<Usuario> listaUsuarios = new List<Usuario>();

                while (dtr.Read())
                    listaUsuarios.Add(CriaObjetoUsuario(dtr));

                dtr.Close();
                this.connection.Close();

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw ex;
            }
        }

        public void DeletaUsuario(int idUsuario)
        {
            if(idUsuario != 1)
            {
                string query = "EXECUTE SP_DELETA_USUARIO @IdUsuario";
                try
                {
                    this.connection.Open();
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("O Usuário foi excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.connection.Close();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                        MessageBox.Show("Não foi possível realizar a operação.\nEste USUÁRIO está sendo referenciado em alguma COMPRA ou VENDA!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Um erro inesperado ocorreu: \n" + ex.Message, "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nEste USUÁRIO é PADRÃO do sistema e em hipótese alguma pode ser deletado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public Usuario CriaObjetoUsuario(SqlDataReader dtr)
        {
            Usuario usuario = new Usuario();
            usuario.IdUsuario = Convert.ToInt32(dtr["idUsuario"].ToString());
            usuario.usuario = dtr["usuario"].ToString();
            usuario.Senha = dtr["senha"].ToString();

            Cargo cargo = new Cargo();
            cargo.IdCargo = Convert.ToInt32(dtr["idCargo"].ToString());
            cargo.cargo = dtr["cargo"].ToString();
            cargo.Permissoes = dtr["permissoes"].ToString();

            usuario.Cargo = cargo;

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

            usuario.Empresa = empresa;

            return usuario;
        }
    }
}
