using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Xml;
using System.IO;

namespace ProjetoMobile.Persistencia.Common
{
    public class CreateDataBase
    {
        public static bool CriarBancoDados()
        {
            try
            {
                string connString = "Data Source = '" + Program.ARQUIVO_DADOS + "'; LCID=1033;";
                SqlCeEngine engine = new SqlCeEngine(connString);
                engine.CreateDatabase();
                engine.Dispose();

                return CriarTabelas();
            }
            catch
            {
                return false;
            }
        }

        private static bool CriarTabelas()
        {
            bool retorno = true;
            try
            {

                SqlCeConnection myConn = new SqlCeConnection(DataBaseLocator.ConnectionString);

                myConn.Open();

                try
                {
                    foreach (string command in TabelasSINAF())
                    {
                        SqlCeCommand myCommand = new SqlCeCommand(command, myConn);

                        try
                        {
                            myCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Util.LogErro.GravaLog(ex.Message, "CreateDatabase::CriarTabelas()");
                            retorno = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Util.LogErro.GravaLog(ex.Message, "CreateDatabase::CriarTabelas()");
                    retorno = false;
                }

                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog(ex.Message, "CreateDatabase::CriarTabelas()");
                retorno = false;
            }
            return retorno;
        }

        private static string[] TabelasSINAF()
        {
            string[] strTabelas = new string[50];

            #region [ TUsuario 1-2]

            strTabelas[0] = "CREATE TABLE [TUsuario] ( " +
                        "  [IDUsuario] bigint NOT NULL " +
                        ", [Nome] nvarchar(100) NOT NULL " +
                        ", [Login] nvarchar(100) NOT NULL " +
                        ", [Senha] nvarchar(100) NOT NULL " +
                        ", [IDPerfil] int NOT NULL " +
                        ", [Email] nvarchar(100) NULL " +
                        "); ";

            strTabelas[1] = "ALTER TABLE [TUsuario] ADD CONSTRAINT [TUsuario_PK] PRIMARY KEY ([IDUsuario]); ";

            //strTabelas[2] = "CREATE UNIQUE INDEX [UQ_TAA] ON [TAA] ([ID_TAA] ASC); ";

            #endregion

            #region [ TEstado 3-4]

            strTabelas[3] = "CREATE TABLE [TEstado] ( " +
                        "  [IDEstado] int NOT NULL " +
                        ", [Sigla] nvarchar(2) NOT NULL " +
                        "); ";

            strTabelas[4] = "ALTER TABLE [TEstado] ADD CONSTRAINT [TEstado_PK] PRIMARY KEY ([IDEstado]); ";

            #endregion

            #region [ TCidade 5-7]

            strTabelas[5] = "CREATE TABLE [TCidade] ( " +
                        "  [IDCidade] int NOT NULL " +
                        ", [NomeCidade] nvarchar(100) NOT NULL " +
                        ", [IDEstado] int NOT NULL " +
                        "); ";

            strTabelas[6] = "ALTER TABLE [TCidade] ADD CONSTRAINT [TCidade_PK] PRIMARY KEY ([IDCidade]); ";
            strTabelas[7] = "ALTER TABLE [TCidade] ADD CONSTRAINT [TEstado_FK] FOREIGN KEY ([IDEstado]) REFERENCES [TEstado]([IDEstado]); ";

            #endregion

            #region [ TBairro 8-10]

            strTabelas[8] = "CREATE TABLE [TBairro] ( " +
                        "  [IDBairro] int NOT NULL " +
                        ", [NomeBairro] nvarchar(100) NOT NULL " +
                        ", [IDCidade] int NOT NULL " +
                        "); ";

            strTabelas[9] = "ALTER TABLE [TBairro] ADD CONSTRAINT [TBairro_PK] PRIMARY KEY ([IDBairro]); ";
            strTabelas[10] = "ALTER TABLE [TBairro] ADD CONSTRAINT [TCidade_FK] FOREIGN KEY ([IDCidade]) REFERENCES [TCidade]([IDCidade]); ";

            #endregion

            #region [ TLogradouro 11-14]

            strTabelas[11] = "CREATE TABLE [TLogradouro] ( " +
                        "  [IDLogradouro] int NOT NULL " +
                        ", [NomeLogradouro] nvarchar(100) NOT NULL " +
                        ", [IDBairro] int NULL " +
                        ", [CEP] int NOT NULL " +
                        ", [IDCidade] int NULL " +
                        "); ";

            strTabelas[12] = "ALTER TABLE [TLogradouro] ADD CONSTRAINT [TLogradouro_PK] PRIMARY KEY ([IDLogradouro]); ";
            strTabelas[13] = "ALTER TABLE [TLogradouro] ADD CONSTRAINT [TBairro_FK] FOREIGN KEY ([IDBairro]) REFERENCES [TBairro]([IDBairro]); ";
            strTabelas[14] = "ALTER TABLE [TLogradouro] ADD CONSTRAINT [TCidade_FK] FOREIGN KEY ([IDCidade]) REFERENCES [TCidade]([IDCidade]); ";

            #endregion

            return strTabelas;
        }
    }
}
