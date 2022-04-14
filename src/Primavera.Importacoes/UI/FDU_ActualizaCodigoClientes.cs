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
    public partial class FDU_ActualizaCodigoClientes : CustomForm
    {
        ClsCliente motor;
        public FDU_ActualizaCodigoClientes()
        {
            InitializeComponent();
        }

        private void FDU_ImportacaoClientes_Load(object sender, EventArgs e)
        {
            try
            {
                motor = new ClsCliente(BSO, PSO);
            }
            catch (Exception ex)
            {

            }
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string str_erros = "";
            try
            {
                DataView dt = (DataView)dgDados.DataSource;

                motor.ActualizaCodigo(dt);

                if (str_erros.Length > 0)
                {
                    motor.escreveLog(str_erros);
                }
                else
                {
                    MessageBox.Show("Operação Terminada, confirme no sistema");
                }
            }
            catch (Exception ex)
            {
                PSO.Dialogos.MostraAviso(
                   "Ocorreu um erro ao importar a informação do excell",
                   StdPlatBS100.StdBSTipos.IconId.PRI_Critico,
                   ex.Message
               );
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    txtCaminhoExcel.Text = file.FileName;

                    cbSheet.DataSource = motor.listaFolhaExcel(file.FileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
