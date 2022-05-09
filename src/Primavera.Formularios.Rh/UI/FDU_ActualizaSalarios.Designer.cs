namespace Primavera.Formularios.RH.UI
{
    partial class FDU_ImportadorDadosFuncionarios
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
            this.toolbox = new System.Windows.Forms.ToolStrip();
            this.btActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btImprimir = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCaminhoExcel = new System.Windows.Forms.TextBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDataEfectiva = new System.Windows.Forms.DateTimePicker();
            this.toolbox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbox
            // 
            this.toolbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btActualizar,
            this.toolStripButton1,
            this.btImprimir});
            this.toolbox.Location = new System.Drawing.Point(0, 0);
            this.toolbox.Name = "toolbox";
            this.toolbox.Size = new System.Drawing.Size(890, 25);
            this.toolbox.TabIndex = 30;
            this.toolbox.Text = "toolStrip1";
            // 
            // btActualizar
            // 
            this.btActualizar.Image = global::Primavera.Formularios.Rh.Properties.Resources.actualizar32x32;
            this.btActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(79, 22);
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Primavera.Formularios.Rh.Properties.Resources.processar32x32;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(77, 22);
            this.toolStripButton1.Text = "Processar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btImprimir
            // 
            this.btImprimir.Enabled = false;
            this.btImprimir.Image = global::Primavera.Formularios.Rh.Properties.Resources.print_512;
            this.btImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(73, 22);
            this.btImprimir.Text = "Imprimir";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 80);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ficheiro Excell";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCaminhoExcel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btPesquisar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbSheet, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(550, 59);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Caminho (.XLS):";
            // 
            // txtCaminhoExcel
            // 
            this.txtCaminhoExcel.Location = new System.Drawing.Point(120, 3);
            this.txtCaminhoExcel.Name = "txtCaminhoExcel";
            this.txtCaminhoExcel.Size = new System.Drawing.Size(379, 20);
            this.txtCaminhoExcel.TabIndex = 10;
            // 
            // btPesquisar
            // 
            this.btPesquisar.Image = global::Primavera.Formularios.Rh.Properties.Resources.procurar;
            this.btPesquisar.Location = new System.Drawing.Point(513, 3);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(30, 23);
            this.btPesquisar.TabIndex = 15;
            this.btPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Folha do Excel:";
            // 
            // cbSheet
            // 
            this.cbSheet.FormattingEnabled = true;
            this.cbSheet.Location = new System.Drawing.Point(120, 32);
            this.cbSheet.Name = "cbSheet";
            this.cbSheet.Size = new System.Drawing.Size(376, 21);
            this.cbSheet.TabIndex = 14;
            // 
            // dgDados
            // 
            this.dgDados.AllowUserToAddRows = false;
            this.dgDados.AllowUserToOrderColumns = true;
            this.dgDados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Location = new System.Drawing.Point(3, 114);
            this.dgDados.Name = "dgDados";
            this.dgDados.Size = new System.Drawing.Size(884, 385);
            this.dgDados.TabIndex = 32;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(575, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 79);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.33334F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtDataEfectiva, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(276, 62);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Efectiva:";
            // 
            // dtDataEfectiva
            // 
            this.dtDataEfectiva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataEfectiva.Location = new System.Drawing.Point(82, 3);
            this.dtDataEfectiva.MinDate = new System.DateTime(2008, 12, 1, 0, 0, 0, 0);
            this.dtDataEfectiva.Name = "dtDataEfectiva";
            this.dtDataEfectiva.Size = new System.Drawing.Size(144, 20);
            this.dtDataEfectiva.TabIndex = 1;
            // 
            // FDU_ImportadorDadosFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolbox);
            this.Name = "FDU_ImportadorDadosFuncionarios";
            this.Size = new System.Drawing.Size(890, 503);
            this.Text = "Funcionarios - Actualização Salarios";
            this.Load += new System.EventHandler(this.FDU_ImportadorDadosFuncionarios_Load);
            this.toolbox.ResumeLayout(false);
            this.toolbox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbox;
        private System.Windows.Forms.ToolStripButton btActualizar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btImprimir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCaminhoExcel;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSheet;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDataEfectiva;
    }
}