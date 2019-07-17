using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoVO;
using ProjetoController;
using ProjetoWeb.Util;
using System.Data.SqlServerCe;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebControls;
using System.Web.Configuration;

namespace ProjetoWeb.Service
{
    public class ServicoSINAF
    {
        #region [ PROPRIEDADES ]

        private static string connectionString;

        public static string ConnectionString
        {
            get
            {
                if (connectionString == null)
                    connectionString = WebConfigurationManager.ConnectionStrings["ConnectionStringWEB"].ConnectionString;

                return connectionString;

            }
        }

        private static string connectionStringSINAF;

        public static string ConnectionStringSINAF
        {
            get
            {
                if (connectionStringSINAF == null)
                    connectionStringSINAF = WebConfigurationManager.ConnectionStrings["ConnectionStringSINAF"].ConnectionString;

                return connectionStringSINAF;

            }
        }

        private static string connectionStringEND;

        public static string ConnectionStringEND
        {
            get
            {
                if (connectionStringEND == null)
                    connectionStringEND = WebConfigurationManager.ConnectionStrings["ConnectionStringEND"].ConnectionString;

                return connectionStringEND;

            }
        }

        private static string connectionStringInterface;

        public static string ConnectionStringInterface
        {
            get
            {
                if (connectionStringInterface == null)
                    connectionStringInterface = WebConfigurationManager.ConnectionStrings["ConnectionStringInterface"].ConnectionString;

                return connectionStringInterface;

            }
        }

        #endregion              

        #region [ SERVIÇO CORREIO ]

        public void ImportarBancoCorreio()
        {

            try
            {

                #region [ Drop Tables ]

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmdDropTables = new SqlCommand(queryDropTables(), conn);
                    cmdDropTables.ExecuteNonQuery();
                }

                #endregion

                #region [ Create Tables ]

                //using (SqlConnection conn = new SqlConnection(ConnectionString))
                //{
                //    conn.Open();

                //    SqlCommand cmdCreateTables = new SqlCommand(queryCreateTables(), conn);
                //    cmdCreateTables.ExecuteNonQuery();
                //}

                #endregion

                #region [ Import Table TCorreio ]

                DataTable tableUF = new DataTable();
                DataTable tableUF_Cidade = new DataTable();

                //Preenche tableUF com todos os UF da TB_CORREIO
                using (SqlConnection connEND = new SqlConnection(ConnectionStringEND))
                {

                    connEND.Open();

                    SqlCommand cmdLerDistinctTabelaCorreioUF = new SqlCommand(queryLerDistinctTabelaCorreioUF(), connEND);
                    SqlDataReader readerDistinctUF = cmdLerDistinctTabelaCorreioUF.ExecuteReader();
                    tableUF.Load(readerDistinctUF);
                }

                //Preenche tableUF_Cidade com todos os UF e Cidades da TB_CORREIO
                using (SqlConnection connEND = new SqlConnection(ConnectionStringEND))
                {

                    connEND.Open();

                    SqlCommand cmdLerDistinctTabelaCorreioUF_Cidade = new SqlCommand(queryLerDistinctTabelaCorreioUF_Cidade(), connEND);
                    SqlDataReader readerDistinctUF_Cidade = cmdLerDistinctTabelaCorreioUF_Cidade.ExecuteReader();
                    tableUF_Cidade.Load(readerDistinctUF_Cidade);
                }

                //Cria a TB_CORREIO_TEMP para importar os dados
                //using (SqlConnection destinationConnection = new SqlConnection(ConnectionString))
                //{
                //    destinationConnection.Open();

                //    SqlCommand cmdCriarTabelaCorreio = new SqlCommand(queryCriarTabelaCorreioTemp(), destinationConnection);

                //    cmdCriarTabelaCorreio.ExecuteNonQuery();
                //}

                //Preenche TB_CORREIO_TEMP com os dados da TB_CORREIO filtrando por UF_Cidade
                foreach (DataRow itemUF_Cidade in tableUF_Cidade.Rows)
                {
                    using (SqlConnection connEND = new SqlConnection(ConnectionStringEND))
                    {

                        connEND.Open();

                        SqlCommand cmdLerTabelaCorreio = new SqlCommand(queryLerTabelaCorreio(itemUF_Cidade["SIGLA"].ToString(), itemUF_Cidade["CIDADE"].ToString().Replace("'", " "), itemUF_Cidade["BAIRRO"].ToString().Replace("'", " ")), connEND);
                        SqlDataReader reader = cmdLerTabelaCorreio.ExecuteReader();

                        using (SqlConnection destinationConnection = new SqlConnection(ConnectionString))
                        {
                            destinationConnection.Open();

                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                            {
                                bulkCopy.DestinationTableName = "TCorreioTemp";

                                try
                                {
                                    bulkCopy.WriteToServer(reader);
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                finally
                                {
                                    reader.Close();
                                }
                            }
                        }
                    }
                }


                #endregion

                #region [ Import Table TEstado ]

                foreach (DataRow itemUF in tableUF.Rows)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmdPreencheTabelaEstado = new SqlCommand(queryPreencheTabelaEstado(itemUF["SIGLA"].ToString()), conn);
                        cmdPreencheTabelaEstado.ExecuteNonQuery();
                    }
                }

                #endregion

                #region [ Import Table TCidade ]

