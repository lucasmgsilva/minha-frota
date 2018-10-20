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
            this.lblTrabalhoDeConclusaoDeCurso = new System.Windows.Forms.Label();
            this.lblIFSPCampusCatanduva = new System.Windows.Forms.Label();
            this.pctLogo = new System.Windows.Forms.PictureBox();
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
            this.lblGestaoDeVeiculos.Location = new System.Drawing.Point(44, 89);
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
            this.lblMinhaFrota.Location = new System.Drawing.Point(42, 52);
            this.lblMinhaFrota.Name = "lblMinhaFrota";
            this.lblMinhaFrota.Size = new System.Drawing.Size(200, 37);
            this.lblMinhaFrota.TabIndex = 2;
            this.lblMinhaFrota.Text = "Minha Frota";
            // 
            // lblTrabalhoDeConclusaoDeCurso
            // 
            this.lblTrabalhoDeConclusaoDeCurso.AutoSize = true;
            this.lblTrabalhoDeConclusaoDeCurso.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrabalhoDeConclusaoDeCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            this.lblTrabalhoDeConclusaoDeCurso.Location = new System.Drawing.Point(46, 333);
            this.lblTrabalhoDeConclusaoDeCurso.Name = "lblTrabalhoDeConclusaoDeCurso";
            this.lblTrabalhoDeConclusaoDeCurso.Size = new System.Drawing.Size(236, 18);
            this.lblTrabalhoDeConclusaoDeCurso.TabIndex = 3;
            this.lblTrabalhoDeConclusaoDeCurso.Text = "Trabalho de Conclusão de Curso";
            // 
            // lblIFSPCampusCatanduva
            // 
            this.lblIFSPCampusCatanduva.AutoSize = true;
            this.lblIFSPCampusCatanduva.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIFSPCampusCatanduva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            this.lblIFSPCampusCatanduva.Location = new System.Drawing.Point(46, 359);
            this.lblIFSPCampusCatanduva.Name = "lblIFSPCampusCatanduva";
            this.lblIFSPCampusCatanduva.Size = new System.Drawing.Size(368, 18);
            this.lblIFSPCampusCatanduva.TabIndex = 4;
            this.lblIFSPCampusCatanduva.Text = "Instituto Federal de São Paulo - Campus Catanduva";
            // 
            // pctLogo
            // 
            this.pctLogo.Image = global::Trinity.Properties.Resources.logo;
            this.pctLogo.Location = new System.Drawing.Point(331, 157);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(149, 106);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctLogo.TabIndex = 5;
            this.pctLogo.TabStop = false;
            this.pctLogo.Click += new System.EventHandler(this.pctMatrix_Click);
            // 
            // FrmApresentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(810, 421);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.lblIFSPCampusCatanduva);
            this.Controls.Add(this.lblTrabalhoDeConclusaoDeCurso);
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
        private System.Windows.Forms.Label lblTrabalhoDeConclusaoDeCurso;
        private System.Windows.Forms.Label lblIFSPCampusCatanduva;
        private System.Windows.Forms.PictureBox pctLogo;
    }
}