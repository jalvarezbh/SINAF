using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using System.Data;
using ProjetoMobile.Dominio;

namespace ProjetoMobile.Persistencia
{
    public class TParametroPERSISTENCIA
    {
        #region [ CONNECTION ]

        private static string connectionString;

        public static string ConnectionString
        {
            get
            {
                if (connectionString == null)
                    connectionString = @"Data Source = '" + Program.ARQUIVO_DADOS + "';";
                return connectionString;
            }
        }

        #endregion

        #region [ METHODS ]
          
        #region [ SelecioneParametros ]

        public DataTable SelecioneParametros()
        {
            try
            {
                StringBuilder queryTabelaParametros = new StringBuilder();

                queryTabelaParametros.Append(@" SELECT     IDParametro            ");
                queryTabelaParametros.Append(@"         ,  TempoLogOff            ");
                queryTabelaParametros.Append(@"         ,  PrazoSincronismoDia    ");
                queryTabelaParametros.Append(@"         ,  EstoqueMaximoColetor   ");
                queryTabelaParametros.Append(@"         ,  EstoqueMinimoColetor   ");
                queryTabelaParametros.Append(@"   FROM   TParametro               ");
                               
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaParametros.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable("TParametro");
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TParametro", ex.Message);
                return new DataTable();
            }

        }

        #endregion
             

        #endregion
    }
}
