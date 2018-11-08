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
    public partial class FrmCor : Form
    {
        List<Cor> listaCores;
        bool editando;
        Cor corCarregada;

        public FrmCor()
        {
            InitializeComponent();
            this.editando = false;
            LimpaCampos();
        }

        private void DesabilitaCampos()
        {
            txtCor.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtCor.Enabled = !false;
            txtCor.Focus();
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
            txtCor.Text = String.Empty;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtCor.Text.Trim()))
            {
                if (this.corCarregada == null)
                    this.corCarregada = new Cor();

                this.corCarregada.cor = txtCor.Text.Trim();

                CorDAO dao = new CorDAO();
                if (!this.editando)
                    dao.AdicionaCor(this.corCarregada);
                else dao.AlteraCor(this.corCarregada);
                CarregaListaCores();
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações desta COR?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaCor();
                }
            }
            else this.Close();
        }

        private void FmCor_Load(object sender, EventArgs e)
        {
            CarregaListaCores();
        }

        public void CarregaListaCores()
        {
            dgvCores.AutoGenerateColumns = false;
            listaCores = new CorDAO().GetListaCores();
            dgvCores.DataSource = new BindingList<Cor>(listaCores);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCores.RowCount != 0)
            {
                if (dgvCores.CurrentRow.Selected)
                {
                    this.editando = true;
                    DesabilitaBotoes();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma COR selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma COR cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvCores_SelectionChanged(object sender, EventArgs e)
        {
            LimpaCampos();
            if (dgvCores.RowCount != 0)
            {
                if (dgvCores.CurrentRow.Selected)
                {
                    this.editando = false;
                    int idCor = Convert.ToInt32(dgvCores.CurrentRow.Cells["idCor"].Value.ToString());
                    this.corCarregada = this.listaCores.Find(u => u.IdCor == idCor);
                    CarregaCor();
                }
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma COR cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CarregaCor()
        {
            txtCor.Text = corCarregada.cor;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.editando = false;
            LimpaCampos();
            DesabilitaBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvCores.RowCount != 0)
            {
                if (dgvCores.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir esta COR?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CorDAO dao = new CorDAO();
                        dao.DeletaCor(this.corCarregada.IdCor);
                        CarregaListaCores();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma COR selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma COR cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
