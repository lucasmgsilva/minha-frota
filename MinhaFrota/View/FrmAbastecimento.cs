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
using Trinity.Model.Bean;
using Trinity.Model.DAO;

namespace Trinity.View
{
    public partial class FrmAbastecimento : Form
    {
        List<Abastecimento> listaAbastecimento;
        bool editando;
        Abastecimento abastecimentoCarregado;

        public FrmAbastecimento()
        {
            InitializeComponent();
            this.editando = false;
            CarregaListaVeiculos();
            CarregaListaMotoristas();
            LimpaCampos();
        }

        private void CarregaListaVeiculos()
        {
            cmbVeiculo.SelectedItem = null;
            cmbVeiculo.DisplayMember = "placa";
            cmbVeiculo.DataSource = new VeiculoDAO().GetListaVeiculos();
        }

        private void CarregaListaMotoristas()
        {
            cmbMotorista.SelectedItem = null;
            cmbMotorista.DisplayMember = "nome";
            cmbMotorista.DataSource = new MotoristaDAO().GetListaMotoristas();
        }

        private void DesabilitaCampos()
        {
            txtData.Enabled = false;
            cmbMotorista.Enabled = false;
            cmbVeiculo.Enabled = !false;
            txtKmAtual.Enabled = false;
            txtLitros.Enabled = false;
            txtValorLitro.Enabled = false;
            txtValorTotal.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtData.Enabled = !false;
            cmbMotorista.Enabled = !false;
            cmbVeiculo.Enabled = false;
            txtKmAtual.Enabled = !false;
            txtLitros.Enabled = !false;
            txtValorLitro.Enabled = !false;
            txtValorTotal.Enabled = !false;
            txtData.Focus();
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
            txtData.Value = DateTime.Now;
            cmbMotorista.SelectedItem = null;
            txtKmAtual.Value = 0;
            txtLitros.Value = 0;
            txtValorLitro.Value = 0;
            txtValorTotal.Value = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtData.Text.Trim()) && cmbMotorista.SelectedItem != null && cmbVeiculo.SelectedItem != null && 
                !String.IsNullOrWhiteSpace(txtKmAtual.Value.ToString().Trim()) &&
                !String.IsNullOrWhiteSpace(txtLitros.Value.ToString().Trim()) &&
                !String.IsNullOrWhiteSpace(txtValorLitro.Value.ToString().Trim()) &&
                !String.IsNullOrWhiteSpace(txtValorTotal.Value.ToString().Trim()))
            {
                if(txtKmAtual.Value > 0 && txtLitros.Value > 0 && txtValorLitro.Value > 0 && txtValorTotal.Value > 0)
                {
                    if (this.abastecimentoCarregado == null)
                        this.abastecimentoCarregado = new Abastecimento();

                    this.abastecimentoCarregado.Motorista = (Motorista)cmbMotorista.SelectedItem;
                    this.abastecimentoCarregado.Veiculo = (Veiculo)cmbVeiculo.SelectedItem;
                    this.abastecimentoCarregado.DataAbastecimento = Convert.ToDateTime(txtData.Text);
                    this.abastecimentoCarregado.Litros = float.Parse(txtLitros.Value.ToString());
                    this.abastecimentoCarregado.ValorLitro = float.Parse(txtValorLitro.Value.ToString());
                    this.abastecimentoCarregado.KmAtual = int.Parse(txtKmAtual.Value.ToString());

                    AbastecimentoDAO dao = new AbastecimentoDAO();
                    if (!this.editando)
                        dao.AdicionaAbastecimento(this.abastecimentoCarregado);
                    else dao.AlteraAbastecimento(this.abastecimentoCarregado);
                    CarregaListaAbastecimentos();
                } else MessageBox.Show("Não foi possível realizar a operação.\nO Km. Atual, Litros, Valor por Litro e Valor Total devem ser maior que zero!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações deste ABASTECIMENTO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaAbastecimento();
                }
            }
            else this.Close();
        }

        public void CarregaListaAbastecimentos()
        {
            if (cmbVeiculo.SelectedItem != null)
            {
                dgvAbastecimentos.AutoGenerateColumns = false;
                listaAbastecimento = new AbastecimentoDAO().GetListaAbastecimento(((Veiculo) cmbVeiculo.SelectedItem).IdVeiculo);
                dgvAbastecimentos.DataSource = new BindingList<Abastecimento>(listaAbastecimento);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAbastecimentos.RowCount != 0)
            {
                if (dgvAbastecimentos.CurrentRow.Selected)
                {
                    this.editando = true;
                    DesabilitaBotoes();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum ABASTECIMENTO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum ABASTECIMENTO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            LimpaCampos();
            if (dgvAbastecimentos.RowCount != 0)
            {
                if (dgvAbastecimentos.CurrentRow.Selected)
                {
                    this.editando = false;
                    int idAbastecimento = Convert.ToInt32(dgvAbastecimentos.CurrentRow.Cells["idAbastecimento"].Value.ToString());
                    this.abastecimentoCarregado = this.listaAbastecimento.Find(u => u.IdAbastecimento == idAbastecimento);
                    CarregaAbastecimento();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum ABASTECIMENTO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.editando = false;
            LimpaCampos();
            DesabilitaBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvAbastecimentos.RowCount != 0)
            {
                if (dgvAbastecimentos.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir este ABASTECIMENTO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        AbastecimentoDAO dao = new AbastecimentoDAO();
                        dao.DeletaAbastecimento(this.abastecimentoCarregado.IdAbastecimento);
                        CarregaListaAbastecimentos();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum ABASTECIMENTO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum ABASTECIMENTO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label20_Click(object sender, EventArgs e)
        {
            FrmVeiculo veiculo = new FrmVeiculo(null);
            veiculo.ShowDialog();
            CarregaListaVeiculos();
        }

        private void txtValorLitro_ValueChanged(object sender, EventArgs e)
        {
            txtValorTotal.Value = txtValorLitro.Value * txtLitros.Value;
        }

        private void txtValorTotal_ValueChanged(object sender, EventArgs e)
        {
            if(txtLitros.Value != 0)
                txtValorLitro.Value = txtValorTotal.Value / txtLitros.Value;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FrmMotorista motorista = new FrmMotorista(null);
            motorista.ShowDialog();
            CarregaListaMotoristas();

        }

        private void txtLitros_ValueChanged(object sender, EventArgs e)
        {
            txtValorTotal.Value = txtValorLitro.Value * txtLitros.Value;
        }

        private void cmbVeiculo_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaListaAbastecimentos();
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

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvAbastecimentos.Rows[e.RowIndex].DataBoundItem != null) && (dgvAbastecimentos.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvAbastecimentos.Rows[e.RowIndex].DataBoundItem, dgvAbastecimentos.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void SelecionaMotorista()
        {
            
            foreach (Motorista item in cmbMotorista.Items)
            {
                if (item.IdMotorista == this.abastecimentoCarregado.Motorista.IdMotorista)
                {
                    cmbMotorista.SelectedItem = item;
                    break;
                }
            }
        }

        private void CarregaAbastecimento()
        {
            txtData.Value = this.abastecimentoCarregado.DataAbastecimento;
            SelecionaMotorista();
            cmbMotorista.SelectedItem = this.abastecimentoCarregado.Motorista;
            txtKmAtual.Value = this.abastecimentoCarregado.KmAtual;
            txtLitros.Value = Decimal.Parse(this.abastecimentoCarregado.Litros.ToString());
            txtValorLitro.Value = Decimal.Parse(this.abastecimentoCarregado.ValorLitro.ToString());
        }
    }
}