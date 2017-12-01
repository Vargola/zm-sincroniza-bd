namespace zmSBD
{
	partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecionarTudoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUser1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCatalog1 = new System.Windows.Forms.TextBox();
            this.cmbUDL1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSource1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUser2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCatalog2 = new System.Windows.Forms.TextBox();
            this.cmbUDL2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSource2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkNovos = new System.Windows.Forms.CheckBox();
            this.chkExcluidos = new System.Windows.Forms.CheckBox();
            this.chkProcs = new System.Windows.Forms.CheckBox();
            this.chkViews = new System.Windows.Forms.CheckBox();
            this.chkListagem = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(607, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "DIFF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbResult
            // 
            this.rtbResult.ContextMenuStrip = this.contextMenuStrip1;
            this.rtbResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbResult.EnableAutoDragDrop = true;
            this.rtbResult.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbResult.Location = new System.Drawing.Point(67, 230);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.ReadOnly = true;
            this.rtbResult.Size = new System.Drawing.Size(600, 359);
            this.rtbResult.TabIndex = 1;
            this.rtbResult.Text = "";
            this.rtbResult.WordWrap = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarToolStripMenuItem,
            this.selecionarTudoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 48);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Image = global::zmSBD.Properties.Resources.copiar;
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
            // 
            // selecionarTudoToolStripMenuItem
            // 
            this.selecionarTudoToolStripMenuItem.Name = "selecionarTudoToolStripMenuItem";
            this.selecionarTudoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.selecionarTudoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.selecionarTudoToolStripMenuItem.Text = "Selecionar Tudo";
            this.selecionarTudoToolStripMenuItem.Click += new System.EventHandler(this.selecionarTudoToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtUser1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCatalog1);
            this.groupBox1.Controls.Add(this.cmbUDL1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSource1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 146);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database 1 - MODELO";
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(94, 117);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(210, 20);
            this.txtPassword1.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Password:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser1
            // 
            this.txtUser1.Location = new System.Drawing.Point(94, 91);
            this.txtUser1.Name = "txtUser1";
            this.txtUser1.Size = new System.Drawing.Size(210, 20);
            this.txtUser1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "UDL:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCatalog1
            // 
            this.txtCatalog1.Location = new System.Drawing.Point(94, 64);
            this.txtCatalog1.Name = "txtCatalog1";
            this.txtCatalog1.Size = new System.Drawing.Size(210, 20);
            this.txtCatalog1.TabIndex = 9;
            // 
            // cmbUDL1
            // 
            this.cmbUDL1.FormattingEnabled = true;
            this.cmbUDL1.Location = new System.Drawing.Point(94, 13);
            this.cmbUDL1.Name = "cmbUDL1";
            this.cmbUDL1.Size = new System.Drawing.Size(210, 21);
            this.cmbUDL1.TabIndex = 8;
            this.cmbUDL1.SelectedIndexChanged += new System.EventHandler(this.cmbUDL1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Catalog:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSource1
            // 
            this.txtSource1.Location = new System.Drawing.Point(94, 39);
            this.txtSource1.Name = "txtSource1";
            this.txtSource1.Size = new System.Drawing.Size(210, 20);
            this.txtSource1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Source:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPassword2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtUser2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCatalog2);
            this.groupBox2.Controls.Add(this.cmbUDL2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSource2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(347, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 146);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database 2";
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(99, 116);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(210, 20);
            this.txtPassword2.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Password:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser2
            // 
            this.txtUser2.Location = new System.Drawing.Point(99, 91);
            this.txtUser2.Name = "txtUser2";
            this.txtUser2.Size = new System.Drawing.Size(210, 20);
            this.txtUser2.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "UDL:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCatalog2
            // 
            this.txtCatalog2.Location = new System.Drawing.Point(99, 64);
            this.txtCatalog2.Name = "txtCatalog2";
            this.txtCatalog2.Size = new System.Drawing.Size(210, 20);
            this.txtCatalog2.TabIndex = 17;
            // 
            // cmbUDL2
            // 
            this.cmbUDL2.FormattingEnabled = true;
            this.cmbUDL2.Location = new System.Drawing.Point(99, 13);
            this.cmbUDL2.Name = "cmbUDL2";
            this.cmbUDL2.Size = new System.Drawing.Size(210, 21);
            this.cmbUDL2.TabIndex = 16;
            this.cmbUDL2.SelectedIndexChanged += new System.EventHandler(this.cmbUDL2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "User ID:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Catalog:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSource2
            // 
            this.txtSource2.Location = new System.Drawing.Point(99, 39);
            this.txtSource2.Name = "txtSource2";
            this.txtSource2.Size = new System.Drawing.Size(210, 20);
            this.txtSource2.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Data Source:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(67, 596);
            this.progressBar1.Maximum = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(600, 30);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Visible = false;
            // 
            // chkNovos
            // 
            this.chkNovos.AutoSize = true;
            this.chkNovos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNovos.Location = new System.Drawing.Point(67, 168);
            this.chkNovos.Name = "chkNovos";
            this.chkNovos.Size = new System.Drawing.Size(109, 17);
            this.chkNovos.TabIndex = 5;
            this.chkNovos.Text = "Objetos Novos";
            this.chkNovos.UseVisualStyleBackColor = true;
            // 
            // chkExcluidos
            // 
            this.chkExcluidos.AutoSize = true;
            this.chkExcluidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcluidos.Location = new System.Drawing.Point(182, 168);
            this.chkExcluidos.Name = "chkExcluidos";
            this.chkExcluidos.Size = new System.Drawing.Size(129, 17);
            this.chkExcluidos.TabIndex = 6;
            this.chkExcluidos.Text = "Objetos Excluídos";
            this.chkExcluidos.UseVisualStyleBackColor = true;
            // 
            // chkProcs
            // 
            this.chkProcs.AutoSize = true;
            this.chkProcs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProcs.Location = new System.Drawing.Point(382, 168);
            this.chkProcs.Name = "chkProcs";
            this.chkProcs.Size = new System.Drawing.Size(160, 17);
            this.chkProcs.TabIndex = 7;
            this.chkProcs.Text = "Procedures e Functions";
            this.chkProcs.UseVisualStyleBackColor = true;
            // 
            // chkViews
            // 
            this.chkViews.AutoSize = true;
            this.chkViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViews.Location = new System.Drawing.Point(317, 168);
            this.chkViews.Name = "chkViews";
            this.chkViews.Size = new System.Drawing.Size(59, 17);
            this.chkViews.TabIndex = 8;
            this.chkViews.Text = "Views";
            this.chkViews.UseVisualStyleBackColor = true;
            // 
            // chkListagem
            // 
            this.chkListagem.AutoSize = true;
            this.chkListagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListagem.Location = new System.Drawing.Point(538, 207);
            this.chkListagem.Name = "chkListagem";
            this.chkListagem.Size = new System.Drawing.Size(129, 17);
            this.chkListagem.TabIndex = 9;
            this.chkListagem.Text = "Somente Listagem";
            this.chkListagem.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 632);
            this.Controls.Add(this.chkListagem);
            this.Controls.Add(this.chkViews);
            this.Controls.Add(this.chkExcluidos);
            this.Controls.Add(this.chkProcs);
            this.Controls.Add(this.chkNovos);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iguala Estrutura de Base de Dados 1.0 - By Vargola";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox rtbResult;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbUDL1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selecionarTudoToolStripMenuItem;
		private System.Windows.Forms.TextBox txtUser1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCatalog1;
		private System.Windows.Forms.TextBox txtSource1;
		private System.Windows.Forms.TextBox txtUser2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCatalog2;
		private System.Windows.Forms.ComboBox cmbUDL2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtSource2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtPassword1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtPassword2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.CheckBox chkNovos;
		private System.Windows.Forms.CheckBox chkExcluidos;
		private System.Windows.Forms.CheckBox chkProcs;
		private System.Windows.Forms.CheckBox chkViews;
        private System.Windows.Forms.CheckBox chkListagem;
	}
}

