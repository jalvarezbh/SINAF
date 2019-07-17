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
    public class TSimuladorSubFuneralPERSISTENCIA
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

        #region [ SalvarSimuladorABAPlanos ]

        public void SalvarSimuladorABAPlanos(string nomeProduto, TSimuladorSubFuneralDOMINIO dadosSimulador)
        {
            try
            {    
                if (nomeProduto.Equals(ProdutoPrincipal.PLANOPROTECAO.GetStringValue()))
                     IncluirSimuladorSubFuneralProtecao(dadosSimulador);

                if (nomeProduto.Equals(ProdutoPrincipal.PLANOSENIOR.GetStringValue()))
                     IncluirSimuladorSubFuneralSenior(dadosSimulador);

                if (nomeProduto.Equals(ProdutoPrincipal.PLANOCASAL.GetStringValue()))
                     IncluirSimuladorSubFuneralCasal(dadosSimulador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ IncluirSimuladorSubFuneralProtecao ]

        public void IncluirSimuladorSubFuneralProtecao(TSimuladorSubFuneralDOMINIO dadosSimulador)
        {
            try
            {
                StringBuilder queryTabelaSimuladorSubFuneral = new StringBuilder();

                string decimalCoberturaAcidente = dadosSimulador.ProtecaoCoberturaAcidente.HasValue ? dadosSimulador.ProtecaoCoberturaAcidente.ToString().Replace(',', '.') : "NULL";
                string decimalCoberturaEmergencia = dadosSimulador.ProtecaoCoberturaEmergencia.HasValue ? dadosSimulador.ProtecaoCoberturaEmergencia.ToString().Replace(',', '.') : "NULL";
                string decimalCoberturaMorte = dadosSimulador.ProtecaoCoberturaMorte.HasValue ? dadosSimulador.ProtecaoCoberturaMorte.ToString().Replace(',', '.') : "NULL";
                string decimalPremio = dadosSimulador.ProtecaoPremio.HasValue ? dadosSimulador.ProtecaoPremio.ToString().Replace(',', '.') : "NULL";

                queryTabelaSimuladorSubFuneral.Append(@" INSERT INTO TSimuladorSubFuneral                                 ");
                queryTabelaSimuladorSubFuneral.Append(@"     (  IDSimuladorProduto                                        ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  ProtecaoCategoria                                         ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  ProtecaoCoberturaAcidente                                 ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  ProtecaoCoberturaEmergencia                               ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  ProtecaoCoberturaMorte                                    ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  ProtecaoPremio         )                                  ");
                queryTabelaSimuladorSubFuneral.Append(@"     VALUES  ( " + dadosSimulador.IDSimuladorProduto + "          ");
                queryTabelaSimuladorSubFuneral.Append(@"             , '" + dadosSimulador.ProtecaoCategoria + "'         ");
                queryTabelaSimuladorSubFuneral.Append(@"             , " + decimalCoberturaAcidente + "                  ");
                queryTabelaSimuladorSubFuneral.Append(@"             , " + decimalCoberturaEmergencia + "                 ");
                queryTabelaSimuladorSubFuneral.Append(@"             , " + decimalCoberturaMorte + "                      ");
                queryTabelaSimuladorSubFuneral.Append(@"             , " + decimalPremio + " )                            ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaSimuladorSubFuneral.ToString(), conn);
                    command.ExecuteNonQuery();
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ IncluirSimuladorSubFuneralCasal ]

        public void IncluirSimuladorSubFuneralCasal(TSimuladorSubFuneralDOMINIO dadosSimulador)
        {
            try
            {
                StringBuilder queryTabelaSimuladorSubFuneral = new StringBuilder();

                string decimalCoberturaConjuge = dadosSimulador.CasalCoberturaConjuge.HasValue ? dadosSimulador.CasalCoberturaConjuge.ToString().Replace(',', '.') : "NULL";
                string decimalCoberturaMorte = dadosSimulador.CasalCoberturaMorte.HasValue ? dadosSimulador.CasalCoberturaMorte.ToString().Replace(',', '.') : "NULL";
                string decimalPremio = dadosSimulador.CasalPremio.HasValue ? dadosSimulador.CasalPremio.ToString().Replace(',', '.') : "NULL";

                queryTabelaSimuladorSubFuneral.Append(@" INSERT INTO TSimuladorSubFuneral                           ");
                queryTabelaSimuladorSubFuneral.Append(@"     (  IDSimuladorProduto                                  ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  CasalCategoria                                      ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  CasalCoberturaConjuge                               ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  CasalCoberturaMorte                                 ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  CasalPremio         )                               ");
                queryTabelaSimuladorSubFuneral.Append(@"     VALUES  ( " + dadosSimulador.IDSimuladorProduto + "    ");
                queryTabelaSimuladorSubFuneral.Append(@"             , '" + dadosSimulador.CasalCategoria + "'      ");
                queryTabelaSimuladorSubFuneral.Append(@"             , " + dadosSimulador.CasalCoberturaConjuge + " ");
                queryTabelaSimuladorSubFuneral.Append(@"             , " + dadosSimulador.CasalCoberturaMorte + "   ");
                queryTabelaSimuladorSubFuneral.Append(@"             , " + dadosSimulador.CasalPremio + " )         ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaSimuladorSubFuneral.ToString(), conn);
                    command.ExecuteNonQuery();
                }               
            }
            catch (Exception ex)
            {
                throw ex;               
            }
        }

        #endregion

        #region [ IncluirSimuladorSubFuneralSenior ]

        public void IncluirSimuladorSubFuneralSenior(TSimuladorSubFuneralDOMINIO dadosSimulador)
        {
            try
            {
                StringBuilder queryTabelaSimuladorSubFuneral = new StringBuilder();

                string decimalCoberturaMorte = dadosSimulador.SeniorCoberturaMorte.HasValue ? dadosSimulador.SeniorCoberturaMorte.ToString().Replace(',', '.') : "NULL";
                string decimalPremio = dadosSimulador.SeniorPremio.HasValue ? dadosSimulador.SeniorPremio.ToString().Replace(',', '.') : "NULL";

                queryTabelaSimuladorSubFuneral.Append(@" INSERT INTO TSimuladorSubFuneral                          ");
                queryTabelaSimuladorSubFuneral.Append(@"     (  IDSimuladorProduto                                 ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  SeniorCategoria                                    ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  SeniorCoberturaMorte                               ");
                queryTabelaSimuladorSubFuneral.Append(@"     ,  SeniorPremio         )                             ");
                queryTabelaSimuladorSubFuneral.Append(@"     VALUES  ( " + dadosSimulador.IDSimuladorProduto + "   ");
                queryTabelaSimuladorSubFuneral.Append(@"             , '" + dadosSimulador.SeniorCategoria + "'    ");
                queryTabelaSimuladorSubFuneral.Append(@"             , " + dadosSimulador.SeniorCoberturaMorte + " ");
                queryTabelaSimuladorSubFuneral.Append(@"             , " + dadosSimulador.SeniorPremio + " )       ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaSimuladorSubFuneral.ToString(), conn);
                    command.ExecuteNonQuery();
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ SelecioneSimuladorSubFuneral ]

        public DataTable SelecioneSimuladorSubFuneral(Int32 idSimuladorProduto)
        {
            try
            {
                StringBuilder queryTabela = new StringBuilder();

                queryTabela.Append(@" SELECT     IDSimuladorSubFuneral           ");
                queryTabela.Append(@"         ,  IDSimuladorProduto              ");
                queryTabela.Append(@"         ,  ProtecaoCoberturaMorte          ");
                queryTabela.Append(@"         ,  ProtecaoCoberturaAcidente       ");
                queryTabela.Append(@"         ,  ProtecaoCoberturaEmergencia     ");
                queryTabela.Append(@"         ,  ProtecaoCategoria               ");
                queryTabela.Append(@"         ,  ProtecaoPremio                  ");
                queryTabela.Append(@"         ,  CasalCoberturaMorte             ");
                queryTabela.Append(@"         ,  CasalCoberturaConjuge           ");
                queryTabela.Append(@"         ,  CasalCategoria                  ");
                queryTabela.Append(@"         ,  CasalPremio                     ");
                queryTabela.Append(@"         ,  SeniorCoberturaMorte            ");
                queryTabela.Append(@"         ,  SeniorCategoria                 ");
                queryTabela.Append(@"         ,  SeniorPremio                    ");
                queryTabela.Append(@"   FROM   TSimuladorSubFuneral              ");
                queryTabela.Append(@"  WHERE   0 = 0                             ");

                if (idSimuladorProduto > 0)
                    queryTabela.Append(@"  AND   IDSimuladorProduto = " + idSimuladorProduto);

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
                Util.LogErro.GravaLog("Selecionar registro TSimuladorSubFuneral", ex.Message);
                return new DataTable();
            }

        }

        #endregion
        
        #endregion
    }
}
