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

        private DataTable _dadosCmbAba5Sub5Sub1Produto;
        public DataTable DadosCmbAba5Sub5Sub1Produto
        {
            get { return _dadosCmbAba5Sub5Sub1Produto; }
            set { _dadosCmbAba5Sub5Sub1Produto = value; }
        }

        private string _textoCmbAba5Sub5Sub1Produto;
        public string TextoCmbAba5Sub5Sub1Produto
        {
            get { return _textoCmbAba5Sub5Sub1Produto; }
            set { _textoCmbAba5Sub5Sub1Produto = value; }
        }

        private DataTable _dadosCmbAba5Sub5Sub1FaixaBase;
        public DataTable DadosCmbAba5Sub5Sub1FaixaBase
        {
            get { return _dadosCmbAba5Sub5Sub1FaixaBase; }
            set { _dadosCmbAba5Sub5Sub1FaixaBase = value; }
        }

        private string _textoCmbAba5Sub5Sub1FaixaBase;
        public string TextoCmbAba5Sub5Sub1FaixaBase
        {
            get { return _textoCmbAba5Sub5Sub1FaixaBase; }
            set { _textoCmbAba5Sub5Sub1FaixaBase = value; }
        }

        private Dictionary<decimal, string> _dadosCmbAba5Sub5Sub2Morte;
        public Dictionary<decimal, string> DadosCmbAba5Sub5Sub2Morte
        {
            get { return _dadosCmbAba5Sub5Sub2Morte; }
            set { _dadosCmbAba5Sub5Sub2Morte = value; }
        }

        private string _textoCmbAba5Sub5Sub2Morte;
        public string TextoCmbAba5Sub5Sub2Morte
        {
            get { return _textoCmbAba5Sub5Sub2Morte; }
            set { _textoCmbAba5Sub5Sub2Morte = value; }
        }

        private Dictionary<int, string> _dadosCmbAba5Sub5Sub2Funeral;
        public Dictionary<int, string> DadosCmbAba5Sub5Sub2Funeral
        {
            get { return _dadosCmbAba5Sub5Sub2Funeral; }
            set { _dadosCmbAba5Sub5Sub2Funeral = value; }
        }

        private string _textoCmbAba5Sub5Sub2Funeral;
        public string TextoCmbAba5Sub5Sub2Funeral
        {
            get { return _textoCmbAba5Sub5Sub2Funeral; }
            set { _textoCmbAba5Sub5Sub2Funeral = value; }
        }

        private Dictionary<decimal, string> _dadosCmbAba5Sub5Sub2IPA;
        public Dictionary<decimal, string> DadosCmbAba5Sub5Sub2IPA
        {
            get { return _dadosCmbAba5Sub5Sub2IPA; }
            set { _dadosCmbAba5Sub5Sub2IPA = value; }
        }

        private string _textoCmbAba5Sub5Sub2IPA;
        public string TextoCmbAba5Sub5Sub2IPA
        {
            get { return _textoCmbAba5Sub5Sub2IPA; }
            set { _textoCmbAba5Sub5Sub2IPA = value; }
        }

        private Dictionary<decimal, string> _dadosCmbAba5Sub5Sub2AssistOUConj;
        public Dictionary<decimal, string> DadosCmbAba5Sub5Sub2AssistOUConj
        {
            get { return _dadosCmbAba5Sub5Sub2AssistOUConj; }
            set { _dadosCmbAba5Sub5Sub2AssistOUConj = value; }
        }

        private string _textoCmbAba5Sub5Sub2AssistOUConj;
        public string TextoCmbAba5Sub5Sub2AssistOUConj
        {
            get { return _textoCmbAba5Sub5Sub2AssistOUConj; }
            set { _textoCmbAba5Sub5Sub2AssistOUConj = value; }
        }

        private DataTable _dadosCmbAba5Sub5Sub3Parentesco;
        public DataTable DadosCmbAba5Sub5Sub3Parentesco
        {
            get { return _dadosCmbAba5Sub5Sub3Parentesco; }
            set { _dadosCmbAba5Sub5Sub3Parentesco = value; }
        }

        private string _textoCmbAba5Sub5Sub3Parentesco;
        public string TextoCmbAba5Sub5Sub3Parentesco
        {
            get { return _textoCmbAba5Sub5Sub3Parentesco; }
            set { _textoCmbAba5Sub5Sub3Parentesco = value; }
        }

        private Dictionary<int, string> _dadosCmbAba5Sub5Sub3Funeral;
        public Dictionary<int, string> DadosCmbAba5Sub5Sub3Funeral
        {
            get { return _dadosCmbAba5Sub5Sub3Funeral; }
            set { _dadosCmbAba5Sub5Sub3Funeral = value; }
        }

        private string _textoCmbAba5Sub5Sub3Funeral;
        public string TextoCmbAba5Sub5Sub3Funeral
        {
            get { return _textoCmbAba5Sub5Sub3Funeral; }
            set { _textoCmbAba5Sub5Sub3Funeral = value; }
        }

        private List<decimal> _premioAgregadoTabelas;
        public List<decimal> PremioAgregadoTabelas
        {
            get
            {
                if (_premioAgregadoTabelas != null)
                    return _premioAgregadoTabelas;
                else
                    return new List<decimal>();
            }
            set { _premioAgregadoTabelas = value; }
        }

        private Dictionary<int, string> _dadosCmbAba5Sub5Sub4Periodo;
        public Dictionary<int, string> DadosCmbAba5Sub5Sub4Periodo
        {
            get { return _dadosCmbAba5Sub5Sub4Periodo; }
            set { _dadosCmbAba5Sub5Sub4Periodo = value; }
        }

        private string _textoCmbAba5Sub5Sub4Periodo;
        public string TextoCmbAba5Sub5Sub4Periodo
        {
            get { return _textoCmbAba5Sub5Sub4Periodo; }
            set { _textoCmbAba5Sub5Sub4Periodo = value; }
        }

        private Dictionary<decimal, string> _dadosCmbAba5Sub5Sub4Valor;
        public Dictionary<decimal, string> DadosCmbAba5Sub5Sub4Valor
        {
            get { return _dadosCmbAba5Sub5Sub4Valor; }
            set { _dadosCmbAba5Sub5Sub4Valor = value; }
        }

        private string _textoCmbAba5Sub5Sub4Valor;
        public string TextoCmbAba5Sub5Sub4Valor
        {
            get { return _textoCmbAba5Sub5Sub4Valor; }
            set { _textoCmbAba5Sub5Sub4Valor = value; }
        }

        #endregion

        #region [ RECOVER ]

        private void PopularSimuladorAbaTabelas()
        {
            DataTable dtProduto = new DataTable();
            DataColumn dcValor = new DataColumn("Key");
            DataColumn dcTexto = new DataColumn("Value");

            dtProduto.Columns.Add(dcValor);
            dtProduto.Columns.Add(dcTexto);

            DataRow drItems = dtProduto.NewRow();
            drItems = dtProduto.NewRow();
            drItems["Key"] = 0;
            drItems["Value"] = string.Empty;
            dtProduto.Rows.Add(drItems);

            drItems = dtProduto.NewRow();
            drItems["Key"] = (int)ProdutoPrincipal.PLANOPROTECAO;
            drItems["Value"] = ProdutoPrincipal.PLANOPROTECAO.GetStringValue();
            dtProduto.Rows.Add(drItems);

            drItems = dtProduto.NewRow();
            drItems["Key"] = (int)ProdutoPrincipal.PLANOSENIOR;
            drItems["Value"] = ProdutoPrincipal.PLANOSENIOR.GetStringValue();
            dtProduto.Rows.Add(drItems);

            drItems = dtProduto.NewRow();
            drItems["Key"] = (int)ProdutoPrincipal.PLANOCASAL;
            drItems["Value"] = ProdutoPrincipal.PLANOCASAL.GetStringValue();
            dtProduto.Rows.Add(drItems);

            cmbAba5Sub5Sub1Produto.ValueMember = "Key";
            cmbAba5Sub5Sub1Produto.DisplayMember = "Value";
            cmbAba5Sub5Sub1Produto.DataSource = dtProduto;
            DadosCmbAba5Sub5Sub1Produto = dtProduto;
            TextoCmbAba5Sub5Sub1Produto = string.Empty;
            cmbAba5Sub5Sub1Produto.Focus();
        }

        private void PopularSimuladorAbaTabelasFaixaBase(int produto)
        {
            cmbAba5Sub5Sub1FaixaBase.DisplayMember = "Value";
            cmbAba5Sub5Sub1FaixaBase.ValueMember = "Key";
            cmbAba5Sub5Sub1FaixaBase.DataSource = ControllerEnum.ListaDeFaixaEtaria(produto);
            cmbAba5Sub5Sub1FaixaBase.SelectedIndex = 0;
            DadosCmbAba5Sub5Sub1FaixaBase = ControllerEnum.ListaDeFaixaEtaria(produto);
            TextoCmbAba5Sub5Sub1FaixaBase = string.Empty;
        }
               
        private void PopularSimuladorAbaTabelasSubPlano()
        {

            if (Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) == (int)ProdutoPrincipal.PLANOPROTECAO)
                PopularSimuladorAbaTabelasComboPlanoProtecao();

            if (Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) == (int)ProdutoPrincipal.PLANOSENIOR)
                PopularSimuladorAbaTabelasComboPlanoSenior();

            if (Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) == (int)ProdutoPrincipal.PLANOCASAL)
                PopularSimuladorAbaTabelasComboPlanoCasal();

            lblAba5Sub5Sub2PremioPlanoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);
        }

        private void PopularSimuladorAbaTabelasComboPlanoProtecao()
        {
            lblAba5Sub5Sub2Produto.Text = ProdutoPrincipal.PLANOPROTECAO.GetStringValue();
            lblAba5Sub5Sub3Produto.Text = ProdutoPrincipal.PLANOPROTECAO.GetStringValue();
            lblAba5Sub5Sub4Produto.Text = ProdutoPrincipal.PLANOPROTECAO.GetStringValue();

            cmbAba5Sub5Sub2Morte.DataSource = new BindingSource(ControllerPlanoProtecao.ListarTodosMorteAcidental(true, Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue)), null);
            cmbAba5Sub5Sub2Morte.ValueMember = "Key";
            cmbAba5Sub5Sub2Morte.DisplayMember = "Value";
            DadosCmbAba5Sub5Sub2Morte = ControllerPlanoProtecao.ListarTodosMorteAcidental(true, Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue));
            TextoCmbAba5Sub5Sub2Morte = string.Empty;

            DadosCmbAba5Sub5Sub2IPA = ControllerPlanoProtecao.ListarTodosInvalidezAcidente(true, Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue));
            TextoCmbAba5Sub5Sub2IPA = string.Empty;

            DadosCmbAba5Sub5Sub2AssistOUConj = ControllerPlanoProtecao.ListarTodosAssisteciaEmergencial(true);
            TextoCmbAba5Sub5Sub2AssistOUConj = string.Empty;

            cmbAba5Sub5Sub2Funeral.DataSource = new BindingSource(ControllerPlanoProtecao.ListarTodosFuneralCategoria(true), null);
            cmbAba5Sub5Sub2Funeral.ValueMember = "Key";
            cmbAba5Sub5Sub2Funeral.DisplayMember = "Value";
            DadosCmbAba5Sub5Sub2Funeral = ControllerPlanoProtecao.ListarTodosFuneralCategoria(true);
            TextoCmbAba5Sub5Sub2Funeral = string.Empty;

            lblAba5Sub5Sub2AssistOUConj.Visible = true;
            lblAba5Sub5Sub2AssistOUConj.Text = "Assist. Emerg :";
            lblAba5Sub5Sub2AssistOUConj.Width = 200;
            lblAba5Sub5Sub2AssistOUConjValor.Visible = true;
            lblAba5Sub5Sub2AssistOUConjValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);

            lblAba5Sub5Sub2IPA.Visible = true;
            lblAba5Sub5Sub2IPA.Text = "Inv. Acidental :";
            lblAba5Sub5Sub2IPAValor.Visible = true;
            lblAba5Sub5Sub2IPAValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);

        }

        private void PopularSimuladorAbaTabelasComboPlanoSenior()
        {
            lblAba5Sub5Sub2Produto.Text = ProdutoPrincipal.PLANOSENIOR.GetStringValue();
            lblAba5Sub5Sub3Produto.Text = ProdutoPrincipal.PLANOSENIOR.GetStringValue();
            lblAba5Sub5Sub4Produto.Text = ProdutoPrincipal.PLANOSENIOR.GetStringValue();

            cmbAba5Sub5Sub2Morte.DataSource = new BindingSource(ControllerPlanoSenior.ListarTodosFuneralPrincipal(true, Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue)), null);
            cmbAba5Sub5Sub2Morte.ValueMember = "Key";
            cmbAba5Sub5Sub2Morte.DisplayMember = "Value";
            DadosCmbAba5Sub5Sub2Morte = ControllerPlanoSenior.ListarTodosFuneralPrincipal(true, Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue));
            TextoCmbAba5Sub5Sub2Morte = string.Empty;

            cmbAba5Sub5Sub2Funeral.DataSource = new BindingSource(ControllerPlanoSenior.ListarTodosFuneralCategoria(true), null);
            cmbAba5Sub5Sub2Funeral.ValueMember = "Key";
            cmbAba5Sub5Sub2Funeral.DisplayMember = "Value";
            DadosCmbAba5Sub5Sub2Funeral = ControllerPlanoSenior.ListarTodosFuneralCategoria(true);
            TextoCmbAba5Sub5Sub2Funeral = string.Empty;

            lblAba5Sub5Sub2AssistOUConj.Visible = false;
            lblAba5Sub5Sub2AssistOUConjValor.Visible = false;
            lblAba5Sub5Sub2AssistOUConj.Width = 200;

            lblAba5Sub5Sub2IPA.Visible = false;
            lblAba5Sub5Sub2IPAValor.Visible = false;
        }

        private void PopularSimuladorAbaTabelasComboPlanoCasal()
        {
            lblAba5Sub5Sub2Produto.Text = ProdutoPrincipal.PLANOCASAL.GetStringValue();
            lblAba5Sub5Sub3Produto.Text = ProdutoPrincipal.PLANOCASAL.GetStringValue();
            lblAba5Sub5Sub4Produto.Text = ProdutoPrincipal.PLANOCASAL.GetStringValue();

            cmbAba5Sub5Sub2Morte.DataSource = new BindingSource(ControllerPlanoCasal.ListarTodosFuneralPrincipal(true, Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue)), null);
            cmbAba5Sub5Sub2Morte.ValueMember = "Key";
            cmbAba5Sub5Sub2Morte.DisplayMember = "Value";
            DadosCmbAba5Sub5Sub2Morte = ControllerPlanoCasal.ListarTodosFuneralPrincipal(true, Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue));
            TextoCmbAba5Sub5Sub2Morte = string.Empty;

            cmbAba5Sub5Sub2Funeral.DataSource = new BindingSource(ControllerPlanoCasal.ListarTodosFuneralCategoria(true), null);
            cmbAba5Sub5Sub2Funeral.ValueMember = "Key";
            cmbAba5Sub5Sub2Funeral.DisplayMember = "Value";
            DadosCmbAba5Sub5Sub2Funeral = ControllerPlanoCasal.ListarTodosFuneralCategoria(true);
            TextoCmbAba5Sub5Sub2Funeral = string.Empty;

            lblAba5Sub5Sub2AssistOUConj.Visible = true;
            lblAba5Sub5Sub2AssistOUConj.Text = "Capital Segurado Cônjuge :";
            lblAba5Sub5Sub2AssistOUConj.Width = 350;
            lblAba5Sub5Sub2AssistOUConjValor.Visible = true;
            lblAba5Sub5Sub2AssistOUConjValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);

            lblAba5Sub5Sub2IPA.Visible = false;
            lblAba5Sub5Sub2IPAValor.Visible = false;
        }

        private void PopularSimuladorAbaTabelasSubAgregado()
        {
            cmbAba5Sub5Sub3Parentesco.DisplayMember = "Value";
            cmbAba5Sub5Sub3Parentesco.ValueMember = "Key";
            bool plano = Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) == (int)ProdutoPrincipal.PLANOSENIOR;
            cmbAba5Sub5Sub3Parentesco.DataSource = ControllerEnum.ListaDeParentesco(plano, true);
            DadosCmbAba5Sub5Sub3Parentesco = ControllerEnum.ListaDeParentesco(plano, true);
            TextoCmbAba5Sub5Sub3Parentesco = string.Empty;

            cmbAba5Sub5Sub3Funeral.DataSource = new BindingSource(ControllerPlanoProtecao.ListarTodosFuneralCategoria(true), null);
            cmbAba5Sub5Sub3Funeral.ValueMember = "Key";
            cmbAba5Sub5Sub3Funeral.DisplayMember = "Value";
            DadosCmbAba5Sub5Sub3Funeral = ControllerPlanoProtecao.ListarTodosFuneralCategoria(true);
            TextoCmbAba5Sub5Sub3Funeral = string.Empty;

            lblAba5Sub5Sub3PremioAgregadoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);
            lstAba5Sub5Sub3Agregado.Items.Clear();
            lblAba5Sub5Sub3QuantidadeValor.Text = "0";

            txtAba5Sub5Sub3Idade.Text = string.Empty;
       }

        private void PopularSimuladorAbaTabelasSubRenda()
        {
            cmbAba5Sub5Sub4Periodo.DataSource = new BindingSource(ControllerPlanoProtecao.ListarTodosRendaPeriodo(true), null);
            cmbAba5Sub5Sub4Periodo.ValueMember = "Key";
            cmbAba5Sub5Sub4Periodo.DisplayMember = "Value";
            DadosCmbAba5Sub5Sub4Periodo = ControllerPlanoProtecao.ListarTodosRendaPeriodo(true);
            TextoCmbAba5Sub5Sub4Periodo = string.Empty;
            cmbAba5Sub5Sub4Valor.DataSource = null;
            lblAba5Sub5Sub4CapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);
            lblAba5Sub5Sub4PremioRendaValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);
        }

        private void PopularSimuladorAbaTabelasSubRendaValor()
        {
            cmbAba5Sub5Sub4Valor.DataSource = new BindingSource(ControllerPlanoProtecao.ListarTodosRendaValor(true, Convert.ToInt32(cmbAba5Sub5Sub4Periodo.SelectedValue), Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue)), null);
            cmbAba5Sub5Sub4Valor.ValueMember = "Key";
            cmbAba5Sub5Sub4Valor.DisplayMember = "Value";
            DadosCmbAba5Sub5Sub4Valor = ControllerPlanoProtecao.ListarTodosRendaValor(true, Convert.ToInt32(cmbAba5Sub5Sub4Periodo.SelectedValue), Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue));
            TextoCmbAba5Sub5Sub4Valor = string.Empty;
        }

        private void PreencherCamposSimuladorAbaTabelas()
        {
            PopularSimuladorAbaTabelas();     
        }

        private void PreencherSimuladorAbaTabelasSubPlano()
        {

            if (Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) == (int)ProdutoPrincipal.PLANOPROTECAO &&
                cmbAba5Sub5Sub2Morte.SelectedIndex > 0 && cmbAba5Sub5Sub2Funeral.SelectedIndex > 0)
            {
                TPlanoProtecaoDOMINIO registro = ControllerPlanoProtecao.CalcularPremioFuneral(Convert.ToDecimal(cmbAba5Sub5Sub2Morte.SelectedValue), 0, 0, Convert.ToInt32(cmbAba5Sub5Sub2Funeral.SelectedValue), Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue));

                lblAba5Sub5Sub2AssistOUConjValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", registro.CoberturaAcidente);
                lblAba5Sub5Sub2IPAValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", registro.CoberturaEmergencia);
                lblAba5Sub5Sub2PremioPlanoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", registro.ValorPremioIdadeBase.GetValueOrDefault());
            }

            if (Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) == (int)ProdutoPrincipal.PLANOSENIOR &&
                cmbAba5Sub5Sub2Morte.SelectedIndex > 0 && cmbAba5Sub5Sub2Funeral.SelectedIndex > 0)
            {
                TPlanoSeniorDOMINIO registro = ControllerPlanoSenior.CalcularPremioFuneral(Convert.ToDecimal(cmbAba5Sub5Sub2Morte.SelectedValue), Convert.ToInt32(cmbAba5Sub5Sub2Funeral.SelectedValue), Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue));

                lblAba5Sub5Sub2PremioPlanoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", registro.ValorPremioIdadeBase.GetValueOrDefault());
            }

            if (Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) == (int)ProdutoPrincipal.PLANOCASAL &&
                cmbAba5Sub5Sub2Morte.SelectedIndex > 0 && cmbAba5Sub5Sub2Funeral.SelectedIndex > 0)
            {
                TPlanoCasalDOMINIO registro = ControllerPlanoCasal.CalcularPremioFuneral(Convert.ToDecimal(cmbAba5Sub5Sub2Morte.SelectedValue), 0, Convert.ToInt32(cmbAba5Sub5Sub2Funeral.SelectedValue), Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue));

                lblAba5Sub5Sub2AssistOUConjValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", registro.CoberturaConjuge);
                lblAba5Sub5Sub2PremioPlanoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", registro.ValorPremioIdadeBase.GetValueOrDefault());
            }

        }

        private void PreencherSimuladorAbaTabelasSubRenda()
        {
            if (cmbAba5Sub5Sub4Periodo.SelectedIndex > 0 && cmbAba5Sub5Sub4Valor.SelectedIndex > 0)
            {
                TPlanoProtecaoDOMINIO registro = ControllerPlanoProtecao.CalcularPremioRenda(cmbAba5Sub5Sub4Periodo.Text, Convert.ToDecimal(cmbAba5Sub5Sub4Valor.SelectedValue), Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue));
                
                lblAba5Sub5Sub4CapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", registro.RendaCoberturaCapitalTotal);

                lblAba5Sub5Sub4PremioRendaValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", registro.RendaValorPremioIdadeBase.GetValueOrDefault()); ;
            }
        }

        #endregion

        #region [ FILL ]

        private void AcertarFocuSimuladorSubTabelas()
        {
            switch (tabControlTabelasSimulador.SelectedIndex)
            {
                case 0:
                    cmbAba5Sub5Sub1Produto.Focus();
                    SimuladorAbaTabelaAnterior = 0;
                    break;
                case 1:
                    cmbAba5Sub5Sub2Morte.Focus();
                    PopularSimuladorAbaTabelasSubPlano();
                    SimuladorAbaTabelaAnterior = 1;
                    break;
                case 2:
                    cmbAba5Sub5Sub3Parentesco.Focus();
                    PremioAgregadoTabelas = new List<decimal>();
                    PopularSimuladorAbaTabelasSubAgregado();
                    SimuladorAbaTabelaAnterior = 2;
                    break;
                case 3:
                    cmbAba5Sub5Sub4Periodo.Focus();
                    PopularSimuladorAbaTabelasSubRenda();
                    SimuladorAbaTabelaAnterior = 3;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region [ CONTROLS ]

        #region [ ABA 1 ]

        private void cmbAba5Sub5Sub1Produto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAba5Sub5Sub1Produto.SelectedIndex > 0)
            {                
                PopularSimuladorAbaTabelasFaixaBase(cmbAba5Sub5Sub1Produto.SelectedIndex);
                
                if (Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) == (int)ProdutoPrincipal.PLANOPROTECAO)
                {
                    if (!tabControlTabelasSimulador.TabPages.Contains(tabTabelaRenda))
                        tabControlTabelasSimulador.TabPages.Insert(3, tabTabelaRenda);
                }
                else
                {                   
                    if (tabControlTabelasSimulador.TabPages.Contains(tabTabelaRenda))
                    {
                        tabControlTabelasSimulador.TabPages.RemoveAt(tabControlTabelasSimulador.TabPages.IndexOf(tabTabelaRenda));                        
                        tabControlTabelasSimulador.SelectedIndex = 0;
                    }
                }
            }

        }

        private void cmbAba5Sub5Sub1Produto_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub5Sub1Produto = string.Empty;
        }

        private void cmbAba5Sub5Sub1Produto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub5Sub1Produto = string.Empty;
                e.Handled = true;
                return;
            }  

            string atual = TextoCmbAba5Sub5Sub1Produto;
            TextoCmbAba5Sub5Sub1Produto += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba5Sub5Sub1Produto.Select("Value LIKE '%" + TextoCmbAba5Sub5Sub1Produto + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba5Sub5Sub1Produto = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub5Sub1FaixaBase_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub5Sub1FaixaBase = string.Empty;
        }

        private void cmbAba5Sub5Sub1FaixaBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9 || e.KeyChar == 13)
            {
                TextoCmbAba5Sub5Sub1FaixaBase = string.Empty;
                e.Handled = true;
                return;
            }
                        
            string atual = TextoCmbAba5Sub5Sub1FaixaBase;
            TextoCmbAba5Sub5Sub1FaixaBase += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba5Sub5Sub1FaixaBase.Select("Value LIKE '" + TextoCmbAba5Sub5Sub1FaixaBase + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba5Sub5Sub1FaixaBase = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub5Sub1FaixaBase_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlTabelasSimulador.SelectedIndex = 1;
                e.Handled = true;
            }
        }

        #endregion

        #region [ ABA 2 ]

        private void cmbAba5Sub5Sub2Morte_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub5Sub2Morte = string.Empty;
        }

        private void cmbAba5Sub5Sub2Morte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub5Sub2Morte = string.Empty;
                e.Handled = true;
                return;
            }  

            string atual = TextoCmbAba5Sub5Sub2Morte;
            
            if (e.KeyChar != 13)
                TextoCmbAba5Sub5Sub2Morte += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<decimal, string> verificaCombo = DadosCmbAba5Sub5Sub2Morte.Where(registro => registro.Value.Contains(TextoCmbAba5Sub5Sub2Morte)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub5Sub2Morte = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub5Sub2Morte_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherSimuladorAbaTabelasSubPlano();
        }

        private void cmbAba5Sub5Sub2Funeral_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub5Sub2Funeral = string.Empty;
        }

        private void cmbAba5Sub5Sub2Funeral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub5Sub2Funeral = string.Empty;
                e.Handled = true;
                return;
            }  

            string atual = TextoCmbAba5Sub5Sub2Funeral;
           
            if (e.KeyChar != 13)
                TextoCmbAba5Sub5Sub2Funeral += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<int, string> verificaCombo = DadosCmbAba5Sub5Sub2Funeral.Where(registro => registro.Value.Contains(TextoCmbAba5Sub5Sub2Funeral)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub5Sub2Funeral = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub5Sub2Funeral_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherSimuladorAbaTabelasSubPlano();
        }

        private void cmbAba5Sub5Sub2Funeral_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlTabelasSimulador.SelectedIndex = 2;
                e.Handled = true;
            }
        }

        #endregion

        #region [ ABA 3 ]

        private void cmbAba5Sub5Sub3Parentesco_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub5Sub3Parentesco = string.Empty;
        }

        private void cmbAba5Sub5Sub3Parentesco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub5Sub3Parentesco = string.Empty;
                e.Handled = true;
                return;
            } 

            string atual = TextoCmbAba5Sub5Sub3Parentesco;
            TextoCmbAba5Sub5Sub3Parentesco += e.KeyChar.ToString();


            DataRow[] verificaCombo = DadosCmbAba5Sub5Sub3Parentesco.Select("Value LIKE '" + TextoCmbAba5Sub5Sub3Parentesco + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba5Sub5Sub3Parentesco = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub5Sub3Funeral_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            //TextoCmbAba5Sub5Sub3Funeral = string.Empty;
        }

        //private void cmbAba5Sub5Sub3Funeral_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
        //    {
        //        TextoCmbAba5Sub5Sub3Funeral = string.Empty;
        //        e.Handled = true;
        //        return;
        //    } 

        //    string atual = TextoCmbAba5Sub5Sub3Funeral;
           
        //    if (e.KeyChar != 13)
        //        TextoCmbAba5Sub5Sub3Funeral += e.KeyChar.ToString();
        //    else
        //    {
        //        e.Handled = true; return;
        //    }

        //    Dictionary<int, string> verificaCombo = DadosCmbAba5Sub5Sub3Funeral.Where(registro => registro.Value.Contains(TextoCmbAba5Sub5Sub3Funeral)).ToDictionary(registro => registro.Key, registro => registro.Value);
        //    if (verificaCombo.Count > 0)
        //    {
        //        ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
        //    }
        //    else
        //    {
        //        TextoCmbAba5Sub5Sub3Funeral = atual;
        //    }

        //    e.Handled = true;
        //}

        private void btnAba5Sub5Sub3Adicionar_Click(object sender, EventArgs e)
        {
            if (cmbAba5Sub5Sub3Parentesco.SelectedIndex > 0 && cmbAba5Sub5Sub3Funeral.SelectedIndex > 0 && !string.IsNullOrEmpty(txtAba5Sub5Sub3Idade.Text))
            {
                if ((Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) == (int)ProdutoPrincipal.PLANOSENIOR) &&
                    (Convert.ToInt32(cmbAba5Sub5Sub3Parentesco.SelectedValue) == (int)GrauParentesco.CONJUGE) &&
                    (Convert.ToInt32(txtAba5Sub5Sub3Idade.Text) >= 61))
                {
                    Util.CaixaMensagem.ExibirOk("O titular não poderá informar o cônjuge maior de 61 anos como agregado.");
                    return;
                }
                else if ((Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) == (int)ProdutoPrincipal.PLANOPROTECAO) && 
                    ((Convert.ToInt32(cmbAba5Sub5Sub3Parentesco.SelectedValue) == (int)GrauParentesco.FILHO) || (Convert.ToInt32(cmbAba5Sub5Sub3Parentesco.SelectedValue) == (int)GrauParentesco.ENTEADO)) &&
                    (Convert.ToInt32(txtAba5Sub5Sub3Idade.Text) <= 24))
                {
                    Util.CaixaMensagem.ExibirOk("O titular não poderá informar o filho/enteado menor de 25 anos como agregado.");
                    return;
                }
                else if (Convert.ToInt32(txtAba5Sub5Sub3Idade.Text) > 80)
                {
                    Util.CaixaMensagem.ExibirOk("O titular não poderá informar um agregado maior que 80 anos.");
                    return;
                }
                else
                {
                    TAgregadoDOMINIO temporario = new TAgregadoDOMINIO();
                    //PremioAgregadoTabelas = new List<decimal>();
                    temporario.GrauParentesco = cmbAba5Sub5Sub3Parentesco.Text;
                    temporario.Idade = Convert.ToInt32(txtAba5Sub5Sub3Idade.Text);
                    temporario.Funeral = cmbAba5Sub5Sub3Funeral.Text;
                    switch (Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue))
                    {
                        case (int)ProdutoPrincipal.PLANOPROTECAO:
                            temporario.Premio = ControllerPlanoProtecao.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub5Sub3Parentesco.SelectedValue), temporario.Idade, temporario.Funeral);
                            cmbAba5Sub5Sub3Funeral.Text = DadosTPlanoProtecao.NomePlano;
                            break;
                        case (int)ProdutoPrincipal.PLANOSENIOR:
                            temporario.Premio = ControllerPlanoSenior.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub5Sub3Parentesco.SelectedValue), temporario.Idade, temporario.Funeral);
                            cmbAba5Sub5Sub3Funeral.Text = DadosTPlanoSenior.NomePlano;
                            break;
                        case (int)ProdutoPrincipal.PLANOCASAL:
                            temporario.Premio = ControllerPlanoCasal.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub5Sub3Parentesco.SelectedValue), temporario.Idade, temporario.Funeral);
                            cmbAba5Sub5Sub3Funeral.Text = DadosTPlanoCasal.NomePlano;
                            break;
                        default:
                            break;
                    }

                    lstAba5Sub5Sub3Agregado.Items.Add(temporario.GrauParentesco.Trim() + " - " + temporario.Idade + " - " + String.Format(new CultureInfo("pt-BR"), "{0:C}", temporario.Premio) + " - " + temporario.Funeral);
                    PremioAgregadoTabelas.Add(temporario.Premio);

                    cmbAba5Sub5Sub3Parentesco.SelectedIndex = 0;
                    txtAba5Sub5Sub3Idade.Text = string.Empty;

                    decimal valorTotal = 0;
                    foreach (decimal item in PremioAgregadoTabelas)
                    {
                        valorTotal += item;
                    }
                    lblAba5Sub5Sub3PremioAgregadoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", valorTotal);

                    lblAba5Sub5Sub3QuantidadeValor.Text = lstAba5Sub5Sub3Agregado.Items.Count.ToString();

                    cmbAba5Sub5Sub3Parentesco.Focus();
                }
            }
        }

        private void btnAba5Sub5Sub3Remover_Click(object sender, EventArgs e)
        {
            if (lstAba5Sub5Sub3Agregado.SelectedIndex > -1)
            {
                if (PremioAgregadoTabelas.Count > 0)
                {
                    PremioAgregadoTabelas.RemoveAt(lstAba5Sub5Sub3Agregado.SelectedIndex);
                }

                lstAba5Sub5Sub3Agregado.Items.RemoveAt(lstAba5Sub5Sub3Agregado.SelectedIndex);

                cmbAba5Sub5Sub3Parentesco.SelectedIndex = 0;
                txtAba5Sub5Sub3Idade.Text = string.Empty;

                decimal valorTotal = 0;
                foreach (decimal item in PremioAgregadoTabelas)
                {
                    valorTotal += item;
                }
                lblAba5Sub5Sub3PremioAgregadoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", valorTotal);

                lblAba5Sub5Sub3QuantidadeValor.Text = lstAba5Sub5Sub3Agregado.Items.Count.ToString();
            }
        }

        private void btnAba5Sub5Sub3Remover_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tabControlTabelasSimulador.TabPages.Contains(tabTabelaRenda))
            {
                tabControlTabelasSimulador.SelectedIndex = 3;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSalvar.Focus();
            }
        }

        #endregion

        #region [ ABA 4 ]

        private void cmbAba5Sub5Sub4Periodo_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub5Sub4Periodo = string.Empty;
        }

        private void cmbAba5Sub5Sub4Periodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub5Sub4Periodo = string.Empty;
                e.Handled = true;
                return;
            } 

            string atual = TextoCmbAba5Sub5Sub4Periodo;
            
            if (e.KeyChar != 13)
                TextoCmbAba5Sub5Sub4Periodo += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<int, string> verificaCombo = DadosCmbAba5Sub5Sub4Periodo.Where(registro => registro.Value.Contains(TextoCmbAba5Sub5Sub4Periodo)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub5Sub4Periodo = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub5Sub4Periodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAba5Sub5Sub4Periodo.SelectedIndex > 0)
            {
                if (Convert.ToInt32(cmbAba5Sub5Sub1FaixaBase.SelectedValue) == (int)FaixaEtaria.PREMIO_18_30)
                {
                    if (cmbAba5Sub5Sub4Periodo.SelectedIndex == 0)
                    {
                        cmbAba5Sub5Sub4Valor.Enabled = false;
                        if (cmbAba5Sub5Sub4Valor.Items.Count > 0)
                            cmbAba5Sub5Sub4Valor.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbAba5Sub5Sub4Valor.Enabled = true;
                        lblAba5Sub5Sub4CapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);
                        PopularSimuladorAbaTabelasSubRendaValor();
                    }
                }
                else
                {
                    cmbAba5Sub5Sub4Valor.Enabled = true;
                    lblAba5Sub5Sub4CapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);
                    PopularSimuladorAbaTabelasSubRendaValor();
                }

                PreencherSimuladorAbaTabelasSubRenda();
            }
        }

        private void cmbAba5Sub5Sub4Valor_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub5Sub4Valor = string.Empty;
        }

        private void cmbAba5Sub5Sub4Valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub5Sub4Valor = string.Empty;
                e.Handled = true;
                return;
            } 

            string atual = TextoCmbAba5Sub5Sub4Valor;
           
            if (e.KeyChar != 13)
                TextoCmbAba5Sub5Sub4Valor += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<decimal, string> verificaCombo = DadosCmbAba5Sub5Sub4Valor.Where(registro => registro.Value.Contains(TextoCmbAba5Sub5Sub4Valor)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub5Sub4Valor = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub5Sub4Valor_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherSimuladorAbaTabelasSubRenda();
        }

        private void cmbAba5Sub5Sub4Valor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar.Focus();
            }
        }

        #endregion

        private void tabControlTabelasSimulador_SelectedIndexChanged(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);
            if (SimuladorAbaTabelaAnterior != tabControlTabelasSimulador.SelectedIndex)
            {
                switch (SimuladorAbaTabelaAnterior)
                {
                    case 0:
                        if ((cmbAba5Sub5Sub1Produto.SelectedIndex == 0 || cmbAba5Sub5Sub1FaixaBase.SelectedIndex == 0))
                        {
                            if (!(Convert.ToInt32(cmbAba5Sub5Sub1Produto.SelectedValue) != (int)ProdutoPrincipal.PLANOPROTECAO && tabControlTabelasSimulador.SelectedIndex == 2))
                            {
                                Util.CaixaMensagem.ExibirOk("Simulador Tabelas - Informe o Produto e a Faixa Base que deseja pesquisar.");
                                tabControlTabelasSimulador.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            AcertarFocuSimuladorSubTabelas();
                        }                        
                        break;
                    case 1:
                        AcertarFocuSimuladorSubTabelas();
                        break;
                    case 2:
                        AcertarFocuSimuladorSubTabelas();
                        break;
                    case 3:
                        AcertarFocuSimuladorSubTabelas();
                        break;
                    default:
                        break;
                }
            }

            Util.MostraCursor.CursorAguarde(false);
        }

        #endregion
    }
}
