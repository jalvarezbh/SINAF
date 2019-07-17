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

        private Dictionary<int, string> _dadosCmbAba5Sub3Periodo;
        public Dictionary<int, string> DadosCmbAba5Sub3Periodo
        {
            get { return _dadosCmbAba5Sub3Periodo; }
            set { _dadosCmbAba5Sub3Periodo = value; }
        }

        private string _textoCmbAba5Sub3Periodo;
        public string TextoCmbAba5Sub3Periodo
        {
            get { return _textoCmbAba5Sub3Periodo; }
            set { _textoCmbAba5Sub3Periodo = value; }
        }

        private Dictionary<decimal, string> _dadosCmbAba5Sub3Valor;
        public Dictionary<decimal, string> DadosCmbAba5Sub3Valor
        {
            get { return _dadosCmbAba5Sub3Valor; }
            set { _dadosCmbAba5Sub3Valor = value; }
        }

        private string _textoCmbAba5Sub3Valor;
        public string TextoCmbAba5Sub3Valor
        {
            get { return _textoCmbAba5Sub3Valor; }
            set { _textoCmbAba5Sub3Valor = value; }
        }

        #endregion

        #region [ RECOVER ]

        private void PopularComboRenda()
        {
            cmbAba5Sub3Periodo.DataSource = new BindingSource(ControllerPlanoProtecao.ListarTodosRendaPeriodo(true), null);
            cmbAba5Sub3Periodo.ValueMember = "Key";
            cmbAba5Sub3Periodo.DisplayMember = "Value";
            DadosCmbAba5Sub3Periodo = ControllerPlanoProtecao.ListarTodosRendaPeriodo(true);
            TextoCmbAba5Sub3Periodo = string.Empty;
            lblAba5Sub3CapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);    
        }

        private void PopularPlanoProtecaoRendaValor()
        {
            cmbAba5Sub3Valor.DataSource = new BindingSource(ControllerPlanoProtecao.ListarTodosRendaValor(true, Convert.ToInt32(cmbAba5Sub3Periodo.SelectedValue), FaixaBase), null);
            cmbAba5Sub3Valor.ValueMember = "Key";
            cmbAba5Sub3Valor.DisplayMember = "Value";
            DadosCmbAba5Sub3Valor = ControllerPlanoProtecao.ListarTodosRendaValor(true, Convert.ToInt32(cmbAba5Sub3Periodo.SelectedValue), FaixaBase);
            TextoCmbAba5Sub3Valor = string.Empty;
        }

        private void PreencherDominoAbaSimuladorSubRenda()
        {
            DataTable tableTRenda = ControllerSimuladorSubRenda.SelecioneSimuladorSubRenda(DadosTSimuladorProduto.IDSimuladorProduto);

            if (tableTRenda.Rows.Count > 0)
            {
                DadosTPlanoProtecao.RendaPeriodo = tableTRenda.Rows[0]["Periodo"].ToString();
                DadosTPlanoProtecao.RendaCoberturaRendaMensal = Convert.ToDecimal(tableTRenda.Rows[0]["ValorRenda"]);
                DadosTPlanoProtecao.RendaCoberturaCapitalTotal = Convert.ToDecimal(tableTRenda.Rows[0]["Capital"]);
                DadosTPlanoProtecao.RendaValorPremioIdadeBase = Convert.ToDecimal(tableTRenda.Rows[0]["PremioRenda"]);
                PremioRenda = DadosTPlanoProtecao.RendaValorPremioIdadeBase.GetValueOrDefault();
            }
            else
            {
                if (DadosTPlanoProtecao.IDPlanoProtecao > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOPROTECAO.GetStringValue()))
                {

                    decimal valorPlanoAP = PremioTotalMax - PremioPlano - PremioAgregado;
                    TPlanoProtecaoDOMINIO rendaCalculada = new TPlanoProtecaoDOMINIO();
                    rendaCalculada = ControllerPlanoProtecao.SelecionarPlanoProtecaoRendaInicial(FaixaBase, valorPlanoAP);
                    if (rendaCalculada.IDPlanoProtecaoRenda > 0)
                    {
                        DadosTPlanoProtecao.RendaPeriodo = rendaCalculada.RendaPeriodo;
                        DadosTPlanoProtecao.RendaCoberturaRendaMensal = rendaCalculada.RendaCoberturaRendaMensal;
                        DadosTPlanoProtecao.RendaCoberturaCapitalTotal = rendaCalculada.RendaCoberturaCapitalTotal;
                        DadosTPlanoProtecao.RendaValorPremioIdadeBase = rendaCalculada.RendaValorPremioIdadeBase;
                        PremioRenda = rendaCalculada.RendaValorPremioIdadeBase.GetValueOrDefault();
                    }
                }
            }
        }

        private void PreencherCamposSimuladorAbaRenda()
        {
            PopularComboRenda();

            if (!string.IsNullOrEmpty(DadosTPlanoProtecao.RendaPeriodo))
            {
                if (DadosTPlanoProtecao.RendaPeriodo.Contains(PeriodoRenda.AVISTA.GetStringValue()))
                    cmbAba5Sub3Periodo.SelectedValue = (int)PeriodoRenda.AVISTA;

                if (DadosTPlanoProtecao.RendaPeriodo.Contains(PeriodoRenda.MESES_3.GetStringValue()))
                    cmbAba5Sub3Periodo.SelectedValue = (int)PeriodoRenda.MESES_3;

                if (DadosTPlanoProtecao.RendaPeriodo.Contains(PeriodoRenda.MESES_6.GetStringValue()))
                    cmbAba5Sub3Periodo.SelectedValue = (int)PeriodoRenda.MESES_6;

                if (DadosTPlanoProtecao.RendaPeriodo.Contains(PeriodoRenda.MESES_12.GetStringValue()))
                    cmbAba5Sub3Periodo.SelectedValue = (int)PeriodoRenda.MESES_12;

                if (DadosTPlanoProtecao.RendaPeriodo.Contains(PeriodoRenda.MESES_24.GetStringValue()))
                    cmbAba5Sub3Periodo.SelectedValue = (int)PeriodoRenda.MESES_24;

                PopularPlanoProtecaoRendaValor();
                cmbAba5Sub3Valor.SelectedValue = DadosTPlanoProtecao.RendaCoberturaRendaMensal;
                lblAba5Sub3CapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoProtecao.RendaCoberturaCapitalTotal);
            }
        }

        #endregion

        #region [ FILL ]

        private void MapearCamposAbaProdutoSubAbaRenda()
        {
            //if (cmbAba5Sub3Periodo.SelectedIndex > 0)
                DadosTSimuladorSubRenda.Periodo = cmbAba5Sub3Periodo.Text;

            if (cmbAba5Sub3Valor.SelectedIndex > 0)
                DadosTSimuladorSubRenda.ValorRenda = Convert.ToDecimal(cmbAba5Sub3Valor.SelectedValue);

            DadosTSimuladorSubRenda.Capital = PremioRendaCapital;

            DadosTSimuladorSubRenda.PremioRenda = PremioRenda;
        }

        private void VerificarPlanoProtecaoRenda()
        {
            if (cmbAba5Sub3Periodo.SelectedIndex > 0 && cmbAba5Sub3Valor.SelectedIndex > 0)
            {
                DadosTPlanoProtecaoRendaNovo = ControllerPlanoProtecao.CalcularPremioRenda(cmbAba5Sub3Periodo.Text, Convert.ToDecimal(cmbAba5Sub3Valor.SelectedValue), FaixaBase);
                PremioRenda = DadosTPlanoProtecaoRendaNovo.RendaValorPremioIdadeBase.GetValueOrDefault();
                PremioRendaCapital = DadosTPlanoProtecaoRendaNovo.RendaCoberturaCapitalTotal;
                lblAba5Sub3CapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioRendaCapital);                
            }
            else
            {
                PremioRenda = Decimal.Zero;
                PremioRendaCapital = Decimal.Zero;
                lblAba5Sub3CapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);                
            }

            PreencherCamposTotais();
        }

        #endregion
                
        #region [ CONTROLS ]

        #region [ RENDA ]

        private void cmbAba5Sub3Periodo_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub3Periodo = string.Empty;
        }

        private void cmbAba5Sub3Periodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub3Periodo = string.Empty;
                e.Handled = true;
                return;
            }   

            string atual = TextoCmbAba5Sub3Periodo;
           
            if (e.KeyChar != 13)
                TextoCmbAba5Sub3Periodo += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<int, string> verificaCombo = DadosCmbAba5Sub3Periodo.Where(registro => registro.Value.Contains(TextoCmbAba5Sub3Periodo)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub3Periodo = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub3Periodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAba5Sub3Periodo.SelectedIndex > 0)
            {
                if (FaixaBase == (int)FaixaEtaria.PREMIO_18_30)
                {
                    if (cmbAba5Sub3Periodo.SelectedIndex == 0)
                    {
                        cmbAba5Sub3Valor.Enabled = false;
                        if (cmbAba5Sub3Valor.Items.Count > 0)
                            cmbAba5Sub3Valor.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbAba5Sub3Valor.Enabled = true;
                        lblAba5Sub3CapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);
                        PopularPlanoProtecaoRendaValor();
                    }
                }
                else
                {
                    cmbAba5Sub3Valor.Enabled = true;
                    lblAba5Sub3CapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", Decimal.Zero);
                    PopularPlanoProtecaoRendaValor();
                }                
            }

            VerificarPlanoProtecaoRenda();         
        }

        private void cmbAba5Sub3Valor_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub3Valor = string.Empty;
        }

        private void cmbAba5Sub3Valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub3Valor = string.Empty;
                e.Handled = true;
                return;
            }   

            string atual = TextoCmbAba5Sub3Valor;
           
            if (e.KeyChar != 13)
                TextoCmbAba5Sub3Valor += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<decimal, string> verificaCombo = DadosCmbAba5Sub3Valor.Where(registro => registro.Value.Contains(TextoCmbAba5Sub3Valor)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub3Valor = atual;
            }

            e.Handled = true;
        }

        private void cmbAba5Sub3Valor_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarPlanoProtecaoRenda();
        }

        #endregion

        #region [ BUTTONS ]

        private void btnAba5Sub3Voltar_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);
            PopularSimulador();
            Util.MostraCursor.CursorAguarde(false);
        }

        private void btnAba5Sub3Salvar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlSimulador.SelectedIndex = 3;
                e.Handled = true;
            }
        }

        private void btnAba5Sub3Salvar_Click(object sender, EventArgs e)
        {
            GravarSimulador = true;
        }

        #endregion

        #endregion              
    }
}
