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
    public class TSimuladorSubRendaPERSISTENCIA
    {
        #region [ PERSISTENCE ]

        private TSimuladorProdutoPERSISTENCIA _TSimuladorProdutoPERSISTENCIA;

        public TSimuladorProdutoPERSISTENCIA TSimuladorProdutoPERSISTENCIA
        {
            get
            {
                if (_TSimuladorProdutoPERSISTENCIA == null)
                    _TSimuladorProdutoPERSISTENCIA = new TSimuladorProdutoPERSISTENCIA();

                return _TSimuladorProdutoPERSISTENCIA;

            }
        }

        #endregion

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

        #region [ SalvarSimuladorABARenda ]

        public void SalvarSimuladorABARenda(TSimuladorSubRendaDOMINIO dadosSimulador)
        {
            try
            {
                IncluirSimuladorSubRenda(dadosSimulador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ IncluirSimuladorSubRenda ]

        public void IncluirSimuladorSubRenda(TSimuladorSubRendaDOMINIO dadosSimulador)
        {
            try
            {
                StringBuilder queryTabelaSimuladorSubRenda = new StringBuilder();

                queryTabelaSimuladorSubRenda.Append(@" INSERT INTO TSimuladorSubRenda                                                   ");
                queryTabelaSimuladorSubRenda.Append(@"     (  IDSimuladorProduto                                                        ");
                queryTabelaSimuladorSubRenda.Append(@"     ,  Periodo                                                                   ");
                queryTabelaSimuladorSubRenda.Append(@"     ,  ValorRenda                                                                ");
                queryTabelaSimuladorSubRenda.Append(@"     ,  Capital                                                                   ");
                queryTabelaSimuladorSubRenda.Append(@"     ,  PremioRenda         )                                                     ");
                queryTabelaSimuladorSubRenda.Append(@"     VALUES  ( " + dadosSimulador.IDSimuladorProduto + "                          ");
                queryTabelaSimuladorSubRenda.Append(@"             , '" + dadosSimulador.Periodo + "'                                   ");
                queryTabelaSimuladorSubRenda.Append(@"             , " + dadosSimulador.ValorRenda.ToString().Replace(',', '.') + "     ");
                queryTabelaSimuladorSubRenda.Append(@"             , " + dadosSimulador.Capital.ToString().Replace(',', '.') + "        ");
                queryTabelaSimuladorSubRenda.Append(@"             , " + dadosSimulador.PremioRenda.ToString().Replace(',', '.') + " )  ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaSimuladorSubRenda.ToString(), conn);
                    command.ExecuteNonQuery();
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ SelecioneSimuladorSubRenda ]

        public DataTable SelecioneSimuladorSubRenda(Int32 idSimuladorProduto)
        {
            try
            {
                StringBuilder queryTabela = new StringBuilder();

                queryTabela.Append(@" SELECT     IDSimuladorSubRenda             ");
                queryTabela.Append(@"         ,  IDSimuladorProduto              ");
                queryTabela.Append(@"         ,  Periodo                         ");
                queryTabela.Append(@"         ,  ValorRenda                      ");
                queryTabela.Append(@"         ,  Capital                         ");
                queryTabela.Append(@"         ,  PremioRenda                     ");
                queryTabela.Append(@"   FROM   TSimuladorSubRenda                ");
                queryTabela.Append(@"  WHERE   IDSimuladorProduto = " + idSimuladorProduto);


                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabela.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TSimuladorSubRenda", ex.Message);
                return new DataTable();
            }

        }

        #endregion
                
        #endregion
    }
}
