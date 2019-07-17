using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using ProjetoMobile.Dominio;
using System.Data;
using System.IO;

namespace ProjetoMobile.Persistencia
{
    public class TEstadoPERSISTENCIA
    {
        #region [ CONNECTION ]

        private static string connectionString;

        public static string ConnectionString
        {
            get
            {
                if (connectionString == null)
                    connectionString = @"Data Source = '" + Program.ARQUIVO_CORREIO + "';";
                return connectionString;
            }
        }

        #endregion

        #region [ METHODS ]

        #region [ ListaDeEstado ]

        public DataTable ListaDeEstado()
        {
            FileInfo bancoCorreio = new FileInfo(Program.ARQUIVO_CORREIO);
            if (bancoCorreio.Exists)
            {
                StringBuilder queryTabelaEstado = new StringBuilder();

                queryTabelaEstado.Append(@" SELECT   IDEstado               ");
                queryTabelaEstado.Append(@"        , Sigla                  ");
                queryTabelaEstado.Append(@"   FROM   TEstado                ");

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaEstado.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);

                    DataRow rowEmpyt = dadosTable.NewRow();
                    rowEmpyt["IDEstado"] = 0;
                    rowEmpyt["Sigla"] = string.Empty;

                    dadosTable.Rows.InsertAt(rowEmpyt, 0);

                    if (dadosTable.Rows.Count == 1)
                    {
                        DataRow rowRJ = dadosTable.NewRow();
                        rowRJ["IDEstado"] = 1;
                        rowRJ["Sigla"] = "RJ";
                        dadosTable.Rows.Add(rowRJ);
                    }

                    return dadosTable;
                }
            }
            else
            {
                DataTable dadosTable = new DataTable("TEstado");
                DataColumn columnID = new DataColumn("IDEstado");
                DataColumn columnSigla = new DataColumn("Sigla");
                dadosTable.Columns.Add(columnID);
                dadosTable.Columns.Add(columnSigla);

                DataRow rowEmpyt = dadosTable.NewRow();
                rowEmpyt["IDEstado"] = 0;
                rowEmpyt["Sigla"] = string.Empty;
                dadosTable.Rows.Add(rowEmpyt);

                DataRow rowRJ = dadosTable.NewRow();
                rowRJ["IDEstado"] = 1;
                rowRJ["Sigla"] = "RJ";
                dadosTable.Rows.Add(rowRJ);

                return dadosTable;
            }
        }

        #endregion

        #endregion
    }
}
