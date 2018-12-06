namespace UNIP.PIM.HelpDesk.WindowsForms
{
    partial class frmChamados
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tblChamadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ChamadosDataSet = new UNIP.PIM.HelpDesk.WindowsForms.ChamadosDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tblChamadoTableAdapter = new UNIP.PIM.HelpDesk.WindowsForms.ChamadosDataSetTableAdapters.tblChamadoTableAdapter();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtIdChamado = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDataAbertura = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtDataFechamento = new System.Windows.Forms.DateTimePicker();
            this.dtDataConclusao = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.cboTecnico = new System.Windows.Forms.ComboBox();
            this.cboSolicitacao = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblChamadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChamadosDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tblChamadoBindingSource
            // 
            this.tblChamadoBindingSource.DataMember = "tblChamado";
            this.tblChamadoBindingSource.DataSource = this.ChamadosDataSet;
            // 
            // ChamadosDataSet
            // 
            this.ChamadosDataSet.DataSetName = "ChamadosDataSet";
            this.ChamadosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblChamadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UNIP.PIM.HelpDesk.WindowsForms.RptChamados.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 133);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(960, 582);
            this.reportViewer1.TabIndex = 0;
            // 
            // tblChamadoTableAdapter
            // 
            this.tblChamadoTableAdapter.ClearBeforeFill = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(793, 29);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(123, 69);
            this.btnFiltrar.TabIndex = 1;
            this.btnFiltrar.Text = "Gerar Relatório";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIdChamado
            // 
            this.txtIdChamado.Location = new System.Drawing.Point(12, 30);
            this.txtIdChamado.Name = "txtIdChamado";
            this.txtIdChamado.Size = new System.Drawing.Size(120, 20);
            this.txtIdChamado.TabIndex = 2;
            this.txtIdChamado.TextChanged += new System.EventHandler(this.txtIdChamado_TextChanged);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(148, 29);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(258, 20);
            this.txtTitulo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID do Chamado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Título";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuário";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(602, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Técnico";
            // 
            // dtDataAbertura
            // 
            this.dtDataAbertura.CustomFormat = " ";
            this.dtDataAbertura.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDataAbertura.Location = new System.Drawing.Point(13, 80);
            this.dtDataAbertura.Name = "dtDataAbertura";
            this.dtDataAbertura.Size = new System.Drawing.Size(120, 20);
            this.dtDataAbertura.TabIndex = 10;
            this.dtDataAbertura.Value = new System.DateTime(2018, 11, 15, 0, 0, 0, 0);
            this.dtDataAbertura.ValueChanged += new System.EventHandler(this.dtDataAbertura_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Data de Abertura";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(145, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Data de Fechamento";
            // 
            // dtDataFechamento
            // 
            this.dtDataFechamento.CustomFormat = " ";
            this.dtDataFechamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDataFechamento.Location = new System.Drawing.Point(148, 80);
            this.dtDataFechamento.Name = "dtDataFechamento";
            this.dtDataFechamento.Size = new System.Drawing.Size(120, 20);
            this.dtDataFechamento.TabIndex = 13;
            this.dtDataFechamento.ValueChanged += new System.EventHandler(this.dtDataFechamento_ValueChanged);
            // 
            // dtDataConclusao
            // 
            this.dtDataConclusao.CustomFormat = " ";
            this.dtDataConclusao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDataConclusao.Location = new System.Drawing.Point(286, 80);
            this.dtDataConclusao.Name = "dtDataConclusao";
            this.dtDataConclusao.Size = new System.Drawing.Size(120, 20);
            this.dtDataConclusao.TabIndex = 15;
            this.dtDataConclusao.ValueChanged += new System.EventHandler(this.dtDataConclusao_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Data de Conclusão";
            // 
            // cboStatus
            // 
            this.cboStatus.DisplayMember = "Value";
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Selecionar"});
            this.cboStatus.Location = new System.Drawing.Point(606, 29);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(168, 21);
            this.cboStatus.TabIndex = 16;
            this.cboStatus.ValueMember = "Key";
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(603, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Status";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(418, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Solicitação";
            // 
            // cboUsuario
            // 
            this.cboUsuario.DisplayMember = "Nome";
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Items.AddRange(new object[] {
            "Selecionar"});
            this.cboUsuario.Location = new System.Drawing.Point(421, 77);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(168, 21);
            this.cboUsuario.TabIndex = 21;
            this.cboUsuario.ValueMember = "IdUsuario";
            // 
            // cboTecnico
            // 
            this.cboTecnico.DisplayMember = "Nome";
            this.cboTecnico.FormattingEnabled = true;
            this.cboTecnico.Items.AddRange(new object[] {
            "Selecionar"});
            this.cboTecnico.Location = new System.Drawing.Point(606, 77);
            this.cboTecnico.Name = "cboTecnico";
            this.cboTecnico.Size = new System.Drawing.Size(168, 21);
            this.cboTecnico.TabIndex = 22;
            this.cboTecnico.ValueMember = "IdUsuario";
            // 
            // cboSolicitacao
            // 
            this.cboSolicitacao.DisplayMember = "Descricao";
            this.cboSolicitacao.FormattingEnabled = true;
            this.cboSolicitacao.Items.AddRange(new object[] {
            "Selecionar"});
            this.cboSolicitacao.Location = new System.Drawing.Point(423, 30);
            this.cboSolicitacao.Name = "cboSolicitacao";
            this.cboSolicitacao.Size = new System.Drawing.Size(168, 21);
            this.cboSolicitacao.TabIndex = 23;
            this.cboSolicitacao.ValueMember = "IdSolicitacao";
            // 
            // frmChamados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 727);
            this.Controls.Add(this.cboSolicitacao);
            this.Controls.Add(this.cboTecnico);
            this.Controls.Add(this.cboUsuario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.dtDataConclusao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtDataFechamento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtDataAbertura);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtIdChamado);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.reportViewer1);
            this.MaximumSize = new System.Drawing.Size(1000, 766);
            this.MinimumSize = new System.Drawing.Size(977, 766);
            this.Name = "frmChamados";
            this.Text = "Relatório de Chamados";
            this.Load += new System.EventHandler(this.frmChamados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblChamadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChamadosDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblChamadoBindingSource;
        private ChamadosDataSet ChamadosDataSet;
        private ChamadosDataSetTableAdapters.tblChamadoTableAdapter tblChamadoTableAdapter;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtIdChamado;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtDataAbertura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtDataFechamento;
        private System.Windows.Forms.DateTimePicker dtDataConclusao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.ComboBox cboTecnico;
        private System.Windows.Forms.ComboBox cboSolicitacao;
    }
}