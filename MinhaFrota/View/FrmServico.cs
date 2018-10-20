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
    public partial class FrmServico : Form
    {
        List<Servico> listaServicos;
        bool editando;
        Servico servicoCarregado;

        public FrmServico()
        {
            InitializeComponent();
            this.editando = false;
            LimpaCampos();
        }

        private void DesabilitaCampos()
        {
            txtServico.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtServico.Enabled = !false;
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
            txtServico.Text = String.Empty;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtServico.Text))
            {
                if (this.servicoCarregado == null)
                    this.servicoCarregado = new Servico();

                this.servicoCarregado.servico = txtServico.Text;

                ServicoDAO dao = new ServicoDAO();
                if (!this.editando)
                    dao.AdicionaServico(this.servicoCarregado);
                else dao.AlteraServico(this.servicoCarregado);
                CarregaListaServicos();
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações deste SERVIÇO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaServico();
                }
            }
            else this.Close();
        }

        private void FrmServico_Load(object sender, EventArgs e)
        {
            CarregaListaServicos();
        }

        public void CarregaListaServicos()
        {
            dgvServicos.AutoGenerateColumns = false;
            listaServicos = new ServicoDAO().GetListaServicos();
            dgvServicos.DataSource = new BindingList<Servico>(listaServicos);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvServicos.RowCount != 0)
            {
                if (dgvServicos.CurrentRow.Selected)
                {
                    this.editando = true;
                    DesabilitaBotoes();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum SERVIÇO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum SERVIÇO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            LimpaCampos();
            if (dgvServicos.RowCount != 0)
            {
                if (dgvServicos.CurrentRow.Selected)
                {
                    this.editando = false;
                    int idServico = Convert.ToInt32(dgvServicos.CurrentRow.Cells["idServico"].Value.ToString());
                    this.servicoCarregado = this.listaServicos.Find(u => u.IdServico == idServico);
                    CarregaServico();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum SERVIÇO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CarregaServico()
        {
            txtServico.Text = servicoCarregado.servico;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.editando = false;
            LimpaCampos();
            DesabilitaBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvServicos.RowCount != 0)
            {
                if (dgvServicos.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir este SERVIÇO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ServicoDAO dao = new ServicoDAO();
                        dao.DeletaServico(this.servicoCarregado.IdServico);
                        CarregaListaServicos();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum SERVIÇO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum SERVIÇO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
