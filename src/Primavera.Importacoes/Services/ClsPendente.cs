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
                    codigo = StringHelper.DaString(dr["Cliente"]);


                    if (codigo.Length > 0 && !bso.Base.Clientes.Existe(codigo))
                    {                        
                        _cliente = new BasBECliente()
                        {
                            Cliente = codigo,
                            Nome = StringHelper.DaString(dr["Nome"]),
                            NomeFiscal = StringHelper.DaString(dr["Nome"]),
                            Morada = StringHelper.DaString(dr["Morada"]),
                            Localidade = StringHelper.DaString(dr["Localidade"]),
                            NumContribuinte = StringHelper.DaString(dr["Nuit"]),                            
                            Moeda = StringHelper.DaString(dr["Moeda"]),
                            CondPag = StringHelper.DaString(dr["CondPag"])
                        };

                        bso.Base.Clientes.Actualiza(_cliente);
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
