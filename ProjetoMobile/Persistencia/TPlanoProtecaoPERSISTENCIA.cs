using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using ProjetoMobile.Dominio;
using ProjetoMobile.Dominio.Enumeradores;
using System.Data;
using System.Globalization;

namespace ProjetoMobile.Persistencia
{
    public class TPlanoProtecaoPERSISTENCIA
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

        #region [ ConsultaCategoriaSuperior ]

        public TPlanoProtecaoDOMINIO ConsultaCategoriaSuperior(int faixaPadaro, decimal valorPremioAPD)
        {
            try
            {
                StringBuilder queryTabelaPlanoProtecao = new StringBuilder();
                StringBuilder queryTabelaPlanoProtecaoMaior = new StringBuilder();
                StringBuilder queryTabelaPlanoProtecaoMenor = new StringBuilder();

                queryTabelaPlanoProtecao.Append(@" SELECT   IDPlanoProtecao       ");
                queryTabelaPlanoProtecao.Append(@"        , Codigo                ");
                queryTabelaPlanoProtecao.Append(@"        , CoberturaMorte        ");
                queryTabelaPlanoProtecao.Append(@"        , CoberturaAcidente     ");
                queryTabelaPlanoProtecao.Append(@"        , CoberturaEmergencia   ");
                queryTabelaPlanoProtecao.Append(@"        , Premio_18_30          ");
                queryTabelaPlanoProtecao.Append(@"        , Premio_31_40          ");
                queryTabelaPlanoProtecao.Append(@"        , Premio_41_45          ");
                queryTabelaPlanoProtecao.Append(@"        , Premio_46_50          ");
                queryTabelaPlanoProtecao.Append(@"        , Premio_51_55          ");
                queryTabelaPlanoProtecao.Append(@"        , Premio_56_60          ");
                queryTabelaPlanoProtecao.Append(@"        , Premio_61_65          ");
                queryTabelaPlanoProtecao.Append(@"        , NomePlano             ");

                string valorPremioAP = Decimal.Round(valorPremioAPD, 2).ToString().Replace(',', '.');
                switch (faixaPadaro)
                {
                    case (int)FaixaEtaria.PREMIO_18_30:
                        queryTabelaPlanoProtecao.Append(@"   , Premio_18_30 AS ValorPadrao  ");
                        queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao          ");
                        queryTabelaPlanoProtecao.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoProtecaoMenor.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMaior.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMenor.Append(@"        AND  Premio_18_30  <= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMenor.Append(@"   ORDER BY  Premio_18_30 DESC                      ");
                        queryTabelaPlanoProtecaoMaior.Append(@"        AND  Premio_18_30  >= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMaior.Append(@"   ORDER BY  Premio_18_30                           ");
                        break;
                    case (int)FaixaEtaria.PREMIO_31_40:
                        queryTabelaPlanoProtecao.Append(@"   , Premio_31_40 AS ValorPadrao  ");
                        queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao          ");
                        queryTabelaPlanoProtecao.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoProtecaoMenor.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMaior.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMenor.Append(@"        AND  Premio_31_40  <= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMenor.Append(@"   ORDER BY  Premio_31_40 DESC                      ");
                        queryTabelaPlanoProtecaoMaior.Append(@"        AND  Premio_31_40  >= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMaior.Append(@"   ORDER BY  Premio_31_40                           ");
                        break;
                    case (int)FaixaEtaria.PREMIO_41_45:
                        queryTabelaPlanoProtecao.Append(@"   , Premio_41_45 AS ValorPadrao  ");
                        queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao          ");
                        queryTabelaPlanoProtecao.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoProtecaoMenor.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMaior.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMenor.Append(@"        AND  Premio_41_45  <= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMenor.Append(@"   ORDER BY  Premio_41_45 DESC                      ");
                        queryTabelaPlanoProtecaoMaior.Append(@"        AND  Premio_41_45  >= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMaior.Append(@"   ORDER BY  Premio_41_45                           ");
                        break;
                    case (int)FaixaEtaria.PREMIO_46_50:
                        queryTabelaPlanoProtecao.Append(@"   , Premio_46_50 AS ValorPadrao  ");
                        queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao          ");
                        queryTabelaPlanoProtecao.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoProtecaoMenor.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMaior.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMenor.Append(@"        AND  Premio_46_50  <= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMenor.Append(@"   ORDER BY  Premio_46_50 DESC                      ");
                        queryTabelaPlanoProtecaoMaior.Append(@"        AND  Premio_46_50  >= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMaior.Append(@"   ORDER BY  Premio_46_50                           ");
                        break;
                    case (int)FaixaEtaria.PREMIO_51_55:
                        queryTabelaPlanoProtecao.Append(@"   , Premio_51_55 AS ValorPadrao  ");
                        queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao          ");
                        queryTabelaPlanoProtecao.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoProtecaoMenor.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMaior.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMenor.Append(@"        AND  Premio_51_55  <= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMenor.Append(@"   ORDER BY  Premio_51_55 DESC                      ");
                        queryTabelaPlanoProtecaoMaior.Append(@"        AND  Premio_51_55  >= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMaior.Append(@"   ORDER BY  Premio_51_55                           ");
                        break;
                    case (int)FaixaEtaria.PREMIO_56_60:
                        queryTabelaPlanoProtecao.Append(@"   , Premio_56_60 AS ValorPadrao  ");
                        queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao          ");
                        queryTabelaPlanoProtecao.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoProtecaoMenor.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMaior.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMenor.Append(@"        AND  Premio_56_60  <= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMenor.Append(@"   ORDER BY  Premio_56_60 DESC                      ");
                        queryTabelaPlanoProtecaoMaior.Append(@"        AND  Premio_56_60  >= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMaior.Append(@"   ORDER BY  Premio_56_60                           ");
                        break;
                    case (int)FaixaEtaria.PREMIO_61_65:
                        queryTabelaPlanoProtecao.Append(@"   , Premio_61_65 AS ValorPadrao  ");
                        queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao          ");
                        queryTabelaPlanoProtecao.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoProtecaoMenor.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMaior.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMenor.Append(@"        AND  Premio_61_65  <= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMenor.Append(@"   ORDER BY  Premio_61_65 DESC                      ");
                        queryTabelaPlanoProtecaoMaior.Append(@"        AND  Premio_61_65  >= " + valorPremioAP + " ");
                        queryTabelaPlanoProtecaoMaior.Append(@"   ORDER BY  Premio_61_65                           ");
                        break;
                    default:
                        queryTabelaPlanoProtecao.Append(@"   , 0 AS ValorPadrao ");
                        queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao          ");
                        queryTabelaPlanoProtecao.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoProtecaoMenor.Append(queryTabelaPlanoProtecao.ToString());
                        queryTabelaPlanoProtecaoMaior.Append(queryTabelaPlanoProtecao.ToString());
                        break;
                }

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand commandMenor = new SqlCeCommand(queryTabelaPlanoProtecaoMenor.ToString(), conn);
                    SqlCeDataReader dadosMenor = commandMenor.ExecuteReader();
                    DataTable dadosTableMenor = new DataTable();
                    dadosTableMenor.Load(dadosMenor);

                    SqlCeCommand commandMaior = new SqlCeCommand(queryTabelaPlanoProtecaoMaior.ToString(), conn);
                    SqlCeDataReader dadosMaior = commandMaior.ExecuteReader();
                    DataTable dadosTableMaior = new DataTable();
                    dadosTableMaior.Load(dadosMaior);

                    if ((dadosTableMenor.Rows.Count > 0) && (dadosTableMaior.Rows.Count > 0))
                    {
                        if (valorPremioAPD - Convert.ToDecimal(dadosTableMenor.Rows[0]["ValorPadrao"]) > Convert.ToDecimal(dadosTableMaior.Rows[0]["ValorPadrao"]) - valorPremioAPD)
                            return MontarDominioTPlanoProtecao(dadosTableMaior.Rows[0]);
                        else
                            return MontarDominioTPlanoProtecao(dadosTableMenor.Rows[0]);
                    }
                    else
                    {
                        if (dadosTableMenor.Rows.Count > 0)
                            return MontarDominioTPlanoProtecao(dadosTableMenor.Rows[0]);

                        if (dadosTableMaior.Rows.Count > 0)
                            return MontarDominioTPlanoProtecao(dadosTableMaior.Rows[0]);

                        return new TPlanoProtecaoDOMINIO();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ MontarDominioTPlanoProtecao ]

        public TPlanoProtecaoDOMINIO MontarDominioTPlanoProtecao(DataRow dadosDominio)
        {
            TPlanoProtecaoDOMINIO dadosConsulta = new TPlanoProtecaoDOMINIO();
            dadosConsulta.IDPlanoProtecao = Convert.ToInt32(dadosDominio["IDPlanoProtecao"]);
            dadosConsulta.Codigo = Convert.ToInt32(dadosDominio["Codigo"]);
            dadosConsulta.CoberturaMorte = Convert.ToDecimal(dadosDominio["CoberturaMorte"]);
            dadosConsulta.CoberturaAcidente = Convert.ToDecimal(dadosDominio["CoberturaAcidente"]);
            dadosConsulta.CoberturaEmergencia = Convert.ToDecimal(dadosDominio["CoberturaEmergencia"]);
            dadosConsulta.Premio_18_30 = dadosDominio.Field<Decimal?>("Premio_18_30");
            dadosConsulta.Premio_31_40 = dadosDominio.Field<Decimal?>("Premio_31_40");
            dadosConsulta.Premio_41_45 = dadosDominio.Field<Decimal?>("Premio_41_45");
            dadosConsulta.Premio_46_50 = dadosDominio.Field<Decimal?>("Premio_46_50");
            dadosConsulta.Premio_51_55 = dadosDominio.Field<Decimal?>("Premio_51_55");
            dadosConsulta.Premio_56_60 = dadosDominio.Field<Decimal?>("Premio_56_60");
            dadosConsulta.Premio_61_65 = dadosDominio.Field<Decimal?>("Premio_61_65");
            dadosConsulta.NomePlano = dadosDominio["NomePlano"].ToString();

            return dadosConsulta;
        }

        #endregion

        #region [ MontarDominioTPlanoProtecaoFuneral ]

        public TPlanoProtecaoDOMINIO MontarDominioTPlanoProtecaoFuneral(DataRow dadosDominio)
        {
            TPlanoProtecaoDOMINIO dadosConsulta = new TPlanoProtecaoDOMINIO();
            dadosConsulta.IDPlanoProtecaoFuneral = Convert.ToInt32(dadosDominio["IDPlanoProtecaoFuneral"]);
            dadosConsulta.FuneralCodigo = Convert.ToInt32(dadosDominio["Codigo"]);
            dadosConsulta.FuneralCategoria = dadosDominio["Categoria"].ToString();
            dadosConsulta.FuneralAte_20 = dadosDominio.Field<Decimal?>("Ate_20");
            dadosConsulta.FuneralDe_21_40 = dadosDominio.Field<Decimal?>("De_21_40");
            dadosConsulta.FuneralDe_41_50 = dadosDominio.Field<Decimal?>("De_41_50");
            dadosConsulta.FuneralDe_51_60 = dadosDominio.Field<Decimal?>("De_51_60");
            dadosConsulta.FuneralDe_61_65 = dadosDominio.Field<Decimal?>("De_61_65");
            dadosConsulta.FuneralDe_66_70 = dadosDominio.Field<Decimal?>("De_66_70");
            dadosConsulta.FuneralDe_71_75 = dadosDominio.Field<Decimal?>("De_71_75");
            dadosConsulta.FuneralDe_76_80 = dadosDominio.Field<Decimal?>("De_76_80");

            return dadosConsulta;
        }

        #endregion

        #region [ MontarDominioTPlanoProtecaoRenda ]

        public TPlanoProtecaoDOMINIO MontarDominioTPlanoProtecaoRenda(DataRow dadosDominio)
        {
            TPlanoProtecaoDOMINIO dadosConsulta = new TPlanoProtecaoDOMINIO();
            dadosConsulta.IDPlanoProtecaoRenda = Convert.ToInt32(dadosDominio["IDPlanoProtecaoRenda"]);
            dadosConsulta.RendaPeriodo = dadosDominio["RendaPeriodo"].ToString();
            dadosConsulta.RendaCoberturaRendaMensal = Convert.ToDecimal(dadosDominio["CoberturaRendaMensal"]);
            dadosConsulta.RendaCoberturaCapitalTotal = Convert.ToDecimal(dadosDominio["CoberturaCapitalTotal"]);
            dadosConsulta.RendaPremio_18_30 = dadosDominio.Field<Decimal?>("Premio_18_30");
            dadosConsulta.RendaPremio_31_40 = dadosDominio.Field<Decimal?>("Premio_31_40");
            dadosConsulta.RendaPremio_41_45 = dadosDominio.Field<Decimal?>("Premio_41_45");
            dadosConsulta.RendaPremio_46_50 = dadosDominio.Field<Decimal?>("Premio_46_50");
            dadosConsulta.RendaPremio_51_55 = dadosDominio.Field<Decimal?>("Premio_51_55");
            dadosConsulta.RendaPremio_56_60 = dadosDominio.Field<Decimal?>("Premio_56_60");
            dadosConsulta.RendaPremio_61_65 = dadosDominio.Field<Decimal?>("Premio_61_65");

            return dadosConsulta;
        }

        #endregion

        #region [ ListarTodosMorteAcidental ]

        public Dictionary<decimal, string> ListarTodosMorteAcidental(bool itemVazio, int idadeBase)
        {

            try
            {
                StringBuilder queryTabelaPlanoProtecao = new StringBuilder();
                queryTabelaPlanoProtecao.Append(@" SELECT  DISTINCT CoberturaMorte ");
                queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao         ");

                Dictionary<decimal, string> dadosRetornados;

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);
                    dadosRetornados = dadosTable.AsEnumerable().ToDictionary(registro => Convert.ToDecimal(registro[0]), registro => String.Format(new CultureInfo("pt-BR"), "{0:C}", registro[0]));
                }

                if (idadeBase == (int)FaixaEtaria.PREMIO_18_30)
                {
                    decimal[] regraManter = { 1500, 3000, 6000, 12000 };
                    dadosRetornados = dadosRetornados.Where(registro => regraManter.Contains(registro.Key)).ToDictionary(registro => registro.Key, registro => registro.Value);

                }

                if (itemVazio)
                {
                    dadosRetornados.Add(0, string.Empty);
                    dadosRetornados = dadosRetornados.OrderBy(order => order.Key).ToDictionary(registro => registro.Key, registro => registro.Value);
                }

                return dadosRetornados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ ListarTodosInvalidezAcidente ]

        public Dictionary<decimal, string> ListarTodosInvalidezAcidente(bool itemVazio, int idadeBase)
        {

            try
            {
                StringBuilder queryTabelaPlanoProtecao = new StringBuilder();
                queryTabelaPlanoProtecao.Append(@" SELECT  DISTINCT CoberturaAcidente ");
                queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao            ");

                Dictionary<decimal, string> dadosRetornados;
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);
                    dadosRetornados = dadosTable.AsEnumerable().ToDictionary(registro => Convert.ToDecimal(registro[0]), registro => String.Format(new CultureInfo("pt-BR"), "{0:C}", registro[0]));
                }

                if (idadeBase == (int)FaixaEtaria.PREMIO_18_30)
                {
                    decimal[] regraManter = { 1500, 3000, 6000, 12000 };
                    dadosRetornados = dadosRetornados.Where(registro => regraManter.Contains(registro.Key)).ToDictionary(registro => registro.Key, registro => registro.Value);

                }

                if (itemVazio)
                {
                    dadosRetornados.Add(0, string.Empty);
                    dadosRetornados = dadosRetornados.OrderBy(order => order.Key).ToDictionary(registro => registro.Key, registro => registro.Value);
                }

                return dadosRetornados;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Listar Valores de Invalidez por Acidente.");
            }
        }

        #endregion

        #region [ ListarTodosAssisteciaEmergencial ]

        public Dictionary<decimal, string> ListarTodosAssisteciaEmergencial(bool itemVazio)
        {
            try
            {
                StringBuilder queryTabelaPlanoProtecao = new StringBuilder();
                queryTabelaPlanoProtecao.Append(@" SELECT  DISTINCT CoberturaEmergencia ");
                queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecao              ");

                Dictionary<decimal, string> dadosRetornados;
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);
                    dadosRetornados = dadosTable.AsEnumerable().ToDictionary(registro => Convert.ToDecimal(registro[0]), registro => String.Format(new CultureInfo("pt-BR"), "{0:C}", registro[0]));
                }

                if (itemVazio)
                {
                    dadosRetornados.Add(0, string.Empty);
                    dadosRetornados = dadosRetornados.OrderBy(order => order.Key).ToDictionary(registro => registro.Key, registro => registro.Value);
                }

                return dadosRetornados;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Listar Valores de Assistência Emergencial.");
            }
        }

        #endregion

        #region [ ListarTodosFuneralCategoria ]

        public Dictionary<int, string> ListarTodosFuneralCategoria(bool itemVazio)
        {

            try
            {
                StringBuilder queryTabelaPlanoProtecao = new StringBuilder();
                queryTabelaPlanoProtecao.Append(@"   SELECT  DISTINCT Codigo         ");
                queryTabelaPlanoProtecao.Append(@"                  , NomePlano      ");
                queryTabelaPlanoProtecao.Append(@"     FROM   TPlanoProtecao         ");
                queryTabelaPlanoProtecao.Append(@" ORDER BY   Codigo                 ");

                Dictionary<int, string> dadosRetornados;
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);
                    dadosRetornados = dadosTable.AsEnumerable().ToDictionary(registro => Convert.ToInt32(registro[0]), registro => registro[1].ToString());
                }

                if (itemVazio)
                {
                    dadosRetornados.Add(0, string.Empty);
                    dadosRetornados = dadosRetornados.OrderBy(order => order.Key).ToDictionary(registro => registro.Key, registro => registro.Value);
                }

                return dadosRetornados;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Listar Valores de Categoria do Funeral.");
            }
        }

        #endregion

        #region [ ListarTodosRendaValor ]

        public Dictionary<decimal, string> ListarTodosRendaValor(bool itemVazio, int rendaPeriodo, int idadeBase)
        {

            try
            {
                string periodo = string.Empty;
                switch (rendaPeriodo)
                {
                    case (int)PeriodoRenda.AVISTA:
                        periodo = PeriodoRenda.AVISTA.GetStringValue();
                        break;
                    case (int)PeriodoRenda.MESES_3:
                        periodo = PeriodoRenda.MESES_3.GetStringValue();
                        break;
                    case (int)PeriodoRenda.MESES_6:
                        periodo = PeriodoRenda.MESES_6.GetStringValue();
                        break;
                    case (int)PeriodoRenda.MESES_12:
                        periodo = PeriodoRenda.MESES_12.GetStringValue();
                        break;
                    case (int)PeriodoRenda.MESES_24:
                        periodo = PeriodoRenda.MESES_24.GetStringValue();
                        break;
                    default:
                        periodo = PeriodoRenda.AVISTA.GetStringValue();
                        break;
                }

                StringBuilder queryTabelaPlanoProtecao = new StringBuilder();
                queryTabelaPlanoProtecao.Append(@" SELECT  DISTINCT CoberturaRendaMensal          ");
                queryTabelaPlanoProtecao.Append(@"   FROM   TPlanoProtecaoRenda                   ");
                queryTabelaPlanoProtecao.Append(@"  WHERE   RendaPeriodo like '%" + periodo + "%' ");

                Dictionary<decimal, string> dadosRetornados;
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);
                    dadosRetornados = dadosTable.AsEnumerable().ToDictionary(registro => Convert.ToDecimal(registro[0]), registro => String.Format(new CultureInfo("pt-BR"), "{0:C}", registro[0]));
                }

                if (rendaPeriodo == (int)PeriodoRenda.AVISTA && idadeBase == (int)FaixaEtaria.PREMIO_18_30)
                {
                    decimal[] regraManter = { 1500, 2250, 3000, 4500, 6000, 9000, 12000 };
                    dadosRetornados = dadosRetornados.Where(registro => regraManter.Contains(registro.Key)).ToDictionary(registro => registro.Key, registro => registro.Value);

                }

                if (rendaPeriodo == (int)PeriodoRenda.MESES_12 && idadeBase == (int)FaixaEtaria.PREMIO_18_30)
                {
                    decimal[] regraManter = { 500, 750, 1000 };
                    dadosRetornados = dadosRetornados.Where(registro => regraManter.Contains(registro.Key)).ToDictionary(registro => registro.Key, registro => registro.Value);

                }

                if (rendaPeriodo == (int)PeriodoRenda.MESES_24 && idadeBase == (int)FaixaEtaria.PREMIO_18_30)
                {
                    decimal[] regraManter = { 500 };
                    dadosRetornados = dadosRetornados.Where(registro => regraManter.Contains(registro.Key)).ToDictionary(registro => registro.Key, registro => registro.Value);

                }

                //Dia 07/01 Marcelo falou que não divide pelos meses, é o número da tabela
                //
                //switch (rendaPeriodo)
                //{
                //    case (int)PeriodoRenda.MESES_3:
                //        dadosRetornados = dadosRetornados.ToDictionary(registro => registro.Key , registro => String.Format(new CultureInfo("pt-BR"), "{0:C}", (registro.Key / 3)));
                //        break;
                //    case (int)PeriodoRenda.MESES_6:
                //        dadosRetornados = dadosRetornados.ToDictionary(registro => registro.Key , registro => String.Format(new CultureInfo("pt-BR"), "{0:C}", (registro.Key / 6)));
                //        break;
                //    case (int)PeriodoRenda.MESES_12:
                //        dadosRetornados = dadosRetornados.ToDictionary(registro => registro.Key , registro => String.Format(new CultureInfo("pt-BR"), "{0:C}", (registro.Key / 12)));
                //        break;
                //    case (int)PeriodoRenda.MESES_24:
                //        dadosRetornados = dadosRetornados.ToDictionary(registro => registro.Key , registro => String.Format(new CultureInfo("pt-BR"), "{0:C}", (registro.Key / 24)));
                //        break;
                //    default:
                //        break;
                //}

                if (itemVazio)
                {
                    dadosRetornados.Add(0, string.Empty);
                    dadosRetornados = dadosRetornados.OrderBy(order => order.Key).ToDictionary(registro => registro.Key, registro => registro.Value);
                }

                return dadosRetornados;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Listar Valores de Cobertura Renda Mensal.");
            }
        }

        #endregion

        #region [ ListarTodosRendaPeriodo ]

        public Dictionary<int, string> ListarTodosRendaPeriodo(bool itemVazio)
        {

            try
            {
                Dictionary<int, string> dadosRetornados = new Dictionary<int, string>();
                dadosRetornados.Add((int)PeriodoRenda.AVISTA, PeriodoRenda.AVISTA.GetStringValue());
                dadosRetornados.Add((int)PeriodoRenda.MESES_3, PeriodoRenda.MESES_3.GetStringValue());
                dadosRetornados.Add((int)PeriodoRenda.MESES_6, PeriodoRenda.MESES_6.GetStringValue());
                dadosRetornados.Add((int)PeriodoRenda.MESES_12, PeriodoRenda.MESES_12.GetStringValue());
                dadosRetornados.Add((int)PeriodoRenda.MESES_24, PeriodoRenda.MESES_24.GetStringValue());

                if (itemVazio)
                {
                    dadosRetornados.Add(-1, string.Empty);
                    dadosRetornados = dadosRetornados.OrderBy(order => order.Key).ToDictionary(registro => registro.Key, registro => registro.Value);
                }

                return dadosRetornados;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Listar Valores de Período.");
            }
        }

        #endregion

        #region [ CalcularPremioFuneral ]

        public TPlanoProtecaoDOMINIO CalcularPremioFuneral(decimal valorMorteNovo, decimal valorIPANovo, decimal valorAssistenciaNovo, int valorCategoriaNovo, int idadeBase)
        {

            try
            {
                TPlanoProtecaoDOMINIO planoFuneral = SelecionarPlanoProtecaoFuneral(valorMorteNovo, valorIPANovo, valorAssistenciaNovo, valorCategoriaNovo);

                switch (idadeBase)
                {
                    case (int)FaixaEtaria.PREMIO_18_30:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_18_30;
                        break;
                    case (int)FaixaEtaria.PREMIO_31_40:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_31_40;
                        break;
                    case (int)FaixaEtaria.PREMIO_41_45:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_41_45;
                        break;
                    case (int)FaixaEtaria.PREMIO_46_50:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_46_50;
                        break;
                    case (int)FaixaEtaria.PREMIO_51_55:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_51_55;
                        break;
                    case (int)FaixaEtaria.PREMIO_56_60:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_56_60;
                        break;
                    case (int)FaixaEtaria.PREMIO_61_65:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_61_65;
                        break;
                    default:
                        break;
                }

                return planoFuneral;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Calcular Prêmio do Funeral.");
            }
        }

        #endregion

        #region [ CalcularPremioAgregado ]

        public decimal CalcularPremioAgregado(int grauParentesco, int idade, string valorCategoria)
        {

            try
            {
                TPlanoProtecaoDOMINIO planoAgregado = new TPlanoProtecaoDOMINIO();

                if (grauParentesco == (int)GrauParentesco.CONJUGE)
                    return 0;

                if ((grauParentesco == (int)GrauParentesco.FILHO || grauParentesco == (int)GrauParentesco.ENTEADO) && idade <= 24)
                    return 0;

                if (idade <= 40)
                {
                    planoAgregado = SelecionarPlanoPremioAgregado(valorCategoria, 1);
                    if (idade <= 20)
                        return planoAgregado.FuneralAte_20.GetValueOrDefault();
                    else
                        return planoAgregado.FuneralDe_21_40.GetValueOrDefault();
                }
                else
                {
                    if (idade <= 60)
                    {
                        planoAgregado = SelecionarPlanoPremioAgregado(valorCategoria, 2);
                        if (idade <= 50)
                            return planoAgregado.FuneralDe_41_50.GetValueOrDefault();
                        else
                            return planoAgregado.FuneralDe_51_60.GetValueOrDefault();
                    }
                    else
                    {
                        if (idade <= 70)
                        {
                            planoAgregado = SelecionarPlanoPremioAgregado(valorCategoria, 3);
                            if (idade <= 65)
                                return planoAgregado.FuneralDe_61_65.GetValueOrDefault();
                            else
                                return planoAgregado.FuneralDe_66_70.GetValueOrDefault();
                        }
                        else
                        {
                            planoAgregado = SelecionarPlanoPremioAgregado(valorCategoria, 4);
                            if (idade <= 75)
                                return planoAgregado.FuneralDe_71_75.GetValueOrDefault();
                            else
                                return planoAgregado.FuneralDe_76_80.GetValueOrDefault();
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw new Exception("Erro ao Calcular Prêmio do Agregado.");
            }
        }

        #endregion

        #region [ CalcularPremioRenda ]

        public TPlanoProtecaoDOMINIO CalcularPremioRenda(string periodoNovo, decimal valorRendaNovo, int idadeBase)
        {
            try
            {
                TPlanoProtecaoDOMINIO planoRenda = new TPlanoProtecaoDOMINIO();

                planoRenda = SelecionarPlanoProtecaoRenda(periodoNovo, valorRendaNovo);

                switch (idadeBase)
                {
                    case (int)FaixaEtaria.PREMIO_18_30:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_18_30;
                        break;
                    case (int)FaixaEtaria.PREMIO_31_40:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_31_40;
                        break;
                    case (int)FaixaEtaria.PREMIO_41_45:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_41_45;
                        break;
                    case (int)FaixaEtaria.PREMIO_46_50:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_46_50;
                        break;
                    case (int)FaixaEtaria.PREMIO_51_55:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_51_55;
                        break;
                    case (int)FaixaEtaria.PREMIO_56_60:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_56_60;
                        break;
                    case (int)FaixaEtaria.PREMIO_61_65:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_61_65;
                        break;
                    default:
                        break;
                }

                return planoRenda;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Calcular Prêmio da Renda.");
            }
        }

        #endregion

        #region [ SelecionarPlanoProtecaoFuneral ]

        public TPlanoProtecaoDOMINIO SelecionarPlanoProtecaoFuneral(decimal coberturaMorte, decimal coberturaAcidente, decimal coberturaEmergencia, int codigoPlano)
        {
            StringBuilder queryTabelaPlanoProtecao = new StringBuilder();

            queryTabelaPlanoProtecao.Append(@" SELECT   IDPlanoProtecao       ");
            queryTabelaPlanoProtecao.Append(@"        , Codigo                ");
            queryTabelaPlanoProtecao.Append(@"        , NomePlano             ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaMorte        ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaAcidente     ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaEmergencia   ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_18_30          ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_31_40          ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_41_45          ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_46_50          ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_51_55          ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_56_60          ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_61_65          ");
            queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecao          ");
            queryTabelaPlanoProtecao.Append(@" WHERE  Codigo = " + codigoPlano + " ");
            queryTabelaPlanoProtecao.Append(@"   AND  CoberturaMorte  = " + coberturaMorte.ToString().Replace(',', '.') + " ");
            //queryTabelaPlanoProtecao.Append(@"   AND  CoberturaAcidente  <= " + coberturaAcidente + " ");
            //queryTabelaPlanoProtecao.Append(@"   AND  CoberturaEmergencia  <= " + coberturaEmergencia + " ");

            TPlanoProtecaoDOMINIO planoFuneral = new TPlanoProtecaoDOMINIO();

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable();
                dadosTable.Load(dados);
                if (dadosTable.Rows.Count > 0)
                    planoFuneral = MontarDominioTPlanoProtecao(dadosTable.Rows[0]);
            }


            if (planoFuneral == null)
                return new TPlanoProtecaoDOMINIO();
            else
                return planoFuneral;
        }

        #endregion

        #region [ SelecionarPlanoPremioAgregado ]

        public TPlanoProtecaoDOMINIO SelecionarPlanoPremioAgregado(string nomePlano, int codigoFaixa)
        {
            StringBuilder queryTabelaPlanoProtecao = new StringBuilder();

            queryTabelaPlanoProtecao.Append(@" SELECT   IDPlanoProtecaoFuneral ");
            queryTabelaPlanoProtecao.Append(@"        , Codigo                 ");
            queryTabelaPlanoProtecao.Append(@"        , Categoria              ");
            queryTabelaPlanoProtecao.Append(@"        , Ate_20                 ");
            queryTabelaPlanoProtecao.Append(@"        , De_21_40               ");
            queryTabelaPlanoProtecao.Append(@"        , De_41_50               ");
            queryTabelaPlanoProtecao.Append(@"        , De_51_60               ");
            queryTabelaPlanoProtecao.Append(@"        , De_61_65               ");
            queryTabelaPlanoProtecao.Append(@"        , De_66_70               ");
            queryTabelaPlanoProtecao.Append(@"        , De_71_75               ");
            queryTabelaPlanoProtecao.Append(@"        , De_76_80               ");
            queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoFuneral    ");
            queryTabelaPlanoProtecao.Append(@" WHERE  Categoria = '" + nomePlano + "' ");
            queryTabelaPlanoProtecao.Append(@"   AND  Codigo  = " + codigoFaixa + " ");

            TPlanoProtecaoDOMINIO planoAgregado = new TPlanoProtecaoDOMINIO();

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable();
                dadosTable.Load(dados);
                if (dadosTable.Rows.Count > 0)
                    planoAgregado = MontarDominioTPlanoProtecaoFuneral(dadosTable.Rows[0]);
            }


            if (planoAgregado == null)
                return new TPlanoProtecaoDOMINIO();
            else
                return planoAgregado;
        }

        #endregion

        #region [ SelecionarPlanoProtecaoRenda ]

        public TPlanoProtecaoDOMINIO SelecionarPlanoProtecaoRenda(string periodoNovo, decimal valorRendaNovo)
        {
            StringBuilder queryTabelaPlanoProtecao = new StringBuilder();

            queryTabelaPlanoProtecao.Append(@" SELECT   IDPlanoProtecaoRenda    ");
            queryTabelaPlanoProtecao.Append(@"        , RendaPeriodo            ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaRendaMensal    ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaCapitalTotal   ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_18_30            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_31_40            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_41_45            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_46_50            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_51_55            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_56_60            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_61_65            ");
            queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoRenda       ");
            queryTabelaPlanoProtecao.Append(@" WHERE  RendaPeriodo LIKE '%" + periodoNovo + "%' ");
            queryTabelaPlanoProtecao.Append(@"   AND  CoberturaRendaMensal  = " + valorRendaNovo.ToString().Replace(',', '.') + " ");

            TPlanoProtecaoDOMINIO planoRenda = new TPlanoProtecaoDOMINIO();

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable();
                dadosTable.Load(dados);
                if (dadosTable.Rows.Count > 0)
                    planoRenda = MontarDominioTPlanoProtecaoRenda(dadosTable.Rows[0]);
            }


            if (planoRenda == null)
                return new TPlanoProtecaoDOMINIO();
            else
                return planoRenda;
        }

        #endregion

        #region [ SelecionarPlanoProtecaoRendaInicial ]

        public TPlanoProtecaoDOMINIO SelecionarPlanoProtecaoRendaInicial(int idadeBase, decimal premio)
        {
            TPlanoProtecaoDOMINIO planoRenda = new TPlanoProtecaoDOMINIO();

            DataTable tabelaLimite = ConsultarPlanoProtecaoRendaLimite(idadeBase, premio);

            if (tabelaLimite.Rows.Count > 0)
                planoRenda = MontarDominioTPlanoProtecaoRenda(tabelaLimite.Rows[0]);
            else
            {
                DataTable tabelaMinimo = ConsultarPlanoProtecaoRendaMinimo(idadeBase);
                if (tabelaMinimo.Rows.Count > 0)
                    planoRenda = MontarDominioTPlanoProtecaoRenda(tabelaMinimo.Rows[0]);
            }
            
            if (planoRenda == null || planoRenda.IDPlanoProtecaoRenda == 0)
                return new TPlanoProtecaoDOMINIO();
            else
            {
                switch (idadeBase)
                {
                    case (int)FaixaEtaria.PREMIO_18_30:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_18_30;
                        break;
                    case (int)FaixaEtaria.PREMIO_31_40:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_31_40;
                        break;
                    case (int)FaixaEtaria.PREMIO_41_45:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_41_45;
                        break;
                    case (int)FaixaEtaria.PREMIO_46_50:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_46_50;
                        break;
                    case (int)FaixaEtaria.PREMIO_51_55:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_51_55;
                        break;
                    case (int)FaixaEtaria.PREMIO_56_60:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_56_60;
                        break;
                    case (int)FaixaEtaria.PREMIO_61_65:
                        planoRenda.RendaValorPremioIdadeBase = planoRenda.RendaPremio_61_65;
                        break;
                    default:
                        break;
                }

                return planoRenda;
            }
        }

        #endregion

        #region [ ConsultarPlanoProtecaoFuneral ]

        public DataTable ConsultarPlanoProtecaoFuneral(int faixaBase)
        {
            StringBuilder queryTabelaPlanoProtecao = new StringBuilder();

            queryTabelaPlanoProtecao.Append(@" SELECT   IDPlanoProtecao       ");
            queryTabelaPlanoProtecao.Append(@"        , NomePlano             ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaMorte        ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaAcidente     ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaEmergencia   ");


            switch (faixaBase)
            {
                case (int)FaixaEtaria.PREMIO_18_30:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_18_30  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecao                 ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_18_30 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_31_40:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_31_40  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecao                 ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_31_40 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_41_45:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_41_45  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecao                 ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_41_45 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_46_50:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_46_50  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecao                 ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_46_50 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_51_55:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_51_55  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecao                 ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_51_55 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_56_60:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_56_60  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecao                 ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_56_60 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_61_65:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_61_65  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecao                 ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_61_65 IS NOT NULL       ");
                    break;
                default:
                    break;
            }


            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable("Planos");
                dadosTable.Load(dados);

                return dadosTable;
            }
        }

        #endregion

        #region [ ConsultarPlanoProtecaoAgregado ]

        public DataTable ConsultarPlanoProtecaoAgregado()
        {
            DataTable dtAgregados = new DataTable("Agregados");
            DataColumn dcFaixaEtaria = new DataColumn("FaixaEtaria");
            DataColumn dcEspecial = new DataColumn("Especial");
            DataColumn dcSuperior = new DataColumn("Superior");
            DataColumn dcLuxo = new DataColumn("Luxo");

            dtAgregados.Columns.Add(dcFaixaEtaria);
            dtAgregados.Columns.Add(dcEspecial);
            dtAgregados.Columns.Add(dcSuperior);
            dtAgregados.Columns.Add(dcLuxo);

            StringBuilder queryFaixa20_40 = new StringBuilder();

            queryFaixa20_40.Append(@" SELECT   Categoria              ");
            queryFaixa20_40.Append(@"        , SUM(Ate_20) AS Val_1   ");
            queryFaixa20_40.Append(@"        , SUM(De_21_40) AS Val_2 ");
            queryFaixa20_40.Append(@"  FROM  TPlanoProtecaoFuneral    ");
            queryFaixa20_40.Append(@" WHERE  Ate_20 IS NOT NULL       ");
            queryFaixa20_40.Append(@"   AND  De_21_40 IS NOT NULL     ");
            queryFaixa20_40.Append(@" GROUP BY Categoria              ");
            queryFaixa20_40.Append(@" ORDER BY Categoria              ");

            StringBuilder queryFaixa41_60 = new StringBuilder();

            queryFaixa41_60.Append(@" SELECT   Categoria              ");
            queryFaixa41_60.Append(@"        , SUM(De_41_50) AS Val_1 ");
            queryFaixa41_60.Append(@"        , SUM(De_51_60) AS Val_2 ");
            queryFaixa41_60.Append(@"  FROM  TPlanoProtecaoFuneral    ");
            queryFaixa41_60.Append(@" WHERE  De_41_50 IS NOT NULL     ");
            queryFaixa41_60.Append(@"   AND  De_51_60 IS NOT NULL     ");
            queryFaixa41_60.Append(@" GROUP BY Categoria              ");
            queryFaixa41_60.Append(@" ORDER BY Categoria              ");

            StringBuilder queryFaixa61_70 = new StringBuilder();

            queryFaixa61_70.Append(@" SELECT   Categoria              ");
            queryFaixa61_70.Append(@"        , SUM(De_61_65) AS Val_1 ");
            queryFaixa61_70.Append(@"        , SUM(De_66_70) AS Val_2 ");
            queryFaixa61_70.Append(@"  FROM  TPlanoProtecaoFuneral    ");
            queryFaixa61_70.Append(@" WHERE  De_61_65 IS NOT NULL     ");
            queryFaixa61_70.Append(@"   AND  De_66_70 IS NOT NULL     ");
            queryFaixa61_70.Append(@" GROUP BY Categoria              ");
            queryFaixa61_70.Append(@" ORDER BY Categoria              ");

            StringBuilder queryFaixa71_80 = new StringBuilder();

            queryFaixa71_80.Append(@" SELECT   Categoria              ");
            queryFaixa71_80.Append(@"        , SUM(De_71_75) AS Val_1 ");
            queryFaixa71_80.Append(@"        , SUM(De_76_80) AS Val_2 ");
            queryFaixa71_80.Append(@"  FROM  TPlanoProtecaoFuneral    ");
            queryFaixa71_80.Append(@" WHERE  De_71_75 IS NOT NULL     ");
            queryFaixa71_80.Append(@"   AND  De_76_80 IS NOT NULL     ");
            queryFaixa71_80.Append(@" GROUP BY Categoria              ");
            queryFaixa71_80.Append(@" ORDER BY Categoria              ");

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryFaixa20_40.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable();
                DataRow drItems = dtAgregados.NewRow();

                dadosTable.Load(dados);
                if (dadosTable.Rows.Count == 3)
                {
                    drItems = dtAgregados.NewRow();
                    drItems["FaixaEtaria"] = "Até 20";
                    drItems["Especial"] = dadosTable.Rows[0]["Val_1"];
                    drItems["Luxo"] = dadosTable.Rows[1]["Val_1"];
                    drItems["Superior"] = dadosTable.Rows[2]["Val_1"];
                    dtAgregados.Rows.Add(drItems);

                    drItems = dtAgregados.NewRow();
                    drItems["FaixaEtaria"] = "21 - 40";
                    drItems["Especial"] = dadosTable.Rows[0]["Val_2"];
                    drItems["Luxo"] = dadosTable.Rows[1]["Val_2"];
                    drItems["Superior"] = dadosTable.Rows[2]["Val_2"];
                    dtAgregados.Rows.Add(drItems);
                }

                command = new SqlCeCommand(queryFaixa41_60.ToString(), conn);
                dados = command.ExecuteReader();
                dadosTable = new DataTable();
                drItems = dtAgregados.NewRow();

                dadosTable.Load(dados);
                if (dadosTable.Rows.Count == 3)
                {
                    drItems = dtAgregados.NewRow();
                    drItems["FaixaEtaria"] = "41 - 50";
                    drItems["Especial"] = dadosTable.Rows[0]["Val_1"];
                    drItems["Luxo"] = dadosTable.Rows[1]["Val_1"];
                    drItems["Superior"] = dadosTable.Rows[2]["Val_1"];
                    dtAgregados.Rows.Add(drItems);

                    drItems = dtAgregados.NewRow();
                    drItems["FaixaEtaria"] = "51 - 60";
                    drItems["Especial"] = dadosTable.Rows[0]["Val_2"];
                    drItems["Luxo"] = dadosTable.Rows[1]["Val_2"];
                    drItems["Superior"] = dadosTable.Rows[2]["Val_2"];
                    dtAgregados.Rows.Add(drItems);
                }

                command = new SqlCeCommand(queryFaixa61_70.ToString(), conn);
                dados = command.ExecuteReader();
                dadosTable = new DataTable();
                drItems = dtAgregados.NewRow();

                dadosTable.Load(dados);
                if (dadosTable.Rows.Count == 3)
                {
                    drItems = dtAgregados.NewRow();
                    drItems["FaixaEtaria"] = "61 - 65";
                    drItems["Especial"] = dadosTable.Rows[0]["Val_1"];
                    drItems["Luxo"] = dadosTable.Rows[1]["Val_1"];
                    drItems["Superior"] = dadosTable.Rows[2]["Val_1"];
                    dtAgregados.Rows.Add(drItems);

                    drItems = dtAgregados.NewRow();
                    drItems["FaixaEtaria"] = "66 - 70";
                    drItems["Especial"] = dadosTable.Rows[0]["Val_2"];
                    drItems["Luxo"] = dadosTable.Rows[1]["Val_2"];
                    drItems["Superior"] = dadosTable.Rows[2]["Val_2"];
                    dtAgregados.Rows.Add(drItems);
                }

                command = new SqlCeCommand(queryFaixa71_80.ToString(), conn);
                dados = command.ExecuteReader();
                dadosTable = new DataTable();
                drItems = dtAgregados.NewRow();

                dadosTable.Load(dados);
                if (dadosTable.Rows.Count == 3)
                {
                    drItems = dtAgregados.NewRow();
                    drItems["FaixaEtaria"] = "71 - 75";
                    drItems["Especial"] = dadosTable.Rows[0]["Val_1"];
                    drItems["Luxo"] = dadosTable.Rows[1]["Val_1"];
                    drItems["Superior"] = dadosTable.Rows[2]["Val_1"];
                    dtAgregados.Rows.Add(drItems);

                    drItems = dtAgregados.NewRow();
                    drItems["FaixaEtaria"] = "76 - 80";
                    drItems["Especial"] = dadosTable.Rows[0]["Val_2"];
                    drItems["Luxo"] = dadosTable.Rows[1]["Val_2"];
                    drItems["Superior"] = dadosTable.Rows[2]["Val_2"];
                    dtAgregados.Rows.Add(drItems);
                }
            }

            return dtAgregados;
        }

        #endregion

        #region [ ConsultarPlanoProtecaoRenda ]

        public DataTable ConsultarPlanoProtecaoRenda(int faixaBase)
        {
            StringBuilder queryTabelaPlanoProtecao = new StringBuilder();

            queryTabelaPlanoProtecao.Append(@" SELECT   IDPlanoProtecaoRenda    ");
            queryTabelaPlanoProtecao.Append(@"        , RendaPeriodo            ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaRendaMensal    ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaCapitalTotal   ");

            switch (faixaBase)
            {
                case (int)FaixaEtaria.PREMIO_18_30:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_18_30  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoRenda            ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_18_30 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_31_40:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_31_40  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoRenda            ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_31_40 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_41_45:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_41_45  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoRenda            ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_41_45 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_46_50:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_46_50  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoRenda            ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_46_50 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_51_55:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_51_55  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoRenda            ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_51_55 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_56_60:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_56_60  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoRenda            ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_56_60 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_61_65:
                    queryTabelaPlanoProtecao.Append(@"        , Premio_61_65  AS PremioValor ");
                    queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoRenda            ");
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_61_65 IS NOT NULL       ");
                    break;
                default:
                    break;
            }

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable("Renda");
                dadosTable.Load(dados);

                return dadosTable;
            }
        }

        #endregion

        #region [ ConsultarPlanoProtecaoRendaLimite ]

        public DataTable ConsultarPlanoProtecaoRendaLimite(int idadeBase, decimal premio)
        {
            StringBuilder queryTabelaPlanoProtecao = new StringBuilder();

            queryTabelaPlanoProtecao.Append(@" SELECT   IDPlanoProtecaoRenda    ");
            queryTabelaPlanoProtecao.Append(@"        , RendaPeriodo            ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaRendaMensal    ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaCapitalTotal   ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_18_30            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_31_40            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_41_45            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_46_50            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_51_55            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_56_60            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_61_65            ");
            queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoRenda       ");

            switch (idadeBase)
            {
                case (int)FaixaEtaria.PREMIO_18_30:
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_18_30 <= " + premio);
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_18_30 DESC ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda DESC ");
                    break;
                case (int)FaixaEtaria.PREMIO_31_40:
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_31_40 <= " + premio);
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_31_40 DESC ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda DESC ");
                    break;
                case (int)FaixaEtaria.PREMIO_41_45:
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_41_45 <= " + premio);
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_41_45 DESC ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda DESC ");
                    break;
                case (int)FaixaEtaria.PREMIO_46_50:
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_46_50 <= " + premio);
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_46_50 DESC ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda DESC ");
                    break;
                case (int)FaixaEtaria.PREMIO_51_55:
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_51_55 <= " + premio);
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_51_55 DESC ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda DESC ");
                    break;
                case (int)FaixaEtaria.PREMIO_56_60:
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_56_60 <= " + premio);
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_56_60 DESC ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda DESC ");
                    break;
                case (int)FaixaEtaria.PREMIO_61_65:
                    queryTabelaPlanoProtecao.Append(@" WHERE  Premio_61_65 <= " + premio);
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_61_65 DESC ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda DESC ");
                    break;
                default:
                    break;
            }
                        
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable();
                dadosTable.Load(dados);

                return dadosTable;
            }
        }

        #endregion

        #region [ ConsultarPlanoProtecaoRendaMinimo ]

        public DataTable ConsultarPlanoProtecaoRendaMinimo(int idadeBase)
        {
            StringBuilder queryTabelaPlanoProtecao = new StringBuilder();

            queryTabelaPlanoProtecao.Append(@" SELECT   IDPlanoProtecaoRenda    ");
            queryTabelaPlanoProtecao.Append(@"        , RendaPeriodo            ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaRendaMensal    ");
            queryTabelaPlanoProtecao.Append(@"        , CoberturaCapitalTotal   ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_18_30            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_31_40            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_41_45            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_46_50            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_51_55            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_56_60            ");
            queryTabelaPlanoProtecao.Append(@"        , Premio_61_65            ");
            queryTabelaPlanoProtecao.Append(@"  FROM  TPlanoProtecaoRenda       ");

            switch (idadeBase)
            {
                case (int)FaixaEtaria.PREMIO_18_30:
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_18_30  ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda ");
                    break;
                case (int)FaixaEtaria.PREMIO_31_40:
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_31_40  ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda ");
                    break;
                case (int)FaixaEtaria.PREMIO_41_45:
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_41_45  ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda ");
                    break;
                case (int)FaixaEtaria.PREMIO_46_50:
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_46_50  ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda ");
                    break;
                case (int)FaixaEtaria.PREMIO_51_55:
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_51_55  ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda ");
                    break;
                case (int)FaixaEtaria.PREMIO_56_60:
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_56_60  ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda ");
                    break;
                case (int)FaixaEtaria.PREMIO_61_65:
                    queryTabelaPlanoProtecao.Append(@" ORDER BY Premio_61_65  ");
                    queryTabelaPlanoProtecao.Append(@" , IDPlanoProtecaoRenda ");
                    break;
                default:
                    break;
            }

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoProtecao.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable();
                dadosTable.Load(dados);

                return dadosTable;
            }
        }

        #endregion

        #endregion
    }
}
