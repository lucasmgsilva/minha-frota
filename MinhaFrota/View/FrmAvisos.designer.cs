namespace Trinity.View
{
    partial class FrmAvisos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAvisos));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMotoristas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMultas = new System.Windows.Forms.DataGridView();
            this.idMulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMotorista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotoristas)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMultas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMotoristas);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(872, 205);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de CNH\'s - Vencimento em 30 dias";
            // 
            // dgvMotoristas
            // 
            this.dgvMotoristas.AllowUserToAddRows = false;
            this.dgvMotoristas.AllowUserToDeleteRows = false;
            this.dgvMotoristas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvMotoristas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMotoristas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMotoristas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMotorista,
            this.Nome,
            this.Cpf,
            this.CNH,
            this.categoria});
            this.dgvMotoristas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMotoristas.Location = new System.Drawing.Point(3, 22);
            this.dgvMotoristas.MultiSelect = false;
            this.dgvMotoristas.Name = "dgvMotoristas";
            this.dgvMotoristas.ReadOnly = true;
            this.dgvMotoristas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMotoristas.Size = new System.Drawing.Size(866, 180);
            this.dgvMotoristas.TabIndex = 1;
            this.dgvMotoristas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(357, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "PAINEL DE AVISOS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 47);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMultas);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 205);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Multas - Vencimento em 30 dias";
            // 
            // dgvMultas
            // 
            this.dgvMultas.AllowUserToAddRows = false;
            this.dgvMultas.AllowUserToDeleteRows = false;
            this.dgvMultas.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvMultas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMultas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMulta,
            this.placa,
            this.dataGridViewTextBoxColumn1,
            this.valor,
            this.dataVencimento});
            this.dgvMultas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMultas.Location = new System.Drawing.Point(3, 22);
            this.dgvMultas.MultiSelect = false;
            this.dgvMultas.Name = "dgvMultas";
            this.dgvMultas.ReadOnly = true;
            this.dgvMultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMultas.Size = new System.Drawing.Size(866, 180);
            this.dgvMultas.TabIndex = 1;
            this.dgvMultas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormattingMultas);
            // 
            // idMulta
            // 
            this.idMulta.DataPropertyName = "IdMulta";
            dataGridViewCellStyle5.Format = "000000";
            this.idMulta.DefaultCellStyle = dataGridViewCellStyle5;
            this.idMulta.HeaderText = "ID";
            this.idMulta.Name = "idMulta";
            this.idMulta.ReadOnly = true;
            // 
            // placa
            // 
            this.placa.DataPropertyName = "Veiculo.Placa";
            this.placa.HeaderText = "VEÍCULO";
            this.placa.Name = "placa";
            this.placa.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Motorista.Nome";
            this.dataGridViewTextBoxColumn1.HeaderText = "MOTORISTA";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 405;
            // 
            // valor
            // 
            this.valor.DataPropertyName = "Valor";
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.valor.DefaultCellStyle = dataGridViewCellStyle6;
            this.valor.HeaderText = "VALOR";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            // 
            // dataVencimento
            // 
            this.dataVencimento.DataPropertyName = "DataVencimento";
            this.dataVencimento.HeaderText = "VENCIMENTO";
            this.dataVencimento.Name = "dataVencimento";
            this.dataVencimento.ReadOnly = true;
            this.dataVencimento.Width = 115;
            // 
            // IdMotorista
            // 
            this.IdMotorista.DataPropertyName = "IdMotorista";
            dataGridViewCellStyle2.Format = "000000";
            this.IdMotorista.DefaultCellStyle = dataGridViewCellStyle2;
            this.IdMotorista.HeaderText = "ID";
            this.IdMotorista.Name = "IdMotorista";
            this.IdMotorista.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "NOME";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 375;
            // 
            // Cpf
            // 
            this.Cpf.DataPropertyName = "Cpf";
            this.Cpf.HeaderText = "CPF";
            this.Cpf.Name = "Cpf";
            this.Cpf.ReadOnly = true;
            this.Cpf.Width = 130;
            // 
            // CNH
            // 
            this.CNH.DataPropertyName = "Cnh.NumeroRegistro";
            this.CNH.HeaderText = "CNH";
            this.CNH.Name = "CNH";
            this.CNH.ReadOnly = true;
            // 
            // categoria
            // 
            this.categoria.DataPropertyName = "Cnh.DataValidade";
            dataGridViewCellStyle3.NullValue = null;
            this.categoria.DefaultCellStyle = dataGridViewCellStyle3;
            this.categoria.HeaderText = "VENCIMENTO";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            this.categoria.Width = 115;
            // 
            // FrmAvisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 477);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAvisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Painel de Avisos";
            this.Load += new System.EventHandler(this.FrmAvisos_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotoristas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMotoristas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMotorista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
    }
}