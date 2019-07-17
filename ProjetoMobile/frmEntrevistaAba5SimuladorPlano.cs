using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol;
using ProjetoMobile.Dominio;
using ProjetoMobile.Persistencia;
using ProjetoMobile.Dominio.Enumeradores;
using System.Globalization;

namespace ProjetoMobile
{
    public partial class frmEntrevista
    {
        #region [ PROPERTIES ]

        private Dictionary<decimal, string> _dadosCmbAba5Sub1APMorte;
        public Dictionary<decimal, string> DadosCmbAba5Sub1APMorte
        {
            get { return _dadosCmbAba5Sub1APMorte; }
            set { _dadosCmbAba5Sub1APMorte = value; }
        }

        private string _textoCmbAba5Sub1APMorte;
        public string TextoCmbAba5Sub1APMorte
        {
            get { return _textoCmbAba5Sub1APMorte; }
            set { _textoCmbAba5Sub1APMorte = value; }
        }

        private Dictionary<decimal, string> _dadosCmbAba5Sub1APIPA;
        public Dictionary<decimal, string> DadosCmbAba5Sub1APIPA
        {
            get { return _dadosCmbAba5Sub1APIPA; }
            set { _dadosCmbAba5Sub1APIPA = value; }
        }

        private string _textoCmbAba5Sub1APIPA;
        public string TextoCmbAba5Sub1APIPA
        {
            get { return _textoCmbAba5Sub1APIPA; }
            set { _textoCmbAba5Sub1APIPA = value; }
        }

        private Dictionary<decimal, string> _dadosCmbAba5Sub1APAssistencia;
        public Dictionary<decimal, string> DadosCmbAba5Sub1APAssistencia
        {
            get { return _dadosCmbAba5Sub1APAssistencia; }
            set { _dadosCmbAba5Sub1APAssistencia = value; }
        }

        private string _textoCmbAba5Sub1APAssistencia;
        public string TextoCmbAba5Sub1APAssistencia
        {
            get { return _textoCmbAba5Sub1APAssistencia; }
            set { _textoCmbAba5Sub1APAssistencia = value; }
        }

        private Dictionary<int, string> _dadosCmbAba5Sub1APFuneral;
        public Dictionary<int, string> DadosCmbAba5Sub1APFuneral
        {
            get { return _dadosCmbAba5Sub1APFuneral; }
            set { _dadosCmbAba5Sub1APFuneral = value; }
        }

        private string _textoCmbAba5Sub1APFuneral;
        public string TextoCmbAba5Sub1APFuneral
        {
            get { return _textoCmbAba5Sub1APFuneral; }
            set { _textoCmbAba5Sub1APFuneral = value; }
        }

        private Dictionary<decimal, string> _dadosCmbAba5Sub1SeniorMorte;
        public Dictionary<decimal, string> DadosCmbAba5Sub1SeniorMorte
        {
            get { return _dadosCmbAba5Sub1SeniorMorte; }
            set { _dadosCmbAba5Sub1SeniorMorte = value; }
        }

        private string _textoCmbAba5Sub1SeniorMorte;
        public string TextoCmbAba5Sub1SeniorMorte
        {
            get { return _textoCmbAba5Sub1SeniorMorte; }
            set { _textoCmbAba5Sub1SeniorMorte = value; }
        }

        private Dictionary<int, string> _dadosCmbAba5Sub1SeniorFuneral;
        public Dictionary<int, string> DadosCmbAba5Sub1SeniorFuneral
        {
            get { return _dadosCmbAba5Sub1SeniorFuneral; }
            set { _dadosCmbAba5Sub1SeniorFuneral = value; }
        }

        private string _textoCmbAba5Sub1SeniorFuneral;
        public string TextoCmbAba5Sub1SeniorFuneral
        {
            get { return _textoCmbAba5Sub1SeniorFuneral; }
            set { _textoCmbAba5Sub1SeniorFuneral = value; }
        }

