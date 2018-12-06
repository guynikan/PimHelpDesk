namespace UNIP.PIM.HelpDesk.WindowsForms
{
    partial class FrmRelatorioChamados
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
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblChamadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UNIP.PIM.HelpDesk.WindowsForms.rptChamados.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(884, 420);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // tblChamadoTableAdapter
            // 
            this.tblChamadoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelatorioChamados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 420);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelatorioChamados";
            this.Text = "FrmRelatorioChamados";
            this.Load += new System.EventHandler(this.FrmRelatorioChamados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblChamadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChamadosDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblChamadoBindingSource;
        private ChamadosDataSet ChamadosDataSet;
        private ChamadosDataSetTableAdapters.tblChamadoTableAdapter tblChamadoTableAdapter;
    }
}