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
using ProjetoMobile.Util;
using System.Globalization;

namespace ProjetoMobile
{
    public partial class frmEntrevista
    {
        #region [ PROPERTIES ]

        private Mask utilMask;
        public Mask UtilMask
        {
            get
            {
                if (utilMask == null)
                    utilMask = new Mask();

                return utilMask;
            }
        }

        private Validacoes utilValidacoes;
        public Validacoes UtilValidacoes
        {
            get
            {
                if (utilValidacoes == null)
                    utilValidacoes = new Validacoes();

                return utilValidacoes;
            }
        }

        private DataTable _dadosCmbAba3DataNascimentoDia;
        public DataTable DadosCmbAba3DataNascimentoDia
        {
            get { return _dadosCmbAba3DataNascimentoDia; }
            set { _dadosCmbAba3DataNascimentoDia = value; }
        }

        private string _textoCmbAba3DataNascimentoDia;
        public string TextoCmbAba3DataNascimentoDia
        {
            get { return _textoCmbAba3DataNascimentoDia; }
            set { _textoCmbAba3DataNascimentoDia = value; }
        }

        private DataTable _dadosCmbAba3DataNascimentoMes;
        public DataTable DadosCmbAba3DataNascimentoMes
        {
            get { return _dadosCmbAba3DataNascimentoMes; }
            set { _dadosCmbAba3DataNascimentoMes = value; }
        }

        private string _textoCmbAba3DataNascimentoMes;
        public string TextoCmbAba3DataNascimentoMes
        {
            get { return _textoCmbAba3DataNascimentoMes; }
            set { _textoCmbAba3DataNascimentoMes = value; }
        }

        private DataTable _dadosCmbAba3DataNascimentoAno;
        public DataTable DadosCmbAba3DataNascimentoAno
        {
            get { return _dadosCmbAba3DataNascimentoAno; }
            set { _dadosCmbAba3DataNascimentoAno = value; }
        }

        private string _textoCmbAba3DataNascimentoAno;
        public string TextoCmbAba3DataNascimentoAno
        {
            get { return _textoCmbAba3DataNascimentoAno; }
            set { _textoCmbAba3DataNascimentoAno = value; }
        }

        private string _textoCPF;
        public string TextoCPF
        {
            get { return _textoCPF; }
            set { _textoCPF = value; }
        }

        private string _textoSexo;
        public string TextoSexo
        {
            get { return _textoSexo; }
            set { _textoSexo = value; }
        }

        private string _textoDataDia;
        public string TextoDataDia
        {
            get { return _textoDataDia; }
            set { _textoDataDia = value; }
        }

        private string _textoDataMes;
        public string TextoDataMes
        {
            get { return _textoDataMes; }
            set { _textoDataMes = value; }
        }

        private string _textoDataAno;
        public string TextoDataAno
        {
            get { return _textoDataAno; }
            set { _textoDataAno = value; }
        }

        private string _textoTelefone;
        public string TextoTelefone
        {
            get { return _textoTelefone; }
            set { _textoTelefone = value; }
        }

        private string _textoCelular;
        public string TextoCelular
        {
            get { return _textoCelular; }
            set { _textoCelular = value; }
        }

        private string _textoEmail;
        public string TextoEmail
        {
            get { return _textoEmail; }
            set { _textoEmail = value; }
        }

        private DateTime _dataCompleta;
        public DateTime DataCompleta
        {
            get { return _dataCompleta; }
            set { _dataCompleta = value; }
        }

        #endregion

        #region [ RECOVER ]

