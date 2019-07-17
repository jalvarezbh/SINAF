using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;
using System.Web;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Web.Configuration;
using System.Globalization;

namespace ProjetoController
{
    public class TPlanoCasalCONTROLLER
    {
        #region [ BLL ]

        private TPlanoCasalBLL _TPlanoCasalBLL;

        public TPlanoCasalBLL TPlanoCasalBLL
        {
            get
            {
                if (_TPlanoCasalBLL == null)
                    _TPlanoCasalBLL = new TPlanoCasalBLL();

                return _TPlanoCasalBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ ImportarArquivo ]

        public void ImportarArquivo(string keyNomeDiretorio, string nomeArquivo)
        {
            try
            {
                Decimal? DecimalNulo = null;
                string urlRepositorioArquivos = WebConfigurationManager.AppSettings[keyNomeDiretorio];

                string path = HttpContext.Current.Server.MapPath(urlRepositorioArquivos + "\\" + nomeArquivo);
                OleDbConnection connection = new OleDbConnection(WebConfigurationManager.AppSettings["ExcelCONNECT"].Replace("[path]", path).ToString());
                //OleDbConnection connection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=Excel 12.0;");

                #region [ Importar Tabela TPlanoCasal ]

                DataSet dadosExcelTPlanoCasal = new DataSet();

                using (OleDbDataAdapter command = new OleDbDataAdapter("select * from [Plano$]", connection))
                {
                    command.Fill(dadosExcelTPlanoCasal);
                }

                if (dadosExcelTPlanoCasal != null)
                {
                    if (dadosExcelTPlanoCasal.Tables.Count > 0)
                    {
                        if (dadosExcelTPlanoCasal.Tables[0].Rows.Count > 0)
                        {
                            Int32 verificaExisteRegistro = string.IsNullOrEmpty(dadosExcelTPlanoCasal.Tables[0].Rows[0]["Código Plano"].ToString()) ? 0 : Convert.ToInt32(dadosExcelTPlanoCasal.Tables[0].Rows[0]["Código Plano"].ToString().Replace(".", ","));

                            if (verificaExisteRegistro != 0)
                            {
                                //Excluir TPlanoCasal
                                TPlanoCasalBLL.ExcluirTodosPlanoCasal();

                                foreach (DataRow item in dadosExcelTPlanoCasal.Tables[0].Rows)
                                {
                                    TPlanoCasalVO dadosVO = new TPlanoCasalVO();

                                    dadosVO.Codigo = string.IsNullOrEmpty(item["Código Plano"].ToString()) ? 0 : Convert.ToInt32(item["Código Plano"].ToString().Replace(".", ","));
                                    dadosVO.NomePlano = item["Nome Plano"].ToString();
                                    dadosVO.CoberturaMorte = Convert.ToDecimal(item["Capital Segurado (R$) Morte Principal"].ToString().Replace(".", ","));
                                    dadosVO.CoberturaConjuge = Convert.ToDecimal(item["Capital Segurado (R$) Morte Cônjuge"].ToString().Replace(".", ","));
                                    dadosVO.Premio_61_65 = string.IsNullOrEmpty(item["Prêmio 61-65"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 61-65"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosVO.Premio_66_70 = string.IsNullOrEmpty(item["Prêmio 66-70"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 66-70"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosVO.Premio_71_75 = string.IsNullOrEmpty(item["Prêmio 71-75"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 71-75"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosVO.Premio_76_80 = string.IsNullOrEmpty(item["Prêmio 76-80"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 76-80"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));

                                    if (dadosVO.Codigo != 0)
                                        TPlanoCasalBLL.InserirPlanoCasal(dadosVO);
                                }
                            }
                        }
                    }
                }

                #endregion

                #region [ Importar Tabela TPlanoCasalFuneral ]

                DataSet dadosExcelTPlanoCasalFuneral = new DataSet();

                using (OleDbDataAdapter command = new OleDbDataAdapter("select * from [Funeral$]", connection))
                {
                    command.Fill(dadosExcelTPlanoCasalFuneral);
                }

                if (dadosExcelTPlanoCasalFuneral != null)
                {
                    if (dadosExcelTPlanoCasalFuneral.Tables.Count > 0)
                    {
                        if (dadosExcelTPlanoCasalFuneral.Tables[0].Rows.Count > 0)
                        {
                            Int32 verificaExisteRegistroFuneral = string.IsNullOrEmpty(dadosExcelTPlanoCasalFuneral.Tables[0].Rows[0]["Código"].ToString()) ? 0 : Convert.ToInt32(dadosExcelTPlanoCasalFuneral.Tables[0].Rows[0]["Código"].ToString().Replace(".", ","));

                            if (verificaExisteRegistroFuneral != 0)
                            {
                                //Excluir TPlanoCasalFuneral
                                TPlanoCasalBLL.ExcluirTodosPlanoCasalFuneral();

                                foreach (DataRow item in dadosExcelTPlanoCasalFuneral.Tables[0].Rows)
                                {
                                    TPlanoCasalVO dadosFuneralVO = new TPlanoCasalVO();

                                    dadosFuneralVO.FuneralCodigo = string.IsNullOrEmpty(item["Código"].ToString()) ? 0 : Convert.ToInt32(item["Código"].ToString().Replace(".", ","));
                                    dadosFuneralVO.FuneralCategoria = item["Categoria"].ToString();
                                    dadosFuneralVO.FuneralAte_20 = string.IsNullOrEmpty(item["Até 20"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Até 20"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosFuneralVO.FuneralDe_21_40 = string.IsNullOrEmpty(item["21-40"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["21-40"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosFuneralVO.FuneralDe_41_50 = string.IsNullOrEmpty(item["41-50"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["41-50"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosFuneralVO.FuneralDe_51_60 = string.IsNullOrEmpty(item["51-60"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["51-60"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosFuneralVO.FuneralDe_61_65 = string.IsNullOrEmpty(item["61-65"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["61-65"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosFuneralVO.FuneralDe_66_70 = string.IsNullOrEmpty(item["66-70"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["66-70"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosFuneralVO.FuneralDe_71_75 = string.IsNullOrEmpty(item["71-75"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["71-75"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosFuneralVO.FuneralDe_76_80 = string.IsNullOrEmpty(item["76-80"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["76-80"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));

                                    if (dadosFuneralVO.FuneralCodigo != 0)
                                        TPlanoCasalBLL.InserirPlanoCasalFuneral(dadosFuneralVO);
                                }
                            }
                        }
                    }
                }

                #endregion

            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Importar Arquivo Plano Casal.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Importar Arquivo Plano Casal.");
            }
        }

        #endregion

        #region [ ConsultaCategoriaSuperior ]

        public TPlanoCasalVO ConsultaCategoriaSuperior(int faixaPadaro, decimal valorPremioAP)
        {
            try
            {
                return TPlanoCasalBLL.SelecionarPlanoCategoriaSuperior(faixaPadaro, valorPremioAP);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Consultar Plano Sênior Casal Categoria Superior.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Consultar Plano Sênior Casal Categoria Superior.");
            }
        }

        #endregion

        #region [ ListarTodosFuneralPrincipal ]

        public Dictionary<decimal, string> ListarTodosFuneralPrincipal(bool itemVazio, int idadeBase)
        {

            try
            {
                Dictionary<decimal, string> dadosRetornados = TPlanoCasalBLL.ListarTodosFuneralPrincipal();

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
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Valores de Cobertura Morte Principal.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Valores de Cobertura Morte Principal.");
            }
        }

        #endregion

        #region [ ListarTodosFuneralConjuge ]

        public Dictionary<decimal, string> ListarTodosFuneralConjuge(bool itemVazio, int idadeBase)
        {

            try
            {
                Dictionary<decimal, string> dadosRetornados = TPlanoCasalBLL.ListarTodosFuneralConjuge();

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
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Valores de Cobertura Morte Cônjuge.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Valores de Cobertura Morte Cônjuge.");
            }
        }

        #endregion

        #region [ ListarTodosFuneralCategoria ]

        public Dictionary<int, string> ListarTodosFuneralCategoria(bool itemVazio)
        {

            try
            {
                Dictionary<int, string> dadosRetornados = TPlanoCasalBLL.ListarTodosFuneralCategoria();

                if (itemVazio)
                {
                    dadosRetornados.Add(0, string.Empty);
                    dadosRetornados = dadosRetornados.OrderBy(order => order.Key).ToDictionary(registro => registro.Key, registro => registro.Value);
                }

                return dadosRetornados;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Valores de Categoria do Funeral.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Valores de Categoria do Funeral.");
            }
        }

        #endregion

        #region [ CalcularPremioFuneral ]

        public TPlanoCasalVO CalcularPremioFuneral(decimal valorPrincipalNovo, decimal valorConjugeNovo, int valorCategoriaNovo, int idadeBase)
        {

            try
            {
                TPlanoCasalVO planoFuneral = TPlanoCasalBLL.SelecionarPlanoCasalFuneral(valorPrincipalNovo, valorConjugeNovo, valorCategoriaNovo);

                if (planoFuneral == null)
                    return new TPlanoCasalVO();


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
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Calcular Prêmio do Funeral.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Calcular Prêmio do Funeral.");
            }
        }

        #endregion

        #region [ CalcularPremioAgregado ]

        public decimal CalcularPremioAgregado(int grauParentesco, int idade, string valorCategoria)
        {

            try
            {
                TPlanoCasalVO planoAgregado = new TPlanoCasalVO();

                if (grauParentesco == (int)GrauParentesco.CONJUGE)
                    return 0;

                if (grauParentesco == (int)GrauParentesco.FILHO && idade < 25)
                    return 0;

                if (idade <= 40)
                {
                    planoAgregado = TPlanoCasalBLL.SelecionarPlanoPremioAgregado(valorCategoria, 1);
                    if (idade <= 20)
                        return planoAgregado.FuneralAte_20.GetValueOrDefault();
                    else
                        return planoAgregado.FuneralDe_21_40.GetValueOrDefault();
                }
                else
                {
                    if (idade <= 60)
                    {
                        planoAgregado = TPlanoCasalBLL.SelecionarPlanoPremioAgregado(valorCategoria, 2);
                        if (idade <= 50)
                            return planoAgregado.FuneralDe_41_50.GetValueOrDefault();
                        else
                            return planoAgregado.FuneralDe_51_60.GetValueOrDefault();
                    }
                    else
                    {
                        if (idade <= 70)
                        {
                            planoAgregado = TPlanoCasalBLL.SelecionarPlanoPremioAgregado(valorCategoria, 3);
                            if (idade <= 65)
                                return planoAgregado.FuneralDe_61_65.GetValueOrDefault();
                            else
                                return planoAgregado.FuneralDe_66_70.GetValueOrDefault();
                        }
                        else
                        {
                            planoAgregado = TPlanoCasalBLL.SelecionarPlanoPremioAgregado(valorCategoria, 4);
                            if (idade <= 75)
                                return planoAgregado.FuneralDe_71_75.GetValueOrDefault();
                            else
                                return planoAgregado.FuneralDe_76_80.GetValueOrDefault();
                        }
                    }
                }

            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Calcular Prêmio do Agregado.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Calcular Prêmio do Agregado.");
            }
        }

        #endregion

        #endregion
    }
}
