using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using System.Data;

namespace ProjetoMobile.Persistencia
{
    public class TFaixaPERSISTENCIA
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

        #region [ VerificarFaixa ]

        public bool VerificarFaixa()
        {
            try
            {
                StringBuilder queryTabelaFaixa = new StringBuilder();

                queryTabelaFaixa.Append(@" SELECT   IDFaixa                    ");
                queryTabelaFaixa.Append(@"        , CodigoFaixa                ");
                queryTabelaFaixa.Append(@"        , Usado                      ");
                queryTabelaFaixa.Append(@"        , IDResponsavel              ");
                queryTabelaFaixa.Append(@"   FROM   TFaixa                     ");
                queryTabelaFaixa.Append(@"  WHERE   Usado = 'false'            ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaFaixa.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    Program.CountFaixa = dadosTable.Rows.Count;

                    if (dadosTable.Rows.Count > 0)
                    {
                        Program.CodigoFaixa = Convert.ToInt64(dadosTable.Rows[0]["CodigoFaixa"].ToString());
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Verificar registro TFaixa", ex.Message);
                return false;
            }
        }

        #endregion

        #region [ UtilizarFaixa ]

        public bool UtilizarFaixa(Int64 codigoFaixa)
        {
            try
            {
                StringBuilder queryTabelaFaixa = new StringBuilder();

                queryTabelaFaixa.Append(@" UPDATE TFaixa                             ");
                queryTabelaFaixa.Append(@"    SET Usado = 'true'                     ");
                queryTabelaFaixa.Append(@"  WHERE CodigoFaixa = " + codigoFaixa + "  ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaFaixa.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Alterar registro TFaixa", ex.Message);
                return false;
            }
        }

        #endregion

        #region [ VerificarFaixaEntrevistaAntiga ]

        public bool VerificarFaixaEntrevistaAntiga(Int64 codigoEntrevista)
        {
            try
            {
                StringBuilder queryTabelaFaixa = new StringBuilder();

                queryTabelaFaixa.Append(@" SELECT   IDFaixa                                 ");
                queryTabelaFaixa.Append(@"        , CodigoFaixa                             ");
                queryTabelaFaixa.Append(@"   FROM   TFaixa                                  ");
                queryTabelaFaixa.Append(@"  WHERE   CodigoFaixa = " + codigoEntrevista + "  ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaFaixa.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    return dadosTable.Rows.Count == 0;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Verificar registro TFaixa", ex.Message);
                return false;
            }
        }

        #endregion

        #endregion
    }
}
