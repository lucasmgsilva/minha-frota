using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Trinity.Model.Bean;
using Trinity.Model.DAO;

namespace Trinity.View
{
    public partial class FrmConsultaViagem: Form
    {
        List<Viagem> listaViagens;

        public FrmConsultaViagem ()
        {
            InitializeComponent();
        }

        private void FrmConsultaViagem_Load(object sender, EventArgs e)
        {
            CarregaListaViagens();
            txtPalavraChave.Focus();
        }

        public void CarregaListaViagens()
        {
            dgvViagens.AutoGenerateColumns = false;
            listaViagens = new ViagemDAO().GetListaViagem();
            dgvViagens.DataSource = new BindingList<Viagem>(listaViagens);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvViagens.RowCount != 0)
            {
                if (dgvViagens.CurrentRow.Selected)
                {
                    int idViagem = Convert.ToInt32(dgvViagens.CurrentRow.Cells["idViagem"].Value.ToString());
                    FrmViagem telaViagem = new FrmViagem(this.listaViagens.Find(u => u.IdViagem == idViagem));
                    telaViagem.ShowDialog();
                    CarregaListaViagens();
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma VIAGEM selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma VIAGEM cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmViagem telaViagem = new FrmViagem(null);
            telaViagem.ShowDialog();
            CarregaListaViagens();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvViagens.RowCount != 0)
            {
                if (dgvViagens.CurrentRow.Selected)
                {
                    if (MessageBox.Show("Você realmente quer excluir esta VIAGEM?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idViagem = Convert.ToInt32(dgvViagens.CurrentRow.Cells["idViagem"].Value.ToString());
                        ViagemDAO dao = new ViagemDAO();
                        dao.DeletaViagem(idViagem);
                        CarregaListaViagens();
                    }
                }
                else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma VIAGEM selecionada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show("Não foi possível realizar a operação.\nNão há nenhuma VIAGEM cadastrada!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if ((dgvViagens.Rows[e.RowIndex].DataBoundItem != null) && (dgvViagens.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvViagens.Rows[e.RowIndex].DataBoundItem, dgvViagens.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvViagens.AutoGenerateColumns = false;
            listaViagens = new ViagemDAO().BuscaListaViagens(txtPalavraChave.Text);
            dgvViagens.DataSource = new BindingList<Viagem>(listaViagens);
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }
    }
}
