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
    public partial class FrmAvisos : Form
    {
        public FrmAvisos()
        {
            InitializeComponent();
        }

        List<Motorista> listaMotoristas;
        List<Multa> listaMultas;

        private void FrmAvisos_Load(object sender, EventArgs e)
        {
            CarregaListaMotoristasCnhIraVencer();
            CarregaListaMultasIraVencer();
        }

        public void CarregaListaMotoristasCnhIraVencer()
        {
            dgvMotoristas.AutoGenerateColumns = false;
            listaMotoristas = new MotoristaDAO().GetListaMotoristasCnhIraVencer();
            dgvMotoristas.DataSource = new BindingList<Motorista>(listaMotoristas);
        }

        public void CarregaListaMultasIraVencer()
        {
            dgvMultas.AutoGenerateColumns = false;
            listaMultas = new MultaDAO().GetListaMultasIraVencer();
            dgvMultas.DataSource = new BindingList<Multa>(listaMultas);
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

        private void dgv_CellFormattingMultas(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvMultas.Rows[e.RowIndex].DataBoundItem != null) && (dgvMultas.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvMultas.Rows[e.RowIndex].DataBoundItem, dgvMultas.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void dgvMotoristas_SelectionChanged(object sender, EventArgs e)
        {
            dgvMotoristas.ClearSelection();
        }

        private void dgvMultas_SelectionChanged(object sender, EventArgs e)
        {
            dgvMultas.ClearSelection();
        }
    }
}
