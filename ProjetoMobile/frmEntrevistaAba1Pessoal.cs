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
using ProjetoMobile.Util;

namespace ProjetoMobile
{
    public partial class frmEntrevista
    {
        #region [ PROPERTIES ]

        private TEntrevistadoDOMINIO dadosTEntrevistado;

        public TEntrevistadoDOMINIO DadosTEntrevistado
        {
            get
            {
                if (dadosTEntrevistado == null)
                    dadosTEntrevistado = new TEntrevistadoDOMINIO();

                return dadosTEntrevistado;
            }
            set
            {
                dadosTEntrevistado = value;
            }
        }

        private DataTable _dadosCmbAba1EstadoCivil;
        public DataTable DadosCmbAba1EstadoCivil
        {
            get { return _dadosCmbAba1EstadoCivil; }
            set { _dadosCmbAba1EstadoCivil = value; }
        }

        private string _textoCmbAba1EstadoCivil;
        public string TextoCmbAba1EstadoCivil
        {
            get { return _textoCmbAba1EstadoCivil; }
            set { _textoCmbAba1EstadoCivil = value; }
        }

        private DataTable _dadosCmbAba1Profissao;
        public DataTable DadosCmbAba1Profissao
        {
            get { return _dadosCmbAba1Profissao; }
            set { _dadosCmbAba1Profissao = value; }
        }

        private string _textoCmbAba1Profissao;
        public string TextoCmbAba1Profissao
        {
            get { return _textoCmbAba1Profissao; }
            set { _textoCmbAba1Profissao = value; }
        }

        private DataTable _dadosCmbAba1ConjugeFaixaEtaria;
        public DataTable DadosCmbAba1ConjugeFaixaEtaria
        {
            get { return _dadosCmbAba1ConjugeFaixaEtaria; }
            set { _dadosCmbAba1ConjugeFaixaEtaria = value; }
        }

        private string _textoCmbAba1ConjugeFaixaEtaria;
        public string TextoCmbAba1ConjugeFaixaEtaria
        {
            get { return _textoCmbAba1ConjugeFaixaEtaria; }
            set { _textoCmbAba1ConjugeFaixaEtaria = value; }
        }

        private DataTable _dadosCmbAba1ConjugeProfissao;
        public DataTable DadosCmbAba1ConjugeProfissao
        {
            get { return _dadosCmbAba1ConjugeProfissao; }
            set { _dadosCmbAba1ConjugeProfissao = value; }
        }

        private string _textoCmbAba1ConjugeProfissao;
        public string TextoCmbAba1ConjugeProfissao
        {
            get { return _textoCmbAba1ConjugeProfissao; }
            set { _textoCmbAba1ConjugeProfissao = value; }
        }

        private DataTable _dadosCmbAba1DataNascimentoDia;
        public DataTable DadosCmbAba1DataNascimentoDia
        {
            get { return _dadosCmbAba1DataNascimentoDia; }
            set { _dadosCmbAba1DataNascimentoDia = value; }
        }

        private string _textoCmbAba1DataNascimentoDia;
        public string TextoCmbAba1DataNascimentoDia
        {
            get { return _textoCmbAba1DataNascimentoDia; }
            set { _textoCmbAba1DataNascimentoDia = value; }
        }

        private DataTable _dadosCmbAba1DataNascimentoMes;
        public DataTable DadosCmbAba1DataNascimentoMes
        {
            get { return _dadosCmbAba1DataNascimentoMes; }
            set { _dadosCmbAba1DataNascimentoMes = value; }
        }

        private string _textoCmbAba1DataNascimentoMes;
        public string TextoCmbAba1DataNascimentoMes
        {
            get { return _textoCmbAba1DataNascimentoMes; }
            set { _textoCmbAba1DataNascimentoMes = value; }
        }

        private DataTable _dadosCmbAba1DataNascimentoAno;
        public DataTable DadosCmbAba1DataNascimentoAno
        {
            get { return _dadosCmbAba1DataNascimentoAno; }
            set { _dadosCmbAba1DataNascimentoAno = value; }
        }

        private string _textoCmbAba1DataNascimentoAno;
        public string TextoCmbAba1DataNascimentoAno
        {
            get { return _textoCmbAba1DataNascimentoAno; }
            set { _textoCmbAba1DataNascimentoAno = value; }
        }

