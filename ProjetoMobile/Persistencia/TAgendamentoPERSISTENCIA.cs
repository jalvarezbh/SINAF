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
    public class TAgendamentoPERSISTENCIA
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

        #region [ SalvarAgendamento ]

        public bool SalvarAgendamento(TAgendamentoDOMINIO dadosAgendamento)
        {
            try
            {
                if (dadosAgendamento.IDAgendamento > 0)
                    return AlterarAgendamento(dadosAgendamento);
                else
                    return IncluirAgendamento(dadosAgendamento);

            }
            catch
            {
                return false;
            }

        }

        #endregion

        #region [ IncluirAgendamento ]

        public bool IncluirAgendamento(TAgendamentoDOMINIO dadosAgendamento)
        {
            try
            {
                StringBuilder queryTabelaAgendamento = new StringBuilder();
                                
                queryTabelaAgendamento.Append(@" INSERT INTO TAgendamento                                              ");
                queryTabelaAgendamento.Append(@"     (  IDAgendamento                                                  ");
                queryTabelaAgendamento.Append(@"     ,  Nome                                                           ");
                queryTabelaAgendamento.Append(@"     ,  DataNascimento                                                 ");
                queryTabelaAgendamento.Append(@"     ,  Email                                                          ");
                queryTabelaAgendamento.Append(@"     ,  Telefone                                                       ");
                queryTabelaAgendamento.Append(@"     ,  Celular                                                        ");
                queryTabelaAgendamento.Append(@"     ,  CEP                                                            ");
                queryTabelaAgendamento.Append(@"     ,  Logradouro                                                     ");
                queryTabelaAgendamento.Append(@"     ,  Numero                                                         ");
                queryTabelaAgendamento.Append(@"     ,  Complemento                                                    ");
                queryTabelaAgendamento.Append(@"     ,  Bairro                                                         ");
                queryTabelaAgendamento.Append(@"     ,  Cidade                                                         ");
                queryTabelaAgendamento.Append(@"     ,  UF                                                             ");
                queryTabelaAgendamento.Append(@"     ,  PontoReferencia                                                ");
                queryTabelaAgendamento.Append(@"     ,  IDUsuarioAgendamento                                           ");
                queryTabelaAgendamento.Append(@"     ,  IDUsuarioVendedor                                              ");
                queryTabelaAgendamento.Append(@"     ,  IDAtendimento                                                  ");
                queryTabelaAgendamento.Append(@"     ,  Site                                                           ");
                queryTabelaAgendamento.Append(@"     ,  Excluir                                                        ");
                queryTabelaAgendamento.Append(@"     ,  DataAgendada )                                                 ");
                queryTabelaAgendamento.Append(@"     VALUES  ( " + SelecioneUltimoID() + "                             ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.Nome + "'                         ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.DataNascimento.ToString("s") + "' ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.Email + "'                        ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.Telefone + "'                     ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.Celular + "'                      ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.CEP + "'                          ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.Logradouro + "'                   ");
                queryTabelaAgendamento.Append(@"             , " + dadosAgendamento.Numero + "                         ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.Complemento + "'                  ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.Bairro + "'                       ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.Cidade + "'                       ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.UF + "'                           ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.PontoReferencia + "'              ");
                queryTabelaAgendamento.Append(@"             , " + Program.IDUsuario + "                               ");
                queryTabelaAgendamento.Append(@"             , " + Program.IDUsuario + "                               ");
                queryTabelaAgendamento.Append(@"             , NULL, 0 , 0                                             ");
                queryTabelaAgendamento.Append(@"             , '" + dadosAgendamento.DataAgendada.ToString("s") + "' );");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaAgendamento.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Incluir registro TAgendamento", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ AlterarAgendamento ]
        
        public bool AlterarAgendamento(TAgendamentoDOMINIO dadosAgendamento)
        {
            try
            {
                StringBuilder queryTabelaAgendamento = new StringBuilder();
                                
                queryTabelaAgendamento.Append(@" UPDATE TAgendamento                                                             ");
                queryTabelaAgendamento.Append(@"    SET Nome = '" + dadosAgendamento.Nome + "'                                   ");
                queryTabelaAgendamento.Append(@"     ,  DataNascimento = '" + dadosAgendamento.DataNascimento.ToString("s") + "' ");
                queryTabelaAgendamento.Append(@"     ,  Email = '" + dadosAgendamento.Email + "'                                 ");
                queryTabelaAgendamento.Append(@"     ,  Telefone = '" + dadosAgendamento.Telefone + "'                           ");
                queryTabelaAgendamento.Append(@"     ,  Celular ='" + dadosAgendamento.Celular + "'                              ");
                queryTabelaAgendamento.Append(@"     ,  CEP = " + dadosAgendamento.CEP + "                                       ");
                queryTabelaAgendamento.Append(@"     ,  Logradouro = '" + dadosAgendamento.Logradouro + "'                       ");
                queryTabelaAgendamento.Append(@"     ,  Numero = '" + dadosAgendamento.Numero + "'                               ");
                queryTabelaAgendamento.Append(@"     ,  Complemento = '" + dadosAgendamento.Complemento + "'                     ");
                queryTabelaAgendamento.Append(@"     ,  Bairro = '" + dadosAgendamento.Bairro + "'                               ");
                queryTabelaAgendamento.Append(@"     ,  Cidade = '" + dadosAgendamento.Cidade + "'                               ");
                queryTabelaAgendamento.Append(@"     ,  UF = '" + dadosAgendamento.UF + "'                                       ");
                queryTabelaAgendamento.Append(@"     ,  PontoReferencia = '" + dadosAgendamento.PontoReferencia + "'             ");
                queryTabelaAgendamento.Append(@"     ,  DataAgendada = '" + dadosAgendamento.DataAgendada.ToString("s") + "'     ");
                queryTabelaAgendamento.Append(@"  WHERE IDAgendamento = " + dadosAgendamento.IDAgendamento);
                
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaAgendamento.ToString(), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Alterar registro TAgendamento", ex.Message);
                return false;
            }

        }

        #endregion

        #region [ SelecioneAgendamento ]
        
        public DataTable SelecioneAgendamento(Int32 idAgendamento)
        {
            try
            {
                StringBuilder queryTabelaAgendamento = new StringBuilder();

                queryTabelaAgendamento.Append(@" SELECT     IDAgendamento            ");
                queryTabelaAgendamento.Append(@"         ,  Nome                     ");
                queryTabelaAgendamento.Append(@"         ,  DataNascimento           ");
                queryTabelaAgendamento.Append(@"         ,  Email                    ");
                queryTabelaAgendamento.Append(@"         ,  Telefone                 ");
                queryTabelaAgendamento.Append(@"         ,  Celular                  ");
                queryTabelaAgendamento.Append(@"         ,  CEP                      ");
                queryTabelaAgendamento.Append(@"         ,  Logradouro               ");
                queryTabelaAgendamento.Append(@"         ,  Numero                   ");
                queryTabelaAgendamento.Append(@"         ,  Complemento              ");
                queryTabelaAgendamento.Append(@"         ,  Bairro                   ");
                queryTabelaAgendamento.Append(@"         ,  Cidade                   ");
                queryTabelaAgendamento.Append(@"         ,  UF                       ");
                queryTabelaAgendamento.Append(@"         ,  PontoReferencia          ");
                queryTabelaAgendamento.Append(@"         ,  Site                     ");
                queryTabelaAgendamento.Append(@"         ,  Excluir                  ");
                queryTabelaAgendamento.Append(@"         ,  DataAgendada             ");
                queryTabelaAgendamento.Append(@"   FROM   TAgendamento               ");
                queryTabelaAgendamento.Append(@"  WHERE   Excluir = 0                ");

                if (idAgendamento > 0)
                    queryTabelaAgendamento.Append(@"  AND   IDAgendamento = " + idAgendamento);
                
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaAgendamento.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable("TAgendamento");
                    dadosTable.Load(dados);

                    return dadosTable;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TAgendamento", ex.Message);
                return new DataTable();
            }

        }

        #endregion

        #region [ SelecioneUltimoID ]

        public int SelecioneUltimoID()
        {
            try
            {
                StringBuilder queryTabelaAgendamento = new StringBuilder();

                queryTabelaAgendamento.Append(@" SELECT MAX(IDAgendamento)            ");
                queryTabelaAgendamento.Append(@"   FROM   TAgendamento                ");
                
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaAgendamento.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable("TAgendamento");
                    dadosTable.Load(dados);

                    if (dadosTable.Rows.Count > 0)
                        return Convert.ToInt32(dadosTable.Rows[0][0]) + 1;
                    else
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Selecionar registro TAgendamento", ex.Message);
                return 1;
            }

        }

        #endregion

        #region [ ExcluirAgendamento ]
        
        public bool ExcluirAgendamento(Int32 idAgendamento)
        {
            try
            {
                //Verifica se o agendamento foi feito pelo site
                DataTable dadosAgendamento = SelecioneAgendamento(idAgendamento);

                if (dadosAgendamento.Rows.Count > 0)
                {
                    StringBuilder queryTabelaAgendamento = new StringBuilder();

                    if (Convert.ToBoolean(dadosAgendamento.Rows[0]["Site"]))
                    {
                        queryTabelaAgendamento.Append(@" UPDATE TAgendamento SET Excluir = 1    ");
                        queryTabelaAgendamento.Append(@"  WHERE IDAgendamento = " + idAgendamento);
                    }
                    else
                    {
                        queryTabelaAgendamento.Append(@" DELETE FROM TAgendamento               ");
                        queryTabelaAgendamento.Append(@"  WHERE IDAgendamento = " + idAgendamento);
                    }

                    using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                    {
                        conn.Open();

                        SqlCeCommand command = new SqlCeCommand(queryTabelaAgendamento.ToString(), conn);
                        command.ExecuteNonQuery();                        
                    }
                }

                return true;
                
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Excluir registro TAgendamento", ex.Message);
                return false;
            }

        }
        
        #endregion
        
        #endregion
    }        
}
