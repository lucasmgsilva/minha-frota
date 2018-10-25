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
    public partial class FrmAbastecimento : Form
    {
        List<Modelo> listaModelos;
        bool editando;
        Modelo modeloCarregado;

        public FrmAbastecimento()
        {
            InitializeComponent();
            this.editando = false;
            CarregaListaVeiculos();
            CarregaListaCombustiveis();
            CarregaListaMotoristas();
            LimpaCampos();
        }

        private void CarregaListaVeiculos()
        {
            cmbVeiculo.SelectedItem = null;
            cmbVeiculo.DisplayMember = "placa";
            cmbVeiculo.DataSource = new VeiculoDAO().GetListaVeiculos();
        }

        private void CarregaListaCombustiveis()
        {
            cmbCombustivel.SelectedItem = null;
            cmbCombustivel.DisplayMember = "combustivel";
            cmbCombustivel.DataSource = new CombustivelDAO().GetListaCombustiveis();
        }

        private void CarregaListaMotoristas()
        {
            cmbMotorista.SelectedItem = null;
            cmbMotorista.DisplayMember = "nome";
            cmbMotorista.DataSource = new MotoristaDAO().GetListaMotoristas();
        }

        private void DesabilitaCampos()
        {
            cmbVeiculo.Enabled = !false;
            cmbCombustivel.Enabled = !false;
        }

        private void HabilitaCampos()
        {
            cmbVeiculo.Enabled = false;
            cmbCombustivel.Enabled = false;
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
            cmbCombustivel.SelectedItem = null;
            cmbMotorista.SelectedItem = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbVeiculo.SelectedItem != null && cmbCombustivel.SelectedItem != null)
            {
                if (this.modeloCarregado == null)
                    this.modeloCarregado = new Modelo();

                this.modeloCarregado.Marca = (Marca)cmbVeiculo.SelectedItem;
                //this.modeloCarregado.modelo = txtModelo.Text;
                

                ModeloDAO dao = new ModeloDAO();
                if (!this.editando)
                    dao.AdicionaModelo(this.modeloCarregado);
                else dao.AlteraModelo(this.modeloCarregado);
                CarregaListaModelos();
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

        public void CarregaListaModelos()
        {
            /*if (cmbVeiculo.SelectedItem != null)
            {
                dgvModelos.AutoGenerateColumns = false;
                listaModelos = new ModeloDAO().GetListaModelos(((Marca) cmbVeiculo.SelectedItem).IdMarca);
                dgvModelos.DataSource = new BindingList<Modelo>(listaModelos);
            }*/
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
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MODELO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MODELO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            LimpaCampos();
            if (dgvModelos.RowCount != 0)
            {
                if (dgvModelos.CurrentRow.Selected)
                {
                    this.editando = false;
                    int idModelo = Convert.ToInt32(dgvModelos.CurrentRow.Cells["idModelo"].Value.ToString());
                    this.modeloCarregado = this.listaModelos.Find(u => u.IdModelo == idModelo);
                    //CarregaModelos();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum MODELO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (MessageBox.Show("Você realmente quer excluir este MODELO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ModeloDAO dao = new ModeloDAO();
                        dao.DeletaModelo(this.modeloCarregado.IdModelo);
                        CarregaListaModelos();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum MODELO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MODELO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaListaModelos();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            FrmVeiculo veiculo = new FrmVeiculo(null);
            veiculo.ShowDialog();
            CarregaListaVeiculos();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FrmCombustivel combustivel = new FrmCombustivel();
            combustivel.ShowDialog();
            CarregaListaCombustiveis();
        }

        private void realizaCalculos()
        {
            this.txtLitros.ValueChanged -= new System.EventHandler(this.txtValorLitro_ValueChanged);
            this.txtValorLitro.ValueChanged -= new System.EventHandler(this.txtValorLitro_ValueChanged);
            this.txtValorTotal.ValueChanged -= new System.EventHandler(this.txtValorLitro_ValueChanged);

            if (txtLitros.Focused)
            {
                if (txtValorLitro.Value != 0) //Calcula Litros
                    txtLitros.Value = txtValorTotal.Value / txtValorLitro.Value;
            }

            //Calcular litros
            if (txtValorLitro.Value != 0)
                txtLitros.Value = txtValorTotal.Value / txtValorLitro.Value;

            //Calcular valor litro
            if(txtLitros.Value != 0)
                txtValorLitro.Value = txtValorTotal.Value / txtLitros.Value;

            //Calcular valor total
            txtValorTotal.Value = txtValorLitro.Value * txtLitros.Value;

            this.txtValorLitro.ValueChanged += new System.EventHandler(this.txtValorLitro_ValueChanged);
            this.txtValorLitro.ValueChanged += new System.EventHandler(this.txtValorLitro_ValueChanged);
            this.txtValorLitro.ValueChanged += new System.EventHandler(this.txtValorLitro_ValueChanged);
        }

        private void txtLitros_ValueChanged(object sender, EventArgs e)
        {
            realizaCalculos();
        }

        private void txtValorLitro_ValueChanged(object sender, EventArgs e)
        {
            realizaCalculos();
        }

        private void txtValorTotal_ValueChanged(object sender, EventArgs e)
        {
            realizaCalculos();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FrmMotorista motorista = new FrmMotorista(null);
            motorista.ShowDialog();
            CarregaListaMotoristas();

        }
    }
}