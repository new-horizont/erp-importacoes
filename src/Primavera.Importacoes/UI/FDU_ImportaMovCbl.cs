using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.CustomForm;
using Primavera.Importacoes.Services;

namespace Primavera.Importacoes.UI
{
    public partial class FDU_ImportaMovCbl : CustomForm
    {
        public FDU_ImportaMovCbl()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = txtCaminhoExcel.Text;
                int sheet = cbSheet.SelectedIndex;

                dgDados.DataSource = motor.CarregaListaExcel(fileName, sheet, 2).DefaultView;
            }
            catch (Exception ex)
            {
                PSO.Dialogos.MostraAviso(
                    "Ocorreu um erro ao carregar a informação do excell",
                    StdPlatBS100.StdBSTipos.IconId.PRI_Critico,
                    ex.Message
                );
            }
        }
    }
}
