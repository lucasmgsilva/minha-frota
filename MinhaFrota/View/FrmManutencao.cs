using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trinity.Model;
using Trinity.Model.Bean;
using Trinity.Model.DAO;

namespace Trinity.View
{
    public partial class FrmManutencao : Form
    {
        bool editando;
        Manutencao manutencaoCarregada;

        List<ProdutoManutencao> listaProdutosManutencao;
        List<ServicoManutencao> listaServicosManutencao;

        public FrmManutencao(Manutencao manutencaoCarregada)
        {
            InitializeComponent();
            this.manutencaoCarregada = manutencaoCarregada;
            DesabilitaBotoes();
            CarregaVeiculos();
            CarregaMotoristas();
            CarregaProdutos();
            CarregaServicos();
            if (this.manutencaoCarregada != null)
            {
                this.editando = true;
                CarregaManutencao();
            }
        }

        private void CarregaVeiculos()
        {
            cmbVeiculo.DisplayMember = "placa";
            cmbVeiculo.DataSource = new VeiculoDAO().GetListaVeiculos();
        }

        private void SelecionaVeiculo()
        {
            foreach (Veiculo item in cmbVeiculo.Items)
            {
                if(item.IdVeiculo == this.manutencaoCarregada.Veiculo.IdVeiculo)
                {
                    cmbVeiculo.SelectedItem = item;
                    break;
                }
            }
        }

        private void SelecionaMotorista()
        {
            foreach (Motorista item in cmbMotorista.Items)
            {
                if (item.IdMotorista == this.manutencaoCarregada.Motorista.IdMotorista)
                {
                    cmbMotorista.SelectedItem = item;
                    break;
                }
            }
        }

        private void CarregaMotoristas()
        {
            cmbMotorista.DisplayMember = "nome";
            cmbMotorista.DataSource = new MotoristaDAO().GetListaMotoristas();
        }

        private void CarregaProdutos()
        {
            cmbProduto.DisplayMember = "produto";
            cmbProduto.DataSource = new ProdutoDAO().GetListaProdutos();
        }

        private void CarregaServicos()
        {
            cmbServico.DisplayMember = "servico";
            cmbServico.DataSource = new ServicoDAO().GetListaServicos();
        }

        private void CarregaProdutosManutencao()
        {
            dgvProdutos.AutoGenerateColumns = false;
            listaProdutosManutencao = new ProdutoManutencaoDAO().GetListaProdutoManutencao(this.manutencaoCarregada.IdManutencao);
            dgvProdutos.DataSource = new BindingList<ProdutoManutencao>(listaProdutosManutencao);
            LimpaCamposProdutoManutencao();
        }

        private void CarregaServicosManutencao()
        {
            dgvServicos.AutoGenerateColumns = false;
            listaServicosManutencao = new ServicoManutencaoDAO().GetListaProdutoManutencao(this.manutencaoCarregada.IdManutencao);
            dgvServicos.DataSource = new BindingList<ServicoManutencao>(listaServicosManutencao);
            LimpaCamposServicoManutencao();
        }

        private void CarregaManutencao()
        {
            txtDataManutencao.Value = this.manutencaoCarregada.DataManutencao;
            SelecionaVeiculo();
            SelecionaMotorista();
            cmbTipo.Text = this.manutencaoCarregada.Tipo;
            CarregaProdutosManutencao();
            CarregaServicosManutencao();
        }

