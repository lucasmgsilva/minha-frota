namespace Trinity
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblRazaoSocial = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnPrincipal = new System.Windows.Forms.MenuStrip();
            this.minhaEmpresaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.motoristasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.veiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viagensToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abastecimentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manutencaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trocaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreOSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mnPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.mnPrincipal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 573);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(130)))));
            this.panel2.Controls.Add(this.lblRazaoSocial);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(3, 507);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(989, 63);
            this.panel2.TabIndex = 1;
            // 
            // lblRazaoSocial
            // 
            this.lblRazaoSocial.AutoSize = true;
            this.lblRazaoSocial.BackColor = System.Drawing.Color.Transparent;
            this.lblRazaoSocial.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazaoSocial.Location = new System.Drawing.Point(33, 38);
            this.lblRazaoSocial.Name = "lblRazaoSocial";
            this.lblRazaoSocial.Size = new System.Drawing.Size(106, 20);
            this.lblRazaoSocial.TabIndex = 1;
            this.lblRazaoSocial.Text = "RAZÃO SOCIAL";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Trinity.Properties.Resources.empresa_32px;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(9, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(33, 7);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(68, 20);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "USUÁRIO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Trinity.Properties.Resources.usuario_32px;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(9, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // mnPrincipal
            // 
            this.mnPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minhaEmpresaToolStripMenuItem1,
            this.usuariosToolStripMenuItem1,
            this.motoristasToolStripMenuItem1,
            this.veiculosToolStripMenuItem,
            this.viagensToolStripMenuItem1,
            this.abastecimentosToolStripMenuItem,
            this.multasToolStripMenuItem1,
            this.manutencaoToolStripMenuItem,
            this.trocaUsuarioToolStripMenuItem,
            this.sobreOSistemaToolStripMenuItem,
            this.sAIRToolStripMenuItem});
            this.mnPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnPrincipal.Name = "mnPrincipal";
            this.mnPrincipal.Size = new System.Drawing.Size(995, 55);
            this.mnPrincipal.TabIndex = 0;
            this.mnPrincipal.Text = "menuStrip2";
            // 
            // minhaEmpresaToolStripMenuItem1
            // 
            this.minhaEmpresaToolStripMenuItem1.Enabled = false;
            this.minhaEmpresaToolStripMenuItem1.Image = global::Trinity.Properties.Resources.empresa_32px;
            this.minhaEmpresaToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.minhaEmpresaToolStripMenuItem1.Name = "minhaEmpresaToolStripMenuItem1";
            this.minhaEmpresaToolStripMenuItem1.Size = new System.Drawing.Size(113, 51);
            this.minhaEmpresaToolStripMenuItem1.Text = "MINHA EMPRESA";
            this.minhaEmpresaToolStripMenuItem1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.minhaEmpresaToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.minhaEmpresaToolStripMenuItem1.Click += new System.EventHandler(this.minhaEmpresaToolStripMenuItem1_Click);
            // 
            // usuariosToolStripMenuItem1
            // 
            this.usuariosToolStripMenuItem1.Enabled = false;
            this.usuariosToolStripMenuItem1.Image = global::Trinity.Properties.Resources.usuario_32px;
            this.usuariosToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usuariosToolStripMenuItem1.Name = "usuariosToolStripMenuItem1";
            this.usuariosToolStripMenuItem1.Size = new System.Drawing.Size(74, 51);
            this.usuariosToolStripMenuItem1.Text = "USUÁRIOS";
            this.usuariosToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.usuariosToolStripMenuItem1.Click += new System.EventHandler(this.usuariosToolStripMenuItem1_Click);
            // 
            // motoristasToolStripMenuItem1
            // 
            this.motoristasToolStripMenuItem1.Enabled = false;
            this.motoristasToolStripMenuItem1.Image = global::Trinity.Properties.Resources.motorista_32px;
            this.motoristasToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.motoristasToolStripMenuItem1.Name = "motoristasToolStripMenuItem1";
            this.motoristasToolStripMenuItem1.Size = new System.Drawing.Size(89, 51);
            this.motoristasToolStripMenuItem1.Text = "MOTORISTAS";
            this.motoristasToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.motoristasToolStripMenuItem1.Click += new System.EventHandler(this.motoristasToolStripMenuItem1_Click);
            // 
            // veiculosToolStripMenuItem
            // 
            this.veiculosToolStripMenuItem.Enabled = false;
            this.veiculosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("veiculosToolStripMenuItem.Image")));
            this.veiculosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.veiculosToolStripMenuItem.Name = "veiculosToolStripMenuItem";
            this.veiculosToolStripMenuItem.Size = new System.Drawing.Size(72, 51);
            this.veiculosToolStripMenuItem.Text = "VEÍCULOS";
            this.veiculosToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.veiculosToolStripMenuItem.Click += new System.EventHandler(this.vEÍCULOSToolStripMenuItem_Click);
            // 
            // viagensToolStripMenuItem1
            // 
            this.viagensToolStripMenuItem1.Enabled = false;
            this.viagensToolStripMenuItem1.Image = global::Trinity.Properties.Resources.viagem_32px;
            this.viagensToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viagensToolStripMenuItem1.Name = "viagensToolStripMenuItem1";
            this.viagensToolStripMenuItem1.Size = new System.Drawing.Size(66, 51);
            this.viagensToolStripMenuItem1.Text = "VIAGENS";
            this.viagensToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.viagensToolStripMenuItem1.Click += new System.EventHandler(this.viagensToolStripMenuItem1_Click);
            // 
            // abastecimentosToolStripMenuItem
            // 
            this.abastecimentosToolStripMenuItem.Enabled = false;
            this.abastecimentosToolStripMenuItem.Image = global::Trinity.Properties.Resources.abastecimento_32px;
            this.abastecimentosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.abastecimentosToolStripMenuItem.Name = "abastecimentosToolStripMenuItem";
            this.abastecimentosToolStripMenuItem.Size = new System.Drawing.Size(119, 51);
            this.abastecimentosToolStripMenuItem.Text = "ABASTECIMENTOS";
            this.abastecimentosToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.abastecimentosToolStripMenuItem.Click += new System.EventHandler(this.abastecimentosToolStripMenuItem_Click);
            // 
            // manutencaoToolStripMenuItem
            // 
            this.manutencaoToolStripMenuItem.Enabled = false;
            this.manutencaoToolStripMenuItem.Image = global::Trinity.Properties.Resources.manutencao_32px;
            this.manutencaoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manutencaoToolStripMenuItem.Name = "manutencaoToolStripMenuItem";
            this.manutencaoToolStripMenuItem.Size = new System.Drawing.Size(106, 51);
            this.manutencaoToolStripMenuItem.Text = "MANUTENÇÕES";
            this.manutencaoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.manutencaoToolStripMenuItem.Click += new System.EventHandler(this.manutencoesToolStripMenuItem_Click);
            // 
            // multasToolStripMenuItem1
            // 
            this.multasToolStripMenuItem1.Enabled = false;
            this.multasToolStripMenuItem1.Image = global::Trinity.Properties.Resources.multa_32px;
            this.multasToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.multasToolStripMenuItem1.Name = "multasToolStripMenuItem1";
            this.multasToolStripMenuItem1.Size = new System.Drawing.Size(63, 51);
            this.multasToolStripMenuItem1.Text = "MULTAS";
            this.multasToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.multasToolStripMenuItem1.Click += new System.EventHandler(this.multasToolStripMenuItem1_Click);
            // 
            // trocaUsuarioToolStripMenuItem
            // 
            this.trocaUsuarioToolStripMenuItem.Image = global::Trinity.Properties.Resources.trocarUsuario_32px;
            this.trocaUsuarioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.trocaUsuarioToolStripMenuItem.Name = "trocaUsuarioToolStripMenuItem";
            this.trocaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(117, 51);
            this.trocaUsuarioToolStripMenuItem.Text = "TROCAR USUÁRIO";
            this.trocaUsuarioToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.trocaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.trocaUsuarioToolStripMenuItem_Click);
            // 
            // sobreOSistemaToolStripMenuItem
            // 
            this.sobreOSistemaToolStripMenuItem.Image = global::Trinity.Properties.Resources.sobre_32px;
            this.sobreOSistemaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sobreOSistemaToolStripMenuItem.Name = "sobreOSistemaToolStripMenuItem";
            this.sobreOSistemaToolStripMenuItem.Size = new System.Drawing.Size(116, 51);
            this.sobreOSistemaToolStripMenuItem.Text = "SOBRE O SISTEMA";
            this.sobreOSistemaToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sobreOSistemaToolStripMenuItem.Click += new System.EventHandler(this.sobreOSistemaToolStripMenuItem_Click);
            // 
            // sAIRToolStripMenuItem
            // 
            this.sAIRToolStripMenuItem.Image = global::Trinity.Properties.Resources.sair_32px;
            this.sAIRToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sAIRToolStripMenuItem.Name = "sAIRToolStripMenuItem";
            this.sAIRToolStripMenuItem.Size = new System.Drawing.Size(113, 51);
            this.sAIRToolStripMenuItem.Text = "SAIR DO SISTEMA";
            this.sAIRToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sAIRToolStripMenuItem.Click += new System.EventHandler(this.sAIRToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 573);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1011, 612);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minha Frota: Gestão de Veículos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mnPrincipal.ResumeLayout(false);
            this.mnPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblRazaoSocial;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.MenuStrip mnPrincipal;
        private System.Windows.Forms.ToolStripMenuItem minhaEmpresaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem motoristasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trocaUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreOSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAIRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manutencaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abastecimentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viagensToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem multasToolStripMenuItem1;
    }
}