        private string _textoNome;
        public string TextoNome
        {
            get { return _textoNome; }
            set { _textoNome = value; }
        }

        private string _textoEstadoCivil;
        public string TextoEstadoCivil
        {
            get { return _textoEstadoCivil; }
            set { _textoEstadoCivil = value; }
        }

        private string _textoProfissao;
        public string TextoProfissao
        {
            get { return _textoProfissao; }
            set { _textoProfissao = value; }
        }

        private string _textoDataDiaConjuge;
        public string TextoDataDiaConjuge
        {
            get { return _textoDataDiaConjuge; }
            set { _textoDataDiaConjuge = value; }
        }

        private string _textoDataMesConjuge;
        public string TextoDataMesConjuge
        {
            get { return _textoDataMesConjuge; }
            set { _textoDataMesConjuge = value; }
        }

        private string _textoDataAnoConjuge;
        public string TextoDataAnoConjuge
        {
            get { return _textoDataAnoConjuge; }
            set { _textoDataAnoConjuge = value; }
        }

        private string _textoProfissaoConjuge;
        public string TextoProfissaoConjuge
        {
            get { return _textoProfissaoConjuge; }
            set { _textoProfissaoConjuge = value; }
        }

        #endregion

        #region [ RECOVER ]

        private void PopularCombosAbaPessoal()
        {
            try
            {
                cmbAba1EstadoCivil.DisplayMember = "Value";
                cmbAba1EstadoCivil.ValueMember = "Key";
                cmbAba1EstadoCivil.DataSource = ControllerEnum.ListaDeEstadoCivil();
                DadosCmbAba1EstadoCivil = ControllerEnum.ListaDeEstadoCivil();
                TextoCmbAba1EstadoCivil = string.Empty;

                cmbAba1Profissao.DisplayMember = "NomeProfissao";
                cmbAba1Profissao.ValueMember = "IDProfissao";
                cmbAba1Profissao.DataSource = ControllerProfissao.ListaDeProfissao();
                DadosCmbAba1Profissao = ControllerProfissao.ListaDeProfissao();
                TextoCmbAba1Profissao = string.Empty;
                               
                cmbAba1ConjugeProfissao.DisplayMember = "NomeProfissao";
                cmbAba1ConjugeProfissao.ValueMember = "IDProfissao";
                cmbAba1ConjugeProfissao.DataSource = ControllerProfissao.ListaDeProfissao();
                DadosCmbAba1ConjugeProfissao = ControllerProfissao.ListaDeProfissao();
                TextoCmbAba1ConjugeProfissao = string.Empty;

                cmbAba1DataNascimentoDia.DisplayMember = "Value";
                cmbAba1DataNascimentoDia.ValueMember = "Key";
                cmbAba1DataNascimentoDia.DataSource = ControllerEnum.ListaDeDiaData(0);
                DadosCmbAba1DataNascimentoDia = ControllerEnum.ListaDeDiaData(0);
                TextoCmbAba1DataNascimentoDia = string.Empty;

                cmbAba1DataNascimentoMes.DisplayMember = "Value";
                cmbAba1DataNascimentoMes.ValueMember = "Key";
                cmbAba1DataNascimentoMes.DataSource = ControllerEnum.ListaDeMesData();
                DadosCmbAba1DataNascimentoMes = ControllerEnum.ListaDeMesData();
                TextoCmbAba1DataNascimentoMes = string.Empty;

                cmbAba1DataNascimentoAno.DisplayMember = "Value";
                cmbAba1DataNascimentoAno.ValueMember = "Key";
                cmbAba1DataNascimentoAno.DataSource = ControllerEnum.ListaDeAnoDataNascimento(false);
                DadosCmbAba1DataNascimentoAno = ControllerEnum.ListaDeAnoDataNascimento(false);
                TextoCmbAba1DataNascimentoAno = string.Empty;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao popular Aba Pessoal.", ex.Message);
            }
        }

