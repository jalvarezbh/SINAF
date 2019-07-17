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
    public class TRespostaPERSISTENCIA
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

        #region [ IncluirResposta ]

        public bool IncluirResposta(TRespostaDOMINIO dadosResposta)
        {
            try
            {
                StringBuilder queryTabelaResposta = new StringBuilder();

                queryTabelaResposta.Append(@" INSERT INTO TResposta                                         ");
                queryTabelaResposta.Append(@"     (  CodigoEntrevista                                       ");
                queryTabelaResposta.Append(@"     ,  CodigoPergunta                                         ");
                queryTabelaResposta.Append(@"     ,  CodigoOpcao                                            ");
                queryTabelaResposta.Append(@"     ,  CodigoSeqResposta                                      ");
                queryTabelaResposta.Append(@"     ,  TextoResposta                                          ");
                queryTabelaResposta.Append(@"     ,  TextoSubResposta    )                                  ");
                queryTabelaResposta.Append(@"     VALUES  ( " + dadosResposta.CodigoEntrevista + "          ");
                queryTabelaResposta.Append(@"             , " + dadosResposta.CodigoPergunta + "            ");
                queryTabelaResposta.Append(@"             , " + dadosResposta.CodigoOpcao + "               ");
                queryTabelaResposta.Append(@"             , " + dadosResposta.CodigoSeqPergunta + "         ");
                queryTabelaResposta.Append(@"             , '" + dadosResposta.TextoResposta + "'           ");
                queryTabelaResposta.Append(@"             , '" + dadosResposta.TextoSubResposta + "' )      ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaResposta.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Incluir registro TResposta", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ AlterarResposta ]

        public bool AlterarResposta(TRespostaDOMINIO dadosResposta)
        {
            try
            {
                StringBuilder queryTabelaResposta = new StringBuilder();

                queryTabelaResposta.Append(@" UPDATE TResposta SET                                           ");
                queryTabelaResposta.Append(@"     CodigoOpcao = " + dadosResposta.CodigoOpcao + "            ");
                queryTabelaResposta.Append(@"   , CodigoSeqResposta = " + dadosResposta.CodigoSeqPergunta +" ");
                queryTabelaResposta.Append(@"   , TextoResposta = '" + dadosResposta.TextoResposta + "'      ");
                queryTabelaResposta.Append(@"   , TextoSubResposta = '" + dadosResposta.TextoSubResposta + "'");

                queryTabelaResposta.Append(@"  WHERE CodigoEntrevista = " + dadosResposta.CodigoEntrevista);
                queryTabelaResposta.Append(@"  AND   CodigoPergunta = " + dadosResposta.CodigoPergunta);


                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaResposta.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Alterar registro TResposta", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ SelecioneResposta ]

        public DataTable SelecioneResposta(Int64 codigoEntrevista)
        {
            try
            {
                StringBuilder queryTabelaResposta = new StringBuilder();

                queryTabelaResposta.Append(@" SELECT     IDResposta                      ");
                queryTabelaResposta.Append(@"         ,  CodigoEntrevista                ");
                queryTabelaResposta.Append(@"         ,  CodigoPergunta                  ");
                queryTabelaResposta.Append(@"         ,  CodigoOpcao                     ");
                queryTabelaResposta.Append(@"         ,  CodigoSeqResposta               ");
                queryTabelaResposta.Append(@"         ,  TextoResposta                   ");
                queryTabelaResposta.Append(@"         ,  TextoSubResposta                ");
                queryTabelaResposta.Append(@"   FROM   TResposta                         ");
                queryTabelaResposta.Append(@"  WHERE   0 = 0                             ");
                
                if (codigoEntrevista > 0)
                    queryTabelaResposta.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaResposta.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TResposta", ex.Message);
                return new DataTable();
            }

        }

        #endregion

        #region [ ExcluirResposta ]

        public bool ExcluirResposta(Int64 codigoEntrevista, int codigoPergunta)
        {
            try
            {
                StringBuilder queryTabelaResposta = new StringBuilder();

                queryTabelaResposta.Append(@" DELETE FROM TResposta                      ");
                queryTabelaResposta.Append(@"  WHERE   0 = 0                             ");
                
                if (codigoEntrevista > 0)
                    queryTabelaResposta.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                if (codigoPergunta > 0)
                    queryTabelaResposta.Append(@"  AND   CodigoPergunta = " + codigoPergunta);
                
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaResposta.ToString(), conn);
                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Excluir registro TResposta", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ VerificarResposta ]

        public bool VerificarResposta(Int64 codigoEntrevista, int codigoPergunta)
        {
            try
            {
                StringBuilder queryTabelaResposta = new StringBuilder();

                queryTabelaResposta.Append(@" SELECT     IDResposta                      ");
                queryTabelaResposta.Append(@"         ,  CodigoEntrevista                ");
                queryTabelaResposta.Append(@"         ,  CodigoPergunta                  ");
                queryTabelaResposta.Append(@"   FROM   TResposta                         ");
                queryTabelaResposta.Append(@"  WHERE   0 = 0                             ");

                if (codigoEntrevista > 0)
                    queryTabelaResposta.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                if (codigoPergunta > 0)
                    queryTabelaResposta.Append(@"  AND   CodigoPergunta = " + codigoPergunta);


                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaResposta.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    return dadosTable.Rows.Count > 0;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TResposta", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ SalvarResposta ]

        public void SalvarResposta(List<TRespostaDOMINIO> listDadosResposta)
        {
            try
            {
                foreach (TRespostaDOMINIO dadosResposta in listDadosResposta)
                {
                    if (VerificarResposta(dadosResposta.CodigoEntrevista, dadosResposta.CodigoPergunta))
                        AlterarResposta(dadosResposta);
                    else
                        IncluirResposta(dadosResposta);
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Salvar registro TResposta", ex.Message);
            }

        }

        #endregion

        #region [ SalvarRespostaAgregados ]

        public void SalvarRespostaAgregados(List<TRespostaDOMINIO> listDadosResposta)
        {
            try
            {
                if (listDadosResposta.Count > 0)
                    ExcluirResposta(listDadosResposta[0].CodigoEntrevista, listDadosResposta[0].CodigoPergunta);

                foreach (TRespostaDOMINIO dadosResposta in listDadosResposta)
                {
                        IncluirResposta(dadosResposta);
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Salvar registro TResposta", ex.Message);
            }

        }

        #endregion

        #region [ SelecioneRespostaFeedBack ]

        public DataTable SelecioneRespostaFeedBack(Int64 codigoEntrevista, Int32 codigoPergunta)
        {
            try
            {
                StringBuilder queryTabelaResposta = new StringBuilder();

                queryTabelaResposta.Append(@" SELECT     IDResposta                      ");
                queryTabelaResposta.Append(@"         ,  CodigoEntrevista                ");
                queryTabelaResposta.Append(@"         ,  CodigoPergunta                  ");
                queryTabelaResposta.Append(@"         ,  CodigoOpcao                     ");
                queryTabelaResposta.Append(@"         ,  CodigoSeqResposta               ");
                queryTabelaResposta.Append(@"         ,  TextoResposta                   ");
                queryTabelaResposta.Append(@"         ,  TextoSubResposta                ");
                queryTabelaResposta.Append(@"   FROM   TResposta                         ");
                queryTabelaResposta.Append(@"  WHERE   0 = 0                             ");

                if (codigoEntrevista > 0)
                    queryTabelaResposta.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                if (codigoPergunta > 0)
                    queryTabelaResposta.Append(@"  AND   CodigoPergunta = " + codigoPergunta);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaResposta.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TResposta", ex.Message);
                return new DataTable();
            }

        }

        #endregion

        #region [ ExcluirRespostaFeedBack ]

        public bool ExcluirRespostaFeedBack(Int64 codigoEntrevista, Int32 codigoPergunta)
        {
            try
            {
                StringBuilder queryTabelaResposta = new StringBuilder();

                queryTabelaResposta.Append(@" DELETE FROM TResposta                      ");
                queryTabelaResposta.Append(@"  WHERE   0 = 0                             ");

                if (codigoEntrevista > 0)
                    queryTabelaResposta.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                if (codigoPergunta > 0)
                    queryTabelaResposta.Append(@"  AND   CodigoPergunta = " + codigoPergunta);
                
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaResposta.ToString(), conn);
                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Excluir registro TResposta", ex.Message);
                return false;
            }

        }
        
        #endregion

        #region [ SalvarFeedBack ]

        public bool SalvarFeedBack(List<TRespostaDOMINIO> telaResposta)
        {
            try
            {
                if (telaResposta.Count != 2)
                    return false;

                if (ExcluirRespostaFeedBack(telaResposta[0].CodigoEntrevista, telaResposta[0].CodigoPergunta))
                {
                    if (!IncluirResposta(telaResposta[0]))
                        return false;
                }
                else
                    return false;

                if (ExcluirRespostaFeedBack(telaResposta[1].CodigoEntrevista, telaResposta[1].CodigoPergunta))
                {
                    if (!IncluirResposta(telaResposta[1]))
                        return false;
                }
                else
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Gravar FeedBack", ex.Message);
                return false;
            }

        }

        #endregion

        #endregion
    }
}
