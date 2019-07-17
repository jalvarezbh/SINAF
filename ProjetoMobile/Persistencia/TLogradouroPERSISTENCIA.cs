using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using ProjetoMobile.Dominio;
using System.Data;
using System.IO;

namespace ProjetoMobile.Persistencia
{
    public class TLogradouroPERSISTENCIA
    {
        #region [ CONNECTION ]

        private static string connectionString;

        public static string ConnectionString
        {
            get
            {
                if (connectionString == null)
                    connectionString = @"Data Source = '" + Program.ARQUIVO_CORREIO + "';";
                return connectionString;
            }
        }

        #endregion

        #region [ METHODS ]

        #region [ PesquisaCEP ]

        public DataTable PesquisaCEP(int pesquisaCEP)
        {
            FileInfo bancoCorreio = new FileInfo(Program.ARQUIVO_CORREIO);
            if (bancoCorreio.Exists)
            {
                StringBuilder queryTabelaLogradouro = new StringBuilder();

                queryTabelaLogradouro.Append(@" SELECT   NomeLogradouro                                            ");
                queryTabelaLogradouro.Append(@"        , NomeBairro                                                ");
                queryTabelaLogradouro.Append(@"        , NomeCidade                                                ");
                queryTabelaLogradouro.Append(@"        , TEstado.IDEstado                                          ");
                queryTabelaLogradouro.Append(@"   FROM   TLogradouro                                               ");
                queryTabelaLogradouro.Append(@"   INNER JOIN TBairro ON TBairro.IDBairro = TLogradouro.IDBairro    ");
                queryTabelaLogradouro.Append(@"   INNER JOIN TCidade ON TCidade.IDCidade = TLogradouro.IDCidade    ");
                queryTabelaLogradouro.Append(@"   INNER JOIN TEstado ON TEstado.IDEstado = TCidade.IDEstado        ");
                queryTabelaLogradouro.Append(@"   WHERE CEP = " + pesquisaCEP.ToString() + "                       ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaLogradouro.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            else
            {
                DataTable dadosTable = new DataTable("TLogradouro");
                return dadosTable;
            }
        }

        #endregion

        #endregion
    }
}