                foreach (DataRow itemUF in tableUF.Rows)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmdPreencheTabelaCidade = new SqlCommand(queryPreencheTabelaCidade(itemUF["SIGLA"].ToString()), conn);
                        cmdPreencheTabelaCidade.ExecuteNonQuery();
                    }
                }

                #endregion

                #region [ Import Table TBairro ]

                foreach (DataRow itemUF_Cidade in tableUF_Cidade.Rows)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmdPreencheTabelaBairro = new SqlCommand(queryPreencheTabelaBairro(itemUF_Cidade["SIGLA"].ToString(), itemUF_Cidade["CIDADE"].ToString(), itemUF_Cidade["BAIRRO"].ToString().Replace("'", " ")), conn);
                        cmdPreencheTabelaBairro.ExecuteNonQuery();
                    }
                }

                #endregion

                #region [ Import Table TLogradouro ]

                foreach (DataRow itemUF_Cidade in tableUF_Cidade.Rows)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmdPreencheTabelaLogradouro = new SqlCommand(queryPreencheTabelaLogradouro(itemUF_Cidade["SIGLA"].ToString(), itemUF_Cidade["CIDADE"].ToString(), itemUF_Cidade["BAIRRO"].ToString().Replace("'", " ")), conn);
                        cmdPreencheTabelaLogradouro.ExecuteNonQuery();
                    }
                }

                #endregion

                #region [ Drop Tables TCorreio ]

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmdDropTables = new SqlCommand(queryDropTablesTCorreioTemp(), conn);
                    cmdDropTables.ExecuteNonQuery();
                }

                #endregion
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string queryDropTables()
        {
            StringBuilder queryDrop = new StringBuilder();

            //queryDrop.Append(@" IF OBJECT_ID('dbo.TCorreioTemp', 'U') IS NOT NULL");
            //queryDrop.Append(@"     DROP TABLE TCorreioTemp                      ");

            //queryDrop.Append(@" IF OBJECT_ID('dbo.TLogradouro', 'U') IS NOT NULL ");
            //queryDrop.Append(@"     DROP TABLE TLogradouro                       ");

            //queryDrop.Append(@" IF OBJECT_ID('dbo.TBairro', 'U') IS NOT NULL     ");
            //queryDrop.Append(@"     DROP TABLE TBairro                           ");

            //queryDrop.Append(@" IF OBJECT_ID('dbo.TCidade', 'U') IS NOT NULL     ");
            //queryDrop.Append(@"     DROP TABLE TCidade                           ");

            //queryDrop.Append(@" IF OBJECT_ID('dbo.TEstado', 'U') IS NOT NULL     ");
            //queryDrop.Append(@"     DROP TABLE TEstado                           ");

            queryDrop.Append(@" DELETE FROM TCorreioTemp        ");
            queryDrop.Append(@" DELETE FROM TLogradouro         ");
            queryDrop.Append(@" DELETE FROM TBairro             ");
            queryDrop.Append(@" DELETE FROM TCidade             ");
            queryDrop.Append(@" DELETE FROM TEstado             ");

            return queryDrop.ToString();
        }

        private string queryCreateTables()
        {
            StringBuilder queryCreate = new StringBuilder();

            #region [ TEstado ]

            queryCreate.Append(@" CREATE TABLE [TEstado]                  ");
            queryCreate.Append(@" ( [IDEstado] int PRIMARY KEY IDENTITY   ");
            queryCreate.Append(@" , [Sigla] nvarchar(2) NOT NULL          ");
            queryCreate.Append(@" ) ;                                     ");

            #endregion

            #region [ TCidade ]

            queryCreate.Append(@" CREATE TABLE [TCidade]                  ");
            queryCreate.Append(@" ( [IDCidade] int PRIMARY KEY IDENTITY   ");
            queryCreate.Append(@" , [NomeCidade] nvarchar(100) NOT NULL   ");
            queryCreate.Append(@" , [IDEstado] int NOT NULL               ");
            queryCreate.Append(@" );                                      ");

            queryCreate.Append(@" ALTER TABLE [TCidade]                   ");
            queryCreate.Append(@" ADD CONSTRAINT [TEstado_FK]             ");
            queryCreate.Append(@" FOREIGN KEY ([IDEstado])                ");
            queryCreate.Append(@" REFERENCES [TEstado]([IDEstado]);       ");

            #endregion

            #region [ TBairro ]

            queryCreate.Append(@" CREATE TABLE [TBairro]                  ");
            queryCreate.Append(@" ( [IDBairro] int PRIMARY KEY IDENTITY   ");
            queryCreate.Append(@" , [NomeBairro] nvarchar(100) NOT NULL   ");
            queryCreate.Append(@" , [IDCidade] int NOT NULL               ");
            queryCreate.Append(@" );                                      ");

            queryCreate.Append(@" ALTER TABLE [TBairro]                   ");
            queryCreate.Append(@" ADD CONSTRAINT [TCidade_FK]             ");
            queryCreate.Append(@" FOREIGN KEY ([IDCidade])                ");
            queryCreate.Append(@" REFERENCES [TCidade]([IDCidade]);       ");

            #endregion

            #region [ TLogradouro ]

            queryCreate.Append(@" CREATE TABLE [TLogradouro]                  ");
            queryCreate.Append(@" ( [IDLogradouro] int PRIMARY KEY IDENTITY   ");
            queryCreate.Append(@" , [NomeLogradouro] nvarchar(100) NOT NULL   ");
            queryCreate.Append(@" , [IDBairro] int NOT NULL                   ");
            queryCreate.Append(@" , [CEP] int NOT NULL                        ");
            queryCreate.Append(@" , [IDCidade] int NOT NULL                   ");
            queryCreate.Append(@" );                                          ");

            queryCreate.Append(@" ALTER TABLE [TLogradouro]                  ");
            queryCreate.Append(@" ADD CONSTRAINT [TBairro_FK]                 ");
            queryCreate.Append(@" FOREIGN KEY ([IDBairro])                    ");
            queryCreate.Append(@" REFERENCES [TBairro]([IDBairro]);           ");

            queryCreate.Append(@" ALTER TABLE [TLogradouro]                   ");
            queryCreate.Append(@" ADD CONSTRAINT [TCidade_LOGFK]              ");
            queryCreate.Append(@" FOREIGN KEY ([IDCidade])                    ");
            queryCreate.Append(@" REFERENCES [TCidade]([IDCidade]);           ");


            #endregion

            return queryCreate.ToString();
        }

        private string queryLerDistinctTabelaCorreioUF()
        {
            StringBuilder queryTabelaCorreio = new StringBuilder();

            queryTabelaCorreio.Append(@" SELECT DISTINCT  sg_uf  AS Sigla                   ");
            queryTabelaCorreio.Append(@"            FROM  TB_CORREIOS                       ");
            queryTabelaCorreio.Append(@"        ORDER BY  sg_uf                             ");

            return queryTabelaCorreio.ToString();
        }

        private string queryLerDistinctTabelaCorreioUF_Cidade()
        {
            StringBuilder queryTabelaCorreio = new StringBuilder();

            queryTabelaCorreio.Append(@" SELECT DISTINCT  nm_bai AS Bairro                  ");
            queryTabelaCorreio.Append(@"               ,  nm_cid  AS Cidade                 ");
            queryTabelaCorreio.Append(@"               ,  sg_uf  AS Sigla                   ");
            queryTabelaCorreio.Append(@"            FROM  TB_CORREIOS                       ");
            queryTabelaCorreio.Append(@"           WHERE  sg_uf ='RJ'                       ");
            queryTabelaCorreio.Append(@"        ORDER BY  sg_uf, nm_cid , nm_bai            ");

            return queryTabelaCorreio.ToString();
        }

        private string queryLerTabelaCorreio(string UF, string Cidade, string Bairro)
        {
            StringBuilder queryTabelaCorreio = new StringBuilder();

            queryTabelaCorreio.Append(@" SELECT  cd_cep AS CEP                              ");
            queryTabelaCorreio.Append(@" 	   , nm_end AS NomeLogradouro                   ");
            queryTabelaCorreio.Append(@" 	   , nm_bai AS NomeBairro                       ");
            queryTabelaCorreio.Append(@"       , nm_cid AS NomeCidade                       ");
            queryTabelaCorreio.Append(@"       , sg_uf  AS Sigla                            ");
            queryTabelaCorreio.Append(@"   FROM  TB_CORREIOS                                ");
            queryTabelaCorreio.Append(@"  WHERE  cd_cep is not NULL                         ");
            queryTabelaCorreio.Append(@"    AND  cd_cep <> 0                                ");
            queryTabelaCorreio.Append(@"    AND  sg_uf = '" + UF + "'                       ");
            queryTabelaCorreio.Append(@"    AND  nm_cid = '" + Cidade + "'                  ");
            queryTabelaCorreio.Append(@"    AND  nm_bai = '" + Bairro + "'                  ");

            return queryTabelaCorreio.ToString();
        }

        private string queryCriarTabelaCorreioTemp()
        {
            StringBuilder queryTabelaCorreio = new StringBuilder();

            queryTabelaCorreio.Append(@" CREATE TABLE  TCorreioTemp                         ");
            queryTabelaCorreio.Append(@"       ( CEP int                                    ");
            queryTabelaCorreio.Append(@" 	   , NomeLogradouro varchar(100)                ");
            queryTabelaCorreio.Append(@" 	   , NomeBairro varchar(100)                    ");
            queryTabelaCorreio.Append(@"       , NomeCidade varchar(100)                    ");
            queryTabelaCorreio.Append(@"       , Sigla varchar(2)                           ");
            queryTabelaCorreio.Append(@"       )                                            ");

            return queryTabelaCorreio.ToString();
        }

        private string queryPreencheTabelaEstado(string UF)
        {
            StringBuilder queryTabelaEstado = new StringBuilder();

            queryTabelaEstado.Append(@" INSERT INTO TEstado (Sigla)                                                                                 ");
            queryTabelaEstado.Append(@" SELECT * FROM ( SELECT DISTINCT RTrim(Sigla) AS Sigla FROM TCorreioTemp WHERE Sigla = '" + UF + "') AS TEMP ");
            queryTabelaEstado.Append(@" ORDER BY Sigla                                                                                              ");

            return queryTabelaEstado.ToString();
        }

        private string queryPreencheTabelaCidade(string UF)
        {
            StringBuilder queryTabelaCidade = new StringBuilder();

            queryTabelaCidade.Append(@" INSERT INTO TCidade (NomeCidade, IDEstado )                                                                 ");
            queryTabelaCidade.Append(@" SELECT * FROM (                                                                                             ");
            queryTabelaCidade.Append(@"                 SELECT DISTINCT RTrim(TCorreioTemp.NomeCidade) AS NomeCidade , TEstado.IDEstado             ");
            queryTabelaCidade.Append(@"                 FROM TCorreioTemp                                                                           ");
            queryTabelaCidade.Append(@"                 LEFT JOIN TEstado                                                                           ");
            queryTabelaCidade.Append(@"                 ON TCorreioTemp.Sigla = TEstado.Sigla                                                       ");
            queryTabelaCidade.Append(@"                 WHERE TCorreioTemp.Sigla = '" + UF + "'                                                     ");
            queryTabelaCidade.Append(@"                ) AS TEMP                                                                                    ");
            queryTabelaCidade.Append(@" ORDER BY NomeCidade                                                                                         ");

            return queryTabelaCidade.ToString();
        }

        private string queryPreencheTabelaBairro(string UF, string Cidade, string Bairro)
        {
            StringBuilder queryTabelaBairro = new StringBuilder();

            queryTabelaBairro.Append(@" INSERT INTO TBairro (NomeBairro, IDCidade )                                                                 ");
            queryTabelaBairro.Append(@" SELECT * FROM (                                                                                             ");
            queryTabelaBairro.Append(@"                 SELECT DISTINCT RTrim(TCorreioTemp.NomeBairro) AS NomeBairro , TCidade.IDCidade             ");
            queryTabelaBairro.Append(@"                 FROM TCorreioTemp                                                                           ");
            queryTabelaBairro.Append(@"                 LEFT JOIN TCidade                                                                           ");
            queryTabelaBairro.Append(@"                 ON TCorreioTemp.NomeCidade = TCidade.NomeCidade                                             ");
            queryTabelaBairro.Append(@"                 WHERE TCorreioTemp.Sigla = '" + UF + "'                                                     ");
            queryTabelaBairro.Append(@"                   AND TCorreioTemp.NomeCidade = '" + Cidade + "'                                            ");
            queryTabelaBairro.Append(@"                   AND TCorreioTemp.NomeBairro = '" + Bairro + "'                                            ");
            queryTabelaBairro.Append(@"                ) AS TEMP                                                                                    ");
            queryTabelaBairro.Append(@" ORDER BY NomeBairro                                                                                         ");

            return queryTabelaBairro.ToString();
        }

        private string queryPreencheTabelaLogradouro(string UF, string Cidade, string Bairro)
        {
            StringBuilder queryTabelaLogradouro = new StringBuilder();

            queryTabelaLogradouro.Append(@" INSERT INTO TLogradouro (NomeLogradouro, IDBairro, CEP, IDCidade )                                      ");
            queryTabelaLogradouro.Append(@" SELECT * FROM (                                                                                         ");
            queryTabelaLogradouro.Append(@"                 SELECT DISTINCT RTrim(TCorreioTemp.NomeLogradouro) AS NomeLogradouro ,                  ");
            queryTabelaLogradouro.Append(@"                 TBairro.IDBairro, TCorreioTemp.CEP, TCidade.IDCidade                                    ");
            queryTabelaLogradouro.Append(@"                 FROM TCorreioTemp , TBairro , TCidade                                                   ");
            queryTabelaLogradouro.Append(@"                 WHERE TCorreioTemp.Sigla = '" + UF + "'                                                 ");
            queryTabelaLogradouro.Append(@"                 AND TCorreioTemp.NomeCidade = '" + Cidade + "'                                          ");
            queryTabelaLogradouro.Append(@"                 AND TCorreioTemp.NomeBairro = '" + Bairro + "'                                          ");
            queryTabelaLogradouro.Append(@"                 AND TCorreioTemp.NomeBairro = TBairro.NomeBairro                                        ");
            queryTabelaLogradouro.Append(@"                 AND TCorreioTemp.NomeCidade = TCidade.NomeCidade                                        ");
            queryTabelaLogradouro.Append(@"                 AND TBairro.IDCidade = TCidade.IDCidade                                                 ");
            queryTabelaLogradouro.Append(@"                 AND TCorreioTemp.CEP IS NOT NULL                                                        ");
            queryTabelaLogradouro.Append(@"                 AND TCorreioTemp.CEP > 0                                                                ");
            queryTabelaLogradouro.Append(@"                ) AS TEMP                                                                                ");
            queryTabelaLogradouro.Append(@" ORDER BY NomeLogradouro                                                                                 ");

            return queryTabelaLogradouro.ToString();
        }

        private string queryDropTablesTCorreioTemp()
        {
            StringBuilder queryDrop = new StringBuilder();

            queryDrop.Append(@" DELETE FROM TCorreioTemp        ");
            //queryDrop.Append(@" IF OBJECT_ID('dbo.TCorreioTemp', 'U') IS NOT NULL");
            //queryDrop.Append(@"     DROP TABLE TCorreioTemp                      ");

            return queryDrop.ToString();
        }

        #endregion

        #region [ SERVIÇO IMPORTAÇÃO SINAF ]

        public int ObterTempoVerificaSINAF()
        {

            try
            {

                #region [ Table TParametro ]

                DataTable tableParametro = new DataTable();

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {

                    conn.Open();

                    SqlCommand cmdLerTabelaParametro = new SqlCommand(queryLerTabelaParametro(), conn);
                    SqlDataReader readerParametro = cmdLerTabelaParametro.ExecuteReader();
                    tableParametro.Load(readerParametro);
                }

                if (tableParametro.Rows.Count > 0)
                    return Convert.ToInt32(tableParametro.Rows[0]["TempoVerificaERPDias"].ToString());
                else
                    return 0;

                #endregion

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExcluirEntrevistas()
        {
            try
            {
                int tempoServidor = 90;

                #region [ TABLES ]

                DataTable tableEntrevista = new DataTable();
                DataTable tableParametro = new DataTable();
                string entrevistas = string.Empty;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmdLerTabelaParametro = new SqlCommand(queryLerTabelaParametro(), conn);
                    SqlDataReader readerParametro = cmdLerTabelaParametro.ExecuteReader();
                    tableParametro.Load(readerParametro);
                }

                if (tableParametro.Rows.Count > 0)
                    tempoServidor = Convert.ToInt32(tableParametro.Rows[0]["TempoDadosServidorDias"].ToString());

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string dataLimite = DateTime.Now.AddDays(-tempoServidor).ToString("yyyy-MM-dd 00:00:00");
                    SqlCommand cmdLerTabelaEntrevista = new SqlCommand(querySelectEntrevistaDataInclusao(dataLimite), conn);
                    SqlDataReader readerEntrevista = cmdLerTabelaEntrevista.ExecuteReader();
                    tableEntrevista.Load(readerEntrevista);
                }

                foreach (DataRow itemEntrevista in tableEntrevista.Rows)
                {
                    entrevistas += itemEntrevista["CodigoEntrevista"] + ",";
                }

                if (tableEntrevista.Rows.Count > 0)
                    entrevistas = entrevistas.Substring(0, entrevistas.Length - 1);

                #endregion

                #region [ DELETE ]

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand cmdDeleteMobileTSimuladorSubRenda = new SqlCommand(queryDeleteMobileTSimuladorSubRenda(entrevistas), conn, transaction);
                            cmdDeleteMobileTSimuladorSubRenda.ExecuteNonQuery();

                            SqlCommand cmdDeleteMobileTSimuladorSubFuneral = new SqlCommand(queryDeleteMobileTSimuladorSubFuneral(entrevistas), conn, transaction);
                            cmdDeleteMobileTSimuladorSubFuneral.ExecuteNonQuery();

                            SqlCommand cmdDeleteMobileTSimuladorSubAgregado = new SqlCommand(queryDeleteMobileTSimuladorSubAgregado(entrevistas), conn, transaction);
                            cmdDeleteMobileTSimuladorSubAgregado.ExecuteNonQuery();

                            SqlCommand cmdDeleteMobileTSimuladorProduto = new SqlCommand(queryDeleteMobileTSimuladorProduto(entrevistas), conn, transaction);
                            cmdDeleteMobileTSimuladorProduto.ExecuteNonQuery();

                            SqlCommand cmdDeleteMobileTIncompletaResposta = new SqlCommand(queryDeleteMobileTIncompletaResposta(entrevistas), conn, transaction);
                            cmdDeleteMobileTIncompletaResposta.ExecuteNonQuery();

                            SqlCommand cmdDeleteMobileTIncompleta = new SqlCommand(queryDeleteMobileTIncompleta(entrevistas), conn, transaction);
                            cmdDeleteMobileTIncompleta.ExecuteNonQuery();

                            SqlCommand cmdDeleteMobileTGPS = new SqlCommand(queryDeleteMobileTGPS(entrevistas), conn, transaction);
                            cmdDeleteMobileTGPS.ExecuteNonQuery();

                            SqlCommand cmdDeleteMobileTResposta = new SqlCommand(queryDeleteMobileTResposta(entrevistas), conn, transaction);
                            cmdDeleteMobileTResposta.ExecuteNonQuery();

                            SqlCommand cmdDeleteMobileTEntrevistadoEndereco = new SqlCommand(queryDeleteMobileTEntrevistadoEndereco(entrevistas), conn, transaction);
                            cmdDeleteMobileTEntrevistadoEndereco.ExecuteNonQuery();

                            SqlCommand cmdDeleteMobileTEntrevistado = new SqlCommand(queryDeleteMobileTEntrevistado(entrevistas), conn, transaction);
                            cmdDeleteMobileTEntrevistado.ExecuteNonQuery();

                            SqlCommand cmdDeleteMobileTEntrevista = new SqlCommand(queryDeleteMobileTEntrevista(entrevistas), conn, transaction);
                            cmdDeleteMobileTEntrevista.ExecuteNonQuery();

                            SqlCommand cmdDeleteTFaixa = new SqlCommand(queryDeleteFaixa(entrevistas), conn, transaction);
                            cmdDeleteTFaixa.ExecuteNonQuery();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {

            }
        }

        public bool ImportarBaseSINAF()
        {
            try
            {
                ImportarUsuario();
                ImportarProfissao();
                ImportarOrigemVenda();
                ImportarFaixas();
                //ExcluirEntrevistas();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region [ SERVIÇO EXPORTAÇÃO SINAF ]

        public bool ExportarBaseSINAF()
        {
            try
            {
                DataTable tableTEntrevista = new DataTable();
                DataTable tableTEntrevistado = new DataTable();
                DataTable tableTEntrevistadoEndereco = new DataTable();
                DataTable tableTResposta = new DataTable();
                bool erroBulk = false;
                string erro = string.Empty;

                #region [ TABLES ]

                using (SqlConnection connCab = new SqlConnection(ConnectionString))
                {
                    connCab.Open();

                    SqlCommand cmdLerTEntrevista = new SqlCommand(querySelectEntrevista(), connCab);
                    SqlDataReader readerTEntrevista = cmdLerTEntrevista.ExecuteReader();
                    tableTEntrevista.Load(readerTEntrevista);

                }

                using (SqlConnection connCab = new SqlConnection(ConnectionString))
                {
                    connCab.Open();
                    SqlCommand cmdUpdateEntrevistadoTelefone = new SqlCommand(queryUpdateEntrevistadoTelefone(), connCab);
                    cmdUpdateEntrevistadoTelefone.ExecuteNonQuery();

                    SqlCommand cmdLerTEntrevistado = new SqlCommand(querySelectEntrevistado(), connCab);
                    SqlDataReader readerTEntrevistado = cmdLerTEntrevistado.ExecuteReader();
                    tableTEntrevistado.Load(readerTEntrevistado);
                }

                using (SqlConnection connCab = new SqlConnection(ConnectionString))
                {
                    connCab.Open();

                    SqlCommand cmdLerTEntrevistadoEndereco = new SqlCommand(querySelectEntrevistadoEndereco(), connCab);
                    SqlDataReader readerTEntrevistadoEndereco = cmdLerTEntrevistadoEndereco.ExecuteReader();
                    tableTEntrevistadoEndereco.Load(readerTEntrevistadoEndereco);

                }


                using (SqlConnection connCab = new SqlConnection(ConnectionString))
                {
                    connCab.Open();
                    //SqlCommand cmdUpdateRespostaCodigo32 = new SqlCommand(queryUpdateRespostaCodigo32Seq3(), connCab);
                    //cmdUpdateRespostaCodigo32.ExecuteNonQuery();

                    SqlCommand cmdLerTResposta = new SqlCommand(querySelectResposta(), connCab);
                    SqlDataReader readerTResposta = cmdLerTResposta.ExecuteReader();
                    tableTResposta.Load(readerTResposta);
                }

                #endregion

                #region [ BULKCOPY ]

                using (SqlConnection destinationConnection = new SqlConnection(ConnectionStringInterface))
                {
                    destinationConnection.Open();

                    using (SqlTransaction transaction = destinationConnection.BeginTransaction())
                    {
                        try
                        {
                            #region [ Entrevista ]

                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection, SqlBulkCopyOptions.KeepIdentity, transaction))
                            {
                                bulkCopy.DestinationTableName = "TB_ENTREVISTA";
                                bulkCopy.ColumnMappings.Clear();
                                bulkCopy.ColumnMappings.Add("CodigoEntrevista", "cd_eva");
                                bulkCopy.ColumnMappings.Add("CodigoColaborador", "cd_clb");
                                bulkCopy.ColumnMappings.Add("DataEntrevista", "dt_eva");
                                bulkCopy.ColumnMappings.Add("CodigoUsuario", "cd_usuicl");
                                bulkCopy.ColumnMappings.Add("DataInclusao", "dt_icl");
                                bulkCopy.ColumnMappings.Add("CodigoQuestionario", "cd_qst");
                                bulkCopy.ColumnMappings.Add("OrigemVenda", "cd_orivnd");

                                bulkCopy.WriteToServer(tableTEntrevista);
                            }

                            #endregion

                            #region [ Entrevistado ]

                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection, SqlBulkCopyOptions.KeepIdentity, transaction))
                            {
                                bulkCopy.DestinationTableName = "TB_ENTREVISTADO";
                                bulkCopy.ColumnMappings.Clear();
                                bulkCopy.ColumnMappings.Add("CodigoEntrevista", "cd_eva");
                                bulkCopy.ColumnMappings.Add("Nome", "nm_entado");
                                bulkCopy.ColumnMappings.Add("CPF", "nr_cpf");
                                bulkCopy.ColumnMappings.Add("DataNascimento", "dt_nasc");
                                bulkCopy.ColumnMappings.Add("EstadoCivil", "tp_estciv");
                                bulkCopy.ColumnMappings.Add("IDProfissao", "cd_prf");
                                bulkCopy.ColumnMappings.Add("FaixaEtaria", "tp_faieta");
                                bulkCopy.ColumnMappings.Add("FaixaEtariaConjuge", "tp_faietacjg");
                                bulkCopy.ColumnMappings.Add("IDProfissaoConjuge", "cd_prfcjg");
                                bulkCopy.ColumnMappings.Add("CapitalLimitado", "fl_cpiltd");
                                bulkCopy.ColumnMappings.Add("CapitalLimitadoConjuge", "fl_cpiltdcjg");
                                bulkCopy.ColumnMappings.Add("DDD", "nr_dddtelres");
                                bulkCopy.ColumnMappings.Add("Telefone", "nr_telres");
                                bulkCopy.ColumnMappings.Add("DDDCelular", "nr_dddtelcel");
                                bulkCopy.ColumnMappings.Add("Celular", "nr_telcel");
                                bulkCopy.ColumnMappings.Add("Sexo", "tp_sex");
                                bulkCopy.ColumnMappings.Add("Informacao", "fl_infemlcel");

                                bulkCopy.WriteToServer(tableTEntrevistado);
                            }

                            #endregion

                            #region [ EntrevistadoEndereco ]

                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection, SqlBulkCopyOptions.KeepIdentity, transaction))
                            {
                                bulkCopy.DestinationTableName = "TB_ENTREVISTADO_ENDERECO";
                                bulkCopy.ColumnMappings.Clear();
                                bulkCopy.ColumnMappings.Add("CodigoEntrevista", "cd_eva");
                                bulkCopy.ColumnMappings.Add("Endereco", "ds_end");
                                bulkCopy.ColumnMappings.Add("Numero", "nr_end");
                                bulkCopy.ColumnMappings.Add("Bairro", "ds_bai");
                                bulkCopy.ColumnMappings.Add("Cidade", "ds_cid");
                                bulkCopy.ColumnMappings.Add("UF", "sg_uf");
                                bulkCopy.ColumnMappings.Add("CEP", "ds_cep");
                                bulkCopy.ColumnMappings.Add("Complemento", "ds_cpl");
                                bulkCopy.ColumnMappings.Add("Email", "ds_eml");

                                bulkCopy.WriteToServer(tableTEntrevistadoEndereco);
                            }

                            #endregion

                            #region [ Resposta ]

                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection, SqlBulkCopyOptions.KeepIdentity, transaction))
                            {
                                bulkCopy.DestinationTableName = "TB_RESPOSTA";
                                bulkCopy.ColumnMappings.Clear();
                                bulkCopy.ColumnMappings.Add("CodigoEntrevista", "cd_eva");
                                bulkCopy.ColumnMappings.Add("CodigoPergunta", "cd_pgt");
                                bulkCopy.ColumnMappings.Add("CodigoOpcao", "cd_opc");
                                bulkCopy.ColumnMappings.Add("CodigoSeqResposta", "nr_seqrta");
                                bulkCopy.ColumnMappings.Add("TextoResposta", "ds_rta");
                                bulkCopy.ColumnMappings.Add("TextoSubResposta", "ds_cmpopc");

                                bulkCopy.WriteToServer(tableTResposta);
                            }

                            #endregion

                            transaction.Commit();

                            erroBulk = false;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();

                            erroBulk = true;
                        }
                    }
                }

                #endregion

                #region [ ERRO ]

                if (erroBulk)
                {
                    foreach (DataRow itemEntrevista in tableTEntrevista.Rows)
                    {
                        string codigo = itemEntrevista["CodigoEntrevista"].ToString();
                        string colaborador = itemEntrevista["CodigoColaborador"].ToString();
                        string data = Convert.ToDateTime(itemEntrevista["DataEntrevista"].ToString()).ToString("yyyy-MM-dd");
                        try
                        {
                            DataRow[] rowsEntrevistado = tableTEntrevistado.Select("CodigoEntrevista =" + codigo);
                            DataRow[] rowsEntrevistadoEndereco = tableTEntrevistadoEndereco.Select("CodigoEntrevista =" + codigo);
                            DataRow[] rowsResposta = tableTResposta.Select("CodigoEntrevista =" + codigo);

                            if (rowsEntrevistado.Length < 1)
                                throw new Exception("MobileTEntrevistado sem registro.");

                            if (rowsEntrevistadoEndereco.Length < 1)
                                throw new Exception("MobileTEntrevistadoEndereco sem registro.");

                            if (rowsResposta.Length < 1)
                                throw new Exception("MobileTResposta sem registro.");


                            using (SqlConnection destinationConnection = new SqlConnection(ConnectionStringInterface))
                            {
                                destinationConnection.Open();

                                SqlCommand cmdInsertTB_ENTREVISTA = new SqlCommand(queryInsertTB_ENTREVISTA(itemEntrevista), destinationConnection);
                                cmdInsertTB_ENTREVISTA.ExecuteNonQuery();

                                SqlCommand cmdInsertTB_ENTREVISTADO = new SqlCommand(queryInsertTB_ENTREVISTADO(rowsEntrevistado[0]), destinationConnection);
                                cmdInsertTB_ENTREVISTADO.ExecuteNonQuery();

                                SqlCommand cmdInsertTB_ENTREVISTADO_ENDERECO = new SqlCommand(queryInsertTB_ENTREVISTADO_ENDERECO(rowsEntrevistadoEndereco[0]), destinationConnection);
                                cmdInsertTB_ENTREVISTADO_ENDERECO.ExecuteNonQuery();

                                foreach (DataRow itemResposta in rowsResposta)
                                {
                                    SqlCommand cmdInsertTB_RESPOSTA = new SqlCommand(queryInsertTB_RESPOSTA(itemResposta), destinationConnection);
                                    cmdInsertTB_RESPOSTA.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            using (SqlConnection connCab = new SqlConnection(ConnectionString))
                            {
                                connCab.Open();

                                SqlCommand cmdInsertServicoTEntrevista = new SqlCommand(queryInsertServicoTEntrevista(codigo, colaborador, data, ex.Message), connCab);
                                cmdInsertServicoTEntrevista.ExecuteNonQuery();
                            }

                            using (SqlConnection destinationConnection = new SqlConnection(ConnectionStringInterface))
                            {
                                destinationConnection.Open();

                                SqlCommand cmdDeleteTB_RESPOSTA = new SqlCommand(queryDeleteTB_RESPOSTA(codigo), destinationConnection);
                                cmdDeleteTB_RESPOSTA.ExecuteNonQuery();

                                SqlCommand cmdDeleteTB_ENTREVISTADO_ENDERECO = new SqlCommand(queryDeleteTB_ENTREVISTADO_ENDERECO(codigo), destinationConnection);
                                cmdDeleteTB_ENTREVISTADO_ENDERECO.ExecuteNonQuery();

                                SqlCommand cmdDeleteTB_ENTREVISTADO = new SqlCommand(queryDeleteTB_ENTREVISTADO(codigo), destinationConnection);
                                cmdDeleteTB_ENTREVISTADO.ExecuteNonQuery();

                                SqlCommand cmdDeleteTB_ENTREVISTA = new SqlCommand(queryDeleteTB_ENTREVISTA(codigo), destinationConnection);
                                cmdDeleteTB_ENTREVISTA.ExecuteNonQuery();

                            }
                        }
                    }
                }

                #endregion

                #region [ DISPOSE ]

                tableTEntrevista.Dispose();
                tableTEntrevistado.Dispose();
                tableTEntrevistadoEndereco.Dispose();
                tableTResposta.Dispose();

                #endregion

                #region [ UPDATE ]

                using (SqlConnection connCab = new SqlConnection(ConnectionString))
                {
                    connCab.Open();

                    SqlCommand cmdUpdateEntrevista = new SqlCommand(queryUpdateEntrevista(), connCab);
                    cmdUpdateEntrevista.ExecuteNonQuery();

                    SqlCommand cmdUpdateEntrevistado = new SqlCommand(queryUpdateEntrevistado(), connCab);
                    cmdUpdateEntrevistado.ExecuteNonQuery();

                    SqlCommand cmdUpdateEntrevistadoEndereco = new SqlCommand(queryUpdateEntrevistadoEndereco(), connCab);
                    cmdUpdateEntrevistadoEndereco.ExecuteNonQuery();

                    SqlCommand cmdUpdateResposta = new SqlCommand(queryUpdateResposta(), connCab);
                    cmdUpdateResposta.ExecuteNonQuery();

                }

                #endregion                

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }        

        #endregion

        #region [ Tabela MobileTEntrevista ]

        private string querySelectEntrevista()
        {
            StringBuilder querySelect = new StringBuilder();

            querySelect.Append(@" SELECT   CodigoEntrevista                     ");
            querySelect.Append(@" 	     , CodigoColaborador                    ");
            querySelect.Append(@" 	     , DataEntrevista                       ");
            querySelect.Append(@" 	     , CodigoUsuario                        ");
            querySelect.Append(@" 	     , getdate() as DataInclusao            ");
            querySelect.Append(@" 	     , 3 AS CodigoQuestionario              ");
            querySelect.Append(@" 	     , OrigemVenda                          ");
            querySelect.Append(@" 	     , Exportado                            ");
            querySelect.Append(@"   FROM  MobileTEntrevista                     ");
            querySelect.Append(@"  WHERE  Exportado IS NULL OR Exportado = 0    ");

            return querySelect.ToString();
        }

        private string queryUpdateEntrevista()
        {
            StringBuilder queryUpdate = new StringBuilder();

            queryUpdate.Append(@" UPDATE  MobileTEntrevista                     ");
            queryUpdate.Append(@"    SET  Exportado = 1                         ");
            queryUpdate.Append(@"  WHERE  Exportado IS NULL OR Exportado = 0    ");

            return queryUpdate.ToString();
        }

        private string queryInsertTB_ENTREVISTA(DataRow entrevista)
        {
            StringBuilder queryInsert = new StringBuilder();

            queryInsert.Append(@" INSERT INTO TB_ENTREVISTA                         ");
            queryInsert.Append(@" 	     ( cd_eva                                   ");
            queryInsert.Append(@" 	     , cd_clb                                   ");
            queryInsert.Append(@" 	     , dt_eva                                   ");
            queryInsert.Append(@" 	     , cd_usuicl                                ");
            queryInsert.Append(@" 	     , dt_icl                                   ");
            queryInsert.Append(@" 	     , cd_qst                                   ");
            queryInsert.Append(@" 	     , cd_orivnd )                              ");
            queryInsert.Append(@" VALUES ( " + entrevista["CodigoEntrevista"] + "   ");
            queryInsert.Append(@" 	     , " + entrevista["CodigoColaborador"] + "  ");
            queryInsert.Append(@" 	     , '" + entrevista["DataEntrevista"] + "'   ");
            queryInsert.Append(@" 	     , " + entrevista["CodigoUsuario"] + "      ");
            queryInsert.Append(@" 	     , '" + entrevista["DataInclusao"] + "'     ");
            queryInsert.Append(@" 	     , " + entrevista["CodigoQuestionario"] + " ");
            queryInsert.Append(@" 	     , '" + entrevista["OrigemVenda"] + "' )    ");

            return queryInsert.ToString();
        }

        private string queryDeleteTB_ENTREVISTA(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM TB_ENTREVISTA                         ");
            queryDelete.Append(@"  WHERE cd_eva = " + codigoEntrevista + "          ");

            return queryDelete.ToString();
        }

        private string queryInsertServicoTEntrevista(string codigo, string colaborador, string data, string mensagem)
        {
            StringBuilder queryInsert = new StringBuilder();

            string dataErro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            queryInsert.Append(@" INSERT INTO ServicoTEntrevista                    ");
            queryInsert.Append(@" 	     ( CodigoEntrevista                         ");
            queryInsert.Append(@" 	     , CodigoColaborador                        ");
            queryInsert.Append(@" 	     , DataEntrevista                           ");
            queryInsert.Append(@" 	     , DataErro                                 ");
            queryInsert.Append(@" 	     , Mensagem  )                              ");
            queryInsert.Append(@" VALUES ( " + codigo + "                           ");
            queryInsert.Append(@" 	     , " + colaborador + "                      ");
            queryInsert.Append(@" 	     , '" + data + "'                            ");
            queryInsert.Append(@" 	     , '" + dataErro + "'                       ");
            queryInsert.Append(@" 	     , '" + mensagem + "' )                     ");

            return queryInsert.ToString();
        }

        private string querySelectEntrevistaDataInclusao(string data)
        {
            StringBuilder querySelect = new StringBuilder();

            querySelect.Append(@" SET DATEFORMAT YMD;                           ");
            querySelect.Append(@" SELECT   CodigoEntrevista                     ");
            querySelect.Append(@" 	     , CodigoColaborador                    ");
            querySelect.Append(@" 	     , DataEntrevista                       ");
            querySelect.Append(@" 	     , CodigoUsuario                        ");
            querySelect.Append(@" 	     , DataInclusao                         ");
            querySelect.Append(@" 	     , CodigoQuestionario                   ");
            querySelect.Append(@" 	     , OrigemVenda                          ");
            querySelect.Append(@" 	     , Exportado                            ");
            querySelect.Append(@"   FROM  MobileTEntrevista                     ");
            querySelect.Append(@"  WHERE  DataInclusao < '" + data + "'         ");

            return querySelect.ToString();
        }

        private string queryDeleteMobileTEntrevista(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTEntrevista                         ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela MobileTEntrevistado ]

        private string querySelectEntrevistado()
        {
            StringBuilder querySelect = new StringBuilder();

            querySelect.Append(@" SELECT   CodigoEntrevista                     ");
            querySelect.Append(@" 	     , Nome                                 ");
            querySelect.Append(@" 	     , CPF                                  ");
            querySelect.Append(@" 	     , DataNascimento                       ");
            querySelect.Append(@" 	     , EstadoCivil                          ");
            querySelect.Append(@" 	     , IDProfissao                          ");
            querySelect.Append(@" 	     , FaixaEtaria                          ");
            querySelect.Append(@" 	     , FaixaEtariaConjuge                   ");
            querySelect.Append(@" 	     , IDProfissaoConjuge                   ");
            querySelect.Append(@" 	     , CapitalLimitado                      ");
            querySelect.Append(@" 	     , CapitalLimitadoConjuge               ");
            querySelect.Append(@" 	     , DDD                                  ");
            querySelect.Append(@" 	     , Telefone                             ");
            querySelect.Append(@" 	     , DDDCelular                           ");
            querySelect.Append(@" 	     , Celular                              ");
            querySelect.Append(@" 	     , Sexo                                 ");
            querySelect.Append(@" 	     , Informacao                           ");
            querySelect.Append(@" 	     , Exportado                            ");
            querySelect.Append(@"   FROM  MobileTEntrevistado                   ");
            querySelect.Append(@"  WHERE  Exportado IS NULL OR Exportado = 0    ");

            return querySelect.ToString();
        }

        private string queryUpdateEntrevistado()
        {
            StringBuilder queryUpdate = new StringBuilder();

            queryUpdate.Append(@" UPDATE  MobileTEntrevistado                   ");
            queryUpdate.Append(@"    SET  Exportado = 1                         ");
            queryUpdate.Append(@"  WHERE  Exportado IS NULL OR Exportado = 0    ");

            return queryUpdate.ToString();
        }

        private string queryUpdateEntrevistadoTelefone()
        {
            StringBuilder queryUpdate = new StringBuilder();

            queryUpdate.Append(@" UPDATE  MobileTEntrevistado                   ");
            queryUpdate.Append(@"    SET  Telefone = REPLACE(Telefone, '-', '') ");
            queryUpdate.Append(@"      ,  Celular = REPLACE(Celular, '-', '')   ");
            queryUpdate.Append(@"  WHERE  Exportado IS NULL OR Exportado = 0    ");

            return queryUpdate.ToString();
        }

        private string queryInsertTB_ENTREVISTADO(DataRow entrevistado)
        {
            int informacao = Convert.ToBoolean(entrevistado["Informacao"]) ? 1 : 0;
            StringBuilder queryInsert = new StringBuilder();

            queryInsert.Append(@" INSERT INTO TB_ENTREVISTADO                               ");
            queryInsert.Append(@" 	     ( cd_eva                                           ");
            queryInsert.Append(@" 	     , nm_entado                                        ");
            queryInsert.Append(@" 	     , nr_cpf                                           ");
            queryInsert.Append(@" 	     , dt_nasc                                          ");
            queryInsert.Append(@" 	     , tp_estciv                                        ");
            queryInsert.Append(@" 	     , cd_prf                                           ");
            queryInsert.Append(@" 	     , tp_faieta                                        ");
            queryInsert.Append(@" 	     , tp_faietacjg                                     ");
            queryInsert.Append(@" 	     , cd_prfcjg                                        ");
            queryInsert.Append(@" 	     , fl_cpiltd                                        ");
            queryInsert.Append(@" 	     , fl_cpiltdcjg                                     ");
            queryInsert.Append(@" 	     , nr_dddtelres                                     ");
            queryInsert.Append(@" 	     , nr_telres                                        ");
            queryInsert.Append(@" 	     , nr_dddtelcel                                     ");
            queryInsert.Append(@" 	     , nr_telcel                                        ");
            queryInsert.Append(@" 	     , tp_sex                                           ");
            queryInsert.Append(@" 	     , fl_infemlcel )                                   ");
            queryInsert.Append(@" VALUES ( " + entrevistado["CodigoEntrevista"] + "         ");
            queryInsert.Append(@" 	     , '" + entrevistado["Nome"] + "'                   ");
            queryInsert.Append(@" 	     , '" + entrevistado["CPF"] + "'                    ");
            queryInsert.Append(@" 	     , '" + entrevistado["DataNascimento"] + "'         ");
            queryInsert.Append(@" 	     , " + entrevistado["EstadoCivil"] + "              ");
            queryInsert.Append(@" 	     , " + entrevistado["IDProfissao"] + "              ");
            queryInsert.Append(@" 	     , " + entrevistado["FaixaEtaria"] + "              ");
            queryInsert.Append(@" 	     , " + entrevistado["FaixaEtariaConjuge"] + "       ");
            queryInsert.Append(@" 	     , " + entrevistado["IDProfissaoConjuge"] + "       ");
            queryInsert.Append(@" 	     , '" + entrevistado["CapitalLimitado"] + "'        ");
            queryInsert.Append(@" 	     , '" + entrevistado["CapitalLimitadoConjuge"] + "' ");
            queryInsert.Append(@" 	     , '" + entrevistado["DDD"] + "'                    ");
            queryInsert.Append(@" 	     , '" + entrevistado["Telefone"] + "'               ");
            queryInsert.Append(@" 	     , '" + entrevistado["DDDCelular"] + "'             ");
            queryInsert.Append(@" 	     , '" + entrevistado["Celular"] + "'                ");
            queryInsert.Append(@" 	     , '" + entrevistado["Sexo"] + "'                   ");
            queryInsert.Append(@" 	     , " + informacao + "  )                            ");

            return queryInsert.ToString();
        }

        private string queryDeleteTB_ENTREVISTADO(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM TB_ENTREVISTADO                       ");
            queryDelete.Append(@"  WHERE cd_eva = " + codigoEntrevista + "          ");

            return queryDelete.ToString();
        }

        private string queryDeleteMobileTEntrevistado(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTEntrevistado                       ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela MobileTEntrevistadoEndereco ]

        private string querySelectEntrevistadoEndereco()
        {
            StringBuilder querySelect = new StringBuilder();

            querySelect.Append(@" SELECT   CodigoEntrevista                     ");
            querySelect.Append(@" 	     , Endereco                             ");
            querySelect.Append(@" 	     , Numero                               ");
            querySelect.Append(@" 	     , Bairro                               ");
            querySelect.Append(@" 	     , Cidade                               ");
            querySelect.Append(@" 	     , UF                                   ");
            querySelect.Append(@" 	     , CEP                                  ");
            querySelect.Append(@" 	     , Complemento                          ");
            querySelect.Append(@" 	     , Email                                ");
            querySelect.Append(@" 	     , Exportado                            ");
            querySelect.Append(@"   FROM  MobileTEntrevistadoEndereco           ");
            querySelect.Append(@"  WHERE  Exportado IS NULL OR Exportado = 0    ");

            return querySelect.ToString();
        }

        private string queryUpdateEntrevistadoEndereco()
        {
            StringBuilder queryUpdate = new StringBuilder();

            queryUpdate.Append(@" UPDATE  MobileTEntrevistadoEndereco           ");
            queryUpdate.Append(@"    SET  Exportado = 1                         ");
            queryUpdate.Append(@"  WHERE  Exportado IS NULL OR Exportado = 0    ");

            return queryUpdate.ToString();
        }

        private string queryInsertTB_ENTREVISTADO_ENDERECO(DataRow entrevistado)
        {
            StringBuilder queryInsert = new StringBuilder();

            queryInsert.Append(@" INSERT INTO TB_ENTREVISTADO_ENDERECO                     ");
            queryInsert.Append(@" 	     ( cd_eva                                          ");
            queryInsert.Append(@" 	     , ds_end                                          ");
            queryInsert.Append(@" 	     , nr_end                                          ");
            queryInsert.Append(@" 	     , ds_bai                                          ");
            queryInsert.Append(@" 	     , ds_cid                                          ");
            queryInsert.Append(@" 	     , sg_uf                                           ");
            queryInsert.Append(@" 	     , ds_cep                                          ");
            queryInsert.Append(@" 	     , ds_cpl                                          ");
            queryInsert.Append(@" 	     , ds_eml  )                                       ");
            queryInsert.Append(@" VALUES ( " + entrevistado["CodigoEntrevista"] + "        ");
            queryInsert.Append(@" 	     , '" + entrevistado["Endereco"] + "'              ");
            queryInsert.Append(@" 	     , " + entrevistado["Numero"] + "                  ");
            queryInsert.Append(@" 	     , '" + entrevistado["Bairro"] + "'                ");
            queryInsert.Append(@" 	     , '" + entrevistado["Cidade"] + "'                ");
            queryInsert.Append(@" 	     , '" + entrevistado["UF"] + "'                    ");
            queryInsert.Append(@" 	     , '" + entrevistado["CEP"] + "'                   ");
            queryInsert.Append(@" 	     , '" + entrevistado["Complemento"] + "'           ");
            queryInsert.Append(@" 	     , '" + entrevistado["Email"] + "'  )              ");

            return queryInsert.ToString();
        }

        private string queryDeleteTB_ENTREVISTADO_ENDERECO(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM TB_ENTREVISTADO_ENDERECO              ");
            queryDelete.Append(@"  WHERE cd_eva = " + codigoEntrevista + "          ");

            return queryDelete.ToString();
        }

        private string queryDeleteMobileTEntrevistadoEndereco(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTEntrevistadoEndereco               ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela MobileTGPS ]

        private string queryDeleteMobileTGPS(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTGPS                                ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela MobileTIncompleta ]

        private string queryDeleteMobileTIncompleta(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTIncompleta                         ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela MobileTIncompletaResposta ]

        private string queryDeleteMobileTIncompletaResposta(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTIncompletaResposta                 ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela MobileTResposta ]

        private string querySelectResposta()
        {
            StringBuilder querySelect = new StringBuilder();

            querySelect.Append(@" SELECT   CodigoEntrevista                                      ");
            querySelect.Append(@" 	     , CodigoPergunta                                        ");
            querySelect.Append(@" 	     , CodigoOpcao                                           ");
            querySelect.Append(@" 	     , CodigoSeqResposta                                     ");
            querySelect.Append(@" 	     , TextoResposta                                         ");
            querySelect.Append(@"   , CASE WHEN CodigoPergunta = 32  AND  CodigoSeqResposta = 3  ");
            querySelect.Append(@" THEN ''                                                        ");
            querySelect.Append(@" ELSE TextoSubResposta                                          ");
            querySelect.Append(@" END AS TextoSubResposta                                        ");
            querySelect.Append(@" 	     , Exportado                                             ");
            querySelect.Append(@"   FROM  MobileTResposta                                        ");
            querySelect.Append(@"  WHERE  Exportado IS NULL OR Exportado = 0                     ");

            return querySelect.ToString();
        }

        private string queryUpdateResposta()
        {
            StringBuilder queryUpdate = new StringBuilder();

            queryUpdate.Append(@" UPDATE  MobileTResposta                       ");
            queryUpdate.Append(@"    SET  Exportado = 1                         ");
            queryUpdate.Append(@"  WHERE  Exportado IS NULL OR Exportado = 0    ");

            return queryUpdate.ToString();
        }

        private string queryInsertTB_RESPOSTA(DataRow resposta)
        {
            StringBuilder queryInsert = new StringBuilder();

            queryInsert.Append(@" INSERT INTO TB_RESPOSTA                           ");
            queryInsert.Append(@" 	     ( cd_eva                                   ");
            queryInsert.Append(@" 	     , cd_pgt                                   ");
            queryInsert.Append(@" 	     , cd_opc                                   ");
            queryInsert.Append(@" 	     , nr_seqrta                                ");
            queryInsert.Append(@" 	     , ds_rta                                   ");
            queryInsert.Append(@" 	     , ds_cmpopc  )                             ");
            queryInsert.Append(@" VALUES ( " + resposta["CodigoEntrevista"] + "     ");
            queryInsert.Append(@" 	     , " + resposta["CodigoPergunta"] + "       ");
            queryInsert.Append(@" 	     , " + resposta["CodigoOpcao"] + "          ");
            queryInsert.Append(@" 	     , " + resposta["CodigoSeqResposta"] + "    ");
            queryInsert.Append(@" 	     , '" + resposta["TextoResposta"] + "'      ");
            queryInsert.Append(@" 	     , '" + resposta["TextoSubResposta"] + "' ) ");

            return queryInsert.ToString();
        }

        private string queryDeleteTB_RESPOSTA(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM TB_RESPOSTA                           ");
            queryDelete.Append(@"  WHERE cd_eva = " + codigoEntrevista + "          ");

            return queryDelete.ToString();
        }

        private string queryDeleteMobileTResposta(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTResposta                           ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela MobileTSimuladorProduto ]

        private string queryDeleteMobileTSimuladorProduto(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTSimuladorProduto                   ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela MobileTSimuladorSubAgregado ]

        private string queryDeleteMobileTSimuladorSubAgregado(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTSimuladorSubAgregado               ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela MobileTSimuladorSubFuneral ]

        private string queryDeleteMobileTSimuladorSubFuneral(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTSimuladorSubFuneral                ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela MobileTSimuladorSubRenda ]

        private string queryDeleteMobileTSimuladorSubRenda(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM MobileTSimuladorSubRenda                  ");
            queryDelete.Append(@"  WHERE CodigoEntrevista in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela TFaixa ]

        public bool ImportarFaixas()
        {

            try
            {
                #region [ Import Faixa ]

                using (SqlConnection connSINAF = new SqlConnection(ConnectionStringSINAF))
                {

                    connSINAF.Open();

                    SqlCommand cmdLerViewFaixa = new SqlCommand(queryViewFaixa(), connSINAF);
                    SqlDataReader reader = cmdLerViewFaixa.ExecuteReader();
                    DataTable dadosFaixa = new DataTable("TFaixa");
                    dadosFaixa.Load(reader);

                    foreach (DataRow itemFaixa in dadosFaixa.Rows)
                    {

                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmdLerSelectFaixa = new SqlCommand(querySelectFaixa(Convert.ToInt64(itemFaixa["CodigoFaixa"])), conn);
                            SqlDataReader readerFaixaAtual = cmdLerSelectFaixa.ExecuteReader();
                            DataTable dadosFaixaAtual = new DataTable("TFaixa");

                            dadosFaixaAtual.Load(readerFaixaAtual);

                            if (dadosFaixaAtual.Rows.Count >= 1)
                            {
                                //Código de controle do relatório

                            }
                            else if (dadosFaixaAtual.Rows.Count == 0)
                            {
                                SqlCommand cmdInsertFaixa = new SqlCommand(queryInsertFaixa(Convert.ToInt64(itemFaixa["CodigoFaixa"])), conn);
                                cmdInsertFaixa.ExecuteNonQuery();
                            }
                        }
                    }

                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string queryViewFaixa()
        {
            StringBuilder queryViewFaixa = new StringBuilder();

            queryViewFaixa.Append(@" SELECT  cd_eva AS CodigoFaixa      ");
            queryViewFaixa.Append(@"   FROM  VW_FAIXA_ENTREVISTA_MOBILE ");

            return queryViewFaixa.ToString();
        }

        private string querySelectFaixa(Int64 CodigoFaixa)
        {
            StringBuilder querySelectFaixa = new StringBuilder();

            querySelectFaixa.Append(@" SELECT    IDFaixa                                     ");
            querySelectFaixa.Append(@" 	       , CodigoFaixa                                 ");
            querySelectFaixa.Append(@" 	       , Usado                                       ");
            querySelectFaixa.Append(@"         , IDResponsavel                               ");
            querySelectFaixa.Append(@"         , IDHistoricoTSincronismoDownload             ");
            querySelectFaixa.Append(@"         , IDHistoricoTSincronismoUpload               ");
            querySelectFaixa.Append(@"         , DataDownloadBase                            ");
            querySelectFaixa.Append(@"         , DataUtilizado                               ");
            querySelectFaixa.Append(@"   FROM  TFaixa                                        ");
            querySelectFaixa.Append(@"  WHERE  CodigoFaixa = " + CodigoFaixa.ToString() + "  ");

            return querySelectFaixa.ToString();
        }

        private string queryInsertFaixa(Int64 CodigoFaixa)
        {
            StringBuilder queryInsertFaixa = new StringBuilder();

            queryInsertFaixa.Append(@" INSERT INTO TFaixa                                                     ");
            queryInsertFaixa.Append(@" (                                                                      ");
            queryInsertFaixa.Append(@"   TFaixa.CodigoFaixa                                                   ");
            queryInsertFaixa.Append(@" , TFaixa.Usado                                                         ");
            queryInsertFaixa.Append(@" , TFaixa.DataDownloadBase                                              ");
            queryInsertFaixa.Append(@" )                                                                      ");
            queryInsertFaixa.Append(@" VALUES                                                                 ");
            queryInsertFaixa.Append(@" (                                                                      ");
            queryInsertFaixa.Append(@"   " + CodigoFaixa + "                                                  ");
            queryInsertFaixa.Append(@" , 0                                                                    ");
            queryInsertFaixa.Append(@" , GetDate()                                                            ");
            queryInsertFaixa.Append(@" );                                                                     ");

            return queryInsertFaixa.ToString();
        }

        private string queryDeleteFaixa(string codigoEntrevista)
        {
            StringBuilder queryDelete = new StringBuilder();

            queryDelete.Append(@" DELETE FROM TFaixa                               ");
            queryDelete.Append(@"  WHERE CodigoFaixa in (" + codigoEntrevista + ") ");

            return queryDelete.ToString();
        }

        #endregion

        #region [ Tabela TOrigemVenda ]

        public bool ImportarOrigemVenda()
        {

            try
            {
                #region [ Drop Table ]

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmdDropTables = new SqlCommand(queryDropTableOrigemVenda(), conn);
                    cmdDropTables.ExecuteNonQuery();
                }

                #endregion

                #region [ Create Table and Import VIEW ORIGEM VENDAS ]

                using (SqlConnection connSINAF = new SqlConnection(ConnectionStringSINAF))
                {

                    connSINAF.Open();

                    SqlCommand cmdLerViewOrigemVenda = new SqlCommand(queryViewOrigemVenda(), connSINAF);
                    SqlDataReader reader = cmdLerViewOrigemVenda.ExecuteReader();

                    using (SqlConnection destinationConnection = new SqlConnection(ConnectionString))
                    {
                        destinationConnection.Open();

                        //SqlCommand cmdCriarTabelaOrigemVenda = new SqlCommand(queryCreateTableOrigemVenda(), destinationConnection);

                        //cmdCriarTabelaOrigemVenda.ExecuteNonQuery();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                        {
                            bulkCopy.DestinationTableName = "TOrigemVenda";
                            bulkCopy.ColumnMappings.Clear();
                            bulkCopy.ColumnMappings.Add("CodigoOrigemVenda", "CodigoOrigemVenda");
                            bulkCopy.ColumnMappings.Add("NomeOrigemVenda", "NomeOrigemVenda");

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string queryDropTableOrigemVenda()
        {
            StringBuilder queryDrop = new StringBuilder();

            //queryDrop.Append(@" IF OBJECT_ID('dbo.TOrigemVenda', 'U') IS NOT NULL ");
            //queryDrop.Append(@"     DROP TABLE TOrigemVenda                       ");

            queryDrop.Append(@" DELETE FROM TOrigemVenda    ");

            return queryDrop.ToString();
        }

        private string queryCreateTableOrigemVenda()
        {
            StringBuilder queryCreate = new StringBuilder();

            #region [ TOrigemVenda ]

            queryCreate.Append(@" CREATE TABLE [TOrigemVenda]                   ");
            queryCreate.Append(@" ( [IDOrigemVenda]  int PRIMARY KEY IDENTITY   ");
            queryCreate.Append(@" , [CodigoOrigemVenda]  varchar(3) NOT NULL    ");
            queryCreate.Append(@" , [NomeOrigemVenda]  varchar(50) NOT NULL     ");
            queryCreate.Append(@" );                                            ");

            #endregion

            return queryCreate.ToString();
        }

        private string queryViewOrigemVenda()
        {
            StringBuilder queryViewOrigemVenda = new StringBuilder();

            queryViewOrigemVenda.Append(@" SELECT  cd_orivnd AS CodigoOrigemVenda      ");
            queryViewOrigemVenda.Append(@" 	     , ds_orivnd AS NomeOrigemVenda        ");
            queryViewOrigemVenda.Append(@"   FROM  VW_ORIGEM_VENDA                     ");

            return queryViewOrigemVenda.ToString();
        }

        private string queryViewOrigemVendaCAB()
        {
            StringBuilder queryViewOrigemVenda = new StringBuilder();

            queryViewOrigemVenda.Append(@" SELECT  CodigoOrigemVenda      ");
            queryViewOrigemVenda.Append(@" 	     , NomeOrigemVenda        ");
            queryViewOrigemVenda.Append(@"   FROM  TOrigemVenda                     ");

            return queryViewOrigemVenda.ToString();
        }

        #endregion

        #region [ Tabela TParametro ]

        private string queryLerTabelaParametro()
        {
            StringBuilder queryTabelaParametro = new StringBuilder();

            queryTabelaParametro.Append(@" SELECT  IDParametro                   ");
            queryTabelaParametro.Append(@" 	     , TempoLogOff                   ");
            queryTabelaParametro.Append(@" 	     , PrazoSincronismoDia           ");
            queryTabelaParametro.Append(@"       , EstoqueMaximoWeb              ");
            queryTabelaParametro.Append(@"       , EstoqueMinimoWeb              ");
            queryTabelaParametro.Append(@"       , EstoqueMaximoColetor          ");
            queryTabelaParametro.Append(@"       , EstoqueMinimoColetor          ");
            queryTabelaParametro.Append(@"       , TempoDadosServidorDias        ");
            queryTabelaParametro.Append(@"       , TempoVerificaERPDias          ");
            queryTabelaParametro.Append(@"   FROM  TParametro                    ");

            return queryTabelaParametro.ToString();
        }

        #endregion

        #region [ Tabela TProfissao ]

        public bool ImportarProfissao()
        {

            try
            {
                #region [ Drop Table ]

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmdDropTables = new SqlCommand(queryDropTableProfissao(), conn);
                    cmdDropTables.ExecuteNonQuery();
                }

                #endregion

                #region [ Create Table and Import VIEW PROFISSAO ]

                using (SqlConnection connSINAF = new SqlConnection(ConnectionStringSINAF))
                {

                    connSINAF.Open();

                    SqlCommand cmdLerViewProfissao = new SqlCommand(queryViewProfissao(), connSINAF);
                    SqlDataReader reader = cmdLerViewProfissao.ExecuteReader();

                    using (SqlConnection destinationConnection = new SqlConnection(ConnectionString))
                    {
                        destinationConnection.Open();

                        //SqlCommand cmdCriarTabelaProfissao = new SqlCommand(queryCreateTableProfissao(), destinationConnection);

                        //cmdCriarTabelaProfissao.ExecuteNonQuery();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TProfissao";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string queryDropTableProfissao()
        {
            StringBuilder queryDrop = new StringBuilder();

            queryDrop.Append(@" DELETE FROM TProfissao        ");

            //queryDrop.Append(@" IF OBJECT_ID('dbo.TProfissao', 'U') IS NOT NULL ");
            //queryDrop.Append(@"     DROP TABLE TProfissao                       ");

            return queryDrop.ToString();
        }

        private string queryCreateTableProfissao()
        {
            StringBuilder queryCreate = new StringBuilder();

            #region [ TProfissao ]

            queryCreate.Append(@" CREATE TABLE [TProfissao]                 ");
            queryCreate.Append(@" ( [IDProfissao] int PRIMARY KEY           ");
            queryCreate.Append(@" , [NomeProfissao] nvarchar(100) NOT NULL  ");
            queryCreate.Append(@" , [CapitalLimitado] bit NOT NULL          ");
            queryCreate.Append(@" );                                        ");

            #endregion

            return queryCreate.ToString();
        }

        private string queryViewProfissao()
        {
            StringBuilder queryViewProfissao = new StringBuilder();

            queryViewProfissao.Append(@" SELECT  Codigo  AS IDProfissao              ");
            queryViewProfissao.Append(@" 	     , nm_atdcli AS NomeProfissao        ");
            queryViewProfissao.Append(@" 	     , fl_caplim AS CapitalLimitado      ");
            queryViewProfissao.Append(@"   FROM  VW_PROFISSAO_ENTREVISTA             ");

            return queryViewProfissao.ToString();
        }

        private string queryViewProfissaoCAB()
        {
            StringBuilder queryViewProfissao = new StringBuilder();

            queryViewProfissao.Append(@" SELECT   IDProfissao              ");
            queryViewProfissao.Append(@" 	     ,  NomeProfissao        ");
            queryViewProfissao.Append(@" 	     ,  CapitalLimitado      ");
            queryViewProfissao.Append(@"   FROM  TProfissao             ");

            return queryViewProfissao.ToString();
        }

        #endregion

        #region [ Tabela TUsuario ]

        public bool ImportarUsuario()
        {
            try
            {
                #region [ Import Usuario ]

                using (SqlConnection connSINAF = new SqlConnection(ConnectionStringSINAF))
                {

                    connSINAF.Open();

                    SqlCommand cmdLerViewUsuario = new SqlCommand(queryViewUsuario(), connSINAF);
                    SqlDataReader reader = cmdLerViewUsuario.ExecuteReader();
                    DataTable dadosUsuario = new DataTable("TUsuario");
                    dadosUsuario.Load(reader);

                    foreach (DataRow itemUsuario in dadosUsuario.Rows)
                    {

                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmdLerSelectUsuario = new SqlCommand(querySelectUsuario(Convert.ToInt32(itemUsuario["CodigoColaborador"])), conn);
                            SqlDataReader readerUsuarioAtual = cmdLerSelectUsuario.ExecuteReader();
                            DataTable dadosUsuarioAtual = new DataTable("TUsuario");
                            string SenhaNova = Criptografia.EncryptSymmetric("DESCryptoServiceProvider", itemUsuario["Senha"].ToString());
                            dadosUsuarioAtual.Load(readerUsuarioAtual);

                            if (dadosUsuarioAtual.Rows.Count >= 1)
                            {
                                SqlCommand cmdUpdateUsuario = new SqlCommand(queryUpdateUsuario(itemUsuario, SenhaNova), conn);
                                cmdUpdateUsuario.ExecuteNonQuery();

                                for (int repetido = 1; repetido < dadosUsuarioAtual.Rows.Count; repetido++)
                                {
                                    SqlCommand cmdDeleteUsuario = new SqlCommand(queryDeleteUsuario(Convert.ToInt32(dadosUsuarioAtual.Rows[repetido]["IDUsuario"])), conn);
                                    cmdDeleteUsuario.ExecuteNonQuery();
                                }

                            }
                            else if (dadosUsuarioAtual.Rows.Count == 0)
                            {
                                SqlCommand cmdInsertUsuario = new SqlCommand(queryInsertUsuario(itemUsuario, SenhaNova), conn);
                                cmdInsertUsuario.ExecuteNonQuery();
                            }
                        }
                    }

                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmdDeleteUsuarioBase = new SqlCommand(queryDeleteUsuarioBase(), conn);
                        cmdDeleteUsuarioBase.ExecuteNonQuery();
                    }
                }

                #endregion

                #region [ Update Cargo/Perfil ]

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {

                    conn.Open();

                    SqlCommand cmdLerViewUsuario = new SqlCommand(querySelectCargo(), conn);
                    SqlDataReader reader = cmdLerViewUsuario.ExecuteReader();
                    DataTable dadosUsuario = new DataTable("TUsuario");
                    dadosUsuario.Load(reader);

                    foreach (DataRow itemUsuario in dadosUsuario.Rows)
                    {
                        SqlCommand cmdLerViewPerfil = new SqlCommand(querySelectPerfil(itemUsuario["Cargo"].ToString()), conn);
                        SqlDataReader readerPerfil = cmdLerViewPerfil.ExecuteReader();
                        DataTable dadosPerfil = new DataTable("TPerfilCargo");
                        dadosPerfil.Load(readerPerfil);

                        if (dadosPerfil.Rows.Count > 0)
                        {
                            SqlCommand cmdUpdateUsuario = new SqlCommand(queryUpdatePerfil(Convert.ToInt32(dadosPerfil.Rows[0]["IDPerfil"].ToString()), itemUsuario["Cargo"].ToString()), conn);
                            cmdUpdateUsuario.ExecuteNonQuery();
                        }
                    }
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string queryViewUsuario()
        {
            StringBuilder queryViewUsuario = new StringBuilder();

            queryViewUsuario.Append(@" SELECT  nm_clb AS Nome                           ");
            queryViewUsuario.Append(@" 	     , nm_lgnusu AS Login                       ");
            queryViewUsuario.Append(@" 	     , nm_gue AS Abreviado                      ");
            queryViewUsuario.Append(@" 	     , 'SINAF' AS Senha                         ");
            queryViewUsuario.Append(@"       , 1 AS IDPerfil                            ");
            queryViewUsuario.Append(@"       , eml_clb  AS Email                        ");
            queryViewUsuario.Append(@"       , cd_clbcha  AS CodigoColaborador          ");
            queryViewUsuario.Append(@"       , ds_und  AS Unidade                       ");
            queryViewUsuario.Append(@"       , ds_cgoger  AS Cargo                      ");
            queryViewUsuario.Append(@"       , 1  AS Ativo                              ");
            queryViewUsuario.Append(@"   FROM  VW_USUARIO_MOBILE_ENTREVISTA             ");

            return queryViewUsuario.ToString();
        }

        private string querySelectUsuario(int CodigoColaborador)
        {
            StringBuilder querySelectUsuario = new StringBuilder();

            querySelectUsuario.Append(@" SELECT    IDUsuario                                           ");
            querySelectUsuario.Append(@"         , Nome                                                ");
            querySelectUsuario.Append(@"         , Abreviado                                           ");
            querySelectUsuario.Append(@" 	     , Login                                               ");
            querySelectUsuario.Append(@" 	     , Senha                                               ");
            querySelectUsuario.Append(@"         , IDPerfil                                            ");
            querySelectUsuario.Append(@"         , Email                                               ");
            querySelectUsuario.Append(@"         , CodigoColaborador                                   ");
            querySelectUsuario.Append(@"         , Unidade                                             ");
            querySelectUsuario.Append(@"         , Cargo                                               ");
            querySelectUsuario.Append(@"         , Ativo                                               ");
            querySelectUsuario.Append(@"   FROM  TUsuario                                              ");
            querySelectUsuario.Append(@"  WHERE  CodigoColaborador = " + CodigoColaborador.ToString() + "  ");

            return querySelectUsuario.ToString();
        }

        private string queryInsertUsuario(DataRow dadosUsuario, string Senha)
        {
            StringBuilder queryInsertUsuario = new StringBuilder();

            queryInsertUsuario.Append(@" INSERT INTO TUsuario                                                   ");
            queryInsertUsuario.Append(@" (                                                                      ");
            queryInsertUsuario.Append(@"   TUsuario.Nome                                                        ");
            queryInsertUsuario.Append(@" , TUsuario.Abreviado                                                   ");
            queryInsertUsuario.Append(@" , TUsuario.Login                                                       ");
            queryInsertUsuario.Append(@" , TUsuario.Senha                                                       ");
            queryInsertUsuario.Append(@" , TUsuario.IDPerfil                                                    ");
            queryInsertUsuario.Append(@" , TUsuario.Email                                                       ");
            queryInsertUsuario.Append(@" , TUsuario.CodigoColaborador                                           ");
            queryInsertUsuario.Append(@" , TUsuario.Unidade                                                     ");
            queryInsertUsuario.Append(@" , TUsuario.Cargo                                                       ");
            queryInsertUsuario.Append(@" , TUsuario.Ativo                                                       ");
            queryInsertUsuario.Append(@" )                                                                      ");
            queryInsertUsuario.Append(@" VALUES                                                                 ");
            queryInsertUsuario.Append(@" (                                                                      ");
            queryInsertUsuario.Append(@"   '" + dadosUsuario["Nome"].ToString() + "'                            ");
            queryInsertUsuario.Append(@" , '" + dadosUsuario["Abreviado"].ToString() + "'                       ");
            queryInsertUsuario.Append(@" , '" + dadosUsuario["Login"].ToString().Trim() + "'                    ");
            queryInsertUsuario.Append(@" , '" + Senha + "'                                                      ");
            queryInsertUsuario.Append(@" , 1                                                                    ");
            queryInsertUsuario.Append(@" , '" + dadosUsuario["Email"].ToString() + "'                           ");
            queryInsertUsuario.Append(@" , " + dadosUsuario["CodigoColaborador"].ToString() + "                 ");
            queryInsertUsuario.Append(@" , '" + dadosUsuario["Unidade"].ToString() + "'                         ");
            queryInsertUsuario.Append(@" , '" + dadosUsuario["Cargo"].ToString() + "'                           ");
            queryInsertUsuario.Append(@" , 1                                                                    ");
            queryInsertUsuario.Append(@" );                                                                     ");

            return queryInsertUsuario.ToString();
        }

        private string queryUpdateUsuario(DataRow dadosUsuario, string Senha)
        {
            StringBuilder queryUpdateUsuario = new StringBuilder();

            queryUpdateUsuario.Append(@" UPDATE TUsuario                                                                    ");
            queryUpdateUsuario.Append(@"    SET Nome = '" + dadosUsuario["Nome"].ToString() + "'                            ");
            queryUpdateUsuario.Append(@"      , Abreviado = '" + dadosUsuario["Abreviado"].ToString() + "'                  ");
            queryUpdateUsuario.Append(@"      , Login = '" + dadosUsuario["Login"].ToString().Trim() + "'                   ");
            queryUpdateUsuario.Append(@"      , Senha = '" + Senha + "'                                                     ");
            queryUpdateUsuario.Append(@"      , IDPerfil = " + dadosUsuario["IDPerfil"].ToString() + "                      ");
            queryUpdateUsuario.Append(@"      , Email = '" + dadosUsuario["Email"].ToString() + "'                          ");
            queryUpdateUsuario.Append(@"      , CodigoColaborador = " + dadosUsuario["CodigoColaborador"].ToString() + "    ");
            queryUpdateUsuario.Append(@"      , Unidade = '" + dadosUsuario["Unidade"].ToString() + "'                      ");
            queryUpdateUsuario.Append(@"      , Cargo = '" + dadosUsuario["Cargo"].ToString() + "'                          ");
            queryUpdateUsuario.Append(@"      , Ativo = 1                                                                   ");
            queryUpdateUsuario.Append(@"   FROM TUsuario                                                                    ");
            queryUpdateUsuario.Append(@"  WHERE CodigoColaborador = " + dadosUsuario["CodigoColaborador"].ToString() + "    ");

            return queryUpdateUsuario.ToString();
        }

        private string queryDeleteUsuario(int idUsuario)
        {
            StringBuilder queryDeleteUsuario = new StringBuilder();

            queryDeleteUsuario.Append(@" DELETE  FROM TUsuario                  ");
            queryDeleteUsuario.Append(@"  WHERE  IDUsuario = " + idUsuario + "  ");

            return queryDeleteUsuario.ToString();
        }

        private string queryDeleteUsuarioBase()
        {
            StringBuilder queryDadosUsuario = new StringBuilder();

            string db_entrevista = WebConfigurationManager.AppSettings["BancoEntrevista"];

            queryDadosUsuario.Append(@" UPDATE db_interf_cabtec.dbo.TUsuario  SET Ativo = 0                                                                  ");
            queryDadosUsuario.Append(@"  WHERE db_interf_cabtec.dbo.TUsuario.CodigoColaborador NOT IN (                                                      ");
            queryDadosUsuario.Append(@" 									        SELECT cd_clbcha                                                         ");
            queryDadosUsuario.Append(@" 									          FROM " + db_entrevista + ".dbo.VW_USUARIO_MOBILE_ENTREVISTA            ");
            queryDadosUsuario.Append(@" 							            )                                                                            ");

            //Para realizar teste não apagar usuarios teste
            queryDadosUsuario.Append(@" AND db_interf_cabtec.dbo.TUsuario.IDUsuario > 5 ;                                                            ");

            return queryDadosUsuario.ToString();
        }

        private string querySelectCargo()
        {
            StringBuilder querySelectUsuario = new StringBuilder();

            querySelectUsuario.Append(@" SELECT DISTINCT Cargo        ");
            querySelectUsuario.Append(@"   FROM  TUsuario             ");

            return querySelectUsuario.ToString();
        }

        private string querySelectPerfil(string Cargo)
        {
            StringBuilder querySelectPerfil = new StringBuilder();

            querySelectPerfil.Append(@" SELECT  IDPerfilCargo         ");
            querySelectPerfil.Append(@" 	   , IDPerfil             ");
            querySelectPerfil.Append(@" 	   , Cargo                ");
            querySelectPerfil.Append(@"   FROM  TPerfilCargo          ");
            querySelectPerfil.Append(@"  WHERE Cargo = '" + Cargo + "'    ");

            return querySelectPerfil.ToString();
        }

        private string queryUpdatePerfil(int IDPerfil, string Cargo)
        {
            StringBuilder queryUpdatePerfil = new StringBuilder();

            queryUpdatePerfil.Append(@" UPDATE TUsuario                ");
            queryUpdatePerfil.Append(@"    SET IDPerfil = " + IDPerfil + " ");
            queryUpdatePerfil.Append(@"  WHERE Cargo = '" + Cargo + "' ");

            return queryUpdatePerfil.ToString();
        }

        #endregion             
                
    }
}
