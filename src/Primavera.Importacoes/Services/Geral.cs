using ErpBS100;
using Primavera.Importacoes.Helpers;
using StdPlatBS100;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Primavera.Importacoes.Services
{
    public class Geral : IDisposable
    {
        public StdPlatBS plat { get; set; }

        public StdBSInterfPub pso { get; set; }

        public ErpBS bso { get; set; }

        public Geral(dynamic bso)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            this.bso = bso;
            AbrePlataforma(bso);
        }

        public Geral(dynamic bso, dynamic pso)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            this.bso = bso;

            //AbrePlataforma(bso);

            this.pso = pso;
        }

        public Geral(string userPrimavera, string passUserPrimavera, string empresa, int tipoEmpPRI)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            AbrirMotorPrimavera(userPrimavera, passUserPrimavera, empresa, tipoEmpPRI);
        }

        public ErpBS MotorERP()
        {
            return bso;
        }

        /// <summary>
        /// Método para resolução das assemblies.
        /// </summary>
        /// <param name="sender">Application</param>
        /// <param name="args">Resolving Assembly Name</param>
        /// <returns>Assembly</returns>
        public static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string assemblyFullName;
            System.Reflection.AssemblyName assemblyName;
            string PRIMAVERA_COMMON_FILES_FOLDER = PrimaveraConstHelper.pastaConfigV100;//pasta dos ficheiros comuns especifica da versão do ERP PRIMAVERA utilizada.
            assemblyName = new System.Reflection.AssemblyName(args.Name);
            assemblyFullName = System.IO.Path.Combine(System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86), PRIMAVERA_COMMON_FILES_FOLDER), assemblyName.Name + ".dll");
            if (System.IO.File.Exists(assemblyFullName))
                return System.Reflection.Assembly.LoadFile(assemblyFullName);
            else
                return null;
        }

        public Boolean AbrirMotorPrimavera(string userPrimavera, string passUserPrimavera, string empresa, int tipoEmpPRI)
        {
            try
            {
                bso = new ErpBS();

                bso.AbreEmpresaTrabalho(tipoEmpPRI, empresa, userPrimavera, passUserPrimavera);

                AbrePlataforma(bso);

                return bso.Contexto.EmpresaAberta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbrePlataforma(ErpBS motor)
        {
            StdBSConfApl objAplConf = new StdBSConfApl();
            plat = new StdPlatBS();

            try
            {
                objAplConf.Instancia = motor.Contexto.Instancia;
                objAplConf.AbvtApl = "ERP";
                objAplConf.PwdUtilizador = motor.Contexto.PasswordUtilizadorActual;
                objAplConf.Utilizador = motor.Contexto.UtilizadorActual;
                objAplConf.LicVersaoMinima = "10.00";

                plat.AbrePlataformaEmpresa(motor.Contexto.CodEmp, null, objAplConf, motor.Contexto.TipoPlataforma);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ConsultaSQLDatatable(string querySql)
        {

            try
            {
                DataTable dt = new DataTable();

                string connectionString = plat != null ? plat.BaseDados.DaConnectionStringNET(plat.BaseDados.DaNomeBDdaEmpresa(bso.Contexto.CodEmp),
                    "Default") : pso.BaseDados.DaConnectionStringNET(pso.BaseDados.DaNomeBDdaEmpresa(bso.Contexto.CodEmp),
                    "Default");

                SqlConnection con = new SqlConnection(connectionString);

                SqlDataAdapter da = new SqlDataAdapter(querySql, con);

                SqlCommandBuilder cb = new SqlCommandBuilder(da);

                da.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetParameter(string Name)
        {
            try
            {
                string result = "";
                string query = string.Format("select * from TDU_Parametros where CDU_Parametro = '{0}' ", Name);
                DataTable dt = ConsultaSQLDatatable(query);

                if (dt.Rows.Count > 0)
                {
                    result = dt.Rows[0]["CDU_Valor"].ToString();
                }
                else
                {
                    new Exception("O parametro {0} não se encontra configurado na tabela de TDU_Parametros");
                }

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int ExecutaQuery(string querySQL)
        {
            try
            {
                DataTable dt = new DataTable();

                string connectionString = plat != null ? plat.BaseDados.DaConnectionStringNET(plat.BaseDados.DaNomeBDdaEmpresa(bso.Contexto.CodEmp),
                    "Default") : pso.BaseDados.DaConnectionStringNET(pso.BaseDados.DaNomeBDdaEmpresa(bso.Contexto.CodEmp),
                    "Default");

                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = con;
                command.CommandText = querySQL;
                con.Open();

                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public object F4Event(string query, string Coluna, string nomeTabela)
        {
            try
            {
                return plat.Listas.GetF4SQL(nomeTabela, query, Coluna);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AddLinhaVazia(DataTable dt)
        {
            try
            {
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable daListaTabela(string tabela, int maximo = 0, string campos = "", string filtros = "", string juncoes = "", string ordenacao = "")
        {
            string strSql = "select ";

            try
            {

                DataTable dt;

                if (maximo > 0) strSql = strSql + string.Format("Top {0} ", maximo);

                if ((campos.Length > 0))
                {
                    strSql = (strSql + campos);
                }
                else
                {
                    strSql = (strSql + " * ");
                }

                strSql = (strSql + (" from " + tabela));
                if ((juncoes.Length > 0))
                {
                    strSql = (strSql + (" " + juncoes));
                }

                if ((filtros.Length > 0))
                {
                    strSql = (strSql + (" where " + filtros));
                }

                if ((ordenacao.Length > 0))
                {
                    strSql = (strSql + (" order by " + ordenacao));
                }

                dt = this.ConsultaSQLDatatable(strSql);

                return dt;
            }
            catch (Exception ex)
            {
                escreveErro(strSql);

                throw ex;
            }

        }

        public void escreveErro(string pastaLog, string name, string logMessage)
        {
            string ficheiro;
            try
            {
                ficheiro = pastaLog;

                using (StreamWriter w = File.AppendText(ficheiro + "\\" + string.Format("erro_{0}.log", name)))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void escreveErro(string logMessage)
        {
            string ficheiro;
            try
            {
                ficheiro = GetParameter("Log_PastaErro");

                using (StreamWriter w = File.AppendText(ficheiro + "\\" + string.Format("log_{0}.txt", DateTime.Now.ToString("ddMMyy"))))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void escreveLog(string pastaLog, string name, string logMessage)
        {
            string ficheiro;
            try
            {
                ficheiro = pastaLog;

                using (StreamWriter w = File.AppendText(ficheiro + "\\" + string.Format("log_{0}.log", name)))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        public void escreveLog(string logMessage)
        {
            string ficheiro;
            try
            {
                ficheiro = GetParameter("Log_PastaErro");

                using (StreamWriter w = File.AppendText(ficheiro + "\\" + string.Format("log_{0}.txt", DateTime.Now.ToString("ddMMyy"))))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AvisoPoliticaComercial(string mensaguem, ref string strAviso)
        {
            try
            {
                if (!strAviso.Contains(mensaguem))
                    strAviso += mensaguem + "\n";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("{0} - {1}", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), logMessage);
            }
            catch (Exception ex)
            {

            }
        }

        #region excel
        public List<string> listaFolhaExcel(string caminhoExcell)
        {
            try
            {

                if (!File.Exists(caminhoExcell))
                {
                    throw new Exception("File does not exists");
                }

                List<string> listSheet = new List<string>();

                OleDbConnection conn = new OleDbConnection();

                string connString = ExcelConnection(caminhoExcell);

                conn.ConnectionString = connString;
                conn.Open();

                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                foreach (DataRow drSheet in dt.Rows)
                {
                    listSheet.Add(drSheet["TABLE_NAME"].ToString());
                }

                return listSheet;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CarregaListaExcel(string caminhoExcell, int sheetNumber, int linhaInicial)
        {

            DataTable dt;
            DataRow dr;

            try
            {

                if (!File.Exists(caminhoExcell))
                {
                    throw new Exception("File does not exists");
                }

                List<string> listSheet = new List<string>();

                OleDbConnection conn = new OleDbConnection();

                string connString = ExcelConnection(caminhoExcell);

                conn.ConnectionString = connString;
                conn.Open();

                var dtExcel = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                dt = ObtemDadosSheetExcell(conn, dtExcel.Rows[sheetNumber]["TABLE_NAME"].ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        public DataTable ObtemDadosSheetExcell(OleDbConnection conn, string sheet)
        {
            try
            {
                DataTable dt = new DataTable();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataReader connReader;

                cmd.Connection = conn;
                cmd.CommandText = string.Format("Select * From [{0}]", sheet);

                connReader = cmd.ExecuteReader();
                dt.Load(connReader);

                connReader.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object id = dt.Rows[i];
                    if (id != null && !String.IsNullOrEmpty(id.ToString().Trim()))
                    {

                    }
                    else
                    {
                        dt.Rows[i].Delete();
                    }
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception("<ObtemDadosSheetExcell>_" + ex.Message);
            }
        }
        private string ExcelConnection(string fileName)
        {
            return @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                   @"Data Source=" + fileName + ";" +
                   @"Extended Properties='Excel 8.0;HDR=YES'";
        }
        #endregion

        #region Limpeza de Lixo
        public static void ReleaseCom(dynamic ObjCom)
        {
            try
            {
                if (ObjCom != null)
                {
                    while (Marshal.ReleaseComObject(ObjCom) > 0)
                    {
                        // release one by one
                    };

                    ObjCom = null;
                }
            }
            catch (Exception e)
            {
                //throw new Exception("Erro ao finalizar o motor.");
            }
        }
        #endregion

        public void Dispose()
        {
            ReleaseCom(bso);
            ReleaseCom(plat);
        }
    }
}