        private Dictionary<decimal, string> _dadosCmbAba5Sub1CasalMorte;
        public Dictionary<decimal, string> DadosCmbAba5Sub1CasalMorte
        {
            get { return _dadosCmbAba5Sub1CasalMorte; }
            set { _dadosCmbAba5Sub1CasalMorte = value; }
        }

        private string _textoCmbAba5Sub1CasalMorte;
        public string TextoCmbAba5Sub1CasalMorte
        {
            get { return _textoCmbAba5Sub1CasalMorte; }
            set { _textoCmbAba5Sub1CasalMorte = value; }
        }

        private Dictionary<decimal, string> _dadosCmbAba5Sub1CasalConjuge;
        public Dictionary<decimal, string> DadosCmbAba5Sub1CasalConjuge
        {
            get { return _dadosCmbAba5Sub1CasalConjuge; }
            set { _dadosCmbAba5Sub1CasalConjuge = value; }
        }

        private string _textoCmbAba5Sub1CasalConjuge;
        public string TextoCmbAba5Sub1CasalConjuge
        {
            get { return _textoCmbAba5Sub1CasalConjuge; }
            set { _textoCmbAba5Sub1CasalConjuge = value; }
        }

        private Dictionary<int, string> _dadosCmbAba5Sub1CasalFuneral;
        public Dictionary<int, string> DadosCmbAba5Sub1CasalFuneral
        {
            get { return _dadosCmbAba5Sub1CasalFuneral; }
            set { _dadosCmbAba5Sub1CasalFuneral = value; }
        }

        private string _textoCmbAba5Sub1CasalFuneral;
        public string TextoCmbAba5Sub1CasalFuneral
        {
            get { return _textoCmbAba5Sub1CasalFuneral; }
            set { _textoCmbAba5Sub1CasalFuneral = value; }
        }

        #endregion

        #region [ RECOVER ]

        private void PopularComboPlanoProtecao()
        {
            cmbAba5Sub1APMorte.DataSource = new BindingSource(ControllerPlanoProtecao.ListarTodosMorteAcidental(false, FaixaBase), null);
            cmbAba5Sub1APMorte.ValueMember = "Key";
            cmbAba5Sub1APMorte.DisplayMember = "Value";
            DadosCmbAba5Sub1APMorte = ControllerPlanoProtecao.ListarTodosMorteAcidental(false, FaixaBase);
            TextoCmbAba5Sub1APMorte = string.Empty;

            DadosCmbAba5Sub1APIPA = ControllerPlanoProtecao.ListarTodosInvalidezAcidente(false, FaixaBase);
            TextoCmbAba5Sub1APIPA = string.Empty;

            DadosCmbAba5Sub1APAssistencia = ControllerPlanoProtecao.ListarTodosAssisteciaEmergencial(false);
            TextoCmbAba5Sub1APAssistencia = string.Empty;

            cmbAba5Sub1APFuneral.DataSource = new BindingSource(ControllerPlanoProtecao.ListarTodosFuneralCategoria(false), null);
            cmbAba5Sub1APFuneral.ValueMember = "Key";
            cmbAba5Sub1APFuneral.DisplayMember = "Value";
            DadosCmbAba5Sub1APFuneral = ControllerPlanoProtecao.ListarTodosFuneralCategoria(false);
            TextoCmbAba5Sub1APFuneral = string.Empty;
        }

        private void PopularComboPlanoSenior()
        {
            cmbAba5Sub1SeniorMorte.DataSource = new BindingSource(ControllerPlanoSenior.ListarTodosFuneralPrincipal(false, FaixaBase), null);
            cmbAba5Sub1SeniorMorte.ValueMember = "Key";
            cmbAba5Sub1SeniorMorte.DisplayMember = "Value";
            DadosCmbAba5Sub1SeniorMorte = ControllerPlanoSenior.ListarTodosFuneralPrincipal(false, FaixaBase);
            TextoCmbAba5Sub1SeniorMorte = string.Empty;

            cmbAba5Sub1SeniorFuneral.DataSource = new BindingSource(ControllerPlanoSenior.ListarTodosFuneralCategoria(false), null);
            cmbAba5Sub1SeniorFuneral.ValueMember = "Key";
            cmbAba5Sub1SeniorFuneral.DisplayMember = "Value";
            DadosCmbAba5Sub1SeniorFuneral = ControllerPlanoSenior.ListarTodosFuneralCategoria(false);
            TextoCmbAba5Sub1SeniorFuneral = string.Empty;
        }

