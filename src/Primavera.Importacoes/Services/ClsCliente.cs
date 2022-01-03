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
    public class ClsCliente : Geral
    {
        public ClsCliente(object BSO) : base(BSO)
        {

        }
        public ClsCliente(object BSO, object Plat) : base(BSO, Plat)
        {

        }

        public ClsCliente(int tipoPlataforma, string strEmpresa, string strUtilizador, string strPassword)
            : base(strUtilizador, strPassword, strEmpresa, tipoPlataforma)
        {

        }

        public void Processar(DataView dt)
        {
            try
            {
                string codigo;

                BasBECliente _cliente;

                for (int i = 0; i < dt.Count; i++)
                {
                    DataRowView dr = dt[i];
                    codigo = StringHelper.DaString(dr["Codigo"]);


                    if (codigo.Length > 0 && !bso.Base.Clientes.Existe(codigo))
                    {
                        string conta = StringHelper.DaString(dr["NIB/Conta"]);
                        _cliente = new BasBECliente()
                        {
                            Cliente = codigo,
                            Nome = StringHelper.DaString(dr["Nome"]),                            
                            //DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]),                            
                            //NumeroBI = Convert.ToString(dr["NumeroBI"]),
                            //VencimentoMensal = Convert.ToDouble(dr["VencimentoBase"]),
                            //Vencimento = Convert.ToDouble(dr["VencimentoBase"]),                            
                            //Instrumento = "001",
                            //Periodo = "P01",
                            //Moeda = bso.Contexto.MoedaBase,
                            //TipoProcessamento = 2,
                            //TipoCalculoVencimento = 1,
                            //TipoRendimento = "A",
                            //TabIRPS = "TAB2014",
                            //Estabelecimento = Convert.ToString(dr["CodEstabelecimento"]),
                            //Situacao = Convert.ToString(dr["SituacaoProfissional"])
                        };

                        //bso.RecursosHumanos.Funcionarios.Actualiza(_funcionario);
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
