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
    public class TEntrevistaPERSISTENCIA
    {
        #region [ PERSISTENCE ]
        
        private TEntrevistadoPERSISTENCIA _TEntrevistadoPERSISTENCIA;

        public TEntrevistadoPERSISTENCIA TEntrevistadoPERSISTENCIA
        {
            get
            {
                if (_TEntrevistadoPERSISTENCIA == null)
                    _TEntrevistadoPERSISTENCIA = new TEntrevistadoPERSISTENCIA();

                return _TEntrevistadoPERSISTENCIA;

            }
        }

        private TEntrevistadoEnderecoPERSISTENCIA _TEntrevistadoEnderecoPERSISTENCIA;

        public TEntrevistadoEnderecoPERSISTENCIA TEntrevistadoEnderecoPERSISTENCIA
        {
            get
            {
                if (_TEntrevistadoEnderecoPERSISTENCIA == null)
                    _TEntrevistadoEnderecoPERSISTENCIA = new TEntrevistadoEnderecoPERSISTENCIA();

                return _TEntrevistadoEnderecoPERSISTENCIA;

            }
        }

        private TRespostaPERSISTENCIA _TRespostaPERSISTENCIA;

        public TRespostaPERSISTENCIA TRespostaPERSISTENCIA
        {
            get
            {
                if (_TRespostaPERSISTENCIA == null)
                    _TRespostaPERSISTENCIA = new TRespostaPERSISTENCIA();

                return _TRespostaPERSISTENCIA;

            }
        }

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

        private TSimuladorSubRendaPERSISTENCIA _TSimuladorSubRendaPERSISTENCIA;

        public TSimuladorSubRendaPERSISTENCIA TSimuladorSubRendaPERSISTENCIA
        {
            get
            {
                if (_TSimuladorSubRendaPERSISTENCIA == null)
                    _TSimuladorSubRendaPERSISTENCIA = new TSimuladorSubRendaPERSISTENCIA();

                return _TSimuladorSubRendaPERSISTENCIA;

            }
        }

        private TSimuladorSubAgregadoPERSISTENCIA _TSimuladorSubAgregadoPERSISTENCIA;

        public TSimuladorSubAgregadoPERSISTENCIA TSimuladorSubAgregadoPERSISTENCIA
        {
            get
            {
                if (_TSimuladorSubAgregadoPERSISTENCIA == null)
                    _TSimuladorSubAgregadoPERSISTENCIA = new TSimuladorSubAgregadoPERSISTENCIA();

                return _TSimuladorSubAgregadoPERSISTENCIA;

            }
        }

        private TSimuladorSubFuneralPERSISTENCIA _TSimuladorSubFuneralPERSISTENCIA;

        public TSimuladorSubFuneralPERSISTENCIA TSimuladorSubFuneralPERSISTENCIA
        {
            get
            {
                if (_TSimuladorSubFuneralPERSISTENCIA == null)
                    _TSimuladorSubFuneralPERSISTENCIA = new TSimuladorSubFuneralPERSISTENCIA();

                return _TSimuladorSubFuneralPERSISTENCIA;

            }
        }

        private TFaixaPERSISTENCIA _TFaixaPERSISTENCIA;

        public TFaixaPERSISTENCIA TFaixaPERSISTENCIA
        {
            get
            {
                if (_TFaixaPERSISTENCIA == null)
                    _TFaixaPERSISTENCIA = new TFaixaPERSISTENCIA();

                return _TFaixaPERSISTENCIA;

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
                
        #region [ SalvarAba1 ]

        public bool SalvarAba1(TEntrevistaDOMINIO telaEntrevista, TEntrevistadoDOMINIO telaEntrevistado, TEntrevistadoEnderecoDOMINIO telaEntrevistadoEndereco)
        {
            try
            {
                DataTable tableEntrevista = SelecioneEntrevista(telaEntrevista.CodigoEntrevista);
                                
                if (tableEntrevista.Rows.Count == 0)
                  IncluirEntrevista(telaEntrevista);
                
                DataTable tableEntrevistado = TEntrevistadoPERSISTENCIA.SelecioneEntrevistado(telaEntrevista.CodigoEntrevista);
               
                if (tableEntrevistado.Rows.Count== 0)
                    TEntrevistadoPERSISTENCIA.IncluirEntrevistado(telaEntrevistado);
                else
                    TEntrevistadoPERSISTENCIA.AlterarEntrevistadoAba1(telaEntrevistado);

                DataTable tableEntrevistadoEndereco = TEntrevistadoEnderecoPERSISTENCIA.SelecioneEntrevistadoEndereco(telaEntrevista.CodigoEntrevista);

                if (tableEntrevistadoEndereco.Rows.Count == 0)
                    TEntrevistadoEnderecoPERSISTENCIA.IncluirEntrevistadoEndereco(telaEntrevistadoEndereco);
                else
                    TEntrevistadoEnderecoPERSISTENCIA.AlterarEntrevistadoEndereco(telaEntrevistadoEndereco);

                if (!TFaixaPERSISTENCIA.UtilizarFaixa(telaEntrevista.CodigoEntrevista))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Gravar Aba Pessoal", ex.Message);
                return false;
            }

        }

        #endregion
                
        #region [ IncluirEntrevista ]

        public bool IncluirEntrevista(TEntrevistaDOMINIO dadosEntrevista)
        {
            try
            {
                
                StringBuilder queryTabelaEntrevista = new StringBuilder();

                queryTabelaEntrevista.Append(@" INSERT INTO TEntrevista                                              ");
                queryTabelaEntrevista.Append(@"     (  CodigoEntrevista                                              ");
                queryTabelaEntrevista.Append(@"     ,  CodigoColaborador                                             ");
                queryTabelaEntrevista.Append(@"     ,  DataEntrevista                                                ");
                queryTabelaEntrevista.Append(@"     ,  CodigoUsuario                                                 ");
                queryTabelaEntrevista.Append(@"     ,  DataInclusao                                                  ");
                queryTabelaEntrevista.Append(@"     ,  CodigoQuestionario                                            ");
                queryTabelaEntrevista.Append(@"     ,  OrigemVenda                                                   ");
                queryTabelaEntrevista.Append(@"     ,  Completa                                                      ");
                queryTabelaEntrevista.Append(@"     ,  Motivo              )                                         ");
                queryTabelaEntrevista.Append(@"     VALUES  ( " + dadosEntrevista.CodigoEntrevista + "               ");
                queryTabelaEntrevista.Append(@"             , " + dadosEntrevista.CodigoColaborador + "              ");
                queryTabelaEntrevista.Append(@"             , '" + dadosEntrevista.DataEntrevista.ToString("s") + "' ");
                queryTabelaEntrevista.Append(@"             , " + dadosEntrevista.CodigoUsuario + "                  ");
                queryTabelaEntrevista.Append(@"             , '" + dadosEntrevista.DataInclusao.ToString("s") + "'   ");
                queryTabelaEntrevista.Append(@"             , " + dadosEntrevista.CodigoQuestionario + "             ");
                queryTabelaEntrevista.Append(@"             , '" + dadosEntrevista.OrigemVenda + "'                  ");
                queryTabelaEntrevista.Append(@"             , 'False'                                                ");
                queryTabelaEntrevista.Append(@"             , '' )                                                   ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevista.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Incluir registro TEntrevista", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ SelecioneEntrevista ]

        public DataTable SelecioneEntrevista(Int64 codigoEntrevista)
        {
            try
            {
                StringBuilder queryTabelaEntrevista = new StringBuilder();

                queryTabelaEntrevista.Append(@" SELECT     IDEntrevista                    ");
                queryTabelaEntrevista.Append(@"         ,  CodigoEntrevista                ");
                queryTabelaEntrevista.Append(@"         ,  CodigoColaborador               ");
                queryTabelaEntrevista.Append(@"         ,  DataEntrevista                  ");
                queryTabelaEntrevista.Append(@"         ,  CodigoUsuario                   ");
                queryTabelaEntrevista.Append(@"         ,  DataInclusao                    ");
                queryTabelaEntrevista.Append(@"         ,  CodigoQuestionario              ");
                queryTabelaEntrevista.Append(@"         ,  OrigemVenda                     ");
                queryTabelaEntrevista.Append(@"         ,  Completa                        ");
                queryTabelaEntrevista.Append(@"         ,  Motivo                          ");
                queryTabelaEntrevista.Append(@"   FROM   TEntrevista                       ");
                queryTabelaEntrevista.Append(@"  WHERE   0 = 0                             ");
                  
                if (codigoEntrevista > 0)
                    queryTabelaEntrevista.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevista.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TEntrevista", ex.Message);
                return new DataTable();
            }

        }

        #endregion

        #region [ ExcluirEntrevista ]

        public bool ExcluirEntrevista(Int64 codigoEntrevista)
        {
            try
            {
                StringBuilder queryTabelaEntrevista = new StringBuilder();

                queryTabelaEntrevista.Append(@" DELETE FROM TEntrevista                    ");
                queryTabelaEntrevista.Append(@"  WHERE   0 = 0                             ");
                               
                if (codigoEntrevista > 0)
                    queryTabelaEntrevista.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevista.ToString(), conn);
                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Excluir registro TEntrevista", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ ListaEntrevistaEntrevistado ]

        public DataTable ListaEntrevistaEntrevistado()
        {
            try
            {
                StringBuilder queryTabelaEntrevista = new StringBuilder();

                queryTabelaEntrevista.Append(@" SELECT     IDEntrevista                                               ");
                queryTabelaEntrevista.Append(@"         ,  TEntrevista.CodigoEntrevista                               ");
                queryTabelaEntrevista.Append(@"         ,  CodigoColaborador                                          ");
                queryTabelaEntrevista.Append(@"         ,  DataEntrevista                                             ");
                queryTabelaEntrevista.Append(@"         ,  CodigoUsuario                                              ");
                queryTabelaEntrevista.Append(@"         ,  DataInclusao                                               ");
                queryTabelaEntrevista.Append(@"         ,  CodigoQuestionario                                         ");
                queryTabelaEntrevista.Append(@"         ,  OrigemVenda                                                ");
                queryTabelaEntrevista.Append(@"         ,  IDEntrevistado                                             ");
                queryTabelaEntrevista.Append(@"         ,  Nome                                                       ");
                queryTabelaEntrevista.Append(@"         ,  CPF                                                        ");
                queryTabelaEntrevista.Append(@"         ,  DataNascimento                                             ");
                queryTabelaEntrevista.Append(@"         ,  EstadoCivil                                                ");
                queryTabelaEntrevista.Append(@"         ,  IDProfissao                                                ");
                queryTabelaEntrevista.Append(@"         ,  FaixaEtaria                                                ");
                queryTabelaEntrevista.Append(@"         ,  CapitalLimitado                                            ");
                queryTabelaEntrevista.Append(@"         ,  DDD                                                        ");
                queryTabelaEntrevista.Append(@"         ,  Telefone                                                   ");
                queryTabelaEntrevista.Append(@"         ,  DDDCelular                                                 ");
                queryTabelaEntrevista.Append(@"         ,  Celular                                                    ");
                queryTabelaEntrevista.Append(@"         ,  Sexo                                                       ");
                queryTabelaEntrevista.Append(@"         ,  Informacao                                                 ");
                queryTabelaEntrevista.Append(@"         ,  IDProfissaoConjuge                                         ");
                queryTabelaEntrevista.Append(@"         ,  FaixaEtariaConjuge                                         ");
                queryTabelaEntrevista.Append(@"         ,  CapitalLimitadoConjuge                                     ");
                queryTabelaEntrevista.Append(@"         ,  Completa                                                   ");
                queryTabelaEntrevista.Append(@"         ,  Motivo                                                     ");
                queryTabelaEntrevista.Append(@"   FROM   TEntrevista                                                  ");
                queryTabelaEntrevista.Append(@"   INNER JOIN  TEntrevistado                                           ");
                queryTabelaEntrevista.Append(@"   ON TEntrevista.CodigoEntrevista = TEntrevistado.CodigoEntrevista    ");
                
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevista.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable("Formulario");
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TEntrevista INNER JOIN TEntrevistado", ex.Message);
                return new DataTable();
            }

        }
        
        #endregion

        #region [ VerificaEntrevistaCompleta ]

        public bool VerificaEntrevistaCompleta(Int32 codigoEntrevista)
        {
            try
            {
                StringBuilder queryTabelaEntrevista = new StringBuilder();

                queryTabelaEntrevista.Append(@" SELECT     IDEntrevista                                                     ");
                queryTabelaEntrevista.Append(@"         ,  TEntrevista.CodigoEntrevista                                     ");
                queryTabelaEntrevista.Append(@"   FROM   TEntrevista                                                        ");
                queryTabelaEntrevista.Append(@"   INNER JOIN  TEntrevistado                                                 ");
                queryTabelaEntrevista.Append(@"   ON TEntrevista.CodigoEntrevista = TEntrevistado.CodigoEntrevista          ");
                queryTabelaEntrevista.Append(@"   INNER JOIN  TEntrevistadoEndereco                                         ");
                queryTabelaEntrevista.Append(@"   ON TEntrevista.CodigoEntrevista = TEntrevistadoEndereco.CodigoEntrevista  ");
                queryTabelaEntrevista.Append(@"   INNER JOIN  TResposta                                                     ");
                queryTabelaEntrevista.Append(@"   ON TEntrevista.CodigoEntrevista  = TResposta.CodigoEntrevista             ");              

                if (codigoEntrevista > 0)
                    queryTabelaEntrevista.Append(@"  WHERE   TEntrevista.CodigoEntrevista = " + codigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevista.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    if (dadosTable.Rows.Count <= 0)
                        return false;
                    else
                    {
                        if (!TRespostaPERSISTENCIA.VerificarResposta(codigoEntrevista, (int)CodigoPergunta.FEEDBACKABA1))
                            return false;

                        if (!TRespostaPERSISTENCIA.VerificarResposta(codigoEntrevista, (int)CodigoPergunta.FEEDBACKABA2))
                            return false;

                        return true;
                    }                    
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Verificar registro completo.", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ AtualizarEntrevista ]

        public bool AtualizarEntrevista(TEntrevistaDOMINIO dadosEntrevista)
        {
            try
            {
                StringBuilder queryTabelaEntrevista = new StringBuilder();

                queryTabelaEntrevista.Append(@" UPDATE TEntrevista                                                    ");
                queryTabelaEntrevista.Append(@" SET Completa = '" + dadosEntrevista.Completa + "'                     ");
                queryTabelaEntrevista.Append(@"   , Motivo = '" + dadosEntrevista.Motivo + "'                         ");
                queryTabelaEntrevista.Append(@" WHERE  CodigoEntrevista = " + dadosEntrevista.CodigoEntrevista + "    ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevista.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex )
            {
                Util.LogErro.GravaLog("Atualizar registro TEntrevista", ex.Message);
                return false;
            }
        }

        #endregion 

        #region [ ValidarEntrevistaCompleta ]

        public bool ValidarEntrevistaCompleta()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTabela = new StringBuilder();

                queryTabela.Append(@" SELECT TEntrevista.CodigoEntrevista                                        ");
                queryTabela.Append(@"      , TEntrevista.CodigoColaborador                                       ");
                queryTabela.Append(@"      , TEntrevista.DataEntrevista                                          ");
                queryTabela.Append(@"      , TEntrevista.CodigoUsuario                                           ");
                queryTabela.Append(@"      , TEntrevista.DataInclusao                                            ");
                queryTabela.Append(@"      , TEntrevista.CodigoQuestionario                                      ");
                queryTabela.Append(@"      , TEntrevista.OrigemVenda                                             ");
                queryTabela.Append(@"      , TEntrevista.Completa                                                ");
                queryTabela.Append(@"      , TEntrevistado.Nome                                                  ");
                queryTabela.Append(@"      , TEntrevistado.CPF                                                   ");
                queryTabela.Append(@"      , TEntrevistado.DataNascimento                                        ");
                queryTabela.Append(@"      , TEntrevistado.EstadoCivil                                           ");
                queryTabela.Append(@"      , TEntrevistado.IDProfissao                                           ");
                queryTabela.Append(@"      , TEntrevistado.FaixaEtaria                                           ");
                queryTabela.Append(@"      , TEntrevistado.FaixaEtariaConjuge                                    ");
                queryTabela.Append(@"      , TEntrevistado.IDProfissaoConjuge                                    ");
                queryTabela.Append(@"      , TEntrevistado.CapitalLimitado                                       ");
                queryTabela.Append(@"      , TEntrevistado.CapitalLimitadoConjuge                                ");
                queryTabela.Append(@"      , TEntrevistado.DDD                                                   ");
                queryTabela.Append(@"      , TEntrevistado.Telefone                                              ");
                queryTabela.Append(@"      , TEntrevistado.DDDCelular                                            ");
                queryTabela.Append(@"      , TEntrevistado.Celular                                               ");
                queryTabela.Append(@"      , TEntrevistado.Sexo                                                  ");
                queryTabela.Append(@"      , TEntrevistado.Informacao                                            ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Endereco                                      ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Numero                                        ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Bairro                                        ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Cidade                                        ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.UF                                            ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.CEP                                           ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Complemento                                   ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Email                                         ");
                queryTabela.Append(@"   FROM TEntrevista                                                         ");
                queryTabela.Append(@" INNER JOIN  TFaixa                                                         ");
                queryTabela.Append(@" ON TEntrevista.CodigoEntrevista = TFaixa.CodigoFaixa                       ");
                queryTabela.Append(@" LEFT JOIN TEntrevistado                                                    ");
                queryTabela.Append(@" ON TEntrevistado.CodigoEntrevista  = TEntrevista.CodigoEntrevista          ");
                queryTabela.Append(@" LEFT JOIN TEntrevistadoEndereco                                            ");
                queryTabela.Append(@" ON TEntrevistadoEndereco.CodigoEntrevista  = TEntrevista.CodigoEntrevista  ");
                
                StringBuilder queryResposta = new StringBuilder();

                queryResposta.Append(@" SELECT CodigoEntrevista                               ");
                queryResposta.Append(@"      , CodigoPergunta                                 ");
                queryResposta.Append(@"      , CodigoOpcao                                    ");
                queryResposta.Append(@"      , CodigoSeqResposta                              ");
                queryResposta.Append(@"      , TextoResposta                                  ");
                queryResposta.Append(@"      , TextoSubResposta                               ");
                queryResposta.Append(@"   FROM TResposta                                      ");
                queryResposta.Append(@" WHERE CodigoEntrevista =  @CODIGO                     ");
                queryResposta.Append(@"   AND CodigoPergunta =  @PERGUNTA                     ");

                #endregion

                #region [ UPLOAD ]

                StringBuilder queryUpdate = new StringBuilder();

                queryUpdate.Append(@" UPDATE TEntrevista                 ");
                queryUpdate.Append(@" SET Completa = '@COMPLETA'         ");
                queryUpdate.Append(@"   , Motivo = '@MOTIVO'             ");
                queryUpdate.Append(@" WHERE CodigoEntrevista =  @CODIGO  ");

                #endregion

                #region [ EXECUTE ]

                DataTable dadosTabela = new DataTable();

                using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabela = new SqlCeCommand(queryTabela.ToString(), connMobile);
                    IDataReader reader = cmdLerTabela.ExecuteReader();


                    dadosTabela.Load(reader);
                }

                foreach (DataRow dadosRow in dadosTabela.Rows)
                {
                    string queryIncompleta = queryUpdate.ToString().Replace("@COMPLETA", "false").Replace("@CODIGO", dadosRow["CodigoEntrevista"].ToString());
                    string queryCompleta = queryUpdate.ToString().Replace("@COMPLETA", "true").Replace("@CODIGO", dadosRow["CodigoEntrevista"].ToString());
                    string querySelectTResposta = queryResposta.ToString().Replace("@CODIGO", dadosRow["CodigoEntrevista"].ToString());
                                        
                    #region [ ABA 1]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        if (string.IsNullOrEmpty(dadosRow["Nome"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Nome não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["EstadoCivil"].ToString()) || string.IsNullOrEmpty(dadosRow["EstadoCivil"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Estado Civil não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["IDProfissao"].ToString()) || string.IsNullOrEmpty(dadosRow["IDProfissao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Profissão não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ ABA 2]

                    #region [ PERGUNTA 2]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "29"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 3]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "30"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 3 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 3 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 3 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 4]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "31"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 4 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 4 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 4 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 5]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "32"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 5 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 5 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoSeqResposta"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoSeqResposta"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 5 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 5 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoSubResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 5 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 6]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "33"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 6 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 6 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 6 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 7]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "34"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 7 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 7 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 7 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #endregion

                    #region [ ABA 3]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        if (string.IsNullOrEmpty(dadosRow["Sexo"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Sexo não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["DataNascimento"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Data Nascimento não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["Telefone"].ToString()) && string.IsNullOrEmpty(dadosRow["Celular"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Telefone não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ ABA 4]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        if (string.IsNullOrEmpty(dadosRow["CEP"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "CEP não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["Endereco"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Endereço não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["Bairro"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Bairro não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["Cidade"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Cidade não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["UF"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "UF não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["Numero"].ToString()) && string.IsNullOrEmpty(dadosRow["Complemento"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Número e Complemento não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ FEEDBACK ]

                    #region [ PERGUNTA 1]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "35"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 1 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 1 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 1 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 2]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ConnectionString))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "36"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #endregion
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Validar registro TEntrevista", ex.Message);
                return false;
            }
        }

        #endregion 

        #endregion
    }
}
