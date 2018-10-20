using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trinity.Model.Bean;
using Trinity.Model.DAO;

namespace Trinity
{
    public partial class FrmAcesso : Form
    {
        public FrmAcesso()
        {
            InitializeComponent();
            if (cmbUsuario.Items.Count>0)
                cmbUsuario.SelectedIndex = 0;
        }

        private void chkSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar)
                txtSenha.UseSystemPasswordChar = false;
            else txtSenha.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.Items.Count != 0)
            {
                Usuario usuario = (Usuario)cmbUsuario.SelectedItem;
                if (usuario != null)
                {
                    string senha = txtSenha.Text.Trim();
                    if (!String.IsNullOrEmpty(senha))
                    {
                        if (senha.Equals(usuario.Senha))
                        {
                            FrmPrincipal principal = new FrmPrincipal(usuario);
                            principal.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível realizar a operação.\nA SENHA digitada está incorreta!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSenha.Text = String.Empty;
                            txtSenha.Focus();
                        }
                    } else MessageBox.Show("Não foi possível realizar a operação.\nNenhuma SENHA foi digitada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else MessageBox.Show("Não foi possível realizar a operação.\nNenhum USUÁRIO foi selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum USUÁRIO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
                btnAcessar.PerformClick();
        }

        private void cmbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
                txtSenha.Focus();
        }

        private void TelaAcesso_Load(object sender, EventArgs e)
        {
            UsuarioDAO dao = new UsuarioDAO();
            cmbUsuario.DisplayMember = "usuario";
            cmbUsuario.DataSource = dao.GetListaUsuarios();
        }
    }
}
