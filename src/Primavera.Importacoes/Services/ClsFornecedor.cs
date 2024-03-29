﻿using BasBE100;
using Primavera.Importacoes.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primavera.Importacoes.Services
{
    public class ClsFornecedor : Geral
    {
        public ClsFornecedor(object BSO) : base(BSO)
        {

        }
        public ClsFornecedor(object BSO, object Plat) : base(BSO, Plat)
        {

        }

        public ClsFornecedor(int tipoPlataforma, string strEmpresa, string strUtilizador, string strPassword)
            : base(strUtilizador, strPassword, strEmpresa, tipoPlataforma)
        {

        }

        public void Processar(DataView dt)
        {
            try
            {
                string codigo;

                BasBEFornecedor _fornecedor;

                for (int i = 0; i < dt.Count; i++)
                {
                    DataRowView dr = dt[i];
                    codigo = StringHelper.DaString(dr["Fornecedor"]);


                    if (codigo.Length > 0 && !bso.Base.Fornecedores.Existe(codigo))
                    {
                        _fornecedor = new BasBEFornecedor()
                        {
                            Fornecedor = codigo,
                            Nome = StringHelper.DaString(dr["Nome"]),
                            NomeFiscal = StringHelper.DaString(dr["Nome"]),
                            Morada = StringHelper.DaString(dr["Morada"]),
                            Localidade = StringHelper.DaString(dr["Localidade"]),
                            NumContribuinte = StringHelper.DaString(dr["Nuit"]),
                            Moeda = StringHelper.DaString(dr["Moeda"]),
                            CondPag = StringHelper.DaString(dr["CondPag"])
                        };

                        bso.Base.Fornecedores.Actualiza(_fornecedor);
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
