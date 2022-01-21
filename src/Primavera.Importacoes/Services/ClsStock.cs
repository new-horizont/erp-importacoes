using BasBE100;
using IntBE100;
using Primavera.Importacoes.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primavera.Importacoes.Services
{
    public class ClsStock : Geral
    {
        public ClsStock(object BSO) : base(BSO)
        {

        }
        public ClsStock(object BSO, object Plat) : base(BSO, Plat)
        {

        }

        public ClsStock(int tipoPlataforma, string strEmpresa, string strUtilizador, string strPassword)
            : base(strUtilizador, strPassword, strEmpresa, tipoPlataforma)
        {

        }

        public void Processar(DataView dt, string doc)
        {
            try
            {
                IntBEDocumentoInterno _doc;

                _doc = new IntBEDocumentoInterno();

                _doc.Tipodoc = doc;
                _doc.Serie = DateTime.Today.Year.ToString();

                bso.Internos.Documentos.PreencheDadosRelacionados(_doc);

                _doc.Data = DateTime.Today;
                _doc.DataVencimento = DateTime.Today;
                _doc.Utilizador = bso.Contexto.UtilizadorActual;

                for (int i = 0; i < dt.Count; i++)
                {
                    DataRowView dr = dt[i];

                    string artigo = StringHelper.DaString(dr["Artigo"]);

                    if (artigo.Length > 0)
                    {
                        string armazem = StringHelper.DaString(dr["Armazem"]);
                        string localizacao = StringHelper.DaString(dr["Localizacao"]);
                        double precUnit = StringHelper.DaDouble(dr["PrecUnit"]);
                        double qnt = StringHelper.DaDouble(dr["Quantidade"]);

                        bso.Internos.Documentos.AdicionaLinha(_doc, artigo, armazem, localizacao, "",
                            precUnit, 0, qnt);
                    }
                }

                bso.Internos.Documentos.Actualiza(_doc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
