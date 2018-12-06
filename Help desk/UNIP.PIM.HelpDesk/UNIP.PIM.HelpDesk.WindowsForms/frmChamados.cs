using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNIP.PIM.HelpDesk.BLL;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DAO;
using UNIP.PIM.HelpDesk.DTO.Chamado;

namespace UNIP.PIM.HelpDesk.WindowsForms
{
    
    public partial class frmChamados : Form
    {

        public frmChamados()
        {
            InitializeComponent();
        }

        private void frmChamados_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'ChamadosDataSet.tblChamado'. Você pode movê-la ou removê-la conforme necessário.
            this.tblChamadoTableAdapter.Fill(this.ChamadosDataSet.tblChamado);
            var chamado = new ChamadoDAL();
            var usuario = new UsuarioDAL();
            var solicitacao = new SolicitacaoDAL();

            var listaStatus = chamado.ListarStatus();
            var listaUsuario = usuario.Listar();
            var listaSolicitacao = solicitacao.ListarSolicitacoes();

            foreach (var item in listaStatus)
            {
                cboStatus.Items.Add(item);
            }
            foreach (var item in listaUsuario)
            {
                cboUsuario.Items.Add(item);
                cboTecnico.Items.Add(item);
            }
            foreach (var item in listaSolicitacao)
            {
                cboSolicitacao.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var chamado = new ChamadoDAL();

            var status = cboStatus.Text != "Selecionar" ? cboStatus.Text : string.Empty;
            var tecnio = cboTecnico.Text != "Selecionar" ?  cboTecnico.Text : string.Empty;
            var usuario = cboUsuario.Text != "Selecionar" ? cboUsuario.Text : string.Empty;
            var solicitacao = cboSolicitacao.Text != "Selecionar" ? cboSolicitacao.Text : string.Empty;

            var chamados = chamado.ListarChamadosRelatorio(txtIdChamado.Text, txtTitulo.Text, status, tecnio, 
                usuario, solicitacao, dtDataAbertura.Text, dtDataFechamento.Text, dtDataConclusao.Text);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", chamados));
    
            this.reportViewer1.RefreshReport();
            txtIdChamado.Text = string.Empty;
            txtTitulo.Text = string.Empty;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtDataAbertura_ValueChanged(object sender, EventArgs e)
        {
            dtDataAbertura.CustomFormat = "dd/MM/yyyy"; 
        }

        private void dtDataFechamento_ValueChanged(object sender, EventArgs e)
        {
            dtDataFechamento.CustomFormat = "dd/MM/yyyy";
        }

        private void dtDataConclusao_ValueChanged(object sender, EventArgs e)
        {
            dtDataConclusao.CustomFormat = "dd/MM/yyyy";
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void txtIdChamado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