        private void PopularCombosAbaDados()
        {
            try
            {
                cmbAba3Sexo.DisplayMember = "Value";
                cmbAba3Sexo.ValueMember = "Key";
                cmbAba3Sexo.DataSource = ControllerEnum.ListaDeSexo();

                cmbAba3DataNascimentoDia.DisplayMember = "Value";
                cmbAba3DataNascimentoDia.ValueMember = "Key";
                cmbAba3DataNascimentoDia.DataSource = ControllerEnum.ListaDeDiaData(0);
                DadosCmbAba3DataNascimentoDia = ControllerEnum.ListaDeDiaData(0);
                TextoCmbAba3DataNascimentoDia = string.Empty;

                cmbAba3DataNascimentoMes.DisplayMember = "Value";
                cmbAba3DataNascimentoMes.ValueMember = "Key";
                cmbAba3DataNascimentoMes.DataSource = ControllerEnum.ListaDeMesData();
                DadosCmbAba3DataNascimentoMes = ControllerEnum.ListaDeMesData();
                TextoCmbAba3DataNascimentoMes = string.Empty;

                cmbAba3DataNascimentoAno.DisplayMember = "Value";
                cmbAba3DataNascimentoAno.ValueMember = "Key";
                cmbAba3DataNascimentoAno.DataSource = ControllerEnum.ListaDeAnoDataNascimento(true);
                DadosCmbAba3DataNascimentoAno = ControllerEnum.ListaDeAnoDataNascimento(true);
                TextoCmbAba3DataNascimentoAno = string.Empty;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao popular Aba Dados.", ex.Message);
            }
        }

        private void PreencherCamposAbaDados()
        {
            try
            {
                if (Program.CodigoEntrevista > 0)
                {
                    DataTable tableTEntrevistado = ControllerEntrevistado.SelecioneEntrevistado(Program.CodigoEntrevista);

                    if (tableTEntrevistado.Rows.Count == 1)
                    {
                        if (!string.IsNullOrEmpty(tableTEntrevistado.Rows[0]["DataNascimento"].ToString()))
                        {
                            txtAba3CPF.Text = tableTEntrevistado.Rows[0]["CPF"].ToString();

                            DataCompleta = Convert.ToDateTime(tableTEntrevistado.Rows[0]["DataNascimento"]);
                            cmbAba3DataNascimentoDia.SelectedValue = DataCompleta.Day;
                            cmbAba3DataNascimentoMes.SelectedValue = DataCompleta.Month;
                            cmbAba3DataNascimentoAno.SelectedValue = DataCompleta.Year;


                            DadosTEntrevistado.FaixaEtaria = ControllerEnum.FaixaEtariaDataNascimento(DataCompleta);

                            cmbAba3Sexo.Text = tableTEntrevistado.Rows[0]["Sexo"].ToString();

                            string telefone = "(" + tableTEntrevistado.Rows[0]["DDD"].ToString() + ")" + tableTEntrevistado.Rows[0]["Telefone"].ToString();

                            if (telefone.Length > 4)
                                txtAba3Telefone.Text = telefone;

                            string celular = "(" + tableTEntrevistado.Rows[0]["DDDCelular"].ToString() + ")" + tableTEntrevistado.Rows[0]["Celular"].ToString();

                            if (celular.Length > 4)
                                txtAba3Celular.Text = celular;

                            DataTable tableTEntrevistadoEndereco = ControllerEntrevistadoEndereco.SelecioneEntrevistadoEndereco(Program.CodigoEntrevista);
                            if (tableTEntrevistadoEndereco.Rows.Count == 1)
                                txtAba3Email.Text = tableTEntrevistadoEndereco.Rows[0]["Email"].ToString();
                        }
                        else
                            PreencherCamposAbaDadosTemporario();
                    }

                }
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao preencher Aba Dados.", ex.Message);
            }
        }

        private void BloquearCamposAbaDados()
        {
            try
            {
                txtAba3CPF.Enabled = false;
                cmbAba3Sexo.Enabled = false;
                cmbAba3DataNascimentoDia.Enabled = false;
                cmbAba3DataNascimentoMes.Enabled = false;
                cmbAba3DataNascimentoAno.Enabled = false;
                txtAba3Telefone.Enabled = false;
                txtAba3Celular.Enabled = false;
                txtAba3Email.Enabled = false;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao desativar campos Aba Dados.", ex.Message);
            }

        }

