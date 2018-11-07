using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trinity.Model.Bean;
using Trinity.Model.DAO;

namespace Trinity.View
{
    public partial class FrmConsultaUsuario : Form
    {
        List<Usuario> listaUsuarios;

        public FrmConsultaUsuario()
        {
            InitializeComponent();
        }

        private void TelaConsultaUsuario_Load(object sender, EventArgs e)
        {
            CarregaListaUsuarios();
        }

        public void CarregaListaUsuarios()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            listaUsuarios = new UsuarioDAO().GetListaUsuarios();
            dgvUsuarios.DataSource = new BindingList<Usuario>(listaUsuarios);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.RowCount != 0)
            {
                if (dgvUsuarios.CurrentRow.Selected)
                {
                    int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idUsuario"].Value.ToString());
                    FrmUsuario telaUsuario = new FrmUsuario(this.listaUsuarios.Find(u => u.IdUsuario == idUsuario));
                    telaUsuario.ShowDialog();
                    CarregaListaUsuarios();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum USUÁRIO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum USUÁRIO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmUsuario telaUsuario = new FrmUsuario(null);
            telaUsuario.ShowDialog();
            CarregaListaUsuarios();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.RowCount != 0)
            {
                if (dgvUsuarios.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir este USUÁRIO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idUsuario"].Value.ToString());
                        UsuarioDAO dao = new UsuarioDAO();
                        dao.DeletaUsuario(idUsuario);
                        CarregaListaUsuarios();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum USUÁRIO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum USUÁRIO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";
            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;
                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;
                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }
            return retValue;
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvUsuarios.Rows[e.RowIndex].DataBoundItem != null) && (dgvUsuarios.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvUsuarios.Rows[e.RowIndex].DataBoundItem, dgvUsuarios.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.AutoGenerateColumns = false;
            listaUsuarios = new UsuarioDAO().BuscaListaUsuarios(txtPalavraChave.Text);
            dgvUsuarios.DataSource = new BindingList<Usuario>(listaUsuarios);
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys) e.KeyChar == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }
    }
}
