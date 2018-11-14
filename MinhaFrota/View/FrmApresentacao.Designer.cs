namespace Trinity
{
    partial class FrmApresentacao
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApresentacao));
            this.pgbCarregamento = new System.Windows.Forms.ProgressBar();
            this.relogio = new System.Windows.Forms.Timer(this.components);
            this.lblGestaoDeVeiculos = new System.Windows.Forms.Label();
            this.lblMinhaFrota = new System.Windows.Forms.Label();
            this.lblOrientador = new System.Windows.Forms.Label();
            this.lblOrientando = new System.Windows.Forms.Label();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIFSP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pgbCarregamento
            // 
            this.pgbCarregamento.Location = new System.Drawing.Point(12, 386);
            this.pgbCarregamento.Name = "pgbCarregamento";
            this.pgbCarregamento.Size = new System.Drawing.Size(786, 23);
            this.pgbCarregamento.TabIndex = 0;
            this.pgbCarregamento.Visible = false;
            // 
            // relogio
            // 
            this.relogio.Enabled = true;
            this.relogio.Interval = 25;
            this.relogio.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblGestaoDeVeiculos
            // 
            this.lblGestaoDeVeiculos.AutoSize = true;
            this.lblGestaoDeVeiculos.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestaoDeVeiculos.ForeColor = System.Drawing.Color.White;
            this.lblGestaoDeVeiculos.Location = new System.Drawing.Point(44, 97);
            this.lblGestaoDeVeiculos.Name = "lblGestaoDeVeiculos";
            this.lblGestaoDeVeiculos.Size = new System.Drawing.Size(220, 27);
            this.lblGestaoDeVeiculos.TabIndex = 1;
            this.lblGestaoDeVeiculos.Text = "Gestão de Veículos";
            // 
            // lblMinhaFrota
            // 
            this.lblMinhaFrota.AutoSize = true;
            this.lblMinhaFrota.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinhaFrota.ForeColor = System.Drawing.Color.White;
            this.lblMinhaFrota.Location = new System.Drawing.Point(42, 60);
            this.lblMinhaFrota.Name = "lblMinhaFrota";
            this.lblMinhaFrota.Size = new System.Drawing.Size(200, 37);
            this.lblMinhaFrota.TabIndex = 2;
            this.lblMinhaFrota.Text = "Minha Frota";
            // 
            // lblOrientador
            // 
            this.lblOrientador.AutoSize = true;
            this.lblOrientador.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrientador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            this.lblOrientador.Location = new System.Drawing.Point(46, 306);
            this.lblOrientador.Name = "lblOrientador";
            this.lblOrientador.Size = new System.Drawing.Size(226, 18);
            this.lblOrientador.TabIndex = 3;
            this.lblOrientador.Text = "Prof. Me. Eros Schettini Roman";
            // 
            // lblOrientando
            // 
            this.lblOrientando.AutoSize = true;
            this.lblOrientando.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrientando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            this.lblOrientando.Location = new System.Drawing.Point(46, 332);
            this.lblOrientando.Name = "lblOrientando";
            this.lblOrientando.Size = new System.Drawing.Size(228, 18);
            this.lblOrientando.TabIndex = 4;
            this.lblOrientando.Text = "Lucas Matheus Gomes da Silva";
            // 
            // pctLogo
            // 
            this.pctLogo.Image = global::Trinity.Properties.Resources.logo;
            this.pctLogo.Location = new System.Drawing.Point(331, 165);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(149, 106);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctLogo.TabIndex = 5;
            this.pctLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            this.label1.Location = new System.Drawing.Point(362, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 6;
            // 
            // lblIFSP
            // 
            this.lblIFSP.AutoSize = true;
            this.lblIFSP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIFSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            this.lblIFSP.Location = new System.Drawing.Point(46, 358);
            this.lblIFSP.Name = "lblIFSP";
            this.lblIFSP.Size = new System.Drawing.Size(619, 18);
            this.lblIFSP.TabIndex = 7;
            this.lblIFSP.Text = "Instituto Federal de Educação, Ciência e Tecnologia de São Paulo - Campus Catandu" +
    "va";
            // 
            // FrmApresentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(810, 421);
            this.Controls.Add(this.lblIFSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.lblOrientando);
            this.Controls.Add(this.lblOrientador);
            this.Controls.Add(this.lblMinhaFrota);
            this.Controls.Add(this.lblGestaoDeVeiculos);
            this.Controls.Add(this.pgbCarregamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmApresentacao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apresentação do Sistema";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbCarregamento;
        private System.Windows.Forms.Timer relogio;
        private System.Windows.Forms.Label lblGestaoDeVeiculos;
        private System.Windows.Forms.Label lblMinhaFrota;
        private System.Windows.Forms.Label lblOrientador;
        private System.Windows.Forms.Label lblOrientando;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIFSP;
    }
}