        private void PreencherCamposAbaDadosTemporario()
        {
            try
            {
                txtAba3CPF.Text = TextoCPF;
                cmbAba3Sexo.SelectedValue = TextoSexo;
                cmbAba3DataNascimentoDia.SelectedValue = string.IsNullOrEmpty(TextoDataDia) ? "0" : TextoDataDia;
                cmbAba3DataNascimentoMes.SelectedValue = string.IsNullOrEmpty(TextoDataMes) ? "0" : TextoDataMes;
                cmbAba3DataNascimentoAno.SelectedValue = string.IsNullOrEmpty(TextoDataAno) ? "0" : TextoDataAno;
                txtAba3Telefone.Text = TextoTelefone;
                txtAba3Celular.Text = TextoCelular;
                txtAba3Email.Text = TextoEmail;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao preencher Aba Dados.", ex.Message);
            }
        }

        #endregion

        #region [ FILL ]

        private void MapearCamposAbaDados()
        {
            try
            {
                DadosTEntrevistado.CodigoEntrevista = Program.CodigoEntrevista;
                DadosTEntrevistado.CPF = txtAba3CPF.Text;

                if (string.IsNullOrEmpty(cmbAba3DataNascimentoAno.Text) || string.IsNullOrEmpty(cmbAba3DataNascimentoMes.Text) || string.IsNullOrEmpty(cmbAba3DataNascimentoDia.Text))
                    DadosTEntrevistado.DataNascimento = DataCompleta;
                else
                {
                    string dataCompleta = cmbAba3DataNascimentoAno.Text + "-" + cmbAba3DataNascimentoMes.Text + "-" + cmbAba3DataNascimentoDia.Text;

                    DadosTEntrevistado.DataNascimento = Convert.ToDateTime(dataCompleta);
                }

                DadosTEntrevistado.FaixaEtaria = ControllerEnum.FaixaEtariaDataNascimento(DadosTEntrevistado.DataNascimento.GetValueOrDefault());

                DadosTEntrevistado.Sexo = cmbAba3Sexo.Text;

                if (txtAba3Telefone.Text.Length > 4)
                {
                    DadosTEntrevistado.DDD = txtAba3Telefone.Text.Substring(1, 2);
                    DadosTEntrevistado.Telefone = txtAba3Telefone.Text.Substring(4);
                }

                if (txtAba3Celular.Text.Length > 4)
                {
                    DadosTEntrevistado.DDDCelular = txtAba3Celular.Text.Substring(1, 2);
                    DadosTEntrevistado.Celular = txtAba3Celular.Text.Substring(4);
                }               

            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao mapear Aba Dados.", ex.Message);
                CaixaMensagem.ExibirOk("Erro ao mapear Aba Dados!");
            }
        }

        #endregion

        #region [ AUTHENTICATE ]

