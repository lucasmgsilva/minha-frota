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
    public partial class FrmVeiculo : Form
    {
        bool editando;
        Veiculo veiculoCarregado;

        public FrmVeiculo(Veiculo veiculoCarregado)
        {
            InitializeComponent();
            this.veiculoCarregado = veiculoCarregado;
            DesabilitaBotoes();
            CarregaMarcas();
            CarregaCores();
            CarregaCombustiveis();
            if (this.veiculoCarregado != null)
            {
                this.editando = true;
                CarregaVeiculo();
            } else
            {
                cmbCategoria.SelectedItem = null;
                cmbCombustivel.SelectedItem = null;
                cmbCor.SelectedItem = null;
                cmbMarca.SelectedItem = null;
                cmbModelo.SelectedItem = null;
            }
        }

        private void CarregaVeiculo()
        {
            SelecionaModeloModelo();
            SelecionaCombustivel();
            txtPlaca.Text = this.veiculoCarregado.Placa;
            cmbCategoria.Text = this.veiculoCarregado.CategoriaExigida;
            SelecionaCor();
            txtAnoFabricacao.Text = this.veiculoCarregado.AnoFabricacao.ToString();
            txtAnoModelo.Text = this.veiculoCarregado.AnoModelo.ToString();
            txtKmInicial.Value = this.veiculoCarregado.KmInicial;
            txtRenavam.Text = this.veiculoCarregado.Renavam;
        }

        public void SelecionaModeloModelo()
        {
            if (this.veiculoCarregado != null)
            {
                int idMarca = this.veiculoCarregado.Modelo.Marca.IdMarca;
                foreach (Marca item in cmbMarca.Items)
                    if (item.IdMarca == idMarca)
                    {
                        cmbMarca.SelectedItem = item;
                        break;
                    }

                int idModelo = this.veiculoCarregado.Modelo.IdModelo;
                foreach (Modelo item in cmbModelo.Items)
                {
                    if (item.IdModelo == idModelo)
                    {
                        cmbModelo.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        public void SelecionaCor()
        {
            if (this.veiculoCarregado != null)
            {
                int idCor = this.veiculoCarregado.Cor.IdCor;
                foreach (Cor item in cmbCor.Items)
                    if (item.IdCor == idCor)
                    {
                        cmbCor.SelectedItem = item;
                        break;
                    }
            }
        }

        public void SelecionaCombustivel()
        {
            if (this.veiculoCarregado != null)
            {
                int idCombustivel = this.veiculoCarregado.Combustivel.IdCombustivel;
                foreach (Combustivel item in cmbCombustivel.Items)
                    if (item.IdCombustivel == idCombustivel)
                    {
                        cmbCombustivel.SelectedItem = item;
                        break;
                    }
            }
        }

        private void DesabilitaCampos()
        {
            cmbMarca.Enabled = false;
            cmbModelo.Enabled = false;
            cmbCombustivel.Enabled = false;
            txtPlaca.Enabled = false;
            cmbCategoria.Enabled = false;
            cmbCor.Enabled = false;
            txtAnoFabricacao.Enabled = false;
            txtAnoModelo.Enabled = false;
            txtKmInicial.Enabled = false;
            txtRenavam.Enabled = false;
        }

        private void HabilitaCampos()
        {
            cmbMarca.Enabled = !false;
            cmbModelo.Enabled = !false;
            cmbCombustivel.Enabled = !false;
            txtPlaca.Enabled = !false;
            cmbCategoria.Enabled = !false;
            cmbCor.Enabled = !false;
            txtAnoFabricacao.Enabled = !false;
            txtAnoModelo.Enabled = !false;
            txtKmInicial.Enabled = !false;
            txtRenavam.Enabled = !false;
            cmbMarca.Focus();
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
            cmbMarca.SelectedItem = null;
            cmbModelo.SelectedItem = null;
            cmbCombustivel.SelectedItem = null;
            txtPlaca.Text = String.Empty;
            cmbCategoria.SelectedItem = null;
            cmbCor.SelectedItem = null;
            txtAnoFabricacao.Text = String.Empty;
            txtAnoModelo.Text = String.Empty;
            txtKmInicial.Text = String.Empty;
            txtRenavam.Text = String.Empty;
        }

        private void CarregaMarcas()
        {
            cmbMarca.DisplayMember = "marca";
            cmbMarca.DataSource = new MarcaDAO().GetListaMarcas();
        }

        private void CarregaCores()
        {
            cmbCor.DisplayMember = "cor";
            cmbCor.DataSource = new CorDAO().GetListaCores();
        }

        private void CarregaCombustiveis()
        {
            cmbCombustivel.DisplayMember = "combustivel";
            cmbCombustivel.DataSource = new CombustivelDAO().GetListaCombustiveis();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            FrmMarca frmMarca = new FrmMarca();
            frmMarca.ShowDialog();
            CarregaMarcas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.editando = true;
            DesabilitaBotoes();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            FrmCor frmCor = new FrmCor();
            frmCor.ShowDialog();
            CarregaCores();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FrmModelo frmModelo = new FrmModelo();
            frmModelo.ShowDialog();
            CarregaMarcas();
        }

        private void CarregaModelos()
        {
            cmbModelo.SelectedItem = null;
            if (cmbMarca.SelectedItem != null)
            {
                cmbModelo.DisplayMember = "modelo";
                cmbModelo.DataSource = new ModeloDAO().GetListaModelos(((Marca)cmbMarca.SelectedItem).IdMarca);
            }
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaModelos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedItem != null && cmbModelo.SelectedItem != null && cmbCombustivel.SelectedItem != null && 
                cmbCor.SelectedItem != null && !String.IsNullOrWhiteSpace(txtAnoFabricacao.Text.Trim()) && !String.IsNullOrWhiteSpace(txtAnoModelo.Text.Trim()) && 
                !String.IsNullOrWhiteSpace(txtKmInicial.Value.ToString().Trim()) && cmbCategoria.SelectedItem != null && !String.IsNullOrWhiteSpace(txtPlaca.Text.Trim()) && 
                !String.IsNullOrWhiteSpace(txtRenavam.Text.Trim()))
            {
                if (Validacao.ValidaPlacaVeiculo(txtPlaca.Text.Trim()) && Validacao.ValidaRenavam(txtRenavam.Text.Trim()))
                {
                    if (this.veiculoCarregado == null)
                        this.veiculoCarregado = new Veiculo();

                    this.veiculoCarregado.Modelo = (Modelo) cmbModelo.SelectedItem;
                    this.veiculoCarregado.Combustivel = (Combustivel) cmbCombustivel.SelectedItem;
                    this.veiculoCarregado.Cor = (Cor) cmbCor.SelectedItem;
                    this.veiculoCarregado.AnoFabricacao = txtAnoFabricacao.Value;
                    this.veiculoCarregado.AnoModelo = txtAnoModelo.Value;
                    this.veiculoCarregado.KmInicial = Convert.ToInt32(txtKmInicial.Value);
                    this.veiculoCarregado.Placa = txtPlaca.Text.Trim().ToUpper();
                    this.veiculoCarregado.CategoriaExigida = cmbCategoria.Text.Trim();
                    this.veiculoCarregado.Renavam = txtRenavam.Text.Trim();

                    VeiculoDAO dao = new VeiculoDAO();
                        if (!this.editando)
                            dao.AdicionaVeiculo(this.veiculoCarregado);
                        else dao.AlteraVeiculo(this.veiculoCarregado);
                    this.Close();
                } else MessageBox.Show("Não foi possível realizar a operação.\nA PLACA ou RENAVAM digitado é INVÁLIDO!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações deste VEÍCULO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaVeiculo();
                }
            }
            else this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você realmente quer excluir este VEÍCULO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                VeiculoDAO dao = new VeiculoDAO();
                dao.DeletaVeiculo(this.veiculoCarregado.IdVeiculo);
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FrmCombustivel frmCombustivel = new FrmCombustivel();
            frmCombustivel.ShowDialog();
            CarregaCombustiveis();
        }

        private void txtRenavam_TextChanged(object sender, EventArgs e)
        {
            if (!Validacao.ValidaRenavam(txtRenavam.Text))
                txtRenavam.ForeColor = Color.Red;
            else txtRenavam.ForeColor = Color.Green;
        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {
            if (!Validacao.ValidaPlacaVeiculo(txtPlaca.Text))
                txtPlaca.ForeColor = Color.Red;
            else txtPlaca.ForeColor = Color.Green;
        }
    }
}