        private void PreencherCamposAbaPessoal()
        {
            try
            {
                if (Program.CodigoEntrevista > 0)
                {
                    DataTable tableTEntrevistado = ControllerEntrevistado.SelecioneEntrevistado(Program.CodigoEntrevista);

                    if (tableTEntrevistado.Rows.Count == 1)
                    {
                        txtAba1Nome.Text = tableTEntrevistado.Rows[0]["Nome"].ToString();
                        cmbAba1EstadoCivil.SelectedValue = tableTEntrevistado.Rows[0]["EstadoCivil"].ToString();
                        cmbAba1Profissao.SelectedValue = tableTEntrevistado.Rows[0]["IDProfissao"].ToString();
                        pAba1ConjugePanel.Visible = Convert.ToInt32(cmbAba1EstadoCivil.SelectedValue) == (int)EstadoCivil.Casado || Convert.ToInt32(cmbAba1EstadoCivil.SelectedValue) == (int)EstadoCivil.UniaoEstavel;
                        cmbAba1ConjugeProfissao.SelectedValue = tableTEntrevistado.Rows[0]["IDProfissaoConjuge"].ToString();

                        DateTime dataCompleta = Convert.ToDateTime(tableTEntrevistado.Rows[0]["DataNascimentoConjuge"]);
                        cmbAba1DataNascimentoDia.SelectedValue = dataCompleta.Day;
                        cmbAba1DataNascimentoMes.SelectedValue = dataCompleta.Month;
                        cmbAba1DataNascimentoAno.SelectedValue = dataCompleta.Year;

                    }
                    else
                    {
                        PreencherCamposAbaPessoalTemporario();
                    }
                }


            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao preencher Aba Pessoal.", ex.Message);
            }

        }

        private void BloquearCamposAbaPessoal()
        {
            try
            {
                txtAba1Nome.Enabled  = false;
                cmbAba1EstadoCivil.Enabled = false;
                cmbAba1Profissao.Enabled = false;
                pAba1ConjugePanel.Visible = Convert.ToInt32(cmbAba1EstadoCivil.SelectedValue) == (int)EstadoCivil.Casado || Convert.ToInt32(cmbAba1EstadoCivil.SelectedValue) == (int)EstadoCivil.UniaoEstavel;
                cmbAba1ConjugeProfissao.Enabled = false;
                cmbAba1DataNascimentoDia.Enabled = false;
                cmbAba1DataNascimentoMes.Enabled = false;
                cmbAba1DataNascimentoAno.Enabled = false;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao desativar campos Aba Pessoal.", ex.Message);
            }

        }

        private void PreencherCamposAbaPessoalTemporario()
        {
            try
            {
                txtAba1Nome.Text = TextoNome;
                cmbAba1EstadoCivil.SelectedValue = string.IsNullOrEmpty(TextoEstadoCivil) ? "0" : TextoEstadoCivil;

                if (string.IsNullOrEmpty(TextoProfissao))
                    cmbAba1Profissao.SelectedIndex = 0;
                else
                    cmbAba1Profissao.SelectedValue = TextoProfissao;

                if (pAba1ConjugePanel.Visible)
                {
                    if (string.IsNullOrEmpty(TextoProfissaoConjuge))
                        cmbAba1ConjugeProfissao.SelectedIndex = 0;
                    else
                        cmbAba1ConjugeProfissao.SelectedValue = TextoProfissaoConjuge;

                    cmbAba1DataNascimentoDia.SelectedValue = string.IsNullOrEmpty(TextoDataDiaConjuge) ? "0" : TextoDataDiaConjuge;
                    cmbAba1DataNascimentoMes.SelectedValue = string.IsNullOrEmpty(TextoDataMesConjuge) ? "0" : TextoDataMesConjuge;
                    cmbAba1DataNascimentoAno.SelectedValue = string.IsNullOrEmpty(TextoDataAnoConjuge) ? "0" : TextoDataAnoConjuge;
                }
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao preencher Aba Pessoal.", ex.Message);
            }
        }

        #endregion

        #region [ FILL ]

