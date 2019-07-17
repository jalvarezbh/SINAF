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
    public class TSimuladorSubAgregadoPERSISTENCIA
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

        #region [ SalvarSimuladorABAAgregados ]

        public void SalvarSimuladorABAAgregados(Int32 idSimuladorProduto, List<TSimuladorSubAgregadoDOMINIO> dadosSimulador)
        {
            try
            {
                foreach (TSimuladorSubAgregadoDOMINIO item in dadosSimulador)
                {
                    item.IDSimuladorProduto = idSimuladorProduto;
                    IncluirSimuladorSubAgregado(item);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }                
        }

        #endregion

        #region [ IncluirSimuladorSubAgregado ]

        public void IncluirSimuladorSubAgregado(TSimuladorSubAgregadoDOMINIO dadosSimulador)
        {
            try
            {
                StringBuilder queryTabelaSimuladorSubAgregado = new StringBuilder();

                queryTabelaSimuladorSubAgregado.Append(@" INSERT INTO TSimuladorSubAgregado                                                ");
                queryTabelaSimuladorSubAgregado.Append(@"     (  IDSimuladorProduto                                                        ");
                queryTabelaSimuladorSubAgregado.Append(@"     ,  GrauParentesco                                                            ");
                queryTabelaSimuladorSubAgregado.Append(@"     ,  Idade                                                                     ");
                queryTabelaSimuladorSubAgregado.Append(@"     ,  PremioAgregado                                                            ");
                queryTabelaSimuladorSubAgregado.Append(@"     ,  Funeral            )                                                      ");
                queryTabelaSimuladorSubAgregado.Append(@"     VALUES  ( " + dadosSimulador.IDSimuladorProduto + "                          ");
                queryTabelaSimuladorSubAgregado.Append(@"             , '" + dadosSimulador.GrauParentesco + "'                            ");
                queryTabelaSimuladorSubAgregado.Append(@"             , " + dadosSimulador.Idade + "                                       ");
                queryTabelaSimuladorSubAgregado.Append(@"             , " + dadosSimulador.PremioAgregado.ToString().Replace(',', '.') + " ");
                queryTabelaSimuladorSubAgregado.Append(@"             , '" + dadosSimulador.Funeral + "' )                                   ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaSimuladorSubAgregado.ToString(), conn);
                    command.ExecuteNonQuery();
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ SelecioneSimuladorSubAgregado ]

        public DataTable SelecioneSimuladorSubAgregado(Int32 idSimuladorProduto)
        {
            try
            {
                StringBuilder queryTabela = new StringBuilder();

                queryTabela.Append(@" SELECT     IDSimuladorSubAgregado          ");
                queryTabela.Append(@"         ,  IDSimuladorProduto              ");
                queryTabela.Append(@"         ,  GrauParentesco                  ");
                queryTabela.Append(@"         ,  Idade                           ");
                queryTabela.Append(@"         ,  PremioAgregado                  ");
                queryTabela.Append(@"         ,  Funeral                         ");
                queryTabela.Append(@"   FROM   TSimuladorSubAgregado             ");
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
                Util.LogErro.GravaLog("Selecionar registro TSimuladorSubAgregado", ex.Message);
                return new DataTable();
            }
        }

        #endregion
                
        #endregion
    }
}