        private bool ValidarCamposAbaDados(bool mudancaAba)
        {
            try
            {
                TextoCPF = txtAba3CPF.Text;
                TextoSexo = cmbAba3Sexo.SelectedValue.ToString();
                TextoDataDia = cmbAba3DataNascimentoDia.SelectedValue.ToString();
                TextoDataMes = cmbAba3DataNascimentoMes.SelectedValue.ToString();
                TextoDataAno = cmbAba3DataNascimentoAno.SelectedValue.ToString();
                TextoTelefone = txtAba3Telefone.Text;
                TextoCelular = txtAba3Celular.Text;
                TextoEmail = txtAba3Email.Text;

                if (!string.IsNullOrEmpty(txtAba3CPF.Text))
                {
                    string cpfsonumero = txtAba3CPF.Text.Replace(".", "").Replace("-", "").Trim();
                    if (!UtilValidacoes.isCPF(cpfsonumero))
                    {
                        CaixaMensagem.ExibirOk("Campo CPF inválido!");
                        txtAba3CPF.Focus();
                        return false;
                    }

                    if (ControllerEntrevistado.VerificarEntrevistadoCPF(Program.CodigoEntrevista, txtAba3CPF.Text))
                    {
                        CaixaMensagem.ExibirOk("CPF já cadastrado na base de dados!");
                        txtAba3CPF.Focus();
                        return false;
                    }
                }
                //else
                //{
                //    CaixaMensagem.ExibirOk("Campo CPF obrigatório!");
                //    txtAba3CPF.Focus();
                //    return false;
                //}

                if (Convert.ToInt32(cmbAba3Sexo.SelectedIndex) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Sexo é obrigatório!");
                    cmbAba3Sexo.Focus();

                    return false;
                }

                if (Convert.ToInt32(cmbAba3DataNascimentoDia.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Data de Nascimento (DIA) é obrigatório!");
                    cmbAba3DataNascimentoDia.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba3DataNascimentoMes.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Data de Nascimento (MÊS) é obrigatório!");
                    cmbAba3DataNascimentoMes.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba3DataNascimentoAno.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Data de Nascimento (ANO) é obrigatório!");
                    cmbAba3DataNascimentoAno.Focus();
                    return false;
                }

                string dataCompleta = cmbAba3DataNascimentoAno.Text + "-" + cmbAba3DataNascimentoMes.Text + "-" + cmbAba3DataNascimentoDia.Text;
                if ((int)Math.Floor((DateTime.Now - Convert.ToDateTime(dataCompleta)).TotalDays/ 365.25) < 18)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Data de Nascimento deve ser maior que 18 anos!");
                    cmbAba3DataNascimentoDia.Focus();
                    return false;
                }

                bool informouTelefoneFixo = txtAba3Telefone.Text.Replace("_", "").Length != 4;
                bool informouCelular = txtAba3Celular.Text.Replace("_", "").Length != 4; 

                if (!informouTelefoneFixo && !informouCelular)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Telefone Residencial ou Telefone Celular é obrigatório!");
                    txtAba3Telefone.Focus();
                    return false;
                }

                if (informouTelefoneFixo && !informouCelular)
                    if (!ValidarTelefone())
                        return false;


                if (!informouTelefoneFixo && informouCelular)
                    if (!ValidarCelular())
                        return false;                     

                if (informouTelefoneFixo && informouCelular)
                    if (!ValidarTelefone()||!ValidarCelular())
                        return false;     

                if (string.IsNullOrEmpty(txtAba3Email.Text) && mudancaAba)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo E-Mail não foi preenchido!");
                }
                else
                {
                    if (!UtilValidacoes.ValidaEmail(txtAba3Email.Text) && mudancaAba)
                    {
                        CaixaMensagem.ExibirOk("Campo E-Mail inválido!");
                        txtAba3Email.Focus();
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MostraCursor.CursorAguarde(false);
                LogErro.GravaLog("Erro ao validar Aba Dados.", ex.Message);
                CaixaMensagem.ExibirOk("Erro ao validar Aba Dados!");
                return false;
            }
        }

