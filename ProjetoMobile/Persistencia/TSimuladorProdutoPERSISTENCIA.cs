using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using System.Data;
using ProjetoMobile.Dominio;
using ProjetoMobile.Dominio.Enumeradores;

namespace ProjetoMobile.Persistencia
{
    public class TSimuladorProdutoPERSISTENCIA
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

        #region [ SalvarSimuladorProduto ]

        public void SalvarSimuladorProduto(TSimuladorProdutoDOMINIO dadosSimulador)
        {
            try
            {
                AlterarTipoRegistro(dadosSimulador.IDEntrevista);
                
                IncluirSimuladorProduto(dadosSimulador);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        
        #region [ IncluirSimuladorProduto ]

        public void IncluirSimuladorProduto(TSimuladorProdutoDOMINIO dadosSimulador)
        {
            try
            {
                StringBuilder queryTabelaSimuladorProduto = new StringBuilder();

                queryTabelaSimuladorProduto.Append(@" INSERT INTO TSimuladorProduto                                                 ");
                queryTabelaSimuladorProduto.Append(@"     (  IDEntrevista                                                           ");
                queryTabelaSimuladorProduto.Append(@"     ,  Produto                                                                ");
                queryTabelaSimuladorProduto.Append(@"     ,  PremioTotal                                                            ");
                queryTabelaSimuladorProduto.Append(@"     ,  FaixaEtaria                                                            ");
                queryTabelaSimuladorProduto.Append(@"     ,  FaixaEtariaConjuge                                                     ");
                queryTabelaSimuladorProduto.Append(@"     ,  RespostaBaseRenda                                                      ");
                queryTabelaSimuladorProduto.Append(@"     ,  RespostaBaseDisposto                                                   ");
                queryTabelaSimuladorProduto.Append(@"     ,  TipoRegistro         )                                                 ");
                queryTabelaSimuladorProduto.Append(@"     VALUES  ( " + dadosSimulador.IDEntrevista + "                             ");
                queryTabelaSimuladorProduto.Append(@"             , '" + dadosSimulador.Produto + "'                                ");
                queryTabelaSimuladorProduto.Append(@"             , " + dadosSimulador.PremioTotal.ToString().Replace(',','.') + "  ");
                queryTabelaSimuladorProduto.Append(@"             , " + dadosSimulador.FaixaEtaria + "                              ");
                queryTabelaSimuladorProduto.Append(@"             , " + dadosSimulador.FaixaEtariaConjuge + "                       ");
                queryTabelaSimuladorProduto.Append(@"             , " + dadosSimulador.RespostaBaseRenda + "                        ");
                queryTabelaSimuladorProduto.Append(@"             , " + dadosSimulador.RespostaBaseDisposto + "                     ");
                queryTabelaSimuladorProduto.Append(@"             , '" + dadosSimulador.TipoRegistro + "')                          ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaSimuladorProduto.ToString(), conn);
                    command.ExecuteNonQuery();
                }                
            }
            catch (Exception ex)
            {
                throw ex;               
            }
        }

        #endregion

        #region [ AlterarTipoRegistro ]

        public void AlterarTipoRegistro(long idEntrevista)
        {
            try
            {
                StringBuilder queryTabelaSimuladorProduto = new StringBuilder();

                queryTabelaSimuladorProduto.Append(@" UPDATE TSimuladorProduto                   ");
                queryTabelaSimuladorProduto.Append(@"    SET TipoRegistro = 'H'                  ");
                queryTabelaSimuladorProduto.Append(@"  WHERE IDEntrevista = " + idEntrevista + " ");
                queryTabelaSimuladorProduto.Append(@"    AND TipoRegistro = 'A'                  ");
                
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaSimuladorProduto.ToString(), conn);
                    command.ExecuteNonQuery();
                }                
            }
            catch (Exception ex)
            {
                throw ex;               
            }
        }

        #endregion

        #region [ SelecioneSimuladorProduto ]

        public DataTable SelecioneSimuladorProduto(Int64 codigoEntrevista)
        {
            try
            {
                StringBuilder queryTabelaSimuladorProduto = new StringBuilder();

                queryTabelaSimuladorProduto.Append(@" SELECT     IDSimuladorProduto              ");
                queryTabelaSimuladorProduto.Append(@"         ,  IDEntrevista                    ");
                queryTabelaSimuladorProduto.Append(@"         ,  Produto                         ");
                queryTabelaSimuladorProduto.Append(@"         ,  PremioTotal                     ");
                queryTabelaSimuladorProduto.Append(@"         ,  FaixaEtaria                     ");
                queryTabelaSimuladorProduto.Append(@"         ,  FaixaEtariaConjuge              ");
                queryTabelaSimuladorProduto.Append(@"         ,  RespostaBaseRenda               ");
                queryTabelaSimuladorProduto.Append(@"         ,  RespostaBaseDisposto            ");
                queryTabelaSimuladorProduto.Append(@"         ,  TipoRegistro                    ");
                queryTabelaSimuladorProduto.Append(@"   FROM   TSimuladorProduto                 ");
                queryTabelaSimuladorProduto.Append(@"  WHERE   0 = 0                             ");

                if (codigoEntrevista > 0)
                    queryTabelaSimuladorProduto.Append(@"  AND   IDEntrevista = " + codigoEntrevista);

                queryTabelaSimuladorProduto.Append(@"  ORDER BY IDSimuladorProduto DESC          ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaSimuladorProduto.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TSimuladorProduto", ex.Message);
                return new DataTable();
            }
        }

        #endregion
        
        #endregion
    }
}
