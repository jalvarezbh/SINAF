using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using System.Data;
 
namespace ProjetoMobile.Persistencia
{
    public class TUsuarioPERSISTENCIA
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

        #region [ LoginVerificar ]

        public bool LoginVerificar(string usuario)
        {
            try
            {

                StringBuilder queryTabelaUsuario = new StringBuilder();

                queryTabelaUsuario.Append(@" SELECT   IDUsuario                  ");
                queryTabelaUsuario.Append(@"        , Nome                       ");
                queryTabelaUsuario.Append(@"        , Login                      ");
                queryTabelaUsuario.Append(@"        , Senha                      ");
                queryTabelaUsuario.Append(@"        , IDPerfil                   ");
                queryTabelaUsuario.Append(@"        , Email                      ");
                queryTabelaUsuario.Append(@"        , CodigoColaborador          ");
                queryTabelaUsuario.Append(@"        , Unidade                    ");
                queryTabelaUsuario.Append(@"   FROM   TUsuario                   ");
                queryTabelaUsuario.Append(@"  WHERE   Login = '" + usuario + "'  ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaUsuario.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    if (dadosTable.Rows.Count > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region [ LoginSistema ]

        public bool LoginSistema(string usuario, string senha)
        {            
            StringBuilder queryTabelaUsuario = new StringBuilder();

            senha = Util.HashMD5.GeraHashMD5(senha);

            queryTabelaUsuario.Append(@" SELECT   IDUsuario                  ");
            queryTabelaUsuario.Append(@"        , Nome                       ");
            queryTabelaUsuario.Append(@"        , Login                      ");
            queryTabelaUsuario.Append(@"        , Senha                      ");
            queryTabelaUsuario.Append(@"        , IDPerfil                   ");
            queryTabelaUsuario.Append(@"        , Email                      ");
            queryTabelaUsuario.Append(@"        , CodigoColaborador          ");
            queryTabelaUsuario.Append(@"        , Unidade                    ");
            queryTabelaUsuario.Append(@"   FROM   TUsuario                   ");
            queryTabelaUsuario.Append(@"  WHERE   Login = '" + usuario + "'  ");
            queryTabelaUsuario.Append(@"    AND   Senha = '" + senha + "'    ");
            
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaUsuario.ToString(),conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable();
                dadosTable.Load(dados);

                if (dadosTable.Rows.Count > 0)
                {
                    Program.Usuario = dadosTable.Rows[0]["Nome"].ToString();
                    Program.IDUsuario = Convert.ToInt32(dadosTable.Rows[0]["IDUsuario"].ToString());
                    Program.CodigoColaborador = Convert.ToInt32(dadosTable.Rows[0]["CodigoColaborador"].ToString());
                    return true;
                }
                else
                    return false;
            }
        }

        #endregion

        #endregion
    }
}
