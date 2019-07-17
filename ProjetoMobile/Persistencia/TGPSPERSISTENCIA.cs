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
    public class TGPSPERSISTENCIA
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

        #region [ GravarGPS ]

        public bool GravarGPS(TGPSDOMINIO dadosGPS)
        {            
            try
            {
                StringBuilder queryTabelaGPS = new StringBuilder();

                queryTabelaGPS.Append(@" INSERT INTO TGPS                                                ");
                queryTabelaGPS.Append(@"     (  CodigoEntrevista                                         ");
                queryTabelaGPS.Append(@"     ,  Latitude                                                 ");
                queryTabelaGPS.Append(@"     ,  Longitude                                                ");
                queryTabelaGPS.Append(@"     ,  DataCadastro   )                                         ");
                queryTabelaGPS.Append(@"     VALUES  ( " + dadosGPS.CodigoEntrevista + "                 ");
                queryTabelaGPS.Append(@"             , '" + dadosGPS.Latitude + "'                       ");
                queryTabelaGPS.Append(@"             , '" + dadosGPS.Longitude + "'                      ");
                queryTabelaGPS.Append(@"             , '" + dadosGPS.DataCadastro.ToString("s") + "'  )  ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaGPS.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Incluir registro TGPS", ex.Message);
                return false;
            }
        }

        #endregion

        #region [ SelecioneGPS ]

        public DataTable SelecioneGPS(Int64 codigoEntrevista)
        {
            try
            {
                StringBuilder queryTabelaGPS = new StringBuilder();

                queryTabelaGPS.Append(@" SELECT     IDGPS                           ");
                queryTabelaGPS.Append(@"         ,  CodigoEntrevista                ");
                queryTabelaGPS.Append(@"         ,  Latitude                        ");
                queryTabelaGPS.Append(@"         ,  Longitude                       ");
                queryTabelaGPS.Append(@"         ,  DataCadastro                    ");
                queryTabelaGPS.Append(@"   FROM   TGPS                              ");
                queryTabelaGPS.Append(@"  WHERE   0 = 0                             ");

                if (codigoEntrevista > 0)
                    queryTabelaGPS.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaGPS.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TGPS", ex.Message);
                return new DataTable();
            }

        }

        #endregion
                
        #endregion
    }
}