        private void PopularComboPlanoCasal()
        {
            DadosCmbAba5Sub1CasalConjuge = ControllerPlanoCasal.ListarTodosFuneralConjuge(false, FaixaBase);
            cmbAba5Sub1CasalMorte.DataSource = new BindingSource(ControllerPlanoCasal.ListarTodosFuneralPrincipal(false, FaixaBase), null);
            cmbAba5Sub1CasalMorte.ValueMember = "Key";
            cmbAba5Sub1CasalMorte.DisplayMember = "Value";
            DadosCmbAba5Sub1CasalMorte = ControllerPlanoCasal.ListarTodosFuneralPrincipal(false, FaixaBase);
            TextoCmbAba5Sub1CasalMorte = string.Empty;

            cmbAba5Sub1CasalFuneral.DataSource = new BindingSource(ControllerPlanoCasal.ListarTodosFuneralCategoria(false), null);
            cmbAba5Sub1CasalFuneral.ValueMember = "Key";
            cmbAba5Sub1CasalFuneral.DisplayMember = "Value";
            DadosCmbAba5Sub1CasalFuneral = ControllerPlanoCasal.ListarTodosFuneralCategoria(false);
            TextoCmbAba5Sub1CasalFuneral = string.Empty;
        }

        private void PreencherDominoAbaSimuladorSubPlanos()
        {
            #region [ PROTECAO ]

            DataTable tableTFuneral = ControllerSimuladorSubFuneral.SelecioneSimuladorSubFuneral(DadosTSimuladorProduto.IDSimuladorProduto);

            if (DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOPROTECAO.GetStringValue()))
            {
                DadosTPlanoProtecao.NomePlano = cmbAba5Sub1APFuneral.Text;

                if (tableTFuneral.Rows.Count > 0)
                {
                    DadosTPlanoProtecao.CoberturaMorte = !string.IsNullOrEmpty(tableTFuneral.Rows[0]["ProtecaoCoberturaMorte"].ToString()) ? Convert.ToDecimal(tableTFuneral.Rows[0]["ProtecaoCoberturaMorte"]) : 0;
                    DadosTPlanoProtecao.CoberturaAcidente = !string.IsNullOrEmpty(tableTFuneral.Rows[0]["ProtecaoCoberturaAcidente"].ToString()) ? Convert.ToDecimal(tableTFuneral.Rows[0]["ProtecaoCoberturaAcidente"]) : 0;
                    DadosTPlanoProtecao.CoberturaEmergencia = !string.IsNullOrEmpty(tableTFuneral.Rows[0]["ProtecaoCoberturaEmergencia"].ToString()) ? Convert.ToDecimal(tableTFuneral.Rows[0]["ProtecaoCoberturaEmergencia"]) : 0;
                    DadosTPlanoProtecao.NomePlano = tableTFuneral.Rows[0]["ProtecaoCategoria"].ToString();
                    DadosTPlanoProtecao.ValorPremioIdadeBase = !string.IsNullOrEmpty(tableTFuneral.Rows[0]["ProtecaoPremio"].ToString()) ? Convert.ToDecimal(tableTFuneral.Rows[0]["ProtecaoPremio"]) : 0;
                }
            }

            #endregion

            #region [ CASAL ]

