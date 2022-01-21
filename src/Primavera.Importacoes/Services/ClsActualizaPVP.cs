using BasBE100;
using Primavera.Importacoes.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primavera.Importacoes.Services
{
    public class ClsActualizaPVP : Geral
    {
        public ClsActualizaPVP(object BSO) : base(BSO)
        {

        }
        public ClsActualizaPVP(object BSO, object Plat) : base(BSO, Plat)
        {

        }

        public ClsActualizaPVP(int tipoPlataforma, string strEmpresa, string strUtilizador, string strPassword)
            : base(strUtilizador, strPassword, strEmpresa, tipoPlataforma)
        {

        }

        public void ProcessaAlteracaoPVPs(DataView dt, ref string str_avisos, ref string str_erros)
        {
            try
            {
                bool iva = false;
                string artigo;
                for (int i = 0; i < dt.Count; i++)
                {
                    DataRowView dr = dt[i];

                    artigo = dr["Artigo"].ToString();
                    string unidade = dr["Unidade"].ToString();
                    string moeda = bso.Contexto.MoedaBase;

                    unidade = unidade.Length > 0 ? unidade : "UN";

                    double pvp1Novo = StringHelper.DaDouble(dr["PVP1"]);
                    double pvp2Novo = StringHelper.DaDouble(dr["PVP2"]);
                    double pvp3Novo = StringHelper.DaDouble(dr["PVP3"]);
                    double pvp4Novo = StringHelper.DaDouble(dr["PVP4"]);
                    double pvp5Novo = StringHelper.DaDouble(dr["PVP5"]);
                    double pvp6Novo = StringHelper.DaDouble(dr["PVP6"]);

                    if (bso.Base.ArtigosPrecos.Existe(artigo, moeda, unidade))
                    {
                        if (pvp1Novo > 0)
                            bso.Base.ArtigosPrecos.ActualizaValorAtributo(artigo, moeda, unidade, "PVP1", pvp1Novo);
                        if (pvp2Novo > 0)
                            bso.Base.ArtigosPrecos.ActualizaValorAtributo(artigo, moeda, unidade, "PVP2", pvp2Novo);
                        if (pvp3Novo > 0)
                            bso.Base.ArtigosPrecos.ActualizaValorAtributo(artigo, moeda, unidade, "PVP3", pvp3Novo);
                        if (pvp4Novo > 0)
                            bso.Base.ArtigosPrecos.ActualizaValorAtributo(artigo, moeda, unidade, "PVP4", pvp4Novo);
                        if (pvp5Novo > 0)
                            bso.Base.ArtigosPrecos.ActualizaValorAtributo(artigo, moeda, unidade, "PVP5", pvp5Novo);
                        if (pvp6Novo > 0)
                            bso.Base.ArtigosPrecos.ActualizaValorAtributo(artigo, moeda, unidade, "PVP6", pvp6Novo);

                    }
                    else
                    {
                        BasBEArtigoMoeda am = new BasBEArtigoMoeda();

                        am.Artigo = artigo;
                        am.Descricao = bso.Base.Artigos.DaValorAtributo(artigo, "Descricao");
                        am.Moeda = bso.Contexto.MoedaBase;
                        am.Unidade = unidade;
                        am.PVP1 = pvp1Novo;
                        am.PVP1IvaIncluido = iva;
                        am.PVP2 = pvp2Novo;
                        am.PVP2IvaIncluido = iva;
                        am.PVP3 = pvp3Novo;
                        am.PVP3IvaIncluido = iva;
                        am.PVP4 = pvp4Novo;
                        am.PVP4IvaIncluido = iva;
                        am.PVP5 = pvp5Novo;
                        am.PVP5IvaIncluido = iva;
                        am.PVP6 = pvp6Novo;
                        am.PVP6IvaIncluido = iva;

                        bso.Base.ArtigosPrecos.Actualiza(am);
                    }



                }
            }
            catch (Exception ex)
            {
                str_erros += "/n" + "Ocorreu um erro durante a actualização dos PVP's devido a: " + "/n" + ex.Message;
            }
        }

        public void ProcessaAlteracaoPVPs_SQL(DataTable dtTabela, ref string str_avisos, ref string str_erros)
        {
            try
            {
                bool iva = false;
                string artigo;
                foreach (DataRow dr in dtTabela.Rows)
                {
                    string str_sql = "";

                    artigo = dr["artigo"].ToString();
                    string unidade = dr["UN"].ToString();
                    string moeda = bso.Contexto.MoedaBase;

                    unidade = unidade.Length > 0 ? unidade : "UN";

                    double pvp1Novo = Convert.ToDouble(dr["PVP1"]);
                    double pvp2Novo = Convert.ToDouble(dr["PVP2"]);
                    double pvp3Novo = Convert.ToDouble(dr["PVP3"]);
                    double pvp4Novo = Convert.ToDouble(dr["PVP4"]);
                    double pvp5Novo = Convert.ToDouble(dr["PVP5"]);
                    double pvp6Novo = Convert.ToDouble(dr["PVP6"]);


                    if (pvp1Novo > 0)
                    {
                        str_sql +=
                            string.Format(
                                "update artigomoeda set PVP1 = '{0}' where artigo = '{1}' and moeda = '{2}' and Unidade = '{3}';"
                                , pvp1Novo, artigo, moeda, unidade);
                    }

                    if (pvp2Novo > 0)
                    {
                        str_sql +=
                            string.Format(
                                "update artigomoeda set PVP2 = '{0}' where artigo = '{1}' and moeda = '{2}' and Unidade = '{3}';"
                                , pvp2Novo, artigo, moeda, unidade);
                    }

                    if (pvp3Novo > 0)
                    {
                        str_sql +=
                            string.Format(
                                "update artigomoeda set PVP3 = '{0}' where artigo = '{1}' and moeda = '{2}' and Unidade = '{3}';"
                                , pvp3Novo, artigo, moeda, unidade);
                    }
                    if (pvp4Novo > 0)
                    {
                        str_sql +=
                            string.Format(
                                "update artigomoeda set PVP4 = '{0}' where artigo = '{1}' and moeda = '{2}' and Unidade = '{3}';"
                                , pvp4Novo, artigo, moeda, unidade);
                    }
                    if (pvp5Novo > 0)
                    {
                        str_sql +=
                            string.Format(
                                "update artigomoeda set PVP5 = '{0}' where artigo = '{1}' and moeda = '{2}' and Unidade = '{3}';"
                                , pvp5Novo, artigo, moeda, unidade);
                    }
                    if (pvp6Novo > 0)
                    {
                        str_sql +=
                            string.Format(
                                "update artigomoeda set PVP6 = '{0}' where artigo = '{1}' and moeda = '{2}' and Unidade = '{3}';"
                                , pvp6Novo, artigo, moeda, unidade);
                    }

                    ExecutaQuery(str_sql);
                }
            }
            catch (Exception ex)
            {
                str_erros += "/n" + "Ocorreu um erro durante a actualização dos PVP's devido a: " + "/n" + ex.Message;
            }
        }

        public string daSerieDefeito(string modulo, string tipodoc, DateTime data)
        {
            try
            {
                return bso.Base.Series.DaSerieDefeito(modulo, tipodoc, data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string daUltimoDocumento(string modulo, string tipodoc, string serie)
        {
            try
            {
                return bso.Base.Series.DaValorAtributo(modulo, tipodoc, serie, "Numerador").ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
