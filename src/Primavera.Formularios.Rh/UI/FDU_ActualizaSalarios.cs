using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.CustomForm;
using Primavera.Formularios.RH.Services;

namespace Primavera.Formularios.RH.UI
{
    public partial class FDU_ImportadorDadosFuncionarios : CustomForm
    {
        private ClsFuncionario motor;
        public FDU_ImportadorDadosFuncionarios()
        {
            InitializeComponent();
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

        private void btActualizar_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void actualizar()
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string str_erros = "";
            try
            {
                DataView dt = (DataView)dgDados.DataSource;
                
                DateTime dataefectiva = dtDataEfectiva.Value;

                motor.ActualizaFuncionarios(dataefectiva,dt, ref str_erros);

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

        private void FDU_ImportadorDadosFuncionarios_Load(object sender, EventArgs e)
        {
            try
            {
                motor = new ClsFuncionario(BSO, PSO);


            }
            catch (Exception ex)
            {

            }
        }
    }
}