        private void MapearCamposAbaPessoal()
        {
            try
            {
                DadosTEntrevistado.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;
                DadosTEntrevistado.Nome = txtAba1Nome.Text;
                DadosTEntrevistado.EstadoCivil = Convert.ToInt32(cmbAba1EstadoCivil.SelectedValue);
                DadosTEntrevistado.IDProfissao = Convert.ToInt32(cmbAba1Profissao.SelectedValue);

                //TODO JOAO  Verificar o capital de acordo com a profissão
                //DadosTEntrevistado.CapitalLimitado = cmbAba1Capital.SelectedValue.ToString();
                if ((pAba1ConjugePanel.Visible) &&
                    !string.IsNullOrEmpty(cmbAba1DataNascimentoAno.Text) &&
                    !string.IsNullOrEmpty(cmbAba1DataNascimentoMes.Text) &&
                    !string.IsNullOrEmpty(cmbAba1DataNascimentoDia.Text))
                {
                    string dataCompleta = cmbAba1DataNascimentoAno.Text + "-" + cmbAba1DataNascimentoMes.Text + "-" + cmbAba1DataNascimentoDia.Text;

                    DadosTEntrevistado.IDProfissaoConjuge = Convert.ToInt32(cmbAba1ConjugeProfissao.SelectedValue);
                    DadosTEntrevistado.FaixaEtariaConjuge = ControllerEnum.FaixaEtariaDataNascimento(Convert.ToDateTime(dataCompleta));
                    DadosTEntrevistado.DataNascimentoConjuge = Convert.ToDateTime(dataCompleta);
                }
                else
                {
                    DadosTEntrevistado.IDProfissaoConjuge = 0;
                    DadosTEntrevistado.FaixaEtariaConjuge = 0;
                    DadosTEntrevistado.DataNascimentoConjuge = null;
                }
                //DadosTEntrevistado.CapitalLimitadoConjuge = cmbAba2Capital.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao mapear Aba Pessoal.", ex.Message);
                CaixaMensagem.ExibirOk("Erro ao mapear Aba Pessoal!");
            }
        }

        #endregion

        #region [ AUTHENTICATE ]

        private bool ValidarCamposAbaPessoal()
        {
            try
            {
                TextoNome = txtAba1Nome.Text;
                TextoEstadoCivil = cmbAba1EstadoCivil.SelectedValue.ToString();
                TextoProfissao = cmbAba1Profissao.SelectedValue.ToString();

                if (pAba1ConjugePanel.Visible)
                {
                    TextoDataDiaConjuge = cmbAba1DataNascimentoDia.SelectedValue.ToString();
                    TextoDataMesConjuge = cmbAba1DataNascimentoMes.SelectedValue.ToString();
                    TextoDataAnoConjuge = cmbAba1DataNascimentoAno.SelectedValue.ToString();
                    TextoProfissaoConjuge = cmbAba1ConjugeProfissao.SelectedValue.ToString();

                    if (Convert.ToInt32(cmbAba1DataNascimentoDia.SelectedValue) == 0)
                    {
                        MostraCursor.CursorAguarde(false);
                        CaixaMensagem.ExibirOk("Campo Cônjuge Data de Nascimento (DIA) é obrigatório!");
                        cmbAba1DataNascimentoDia.Focus();
                        return false;
                    }

                    if (Convert.ToInt32(cmbAba1DataNascimentoMes.SelectedValue) == 0)
                    {
                        MostraCursor.CursorAguarde(false);
                        CaixaMensagem.ExibirOk("Campo Cônjuge Data de Nascimento (MÊS) é obrigatório!");
                        cmbAba1DataNascimentoMes.Focus();
                        return false;
                    }

                    if (Convert.ToInt32(cmbAba1DataNascimentoAno.SelectedValue) == 0)
                    {
                        MostraCursor.CursorAguarde(false);
                        CaixaMensagem.ExibirOk("Campo Cônjuge Data de Nascimento (ANO) é obrigatório!");
                        cmbAba1DataNascimentoAno.Focus();
                        return false;
                    }
                    
                    if (Convert.ToInt32(cmbAba1ConjugeProfissao.SelectedValue) == 0)
                    {
                        MostraCursor.CursorAguarde(false);
                        CaixaMensagem.ExibirOk("Campo Cônjuge Profissão é obrigatório!");
                        cmbAba1ConjugeProfissao.Focus();
                        return false;
                    }
                }

                if (string.IsNullOrEmpty(txtAba1Nome.Text))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Nome é obrigatório!");
                    txtAba1Nome.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba1EstadoCivil.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Estado Civil é obrigatório!");
                    cmbAba1EstadoCivil.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba1Profissao.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Profissão é obrigatório!");
                    cmbAba1Profissao.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MostraCursor.CursorAguarde(false);
                LogErro.GravaLog("Erro ao validar Aba Pessoal.", ex.Message);
                CaixaMensagem.ExibirOk("Erro ao validar Aba Pessoal!");
                return false;
            }
        }

