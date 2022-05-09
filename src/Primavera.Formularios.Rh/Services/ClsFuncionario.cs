using Primavera.Formularios.RH.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Primavera.Formularios.RH.Services
{
    public class ClsFuncionario:Geral
    {
        public ClsFuncionario(object BSO) : base(BSO)
        {

        }
        public ClsFuncionario(object BSO, object Plat) : base(BSO, Plat)
        {

        }

        public ClsFuncionario(int tipoPlataforma, string strEmpresa, string strUtilizador, string strPassword)
            : base(strUtilizador, strPassword, strEmpresa, tipoPlataforma)
        {

        }

        public DataTable CarregaListaFuncionarios(string caminhoExcell, int sheetNumber, int linhaInical)
        {
            DataTable dt;
            DataRow dr;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            string str_erros = "";


            try
            {

                string str;
                int rCnt;
                int cCnt;
                int rw = 0;
                int cl = 0;


                string codigo, nome;
                double vencimentoMensal;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(caminhoExcell, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheetNumber + 1);

                range = xlWorkSheet.UsedRange;
                rw = 10000;//range.Rows.Count;
                cl = range.Columns.Count;

                string campos = @"Codigo, Nome, VencimentoMensal";

                dt = daListaTabela("Funcionarios", 0, campos, "Codigo='******'");

                for (rCnt = linhaInical; rCnt < rw; rCnt++)
                {
                    codigo = Convert.ToString((xlWorkSheet.Cells[rCnt, 1] as Excel.Range).Value2);
                    nome = Convert.ToString((xlWorkSheet.Cells[rCnt, 2] as Excel.Range).Value2);
                    vencimentoMensal = StringHelper.DaDouble((xlWorkSheet.Cells[rCnt, 3] as Excel.Range).Value2);
                    

                    if (codigo.Length == 0) break;

                    dr = dt.NewRow();

                    dr["Codigo"] = codigo;
                    dr["Nome"] = nome;
                    dr["VencimentoMensal"] = vencimentoMensal;

                    dt.Rows.Add(dr);
                }

                xlWorkBook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public void ActualizaFuncionarios(DateTime dataefectiva, DataView dt, ref string str_erros)
        {
            try
            { 
                string codigo, nome;
                double vencimentoMensal;
                
                for (int i = 0; i < dt.Count; i++)
                {

                    DataRowView dr = dt[i];
                    codigo = StringHelper.DaString( dr["Codigo"]);

                    if (codigo.Length > 0)
                    {
                        nome = StringHelper.DaString(dr["Nome"]);
                        vencimentoMensal = StringHelper.DaDouble(dr["VencimentoMensal"]);
                        
                        bso.RecursosHumanos.Funcionarios.ActualizaValorAtributo(codigo, "VencimentoMensal", vencimentoMensal);
                        bso.RecursosHumanos.Funcionarios.ActualizaValorAtributo(codigo, "Vencimento", vencimentoMensal);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
