using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trinity
{
    public partial class FrmApresentacao : Form
    {
        public FrmApresentacao()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pgbCarregamento.Value < 100)
                pgbCarregamento.Value++;
            else
            {
                relogio.Enabled = false;
                this.Hide();
                FrmAcesso acesso = new FrmAcesso();
                acesso.Show();
            }
        }

        private void pctMatrix_Click(object sender, EventArgs e)
        {

        }
    }
}
