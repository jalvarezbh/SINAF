using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using System.Data;
using ProjetoMobile.Dominio;
using ProjetoMobile.Util;

namespace ProjetoMobile.Persistencia
{
    public class TEntrevistadoEnderecoPERSISTENCIA
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

        #region [ IncluirEntrevistadoEndereco ]

        public bool IncluirEntrevistadoEndereco(TEntrevistadoEnderecoDOMINIO dadosEntrevistadoEndereco)
        {
            try
            {
                StringBuilder queryTabelaEndereco = new StringBuilder();

                if (dadosEntrevistadoEndereco.Endereco.Length > 50)
                    dadosEntrevistadoEndereco.Endereco = dadosEntrevistadoEndereco.Endereco.Substring(0, 49);

                if (dadosEntrevistadoEndereco.Bairro.Length > 50)
                    dadosEntrevistadoEndereco.Bairro = dadosEntrevistadoEndereco.Bairro.Substring(0, 49);

                if (dadosEntrevistadoEndereco.Cidade.Length > 50)
                    dadosEntrevistadoEndereco.Cidade = dadosEntrevistadoEndereco.Cidade.Substring(0, 49);

                if (dadosEntrevistadoEndereco.CEP.Length > 8)
                    dadosEntrevistadoEndereco.CEP = dadosEntrevistadoEndereco.CEP.Substring(0, 8);

                queryTabelaEndereco.Append(@" INSERT INTO TEntrevistadoEndereco                                     ");
                queryTabelaEndereco.Append(@"     (  CodigoEntrevista                                               ");
                queryTabelaEndereco.Append(@"     ,  Endereco                                                       ");
                queryTabelaEndereco.Append(@"     ,  Numero                                                         ");
                queryTabelaEndereco.Append(@"     ,  Bairro                                                         ");
                queryTabelaEndereco.Append(@"     ,  Cidade                                                         ");
                queryTabelaEndereco.Append(@"     ,  UF                                                             ");
                queryTabelaEndereco.Append(@"     ,  CEP                                                            ");
                queryTabelaEndereco.Append(@"     ,  Complemento                                                    ");
                queryTabelaEndereco.Append(@"     ,  Email   )                                                      ");
                queryTabelaEndereco.Append(@"     VALUES  ( " + dadosEntrevistadoEndereco.CodigoEntrevista + "      ");
                queryTabelaEndereco.Append(@"             , '" + dadosEntrevistadoEndereco.Endereco + "'            ");
                queryTabelaEndereco.Append(@"             , " + dadosEntrevistadoEndereco.Numero + "                ");
                queryTabelaEndereco.Append(@"             , '" + dadosEntrevistadoEndereco.Bairro + "'              ");
                queryTabelaEndereco.Append(@"             , '" + dadosEntrevistadoEndereco.Cidade + "'              ");
                queryTabelaEndereco.Append(@"             , '" + dadosEntrevistadoEndereco.UF + "'                  ");
                queryTabelaEndereco.Append(@"             , '" + dadosEntrevistadoEndereco.CEP + "'                 ");
                queryTabelaEndereco.Append(@"             , '" + dadosEntrevistadoEndereco.Complemento + "'         ");
                queryTabelaEndereco.Append(@"             , '" + dadosEntrevistadoEndereco.Email + "' )             ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEndereco.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Incluir registro TEntrevistadoEndereco", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ AlterarEntrevistadoEndereco ]

        public bool AlterarEntrevistadoEndereco(TEntrevistadoEnderecoDOMINIO dadosEntrevistadoEndereco)
        {
            try
            {
                StringBuilder queryTabelaEndereco = new StringBuilder();

                dadosEntrevistadoEndereco.Endereco = new Mask().RemoverCaracter(dadosEntrevistadoEndereco.Endereco, 50);

                dadosEntrevistadoEndereco.Bairro = new Mask().RemoverCaracter(dadosEntrevistadoEndereco.Bairro, 50);

                dadosEntrevistadoEndereco.Cidade = new Mask().RemoverCaracter(dadosEntrevistadoEndereco.Cidade, 50);

                dadosEntrevistadoEndereco.CEP = new Mask().RemoverCaracter(dadosEntrevistadoEndereco.CEP, 9);
              
                queryTabelaEndereco.Append(@" UPDATE TEntrevistadoEndereco                                          ");
                queryTabelaEndereco.Append(@"    SET Endereco = '" + dadosEntrevistadoEndereco.Endereco + "'        ");
                queryTabelaEndereco.Append(@"     ,  Numero  = " + dadosEntrevistadoEndereco.Numero + "             ");
                queryTabelaEndereco.Append(@"     ,  Bairro = '" + dadosEntrevistadoEndereco.Bairro + "'            ");
                queryTabelaEndereco.Append(@"     ,  Cidade = '" + dadosEntrevistadoEndereco.Cidade + "'            ");
                queryTabelaEndereco.Append(@"     ,  UF = '" + dadosEntrevistadoEndereco.UF + "'                    ");
                queryTabelaEndereco.Append(@"     ,  CEP = '" + dadosEntrevistadoEndereco.CEP + "'                  ");
                queryTabelaEndereco.Append(@"     ,  Complemento = '" + dadosEntrevistadoEndereco.Complemento + "'  ");
                queryTabelaEndereco.Append(@"     ,  Email = '" + dadosEntrevistadoEndereco.Email + "'              ");
                queryTabelaEndereco.Append(@"  WHERE   0 = 0                                                        ");

                if (dadosEntrevistadoEndereco.CodigoEntrevista > 0)
                    queryTabelaEndereco.Append(@"  AND   CodigoEntrevista = " + dadosEntrevistadoEndereco.CodigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEndereco.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Alterar registro TEntrevistadoEndereco", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ SelecioneEntrevistadoEndereco ]

        public DataTable SelecioneEntrevistadoEndereco(Int64 codigoEntrevista)
        {
            try
            {
                StringBuilder queryTabelaEndereco = new StringBuilder();

                queryTabelaEndereco.Append(@" SELECT     IDEntrevistadoEndereco          ");
                queryTabelaEndereco.Append(@"         ,  CodigoEntrevista                ");
                queryTabelaEndereco.Append(@"         ,  Endereco                        ");
                queryTabelaEndereco.Append(@"         ,  Numero                          ");
                queryTabelaEndereco.Append(@"         ,  Bairro                          ");
                queryTabelaEndereco.Append(@"         ,  Cidade                          ");
                queryTabelaEndereco.Append(@"         ,  UF                              ");
                queryTabelaEndereco.Append(@"         ,  CEP                             ");
                queryTabelaEndereco.Append(@"         ,  Complemento                     ");
                queryTabelaEndereco.Append(@"         ,  Email                           ");
                queryTabelaEndereco.Append(@"   FROM   TEntrevistadoEndereco             ");
                queryTabelaEndereco.Append(@"  WHERE   0 = 0                             ");
                
                if (codigoEntrevista > 0)
                    queryTabelaEndereco.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEndereco.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable("TEntrevistadoEndereco");
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TEntrevistadoEndereco", ex.Message);
                return new DataTable();
            }

        }

        #endregion

        #region [ SelecioneUltimoEndereco ]

        public DataTable SelecioneUltimoEndereco()
        {
            try
            {
                StringBuilder queryTabelaEndereco = new StringBuilder();

                queryTabelaEndereco.Append(@" SELECT     IDEntrevistadoEndereco          ");
                queryTabelaEndereco.Append(@"         ,  CodigoEntrevista                ");
                queryTabelaEndereco.Append(@"         ,  Endereco                        ");
                queryTabelaEndereco.Append(@"         ,  Numero                          ");
                queryTabelaEndereco.Append(@"         ,  Bairro                          ");
                queryTabelaEndereco.Append(@"         ,  Cidade                          ");
                queryTabelaEndereco.Append(@"         ,  UF                              ");
                queryTabelaEndereco.Append(@"         ,  CEP                             ");
                queryTabelaEndereco.Append(@"         ,  Complemento                     ");
                queryTabelaEndereco.Append(@"         ,  Email                           ");
                queryTabelaEndereco.Append(@"   FROM   TEntrevistadoEndereco             ");
                queryTabelaEndereco.Append(@"  WHERE   Endereco != ''                    ");
                queryTabelaEndereco.Append(@" ORDER BY  IDEntrevistadoEndereco DESC      ");
                                
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEndereco.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable("TEntrevistadoEndereco");
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TEntrevistadoEndereco", ex.Message);
                return new DataTable();
            }

        }

        #endregion

        #endregion
    }
}