        private void DesabilitaCampos()
        {
            txtDataManutencao.Enabled = false;
            cmbVeiculo.Enabled = false;
            cmbMotorista.Enabled = false;
            cmbTipo.Enabled = false;
            cmbProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtValor.Enabled = false;
            btnSalvarProduto.Enabled = false;
            btnRemover.Enabled = false;
            dgvProdutos.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtDataManutencao.Enabled = !false;
            cmbVeiculo.Enabled = !false;
            cmbMotorista.Enabled = !false;
            cmbTipo.Enabled = !false;
            cmbProduto.Enabled = !false;
            txtQuantidade.Enabled = !false;
            txtValor.Enabled = !false;
            btnSalvarProduto.Enabled = !false;
            btnRemover.Enabled = !false;
            dgvProdutos.Enabled = !false;
            txtDataManutencao.Focus();
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

        private void LimpaCamposProdutoManutencao()
        {
            dgvProdutos.ClearSelection();
            cmbProduto.SelectedItem = null;
            txtQuantidade.Value = 0;
            txtValor.Value = 0;
        }

        private void LimpaCamposServicoManutencao()
        {
            dgvServicos.ClearSelection();
            cmbServico.SelectedItem = null;
            txtValorServico.Value = 0;
        }

        private void LimpaCampos()
        {
            DesabilitaBotoes();
            txtDataManutencao.Value = DateTime.Now;
            cmbVeiculo.SelectedItem = null;
            cmbMotorista.SelectedItem = null;
            cmbTipo.SelectedItem = null;
            LimpaCamposProdutoManutencao();
            LimpaCamposServicoManutencao();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(txtDataManutencao.Text.Trim()) && cmbVeiculo.SelectedItem != null &&
                cmbMotorista.SelectedItem != null && cmbTipo.SelectedItem != null)
            {
                if(dgvProdutos.RowCount != 0 || dgvServicos.RowCount != 0)
                {
                    if (this.manutencaoCarregada == null)
                        this.manutencaoCarregada = new Manutencao();

                    this.manutencaoCarregada.DataManutencao = Convert.ToDateTime(txtDataManutencao.Text);
                    this.manutencaoCarregada.Veiculo = (Veiculo) cmbVeiculo.SelectedItem;
                    this.manutencaoCarregada.Motorista = (Motorista) cmbMotorista.SelectedItem;
                    this.manutencaoCarregada.Tipo = cmbTipo.Text;

                    ManutencaoDAO dao = new ManutencaoDAO();
                    if (!this.editando)
                        dao.AdicionaManutencao(this.manutencaoCarregada);
                    else dao.AlteraManutencao(this.manutencaoCarregada);
                    this.Close();
                } else MessageBox.Show("Mensagem de erro 2");
            } else MessageBox.Show("Mensagem de erro 1");
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

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações desta MANUTENÇÃO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaManutencao();
                }
            }
            else this.Close();
        }

        private void tbcClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FrmProduto frmProduto = new FrmProduto();
            frmProduto.ShowDialog();
            CarregaProdutos();
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

        private void btnSalvarProduto_Click(object sender, EventArgs e)
        {
            if (this.manutencaoCarregada != null)
            {
                if(cmbProduto.SelectedItem != null)
                {
                    if (txtQuantidade.Value != 0 && txtValor.Value != 0)
                    {
                        ProdutoManutencao produtoManutencao = listaProdutosManutencao.Find(prodManutencao => prodManutencao.Produto.idProduto == ((Produto) cmbProduto.SelectedItem).idProduto);
                        ProdutoManutencaoDAO dao = new ProdutoManutencaoDAO();

                        if (produtoManutencao == null) /*É um produto novo que não está na tabela*/
                        {
                            produtoManutencao = new ProdutoManutencao()
                            {
                                Manutencao = this.manutencaoCarregada,
                                Produto = (Produto)cmbProduto.SelectedItem,
                                Quantidade = Convert.ToDouble(txtQuantidade.Value),
                                ValorUnitario = Convert.ToDouble(txtValor.Value)
                            };
                            dao.AdicionaProdutoManutencao(produtoManutencao);
                        } else
                        {
                            produtoManutencao.Manutencao = this.manutencaoCarregada;
                            produtoManutencao.Produto = (Produto)cmbProduto.SelectedItem;
                            produtoManutencao.Quantidade = Convert.ToDouble(txtQuantidade.Value);
                            produtoManutencao.ValorUnitario = Convert.ToDouble(txtValor.Value);

                            dao.AlteraProdutoManutencao(produtoManutencao);
                        }
                        CarregaProdutosManutencao();
                } else MessageBox.Show("Não foi possível realizar a operação.\nA QUANTIDADE e o VALOR do produto devem ser diferente de 0!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else MessageBox.Show("Não foi possível realizar a operação.\nNenhum PRODUTO foi selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show("Não foi possível realizar a operação.\nÉ necessário salvar a MANUTENÇÃO antes de adicionar um PRODUTO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";
            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;
                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;
                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }
            return retValue;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.manutencaoCarregada != null)
            {
                if (dgvProdutos.RowCount != 0)
                {
                    if (dgvProdutos.CurrentRow.Selected)
                    {
                        if (MessageBox.Show("Você realmente quer excluir este PRODUTO DE MANUTENÇÃO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int idManutencao = this.manutencaoCarregada.IdManutencao;
                            int idProduto = this.listaProdutosManutencao[dgvProdutos.CurrentRow.Index].Produto.idProduto;
                            ProdutoManutencaoDAO dao = new ProdutoManutencaoDAO();
                            dao.DeletaProdutoManutencao(idManutencao, idProduto);
                            this.dgvProdutos.SelectionChanged -= new System.EventHandler(this.dgvProdutos_SelectionChanged);
                            CarregaProdutosManutencao();
                            this.dgvProdutos.SelectionChanged += new System.EventHandler(this.dgvProdutos_SelectionChanged);
                        }
                    }
                    else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma PRODUTO DE MANUTENÇÃO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum PRODUTO DE MANUTENÇÃO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else MessageBox.Show("Não foi possível realizar a operação.\nÉ necessário salvar a MANUTENÇÃO antes de remover um PRODUTO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvProdutos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvProdutos.RowCount != 0 && dgvProdutos.CurrentRow != null)
            {
                ProdutoManutencao produtoManutencao = this.listaProdutosManutencao[dgvProdutos.CurrentRow.Index];
                foreach (Produto item in cmbProduto.Items)
                {
                    if(item.idProduto == produtoManutencao.Produto.idProduto)
                    {
                        cmbProduto.SelectedItem = item;
                        txtQuantidade.Value = Convert.ToDecimal(produtoManutencao.Quantidade);
                        txtValor.Value = Convert.ToDecimal(produtoManutencao.ValorUnitario);
                        break;
                    }
                }
            }
        }

        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantidade.Value = 0;
            txtValor.Value = 0;
        }

        private void dgvProdutos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvProdutos.Rows[e.RowIndex].DataBoundItem != null) && (dgvProdutos.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvProdutos.Rows[e.RowIndex].DataBoundItem, dgvProdutos.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void dgvServicos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvServicos.Rows[e.RowIndex].DataBoundItem != null) && (dgvServicos.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvServicos.Rows[e.RowIndex].DataBoundItem, dgvServicos.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void btnSalvarServico_Click(object sender, EventArgs e)
        {
            if (this.manutencaoCarregada != null)
            {
                if (cmbServico.SelectedItem != null)
                {
                    if (txtValorServico.Value != 0)
                    {
                        ServicoManutencao servicoManutencao = listaServicosManutencao.Find(srvManutencao => srvManutencao.Servico.IdServico == ((Servico)cmbServico.SelectedItem).IdServico);
                        ServicoManutencaoDAO dao = new ServicoManutencaoDAO();
                        if (servicoManutencao == null) /*É um serviço novo que não está na tabela*/
                        {
                            servicoManutencao = new ServicoManutencao()
                            {
                                Manutencao = this.manutencaoCarregada,
                                Servico = (Servico) cmbServico.SelectedItem,
                                Valor = Convert.ToDouble(txtValorServico.Value)
                            };
                            dao.AdicionaServicoManutencao(servicoManutencao);
                        } else
                        {
                            servicoManutencao.Manutencao = this.manutencaoCarregada;
                            servicoManutencao.Servico = (Servico)cmbServico.SelectedItem;
                            servicoManutencao.Valor = Convert.ToDouble(txtValorServico.Value);
                            dao.AlteraServicoManutencao(servicoManutencao);
                        }
                        CarregaServicosManutencao();
                    }
                    else MessageBox.Show("Não foi possível realizar a operação.\nO VALOR do serviço deve ser diferente de 0!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNenhum SERVIÇO foi selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nÉ necessário salvar a MANUTENÇÃO antes de adicionar um SERVIÇO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRemoverServico_Click(object sender, EventArgs e)
        {
            if (this.manutencaoCarregada != null)
            {
                if (dgvServicos.RowCount != 0)
                {
                    if (dgvServicos.CurrentRow.Selected)
                    {
                        if (MessageBox.Show("Você realmente quer excluir este SERVIÇO DE MANUTENÇÃO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int idManutencao = this.manutencaoCarregada.IdManutencao;
                            int idServico = this.listaServicosManutencao[dgvServicos.CurrentRow.Index].Servico.IdServico;
                            ServicoManutencaoDAO dao = new ServicoManutencaoDAO();
                            dao.DeletaServicoManutencao(idManutencao, idServico);
                            this.dgvServicos.SelectionChanged -= new System.EventHandler(this.dgvServicos_SelectionChanged);
                            CarregaServicosManutencao();
                            this.dgvServicos.SelectionChanged += new System.EventHandler(this.dgvServicos_SelectionChanged);
                        }
                    }
                    else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma SERVIÇO DE MANUTENÇÃO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum SERVIÇO DE MANUTENÇÃO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nÉ necessário salvar a MANUTENÇÃO antes de remover um SERVIÇO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvServicos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServicos.RowCount != 0 && dgvServicos.CurrentRow != null)
            {
                ServicoManutencao servicoManutencao = this.listaServicosManutencao[dgvServicos.CurrentRow.Index];
                foreach (Servico item in cmbServico.Items)
                {
                    if (item.IdServico == servicoManutencao.Servico.IdServico)
                    {
                        cmbServico.SelectedItem = item;
                        txtValorServico.Value = Convert.ToDecimal(servicoManutencao.Valor);
                        break;
                    }
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            FrmServico frmServico = new FrmServico();
            frmServico.ShowDialog();
            CarregaServicos();
        }
    }
}