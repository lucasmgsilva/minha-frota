using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trinity.Model;
using Trinity.Model.Bean;
using Trinity.Model.DAO;

namespace Trinity.View
{
    public partial class FrmEmpresa : Form
    {
        bool editando;
        Empresa empresaCarregada;

        public FrmEmpresa(Empresa empresaCarregada)
        {
            InitializeComponent();
            this.empresaCarregada = empresaCarregada;
            
            CarregaEstado();
            if (this.empresaCarregada != null)
            {
                HabilitaBotoes();
                CarregaEmpresa();
            }
            else DesabilitaBotoes();
        }

        private void CarregaEmpresa()
        {
            txtRazaoSocial.Text = this.empresaCarregada.RazaoSocial;
            txtDataAbertura.Text = this.empresaCarregada.DataAbertura.ToShortDateString();
            txtNomeFantasia.Text = this.empresaCarregada.NomeFantasia;
            txtCnpj.Text = this.empresaCarregada.Cnpj;
            txtIe.Text = this.empresaCarregada.Ie;
            txtIm.Text = this.empresaCarregada.Im;
            txtTelefoneFixo.Text = this.empresaCarregada.TelefoneFixo;
            txtTelefoneCelular.Text = this.empresaCarregada.TelefoneCelular;
            txtLogradouro.Text = this.empresaCarregada.Logradouro;
            txtNumero.Text = this.empresaCarregada.Numero;
            txtComplemento.Text = this.empresaCarregada.Complemento;
            txtBairro.Text = this.empresaCarregada.Bairro;
            txtCep.Text = this.empresaCarregada.Cep;
            SelecionaEstado();
            SelecionaCidade();
        }

        public void SelecionaCidade()
        {
            int idCidade = this.empresaCarregada.Cidade.IdCidade;
            foreach (Cidade item in cmbCidade.Items)
                if (item.IdCidade == idCidade)
                {
                    cmbCidade.SelectedItem = item;

                    break;
                }
        }

        public void CarregaEstado()
        {
            cmbUf.DisplayMember = "uf";
            cmbUf.DataSource = new EstadoDAO().GetListaEstados();
        }

        public void SelecionaEstado()
        {
            int idEstado = this.empresaCarregada.Cidade.Estado.IdEstado;
            foreach (Estado item in cmbUf.Items)
                if (item.IdEstado == idEstado)
                {
                    cmbUf.SelectedItem = item;
                    break;
                }
        }

        private void cmbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCidade.DisplayMember = "cidade";
            cmbCidade.DataSource = new CidadeDAO().GetListaCidade((Estado)cmbUf.SelectedItem);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRazaoSocial.Text.Trim()) && !String.IsNullOrEmpty(txtDataAbertura.Text.Trim()) && !String.IsNullOrEmpty(txtCnpj.Text.Trim()) && !String.IsNullOrEmpty(txtLogradouro.Text.Trim()) && !String.IsNullOrEmpty(txtNumero.Text.Trim()) && !String.IsNullOrEmpty(txtBairro.Text.Trim()) && !String.IsNullOrEmpty(txtCep.Text.Trim()) && cmbUf.SelectedItem != null && cmbCidade.SelectedItem != null)
            {
                if (Validacao.ValidaCNPJ(txtCnpj.Text))
                    {
                    if (this.empresaCarregada == null)
                        this.empresaCarregada = new Empresa();
                    this.empresaCarregada.RazaoSocial = txtRazaoSocial.Text.Trim();
                    this.empresaCarregada.DataAbertura = Convert.ToDateTime(txtDataAbertura.Text);
                    this.empresaCarregada.NomeFantasia = txtNomeFantasia.Text.Trim();
                    this.empresaCarregada.Cnpj = txtCnpj.Text;
                    this.empresaCarregada.Ie = txtIe.Text.Trim();
                    this.empresaCarregada.Im = txtIm.Text.Trim();
                    this.empresaCarregada.TelefoneFixo = txtTelefoneFixo.Text.Trim();
                    this.empresaCarregada.TelefoneCelular = txtTelefoneCelular.Text.Trim();
                    this.empresaCarregada.Logradouro = txtLogradouro.Text.Trim();
                    this.empresaCarregada.Numero = txtNumero.Text.Trim();
                    this.empresaCarregada.Complemento = txtComplemento.Text.Trim();
                    this.empresaCarregada.Bairro = txtBairro.Text.Trim();
                    this.empresaCarregada.Cep = txtCep.Text;
                    this.empresaCarregada.Cidade = (Cidade)cmbCidade.SelectedItem;
                    this.empresaCarregada.Cidade.Estado = (Estado)cmbUf.SelectedItem;

                    EmpresaDAO dao = new EmpresaDAO();
                    dao.AlteraEmpresa(this.empresaCarregada);
                    this.Close();
                } else MessageBox.Show("Não foi possível realizar a operação.\nO CNPJ digitado é INVÁLIDO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DesabilitaCampos()
        {
            txtRazaoSocial.Enabled = false;
            txtDataAbertura.Enabled = false;
            txtNomeFantasia.Enabled = false;
            txtCnpj.Enabled = false;
            txtIe.Enabled = false;
            txtIm.Enabled = false;
            txtTelefoneFixo.Enabled = false;
            txtTelefoneCelular.Enabled = false;
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            txtComplemento.Enabled = false;
            txtBairro.Enabled = false;
            txtCep.Enabled = false;
            cmbUf.Enabled = false;
            cmbCidade.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtRazaoSocial.Enabled = !false;
            txtDataAbertura.Enabled = !false;
            txtNomeFantasia.Enabled = !false;
            txtCnpj.Enabled = !false;
            txtIe.Enabled = !false;
            txtIm.Enabled = !false;
            txtTelefoneFixo.Enabled = !false;
            txtTelefoneCelular.Enabled = !false;
            txtLogradouro.Enabled = !false;
            txtNumero.Enabled = !false;
            txtComplemento.Enabled = !false;
            txtBairro.Enabled = !false;
            txtCep.Enabled = !false;
            cmbUf.Enabled = !false;
            cmbCidade.Enabled = !false;
            txtRazaoSocial.Focus();
        }

        private void HabilitaBotoes()
        {
            DesabilitaCampos();
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
        }

        private void DesabilitaBotoes()
        {
            HabilitaCampos();
            btnSalvar.Enabled = !false;
            btnEditar.Enabled = !true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.editando = true;
            DesabilitaBotoes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações desta EMPRESA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaEmpresa();
                }
            }
            else this.Close();
        }

        private void txtCnpj_TextChanged(object sender, EventArgs e)
        {
            if (!Validacao.ValidaCNPJ(txtCnpj.Text))
                txtCnpj.ForeColor = Color.Red;
            else txtCnpj.ForeColor = Color.Green;
        }
    }
}