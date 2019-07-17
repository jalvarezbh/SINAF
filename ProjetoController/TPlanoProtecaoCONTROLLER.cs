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
    public class TPlanoProtecaoCONTROLLER
    {
        #region [ BLL ]

        private TPlanoProtecaoBLL _TPlanoProtecaoBLL;

        public TPlanoProtecaoBLL TPlanoProtecaoBLL
        {
            get
            {
                if (_TPlanoProtecaoBLL == null)
                    _TPlanoProtecaoBLL = new TPlanoProtecaoBLL();

                return _TPlanoProtecaoBLL;

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

                #region [ Importar Tabela TPlanoProtecao ]

                DataSet dadosExcelTPlanoProtecao = new DataSet();

                using (OleDbDataAdapter command = new OleDbDataAdapter("select * from [Plano$]", connection))
                {
                    command.Fill(dadosExcelTPlanoProtecao);
                }

                if (dadosExcelTPlanoProtecao != null)
                {
                    if (dadosExcelTPlanoProtecao.Tables.Count > 0)
                    {
                        if (dadosExcelTPlanoProtecao.Tables[0].Rows.Count > 0)
                        {
                            Int32 verificaExisteRegistro = string.IsNullOrEmpty(dadosExcelTPlanoProtecao.Tables[0].Rows[0]["Código Plano"].ToString()) ? 0 : Convert.ToInt32(dadosExcelTPlanoProtecao.Tables[0].Rows[0]["Código Plano"].ToString().Replace(".", ","));

                            if (verificaExisteRegistro != 0)
                            {
                                //Excluir TPlanoProtecao
                                TPlanoProtecaoBLL.ExcluirTodosPlanoProtecao();

                                foreach (DataRow item in dadosExcelTPlanoProtecao.Tables[0].Rows)
                                {
                                    TPlanoProtecaoVO dadosVO = new TPlanoProtecaoVO();

                                    dadosVO.Codigo = string.IsNullOrEmpty(item["Código Plano"].ToString()) ? 0 : Convert.ToInt32(item["Código Plano"].ToString().Replace(".", ","));
                                    dadosVO.NomePlano = item["Nome Plano"].ToString();
                                    dadosVO.CoberturaMorte = Convert.ToDecimal(item["Cobertura Morte Acidental"].ToString().Replace(".", ","));
                                    dadosVO.CoberturaAcidente = Convert.ToDecimal(item["Cobertura Invalidez por Acidente"].ToString().Replace(".", ","));
                                    dadosVO.CoberturaEmergencia = Convert.ToDecimal(item["Cobertura Assistência Emergencial"].ToString().Replace(".", ","));
                                    dadosVO.Premio_18_30 = string.IsNullOrEmpty(item["Prêmio 18-30"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 18-30"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosVO.Premio_31_40 = string.IsNullOrEmpty(item["Prêmio 31-40"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 31-40"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosVO.Premio_41_45 = string.IsNullOrEmpty(item["Prêmio 41-45"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 41-45"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosVO.Premio_46_50 = string.IsNullOrEmpty(item["Prêmio 46-50"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 46-50"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosVO.Premio_51_55 = string.IsNullOrEmpty(item["Prêmio 51-55"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 51-55"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosVO.Premio_56_60 = string.IsNullOrEmpty(item["Prêmio 56-60"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 56-60"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosVO.Premio_61_65 = string.IsNullOrEmpty(item["Prêmio 61-65"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 61-65"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));

                                    if (dadosVO.Codigo != 0)
                                        TPlanoProtecaoBLL.InserirPlanoProtecao(dadosVO);
                                }
                            }
                        }
                    }
                }

                #endregion

                #region [ Importar Tabela TPlanoProtecaoFuneral ]

                DataSet dadosExcelTPlanoProtecaoFuneral = new DataSet();

                using (OleDbDataAdapter command = new OleDbDataAdapter("select * from [Funeral$]", connection))
                {
                    command.Fill(dadosExcelTPlanoProtecaoFuneral);
                }

                if (dadosExcelTPlanoProtecaoFuneral != null)
                {
                    if (dadosExcelTPlanoProtecaoFuneral.Tables.Count > 0)
                    {
                        if (dadosExcelTPlanoProtecaoFuneral.Tables[0].Rows.Count > 0)
                        {
                            Int32 verificaExisteRegistroFuneral = string.IsNullOrEmpty(dadosExcelTPlanoProtecaoFuneral.Tables[0].Rows[0]["Código"].ToString()) ? 0 : Convert.ToInt32(dadosExcelTPlanoProtecaoFuneral.Tables[0].Rows[0]["Código"].ToString().Replace(".", ","));

                            if (verificaExisteRegistroFuneral != 0)
                            {
                                //Excluir TPlanoProtecaoFuneral
                                TPlanoProtecaoBLL.ExcluirTodosPlanoProtecaoFuneral();

                                foreach (DataRow item in dadosExcelTPlanoProtecaoFuneral.Tables[0].Rows)
                                {
                                    TPlanoProtecaoVO dadosFuneralVO = new TPlanoProtecaoVO();

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
                                        TPlanoProtecaoBLL.InserirPlanoProtecaoFuneral(dadosFuneralVO);
                                }
                            }
                        }
                    }
                }

                #endregion

                #region [ Importar Tabela TPlanoProtecaoRenda ]

                DataSet dadosExcelTPlanoProtecaoRenda = new DataSet();

                using (OleDbDataAdapter command = new OleDbDataAdapter("select * from [Renda$]", connection))
                {
                    command.Fill(dadosExcelTPlanoProtecaoRenda);
                }


                if (dadosExcelTPlanoProtecaoRenda != null)
                {
                    if (dadosExcelTPlanoProtecaoRenda.Tables.Count > 0)
                    {
                        if (dadosExcelTPlanoProtecaoRenda.Tables[0].Rows.Count > 0)
                        {

                            string verificaExisteRegistroRenda = dadosExcelTPlanoProtecaoRenda.Tables[0].Rows[0]["Renda Período"].ToString();

                            if (!string.IsNullOrEmpty(verificaExisteRegistroRenda))
                            {
                                //Excluir TPlanoProtecaoRenda
                                TPlanoProtecaoBLL.ExcluirTodosPlanoProtecaoRenda();

                                foreach (DataRow item in dadosExcelTPlanoProtecaoRenda.Tables[0].Rows)
                                {
                                    TPlanoProtecaoVO dadosRendaVO = new TPlanoProtecaoVO();

                                    dadosRendaVO.RendaPeriodo = item["Renda Período"].ToString();
                                    dadosRendaVO.RendaCoberturaRendaMensal = Convert.ToDecimal(item["Cobertura Morte Renda Mensal"].ToString().Replace(".", ","));
                                    dadosRendaVO.RendaCoberturaCapitalTotal = Convert.ToDecimal(item["Cobertura Morte Capital Total"].ToString().Replace(".", ","));
                                    dadosRendaVO.RendaPremio_18_30 = string.IsNullOrEmpty(item["Prêmio 18-30"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 18-30"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosRendaVO.RendaPremio_31_40 = string.IsNullOrEmpty(item["Prêmio 31-40"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 31-40"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosRendaVO.RendaPremio_41_45 = string.IsNullOrEmpty(item["Prêmio 41-45"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 41-45"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosRendaVO.RendaPremio_46_50 = string.IsNullOrEmpty(item["Prêmio 46-50"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 46-50"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosRendaVO.RendaPremio_51_55 = string.IsNullOrEmpty(item["Prêmio 51-55"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 51-55"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosRendaVO.RendaPremio_56_60 = string.IsNullOrEmpty(item["Prêmio 56-60"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 56-60"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));
                                    dadosRendaVO.RendaPremio_61_65 = string.IsNullOrEmpty(item["Prêmio 61-65"].ToString()) ? DecimalNulo : Convert.ToDecimal(item["Prêmio 61-65"].ToString().Replace(".", ","), new CultureInfo("pt-BR"));

                                    if (!string.IsNullOrEmpty(dadosRendaVO.RendaPeriodo))
                                        TPlanoProtecaoBLL.InserirPlanoProtecaoRenda(dadosRendaVO);
                                }
                            }
                        }
                    }
                }

                #endregion

            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Importar Arquivo Plano Proteção Familia.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Importar Arquivo Plano Proteção Familia.");
            }
        }

        #endregion

        #region [ ConsultaCategoriaSuperior ]

        public TPlanoProtecaoVO ConsultaCategoriaSuperior(int faixaPadaro, decimal valorPremioAP)
        {
            try
            {
                return TPlanoProtecaoBLL.SelecionarPlanoCategoriaSuperior(faixaPadaro, valorPremioAP);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Consultar Plano Proteção Familia Categoria Superior.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Consultar Plano Proteção Familia Categoria Superior.");
            }
        }

        #endregion

        #region [ ListarTodosMorteAcidental ]

        public Dictionary<decimal, string> ListarTodosMorteAcidental(bool itemVazio, int idadeBase)
        {
      
            try
            {
                Dictionary<decimal, string> dadosRetornados = TPlanoProtecaoBLL.ListarTodosMorteAcidental();

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
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Valores de Morte Acidental.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Valores de Morte Acidental.");
            }
        }

        #endregion

        #region [ ListarTodosInvalidezAcidente ]

        public Dictionary<decimal, string> ListarTodosInvalidezAcidente(bool itemVazio, int idadeBase)
        {
      
            try
            {
                Dictionary<decimal, string> dadosRetornados = TPlanoProtecaoBLL.ListarTodosInvalidezAcidente();

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
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Valores de Invalidez por Acidente.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Valores de Invalidez por Acidente.");
            }
        }

        #endregion

        #region [ ListarTodosAssisteciaEmergencial ]

        public Dictionary<decimal, string> ListarTodosAssisteciaEmergencial(bool itemVazio)
        {

            try
            {
                Dictionary<decimal, string> dadosRetornados = TPlanoProtecaoBLL.ListarTodosAssisteciaEmergencial();

                if (itemVazio)
                {
                    dadosRetornados.Add(0, string.Empty);
                    dadosRetornados = dadosRetornados.OrderBy(order => order.Key).ToDictionary(registro => registro.Key, registro => registro.Value);
                }

                return dadosRetornados;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Valores de Assistência Emergencial.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Valores de Assistência Emergencial.");
            }
        }

        #endregion

        #region [ ListarTodosFuneralCategoria ]

        public Dictionary<int, string> ListarTodosFuneralCategoria(bool itemVazio)
        {
      
            try
            {
                Dictionary<int, string> dadosRetornados = TPlanoProtecaoBLL.ListarTodosFuneralCategoria();

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

        #region [ ListarTodosRendaValor ]

        public Dictionary<decimal, string> ListarTodosRendaValor(bool itemVazio, int rendaPeriodo, int idadeBase)
        {

            try
            {
                Dictionary<decimal, string> dadosRetornados = TPlanoProtecaoBLL.ListarTodosRendaValor();
              
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

                if (itemVazio)
                {
                    dadosRetornados.Add(0, string.Empty);
                    dadosRetornados = dadosRetornados.OrderBy(order => order.Key).ToDictionary(registro => registro.Key, registro => registro.Value);
                }

                return dadosRetornados;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Valores de Cobertura Renda Mensal.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Valores de Cobertura Renda Mensal.");
            }
        }

        #endregion

        #region [ ListarTodosRendaPeriodo ]

        public Dictionary<int, string> ListarTodosRendaPeriodo(bool itemVazio)
        {

            try
            {
                Dictionary<int, string> dadosRetornados = TPlanoProtecaoBLL.ListarTodosRendaPeriodo();

                if (itemVazio)
                {
                    dadosRetornados.Add(0, string.Empty);
                    dadosRetornados = dadosRetornados.OrderBy(order => order.Key).ToDictionary(registro => registro.Key, registro => registro.Value);
                }

                return dadosRetornados;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Valores de Período.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Valores de Período.");
            }
        }

        #endregion

        #region [ CalcularPremioFuneral ]

        public TPlanoProtecaoVO CalcularPremioFuneral(decimal valorMorteNovo, decimal valorIPANovo, decimal valorAssistenciaNovo, int valorCategoriaNovo, int idadeBase)
        {

            try
            {
                TPlanoProtecaoVO planoFuneral = TPlanoProtecaoBLL.SelecionarPlanoProtecaoFuneral(valorMorteNovo, valorIPANovo, valorAssistenciaNovo, valorCategoriaNovo);

                if (planoFuneral == null)
                    return new TPlanoProtecaoVO();

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
                TPlanoProtecaoVO planoAgregado = new TPlanoProtecaoVO();

                if (grauParentesco == (int)GrauParentesco.CONJUGE)
                    return 0;

                if (grauParentesco == (int)GrauParentesco.FILHO && idade < 25)
                    return 0;

                if (idade <= 40)
                {
                    planoAgregado = TPlanoProtecaoBLL.SelecionarPlanoPremioAgregado(valorCategoria, 1);
                    if (idade <= 20)
                        return planoAgregado.FuneralAte_20.GetValueOrDefault();
                    else
                        return planoAgregado.FuneralDe_21_40.GetValueOrDefault();
                }
                else
                {
                    if (idade <= 60)
                    {
                        planoAgregado = TPlanoProtecaoBLL.SelecionarPlanoPremioAgregado(valorCategoria, 2);
                        if (idade <= 50)
                            return planoAgregado.FuneralDe_41_50.GetValueOrDefault();
                        else
                            return planoAgregado.FuneralDe_51_60.GetValueOrDefault();
                    }
                    else
                    {
                        if (idade <= 70)
                        {
                            planoAgregado = TPlanoProtecaoBLL.SelecionarPlanoPremioAgregado(valorCategoria, 3);
                            if (idade <= 65)
                                return planoAgregado.FuneralDe_61_65.GetValueOrDefault();
                            else
                                return planoAgregado.FuneralDe_66_70.GetValueOrDefault();
                        }
                        else
                        {
                            planoAgregado = TPlanoProtecaoBLL.SelecionarPlanoPremioAgregado(valorCategoria, 4);
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

        #region [ CalcularPremioRenda ]

        public TPlanoProtecaoVO CalcularPremioRenda(string periodoNovo, decimal valorRendaNovo, int idadeBase)
        {

            try
            {
                TPlanoProtecaoVO planoRenda = TPlanoProtecaoBLL.SelecionarPlanoProtecaoRenda(periodoNovo,valorRendaNovo);

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
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Calcular Prêmio da Renda.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Calcular Prêmio da Renda.");
            }
        }

        #endregion

        #endregion
      
    }
    
}
