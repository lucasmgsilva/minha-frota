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
    public partial class FrmConsultaMotorista : Form
    {
        public FrmConsultaMotorista()
        {
            InitializeComponent();
        }

        List<Motorista> listaMotoristas;

        private void FrmConsultaCliente_Load(object sender, EventArgs e)
        {
            CarregaListaMotoristas();
        }

        public void CarregaListaMotoristas()
        {
            dgvMotoristas.AutoGenerateColumns = false;
            listaMotoristas = new MotoristaDAO().GetListaMotoristas();
            dgvMotoristas.DataSource = new BindingList<Motorista>(listaMotoristas);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmMotorista telaMotorista = new FrmMotorista(null);
            telaMotorista.ShowDialog();
            CarregaListaMotoristas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMotoristas.RowCount != 0)
            {
                if (dgvMotoristas.CurrentRow.Selected)
                {
                    int idMotorista = Convert.ToInt32(dgvMotoristas.CurrentRow.Cells["idMotorista"].Value);
                    FrmMotorista telaCliente = new FrmMotorista(this.listaMotoristas.Find(f => f.IdMotorista == idMotorista));
                    telaCliente.ShowDialog();
                    CarregaListaMotoristas();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum MOTORISTA selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum MOTORISTA cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvMotoristas.RowCount != 0)
            {
                if (dgvMotoristas.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir este MOTORISTA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idMotorista = Convert.ToInt32(dgvMotoristas.CurrentRow.Cells["idMotorista"].Value);
                        MotoristaDAO dao = new MotoristaDAO();
                        dao.DeletaMotorista(idMotorista);
                        CarregaListaMotoristas();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum MOTORISTA selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum MOTORISTA cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if ((dgvMotoristas.Rows[e.RowIndex].DataBoundItem != null) && (dgvMotoristas.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvMotoristas.Rows[e.RowIndex].DataBoundItem, dgvMotoristas.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvMotoristas.AutoGenerateColumns = false;
            listaMotoristas = new MotoristaDAO().BuscaListaMotoristas(txtPalavrasChave.Text);
            dgvMotoristas.DataSource = new BindingList<Motorista>(listaMotoristas);
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