        #endregion

        #region [ CONTROLS ]

        private void cmbAba1EstadoCivil_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba1EstadoCivil = string.Empty;
        }

        private void cmbAba1EstadoCivil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba1EstadoCivil = string.Empty;
                e.Handled = true;
                return;
            }            

            string atual = TextoCmbAba1EstadoCivil;
            TextoCmbAba1EstadoCivil += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba1EstadoCivil.Select("Value LIKE '" + TextoCmbAba1EstadoCivil + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba1EstadoCivil = atual;
            }

            e.Handled = true;
        }

        private void cmbAba1EstadoCivil_LostFocus(object sender, EventArgs e)
        {
            pAba1ConjugePanel.Visible = Convert.ToInt32(cmbAba1EstadoCivil.SelectedValue) == (int)EstadoCivil.Casado || Convert.ToInt32(cmbAba1EstadoCivil.SelectedValue) == (int)EstadoCivil.UniaoEstavel;
        }

        private void cmbAba1Profissao_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba1Profissao = string.Empty;
        }

        private void cmbAba1Profissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba1Profissao = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba1Profissao;
            TextoCmbAba1Profissao += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba1Profissao.Select("NomeProfissao LIKE '" + TextoCmbAba1Profissao + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba1Profissao = atual;
            }

            e.Handled = true;
        }

        private void cmbAba1Profissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !pAba1ConjugePanel.Visible)
            {
                tabEntrevista.SelectedIndex = 1;
                e.Handled = true;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                    cmbAba1Profissao.Parent.SelectNextControl(cmbAba1Profissao, true, true, true, true);
            }
        }

        private void cmbAba1ConjugeFaixaEtaria_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba1ConjugeFaixaEtaria = string.Empty;
        }

        private void cmbAba1ConjugeFaixaEtaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba1ConjugeFaixaEtaria = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba1ConjugeFaixaEtaria;
            TextoCmbAba1ConjugeFaixaEtaria += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba1ConjugeFaixaEtaria.Select("Value LIKE '" + TextoCmbAba1ConjugeFaixaEtaria + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba1ConjugeFaixaEtaria = atual;
            }

            e.Handled = true;
        }

        private void cmbAba1ConjugeProfissao_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba1Profissao = string.Empty;
        }

        private void cmbAba1ConjugeProfissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba1ConjugeProfissao = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba1ConjugeProfissao;
            TextoCmbAba1ConjugeProfissao += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba1ConjugeProfissao.Select("NomeProfissao LIKE '" + TextoCmbAba1ConjugeProfissao + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba1ConjugeProfissao = atual;
            }

            e.Handled = true;
        }

        private void cmbAba1ConjugeProfissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && pAba1ConjugePanel.Visible)
            {
                tabEntrevista.SelectedIndex = 1;
                e.Handled = true;
            }
        }

        private void cmbAba1DataNascimentoDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba1DataNascimentoDia = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba1DataNascimentoDia;
            TextoCmbAba1DataNascimentoDia += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba1DataNascimentoDia.Select("Value LIKE '" + TextoCmbAba1DataNascimentoDia + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba1DataNascimentoDia = atual;
            }

            e.Handled = true;
        }

        private void cmbAba1DataNascimentoMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba1DataNascimentoMes = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba1DataNascimentoMes;
            TextoCmbAba1DataNascimentoMes += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba1DataNascimentoMes.Select("Value LIKE '" + TextoCmbAba1DataNascimentoMes + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba1DataNascimentoMes = atual;
            }

            e.Handled = true;
        }

        private void cmbAba1DataNascimentoMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(cmbAba1DataNascimentoDia.SelectedValue);

            DataTable tabelaDias = ControllerEnum.ListaDeDiaData(Convert.ToInt32(cmbAba1DataNascimentoMes.SelectedValue));
            DataRow[] verificaTabela = tabelaDias.Select("Key = '" + valor + "'");

            cmbAba1DataNascimentoDia.DisplayMember = "Value";
            cmbAba1DataNascimentoDia.ValueMember = "Key";
            cmbAba1DataNascimentoDia.DataSource = tabelaDias;

            if (verificaTabela.Length > 0)
                cmbAba1DataNascimentoDia.SelectedValue = valor;
        }

        private void cmbAba1DataNascimentoAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba1DataNascimentoAno = string.Empty;
                e.Handled = true;
                return;
            }                       

            string atual = TextoCmbAba1DataNascimentoAno;
            TextoCmbAba1DataNascimentoAno += e.KeyChar.ToString();

            int duplaBase = DateTime.Now.Year % 100;
            int centenaBase = duplaBase / 10;

            DataRow[] verificaCombo;

            if (TextoCmbAba1DataNascimentoAno.Length == 1 && Convert.ToInt32(TextoCmbAba1DataNascimentoAno) > centenaBase)
                verificaCombo = DadosCmbAba1DataNascimentoAno.Select("Value LIKE '19" + TextoCmbAba1DataNascimentoAno + "%'");
            else if (TextoCmbAba1DataNascimentoAno.Length == 1 && Convert.ToInt32(TextoCmbAba1DataNascimentoAno) < centenaBase)
                verificaCombo = DadosCmbAba1DataNascimentoAno.Select("Value LIKE '20" + TextoCmbAba1DataNascimentoAno + "%'");
            else if (TextoCmbAba1DataNascimentoAno.Length == 2 && Convert.ToInt32(TextoCmbAba1DataNascimentoAno) > duplaBase)
                verificaCombo = DadosCmbAba1DataNascimentoAno.Select("Value LIKE '19" + TextoCmbAba1DataNascimentoAno + "%'");
            else if (TextoCmbAba1DataNascimentoAno.Length == 2 && Convert.ToInt32(TextoCmbAba1DataNascimentoAno) < duplaBase)
                verificaCombo = DadosCmbAba1DataNascimentoAno.Select("Value LIKE '20" + TextoCmbAba1DataNascimentoAno + "%'");
            else
            {
                TextoCmbAba1DataNascimentoAno = string.Empty;
                e.Handled = true;
                return;
            }

            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba1DataNascimentoAno = atual;
            }

            e.Handled = true;
        }

        #endregion

        #region [ SAVE ]

        private bool SalvarAbaPessoal()
        {
            try
            {
                if (ValidarCamposAbaPessoal())
                {
                    MapearCamposAbaPessoal();
                    PreencherCamposAbaEndereco();
                    MapearCamposAbaEndereco();
                    ControllerEntrevista.SalvarAba1(DadosTEntrevista, DadosTEntrevistado, DadosTEntrevistadoEndereco);

                    bool conjuge = false;
                    foreach (string item in lstAba2Sub1Parentes.Items)
	                {
                		 if(item.Contains(GrauParentesco.CONJUGE.GetStringValue()))
                             conjuge = true;
	                }

                    if (DadosTEntrevistado.DataNascimentoConjuge.HasValue && !conjuge)
                    {
                        TimeSpan tempo = DateTime.Now - DadosTEntrevistado.DataNascimentoConjuge.Value;
                        int ano = (int)Math.Floor(tempo.TotalDays / 365.25);

                        lstAba2Sub1Parentes.Items.Add(GrauParentesco.CONJUGE.GetStringValue() + " - " + ano.ToString() + " - Não");
                    }
                    //if (!Program.RegistroAntigo)
                    //{
                    //    DataTable dadosGPS = ControllerGPS.SelecioneGPS(DadosTEntrevista.CodigoEntrevista);

                    //    if (dadosGPS.Rows.Count == 0)
                    //        Program.InicializaGPS();
                    //}

                    return true;
                }
                else
                    tabEntrevista.SelectedIndex = 0;

                return false;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao salvar Aba Pessoal.", ex.Message);

                return false;
            }
        }

        #endregion
    }
}
