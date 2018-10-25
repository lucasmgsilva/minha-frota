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
        Modelo modeloCarregado;

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
            cmbVeiculo.Enabled = false;
        }

        private void HabilitaCampos()
        {
            cmbVeiculo.Enabled = !false;
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
            cmbVeiculo.SelectedItem = null;
            cmbMotorista.SelectedItem = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbVeiculo.SelectedItem != null && cmbMotorista.SelectedItem != null)
            {
                Abastecimento abastecimento = new Abastecimento()
                {
                    Motorista = (Motorista)cmbMotorista.SelectedItem,
                    Veiculo = (Veiculo)cmbVeiculo.SelectedItem,
                    DataAbastecimento = Convert.ToDateTime(txtData.Text),
                    Litros = float.Parse(txtLitros.Value.ToString()),
                    ValorLitro = float.Parse(txtValorLitro.Value.ToString()),
                    KmAtual = int.Parse(txtKmAtual.Value.ToString())
                };

                new AbastecimentoDAO().AdicionaAbastecimento(abastecimento);

                /*if (this.modeloCarregado == null)
                    this.modeloCarregado = new Modelo();

                this.modeloCarregado.Marca = (Marca)cmbVeiculo.SelectedItem;
                //this.modeloCarregado.modelo = txtModelo.Text;
                

                ModeloDAO dao = new ModeloDAO();
                if (!this.editando)
                    dao.AdicionaModelo(this.modeloCarregado);
                else dao.AlteraModelo(this.modeloCarregado);
                CarregaListaModelos();*/
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações deste MODELO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    //CarregaModelos();
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
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MODELO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MODELO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            /*LimpaCampos();
            if (dgvAbastecimentos.RowCount != 0)
            {
                if (dgvAbastecimentos.CurrentRow.Selected)
                {
                    this.editando = false;
                    int idModelo = Convert.ToInt32(dgvAbastecimentos.CurrentRow.Cells["idModelo"].Value.ToString());
                    //this.modeloCarregado = this.listaAbastecimento.Find(u => u.IdModelo == idModelo);
                    //CarregaModelos();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum MODELO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            */
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
                    if (MessageBox.Show("Você realmente quer excluir este MODELO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ModeloDAO dao = new ModeloDAO();
                        dao.DeletaModelo(this.modeloCarregado.IdModelo);
                        //CarregaListaModelos();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum MODELO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MODELO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}