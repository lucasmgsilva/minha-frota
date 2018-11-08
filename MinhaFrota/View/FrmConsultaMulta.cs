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
    public partial class FrmConsultaMulta : Form
    {
        public FrmConsultaMulta()
        {
            InitializeComponent();
        }

        List<Multa> listaMultas;

        private void FrmConsultaMulta_Load(object sender, EventArgs e)
        {
            CarregaListaMultas();
        }

        public void CarregaListaMultas()
        {
            dgvMultas.AutoGenerateColumns = false;
            listaMultas = new MultaDAO().GetListaMultas();
            dgvMultas.DataSource = new BindingList<Multa>(listaMultas);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmMulta frmMulta = new FrmMulta(null);
            frmMulta.ShowDialog();
            CarregaListaMultas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMultas.RowCount != 0)
            {
                if (dgvMultas.CurrentRow.Selected)
                {
                    int idMulta = Convert.ToInt32(dgvMultas.CurrentRow.Cells["idMulta"].Value);
                    FrmMulta frmMulta = new FrmMulta(this.listaMultas.Find(f => f.IdMulta == idMulta));
                    frmMulta.ShowDialog();
                    CarregaListaMultas();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MULTA selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MULTA cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvMultas.RowCount != 0)
            {
                if (dgvMultas.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir esta MULTA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idMulta = Convert.ToInt32(dgvMultas.CurrentRow.Cells["idMulta"].Value);
                        MultaDAO dao = new MultaDAO();
                        dao.DeletaMulta(idMulta);
                        CarregaListaMultas();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MULTA selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma MULTA cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if ((dgvMultas.Rows[e.RowIndex].DataBoundItem != null) && (dgvMultas.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvMultas.Rows[e.RowIndex].DataBoundItem, dgvMultas.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvMultas.AutoGenerateColumns = false;
            listaMultas = new MultaDAO().BuscaListaMultas(txtPalavrasChave.Text);
            dgvMultas.DataSource = new BindingList<Multa>(listaMultas);
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
