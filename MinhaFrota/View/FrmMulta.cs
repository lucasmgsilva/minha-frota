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
    public partial class FrmMulta : Form
    {
        bool editando;
        Multa multaCarregada;

        public FrmMulta(Multa multaCarregada)
        {
            InitializeComponent();
            this.multaCarregada = multaCarregada;
            DesabilitaBotoes();
            CarregaVeiculos();
            CarregaMotoristas();
            CarregaInfracoes();
            CarregaEstado();
            if (this.multaCarregada != null)
            {
                this.editando = true;
                CarregaMulta();
            }
        }

        private void CarregaVeiculos()
        {
            cmbVeiculo.DisplayMember = "placa";
            cmbVeiculo.DataSource = new VeiculoDAO().GetListaVeiculos();
        }

        public void SelecionaVeiculo()
        {
            int idVeiculo = this.multaCarregada.Veiculo.IdVeiculo;
            foreach (Veiculo item in cmbVeiculo.Items)
                if (item.IdVeiculo == idVeiculo)
                {
                    cmbVeiculo.SelectedItem = item;
                    break;
                }
        }

        private void CarregaMotoristas()
        {
            cmbMotorista.DisplayMember = "nome";
            cmbMotorista.DataSource = new MotoristaDAO().GetListaMotoristas();
        }

        public void SelecionaMotorista()
        {
            int idMotorista = this.multaCarregada.Motorista.IdMotorista;
            foreach (Motorista item in cmbMotorista.Items)
                if (item.IdMotorista == idMotorista)
                {
                    cmbMotorista.SelectedItem = item;
                    break;
                }
        }

        private void CarregaInfracoes()
        {
            cmbInfracao.DisplayMember = "infracao";
            cmbInfracao.DataSource = new InfracaoDAO().GetListaInfracoes();
        }

        public void SelecionaInfracao()
        {
            int idInfracao = this.multaCarregada.Infracao.IdInfracao;
            foreach (Infracao item in cmbInfracao.Items)
                if (item.IdInfracao == idInfracao)
                {
                    cmbInfracao.SelectedItem = item;
                    break;
                }
        }

        private void CarregaMulta()
        {

            txtDataInfracao.Value = this.multaCarregada.DataInfracao;
            SelecionaVeiculo();
            SelecionaMotorista();
            txtDataVencimento.Value = this.multaCarregada.DataVencimento;
            txtDataPagamento.Value = this.multaCarregada.DataPagamento;
            SelecionaEstado();
            SelecionaCidade();
            SelecionaInfracao();
            txtValor.Value = Convert.ToDecimal(this.multaCarregada.Valor);
            
        }

        private void DesabilitaCampos()
        {
            txtDataInfracao.Enabled = false;
            cmbVeiculo.Enabled = false;
            cmbMotorista.Enabled = false;
            txtDataVencimento.Enabled = false;
            txtDataPagamento.Enabled = false;
            cmbUf.Enabled = false;
            cmbCidade.Enabled = false;
            cmbInfracao.Enabled = false;
            txtValor.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtDataInfracao.Enabled = !false;
            cmbVeiculo.Enabled = !false;
            cmbMotorista.Enabled = !false;
            txtDataVencimento.Enabled = !false;
            txtDataPagamento.Enabled = !false;
            cmbUf.Enabled = !false;
            cmbCidade.Enabled = !false;
            cmbInfracao.Enabled = !false;
            txtValor.Enabled = !false;
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
            txtDataInfracao.Value = DateTime.Now;
            cmbVeiculo.SelectedItem = null;
            cmbMotorista.SelectedItem = null;
            txtDataVencimento.Value = DateTime.Now;
            txtDataPagamento.Value = DateTime.Now;
            cmbUf.SelectedIndex = 0;
            cmbCidade.SelectedIndex = 0;
            cmbInfracao.SelectedItem = null;
            txtValor.Value = 0;
        }

        public void SelecionaCidade()
        {
            int idCidade = this.multaCarregada.Cidade.IdCidade;
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
            int idEstado = this.multaCarregada.Cidade.Estado.IdEstado;
            foreach (Estado item in cmbUf.Items)
                if (item.IdEstado == idEstado)
                {
                    cmbUf.SelectedItem = item;
                    break;
                }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(txtDataInfracao.Text.Trim()) && cmbVeiculo.SelectedItem != null && cmbMotorista.SelectedItem != null &&
                !String.IsNullOrWhiteSpace(txtDataVencimento.Text.Trim()) && !String.IsNullOrWhiteSpace(txtDataPagamento.Text.Trim()) && cmbUf.SelectedItem != null && 
                cmbCidade.SelectedItem != null && cmbInfracao.SelectedItem != null && !String.IsNullOrWhiteSpace(txtValor.Value.ToString().Trim()))
            {
                if(txtValor.Value > 0)
                {
                    if (this.multaCarregada == null)
                        this.multaCarregada = new Multa();

                    this.multaCarregada.DataInfracao = txtDataInfracao.Value;
                    this.multaCarregada.Veiculo = (Veiculo) cmbVeiculo.SelectedItem;
                    this.multaCarregada.Motorista = (Motorista) cmbMotorista.SelectedItem;
                    this.multaCarregada.DataVencimento = txtDataVencimento.Value;
                    this.multaCarregada.DataPagamento = txtDataPagamento.Value;
                    this.multaCarregada.Cidade = (Cidade) cmbCidade.SelectedItem;
                    this.multaCarregada.Infracao = (Infracao) cmbInfracao.SelectedItem;
                    this.multaCarregada.Valor = Convert.ToDouble(txtValor.Value);
            
                    MultaDAO dao = new MultaDAO();
                    if (!this.editando)
                        dao.AdicionaMulta(this.multaCarregada);
                    else dao.AlteraMulta(this.multaCarregada);
                    this.Close();
                } else MessageBox.Show("Não foi possível realizar a operação.\nO VALOR da MULTA deve ser maior que zero reais (R$0,00)!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (MessageBox.Show("Você realmente quer excluir esta MULTA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MultaDAO dao = new MultaDAO();
                dao.DeletaMulta(this.multaCarregada.IdMulta);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações desta MULTA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaMulta();
                }
            }
            else this.Close();
        }

        private void tbcClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            FrmVeiculo frmVeiculo = new FrmVeiculo(null);
            frmVeiculo.ShowDialog();
            CarregaVeiculos();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            FrmMotorista frmMotorista = new FrmMotorista(null);
            frmMotorista.ShowDialog();
            CarregaMotoristas();
        }

        private void label40_Click(object sender, EventArgs e)
        {
            FrmInfracao frmInfracao = new FrmInfracao();
            frmInfracao.ShowDialog();
            CarregaInfracoes();
        }
    }
}