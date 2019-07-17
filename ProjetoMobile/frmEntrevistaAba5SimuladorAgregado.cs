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

        private DataTable _dadosCmbAba5Sub2Parentesco;
        public DataTable DadosCmbAba5Sub2Parentesco
        {
            get { return _dadosCmbAba5Sub2Parentesco; }
            set { _dadosCmbAba5Sub2Parentesco = value; }
        }

        private string _textoCmbAba5Sub2Parentesco;
        public string TextoCmbAba5Sub2Parentesco
        {
            get { return _textoCmbAba5Sub2Parentesco; }
            set { _textoCmbAba5Sub2Parentesco = value; }
        }
                 
        #endregion

        #region [ RECOVER ]

        private void PopularCombosAbaSimuladorSubAgregado()
        {
            cmbAba5Sub2Parentesco.DisplayMember = "Value";
            cmbAba5Sub2Parentesco.ValueMember = "Key";
            bool plano = ProdutoCalculo == (int)ProdutoPrincipal.PLANOSENIOR;
            cmbAba5Sub2Parentesco.DataSource = ControllerEnum.ListaDeParentesco(plano, true);
            DadosCmbAba5Sub2Parentesco = ControllerEnum.ListaDeParentesco(plano, true);
            TextoCmbAba5Sub2Parentesco = string.Empty;
            
            txtAba5Sub2Idade.Text = string.Empty;
        }

        private void PreencherDominoAbaSimuladorSubAgregados(bool alterar)
        {
            lstAba5Sub2Agregado.Items.Clear();
            lstAba5Sub2Dependente.Items.Clear();

            PremioAgregadoTemp = new List<decimal>();
            PremioAgregado = 0;

            PopularCombosAbaSimuladorSubAgregado();
            
            DataTable tableAgregados = ControllerSimuladorSubAgregado.SelecioneSimuladorSubAgregado(DadosTSimuladorProduto.IDSimuladorProduto);
            if (tableAgregados.Rows.Count > 0 && !alterar)
            {
                foreach (DataRow agregadoRow in tableAgregados.Rows)
                {
                    TAgregadoDOMINIO temporario = new TAgregadoDOMINIO();
                    temporario.GrauParentesco = agregadoRow["GrauParentesco"].ToString();
                    temporario.Idade = Convert.ToInt32(agregadoRow["Idade"]);
                    cmbAba5Sub2Parentesco.SelectedText = temporario.GrauParentesco;
                    switch (ProdutoCalculo)
                    {
                        case (int)ProdutoPrincipal.PLANOPROTECAO:
                            temporario.Funeral = DadosTPlanoProtecao.NomePlano;
                            temporario.Premio = ControllerPlanoProtecao.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub2Parentesco.SelectedValue), temporario.Idade, temporario.Funeral);
                            break;
                        case (int)ProdutoPrincipal.PLANOSENIOR:
                            temporario.Funeral = DadosTPlanoSenior.NomePlano;
                            temporario.Premio = ControllerPlanoSenior.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub2Parentesco.SelectedValue), temporario.Idade, temporario.Funeral);
                            break;
                        case (int)ProdutoPrincipal.PLANOCASAL:
                            temporario.Funeral = DadosTPlanoCasal.NomePlano;
                            temporario.Premio = ControllerPlanoCasal.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub2Parentesco.SelectedValue), temporario.Idade, temporario.Funeral);
                            break;
                        default:
                            break;
                    }

                    if ((temporario.GrauParentesco.Contains(GrauParentesco.CONJUGE.GetStringValue()) && ProdutoCalculo == (int)ProdutoPrincipal.PLANOPROTECAO && temporario.Idade <= 65)
                                || (temporario.GrauParentesco.Contains(GrauParentesco.CONJUGE.GetStringValue()) && ProdutoCalculo == (int)ProdutoPrincipal.PLANOCASAL)
                                || ((temporario.GrauParentesco.Contains(GrauParentesco.FILHO.GetStringValue()) || temporario.GrauParentesco.Contains(GrauParentesco.ENTEADO.GetStringValue())) && ProdutoCalculo == (int)ProdutoPrincipal.PLANOPROTECAO && temporario.Idade <= 24))
                    {
                        lstAba5Sub2Dependente.Items.Add(temporario.GrauParentesco + " - " + temporario.Idade);
                    }
                    else
                    {
                        if (!(temporario.GrauParentesco.Contains(GrauParentesco.CONJUGE.GetStringValue()) && ProdutoCalculo == (int)ProdutoPrincipal.PLANOPROTECAO && temporario.Idade > 65)
                            && !(temporario.GrauParentesco.Contains(GrauParentesco.CONJUGE.GetStringValue()) && ProdutoCalculo == (int)ProdutoPrincipal.PLANOSENIOR && temporario.Idade >=61)
                            && (temporario.Idade <= 80))
                        {
                            lstAba5Sub2Agregado.Items.Add(temporario.GrauParentesco + " - " + temporario.Idade + " - " + String.Format(new CultureInfo("pt-BR"), "{0:C}", temporario.Premio));
                            PremioAgregadoTemp.Add(temporario.Premio);
                            PremioAgregado += temporario.Premio;
                        }
                    }
                }
            }
            else
            {
                foreach (String agregadoPergunta in lstAba2Sub1Parentes.Items)
                {
                    String[] separacao = agregadoPergunta.Split('-');

                    if (separacao.Length > 2)
                    {
                        TAgregadoDOMINIO temporario = new TAgregadoDOMINIO();
                        temporario.GrauParentesco = separacao[0];
                        temporario.Idade = Convert.ToInt32(separacao[1]);
                        cmbAba5Sub2Parentesco.SelectedText = temporario.GrauParentesco;

                        if (!temporario.GrauParentesco.Contains(GrauParentesco.AVOM.GetStringValue())
                           && !temporario.GrauParentesco.Contains(GrauParentesco.AVOF.GetStringValue())
                           && !temporario.GrauParentesco.Contains(GrauParentesco.OUTRO.GetStringValue()))
                        {                            

                            switch (ProdutoCalculo)
                            {
                                case (int)ProdutoPrincipal.PLANOPROTECAO:
                                    temporario.Funeral = DadosTPlanoProtecao.NomePlano;
                                    temporario.Premio = ControllerPlanoProtecao.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub2Parentesco.SelectedValue), temporario.Idade, DadosTPlanoProtecao.NomePlano);
                                    break;
                                case (int)ProdutoPrincipal.PLANOSENIOR:
                                    temporario.Funeral = DadosTPlanoSenior.NomePlano;
                                    temporario.Premio = ControllerPlanoSenior.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub2Parentesco.SelectedValue), temporario.Idade, DadosTPlanoSenior.NomePlano);
                                    break;
                                case (int)ProdutoPrincipal.PLANOCASAL:
                                    temporario.Funeral = DadosTPlanoCasal.NomePlano;
                                    temporario.Premio = ControllerPlanoCasal.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub2Parentesco.SelectedValue), temporario.Idade, DadosTPlanoCasal.NomePlano);
                                    break;
                                default:
                                    break;
                            }


                            if ((temporario.GrauParentesco.Contains(GrauParentesco.CONJUGE.GetStringValue()) && ProdutoCalculo == (int)ProdutoPrincipal.PLANOPROTECAO && temporario.Idade <= 65)
                                || (temporario.GrauParentesco.Contains(GrauParentesco.CONJUGE.GetStringValue()) && ProdutoCalculo == (int)ProdutoPrincipal.PLANOCASAL)
                                || ((temporario.GrauParentesco.Contains(GrauParentesco.FILHO.GetStringValue()) || temporario.GrauParentesco.Contains(GrauParentesco.ENTEADO.GetStringValue())) && ProdutoCalculo == (int)ProdutoPrincipal.PLANOPROTECAO && temporario.Idade <= 24))
                            {
                                lstAba5Sub2Dependente.Items.Add(temporario.GrauParentesco + " - " + temporario.Idade);
                            }
                            else
                            {
                                if (!(temporario.GrauParentesco.Contains(GrauParentesco.CONJUGE.GetStringValue()) && ProdutoCalculo == (int)ProdutoPrincipal.PLANOPROTECAO && temporario.Idade > 65)
                                    && !(temporario.GrauParentesco.Contains(GrauParentesco.CONJUGE.GetStringValue()) && ProdutoCalculo == (int)ProdutoPrincipal.PLANOSENIOR && temporario.Idade >= 61)
                                    && (temporario.Idade <= 80))
                                    {
                                        lstAba5Sub2Agregado.Items.Add(temporario.GrauParentesco + " - " + temporario.Idade + " - " + String.Format(new CultureInfo("pt-BR"), "{0:C}", temporario.Premio));
                                        PremioAgregadoTemp.Add(temporario.Premio);
                                        PremioAgregado += temporario.Premio;
                                    }
                            }
                        }
                    }
                }
            }

            lblAba5Sub2QuantidadeValor.Text = lstAba5Sub2Agregado.Items.Count.ToString();
            lblAba5Sub2QtdDepValor.Text = lstAba5Sub2Dependente.Items.Count.ToString();
        }      

        #endregion

        #region [ FILL ]

        private void MapearCamposAbaProdutoSubAbaAgregados()
        {
            DadosTSimuladorSubAgregado = new List<TSimuladorSubAgregadoDOMINIO>();

            string funeral = string.Empty;
            
            if (DadosTPlanoProtecao.IDPlanoProtecao > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOPROTECAO.GetStringValue()))
                funeral = DadosTPlanoProtecao.NomePlano;
            else if (DadosTPlanoSenior.IDPlanoSenior > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOSENIOR.GetStringValue()))
                funeral = DadosTPlanoSenior.NomePlano;
            else if (DadosTPlanoCasal.IDPlanoCasal > 0 || DadosTSimuladorProduto.Produto.Equals(ProdutoPrincipal.PLANOCASAL.GetStringValue()))
               funeral = DadosTPlanoCasal.NomePlano;

            for (int index = 0; index < lstAba5Sub2Dependente.Items.Count; index++)
            {
                String[] camposDependentes = lstAba5Sub2Dependente.Items[index].ToString().Split('-');
                if (camposDependentes.Length >= 2)
                {
                    TSimuladorSubAgregadoDOMINIO temporario = new TSimuladorSubAgregadoDOMINIO();
                    temporario.GrauParentesco = camposDependentes[0].Trim();
                    temporario.Idade = Convert.ToInt32(camposDependentes[1].Replace('-', ' ').Trim());
                    temporario.PremioAgregado = 0;
                    temporario.Funeral = funeral;
                    DadosTSimuladorSubAgregado.Add(temporario);
                }
            }

            for (int index = 0; index < lstAba5Sub2Agregado.Items.Count; index++)
            {
                String[] camposAgregado = lstAba5Sub2Agregado.Items[index].ToString().Split('-');
                if (camposAgregado.Length >= 2)
                {
                    TSimuladorSubAgregadoDOMINIO temporario = new TSimuladorSubAgregadoDOMINIO();
                    temporario.GrauParentesco = camposAgregado[0].Trim();
                    temporario.Idade = Convert.ToInt32(camposAgregado[1].Replace('-', ' ').Trim());
                    temporario.PremioAgregado = PremioAgregadoTemp[index];
                    temporario.Funeral = funeral;
                    DadosTSimuladorSubAgregado.Add(temporario);
                }
            }
        }

        #endregion

        #region [ CONTROLS ]

        #region [ Agregados ]

        private void cmbAba5Sub2Parentesco_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba5Sub2Parentesco = string.Empty;
        }

        private void cmbAba5Sub2Parentesco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba5Sub2Parentesco = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba5Sub2Parentesco;
            TextoCmbAba5Sub2Parentesco += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba5Sub2Parentesco.Select("Value LIKE '" + TextoCmbAba5Sub2Parentesco + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba5Sub2Parentesco = atual;
            }

            e.Handled = true;
        }
              
        private void btnAba5Sub2Adicionar_Click(object sender, EventArgs e)
        {
            if (cmbAba5Sub2Parentesco.SelectedIndex > 0 && !string.IsNullOrEmpty(txtAba5Sub2Idade.Text))
            {
                if ((ProdutoCalculo == (int)ProdutoPrincipal.PLANOSENIOR) &&
                    (Convert.ToInt32(cmbAba5Sub2Parentesco.SelectedValue) == (int)GrauParentesco.CONJUGE) &&
                    (Convert.ToInt32(txtAba5Sub2Idade.Text) >= 61))
                {
                    lstAba5Sub2Dependente.Items.Add(cmbAba5Sub2Parentesco.Text + " - " + txtAba5Sub2Idade.Text);
                    lblAba5Sub2QtdDepValor.Text = lstAba5Sub2Dependente.Items.Count.ToString();
                    return;
                }
                else if ((ProdutoCalculo == (int)ProdutoPrincipal.PLANOPROTECAO) &&
                    (cmbAba5Sub2Parentesco.Text.Equals(GrauParentesco.FILHO.GetStringValue())|| cmbAba5Sub2Parentesco.Text.Equals(GrauParentesco.ENTEADO.GetStringValue())) &&
                    (Convert.ToInt32(txtAba5Sub2Idade.Text) <= 24))
                {
                    lstAba5Sub2Dependente.Items.Add(cmbAba5Sub2Parentesco.Text + " - " + txtAba5Sub2Idade.Text);
                    lblAba5Sub2QtdDepValor.Text = lstAba5Sub2Dependente.Items.Count.ToString();
                    return;
                }
                else if (Convert.ToInt32(txtAba5Sub2Idade.Text) > 80)
                {
                    Util.CaixaMensagem.ExibirOk("O titular não poderá informar um agregado maior que 80 anos.");
                    return;
                }
                else
                {
                    TAgregadoDOMINIO temporario = new TAgregadoDOMINIO();
                    temporario.GrauParentesco = cmbAba5Sub2Parentesco.Text;
                    temporario.Idade = Convert.ToInt32(txtAba5Sub2Idade.Text);
                    
                    switch (ProdutoCalculo)
                    {
                        case (int)ProdutoPrincipal.PLANOPROTECAO:
                            temporario.Funeral = DadosTPlanoProtecao.NomePlano;
                            temporario.Premio = ControllerPlanoProtecao.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub2Parentesco.SelectedValue), temporario.Idade, temporario.Funeral);
                            break;
                        case (int)ProdutoPrincipal.PLANOSENIOR:
                            temporario.Funeral = DadosTPlanoSenior.NomePlano;
                            temporario.Premio = ControllerPlanoSenior.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub2Parentesco.SelectedValue), temporario.Idade, temporario.Funeral);
                            break;
                        case (int)ProdutoPrincipal.PLANOCASAL:
                            temporario.Funeral = DadosTPlanoCasal.NomePlano;
                            temporario.Premio = ControllerPlanoCasal.CalcularPremioAgregado(Convert.ToInt32(cmbAba5Sub2Parentesco.SelectedValue), temporario.Idade, temporario.Funeral);
                            break;
                        default:
                            break;
                    }

                    lstAba5Sub2Agregado.Items.Add(temporario.GrauParentesco.Trim() + " - " + temporario.Idade + " - " + String.Format(new CultureInfo("pt-BR"), "{0:C}", temporario.Premio));
                    PremioAgregadoTemp.Add(temporario.Premio);
                    PremioAgregado += temporario.Premio;
                    cmbAba5Sub2Parentesco.SelectedIndex = 0;
                    txtAba5Sub2Idade.Text = string.Empty;

                    PreencherCamposTotais();

                    lblAba5Sub2QuantidadeValor.Text = lstAba5Sub2Agregado.Items.Count.ToString();
                }
            }
        }

        private void btnAba5Sub2Remover_Click(object sender, EventArgs e)
        {
            if (lstAba5Sub2Agregado.SelectedIndex > -1)
            {
                if (PremioAgregadoTemp.Count > 0)
                {
                    PremioAgregado -= PremioAgregadoTemp[lstAba5Sub2Agregado.SelectedIndex];
                    PremioAgregadoTemp.RemoveAt(lstAba5Sub2Agregado.SelectedIndex);
                }

                lstAba5Sub2Agregado.Items.RemoveAt(lstAba5Sub2Agregado.SelectedIndex);

                PreencherCamposTotais();

                lblAba5Sub2QuantidadeValor.Text = lstAba5Sub2Agregado.Items.Count.ToString();
            }

            if (lstAba5Sub2Dependente.SelectedIndex > -1)
            {
                lstAba5Sub2Dependente.Items.RemoveAt(lstAba5Sub2Dependente.SelectedIndex);

                lblAba5Sub2QtdDepValor.Text = lstAba5Sub2Dependente.Items.Count.ToString();
            }
        }

        #endregion

        #region [ Buttons ]

        private void btnAba5Sub2Voltar_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);
            PopularSimulador();
            Util.MostraCursor.CursorAguarde(false);
        }

        private void btnAba5Sub2Salvar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlSimulador.SelectedIndex = 2;
                e.Handled = true;
            }
        }

        private void btnAba5Sub2Salvar_Click(object sender, EventArgs e)
        {
            GravarSimulador = true;
        }

        #endregion

        #endregion              
    }
}
