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
    public partial class FrmCombustivel : Form
    {
        List<Combustivel> listaCombustiveis;
        bool editando;
        Combustivel combustivelCarregado;

        public FrmCombustivel()
        {
            InitializeComponent();
            this.editando = false;
            LimpaCampos();
        }

        private void DesabilitaCampos()
        {
            txtCombustivel.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtCombustivel.Enabled = !false;
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
            txtCombustivel.Text = String.Empty;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCombustivel.Text))
            {
                if (this.combustivelCarregado == null)
                    this.combustivelCarregado = new Combustivel();

                this.combustivelCarregado.combustivel = txtCombustivel.Text;

                CombustivelDAO dao = new CombustivelDAO();
                if (!this.editando)
                    dao.AdicionaCombustivel(this.combustivelCarregado);
                else dao.AlteraCombustivel(this.combustivelCarregado);
                CarregaListaCombustiveis();
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações deste COMBUSTÍVEL?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaCombustivel();
                }
            }
            else this.Close();
        }

        private void FrmCombustivel_Load(object sender, EventArgs e)
        {
            CarregaListaCombustiveis();
        }

        public void CarregaListaCombustiveis()
        {
            dgvCombustiveis.AutoGenerateColumns = false;
            listaCombustiveis = new CombustivelDAO().GetListaCombustiveis();
            dgvCombustiveis.DataSource = new BindingList<Combustivel>(listaCombustiveis);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCombustiveis.RowCount != 0)
            {
                if (dgvCombustiveis.CurrentRow.Selected)
                {
                    this.editando = true;
                    DesabilitaBotoes();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum COMBUSTÍVEL selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum COMBUSTÍVEL cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvCombustiveis_SelectionChanged(object sender, EventArgs e)
        {
            LimpaCampos();
            if (dgvCombustiveis.RowCount != 0)
            {
                if (dgvCombustiveis.CurrentRow.Selected)
                {
                    this.editando = false;
                    int idCombustivel = Convert.ToInt32(dgvCombustiveis.CurrentRow.Cells["idCombustivel"].Value.ToString());
                    this.combustivelCarregado = this.listaCombustiveis.Find(u => u.IdCombustivel == idCombustivel);
                    CarregaCombustivel();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum COMBUSTÍVEL cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CarregaCombustivel()
        {
            txtCombustivel.Text = combustivelCarregado.combustivel;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.editando = false;
            LimpaCampos();
            DesabilitaBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvCombustiveis.RowCount != 0)
            {
                if (dgvCombustiveis.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir este COMBUSTÍVEL?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CombustivelDAO dao = new CombustivelDAO();
                        dao.DeletaCombustivel(this.combustivelCarregado.IdCombustivel);
                        CarregaListaCombustiveis();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum COMBUSTÍVEL selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum COMBUSTÍVEL cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
