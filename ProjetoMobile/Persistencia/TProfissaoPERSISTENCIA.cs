using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using ProjetoMobile.Dominio; 
using System.Data;

namespace ProjetoMobile.Persistencia
{
    public class TProfissaoPERSISTENCIA
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

        #region [ ListaDeProfissao ]

        public DataTable ListaDeProfissao()
        {
            StringBuilder queryTabelaProfissao = new StringBuilder();

            queryTabelaProfissao.Append(@" SELECT   IDProfissao               ");
            queryTabelaProfissao.Append(@"        , NomeProfissao             ");
            queryTabelaProfissao.Append(@"   FROM   TProfissao                ");
            
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaProfissao.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable();
                dadosTable.Load(dados);

                DataRow rowEmpyt = dadosTable.NewRow();
                rowEmpyt["IDProfissao"] = 0;
                rowEmpyt["NomeProfissao"] = string.Empty;

                dadosTable.Rows.InsertAt(rowEmpyt, 0);

                return dadosTable;
            }
        }

        #endregion

        #endregion
    }
}
