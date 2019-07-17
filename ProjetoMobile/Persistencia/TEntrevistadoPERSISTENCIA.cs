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
    public class TEntrevistadoPERSISTENCIA
    {
        #region [ PERSISTENCE ]

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

        #region [ IncluirEntrevistado ]

        public bool IncluirEntrevistado(TEntrevistadoDOMINIO dadosEntrevistado)
        {
            try
            {
                StringBuilder queryTabelaEntrevistado = new StringBuilder();

                string informacao = dadosEntrevistado.Informacao ? "1" : "0";
                string dataNascimento = dadosEntrevistado.DataNascimento.HasValue? "'"+ dadosEntrevistado.DataNascimento.Value.ToString("s")+"'": "null" ;
                string dataNascimentoConjuge = dadosEntrevistado.DataNascimentoConjuge.HasValue ? "'" + dadosEntrevistado.DataNascimentoConjuge.Value.ToString("s") + "'" : "null";

                queryTabelaEntrevistado.Append(@" INSERT INTO TEntrevistado                                          ");
                queryTabelaEntrevistado.Append(@"     (  CodigoEntrevista                                            ");
                queryTabelaEntrevistado.Append(@"     ,  Nome                                                        ");
                queryTabelaEntrevistado.Append(@"     ,  CPF                                                         ");
                queryTabelaEntrevistado.Append(@"     ,  DataNascimento                                              ");
                queryTabelaEntrevistado.Append(@"     ,  EstadoCivil                                                 ");
                queryTabelaEntrevistado.Append(@"     ,  IDProfissao                                                 ");
                queryTabelaEntrevistado.Append(@"     ,  FaixaEtaria                                                 ");
                queryTabelaEntrevistado.Append(@"     ,  CapitalLimitado                                             ");
                queryTabelaEntrevistado.Append(@"     ,  DDD                                                         ");
                queryTabelaEntrevistado.Append(@"     ,  Telefone                                                    ");
                queryTabelaEntrevistado.Append(@"     ,  DDDCelular                                                  ");
                queryTabelaEntrevistado.Append(@"     ,  Celular                                                     ");
                queryTabelaEntrevistado.Append(@"     ,  Sexo                                                        ");
                queryTabelaEntrevistado.Append(@"     ,  Informacao                                                  ");
                queryTabelaEntrevistado.Append(@"     ,  IDProfissaoConjuge                                          ");
                queryTabelaEntrevistado.Append(@"     ,  FaixaEtariaConjuge                                          ");
                queryTabelaEntrevistado.Append(@"     ,  CapitalLimitadoConjuge                                      ");
                queryTabelaEntrevistado.Append(@"     ,  DataNascimentoConjuge     )                                 ");                
                queryTabelaEntrevistado.Append(@"     VALUES  ( " + dadosEntrevistado.CodigoEntrevista + "           ");
                queryTabelaEntrevistado.Append(@"             , '" + dadosEntrevistado.Nome + "'                     ");
                queryTabelaEntrevistado.Append(@"             , '" + dadosEntrevistado.CPF + "'                      ");
                queryTabelaEntrevistado.Append(@"             , " + dataNascimento + "                               ");
                queryTabelaEntrevistado.Append(@"             , " + dadosEntrevistado.EstadoCivil + "                ");
                queryTabelaEntrevistado.Append(@"             , " + dadosEntrevistado.IDProfissao + "                ");
                queryTabelaEntrevistado.Append(@"             , " + dadosEntrevistado.FaixaEtaria + "                ");
                queryTabelaEntrevistado.Append(@"             , '" + dadosEntrevistado.CapitalLimitado + "'          ");
                queryTabelaEntrevistado.Append(@"             , '" + dadosEntrevistado.DDD + "'                      ");
                queryTabelaEntrevistado.Append(@"             , '" + dadosEntrevistado.Telefone + "'                 ");
                queryTabelaEntrevistado.Append(@"             , '" + dadosEntrevistado.DDDCelular + "'               ");
                queryTabelaEntrevistado.Append(@"             , '" + dadosEntrevistado.Celular + "'                  ");
                queryTabelaEntrevistado.Append(@"             , '" + dadosEntrevistado.Sexo + "'                     ");
                queryTabelaEntrevistado.Append(@"             , " + informacao + "                                   ");
                queryTabelaEntrevistado.Append(@"             , " + dadosEntrevistado.IDProfissaoConjuge + "         ");
                queryTabelaEntrevistado.Append(@"             , " + dadosEntrevistado.FaixaEtariaConjuge + "         ");
                queryTabelaEntrevistado.Append(@"             , '" + dadosEntrevistado.CapitalLimitadoConjuge + "'   ");
                queryTabelaEntrevistado.Append(@"             , " + dataNascimentoConjuge + " )                      ");
                
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevistado.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Incluir registro TEntrevistado", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ AlterarEntrevistadoAba1 ]

        public bool AlterarEntrevistadoAba1(TEntrevistadoDOMINIO dadosEntrevistado)
        {
            try
            {
                StringBuilder queryTabelaEntrevistado = new StringBuilder();

                string dataNascimentoConjuge = dadosEntrevistado.DataNascimentoConjuge.HasValue ? "'" + dadosEntrevistado.DataNascimentoConjuge.Value.ToString("s") + "'" : "null";
                
                queryTabelaEntrevistado.Append(@" UPDATE TEntrevistado                                                                ");
                queryTabelaEntrevistado.Append(@"    SET Nome = '" + dadosEntrevistado.Nome + "'                                      ");
                queryTabelaEntrevistado.Append(@"     ,  EstadoCivil  = " + dadosEntrevistado.EstadoCivil + "                         ");
                queryTabelaEntrevistado.Append(@"     ,  IDProfissao = " + dadosEntrevistado.IDProfissao + "                          ");
                queryTabelaEntrevistado.Append(@"     ,  CapitalLimitado = '" + dadosEntrevistado.CapitalLimitado + "'                ");
                queryTabelaEntrevistado.Append(@"     ,  FaixaEtariaConjuge = " + dadosEntrevistado.FaixaEtariaConjuge + "            ");
                queryTabelaEntrevistado.Append(@"     ,  IDProfissaoConjuge = " + dadosEntrevistado.IDProfissaoConjuge + "            ");
                queryTabelaEntrevistado.Append(@"     ,  CapitalLimitadoConjuge = '" + dadosEntrevistado.CapitalLimitadoConjuge + "'  ");
                queryTabelaEntrevistado.Append(@"     ,  DataNascimentoConjuge = " + dataNascimentoConjuge + "                        ");
                queryTabelaEntrevistado.Append(@"  WHERE   0 = 0                                                                      ");

                if (dadosEntrevistado.CodigoEntrevista > 0)
                    queryTabelaEntrevistado.Append(@"  AND   CodigoEntrevista = " + dadosEntrevistado.CodigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevistado.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Alterar registro TEntrevistado", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ SelecioneEntrevistado ]

        public DataTable SelecioneEntrevistado(Int64 codigoEntrevista)
        {
            try
            {
                StringBuilder queryTabelaEntrevistado = new StringBuilder();

                queryTabelaEntrevistado.Append(@" SELECT     IDEntrevistado                  ");
                queryTabelaEntrevistado.Append(@"         ,  CodigoEntrevista                ");
                queryTabelaEntrevistado.Append(@"         ,  Nome                            ");
                queryTabelaEntrevistado.Append(@"         ,  CPF                             ");
                queryTabelaEntrevistado.Append(@"         ,  DataNascimento                  ");
                queryTabelaEntrevistado.Append(@"         ,  EstadoCivil                     ");
                queryTabelaEntrevistado.Append(@"         ,  IDProfissao                     ");
                queryTabelaEntrevistado.Append(@"         ,  FaixaEtaria                     ");
                queryTabelaEntrevistado.Append(@"         ,  CapitalLimitado                 ");
                queryTabelaEntrevistado.Append(@"         ,  DDD                             ");
                queryTabelaEntrevistado.Append(@"         ,  Telefone                        ");
                queryTabelaEntrevistado.Append(@"         ,  DDDCelular                      ");
                queryTabelaEntrevistado.Append(@"         ,  Celular                         ");
                queryTabelaEntrevistado.Append(@"         ,  Sexo                            ");
                queryTabelaEntrevistado.Append(@"         ,  Informacao                      ");
                queryTabelaEntrevistado.Append(@"         ,  IDProfissaoConjuge              ");
                queryTabelaEntrevistado.Append(@"         ,  FaixaEtariaConjuge              ");
                queryTabelaEntrevistado.Append(@"         ,  CapitalLimitadoConjuge          ");
                queryTabelaEntrevistado.Append(@"         ,  DataNascimentoConjuge           ");                
                queryTabelaEntrevistado.Append(@"   FROM   TEntrevistado                     ");
                queryTabelaEntrevistado.Append(@"  WHERE   0 = 0                             ");

                if (codigoEntrevista > 0)
                    queryTabelaEntrevistado.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevistado.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TEntrevistado", ex.Message);
                return new DataTable();
            }

        }

        #endregion

        #region [ ExcluirEntrevistado ]

        public bool ExcluirEntrevistado(Int64 codigoEntrevista)
        {
            try
            {
                StringBuilder queryTabelaEntrevistado = new StringBuilder();

                queryTabelaEntrevistado.Append(@" DELETE FROM TEntrevistado                  ");
                queryTabelaEntrevistado.Append(@"  WHERE   0 = 0                             ");
                                
                if (codigoEntrevista > 0)
                    queryTabelaEntrevistado.Append(@"  AND   CodigoEntrevista = " + codigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevistado.ToString(), conn);
                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Excluir registro TEntrevistado", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ AlterarEntrevistadoPremio ]

        public bool AlterarEntrevistadoPremio(TEntrevistadoDOMINIO dadosEntrevistado)
        {
            try
            {
                StringBuilder queryTabelaEntrevistado = new StringBuilder();

                string dataNascimento = dadosEntrevistado.DataNascimento.HasValue ? "'" + dadosEntrevistado.DataNascimento.Value.ToString("s") + "'" : "null";

                queryTabelaEntrevistado.Append(@" UPDATE TEntrevistado                                          ");
                queryTabelaEntrevistado.Append(@"    SET CPF = '" + dadosEntrevistado.CPF + "'                  ");
                queryTabelaEntrevistado.Append(@"     ,  DataNascimento  =  " + dataNascimento + "              ");
                queryTabelaEntrevistado.Append(@"     ,  FaixaEtaria  =  " + dadosEntrevistado.FaixaEtaria.ToString() + "  ");
                queryTabelaEntrevistado.Append(@"     ,  DDD = '" + dadosEntrevistado.DDD + "'                  ");
                queryTabelaEntrevistado.Append(@"     ,  Telefone = '" + dadosEntrevistado.Telefone + "'        ");
                queryTabelaEntrevistado.Append(@"     ,  DDDCelular = '" + dadosEntrevistado.DDDCelular + "'    ");
                queryTabelaEntrevistado.Append(@"     ,  Celular = '" + dadosEntrevistado.Celular + "'          ");
                queryTabelaEntrevistado.Append(@"     ,  Sexo = '" + dadosEntrevistado.Sexo + "'                ");                
                queryTabelaEntrevistado.Append(@"  WHERE   0 = 0                                                ");

                if (dadosEntrevistado.CodigoEntrevista > 0)
                    queryTabelaEntrevistado.Append(@"  AND   CodigoEntrevista = " + dadosEntrevistado.CodigoEntrevista);

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevistado.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Alterar registro TEntrevistado", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ VerificarEntrevistadoCPF ]

        public bool VerificarEntrevistadoCPF(long codigoEntrevista, string cpfEntrevistado)
        {
            try
            {
                StringBuilder queryTabelaEntrevistado = new StringBuilder();
                queryTabelaEntrevistado.Append(@" SELECT     IDEntrevistado                             ");
                queryTabelaEntrevistado.Append(@"         ,  CPF                                        ");
                queryTabelaEntrevistado.Append(@"   FROM   TEntrevistado                                ");
                queryTabelaEntrevistado.Append(@"  WHERE   CodigoEntrevista <> " + codigoEntrevista + " ");
                queryTabelaEntrevistado.Append(@"    AND   CPF = '" + cpfEntrevistado + "'              ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEntrevistado.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);
                                        
                    return dadosTable.Rows.Count > 0;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TEntrevistado", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ SalvarPremioCompleto ]

        public bool SalvarPremioCompleto(TEntrevistadoDOMINIO telaEntrevistado, TEntrevistadoEnderecoDOMINIO telaEntrevistadoEndereco)
        {
            try
            {
                if (AlterarEntrevistadoPremio(telaEntrevistado))
                {
                    if (!TEntrevistadoEnderecoPERSISTENCIA.AlterarEntrevistadoEndereco(telaEntrevistadoEndereco))
                        return false;
                }
                else
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Gravar Premio", ex.Message);
                return false;
            }

        }

        #endregion
        
        #endregion
    }
}
