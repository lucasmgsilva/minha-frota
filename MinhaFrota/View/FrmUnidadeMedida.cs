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
    public partial class FrmUnidadeMedida : Form
    {
        List<UnidadeMedida> listaUnidadesMedida;
        bool editando;
        UnidadeMedida unidadeMedidaCarregada;

        public FrmUnidadeMedida()
        {
            InitializeComponent();
            this.editando = false;
            LimpaCampos();
        }

        private void DesabilitaCampos()
        {
            txtUnidadeMedida.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtUnidadeMedida.Enabled = !false;
            txtUnidadeMedida.Focus();
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
            txtUnidadeMedida.Text = String.Empty;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtUnidadeMedida.Text.Trim()))
            {
                if(txtUnidadeMedida.Text.Trim().Length == 2)
                {
                    if (this.unidadeMedidaCarregada == null)
                        this.unidadeMedidaCarregada = new UnidadeMedida();

                    this.unidadeMedidaCarregada.unidadeMedida = txtUnidadeMedida.Text.Trim();

                    UnidadeMedidaDAO dao = new UnidadeMedidaDAO();
                    if (!this.editando)
                        dao.AdicionaUnidadeMedida(this.unidadeMedidaCarregada);
                    else dao.AlteraUnidadeMedida(this.unidadeMedidaCarregada);
                    CarregaListaUnidadesMedida();
                } else MessageBox.Show("Não foi possível realizar a operação.\nA UNIDADE DE MEDIDA deve ter dois (2) caracteres!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações desta UNIDADE DE MEDIDA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaUnidadesMedida();
                }
            }
            else this.Close();
        }

        private void FrmUnidadeMedida_Load(object sender, EventArgs e)
        {
            CarregaListaUnidadesMedida();
        }

        public void CarregaListaUnidadesMedida()
        {
            dgvUnidadesMedida.AutoGenerateColumns = false;
            listaUnidadesMedida = new UnidadeMedidaDAO().GetListaUnidadeMedida();
            dgvUnidadesMedida.DataSource = new BindingList<UnidadeMedida>(listaUnidadesMedida);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUnidadesMedida.RowCount != 0)
            {
                if (dgvUnidadesMedida.CurrentRow.Selected)
                {
                    this.editando = true;
                    DesabilitaBotoes();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma UNIDADE DE MEDIDA selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma UNIDADE DE MEDIDA cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            LimpaCampos();
            if (dgvUnidadesMedida.RowCount != 0)
            {
                if (dgvUnidadesMedida.CurrentRow.Selected)
                {
                    this.editando = false;
                    int idUnidadeMedida = Convert.ToInt32(dgvUnidadesMedida.CurrentRow.Cells["idUnidadeMedida"].Value.ToString());
                    this.unidadeMedidaCarregada = this.listaUnidadesMedida.Find(u => u.IdUnidadeMedida == idUnidadeMedida);
                    CarregaUnidadesMedida();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma UNIDADE DE MEDIDA cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CarregaUnidadesMedida()
        {
            txtUnidadeMedida.Text = unidadeMedidaCarregada.unidadeMedida;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.editando = false;
            LimpaCampos();
            DesabilitaBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvUnidadesMedida.RowCount != 0)
            {
                if (dgvUnidadesMedida.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir esta UNIDADE DE MEDIDA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UnidadeMedidaDAO dao = new UnidadeMedidaDAO();
                        dao.DeletaUnidadeMedida(this.unidadeMedidaCarregada.IdUnidadeMedida);
                        CarregaListaUnidadesMedida();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma UNIDADE DE MEDIDA selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma UNIDADE DE MEDIDA cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
