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
    public class ClsPendente : Geral
    {
        public ClsPendente(object BSO) : base(BSO)
        {

        }
        public ClsPendente(object BSO, object Plat) : base(BSO, Plat)
        {

        }

        public ClsPendente(int tipoPlataforma, string strEmpresa, string strUtilizador, string strPassword)
            : base(strUtilizador, strPassword, strEmpresa, tipoPlataforma)
        {

        }

        public void Processar(DataView dt, string tipoEntidade)
        {
            try
            {
                string codigo;
                double valor;

                CctBE100.CctBEPendente _pendentes;

                for (int i = 0; i < dt.Count; i++)
                {
                    DataRowView dr = dt[i];

                    codigo = StringHelper.DaString(dr["Entidade"]);

                    valor = StringHelper.DaDouble(dr["Pendentes"]);

                    _pendentes = new CctBE100.CctBEPendente();

                    _pendentes.Tipodoc = tipoEntidade == "C"? "SAC":"SAF";
                    _pendentes.DataDoc = DateTime.Now;

                    _pendentes.TipoEntidade = tipoEntidade;
                    _pendentes.Serie = bso.Base.Series.DaSerieDefeito("M", _pendentes.Tipodoc, _pendentes.DataDoc);
                    _pendentes.Entidade = codigo;

                    MotorERP().PagamentosRecebimentos.Pendentes.PreencheDadosRelacionados(_pendentes);

                    _pendentes.DataDoc = DateTime.Now;
                    _pendentes.DataVenc = DateTime.Now;
                    _pendentes.DataIntroducao = DateTime.Now;
                    _pendentes.CondPag = "1";
                    _pendentes.Moeda = bso.Contexto.MoedaBase;
                    _pendentes.ValorTotal = valor;
                    _pendentes.ValorPendente = valor;
                    _pendentes.ValorOrig = valor;
                    //_pendentes.CambioMAlt = 0;
                    _pendentes.Cambio = 1;
                    _pendentes.CambioMBase = 1;
                    _pendentes.TotalIva = 0;

                    bso.PagamentosRecebimentos.Pendentes.Actualiza(_pendentes);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