            if (DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOCASAL.GetStringValue()))
            {
                DadosTPlanoCasal.NomePlano = cmbAba5Sub1CasalFuneral.Text;

                if (tableTFuneral.Rows.Count > 0)
                {
                    DadosTPlanoCasal.CoberturaMorte = !string.IsNullOrEmpty(tableTFuneral.Rows[0]["CasalCoberturaMorte"].ToString()) ? Convert.ToDecimal(tableTFuneral.Rows[0]["CasalCoberturaMorte"]) : 0;
                    DadosTPlanoCasal.CoberturaConjuge = !string.IsNullOrEmpty(tableTFuneral.Rows[0]["CasalCoberturaConjuge"].ToString()) ? Convert.ToDecimal(tableTFuneral.Rows[0]["CasalCoberturaConjuge"]) : 0;
                    DadosTPlanoCasal.NomePlano = tableTFuneral.Rows[0]["CasalCategoria"].ToString();
                    DadosTPlanoCasal.ValorPremioIdadeBase = !string.IsNullOrEmpty(tableTFuneral.Rows[0]["CasalPremio"].ToString()) ? Convert.ToDecimal(tableTFuneral.Rows[0]["CasalPremio"]) : 0;
                }
            }

            #endregion

            #region [ SENIOR ]

            if (DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOSENIOR.GetStringValue()))
            {
                DadosTPlanoSenior.NomePlano = cmbAba5Sub1SeniorFuneral.Text;

                if (tableTFuneral.Rows.Count > 0)
                {
                    DadosTPlanoSenior.CoberturaMorte = !string.IsNullOrEmpty(tableTFuneral.Rows[0]["SeniorCoberturaMorte"].ToString()) ? Convert.ToDecimal(tableTFuneral.Rows[0]["SeniorCoberturaMorte"]) : 0;
                    DadosTPlanoSenior.NomePlano = tableTFuneral.Rows[0]["SeniorCategoria"].ToString();
                    DadosTPlanoSenior.ValorPremioIdadeBase = !string.IsNullOrEmpty(tableTFuneral.Rows[0]["SeniorPremio"].ToString()) ? Convert.ToDecimal(tableTFuneral.Rows[0]["SeniorPremio"]) : 0;
                }
            }

            #endregion
        }

        private void PreencherCamposSimuladorAbaPlanos()
        {
            if (DadosTPlanoProtecao.IDPlanoProtecao > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOPROTECAO.GetStringValue()))
            {
                DadosTSimuladorProduto.Produto = ProdutoPrincipal.PLANOPROTECAO.GetStringValue();
                ProdutoCalculo = (int)ProdutoPrincipal.PLANOPROTECAO;
                pPlanoProtecao.Height = 225;
                pPlanoProtecao.Visible = true;
                pPlanoSenior.Visible = false;
                pPlanoCasal.Visible = false;
                PopularComboPlanoProtecao();

                cmbAba5Sub1APMorte.SelectedValue = DadosTPlanoProtecao.CoberturaMorte;
                lblAba5Sub1APIPAValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoProtecao.CoberturaAcidente);
                lblAba5Sub1APAssistenciaValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoProtecao.CoberturaEmergencia);

                cmbAba5Sub1APFuneral.Text = DadosTPlanoProtecao.NomePlano;

                PremioPlano = DadosTPlanoProtecao.ValorPremioIdadeBase.GetValueOrDefault();

                if (tabControlSimulador.TabPages.IndexOf(tabRenda) == -1)
                    tabControlSimulador.TabPages.Insert(2, tabRenda);

                cmbAba5Sub1APMorte.Focus();
            }

            if (DadosTPlanoSenior.IDPlanoSenior > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOSENIOR.GetStringValue()))
            {
                DadosTSimuladorProduto.Produto = ProdutoPrincipal.PLANOSENIOR.GetStringValue();
                ProdutoCalculo = (int)ProdutoPrincipal.PLANOSENIOR;
                pPlanoSenior.Height = 225;
                pPlanoProtecao.Visible = false;
                pPlanoSenior.Visible = true;
                pPlanoCasal.Visible = false;
                PopularComboPlanoSenior();

                cmbAba5Sub1SeniorMorte.SelectedValue = DadosTPlanoSenior.CoberturaMorte;
                cmbAba5Sub1SeniorFuneral.Text = DadosTPlanoSenior.NomePlano;

                PremioPlano = DadosTPlanoSenior.ValorPremioIdadeBase.GetValueOrDefault();

                if (tabControlSimulador.TabPages.IndexOf(tabRenda) > -1)
                    tabControlSimulador.TabPages.RemoveAt(tabControlSimulador.TabPages.IndexOf(tabRenda));

                cmbAba5Sub1SeniorMorte.Focus();

            }

            if (DadosTPlanoCasal.IDPlanoCasal > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOCASAL.GetStringValue()))
            {
                DadosTSimuladorProduto.Produto = ProdutoPrincipal.PLANOCASAL.GetStringValue();
                ProdutoCalculo = (int)ProdutoPrincipal.PLANOCASAL;
                pPlanoCasal.Height = 225;
                pPlanoProtecao.Visible = false;
                pPlanoSenior.Visible = false;
                pPlanoCasal.Visible = true;
                PopularComboPlanoCasal();

                cmbAba5Sub1CasalMorte.SelectedValue = DadosTPlanoCasal.CoberturaMorte;
                lblAba5Sub1CasalConjugeValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoCasal.CoberturaConjuge);

                cmbAba5Sub1CasalFuneral.Text = DadosTPlanoCasal.NomePlano;

                PremioPlano = DadosTPlanoCasal.ValorPremioIdadeBase.GetValueOrDefault();

                if (tabControlSimulador.TabPages.IndexOf(tabRenda) > -1)
                    tabControlSimulador.TabPages.RemoveAt(tabControlSimulador.TabPages.IndexOf(tabRenda));

                cmbAba5Sub1CasalMorte.Focus();
            }
        }

        #endregion

        #region [ FILL ]

        private void MapearCamposAbaProdutoSubAbaPlanos()
        {
            DadosTSimuladorProduto = new TSimuladorProdutoDOMINIO();

            DadosTSimuladorSubFuneral = new TSimuladorSubFuneralDOMINIO();

            DadosTSimuladorProduto.IDEntrevista = DadosTEntrevista.CodigoEntrevista;

            DadosTSimuladorProduto.PremioTotal = PremioTotal;

            DadosTSimuladorProduto.FaixaEtaria = DadosTEntrevistado.FaixaEtaria;

            DadosTSimuladorProduto.FaixaEtariaConjuge = DadosTEntrevistado.FaixaEtariaConjuge;

            DadosTSimuladorProduto.RespostaBaseRenda = Resposta2;

            DadosTSimuladorProduto.RespostaBaseDisposto = Resposta7;

            DadosTSimuladorProduto.TipoRegistro = TipoRegistro;

            switch (ProdutoCalculo)
            {
                case (int)ProdutoPrincipal.PLANOPROTECAO:

                    DadosTSimuladorProduto.Produto = ProdutoPrincipal.PLANOPROTECAO.GetStringValue();

                    DadosTSimuladorSubFuneral.ProtecaoCoberturaMorte = Convert.ToDecimal(cmbAba5Sub1APMorte.SelectedValue);

                    lblAba5Sub1APIPAValor.Text = lblAba5Sub1APIPAValor.Text.Replace(" ", "");

                    if (lblAba5Sub1APIPAValor.Text.Contains(","))
                        lblAba5Sub1APIPAValor.Text = lblAba5Sub1APIPAValor.Text.Replace(".", "").Replace(",", ".");

                    if (lblAba5Sub1APIPAValor.Text.Contains("R"))
                        DadosTSimuladorSubFuneral.ProtecaoCoberturaAcidente = Convert.ToDecimal(lblAba5Sub1APIPAValor.Text.Remove(0, 2));
                    else
                        DadosTSimuladorSubFuneral.ProtecaoCoberturaAcidente = Convert.ToDecimal(lblAba5Sub1APIPAValor.Text);

                    lblAba5Sub1APAssistenciaValor.Text = lblAba5Sub1APAssistenciaValor.Text.Replace(" ", "");

                    if (lblAba5Sub1APAssistenciaValor.Text.Contains(","))
                        lblAba5Sub1APAssistenciaValor.Text = lblAba5Sub1APAssistenciaValor.Text.Replace(".", "").Replace(",", ".");

                    if (lblAba5Sub1APAssistenciaValor.Text.Contains("R"))
                        DadosTSimuladorSubFuneral.ProtecaoCoberturaEmergencia = Convert.ToDecimal(lblAba5Sub1APAssistenciaValor.Text.Remove(0, 2));
                    else
                        DadosTSimuladorSubFuneral.ProtecaoCoberturaEmergencia = Convert.ToDecimal(lblAba5Sub1APAssistenciaValor.Text);

                    DadosTSimuladorSubFuneral.ProtecaoCategoria = cmbAba5Sub1APFuneral.Text;

                    DadosTSimuladorSubFuneral.ProtecaoPremio = PremioPlano;

                    break;
                case (int)ProdutoPrincipal.PLANOSENIOR:

                    DadosTSimuladorProduto.Produto = ProdutoPrincipal.PLANOSENIOR.GetStringValue();

                    DadosTSimuladorSubFuneral.SeniorCoberturaMorte = Convert.ToDecimal(cmbAba5Sub1SeniorMorte.SelectedValue);

                    DadosTSimuladorSubFuneral.SeniorCategoria = cmbAba5Sub1SeniorFuneral.Text;

                    DadosTSimuladorSubFuneral.SeniorPremio = PremioPlano;

                    break;
                case (int)ProdutoPrincipal.PLANOCASAL:

                    DadosTSimuladorProduto.Produto = ProdutoPrincipal.PLANOCASAL.GetStringValue();

                    DadosTSimuladorSubFuneral.CasalCoberturaMorte = Convert.ToDecimal(cmbAba5Sub1CasalMorte.SelectedValue);

                    if (lblAba5Sub1CasalConjugeValor.Text.Contains("R"))
                        DadosTSimuladorSubFuneral.CasalCoberturaConjuge = Convert.ToDecimal(lblAba5Sub1CasalConjugeValor.Text.Remove(0, 2).Replace(".", "").Replace(",", "."));
                    else
                        DadosTSimuladorSubFuneral.CasalCoberturaConjuge = Convert.ToDecimal(lblAba5Sub1CasalConjugeValor.Text.Replace(".", "").Replace(",", "."));

                    DadosTSimuladorSubFuneral.CasalCategoria = cmbAba5Sub1CasalFuneral.Text;

                    DadosTSimuladorSubFuneral.CasalPremio = PremioPlano;

                    break;
                default:
                    break;
            }

        }

        private void VerificaPlanoProtecaoFuneral()
        {
            try
            {
                Decimal morte = Convert.ToDecimal(cmbAba5Sub1APMorte.SelectedValue);
                Int32 funeral = Convert.ToInt32(cmbAba5Sub1APFuneral.SelectedValue);

                lblAba5Sub1APIPAValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", cmbAba5Sub1APMorte.SelectedValue);

                DadosTPlanoProtecaoNovo = ControllerPlanoProtecao.CalcularPremioFuneral(morte, 0, 0, funeral, FaixaBase);
                PremioPlano = DadosTPlanoProtecaoNovo.ValorPremioIdadeBase.GetValueOrDefault();
                lblAba5Sub1PremioPlanoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoProtecaoNovo.ValorPremioIdadeBase.GetValueOrDefault());
                lblAba5Sub1PremioAgregadoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioAgregado);
                lblAba5Sub1PremioRendaValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioRenda);
                lblAba5Sub1PremioTotalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoProtecaoNovo.ValorPremioIdadeBase.GetValueOrDefault() + PremioAgregado + PremioRenda);
            }
            catch
            {
            }
        }

        private void VerificaPlanoCasalFuneral()
        {
            try
            {
                Decimal morte = Convert.ToDecimal(cmbAba5Sub1CasalMorte.SelectedValue);
                Int32 funeral = Convert.ToInt32(cmbAba5Sub1CasalFuneral.SelectedValue);

                lblAba5Sub1CasalConjugeValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosCmbAba5Sub1CasalConjuge.Values.ElementAt(cmbAba5Sub1CasalMorte.SelectedIndex));

                DadosTPlanoCasalNovo = ControllerPlanoCasal.CalcularPremioFuneral(Convert.ToDecimal(cmbAba5Sub1CasalMorte.SelectedValue), 0, Convert.ToInt32(cmbAba5Sub1CasalFuneral.SelectedValue), FaixaBase);
                PremioPlano = DadosTPlanoCasalNovo.ValorPremioIdadeBase.GetValueOrDefault();
                lblAba5Sub1PremioPlanoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoCasalNovo.ValorPremioIdadeBase.GetValueOrDefault());
                lblAba5Sub1PremioAgregadoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioAgregado);
                lblAba5Sub1PremioRendaValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioRenda);
                lblAba5Sub1PremioTotalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoCasalNovo.ValorPremioIdadeBase.GetValueOrDefault() + PremioAgregado + PremioRenda);
            }
            catch
            {
            }
        }

        private void VerificaPlanoSeniorFuneral()
        {
            try
            {
                Decimal morte = Convert.ToDecimal(cmbAba5Sub1SeniorMorte.SelectedValue);
                Int32 funeral = Convert.ToInt32(cmbAba5Sub1SeniorFuneral.SelectedValue);

                if (!string.IsNullOrEmpty(cmbAba5Sub1SeniorMorte.Text) && !string.IsNullOrEmpty(cmbAba5Sub1SeniorFuneral.Text))
                {
                    DadosTPlanoSeniorNovo = ControllerPlanoSenior.CalcularPremioFuneral(Convert.ToDecimal(cmbAba5Sub1SeniorMorte.SelectedValue), Convert.ToInt32(cmbAba5Sub1SeniorFuneral.SelectedValue), FaixaBase);
                    PremioPlano = DadosTPlanoSeniorNovo.ValorPremioIdadeBase.GetValueOrDefault();
                    lblAba5Sub1PremioPlanoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoSeniorNovo.ValorPremioIdadeBase.GetValueOrDefault());
                    lblAba5Sub1PremioAgregadoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioAgregado);
                    lblAba5Sub1PremioRendaValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioRenda);
                    lblAba5Sub1PremioTotalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoSeniorNovo.ValorPremioIdadeBase.GetValueOrDefault() + PremioAgregado + PremioRenda);
                }
            }
            catch
            {
            }
        }

        #endregion

        #region [ CONTROLS ]

        #region [ Plano Protecao ]

        private void cmbAba5Sub1APMorte_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub1APMorte = string.Empty;
        }

        private void cmbAba5Sub1APMorte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub1APMorte = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba5Sub1APMorte;

            if (e.KeyChar != 13)
                TextoCmbAba5Sub1APMorte += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<decimal, string> verificaCombo = DadosCmbAba5Sub1APMorte.Where(registro => registro.Value.Contains(TextoCmbAba5Sub1APMorte)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub1APMorte = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub1APMorte_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificaPlanoProtecaoFuneral();
        }

        private void cmbAba5Sub1APFuneral_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub1APFuneral = string.Empty;
        }

        private void cmbAba5Sub1APFuneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub1APFuneral = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba5Sub1APFuneral;

            if (e.KeyChar != 13)
                TextoCmbAba5Sub1APFuneral += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<int, string> verificaCombo = DadosCmbAba5Sub1APFuneral.Where(registro => registro.Value.Contains(TextoCmbAba5Sub1APFuneral)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub1APFuneral = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub1APFuneral_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAba5Sub1Voltar.Focus();
                e.Handled = true;
            }
        }

        private void cmbAba5Sub1APFuneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificaPlanoProtecaoFuneral();
        }

        #endregion

        #region [ Plano Casal ]

        private void cmbAba5Sub1CasalMorte_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub1CasalMorte = string.Empty;
        }

        private void cmbAba5Sub1CasalMorte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub1CasalMorte = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba5Sub1CasalMorte;
            TextoCmbAba5Sub1CasalMorte += e.KeyChar.ToString();

            if (e.KeyChar != 13)
                TextoCmbAba5Sub1CasalMorte += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<decimal, string> verificaCombo = DadosCmbAba5Sub1CasalMorte.Where(registro => registro.Value.Contains(TextoCmbAba5Sub1CasalMorte)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub1CasalMorte = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub1CasalMorte_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificaPlanoCasalFuneral();
        }

        private void cmbAba5Sub1CasalFuneral_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub1CasalFuneral = string.Empty;
        }

        private void cmbAba5Sub1CasalFuneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub1CasalFuneral = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba5Sub1CasalFuneral;

            if (e.KeyChar != 13)
                TextoCmbAba5Sub1CasalFuneral += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<int, string> verificaCombo = DadosCmbAba5Sub1CasalFuneral.Where(registro => registro.Value.Contains(TextoCmbAba5Sub1CasalFuneral)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub1CasalFuneral = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub1CasalFuneral_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAba5Sub1Voltar.Focus();
                e.Handled = true;
            }
        }

        private void cmbAba5Sub1CasalFuneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificaPlanoCasalFuneral();
        }

        #endregion

        #region [ Plano Senior ]

        private void cmbAba5Sub1SeniorMorte_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub1SeniorMorte = string.Empty;
        }

        private void cmbAba5Sub1SeniorMorte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub1SeniorMorte = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba5Sub1SeniorMorte;

            if (e.KeyChar != 13)
                TextoCmbAba5Sub1SeniorMorte += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<decimal, string> verificaCombo = DadosCmbAba5Sub1SeniorMorte.Where(registro => registro.Value.Contains(TextoCmbAba5Sub1SeniorMorte)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub1SeniorMorte = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub1SeniorMorte_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificaPlanoSeniorFuneral();
        }

        private void cmbAba5Sub1SeniorFuneral_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub1SeniorFuneral = string.Empty;
        }

        private void cmbAba5Sub1SeniorFuneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub1SeniorFuneral = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba5Sub1SeniorFuneral;

            if (e.KeyChar != 13)
                TextoCmbAba5Sub1SeniorFuneral += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<int, string> verificaCombo = DadosCmbAba5Sub1SeniorFuneral.Where(registro => registro.Value.Contains(TextoCmbAba5Sub1SeniorFuneral)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub1SeniorFuneral = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub1SeniorFuneral_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAba5Sub1Voltar.Focus();
                e.Handled = true;
            }
        }

        private void cmbAba5Sub1SeniorFuneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificaPlanoSeniorFuneral();
        }

        #endregion

        #region [ Buttons ]

        private void btnAba5Sub1Voltar_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);
            switch (ProdutoCalculo)
            {
                case (int)ProdutoPrincipal.PLANOPROTECAO:
                    cmbAba5Sub1APMorte.Focus();
                    break;
                case (int)ProdutoPrincipal.PLANOSENIOR:
                    cmbAba5Sub1SeniorMorte.Focus();
                    break;
                case (int)ProdutoPrincipal.PLANOCASAL:
                    cmbAba5Sub1CasalMorte.Focus();
                    break;
                default:
                    break;
            }

            PopularSimulador();

            Util.MostraCursor.CursorAguarde(false);
        }

        private void btnAba5Sub1Salvar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlSimulador.SelectedIndex = 1;
                e.Handled = true;
            }
        }

        private void btnAba5Sub1Salvar_Click(object sender, EventArgs e)
        {
            GravarSimulador = true;
        }

        #endregion

        #endregion              
    }
}