        private bool ValidarTelefone()
        {
            if (txtAba3Telefone.Text.Replace("_", "").Length != 13)
            {
                MostraCursor.CursorAguarde(false);
                CaixaMensagem.ExibirOk("Campo Telefone Residencial não é válido!");
                txtAba3Telefone.Focus();
                return false;
            }

            try
            {
                int ddd = Convert.ToInt32(txtAba3Telefone.Text.Substring(1, 2));
            }
            catch (Exception)
            {
                MostraCursor.CursorAguarde(false);
                CaixaMensagem.ExibirOk("Campo Telefone Residencial não é válido!");
                txtAba3Telefone.Focus();
                return false;
            }

            try
            {
                int telefone = Convert.ToInt32(txtAba3Telefone.Text.Substring(4).Replace("-", ""));
            }
            catch (Exception)
            {
                MostraCursor.CursorAguarde(false);
                CaixaMensagem.ExibirOk("Campo Telefone Residencial não é válido!");
                txtAba3Telefone.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarCelular()
        {
            if (!(txtAba3Celular.Text.Replace("_", "").Length == 13) && !(txtAba3Celular.Text.Replace("_", "").Length == 14))
            {
                MostraCursor.CursorAguarde(false);
                CaixaMensagem.ExibirOk("Campo Telefone Celular não é válido!");
                txtAba3Celular.Focus();
                return false;
            }

            try
            {
                int ddd = Convert.ToInt32(txtAba3Celular.Text.Substring(1, 2));
            }
            catch (Exception)
            {
                MostraCursor.CursorAguarde(false);
                CaixaMensagem.ExibirOk("Campo Telefone Celular não é válido!");
                txtAba3Celular.Focus();
                return false;
            }

            try
            {
                int telefone = Convert.ToInt32(txtAba3Celular.Text.Substring(4).Replace("-", ""));
            }
            catch (Exception)
            {
                MostraCursor.CursorAguarde(false);
                CaixaMensagem.ExibirOk("Campo Telefone Celular não é válido!");
                txtAba3Celular.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region [ CONTROLS ]

        private void CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            if (((TextBox)sender).Text.Length == 14 && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
                return;
            }

            verificado = UtilMask.ApenasNumero(e.KeyChar, ref digitoSaida);

            if (verificado)
            {
                if (((TextBox)sender).Text.Length == 3)
                    ((TextBox)sender).Text = ((TextBox)sender).Text + "." + digitoSaida;
                else if (((TextBox)sender).Text.Length == 7)
                    ((TextBox)sender).Text = ((TextBox)sender).Text + "." + digitoSaida;
                else if (((TextBox)sender).Text.Length == 11)
                    ((TextBox)sender).Text = ((TextBox)sender).Text + "-" + digitoSaida;
                else
                    ((TextBox)sender).Text = ((TextBox)sender).Text + digitoSaida;

                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;

                if (((TextBox)sender).Text.Length == 14)
                {
                    string cpfsonumero = ((TextBox)sender).Text.Replace(".", "").Replace("-", "").Trim();
                    if (UtilValidacoes.isCPF(cpfsonumero))
                        cmbAba3Sexo.Focus();
                    else
                    {
                        CaixaMensagem.ExibirOk("Campo CPF inválido!");
                        txtAba3CPF.Focus();
                    }
                }
                e.Handled = true;

            }
            else
            {
                if (e.KeyChar != Convert.ToChar(8))
                    e.Handled = true;
            }
        }

        private void cmbAba3DataNascimentoDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba3DataNascimentoDia = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba3DataNascimentoDia;
            TextoCmbAba3DataNascimentoDia += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba3DataNascimentoDia.Select("Value LIKE '" + TextoCmbAba3DataNascimentoDia + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba3DataNascimentoDia = atual;
            }

            e.Handled = true;
        }

        private void cmbAba3DataNascimentoMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba3DataNascimentoMes = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba3DataNascimentoMes;
            TextoCmbAba3DataNascimentoMes += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba3DataNascimentoMes.Select("Value LIKE '" + TextoCmbAba3DataNascimentoMes + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba3DataNascimentoMes = atual;
            }

            e.Handled = true;
        }

        private void cmbAba3DataNascimentoMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(cmbAba3DataNascimentoDia.SelectedValue);

            DataTable tabelaDias = ControllerEnum.ListaDeDiaData(Convert.ToInt32(cmbAba3DataNascimentoMes.SelectedValue));
            DataRow[] verificaTabela = tabelaDias.Select("Key = '" + valor + "'");

            cmbAba3DataNascimentoDia.DisplayMember = "Value";
            cmbAba3DataNascimentoDia.ValueMember = "Key";
            cmbAba3DataNascimentoDia.DataSource = tabelaDias;

            if (verificaTabela.Length > 0)
                cmbAba3DataNascimentoDia.SelectedValue = valor;
        }

        private void cmbAba3DataNascimentoAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba3DataNascimentoAno = string.Empty;
                e.Handled = true;
                return;
            }
                        
            string atual = TextoCmbAba3DataNascimentoAno;
            TextoCmbAba3DataNascimentoAno += e.KeyChar.ToString();

            int duplaBase = DateTime.Now.Year % 100;
            int centenaBase = duplaBase / 10;

            DataRow[] verificaCombo;

