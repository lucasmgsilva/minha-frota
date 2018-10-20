using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace Trinity.View.Reports
{
    public partial class FrmRelatorioManutencao : Form
    {
        public FrmRelatorioManutencao()
        {
            InitializeComponent();
        }

        private void FrmRelatorioManutencao_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
        }

    }
}
