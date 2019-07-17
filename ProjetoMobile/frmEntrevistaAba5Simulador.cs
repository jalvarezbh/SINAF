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

        private Dictionary<int, string> _dadosCmbAba5Sub4Produto;
        public Dictionary<int, string> DadosCmbAba5Sub4Produto
        {
            get { return _dadosCmbAba5Sub4Produto; }
            set { _dadosCmbAba5Sub4Produto = value; }
        }

        private string _textoCmbAba5Sub4Produto;
        public string TextoCmbAba5Sub4Produto
        {
            get { return _textoCmbAba5Sub4Produto; }
            set { _textoCmbAba5Sub4Produto = value; }
        }

        private bool _gravarSimulador;
        public bool GravarSimulador
        {
            get { return _gravarSimulador; }
            set { _gravarSimulador = value; }
        }

        private char _tipoRegistro;
        public char TipoRegistro
        {
            get { return _tipoRegistro; }
            set { _tipoRegistro = value; }
        }

        #endregion

        #region [ RECOVER ]

        private void PopularSimulador()
        {
            try
            {
                if (ControllerEnum.FaixaEtariaDataNascimento(DadosTEntrevistado.DataNascimento.GetValueOrDefault()) != (int)FaixaEtaria.PREMIO_81)
                {
                    List<ProdutoPrincipal> produtos = new List<ProdutoPrincipal>();
                    int idadeBase = 0;
                    bool alterarAgregado = true;
                    TipoRegistro = 'A';
                    DadosTSimuladorProduto = new TSimuladorProdutoDOMINIO();
                    DadosTPlanoProtecao = new TPlanoProtecaoDOMINIO();
                    DadosTPlanoSenior = new TPlanoSeniorDOMINIO();
                    DadosTPlanoCasal = new TPlanoCasalDOMINIO();
                    ControllerPlano.PlanoProtecaoDOMINIO = new TPlanoProtecaoDOMINIO();
                    ControllerPlano.PlanoSeniorDOMINIO = new TPlanoSeniorDOMINIO();
                    ControllerPlano.PlanoCasalDOMINIO = new TPlanoCasalDOMINIO();

                    //Verifica se já foi feita simulação
                    DataTable tableProduto = ControllerSimuladorProduto.SelecioneSimuladorProduto(DadosTEntrevista.CodigoEntrevista);

                    if (tableProduto.Rows.Count > 0)
                    {
                        DadosTSimuladorProduto.IDSimuladorProduto = Convert.ToInt32(tableProduto.Rows[0]["IDSimuladorProduto"]);
                        DadosTSimuladorProduto.IDEntrevista = Convert.ToInt64(tableProduto.Rows[0]["IDEntrevista"]);
                        DadosTSimuladorProduto.Produto = tableProduto.Rows[0]["Produto"].ToString();
                        DadosTSimuladorProduto.PremioTotal = Convert.ToDecimal(tableProduto.Rows[0]["PremioTotal"]);
                        DadosTSimuladorProduto.FaixaEtaria = Convert.ToInt32(tableProduto.Rows[0]["FaixaEtaria"]);
                        DadosTSimuladorProduto.FaixaEtariaConjuge = Convert.ToInt32(tableProduto.Rows[0]["FaixaEtariaConjuge"]);
                        DadosTSimuladorProduto.RespostaBaseRenda = Convert.ToInt32(tableProduto.Rows[0]["RespostaBaseRenda"]);
                        DadosTSimuladorProduto.RespostaBaseDisposto = Convert.ToInt32(tableProduto.Rows[0]["RespostaBaseDisposto"]);

                        //Verificações para Aba Planos
                        if ((DadosTSimuladorProduto.FaixaEtaria == DadosTEntrevistado.FaixaEtaria) &&
                           (DadosTSimuladorProduto.FaixaEtariaConjuge == DadosTEntrevistado.FaixaEtariaConjuge) &&
                           (DadosTSimuladorProduto.RespostaBaseRenda == Resposta2) &&
                           (DadosTSimuladorProduto.RespostaBaseDisposto == Resposta7))
                        {
                            int CalculaBase = 0;
                            ControllerPlano.FaixaBase(DadosTEntrevistado.FaixaEtaria, DadosTEntrevistado.FaixaEtariaConjuge, ref CalculaBase);
                            FaixaBase = CalculaBase;
                            ProdutoDisponivel = new List<ProdutoPrincipal>();
                            if ((FaixaBase <= 6) || (FaixaBase == 8))
                                ProdutoDisponivel.Add(ProdutoPrincipal.PLANOPROTECAO);

                            if ((FaixaBase >= 6) && (FaixaBase != 8))
                            {
                                ProdutoDisponivel.Add(ProdutoPrincipal.PLANOSENIOR);

                                ProdutoDisponivel.Add(ProdutoPrincipal.PLANOCASAL);
                            }

                            PreencherDominoAbaSimuladorSubPlanos();

                            alterarAgregado = false;
                            GravarSimulador = false;                            
                        }
                        else
                        {
                            if (ControllerPlano.SimularPlano(DadosTEntrevistado.DataNascimento.Value, DadosTEntrevistado.DataNascimentoConjuge, Resposta2, Resposta7, ref produtos, ref idadeBase))
                            {
                                FaixaBase = idadeBase;
                                DadosTPlanoProtecao = ControllerPlano.PlanoProtecaoDOMINIO;
                                DadosTPlanoSenior = ControllerPlano.PlanoSeniorDOMINIO;
                                DadosTPlanoCasal = ControllerPlano.PlanoCasalDOMINIO;
                                PremioTotalMax = ControllerPlano.TotalMax;
                                ProdutoDisponivel = produtos;
                                GravarSimulador = true;
                                TipoRegistro = 'S';
                            }
                        }
                    }
                    else
                    {
                        if (ControllerPlano.SimularPlano(DadosTEntrevistado.DataNascimento.Value, DadosTEntrevistado.DataNascimentoConjuge, Resposta2, Resposta7, ref produtos, ref idadeBase))
                        {
                            FaixaBase = idadeBase;
                            DadosTPlanoProtecao = ControllerPlano.PlanoProtecaoDOMINIO;
                            DadosTPlanoSenior = ControllerPlano.PlanoSeniorDOMINIO;
                            DadosTPlanoCasal = ControllerPlano.PlanoCasalDOMINIO;
                            PremioTotalMax = ControllerPlano.TotalMax;
                            ProdutoDisponivel = produtos;
                            GravarSimulador = true;
                            TipoRegistro = 'S';
                        }

                        DadosTSimuladorProduto.Produto = "Produto";
                    }

                    //Preenche campos do simulador
                    PreencherCamposSimuladorAbaPlanos();

                    //Verificações para Aba Agregados                
                    PreencherDominoAbaSimuladorSubAgregados(alterarAgregado);

                    if (DadosTPlanoProtecao.IDPlanoProtecao > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOPROTECAO.GetStringValue()))
                    {
                        //Verificações para Aba Renda
                        PreencherDominoAbaSimuladorSubRenda();
                        PreencherCamposSimuladorAbaRenda();
                    }

                    PreencherCamposTotais();

                    if (GravarSimulador)
                        SalvarAbaSimulador();

                }

            }
            catch (Exception ex)
            {
                Util.CaixaMensagem.ExibirOk(ex.Message);

                Util.LogErro.GravaLog("Erro ao Simular Plano.", ex.Message);
            }
        }

        private void PopularSimuladorAlterarProduto()
        {
            try
            {
                if (cmbAba5Sub4Produto.SelectedIndex > 0)
                {
                    List<ProdutoPrincipal> produtos = new List<ProdutoPrincipal>();
                    int idadeBase = 0;
                    DadosTSimuladorProduto = new TSimuladorProdutoDOMINIO();
                    DadosTPlanoProtecao = new TPlanoProtecaoDOMINIO();
                    DadosTPlanoSenior = new TPlanoSeniorDOMINIO();
                    DadosTPlanoCasal = new TPlanoCasalDOMINIO();
                    ControllerPlano.PlanoProtecaoDOMINIO = new TPlanoProtecaoDOMINIO();
                    ControllerPlano.PlanoSeniorDOMINIO = new TPlanoSeniorDOMINIO();
                    ControllerPlano.PlanoCasalDOMINIO = new TPlanoCasalDOMINIO();
                    bool alterar = true;

                    ProdutoCalculo = Convert.ToInt32(cmbAba5Sub4Produto.SelectedValue);

                    if (ControllerPlano.SimularPlanoAlterarProduto(DadosTEntrevistado.DataNascimento.Value, DadosTEntrevistado.DataNascimentoConjuge, Resposta2, Resposta7, ProdutoCalculo, ref produtos, ref idadeBase))
                    {
                        FaixaBase = idadeBase;
                        DadosTPlanoProtecao = ControllerPlano.PlanoProtecaoDOMINIO;
                        DadosTPlanoSenior = ControllerPlano.PlanoSeniorDOMINIO;
                        DadosTPlanoCasal = ControllerPlano.PlanoCasalDOMINIO;
                        ProdutoDisponivel = produtos;
                    }

                    DadosTSimuladorProduto.Produto = "Produto";

                    //Preenche campos do simulador
                    PreencherCamposSimuladorAbaPlanos();

                    //Verificações para Aba Agregados
                    PreencherDominoAbaSimuladorSubAgregados(alterar);

                    PreencherCamposSimuladorAbaRenda();

                    tabControlSimulador.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                Util.CaixaMensagem.ExibirOk(ex.Message);

                Util.LogErro.GravaLog("Erro ao Simular Plano.", ex.Message);
            }
        }

        private void PopularProduto(int valorInicial)
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

            foreach (ProdutoPrincipal item in ProdutoDisponivel)
            {
                drItems = dtProduto.NewRow();
                drItems["Key"] = (int)item;
                drItems["Value"] = item.GetStringValue();
                dtProduto.Rows.Add(drItems);
            }

            cmbAba5Sub4Produto.ValueMember = "Key";
            cmbAba5Sub4Produto.DisplayMember = "Value";
            cmbAba5Sub4Produto.DataSource = dtProduto;

            cmbAba5Sub4Produto.SelectedValue = valorInicial;

        }

        private void PreencherCamposTotais()
        {
            lblAba5Sub1PremioPlanoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioPlano);
            lblAba5Sub1PremioAgregadoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioAgregado);
            lblAba5Sub1PremioRendaValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioRenda);
            lblAba5Sub1PremioTotalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioTotal);

            lblAba5Sub2PremioPlanoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioPlano);
            lblAba5Sub2PremioAgregadoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioAgregado);
            lblAba5Sub2PremioRendaValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioRenda);
            lblAba5Sub2PremioTotalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioTotal);

            lblAba5Sub3PremioPlanoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioPlano);
            lblAba5Sub3PremioAgregadoValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioAgregado);
            lblAba5Sub3PremioRendaValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioRenda);
            lblAba5Sub3PremioTotalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioTotal);
        }

        private void PreencherCamposSimuladorAbaDetalhes()
        {
            ExibirPanelPreto(false);
            ExibirPanel(false);
            ExibirPanelDetalhe(false);

            if (DadosTPlanoProtecao.IDPlanoProtecao > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOPROTECAO.GetStringValue()))
            {
                pResumoPlanoProtecaoPreto.Height = 88;
                pResumoPlanoProtecaoPreto.Visible = true;

                pResumoPlanoProtecao.Height = 85;
                pResumoPlanoProtecao.Visible = true;

                pResumoPlanoProtecaoDetalhe.Visible = false;
                lblAba5Sub4DTProtecaoPremioValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoProtecao.ValorPremioIdadeBase.GetValueOrDefault());

                pResumoRendaPreto.Height = 88;
                pResumoRendaPreto.Visible = true;

                pResumoRenda.Height = 85;
                pResumoRenda.Visible = true;

                pResumoRendaDetalhe.Visible = false;

                lblAba5Sub4DTRendaPremioValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioRenda);

            }

            if (DadosTPlanoSenior.IDPlanoSenior > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOSENIOR.GetStringValue()))
            {
                pResumoPlanoSeniorPreto.Height = 88;
                pResumoPlanoSeniorPreto.Visible = true;

                pResumoPlanoSenior.Height = 85;
                pResumoPlanoSenior.Visible = true;

                pResumoPlanoSeniorDetalhe.Visible = false;
                lblAba5Sub4DTSeniorPremioValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoSenior.ValorPremioIdadeBase.GetValueOrDefault());

                pResumoRendaPreto.Visible = false;
                pResumoRenda.Visible = false;
            }

            if (DadosTPlanoCasal.IDPlanoCasal > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOCASAL.GetStringValue()))
            {
                pResumoPlanoCasalPreto.Height = 88;
                pResumoPlanoCasalPreto.Visible = true;

                pResumoPlanoCasal.Height = 85;
                pResumoPlanoCasal.Visible = true;

                pResumoPlanoCasalDetalhe.Visible = false;
                lblAba5Sub4DTCasalPremioValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoCasal.ValorPremioIdadeBase.GetValueOrDefault());

                pResumoRendaPreto.Visible = false;
                pResumoRenda.Visible = false;
            }

            if (ProdutoDisponivel != null)
                PopularProduto(ProdutoCalculo);

            pResumoAgregadoPreto.Height = 88;
            pResumoAgregadoPreto.Visible = true;

            pResumoAgregado.Height = 85;
            pResumoAgregado.Visible = true;

            pResumoAgregadoDetalhe.Visible = false;
            lblAba5Sub4DTAgregadoPremioValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioAgregado);


            lblAba5Sub4PremioTotalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", PremioTotal);

            cmbAba5Sub4Produto.Focus();
        }

        private void ExibirPanel(bool visible)
        {
            pResumoPlanoProtecao.Visible = visible;
            pResumoPlanoSenior.Visible = visible;
            pResumoPlanoCasal.Visible = visible;
            pResumoAgregado.Visible = visible;
            pResumoRenda.Visible = visible;

        }

        private void ExibirPanelPreto(bool visible)
        {
            pResumoPlanoProtecaoPreto.Visible = visible;
            pResumoPlanoSeniorPreto.Visible = visible;
            pResumoPlanoCasalPreto.Visible = visible;
            pResumoAgregadoPreto.Visible = visible;
            pResumoRendaPreto.Visible = visible;
        }

        private void ExibirPanelDetalhe(bool visible)
        {
            pResumoPlanoProtecaoDetalhe.Visible = visible;
            pResumoPlanoSeniorDetalhe.Visible = visible;
            pResumoPlanoCasalDetalhe.Visible = visible;
            pResumoAgregadoDetalhe.Visible = visible;
            pResumoRendaDetalhe.Visible = visible;
        }

        private void BloquearCamposAbaSimulador()
        {
            try
            {
                cmbAba5Sub1APMorte.Enabled = false;
                cmbAba5Sub1APFuneral.Enabled = false;
                cmbAba5Sub1SeniorMorte.Enabled = false;
                cmbAba5Sub1SeniorFuneral.Enabled = false;
                cmbAba5Sub1CasalMorte.Enabled = false;
                cmbAba5Sub1CasalFuneral.Enabled = false;
                btnAba5Sub1Voltar.Enabled = false;
                btnAba5Sub1Salvar.Enabled = false;
                cmbAba5Sub2Parentesco.Enabled = false;
                txtAba5Sub2Idade.Enabled = false;
                lstAba5Sub2Agregado.Enabled = false;
                btnAba5Sub2Adicionar.Enabled = false;
                btnAba5Sub2Remover.Enabled = false;
                btnAba5Sub2Voltar.Enabled = false;
                btnAba5Sub2Salvar.Enabled = false;
                cmbAba5Sub3Periodo.Enabled = false;
                cmbAba5Sub3Valor.Enabled = false;
                btnAba5Sub3Voltar.Enabled = false;
                btnAba5Sub3Salvar.Enabled = false;
                cmbAba5Sub4Produto.Enabled = false;
                btnAba5Sub4Produto.Enabled = false;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao desativar campos Aba Dados.", ex.Message);
            }

        }

        #endregion

        #region [ FILL ]

        private void AcertarFocuSimuladorSubCampos()
        {
            switch (tabControlSimulador.SelectedIndex)
            {
                case 0:
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
                    SimuladorAbaAnterior = 0;
                    break;
                case 1:
                    cmbAba5Sub2Parentesco.Focus();
                    SimuladorAbaAnterior = 1;
                    break;
                case 2:
                    if (ProdutoCalculo == (int)ProdutoPrincipal.PLANOPROTECAO)
                    {
                        PreencherCamposSimuladorAbaRenda();
                        cmbAba5Sub3Periodo.Focus();
                    }
                    else
                        PreencherCamposSimuladorAbaDetalhes();

                    SimuladorAbaAnterior = 2;
                    break;
                case 3:
                    if (ProdutoCalculo == (int)ProdutoPrincipal.PLANOPROTECAO)
                        PreencherCamposSimuladorAbaDetalhes();
                    else
                    {
                        PopularSimuladorAbaTabelas();
                        tabControlTabelasSimulador.SelectedIndex = 0;
                        cmbAba5Sub5Sub1Produto.Focus();
                    }
                    SimuladorAbaAnterior = 3;
                    break;
                case 4:
                    PopularSimuladorAbaTabelas();
                    tabControlTabelasSimulador.SelectedIndex = 0;
                    cmbAba5Sub5Sub1Produto.Focus();
                    SimuladorAbaAnterior = 4;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region [ CONTROLS ]

        #region [ SUB DETALHE ]

        private void cmbAba5Sub4Produto_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub4Produto = string.Empty;
        }

        private void cmbAba5Sub4Produto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9 || e.KeyChar == 13)
            {
                TextoCmbAba5Sub4Produto = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba5Sub4Produto;

            if (e.KeyChar != 13)
                TextoCmbAba5Sub4Produto += e.KeyChar.ToString();
            else
            {
                e.Handled = true; return;
            }

            Dictionary<int, string> verificaCombo = DadosCmbAba5Sub4Produto.Where(registro => registro.Value.Contains(TextoCmbAba5Sub4Produto)).ToDictionary(registro => registro.Key, registro => registro.Value);
            if (verificaCombo.Count > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo.FirstOrDefault().Key;
            }
            else
            {
                TextoCmbAba5Sub4Produto = atual;
            }

            e.Handled = true;
        }

        private void btnAba5Sub4Produto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (ProdutoCalculo)
                {
                    case (int)ProdutoPrincipal.PLANOPROTECAO:
                        btnAba5Sub4DTProtecao.Focus();
                        break;
                    case (int)ProdutoPrincipal.PLANOSENIOR:
                        btnAba5Sub4DTSenior.Focus();
                        break;
                    case (int)ProdutoPrincipal.PLANOCASAL:
                        btnAba5Sub4DTCasal.Focus();
                        break;
                    default:
                        break;
                }
                e.Handled = true;
            }
        }

        private void btnAba5Sub4Produto_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);
            PopularSimuladorAlterarProduto();
            Util.MostraCursor.CursorAguarde(false);
        }

        private void btnAba5Sub4DTProtecao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAba5Sub4DTAgregado.Focus();
                e.Handled = true;
            }
        }

        private void btnAba5Sub4DTProtecao_Click(object sender, EventArgs e)
        {
            if (btnAba5Sub4DTProtecao.Text.Equals("Detalhar"))
            {
                btnAba5Sub4DTProtecao.Text = "Ocultar";
                pResumoPlanoProtecaoPreto.Height = 373;
                pResumoPlanoProtecao.Height = 370;
                pResumoPlanoProtecaoDetalhe.Height = 290;
                pResumoPlanoProtecaoDetalhe.Visible = true;

                lblAba5Sub4DTProtecaoMorteValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoProtecao.CoberturaMorte);
                lblAba5Sub4DTProtecaoIPAValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoProtecao.CoberturaAcidente);
                lblAba5Sub4DTProtecaoAEValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoProtecao.CoberturaEmergencia);
                lblAba5Sub4DTProtecaoFuneralValor.Text = DadosTPlanoProtecao.NomePlano;

                lstAba5Sub4DTProtecaoDependentes.Items.Clear();
                foreach (String item in lstAba5Sub2Dependente.Items)
                {
                    lstAba5Sub4DTProtecaoDependentes.Items.Add(item);
                }
            }
            else if (btnAba5Sub4DTProtecao.Text.Equals("Ocultar"))
            {
                btnAba5Sub4DTProtecao.Text = "Detalhar";
                pResumoPlanoProtecaoPreto.Height = 88;
                pResumoPlanoProtecao.Height = 85;
                pResumoPlanoProtecaoDetalhe.Visible = false;
            }
        }

        private void btnAba5Sub4DTSenior_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAba5Sub4DTAgregado.Focus();
                e.Handled = true;
            }
        }

        private void btnAba5Sub4DTSenior_Click(object sender, EventArgs e)
        {
            if (btnAba5Sub4DTSenior.Text.Equals("Detalhar"))
            {
                btnAba5Sub4DTSenior.Text = "Ocultar";
                pResumoPlanoSeniorPreto.Height = 303;
                pResumoPlanoSenior.Height = 300;
                pResumoPlanoSeniorDetalhe.Height = 220;
                pResumoPlanoSeniorDetalhe.Visible = true;

                lblAba5Sub4DTSeniorMorteValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoSenior.CoberturaMorte);
                lblAba5Sub4DTSeniorFuneralValor.Text = DadosTPlanoSenior.NomePlano;

                lstAba5Sub4DTSeniorDependentes.Items.Clear();
                foreach (String item in lstAba5Sub2Dependente.Items)
                {
                    lstAba5Sub4DTSeniorDependentes.Items.Add(item);
                }
            }
            else if (btnAba5Sub4DTSenior.Text.Equals("Ocultar"))
            {
                btnAba5Sub4DTSenior.Text = "Detalhar";
                pResumoPlanoSeniorPreto.Height = 88;
                pResumoPlanoSenior.Height = 85;
                pResumoPlanoSeniorDetalhe.Visible = false;
            }
        }

        private void btnAba5Sub4DTCasal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAba5Sub4DTAgregado.Focus();
                e.Handled = true;
            }
        }

        private void btnAba5Sub4DTCasal_Click(object sender, EventArgs e)
        {
            if (btnAba5Sub4DTCasal.Text.Equals("Detalhar"))
            {
                btnAba5Sub4DTCasal.Text = "Ocultar";
                pResumoPlanoCasalPreto.Height = 333;
                pResumoPlanoCasal.Height = 330;
                pResumoPlanoCasalDetalhe.Height = 250;
                pResumoPlanoCasalDetalhe.Visible = true;

                lblAba5Sub4DTCasalMorteValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoCasal.CoberturaMorte);
                lblAba5Sub4DTCasalConjugeValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoCasal.CoberturaConjuge);
                lblAba5Sub4DTCasalFuneralValor.Text = DadosTPlanoCasal.NomePlano;

                lstAba5Sub4DTCasalDependentes.Items.Clear();
                foreach (String item in lstAba5Sub2Dependente.Items)
                {
                    lstAba5Sub4DTCasalDependentes.Items.Add(item);
                }
            }
            else if (btnAba5Sub4DTCasal.Text.Equals("Ocultar"))
            {
                btnAba5Sub4DTCasal.Text = "Detalhar";
                pResumoPlanoCasalPreto.Height = 88;
                pResumoPlanoCasal.Height = 85;
                pResumoPlanoCasalDetalhe.Visible = false;
            }
        }

        private void btnAba5Sub4DTAgregado_Click(object sender, EventArgs e)
        {
            if (btnAba5Sub4DTAgregado.Text.Equals("Detalhar"))
            {
                btnAba5Sub4DTAgregado.Text = "Ocultar";
                pResumoAgregadoPreto.Height = 233;
                pResumoAgregado.Height = 230;
                pResumoAgregadoDetalhe.Visible = true;

                lstAba5Sub4DTAgregado.Items.Clear();

                foreach (String itemAgregado in lstAba5Sub2Agregado.Items)
                {
                    lstAba5Sub4DTAgregado.Items.Add(itemAgregado);
                }

                lblAba5Sub4DTAgregadoQTDValor.Text = lstAba5Sub4DTAgregado.Items.Count.ToString();

            }
            else if (btnAba5Sub4DTAgregado.Text.Equals("Ocultar"))
            {
                btnAba5Sub4DTAgregado.Text = "Detalhar";
                pResumoAgregadoPreto.Height = 88;
                pResumoAgregado.Height = 85;
                pResumoAgregadoDetalhe.Visible = false;
            }
        }

        private void btnAba5Sub4DTAgregado_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAba5Sub4DTRenda.Focus();
                e.Handled = true;
            }
        }

        private void btnAba5Sub4DTRenda_Click(object sender, EventArgs e)
        {
            if (btnAba5Sub4DTRenda.Text.Equals("Detalhar"))
            {
                btnAba5Sub4DTRenda.Text = "Ocultar";
                pResumoRendaPreto.Height = 203;
                pResumoRenda.Height = 200;
                pResumoRendaDetalhe.Visible = true;

                lblAba5Sub4DTRendaPeriodoValor.Text = DadosTPlanoProtecao.RendaPeriodo;
                cmbAba5Sub3Valor.SelectedValue = DadosTPlanoProtecao.RendaCoberturaRendaMensal;
                lblAba5Sub4DTRendaVRValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", cmbAba5Sub3Valor.Text);
                lblAba5Sub4DTRendaCapitalValor.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DadosTPlanoProtecao.RendaCoberturaCapitalTotal);

                new Util.PanelMobile().BorderPanel(pResumoRenda);
            }
            else if (btnAba5Sub4DTRenda.Text.Equals("Ocultar"))
            {
                btnAba5Sub4DTRenda.Text = "Detalhar";
                pResumoRendaPreto.Height = 88;
                pResumoRenda.Height = 85;
                pResumoRendaDetalhe.Visible = false;
            }
        }

        private void btnAba5Sub4DTRenda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tabControlSimulador.TabPages.IndexOf(tabRenda) > -1)
            {
                tabControlSimulador.SelectedIndex = 4;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter && tabControlSimulador.TabPages.IndexOf(tabRenda) == -1)
            {
                tabControlSimulador.SelectedIndex = 3;
                e.Handled = true;
            }
        }

        #endregion

        private void tabControlSimulador_SelectedIndexChanged(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);
            
            if (SimuladorAbaAnterior != tabControlSimulador.SelectedIndex)
            {
                if (GravarSimulador)
                    SalvarAbaSimulador();

                AcertarFocuSimuladorSubCampos();
            }

            Util.MostraCursor.CursorAguarde(false);
        }

        #endregion

        #region [ SAVE ]

        private void SalvarAbaSimulador()
        {
            try
            {
                MapearCamposAbaProdutoSubAbaPlanos();
                ControllerSimuladorProduto.SalvarSimuladorProduto(DadosTSimuladorProduto);
                
                DataTable completaDadosTSimuladorProduto = ControllerSimuladorProduto.SelecioneSimuladorProduto(DadosTEntrevista.CodigoEntrevista);
                Int32 idSimuladorProduto = Convert.ToInt32(completaDadosTSimuladorProduto.Rows[0]["IDSimuladorProduto"]);
                DadosTSimuladorProduto.IDSimuladorProduto = idSimuladorProduto;
                DadosTSimuladorSubFuneral.IDSimuladorProduto = idSimuladorProduto;
                DadosTSimuladorSubRenda.IDSimuladorProduto = idSimuladorProduto;

                ControllerSimuladorSubFuneral.SalvarSimuladorABAPlanos(DadosTSimuladorProduto.Produto, DadosTSimuladorSubFuneral);

                MapearCamposAbaProdutoSubAbaAgregados();
                ControllerSimuladorSubAgregado.SalvarSimuladorABAAgregados(idSimuladorProduto, DadosTSimuladorSubAgregado);

                MapearCamposAbaProdutoSubAbaRenda();
                ControllerSimuladorSubRenda.SalvarSimuladorABARenda(DadosTSimuladorSubRenda);

                GravarSimulador = false;
                TipoRegistro = 'A';
            }
            catch (Exception ex)
            {                
                throw ex;               
            }
        }

        #endregion

    }
}