            if (TextoCmbAba3DataNascimentoAno.Length == 1 && Convert.ToInt32(TextoCmbAba3DataNascimentoAno) > centenaBase)
                verificaCombo = DadosCmbAba3DataNascimentoAno.Select("Value LIKE '19" + TextoCmbAba3DataNascimentoAno + "%'");
            else if (TextoCmbAba3DataNascimentoAno.Length == 1 && Convert.ToInt32(TextoCmbAba3DataNascimentoAno) < centenaBase)
                verificaCombo = DadosCmbAba3DataNascimentoAno.Select("Value LIKE '20" + TextoCmbAba3DataNascimentoAno + "%'");
            else if (TextoCmbAba3DataNascimentoAno.Length == 2 && Convert.ToInt32(TextoCmbAba3DataNascimentoAno) > duplaBase)
                verificaCombo = DadosCmbAba3DataNascimentoAno.Select("Value LIKE '19" + TextoCmbAba3DataNascimentoAno + "%'");
            else if (TextoCmbAba3DataNascimentoAno.Length == 2 && Convert.ToInt32(TextoCmbAba3DataNascimentoAno) < duplaBase)
                verificaCombo = DadosCmbAba3DataNascimentoAno.Select("Value LIKE '20" + TextoCmbAba3DataNascimentoAno + "%'");
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
                TextoCmbAba3DataNascimentoAno = atual;
            }

            e.Handled = true;
        }

        private void Telefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            if (((TextBox)sender).Text.Length == 15 && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
                return;
            }

            verificado = new Util.Mask().ApenasNumero(e.KeyChar, ref digitoSaida);

            if (verificado)
            {
                if ((txtAba3Telefone.Focused && ((TextBox)sender).Text.Length < 13)
                    || (txtAba3Celular.Focused && ((TextBox)sender).Text.Length < 14))
                {

                    if (((TextBox)sender).Text.Length == 0)
                        ((TextBox)sender).Text = "(" + digitoSaida;
                    else if (((TextBox)sender).Text.Length == 3)
                        ((TextBox)sender).Text = ((TextBox)sender).Text + ")" + digitoSaida;
                    else if (txtAba3Telefone.Focused && ((TextBox)sender).Text.Length == 8)
                        ((TextBox)sender).Text = ((TextBox)sender).Text + "-" + digitoSaida;
                    else if (txtAba3Celular.Focused && ((TextBox)sender).Text.Length == 9)
                        ((TextBox)sender).Text = ((TextBox)sender).Text + "-" + digitoSaida;
                    else
                        ((TextBox)sender).Text = ((TextBox)sender).Text + digitoSaida;

                    ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                    e.Handled = true;
                }
            }
            else
            {
                if (e.KeyChar != Convert.ToChar(8))
                    e.Handled = true;
            }
        }

        private void txtAba3Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teste = new Symbol.Keyboard.KeyPad();
            teste.SetKeyState(newstate, 0, true);

            if (e.KeyChar == Convert.ToChar('*'))
            {
                if (txtAba3Email.Text.Contains(".com"))
                    txtAba3Email.Text = txtAba3Email.Text + ".br";
                else
                    txtAba3Email.Text = txtAba3Email.Text + ".com";


                txtAba3Email.SelectionStart = txtAba3Email.Text.Length;
                e.Handled = true;
                return;
            }
            else
            {
                if (e.KeyChar == Convert.ToChar(','))
                {
                    txtAba3Email.Text = txtAba3Email.Text + "@";
                    txtAba3Email.SelectionStart = txtAba3Email.Text.Length;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void txtAba3Email_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabEntrevista.SelectedIndex = 3;
                e.Handled = true;
            }
        }

        #endregion

        #region [ SAVE ]

        private bool SalvarAbaDados()
        {
            try
            {
                if (ValidarCamposAbaDados(true))
                {
                    MapearCamposAbaDados();
                    ControllerEntrevistado.AlterarEntrevistadoPremio(DadosTEntrevistado);

                    return true;
                }
                else
                {
                    tabEntrevista.SelectedIndex = 2;
                }

                return false;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao salvar Aba Dados.", ex.Message);

                return false;
            }
        }

        #endregion
    }
}
