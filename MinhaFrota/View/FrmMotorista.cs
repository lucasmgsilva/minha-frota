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
    public partial class FrmMotorista : Form
    {
        bool editando;
        Motorista motoristaCarregado;

        public FrmMotorista(Motorista motoristaCarregado)
        {
            InitializeComponent();
            this.motoristaCarregado = motoristaCarregado;
            DesabilitaBotoes();
            CarregaEstado();
            if (this.motoristaCarregado != null)
            {
                this.editando = true;
                CarregaCliente();
            } else txtDataCadastro.Text = Convert.ToString(DateTime.Now);
        }

        private void CarregaCliente()
        {
            txtNome.Text = motoristaCarregado.Nome;
            txtDataCadastro.Text = motoristaCarregado.DataCadastro.ToString();
            txtApelido.Text = motoristaCarregado.Apelido;
            if (motoristaCarregado.Sexo.Equals('M'))
                cmbSexo.Text = "MASCULINO";
            else cmbSexo.Text = "FEMININO";
            txtCpf.Text = motoristaCarregado.Cpf;
            txtRG.Text = motoristaCarregado.Rg;
            txtDataNascimento.Text = motoristaCarregado.DataNascimento.ToShortDateString();
            txtLogradouro.Text = this.motoristaCarregado.Logradouro;
            txtNumero.Text = this.motoristaCarregado.Numero;
            txtComplemento.Text = motoristaCarregado.Complemento;
            txtBairro.Text = this.motoristaCarregado.Bairro;
            txtCep.Text = this.motoristaCarregado.Cep;
            txtTelefoneFixo.Text = motoristaCarregado.TelefoneFixo;
            txtTelefoneCelular.Text = this.motoristaCarregado.TelefoneCelular;
            txtNumeroRegistro.Text = this.motoristaCarregado.Cnh.NumeroRegistro;
            txtDataValidade.Text = this.motoristaCarregado.Cnh.DataValidade.ToShortDateString();
            cmbCategoria.Text = motoristaCarregado.Cnh.Categoria.ToString();

            SelecionaEstado();
            SelecionaCidade();
        }

        private void DesabilitaCampos()
        {
            txtNome.Enabled = false;
            txtDataCadastro.Enabled = false;
            txtApelido.Enabled = false;
            cmbSexo.Enabled = false;
            txtCpf.Enabled = false;
            txtRG.Enabled = false;
            txtDataNascimento.Enabled = false;
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            txtComplemento.Enabled = false;
            txtBairro.Enabled = false;
            txtCep.Enabled = false;
            txtTelefoneFixo.Enabled = false;
            txtTelefoneCelular.Enabled = false;
            cmbUf.Enabled = false;
            cmbCidade.Enabled = false;
            txtNumeroRegistro.Enabled = false;
            txtDataValidade.Enabled = false;
            cmbCategoria.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtNome.Enabled = !false;
            txtDataCadastro.Enabled = !false;
            txtApelido.Enabled = !false;
            cmbSexo.Enabled = !false;
            txtCpf.Enabled = !false;
            txtRG.Enabled = !false;
            txtDataNascimento.Enabled = !false;
            txtNome.Focus();
            txtLogradouro.Enabled = !false;
            txtNumero.Enabled = !false;
            txtComplemento.Enabled = !false;
            txtBairro.Enabled = !false;
            txtCep.Enabled = !false;
            txtTelefoneFixo.Enabled = !false;
            txtTelefoneCelular.Enabled = !false;
            cmbUf.Enabled = !false;
            cmbCidade.Enabled = !false;
            txtNumeroRegistro.Enabled = !false;
            txtDataValidade.Enabled = !false;
            cmbCategoria.Enabled = !false;
            txtNome.Focus();
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
            txtNome.Text = String.Empty;
            txtDataCadastro.Text = Convert.ToString(DateTime.Now);
            txtApelido.Text = String.Empty;
            cmbSexo.SelectedItem = null;
            txtCpf.Text = String.Empty;
            txtRG.Text = String.Empty;
            txtDataNascimento.Text = String.Empty;
            txtLogradouro.Text = String.Empty;
            txtNumero.Text = String.Empty;
            txtComplemento.Text = String.Empty;
            txtBairro.Text = String.Empty;
            txtCep.Text = String.Empty;
            txtTelefoneFixo.Text = String.Empty;
            txtTelefoneCelular.Text = String.Empty;
            cmbUf.SelectedIndex = 0;
            txtNumeroRegistro.Text = String.Empty;
            txtDataCadastro.Text = DateTime.Now.ToString();
            cmbCategoria.SelectedItem = null;
        }

        public void SelecionaCidade()
        {
            int idCidade = this.motoristaCarregado.Cidade.IdCidade;
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
            int idEstado = this.motoristaCarregado.Cidade.Estado.IdEstado;
            foreach (Estado item in cmbUf.Items)
                if (item.IdEstado == idEstado)
                {
                    cmbUf.SelectedItem = item;
                    break;
                }
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (!Validacao.ValidaCPF(txtCpf.Text))
                txtCpf.ForeColor = Color.Red;
            else txtCpf.ForeColor = Color.Green;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(txtNome.Text.Trim()) && !String.IsNullOrWhiteSpace(txtDataCadastro.Text.Trim()) &&
                !String.IsNullOrWhiteSpace(txtCpf.Text.Trim()) && cmbSexo.SelectedItem != null && !String.IsNullOrWhiteSpace(txtDataNascimento.Text.Trim()) &&
                !String.IsNullOrWhiteSpace(txtLogradouro.Text.Trim()) && !String.IsNullOrWhiteSpace(txtNumero.Text.Trim()) &&
                !String.IsNullOrWhiteSpace(txtBairro.Text.Trim()) && !String.IsNullOrWhiteSpace(txtCep.Text.Trim()) && 
                cmbUf.SelectedItem != null && cmbCidade.SelectedItem != null && !String.IsNullOrWhiteSpace(txtNumeroRegistro.Text.Trim()) &&
                !String.IsNullOrWhiteSpace(txtDataValidade.Text.Trim()) && cmbCategoria.SelectedItem != null)
            {
                if (Validacao.ValidaCPF(txtCpf.Text.Trim()) && Validacao.ValidaCNH(txtNumeroRegistro.Text.Trim()))
                {
                    if (this.motoristaCarregado == null)
                        this.motoristaCarregado = new Motorista();

                    this.motoristaCarregado.Nome = txtNome.Text.Trim();
                    this.motoristaCarregado.DataCadastro = Convert.ToDateTime(txtDataCadastro.Text.Trim());
                    this.motoristaCarregado.Apelido = txtApelido.Text.Trim();
                    if (cmbSexo.Text.Trim().Equals("MASCULINO"))
                        this.motoristaCarregado.Sexo = Convert.ToChar("M");
                    else this.motoristaCarregado.Sexo = Convert.ToChar("F");
                    this.motoristaCarregado.Cpf = txtCpf.Text.Trim();
                    this.motoristaCarregado.Rg = txtRG.Text.Trim();
                    this.motoristaCarregado.TelefoneFixo = txtTelefoneFixo.Text.Trim();
                    this.motoristaCarregado.TelefoneCelular = txtTelefoneCelular.Text.Trim();
                    this.motoristaCarregado.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text.Trim());
                    this.motoristaCarregado.Logradouro = txtLogradouro.Text.Trim();
                    this.motoristaCarregado.Numero = txtNumero.Text.Trim();
                    this.motoristaCarregado.Complemento = txtComplemento.Text.Trim();
                    this.motoristaCarregado.Bairro = txtBairro.Text.Trim();
                    this.motoristaCarregado.Cep = txtCep.Text.Trim();
                    this.motoristaCarregado.Cidade = (Cidade) cmbCidade.SelectedItem;

                    if (this.motoristaCarregado.Cnh == null)
                        this.motoristaCarregado.Cnh = new CNH();

                    this.motoristaCarregado.Cnh.NumeroRegistro = txtNumeroRegistro.Text.Trim();
                    this.motoristaCarregado.Cnh.DataValidade = Convert.ToDateTime(txtDataValidade.Text.Trim());
                    this.motoristaCarregado.Cnh.Categoria = cmbCategoria.Text.Trim();
           
                    MotoristaDAO dao = new MotoristaDAO();
                    if (!this.editando)
                        dao.AdicionaMotorista(this.motoristaCarregado);
                    else dao.AlteraMotorista(this.motoristaCarregado);
                    this.Close();
                } else MessageBox.Show("Não foi possível realizar a operação.\nO CPF ou NÚMERO DE REGISTRO digitado é INVÁLIDO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCidade.DisplayMember = "cidade";
            cmbCidade.DataSource = new CidadeDAO().GetListaCidade((Estado)cmbUf.SelectedItem);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.editando = true;
            DesabilitaBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você realmente quer excluir este MOTORISTA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MotoristaDAO dao = new MotoristaDAO();
                dao.DeletaMotorista(this.motoristaCarregado.IdMotorista);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações deste MOTORISTA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaCliente();
                }
            }
            else this.Close();
        }

        private void tbcClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            if (!Validacao.ValidaCPF(txtCpf.Text))
                txtCpf.ForeColor = Color.Red;
            else txtCpf.ForeColor = Color.Green;
        }

        private void txtNumeroRegistro_TextChanged(object sender, EventArgs e)
        {
            if (!Validacao.ValidaCNH(txtNumeroRegistro.Text))
                txtNumeroRegistro.ForeColor = Color.Red;
            else txtNumeroRegistro.ForeColor = Color.Green;
        }
    }
}