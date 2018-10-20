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
    public partial class FrmInfracao : Form
    {
        List<Infracao> listaInfracoes;
        bool editando;
        Infracao infracaoCarregada;

        public FrmInfracao()
        {
            InitializeComponent();
            this.editando = false;
            LimpaCampos();
        }

        private void DesabilitaCampos()
        {
            txtInfracao.Enabled = false;
            cmbClassificacao.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtInfracao.Enabled = !false;
            cmbClassificacao.Enabled = !false;
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
            HabilitaBotoes();
            txtInfracao.Text = String.Empty;
            cmbClassificacao.SelectedItem = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtInfracao.Text))
            {
                if (this.infracaoCarregada == null)
                    this.infracaoCarregada = new Infracao();

                this.infracaoCarregada.infracao = txtInfracao.Text;
                this.infracaoCarregada.Classificacao = cmbClassificacao.Text;

                InfracaoDAO dao = new InfracaoDAO();
                if (!this.editando)
                    dao.AdicionaInfracao(this.infracaoCarregada);
                else dao.AlteraInfracao(this.infracaoCarregada);
                CarregaListaInfracoes();
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações desta INFRAÇÃO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaInfracao();
                }
            }
            else this.Close();
        }

        private void FrmInfracao_Load(object sender, EventArgs e)
        {
            CarregaListaInfracoes();
        }

        public void CarregaListaInfracoes()
        {
            dgvInfracoes.AutoGenerateColumns = false;
            listaInfracoes = new InfracaoDAO().GetListaInfracoes();
            dgvInfracoes.DataSource = new BindingList<Infracao>(listaInfracoes);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvInfracoes.RowCount != 0)
            {
                if (dgvInfracoes.CurrentRow.Selected)
                {
                    this.editando = true;
                    DesabilitaBotoes();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma INFRAÇÃO selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma INFRAÇÃO cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            LimpaCampos();
            if (dgvInfracoes.RowCount != 0)
            {
                if (dgvInfracoes.CurrentRow.Selected)
                {
                    this.editando = false;
                    int idInfracao = Convert.ToInt32(dgvInfracoes.CurrentRow.Cells["idInfracao"].Value.ToString());
                    this.infracaoCarregada = this.listaInfracoes.Find(u => u.IdInfracao == idInfracao);
                    CarregaInfracao();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma INFRAÇÃO cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CarregaInfracao()
        {
            txtInfracao.Text = infracaoCarregada.infracao;
            cmbClassificacao.Text = this.infracaoCarregada.Classificacao;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.editando = false;
            LimpaCampos();
            DesabilitaBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvInfracoes.RowCount != 0)
            {
                if (dgvInfracoes.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir esta INFRAÇÃO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        InfracaoDAO dao = new InfracaoDAO();
                        dao.DeletaInfracao(this.infracaoCarregada.IdInfracao);
                        CarregaListaInfracoes();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma INFRAÇÃO selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma INFRAÇÃO cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
