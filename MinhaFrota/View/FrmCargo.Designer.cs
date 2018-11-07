namespace Trinity.View
{
    partial class FrmCargo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCargo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCargos = new System.Windows.Forms.DataGridView();
            this.idCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkViagens = new System.Windows.Forms.CheckBox();
            this.chkManutencoes = new System.Windows.Forms.CheckBox();
            this.chkAbastecimentos = new System.Windows.Forms.CheckBox();
            this.chkVeiculos = new System.Windows.Forms.CheckBox();
            this.chkEmpresas = new System.Windows.Forms.CheckBox();
            this.chkMotoristas = new System.Windows.Forms.CheckBox();
            this.chkUsuarios = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 47);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(182, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTÃO DE CARGOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome do Cargo:";
            // 
            // txtCargo
            // 
            this.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCargo.Location = new System.Drawing.Point(11, 47);
            this.txtCargo.MaxLength = 40;
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(508, 26);
            this.txtCargo.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(142, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 19);
            this.label11.TabIndex = 16;
            this.label11.Text = "*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCargos);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCargo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 398);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do Cargo";
            // 
            // dgvCargos
            // 
            this.dgvCargos.AllowUserToAddRows = false;
            this.dgvCargos.AllowUserToDeleteRows = false;
            this.dgvCargos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvCargos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCargo,
            this.cargo});
            this.dgvCargos.Location = new System.Drawing.Point(11, 238);
            this.dgvCargos.MultiSelect = false;
            this.dgvCargos.Name = "dgvCargos";
            this.dgvCargos.ReadOnly = true;
            this.dgvCargos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargos.Size = new System.Drawing.Size(508, 154);
            this.dgvCargos.TabIndex = 18;
            this.dgvCargos.SelectionChanged += new System.EventHandler(this.dgvcargos_SelectionChanged);
            // 
            // idCargo
            // 
            this.idCargo.DataPropertyName = "IdCargo";
            dataGridViewCellStyle2.Format = "00000";
            dataGridViewCellStyle2.NullValue = null;
            this.idCargo.DefaultCellStyle = dataGridViewCellStyle2;
            this.idCargo.HeaderText = "ID";
            this.idCargo.Name = "idCargo";
            this.idCargo.ReadOnly = true;
            // 
            // cargo
            // 
            this.cargo.DataPropertyName = "Cargo";
            this.cargo.HeaderText = "CARGO";
            this.cargo.Name = "cargo";
            this.cargo.ReadOnly = true;
            this.cargo.Width = 360;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkViagens);
            this.panel2.Controls.Add(this.chkManutencoes);
            this.panel2.Controls.Add(this.chkAbastecimentos);
            this.panel2.Controls.Add(this.chkVeiculos);
            this.panel2.Controls.Add(this.chkEmpresas);
            this.panel2.Controls.Add(this.chkMotoristas);
            this.panel2.Controls.Add(this.chkUsuarios);
            this.panel2.Location = new System.Drawing.Point(11, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(508, 121);
            this.panel2.TabIndex = 1;
            // 
            // chkViagens
            // 
            this.chkViagens.AutoSize = true;
            this.chkViagens.Location = new System.Drawing.Point(229, 10);
            this.chkViagens.Name = "chkViagens";
            this.chkViagens.Size = new System.Drawing.Size(162, 22);
            this.chkViagens.TabIndex = 6;
            this.chkViagens.Text = "Módulo de Viagens";
            this.chkViagens.UseVisualStyleBackColor = true;
            // 
            // chkManutencoes
            // 
            this.chkManutencoes.AutoSize = true;
            this.chkManutencoes.Location = new System.Drawing.Point(229, 66);
            this.chkManutencoes.Name = "chkManutencoes";
            this.chkManutencoes.Size = new System.Drawing.Size(197, 22);
            this.chkManutencoes.TabIndex = 5;
            this.chkManutencoes.Text = "Módulo de Manutenções";
            this.chkManutencoes.UseVisualStyleBackColor = true;
            // 
            // chkAbastecimentos
            // 
            this.chkAbastecimentos.AutoSize = true;
            this.chkAbastecimentos.Location = new System.Drawing.Point(229, 38);
            this.chkAbastecimentos.Name = "chkAbastecimentos";
            this.chkAbastecimentos.Size = new System.Drawing.Size(216, 22);
            this.chkAbastecimentos.TabIndex = 4;
            this.chkAbastecimentos.Text = "Módulo de Abastecimentos";
            this.chkAbastecimentos.UseVisualStyleBackColor = true;
            // 
            // chkVeiculos
            // 
            this.chkVeiculos.AutoSize = true;
            this.chkVeiculos.Location = new System.Drawing.Point(9, 94);
            this.chkVeiculos.Name = "chkVeiculos";
            this.chkVeiculos.Size = new System.Drawing.Size(162, 22);
            this.chkVeiculos.TabIndex = 3;
            this.chkVeiculos.Text = "Módulo de Veículos";
            this.chkVeiculos.UseVisualStyleBackColor = true;
            // 
            // chkEmpresas
            // 
            this.chkEmpresas.AutoSize = true;
            this.chkEmpresas.Location = new System.Drawing.Point(9, 10);
            this.chkEmpresas.Name = "chkEmpresas";
            this.chkEmpresas.Size = new System.Drawing.Size(214, 22);
            this.chkEmpresas.TabIndex = 0;
            this.chkEmpresas.Text = "Módulo de Minha Empresa";
            this.chkEmpresas.UseVisualStyleBackColor = true;
            // 
            // chkMotoristas
            // 
            this.chkMotoristas.AutoSize = true;
            this.chkMotoristas.Location = new System.Drawing.Point(9, 66);
            this.chkMotoristas.Name = "chkMotoristas";
            this.chkMotoristas.Size = new System.Drawing.Size(177, 22);
            this.chkMotoristas.TabIndex = 2;
            this.chkMotoristas.Text = "Módulo de Motoristas";
            this.chkMotoristas.UseVisualStyleBackColor = true;
            // 
            // chkUsuarios
            // 
            this.chkUsuarios.AutoSize = true;
            this.chkUsuarios.Location = new System.Drawing.Point(9, 38);
            this.chkUsuarios.Name = "chkUsuarios";
            this.chkUsuarios.Size = new System.Drawing.Size(166, 22);
            this.chkUsuarios.TabIndex = 1;
            this.chkUsuarios.Text = "Módulo de Usuários";
            this.chkUsuarios.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Permissões:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.Location = new System.Drawing.Point(432, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 29);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Arial", 12F);
            this.btnExcluir.Location = new System.Drawing.Point(328, 457);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(98, 29);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnEditar.Location = new System.Drawing.Point(215, 457);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(98, 29);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSalvar.Location = new System.Drawing.Point(111, 457);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(98, 29);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(5, 457);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(98, 29);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // FrmCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 490);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestão de Cargos";
            this.Load += new System.EventHandler(this.FrmCargo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkVeiculos;
        private System.Windows.Forms.CheckBox chkEmpresas;
        private System.Windows.Forms.CheckBox chkMotoristas;
        private System.Windows.Forms.CheckBox chkUsuarios;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvCargos;
        private System.Windows.Forms.CheckBox chkManutencoes;
        private System.Windows.Forms.CheckBox chkAbastecimentos;
        private System.Windows.Forms.CheckBox chkViagens;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
    }
}