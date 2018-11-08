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

namespace Trinity.View
{
    public partial class FrmUsuario : Form
    {
        bool editando;
        Usuario usuarioCarregado;

        public FrmUsuario(Usuario usuarioCarregado)
        {
            InitializeComponent();
            this.usuarioCarregado = usuarioCarregado;
            DesabilitaBotoes();
            CarregaCargo();
            CarregaRazaoSocial();
            if (this.usuarioCarregado != null)
            {
                this.editando = true;
                CarregaUsuario();
            }
        }

        private void CarregaUsuario ()
        {
            txtUsuario.Text = this.usuarioCarregado.usuario;
            txtSenha.Text = this.usuarioCarregado.Senha;
            txtConfirmacaoSenha.Text = this.usuarioCarregado.Senha;
            SelecionaCargo();
            SelecionaRazaoSocial();
        }

        public void CarregaCargo()
        {
            cmbCargo.DisplayMember = "cargo";
            cmbCargo.DataSource = new CargoDAO().GetListaCargos();
        }

        public void SelecionaCargo()
        {
            if (this.usuarioCarregado != null)
            {
                int idCargo = this.usuarioCarregado.Cargo.IdCargo;
                foreach (Cargo item in cmbCargo.Items)
                    if (item.IdCargo == idCargo)
                    {
                        cmbCargo.SelectedItem = item;
                        break;
                    }
            }
        }

        public void CarregaRazaoSocial()
        {
            cmbRazaoSocial.DisplayMember = "RazaoSocial";
            cmbRazaoSocial.DataSource = new EmpresaDAO().GetListaEmpresas();
        }

        public void SelecionaRazaoSocial()
        {
            if (this.usuarioCarregado != null)
            {
                int idEmpresa = this.usuarioCarregado.Empresa.IdEmpresa;
                foreach (Empresa item in cmbRazaoSocial.Items)
                    if (item.IdEmpresa == idEmpresa)
                    {
                        cmbRazaoSocial.SelectedItem = item;
                        break;
                    }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(txtUsuario.Text.Trim()) && !String.IsNullOrWhiteSpace(txtSenha.Text.Trim()) && !String.IsNullOrWhiteSpace(txtConfirmacaoSenha.Text.Trim()) && cmbCargo.SelectedItem!=null && cmbRazaoSocial.SelectedItem != null)
            {
                if (ValidaSenha())
                {
                    if (this.usuarioCarregado == null)
                        this.usuarioCarregado = new Usuario();
                    this.usuarioCarregado.usuario = txtUsuario.Text.Trim();
                    this.usuarioCarregado.Senha = txtSenha.Text.Trim();
                    this.usuarioCarregado.Cargo = (Cargo) cmbCargo.SelectedItem;
                    this.usuarioCarregado.Empresa = (Empresa) cmbRazaoSocial.SelectedItem;

                    UsuarioDAO dao = new UsuarioDAO();
                    if (!this.editando)
                        dao.AdicionaUsuario(this.usuarioCarregado);
                    else dao.AlteraUsuario(this.usuarioCarregado);
                    this.Close();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nA SENHA não é igual a CONFIRMAÇÃO DE SENHA digitada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Add_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Add_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FrmCargo telaCargo = new FrmCargo();
            telaCargo.ShowDialog();
            CarregaCargo();
            SelecionaCargo();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FrmEmpresa telaEmpresa = new FrmEmpresa(null);
            telaEmpresa.ShowDialog();
            CarregaRazaoSocial();
            SelecionaRazaoSocial();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações deste USUÁRIO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaUsuario();
                }
            }
            else this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.editando = true;
            DesabilitaBotoes();
        }

        private void DesabilitaCampos()
        {
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
            txtConfirmacaoSenha.Enabled = false;
            cmbCargo.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtUsuario.Enabled = !false;
            txtSenha.Enabled = !false;
            txtConfirmacaoSenha.Enabled = !false;
            cmbCargo.Enabled = !false;
            txtUsuario.Focus();
        }

        private void HabilitaBotoes()
        {
            DesabilitaCampos();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void DesabilitaBotoes()
        {
            HabilitaCampos();
            btnNovo.Enabled = !true;
            btnSalvar.Enabled = !false;
            btnEditar.Enabled = !true;
            btnExcluir.Enabled = !true;
        }

        private void LimpaCampos()
        {
            DesabilitaBotoes();
            txtUsuario.Text = String.Empty;
            txtSenha.Text = String.Empty;
            txtConfirmacaoSenha.Text = String.Empty;
            cmbCargo.SelectedItem = null;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você realmente quer excluir este USUÁRIO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UsuarioDAO dao = new UsuarioDAO();
                dao.DeletaUsuario(this.usuarioCarregado.IdUsuario);
                this.Close();
            }
        }

        private bool ValidaSenha()
        {
            if (txtSenha.Text == String.Empty || txtConfirmacaoSenha.Text == String.Empty || txtSenha.Text.Length != txtConfirmacaoSenha.Text.Length || !txtSenha.Text.Equals(txtConfirmacaoSenha.Text))
                return false;
            return true;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (!ValidaSenha())
                txtConfirmacaoSenha.ForeColor = Color.Red;
            else txtConfirmacaoSenha.ForeColor = Color.Green;
        }

        private void txtConfirmacaoSenha_TextChanged(object sender, EventArgs e)
        {
            if (!ValidaSenha())
                txtConfirmacaoSenha.ForeColor = Color.Red;
            else txtConfirmacaoSenha.ForeColor = Color.Green;
        }
    }
}