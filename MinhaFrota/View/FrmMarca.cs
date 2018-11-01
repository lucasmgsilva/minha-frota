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
    public partial class FrmMarca : Form
    {
        List<Marca> listaMarcas;
        bool editando;
        Marca marcaCarregada;

        public FrmMarca()
        {
            InitializeComponent();
            this.editando = false;
            LimpaCampos();
        }

        private void DesabilitaCampos()
        {
            txtMarca.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtMarca.Enabled = !false;
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
            txtMarca.Text = String.Empty;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMarca.Text))
            {
                if (this.marcaCarregada == null)
                    this.marcaCarregada = new Marca();

                this.marcaCarregada.marca = txtMarca.Text;

                MarcaDAO dao = new MarcaDAO();
                if (!this.editando)
                    dao.AdicionaMarca(this.marcaCarregada);
                else dao.AlteraMarca(this.marcaCarregada);
                CarregaListaMarcas();
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações desta MARCA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaMarca();
                }
            }
            else this.Close();
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            CarregaListaMarcas();
        }

        public void CarregaListaMarcas()
        {
            dgvMarcas.AutoGenerateColumns = false;
            listaMarcas = new MarcaDAO().GetListaMarcas();
            dgvMarcas.DataSource = new BindingList<Marca>(listaMarcas);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.RowCount != 0)
            {
                if (dgvMarcas.CurrentRow.Selected)
                {
                    this.editando = true;
                    DesabilitaBotoes();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MARCA selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MARCA cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            LimpaCampos();
            if (dgvMarcas.RowCount != 0)
            {
                if (dgvMarcas.CurrentRow.Selected)
                {
                    this.editando = false;
                    int idMarca = Convert.ToInt32(dgvMarcas.CurrentRow.Cells["idMarca"].Value.ToString());
                    this.marcaCarregada = this.listaMarcas.Find(u => u.IdMarca == idMarca);
                    CarregaMarca();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MARCA cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CarregaMarca()
        {
            txtMarca.Text = marcaCarregada.marca;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.editando = false;
            LimpaCampos();
            DesabilitaBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.RowCount != 0)
            {
                if (dgvMarcas.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir esta MARCA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MarcaDAO dao = new MarcaDAO();
                        dao.DeletaMarca(this.marcaCarregada.IdMarca);
                        CarregaListaMarcas();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MARCA selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MARCA cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
