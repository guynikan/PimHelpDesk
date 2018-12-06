using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNIP.PIM.HelpDesk.WindowsForms
{
    public partial class FrmRelatorioChamados : Form
    {
        public FrmRelatorioChamados()
        {
            InitializeComponent();
        }

        private void FrmRelatorioChamados_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'ChamadosDataSet.tblChamado'. Você pode movê-la ou removê-la conforme necessário.
            this.tblChamadoTableAdapter.Fill(this.ChamadosDataSet.tblChamado);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
