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
    public partial class FrmConsultaVeiculo : Form
    {
        List<Veiculo> listaVeiculos;

        public FrmConsultaVeiculo()
        {
            InitializeComponent();
        }

        private void FrmConsultaVeiculo_Load(object sender, EventArgs e)
        {
            CarregaListaVeiculos();
        }

        public void CarregaListaVeiculos()
        {
            dgvVeiculos.AutoGenerateColumns = false;
            listaVeiculos = new VeiculoDAO().GetListaVeiculos();
            dgvVeiculos.DataSource = new BindingList<Veiculo>(listaVeiculos);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVeiculos.RowCount != 0)
            {
                if (dgvVeiculos.CurrentRow.Selected)
                {
                    int idVeiculo = Convert.ToInt32(dgvVeiculos.CurrentRow.Cells["idVeiculo"].Value.ToString());
                    FrmVeiculo telaVeiculo = new FrmVeiculo(this.listaVeiculos.Find(u => u.IdVeiculo == idVeiculo));
                    telaVeiculo.ShowDialog();
                    CarregaListaVeiculos();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum VEÍCULO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum VEÍCULO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmVeiculo telaVeiculo = new FrmVeiculo(null);
            telaVeiculo.ShowDialog();
            CarregaListaVeiculos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvVeiculos.RowCount != 0)
            {
                if (dgvVeiculos.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir este VEÍCULO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idVeiculo = Convert.ToInt32(dgvVeiculos.CurrentRow.Cells["idVeiculo"].Value.ToString());
                        VeiculoDAO dao = new VeiculoDAO();
                        dao.DeletaVeiculo(idVeiculo);
                        CarregaListaVeiculos();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum VEÍCULO selecionado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhum VEÍCULO cadastrado!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if ((dgvVeiculos.Rows[e.RowIndex].DataBoundItem != null) && (dgvVeiculos.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvVeiculos.Rows[e.RowIndex].DataBoundItem, dgvVeiculos.Columns[e.ColumnIndex].DataPropertyName);
            }
        }
    }
}
