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
using Trinity.View;

namespace Trinity
{
    public partial class FrmPrincipal : Form
    {
        public Usuario UsuarioSessaoAtual { get; set; }

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.UsuarioSessaoAtual = usuario;
            lblUsuario.Text = this.UsuarioSessaoAtual.usuario;
            lblRazaoSocial.Text = this.UsuarioSessaoAtual.Empresa.RazaoSocial;
            HabilitaModulos();
        }

        public void HabilitaModulos()
        { 
                string permissoes = UsuarioSessaoAtual.Cargo.Permissoes;
                for (int i = 0; i < permissoes.Length; i += 2)
                {
                if (permissoes.Substring(i, 2) == "EM")
                    minhaEmpresaToolStripMenuItem1.Enabled = true;
                else if (permissoes.Substring(i, 2) == "US")
                    usuariosToolStripMenuItem1.Enabled = true;
                else if (permissoes.Substring(i, 2) == "MO")
                    motoristasToolStripMenuItem1.Enabled = true;
                else if (permissoes.Substring(i, 2) == "VE")
                    veiculosToolStripMenuItem.Enabled = true;
                else if (permissoes.Substring(i, 2) == "VI")
                    viagensToolStripMenuItem1.Enabled = true;
                else if (permissoes.Substring(i, 2) == "AB")
                    abastecimentosToolStripMenuItem.Enabled = true;
                else if (permissoes.Substring(i, 2) == "MU")
                    multasToolStripMenuItem1.Enabled = true;
                else if (permissoes.Substring(i, 2) == "MA")
                    manutencaoToolStripMenuItem.Enabled = true;
            }
        }

        private void sobreOSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAvisos().ShowDialog();
            FrmSobre telaSobre = new FrmSobre();
            telaSobre.ShowDialog();
        }

        private void trocaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você realmente quer TROCAR DE USUÁRIO?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                FrmAcesso telaAcesso = new FrmAcesso();
                telaAcesso.Show();
            }
        }

        private void minhaEmpresaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmEmpresa telaEmpresa;
            if (UsuarioSessaoAtual != null)
                telaEmpresa = new FrmEmpresa(UsuarioSessaoAtual.Empresa);
            else telaEmpresa = new FrmEmpresa(null);
            telaEmpresa.ShowDialog();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaUsuario telaConsultaUsuario = new FrmConsultaUsuario();
            telaConsultaUsuario.ShowDialog();
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você realmente quer SAIR DO SISTEMA?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void motoristasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaMotorista telaConsultaMotorista = new FrmConsultaMotorista();
            telaConsultaMotorista.ShowDialog();
        }

        private void vEÍCULOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaVeiculo telaConsultaVeiculo = new FrmConsultaVeiculo();
            telaConsultaVeiculo.ShowDialog();
        }

        private void manutencoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaManutencao telaConsultaManutencao = new FrmConsultaManutencao();
            telaConsultaManutencao.ShowDialog();
        }

        private void abastecimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbastecimento telaAbastecimento = new FrmAbastecimento();
            telaAbastecimento.ShowDialog();
        }

        private void viagensToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmViagem telaViagem = new FrmViagem(null);
            telaViagem.ShowDialog();
        }

        private void multasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaMulta telaMulta = new FrmConsultaMulta();
            telaMulta.ShowDialog();
        }
    }
}
