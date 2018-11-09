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
    public partial class FrmConsultaManutencao : Form
    {
        public FrmConsultaManutencao()
        {
            InitializeComponent();
        }

        List<Manutencao> listaManutencoes;

        private void FrmConsultaCliente_Load(object sender, EventArgs e)
        {
            CarregaListaManutencoes();
            txtPalavrasChave.Focus();
        }

        public void CarregaListaManutencoes()
        {
            dgvManutencoes.AutoGenerateColumns = false;
            listaManutencoes = new ManutencaoDAO().GetListaManutencao();
            dgvManutencoes.DataSource = new BindingList<Manutencao>(listaManutencoes);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmManutencao frmManutencao = new FrmManutencao(null);
            frmManutencao.ShowDialog();
            CarregaListaManutencoes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvManutencoes.RowCount != 0)
            {
                if (dgvManutencoes.CurrentRow.Selected)
                {
                    int idManutencao = Convert.ToInt32(dgvManutencoes.CurrentRow.Cells["idManutencao"].Value);
                    FrmManutencao frmManutencao = new FrmManutencao(this.listaManutencoes.Find(f => f.IdManutencao == idManutencao));
                    frmManutencao.ShowDialog();
                    CarregaListaManutencoes();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MANUTENÇÃO selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MANUTENÇÃO cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvManutencoes.RowCount != 0)
            {
                if (dgvManutencoes.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir esta MANUTENÇÃO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idManutencao = Convert.ToInt32(dgvManutencoes.CurrentRow.Cells["idManutencao"].Value);
                        ManutencaoDAO dao = new ManutencaoDAO();
                        dao.DeletaManutencao(idManutencao);
                        CarregaListaManutencoes();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MANUTENÇÃO selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MANUTENÇÃO cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if ((dgvManutencoes.Rows[e.RowIndex].DataBoundItem != null) && (dgvManutencoes.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvManutencoes.Rows[e.RowIndex].DataBoundItem, dgvManutencoes.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvManutencoes.AutoGenerateColumns = false;
            listaManutencoes = new ManutencaoDAO().BuscaListaManutencao(txtPalavrasChave.Text);
            dgvManutencoes.DataSource = new BindingList<Manutencao>(listaManutencoes);
        }

        private void txtPalavrasChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }
    }
}
