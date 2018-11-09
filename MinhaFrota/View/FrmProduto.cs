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
    public partial class FrmProduto : Form
    {
        List<Produto> listaProdutos;
        bool editando;
        Produto produtoCarregado;

        public FrmProduto()
        {
            InitializeComponent();
            this.editando = false;
            LimpaCampos();
        } 

        private void CarregaListaUnidadesMedida()
        {
            cmbUnidadeMedida.SelectedItem = null;
            cmbUnidadeMedida.DisplayMember = "unidadeMedida";
            cmbUnidadeMedida.DataSource = new UnidadeMedidaDAO().GetListaUnidadeMedida();
        }

        private void DesabilitaCampos()
        {
            cmbUnidadeMedida.Enabled = false;
            txtProduto.Enabled = false;
        }

        private void HabilitaCampos()
        {
            cmbUnidadeMedida.Enabled = !false;
            txtProduto.Enabled = !false;
            txtProduto.Focus();
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
            txtProduto.Text = String.Empty;
            cmbUnidadeMedida.SelectedItem = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtProduto.Text.Trim()) && cmbUnidadeMedida.SelectedItem != null)
            {
                if (this.produtoCarregado == null)
                    this.produtoCarregado = new Produto();

                this.produtoCarregado.produto = txtProduto.Text.Trim();
                this.produtoCarregado.UnidadeMedida = (UnidadeMedida) cmbUnidadeMedida.SelectedItem;
                
                ProdutoDAO dao = new ProdutoDAO();
                if (!this.editando)
                    dao.AdicionaProduto(this.produtoCarregado);
                else dao.AlteraProduto(this.produtoCarregado);
                CarregaListaModelos();
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações deste PRODUTO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaProduto();
                }
            }
            else this.Close();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            CarregaListaUnidadesMedida();
            CarregaListaModelos();
        }

        public void CarregaListaModelos()
        {
            if (cmbUnidadeMedida.SelectedItem != null)
            {
                dgvModelos.AutoGenerateColumns = false;
                listaProdutos = new ProdutoDAO().GetListaProdutos();
                dgvModelos.DataSource = new BindingList<Produto>(listaProdutos);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvModelos.RowCount != 0)
            {
                if (dgvModelos.CurrentRow.Selected)
                {
                    this.editando = true;
                    DesabilitaBotoes();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum PRODUTO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum PRODUTO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            LimpaCampos();
            if (dgvModelos.RowCount != 0)
            {
                if (dgvModelos.CurrentRow.Selected)
                {
                    this.editando = false;
                    int idProduto = Convert.ToInt32(dgvModelos.CurrentRow.Cells["idProduto"].Value.ToString());
                    this.produtoCarregado = this.listaProdutos.Find(u => u.idProduto == idProduto);
                    CarregaProduto();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum PRODUTO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CarregaProduto() {
            txtProduto.Text = produtoCarregado.produto;
            SelecionaUnidadeMedida();
        }

        private void SelecionaUnidadeMedida()
        {
            int idUnidadeMedida = this.produtoCarregado.UnidadeMedida.IdUnidadeMedida;
            foreach (UnidadeMedida item in cmbUnidadeMedida.Items)
            {
                if(item.IdUnidadeMedida == idUnidadeMedida)
                {
                    cmbUnidadeMedida.SelectedItem = item;
                    break;
                }
            }
        }
    
        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.editando = false;
            LimpaCampos();
            DesabilitaBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvModelos.RowCount != 0)
            {
                if (dgvModelos.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir este PRODUTO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ProdutoDAO dao = new ProdutoDAO();
                        dao.DeletaProduto(this.produtoCarregado.idProduto);
                        CarregaListaModelos();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum PRODUTO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum PRODUTO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label20_Click(object sender, EventArgs e)
        {
            FrmUnidadeMedida unidadeMedida = new FrmUnidadeMedida();
            unidadeMedida.ShowDialog();
            CarregaListaUnidadesMedida();
        }
    }
}