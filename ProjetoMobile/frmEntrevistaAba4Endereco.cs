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

        private TEntrevistadoEnderecoDOMINIO dadosTEntrevistadoEndereco;

        public TEntrevistadoEnderecoDOMINIO DadosTEntrevistadoEndereco
        {
            get
            {
                if (dadosTEntrevistadoEndereco == null)
                    dadosTEntrevistadoEndereco = new TEntrevistadoEnderecoDOMINIO();

                return dadosTEntrevistadoEndereco;
            }
            set
            {
                dadosTEntrevistadoEndereco = value;
            }
        }

        private DataTable _dadosCmbAba4Complemento;
        public DataTable DadosCmbAba4Complemento
        {
            get { return _dadosCmbAba4Complemento; }
            set { _dadosCmbAba4Complemento = value; }
        }

        private string _textoCmbAba4Complemento;
        public string TextoCmbAba4Complemento
        {
            get { return _textoCmbAba4Complemento; }
            set { _textoCmbAba4Complemento = value; }
        }

        private DataTable _dadosCmbAba4UF;
        public DataTable DadosCmbAba4UF
        {
            get { return _dadosCmbAba4UF; }
            set { _dadosCmbAba4UF = value; }
        }

        private string _textoCmbAba4UF;
        public string TextoCmbAba4UF
        {
            get { return _textoCmbAba4UF; }
            set { _textoCmbAba4UF = value; }
        }

        #endregion

        #region [ RECOVER ]

        private void PopularCombosAbaEndereco()
        {
            try
            {
                cmbAba4Complemento.DisplayMember = "Value";
                cmbAba4Complemento.ValueMember = "Key";
                cmbAba4Complemento.DataSource = ControllerEnum.ListaDeComplemento();
                DadosCmbAba4Complemento = ControllerEnum.ListaDeComplemento();
                TextoCmbAba4Complemento = string.Empty;

                cmbAba4UF.DisplayMember = "Sigla";
                cmbAba4UF.ValueMember = "IDEstado";
                cmbAba4UF.DataSource = ControllerEstado.ListaDeEstado();
                DadosCmbAba4UF = ControllerEstado.ListaDeEstado();
                TextoCmbAba4UF = string.Empty;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao popular Aba Endereço.", ex.Message);
            }
        }

        private void PreencherCamposAbaEndereco()
        {
            try
            {
                if (Program.CodigoEntrevista > 0)
                {
                    DataTable tableTEntrevistadoEndereco = ControllerEntrevistadoEndereco.SelecioneEntrevistadoEndereco(Program.CodigoEntrevista);

                    if (tableTEntrevistadoEndereco.Rows.Count == 1 && ValidarCamposAbaEnderecoAlteracao())
                        PreencherCampos(tableTEntrevistadoEndereco);
                    else
                    {
                        DataTable tableTEntrevistadoUltimo = ControllerEntrevistadoEndereco.SelecioneUltimoEndereco();
                        if (tableTEntrevistadoUltimo.Rows.Count > 0)
                            PreencherCampos(tableTEntrevistadoUltimo);
                    }
                }
                else
                {
                    DataTable tableTEntrevistadoEndereco = ControllerEntrevistadoEndereco.SelecioneUltimoEndereco();
                    if (tableTEntrevistadoEndereco.Rows.Count > 0)
                        PreencherCampos(tableTEntrevistadoEndereco);
                }

                if (cmbAba4UF.Items.Count > 1)
                    cmbAba4UF.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao preencher Aba Endereço.", ex.Message);
            }
        }

        private void PreencherCampos(DataTable tableTEntrevistadoEndereco)
        {
            try
            {
                if (!string.IsNullOrEmpty(tableTEntrevistadoEndereco.Rows[0]["Endereco"].ToString()))
                {
                    txtAba4Endereco.Text = tableTEntrevistadoEndereco.Rows[0]["Endereco"].ToString();

                    txtAba4Numero.Text = string.Empty;
                    if (!string.IsNullOrEmpty(tableTEntrevistadoEndereco.Rows[0]["Numero"].ToString()))
                        if (Convert.ToInt32(tableTEntrevistadoEndereco.Rows[0]["Numero"].ToString()) != 0)
                            txtAba4Numero.Text = tableTEntrevistadoEndereco.Rows[0]["Numero"].ToString();

                    txtAba4Bairro.Text = tableTEntrevistadoEndereco.Rows[0]["Bairro"].ToString();
                    txtAba4Cidade.Text = tableTEntrevistadoEndereco.Rows[0]["Cidade"].ToString();

                    if (cmbAba4UF.Items.Count > 1)
                        cmbAba4UF.SelectedIndex = 1;

                    lstAba4Complemento.Items.Clear();

                    string[] complementos = tableTEntrevistadoEndereco.Rows[0]["Complemento"].ToString().Split('-');
                    if (!(complementos.Length == 1 && String.IsNullOrEmpty(complementos[0])))
                    {
                        foreach (string item in complementos)
                        {
                            lstAba4Complemento.Items.Add(item);
                        }
                    }

                    if (cmbAba4Complemento.Items.Count > 0)
                        cmbAba4Complemento.SelectedIndex = 0;

                    txtAba4Complemento.Text = string.Empty;

                    string cepCompleto = tableTEntrevistadoEndereco.Rows[0]["CEP"].ToString();
                    if (cepCompleto.Length >= 8)
                    {
                        txtAba4CEPbox1.Text = cepCompleto.Substring(0, 5);
                        txtAba4CEPbox2.Text = cepCompleto.Substring(5, 3);
                    }
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }

        private void BloquearCamposAbaEndereco()
        {
            try
            {
                txtAba4CEPbox1.Enabled = false;
                txtAba4CEPbox2.Enabled = false;
                txtAba4Endereco.Enabled = false;
                txtAba4Numero.Enabled = false;
                cmbAba4Complemento.Enabled = false;
                txtAba4Complemento.Enabled = false;
                btnAba4ComplementoAd.Enabled = false;
                btnAba4ComplementoRm.Enabled = false;
                lstAba4Complemento.Enabled = false;
                txtAba4Bairro.Enabled = false;
                txtAba4Cidade.Enabled = false;
                cmbAba4UF.Enabled = false;

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao desativar campos Aba Dados.", ex.Message);
            }

        }

        private void PesquisarCEP(string numeroTextCEP)
        {
            try
            {
                int numeroCEP = Convert.ToInt32(numeroTextCEP);

                DataTable tableEndereco = ControllerLogradouro.PesquisaCEP(numeroCEP);

                if (tableEndereco.Rows.Count > 0)
                {
                    txtAba4Endereco.Text = tableEndereco.Rows[0]["NomeLogradouro"].ToString();
                    txtAba4Bairro.Text = tableEndereco.Rows[0]["NomeBairro"].ToString();
                    txtAba4Cidade.Text = tableEndereco.Rows[0]["NomeCidade"].ToString();
                    cmbAba4UF.SelectedValue = tableEndereco.Rows[0]["IDEstado"].ToString();
                }
                else
                {
                    txtAba4Endereco.Text = string.Empty;
                    txtAba4Bairro.Text = string.Empty;
                    txtAba4Cidade.Text = string.Empty;
                    if(cmbAba4UF.Items.Count > 0)
                        cmbAba4UF.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                txtAba4Endereco.Text = string.Empty;
                txtAba4Bairro.Text = string.Empty;
                txtAba4Cidade.Text = string.Empty;
                if (cmbAba4UF.Items.Count > 0)
                    cmbAba4UF.SelectedIndex = 0;
            }
            
        }

        #endregion

        #region [ FILL ]

        private void MapearCamposAbaEndereco()
        {
            try
            {
                DadosTEntrevistadoEndereco.CodigoEntrevista = Program.CodigoEntrevista;
                DadosTEntrevistadoEndereco.Endereco = txtAba4Endereco.Text;
                DadosTEntrevistadoEndereco.Numero = string.IsNullOrEmpty(txtAba4Numero.Text) ? 0 : Convert.ToInt32(txtAba4Numero.Text);
                DadosTEntrevistadoEndereco.Bairro = txtAba4Bairro.Text;
                DadosTEntrevistadoEndereco.Cidade = txtAba4Cidade.Text;
                DadosTEntrevistadoEndereco.UF = cmbAba4UF.Text;
                DadosTEntrevistadoEndereco.Email = txtAba3Email.Text;

                string cepCompleto = txtAba4CEPbox1.Text + txtAba4CEPbox2.Text;

                DadosTEntrevistadoEndereco.CEP = cepCompleto;

                string complemento = string.Empty;
                foreach (string item in lstAba4Complemento.Items)
                {
                    complemento += "-" + item;
                }

                if (complemento.Length > 1)
                    DadosTEntrevistadoEndereco.Complemento = complemento.Substring(1, complemento.Length - 1);
                else
                    DadosTEntrevistadoEndereco.Complemento = string.Empty;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao mapear Aba Endereço.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao mapear Aba Endereço!");
            }
        }

        #endregion

        #region [ AUTHENTICATE ]

        private bool ValidarCamposAbaEndereco()
        {
            try
            {
                if (string.IsNullOrEmpty(txtAba4CEPbox1.Text))
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Campo CEP é obrigatório!");
                    txtAba4CEPbox1.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtAba4CEPbox2.Text))
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Campo CEP é obrigatório!");
                    txtAba4CEPbox2.Focus();
                    return false;
                }

                if (txtAba4CEPbox1.Text.Length < 5)
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Campo CEP inválido!");
                    txtAba4CEPbox1.Focus();
                    return false;
                }

                if (txtAba4CEPbox2.Text.Length < 3)
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Campo CEP inválido!");
                    txtAba4CEPbox2.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtAba4Endereco.Text))
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Campo Endereço é obrigatório!");
                    txtAba4Endereco.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtAba4Numero.Text) && lstAba4Complemento.Items.Count == 0)
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Campo Número ou Complemento é obrigatório!");
                    txtAba4Numero.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtAba4Bairro.Text))
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Campo Bairro é obrigatório!");
                    txtAba4Bairro.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtAba4Cidade.Text))
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Campo Cidade é obrigatório!");
                    txtAba4Cidade.Focus();
                    return false;
                }

                if (cmbAba4UF.SelectedIndex <= 0)
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Campo UF é obrigatório!");
                    cmbAba4UF.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                Util.LogErro.GravaLog("Erro ao validar Aba Endereço.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao validar Aba Endereço!");
                return false;
            }
        }

        private bool ValidarCamposAbaEnderecoAlteracao()
        {
            if (!string.IsNullOrEmpty(txtAba4CEPbox1.Text))
                return false;

            if (!string.IsNullOrEmpty(txtAba4CEPbox2.Text))
                return false;

            if (!string.IsNullOrEmpty(txtAba4Endereco.Text))
                return false;

            if (!string.IsNullOrEmpty(txtAba4Numero.Text))
                return false;

            if (!string.IsNullOrEmpty(txtAba4Bairro.Text))
                return false;

            if (!string.IsNullOrEmpty(txtAba4Cidade.Text))
                return false;

            if (cmbAba4UF.SelectedIndex > 0)
                return false;

            return true;

        }

        #endregion

        #region [ CONTROLS ]

        private void CEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            if (e.KeyChar == Convert.ToChar(8))
                return;

            if (((TextBox)sender).Name.Equals("txtAba4CEPbox1") && txtAba4CEPbox1.Text.Length == 5)
            {
                e.Handled = true;
                return;
            }

            if (((TextBox)sender).Name.Equals("txtAba4CEPbox1") && txtAba4CEPbox1.Text.Length == 4)
            {
                verificado = new Util.Mask().ApenasNumero(e.KeyChar, ref digitoSaida);

                if (verificado)
                {
                    ((TextBox)sender).Text = ((TextBox)sender).Text + digitoSaida;
                    ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                    e.Handled = true;
                }

                txtAba4CEPbox2.Focus();
                return;
            }

            if (((TextBox)sender).Name.Equals("txtAba4CEPbox2") && txtAba4CEPbox2.Text.Length == 3)
            {
                e.Handled = true;
                return;
            }

            verificado = new Util.Mask().ApenasNumero(e.KeyChar, ref digitoSaida);

            if (verificado)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + digitoSaida;
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                e.Handled = true;
            }
            else
                e.Handled = true;

        }

        private void cmbAba4Complemento_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba4Complemento = string.Empty;
        }

        private void cmbAba4Complemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba4Complemento = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba4Complemento;
            TextoCmbAba4Complemento += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba4Complemento.Select("Value LIKE '" + TextoCmbAba4Complemento + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba4Complemento = atual;
            }

            e.Handled = true;
        }

        private void txtAba4Complemento_GotFocus(object sender, EventArgs e)
        {
            if (cmbAba4Complemento.SelectedValue.Equals("Apto"))
            {
                var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
                Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
                teclado.SetKeyState(newstate, 0, true);
            }
            else
            {
                var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
                Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
                teclado.SetKeyState(newstate, 0, true);
            }
        }

        private void btnAba4CEP_Click(object sender, EventArgs e)
        {
            try
            {
                int tamanho = txtAba4CEPbox1.Text.Length + txtAba4CEPbox2.Text.Length;
                if (tamanho == 8)
                {
                    Util.MostraCursor.CursorAguarde(true);
                    PesquisarCEP(txtAba4CEPbox1.Text + txtAba4CEPbox2.Text);
                    txtAba4Endereco.Focus();
                    
                }
            }
            catch
            {                
            }
            finally { Util.MostraCursor.CursorAguarde(false); }
            
        }

        private void btnAba4ComplementoAd_Click(object sender, EventArgs e)
        {
            if (cmbAba4Complemento.SelectedIndex <= 0)
                cmbAba4Complemento.Focus();
            else
                if (string.IsNullOrEmpty(txtAba4Complemento.Text) && !cmbAba4Complemento.Text.Equals("Casa") && !cmbAba4Complemento.Text.Equals("Fundos"))
                    txtAba4Complemento.Focus();
                else
                {
                    if (string.IsNullOrEmpty(txtAba4Complemento.Text))
                        lstAba4Complemento.Items.Add(cmbAba4Complemento.Text);
                    else
                        lstAba4Complemento.Items.Add(cmbAba4Complemento.Text + " : " + txtAba4Complemento.Text);

                    cmbAba4Complemento.SelectedIndex = 0;
                    txtAba4Complemento.Text = string.Empty;
                }
        }

        private void btnAba4ComplementoRm_Click(object sender, EventArgs e)
        {
            if (lstAba4Complemento.SelectedIndex > -1)
            {
                lstAba4Complemento.Items.RemoveAt(lstAba4Complemento.SelectedIndex);
            }
        }

        private void cmbAba4UF_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba4UF = string.Empty;
        }

        private void cmbAba4UF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba4UF = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba4UF;
            TextoCmbAba4UF += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba4UF.Select("Sigla LIKE '" + TextoCmbAba4UF + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba4UF = atual;
            }

            e.Handled = true;
        }

        private void cmbAba4UF_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabEntrevista.SelectedIndex = 4;
                tabControlSimulador.SelectedIndex = 0;
                e.Handled = true;
            }
        }

        #endregion

        #region [ SAVE ]

        private bool SalvarAbaEndereco()
        {
            try
            {
                if (ValidarCamposAbaEndereco())
                {
                    MapearCamposAbaEndereco();
                    ControllerEntrevistadoEndereco.AlterarEntrevistadoEndereco(DadosTEntrevistadoEndereco);

                    return true;

                }
                else
                {
                    tabEntrevista.SelectedIndex = 3;
                }

                return false;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao salvar Aba Endereço.", ex.Message);

                return false;
            }
        }

        #endregion
    }
}