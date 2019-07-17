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
    public class TPlanoCasalPERSISTENCIA
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

        public TPlanoCasalDOMINIO ConsultaCategoriaSuperior(int faixaPadaro, decimal valorPremioAPD)
        {
            try
            {
                StringBuilder queryTabelaPlanoCasal = new StringBuilder();
                StringBuilder queryTabelaPlanoCasalMaior = new StringBuilder();
                StringBuilder queryTabelaPlanoCasalMenor = new StringBuilder();

                queryTabelaPlanoCasal.Append(@" SELECT   IDPlanoCasal          ");
                queryTabelaPlanoCasal.Append(@"        , Codigo                ");
                queryTabelaPlanoCasal.Append(@"        , NomePlano             ");
                queryTabelaPlanoCasal.Append(@"        , CoberturaMorte        ");
                queryTabelaPlanoCasal.Append(@"        , CoberturaConjuge      ");
                queryTabelaPlanoCasal.Append(@"        , Premio_61_65          ");
                queryTabelaPlanoCasal.Append(@"        , Premio_66_70          ");
                queryTabelaPlanoCasal.Append(@"        , Premio_71_75          ");
                queryTabelaPlanoCasal.Append(@"        , Premio_76_80          ");

                string valorPremioAP = Decimal.Round(valorPremioAPD, 2).ToString().Replace(',', '.'); 

                switch (faixaPadaro)
                {
                    case (int)FaixaEtaria.PREMIO_61_65:
                        queryTabelaPlanoCasal.Append(@"   , Premio_61_65 AS ValorPadrao  ");
                        queryTabelaPlanoCasal.Append(@"   FROM   TPlanoCasal             ");
                        queryTabelaPlanoCasal.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoCasalMenor.Append(queryTabelaPlanoCasal.ToString());
                        queryTabelaPlanoCasalMaior.Append(queryTabelaPlanoCasal.ToString());
                        queryTabelaPlanoCasalMenor.Append(@"        AND  Premio_61_65  <= " + valorPremioAP + " ");
                        queryTabelaPlanoCasalMenor.Append(@"   ORDER BY  Premio_61_65 DESC                      ");
                        queryTabelaPlanoCasalMaior.Append(@"        AND  Premio_61_65  >= " + valorPremioAP + " ");
                        queryTabelaPlanoCasalMaior.Append(@"   ORDER BY  Premio_61_65                           ");
                        break;
                    case (int)FaixaEtaria.PREMIO_66_70:
                        queryTabelaPlanoCasal.Append(@"   , Premio_66_70 AS ValorPadrao  ");
                        queryTabelaPlanoCasal.Append(@"   FROM   TPlanoCasal             ");
                        queryTabelaPlanoCasal.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoCasalMenor.Append(queryTabelaPlanoCasal.ToString());
                        queryTabelaPlanoCasalMaior.Append(queryTabelaPlanoCasal.ToString());
                        queryTabelaPlanoCasalMenor.Append(@"        AND  Premio_66_70  <= " + valorPremioAP + " ");
                        queryTabelaPlanoCasalMenor.Append(@"   ORDER BY  Premio_66_70 DESC                      ");
                        queryTabelaPlanoCasalMaior.Append(@"        AND  Premio_66_70  >= " + valorPremioAP + " ");
                        queryTabelaPlanoCasalMaior.Append(@"   ORDER BY  Premio_66_70                           ");
                        break;
                    case (int)FaixaEtaria.PREMIO_71_75:
                        queryTabelaPlanoCasal.Append(@"   , Premio_71_75 AS ValorPadrao  ");
                        queryTabelaPlanoCasal.Append(@"   FROM   TPlanoCasal             ");
                        queryTabelaPlanoCasal.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoCasalMenor.Append(queryTabelaPlanoCasal.ToString());
                        queryTabelaPlanoCasalMaior.Append(queryTabelaPlanoCasal.ToString());
                        queryTabelaPlanoCasalMenor.Append(@"        AND  Premio_71_75  <= " + valorPremioAP + " ");
                        queryTabelaPlanoCasalMenor.Append(@"   ORDER BY  Premio_71_75 DESC                      ");
                        queryTabelaPlanoCasalMaior.Append(@"        AND  Premio_71_75  >= " + valorPremioAP + " ");
                        queryTabelaPlanoCasalMaior.Append(@"   ORDER BY  Premio_71_75                           ");
                        break;
                    case (int)FaixaEtaria.PREMIO_76_80:
                        queryTabelaPlanoCasal.Append(@"   , Premio_76_80 AS ValorPadrao  ");
                        queryTabelaPlanoCasal.Append(@"   FROM   TPlanoCasal             ");
                        queryTabelaPlanoCasal.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoCasalMenor.Append(queryTabelaPlanoCasal.ToString());
                        queryTabelaPlanoCasalMaior.Append(queryTabelaPlanoCasal.ToString());
                        queryTabelaPlanoCasalMenor.Append(@"        AND  Premio_76_80  <= " + valorPremioAP + " ");
                        queryTabelaPlanoCasalMenor.Append(@"   ORDER BY  Premio_76_80 DESC                      ");
                        queryTabelaPlanoCasalMaior.Append(@"        AND  Premio_76_80  >= " + valorPremioAP + " ");
                        queryTabelaPlanoCasalMaior.Append(@"   ORDER BY  Premio_76_80                           ");
                        break;
                    default:
                        queryTabelaPlanoCasal.Append(@"   , 0 AS ValorPadrao ");
                        queryTabelaPlanoCasal.Append(@"   FROM   TPlanoCasal           ");
                        queryTabelaPlanoCasal.Append(@"  WHERE   NomePlano = 'Superior'  ");
                        queryTabelaPlanoCasalMenor.Append(queryTabelaPlanoCasal.ToString());
                        queryTabelaPlanoCasalMaior.Append(queryTabelaPlanoCasal.ToString());
                        break;
                }

                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand commandMenor = new SqlCeCommand(queryTabelaPlanoCasalMenor.ToString(), conn);
                    SqlCeDataReader dadosMenor = commandMenor.ExecuteReader();
                    DataTable dadosTableMenor = new DataTable();
                    dadosTableMenor.Load(dadosMenor);

                    SqlCeCommand commandMaior = new SqlCeCommand(queryTabelaPlanoCasalMaior.ToString(), conn);
                    SqlCeDataReader dadosMaior = commandMaior.ExecuteReader();
                    DataTable dadosTableMaior = new DataTable();
                    dadosTableMaior.Load(dadosMaior);

                    if ((dadosTableMenor.Rows.Count > 0) && (dadosTableMaior.Rows.Count > 0))
                    {
                        if (valorPremioAPD - Convert.ToDecimal(dadosTableMenor.Rows[0]["ValorPadrao"]) > Convert.ToDecimal(dadosTableMaior.Rows[0]["ValorPadrao"]) - valorPremioAPD)
                            return MontarDominioTPlanoCasal(dadosTableMaior.Rows[0]);
                        else
                            return MontarDominioTPlanoCasal(dadosTableMenor.Rows[0]);
                    }
                    else
                    {
                        if (dadosTableMenor.Rows.Count > 0)
                            return MontarDominioTPlanoCasal(dadosTableMenor.Rows[0]);

                        if (dadosTableMaior.Rows.Count > 0)
                            return MontarDominioTPlanoCasal(dadosTableMaior.Rows[0]);

                        return new TPlanoCasalDOMINIO();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ MontarDominioTPlanoCasal ]

        public TPlanoCasalDOMINIO MontarDominioTPlanoCasal(DataRow dadosDominio)
        {
            TPlanoCasalDOMINIO dadosConsulta = new TPlanoCasalDOMINIO();
            dadosConsulta.IDPlanoCasal = Convert.ToInt32(dadosDominio["IDPlanoCasal"]);
            dadosConsulta.Codigo = Convert.ToInt32(dadosDominio["Codigo"]);
            dadosConsulta.NomePlano = dadosDominio["NomePlano"].ToString();
            dadosConsulta.CoberturaMorte = Convert.ToDecimal(dadosDominio["CoberturaMorte"]);
            dadosConsulta.CoberturaConjuge = Convert.ToDecimal(dadosDominio["CoberturaConjuge"]);
            dadosConsulta.Premio_61_65 = dadosDominio.Field<Decimal?>("Premio_61_65");
            dadosConsulta.Premio_66_70 = dadosDominio.Field<Decimal?>("Premio_66_70");
            dadosConsulta.Premio_71_75 = dadosDominio.Field<Decimal?>("Premio_71_75");
            dadosConsulta.Premio_76_80 = dadosDominio.Field<Decimal?>("Premio_76_80");

            return dadosConsulta;
        }

        #endregion

        #region [ MontarDominioTPlanoCasalFuneral ]

        public TPlanoCasalDOMINIO MontarDominioTPlanoCasalFuneral(DataRow dadosDominio)
        {
            TPlanoCasalDOMINIO dadosConsulta = new TPlanoCasalDOMINIO();
            dadosConsulta.IDPlanoCasalFuneral = Convert.ToInt32(dadosDominio["IDPlanoCasalFuneral"]);
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

        #region [ ListarTodosFuneralPrincipal ]

        public Dictionary<decimal, string> ListarTodosFuneralPrincipal(bool itemVazio, int idadeBase)
        {

            try
            {
                StringBuilder queryTabelaPlanoCasal = new StringBuilder();
                queryTabelaPlanoCasal.Append(@" SELECT  DISTINCT CoberturaMorte ");
                queryTabelaPlanoCasal.Append(@"   FROM   TPlanoCasal            ");

                Dictionary<decimal, string> dadosRetornados = new Dictionary<decimal, string>();
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoCasal.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);
                    dadosRetornados = dadosTable.AsEnumerable().ToDictionary(registro => Convert.ToDecimal(registro[0]), registro => String.Format(new CultureInfo("pt-BR"), "{0:C}", registro[0]));
                }

                if (idadeBase == (int)FaixaEtaria.PREMIO_71_75 || idadeBase == (int)FaixaEtaria.PREMIO_76_80)
                {
                    decimal[] regraManter = { 500, 1000, 2500, 5000 };
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
                throw new Exception("Erro ao Listar Valores de Cobertura Morte Principal.");
            }
        }

        #endregion

        #region [ ListarTodosFuneralConjuge ]

        public Dictionary<decimal, string> ListarTodosFuneralConjuge(bool itemVazio, int idadeBase)
        {

            try
            {
                StringBuilder queryTabelaPlanoCasal = new StringBuilder();
                queryTabelaPlanoCasal.Append(@" SELECT  DISTINCT CoberturaConjuge ");
                queryTabelaPlanoCasal.Append(@"   FROM   TPlanoCasal              ");

                Dictionary<decimal, string> dadosRetornados = new Dictionary<decimal, string>();
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoCasal.ToString(), conn);
                    SqlCeDataReader dados = command.ExecuteReader();
                    DataTable dadosTable = new DataTable();
                    dadosTable.Load(dados);
                    dadosRetornados = dadosTable.AsEnumerable().ToDictionary(registro => Convert.ToDecimal(registro[0]), registro => String.Format(new CultureInfo("pt-BR"), "{0:C}", registro[0]));
                }

                if (idadeBase == (int)FaixaEtaria.PREMIO_71_75 || idadeBase == (int)FaixaEtaria.PREMIO_76_80)
                {
                    decimal[] regraManter = { 250, 500, 1250, 2500 };
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
                throw new Exception("Erro ao Listar Valores de Cobertura Morte Cônjuge.");
            }
        }

        #endregion

        #region [ ListarTodosFuneralCategoria ]

        public Dictionary<int, string> ListarTodosFuneralCategoria(bool itemVazio)
        {

            try
            {
                StringBuilder queryTabelaPlanoCasal = new StringBuilder();
                queryTabelaPlanoCasal.Append(@"   SELECT  DISTINCT Codigo         ");
                queryTabelaPlanoCasal.Append(@"                  , NomePlano      ");
                queryTabelaPlanoCasal.Append(@"     FROM   TPlanoCasal            ");
                queryTabelaPlanoCasal.Append(@" ORDER BY   Codigo                 ");

                Dictionary<int, string> dadosRetornados = new Dictionary<int, string>();
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoCasal.ToString(), conn);
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

        #region [ CalcularPremioFuneral ]

        public TPlanoCasalDOMINIO CalcularPremioFuneral(decimal valorPrincipalNovo, decimal valorConjugeNovo, int valorCategoriaNovo, int idadeBase)
        {

            try
            {
                TPlanoCasalDOMINIO planoFuneral = SelecionarPlanoCasalFuneral(valorPrincipalNovo, valorConjugeNovo, valorCategoriaNovo);

                if (planoFuneral == null)
                    return new TPlanoCasalDOMINIO();


                switch (idadeBase)
                {
                    case (int)FaixaEtaria.PREMIO_61_65:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_61_65;
                        break;
                    case (int)FaixaEtaria.PREMIO_66_70:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_66_70;
                        break;
                    case (int)FaixaEtaria.PREMIO_71_75:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_71_75;
                        break;
                    case (int)FaixaEtaria.PREMIO_76_80:
                        planoFuneral.ValorPremioIdadeBase = planoFuneral.Premio_76_80;
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
                TPlanoCasalDOMINIO planoAgregado = new TPlanoCasalDOMINIO();

                if (grauParentesco == (int)GrauParentesco.CONJUGE)
                    return 0;

                //if (grauParentesco == (int)GrauParentesco.FILHO && idade <= 24)
                //    return 0;

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

        #region [ SelecionarPlanoCasalFuneral ]

        public TPlanoCasalDOMINIO SelecionarPlanoCasalFuneral(decimal coberturaMorte, decimal coberturaConjuge, int codigoPlano)
        {         
            StringBuilder queryTabelaPlanoCasal = new StringBuilder();

            queryTabelaPlanoCasal.Append(@" SELECT   IDPlanoCasal          ");
            queryTabelaPlanoCasal.Append(@"        , Codigo                ");
            queryTabelaPlanoCasal.Append(@"        , NomePlano             ");
            queryTabelaPlanoCasal.Append(@"        , CoberturaMorte        ");
            queryTabelaPlanoCasal.Append(@"        , CoberturaConjuge      ");
            queryTabelaPlanoCasal.Append(@"        , Premio_61_65          ");
            queryTabelaPlanoCasal.Append(@"        , Premio_66_70          ");
            queryTabelaPlanoCasal.Append(@"        , Premio_71_75          ");
            queryTabelaPlanoCasal.Append(@"        , Premio_76_80          ");
            queryTabelaPlanoCasal.Append(@"  FROM  TPlanoCasal             ");
            queryTabelaPlanoCasal.Append(@" WHERE  Codigo = " + codigoPlano + " ");
            queryTabelaPlanoCasal.Append(@"   AND  CoberturaMorte  = " + coberturaMorte.ToString().Replace(',', '.') + " ");
            //queryTabelaPlanoCasal.Append(@"   AND  CoberturaConjuge  = " + coberturaConjuge + " ");

            TPlanoCasalDOMINIO planoFuneral = new TPlanoCasalDOMINIO();

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoCasal.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable();
                dadosTable.Load(dados);
                if (dadosTable.Rows.Count > 0)
                    planoFuneral = MontarDominioTPlanoCasal(dadosTable.Rows[0]);
            }

            if (planoFuneral == null)
                return new TPlanoCasalDOMINIO();
            else
                return planoFuneral;
        }

        #endregion

        #region [ SelecionarPlanoPremioAgregado ]

        public TPlanoCasalDOMINIO SelecionarPlanoPremioAgregado(string nomePlano, int codigoFaixa)
        {
            StringBuilder queryTabelaPlanoCasal = new StringBuilder();

            queryTabelaPlanoCasal.Append(@" SELECT   IDPlanoCasalFuneral    ");
            queryTabelaPlanoCasal.Append(@"        , Codigo                 ");
            queryTabelaPlanoCasal.Append(@"        , Categoria              ");
            queryTabelaPlanoCasal.Append(@"        , Ate_20                 ");
            queryTabelaPlanoCasal.Append(@"        , De_21_40               ");
            queryTabelaPlanoCasal.Append(@"        , De_41_50               ");
            queryTabelaPlanoCasal.Append(@"        , De_51_60               ");
            queryTabelaPlanoCasal.Append(@"        , De_61_65               ");
            queryTabelaPlanoCasal.Append(@"        , De_66_70               ");
            queryTabelaPlanoCasal.Append(@"        , De_71_75               ");
            queryTabelaPlanoCasal.Append(@"        , De_76_80               ");
            queryTabelaPlanoCasal.Append(@"  FROM  TPlanoCasalFuneral       ");
            queryTabelaPlanoCasal.Append(@" WHERE  Categoria = '" + nomePlano + "' ");
            queryTabelaPlanoCasal.Append(@"   AND  Codigo  = " + codigoFaixa + " ");

            TPlanoCasalDOMINIO planoAgregado = new TPlanoCasalDOMINIO();

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoCasal.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable();
                dadosTable.Load(dados);
                if (dadosTable.Rows.Count > 0)
                    planoAgregado = MontarDominioTPlanoCasalFuneral(dadosTable.Rows[0]);
            }


            if (planoAgregado == null)
                return new TPlanoCasalDOMINIO();
            else
                return planoAgregado;
        }

        #endregion

        #region [ ConsultarPlanoCasalFuneral ]

        public DataTable ConsultarPlanoCasalFuneral(int faixaBase)
        {
            StringBuilder queryTabelaPlanoCasal = new StringBuilder();

            queryTabelaPlanoCasal.Append(@" SELECT   IDPlanoSenior         ");
            queryTabelaPlanoCasal.Append(@"        , NomePlano             ");
            queryTabelaPlanoCasal.Append(@"        , CoberturaMorte        ");
            queryTabelaPlanoCasal.Append(@"        , CoberturaConjuge      ");
            
            switch (faixaBase)
            {
                case (int)FaixaEtaria.PREMIO_61_65:
                    queryTabelaPlanoCasal.Append(@"        , Premio_61_65  AS PremioValor ");
                    queryTabelaPlanoCasal.Append(@"  FROM  TPlanoCasal                    ");
                    queryTabelaPlanoCasal.Append(@" WHERE  Premio_61_65 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_66_70:
                    queryTabelaPlanoCasal.Append(@"        , Premio_66_70  AS PremioValor ");
                    queryTabelaPlanoCasal.Append(@"  FROM  TPlanoCasal                    ");
                    queryTabelaPlanoCasal.Append(@" WHERE  Premio_66_70 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_71_75:
                    queryTabelaPlanoCasal.Append(@"        , Premio_71_75  AS PremioValor ");
                    queryTabelaPlanoCasal.Append(@"  FROM  TPlanoCasal                    ");
                    queryTabelaPlanoCasal.Append(@" WHERE  Premio_71_75 IS NOT NULL       ");
                    break;
                case (int)FaixaEtaria.PREMIO_76_80:
                    queryTabelaPlanoCasal.Append(@"        , Premio_76_80  AS PremioValor ");
                    queryTabelaPlanoCasal.Append(@"  FROM  TPlanoCasal                    ");
                    queryTabelaPlanoCasal.Append(@" WHERE  Premio_76_80 IS NOT NULL       ");
                    break;
                default:
                    queryTabelaPlanoCasal.Append(@"  FROM  TPlanoCasal                    ");
                    break;
            }


            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                SqlCeCommand command = new SqlCeCommand(queryTabelaPlanoCasal.ToString(), conn);
                SqlCeDataReader dados = command.ExecuteReader();
                DataTable dadosTable = new DataTable("Planos");
                dadosTable.Load(dados);

                return dadosTable;
            }
        }

        #endregion

        #region [ ConsultarPlanoCasalAgregado ]

        public DataTable ConsultarPlanoCasalAgregado()
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
            queryFaixa20_40.Append(@"  FROM  TPlanoCasalFuneral       ");
            queryFaixa20_40.Append(@" WHERE  Ate_20 IS NOT NULL       ");
            queryFaixa20_40.Append(@"   AND  De_21_40 IS NOT NULL     ");
            queryFaixa20_40.Append(@" GROUP BY Categoria              ");
            queryFaixa20_40.Append(@" ORDER BY Categoria              ");

            StringBuilder queryFaixa41_60 = new StringBuilder();

            queryFaixa41_60.Append(@" SELECT   Categoria              ");
            queryFaixa41_60.Append(@"        , SUM(De_41_50) AS Val_1 ");
            queryFaixa41_60.Append(@"        , SUM(De_51_60) AS Val_2 ");
            queryFaixa41_60.Append(@"  FROM  TPlanoCasalFuneral       ");
            queryFaixa41_60.Append(@" WHERE  De_41_50 IS NOT NULL     ");
            queryFaixa41_60.Append(@"   AND  De_51_60 IS NOT NULL     ");
            queryFaixa41_60.Append(@" GROUP BY Categoria              ");
            queryFaixa41_60.Append(@" ORDER BY Categoria              ");

            StringBuilder queryFaixa61_70 = new StringBuilder();

            queryFaixa61_70.Append(@" SELECT   Categoria              ");
            queryFaixa61_70.Append(@"        , SUM(De_61_65) AS Val_1 ");
            queryFaixa61_70.Append(@"        , SUM(De_66_70) AS Val_2 ");
            queryFaixa61_70.Append(@"  FROM  TPlanoCasalFuneral       ");
            queryFaixa61_70.Append(@" WHERE  De_61_65 IS NOT NULL     ");
            queryFaixa61_70.Append(@"   AND  De_66_70 IS NOT NULL     ");
            queryFaixa61_70.Append(@" GROUP BY Categoria              ");
            queryFaixa61_70.Append(@" ORDER BY Categoria              ");

            StringBuilder queryFaixa71_80 = new StringBuilder();

            queryFaixa71_80.Append(@" SELECT   Categoria              ");
            queryFaixa71_80.Append(@"        , SUM(De_71_75) AS Val_1 ");
            queryFaixa71_80.Append(@"        , SUM(De_76_80) AS Val_2 ");
            queryFaixa71_80.Append(@"  FROM  TPlanoCasalFuneral       ");
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

        #endregion
    }
}
