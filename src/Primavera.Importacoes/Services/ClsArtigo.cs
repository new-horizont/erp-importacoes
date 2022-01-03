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
    public class ClsArtigo : Geral
    {
        public ClsArtigo(object BSO) : base(BSO)
        {

        }
        public ClsArtigo(object BSO, object Plat) : base(BSO, Plat)
        {

        }

        public ClsArtigo(int tipoPlataforma, string strEmpresa, string strUtilizador, string strPassword)
            : base(strUtilizador, strPassword, strEmpresa, tipoPlataforma)
        {

        }

        public void Processar(DataView dt)
        {
            try
            {
                string codigo;

                BasBEArtigo _artigo;

                for (int i = 0; i < dt.Count; i++)
                {
                    DataRowView dr = dt[i];
                    codigo = StringHelper.DaString(dr["Artigo"]);

                    if (codigo.Length > 0 && !bso.Base.Artigos.Existe(codigo))
                    {
                        _artigo = new BasBEArtigo()
                        {
                            Artigo = codigo,
                            Descricao = StringHelper.DaString(dr["Descricao"]),                            
                            TipoArtigo = "3",
                            UnidadeVenda = StringHelper.DaString(dr["UnidadeVenda"]),
                            UnidadeBase = StringHelper.DaString(dr["UnidadeBase"]),
                            IVA = StringHelper.DaString(dr["Iva"]),
                            MovStock = StringHelper.DaString(dr["MovStock"]),
                            UnidadeCompra = StringHelper.DaString(dr["UnidadeCompra"]),
                            UnidadeEntrada = StringHelper.DaString(dr["UnidadeEntrada"]),
                            UnidadeSaida = StringHelper.DaString(dr["UnidadeSaida"]),
                            SujeitoDevolucao = true,
                            Anulado = false,
                            DeduzIVA = true,
                            PercIncidenciaIVA =100,
                            PercIvaDedutivel =100,
                            Familia =  StringHelper.DaString(dr["Familia"]),
                            SubFamilia = StringHelper.DaString(dr["SubFamilia"]),
                            ArmazemSugestao = StringHelper.DaString(dr["ArmazemSugestao"]),
                            LocalizacaoSugestao = StringHelper.DaString(dr["ArmazemSugestao"])
                        };

                        BasBEArtigoMoeda _moeda = new BasBEArtigoMoeda()
                        {
                            Artigo = _artigo.Artigo,
                            Moeda = bso.Contexto.MoedaBase,
                            Unidade = _artigo.UnidadeBase,
                            PVP1 = StringHelper.DaDouble(dr["PVP1"]),
                            PVP2 = StringHelper.DaDouble(dr["PVP2"]),
                            PVP3 = StringHelper.DaDouble(dr["PVP3"]),
                            PVP4 = StringHelper.DaDouble(dr["PVP4"]),
                            PVP5 = StringHelper.DaDouble(dr["PVP5"]),
                            PVP6 = StringHelper.DaDouble(dr["PVP6"]),
                        };

                        bso.Base.Artigos.Actualiza(_artigo);
                        bso.Base.ArtigosPrecos.Actualiza(_moeda);
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
