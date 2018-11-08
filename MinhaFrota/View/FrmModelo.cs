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
    public partial class FrmModelo : Form
    {
        List<Modelo> listaModelos;
        bool editando;
        Modelo modeloCarregado;

        public FrmModelo()
        {
            InitializeComponent();
            this.editando = false;
            LimpaCampos();
        }

        private void CarregaListaMarcas()
        {
            cmbMarca.SelectedItem = null;
            cmbMarca.DisplayMember = "marca";
            cmbMarca.DataSource = new MarcaDAO().GetListaMarcas();
        }

        private void DesabilitaCampos()
        {
            cmbMarca.Enabled = !false;
            txtModelo.Enabled = false;
        }

        private void HabilitaCampos()
        {
            cmbMarca.Enabled = false;
            txtModelo.Enabled = !false;
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
            txtModelo.Text = String.Empty;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedItem != null && !String.IsNullOrWhiteSpace(txtModelo.Text.Trim()))
            {
                if (this.modeloCarregado == null)
                    this.modeloCarregado = new Modelo();

                this.modeloCarregado.Marca = (Marca)cmbMarca.SelectedItem;
                this.modeloCarregado.modelo = txtModelo.Text.Trim();
                

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
                    CarregaModelos();
                }
            }
            else this.Close();
        }

        private void FrmModelo_Load(object sender, EventArgs e)
        {
            CarregaListaMarcas();
        }

        public void CarregaListaModelos()
        {
            if (cmbMarca.SelectedItem != null)
            {
                dgvModelos.AutoGenerateColumns = false;
                listaModelos = new ModeloDAO().GetListaModelos(((Marca) cmbMarca.SelectedItem).IdMarca);
                dgvModelos.DataSource = new BindingList<Modelo>(listaModelos);
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
                    CarregaModelos();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum MODELO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CarregaModelos()
        {
            txtModelo.Text = modeloCarregado.modelo;

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if(cmbMarca.SelectedItem != null)
            {
                this.editando = false;
                LimpaCampos();
                DesabilitaBotoes();
            } else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MARCA selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            FrmMarca marca = new FrmMarca();
            marca.ShowDialog();
            CarregaListaMarcas();
        }
    }
}