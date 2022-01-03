using Primavera.Importacoes.Helpers;
using RhpBE100;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primavera.Importacoes.Services
{
    public class ClsFuncionario : Geral
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

        public void Processar(DataView dt)
        {
            try
            {
                string codigo;

                RhpBEFuncionario _funcionario;

                for (int i = 0; i < dt.Count; i++)
                {
                    DataRowView dr = dt[i];
                    codigo = StringHelper.DaString(dr["Codigo"]);


                    if (codigo.Length > 0 && !bso.RecursosHumanos.Funcionarios.Existe(codigo))
                    {
                        string conta = StringHelper.DaString(dr["NIB/Conta"]);
                        _funcionario = new RhpBEFuncionario()
                        {
                            Funcionario = codigo,
                            Nome = StringHelper.DaString(dr["Nome"]),                            
                            DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]),                            
                            NumeroBI = Convert.ToString(dr["NumeroBI"]),
                            VencimentoMensal = Convert.ToDouble(dr["VencimentoBase"]),
                            Vencimento = Convert.ToDouble(dr["VencimentoBase"]),                            
                            Instrumento = "001",
                            Periodo = "P01",
                            Moeda = bso.Contexto.MoedaBase,
                            TipoProcessamento = 2,
                            TipoCalculoVencimento = 1,
                            TipoRendimento = "A",
                            TabIRPS = "TAB2014",
                            Estabelecimento = Convert.ToString(dr["CodEstabelecimento"]),
                            Situacao = Convert.ToString(dr["SituacaoProfissional"])
                        };

                        bso.RecursosHumanos.Funcionarios.Actualiza(_funcionario);
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
