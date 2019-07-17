using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjetoMobile.Dominio;
using ProjetoMobile.Persistencia;
using ProjetoMobile.Dominio.Enumeradores;
using ProjetoMobile.Util;

namespace ProjetoMobile
{
    public partial class frmPremioAlterado : Form
    {
        #region [ PROPERTIES ]

        private TCombosEnumPERSISTENCIA controllerEnum;

        public TCombosEnumPERSISTENCIA ControllerEnum
        {
            get
            {
                if (controllerEnum == null)
                    controllerEnum = new TCombosEnumPERSISTENCIA();

                return controllerEnum;

            }
        }

        private TEstadoPERSISTENCIA controllerEstado;

        public TEstadoPERSISTENCIA ControllerEstado
        {
            get
            {
                if (controllerEstado == null)
                    controllerEstado = new TEstadoPERSISTENCIA();

                return controllerEstado;

            }
        }

        private TEntrevistadoPERSISTENCIA controllerEntrevistado;

        public TEntrevistadoPERSISTENCIA ControllerEntrevistado
        {
            get
            {
                if (controllerEntrevistado == null)
                    controllerEntrevistado = new TEntrevistadoPERSISTENCIA();

                return controllerEntrevistado;

            }
        }

        private TEntrevistadoEnderecoPERSISTENCIA controllerEntrevistadoEndereco;

        public TEntrevistadoEnderecoPERSISTENCIA ControllerEntrevistadoEndereco
        {
            get
            {
                if (controllerEntrevistadoEndereco == null)
                    controllerEntrevistadoEndereco = new TEntrevistadoEnderecoPERSISTENCIA();

                return controllerEntrevistadoEndereco;

            }
        }

        private TLogradouroPERSISTENCIA controllerLogradouro;

        public TLogradouroPERSISTENCIA ControllerLogradouro
        {
            get
            {
                if (controllerLogradouro == null)
                    controllerLogradouro = new TLogradouroPERSISTENCIA();

                return controllerLogradouro;

            }
        }       

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

        #endregion

        #region [ LOAD ]

        public frmPremioAlterado()
        {
            InitializeComponent();

            Program.PercorreTodosCampos(this);

            txtAba1CPF.Focus();

            DesativarKeyUpMudarAba();
            
            PopularCombos();

            if (Program.CodigoEntrevista > 0 && !Program.IncluirRegistro)
                PreenchePremio();
        }

        #endregion

        #region [ METHODS ]

        #region [ RECOVER ]

        private void PreenchePremio()
        {
            PreencheCamposTEntrevistado();
            PreencheCamposTEntrevistadoEndereco();
        }

        private void PreencheCamposTEntrevistado()
        {
            try
            {
                if (Program.CodigoEntrevista > 0)
                {
                    DataTable tableTEntrevistado = ControllerEntrevistado.SelecioneEntrevistado(Program.CodigoEntrevista);

                    if (tableTEntrevistado.Rows.Count == 1)
                    {
                        txtAba1CPF.Text = tableTEntrevistado.Rows[0]["CPF"].ToString();

                        DateTime dataCompleta = Convert.ToDateTime(tableTEntrevistado.Rows[0]["DataNascimento"]);
                        cmbAba1DataNascimentoDia.SelectedValue = dataCompleta.Day;
                        cmbAba1DataNascimentoMes.SelectedValue = dataCompleta.Month;
                        cmbAba1DataNascimentoAno.SelectedValue = dataCompleta.Year;

                        cmbAba1Sexo.Text = tableTEntrevistado.Rows[0]["Sexo"].ToString();

                        string telefone = "(" + tableTEntrevistado.Rows[0]["DDD"].ToString() + ")" + tableTEntrevistado.Rows[0]["Telefone"].ToString();

                        if (telefone.Length > 4)
                            txtAba1Telefone.Text = telefone;

                        string celular = "(" + tableTEntrevistado.Rows[0]["DDDCelular"].ToString() + ")" + tableTEntrevistado.Rows[0]["Celular"].ToString();

                        if (celular.Length > 4)
                            txtAba1Celular.Text = celular;

                        txtAba1Email.Text = tableTEntrevistado.Rows[0]["Email"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao recuperar o formulário TEntrevistado.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao recuperar o formulário!");
            }
        }

        private void PreencheCamposTEntrevistadoEndereco()
        {
            try
            {
                if (Program.CodigoEntrevista > 0)
                {
                    DataTable tableTEntrevistadoEndereco = ControllerEntrevistadoEndereco.SelecioneEntrevistadoEndereco(Program.CodigoEntrevista);

                    if (tableTEntrevistadoEndereco.Rows.Count == 1)
                    {
                        txtAba2Endereco.Text = tableTEntrevistadoEndereco.Rows[0]["Endereco"].ToString();
                        txtAba2Numero.Text = tableTEntrevistadoEndereco.Rows[0]["Numero"].ToString();
                        txtAba2Bairro.Text = tableTEntrevistadoEndereco.Rows[0]["Bairro"].ToString();
                        txtAba2Cidade.Text = tableTEntrevistadoEndereco.Rows[0]["Cidade"].ToString();
                        cmbAba2UF.Text = tableTEntrevistadoEndereco.Rows[0]["UF"].ToString();
                        txtAba2Complemento.Text = tableTEntrevistadoEndereco.Rows[0]["Complemento"].ToString();

                        string cepCompleto = tableTEntrevistadoEndereco.Rows[0]["CEP"].ToString();
                        if (cepCompleto.Length >= 8)
                        {
                            txtAba2CEPbox1.Text = cepCompleto.Substring(0, 5);
                            txtAba2CEPbox2.Text = cepCompleto.Substring(5, 3);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao recuperar o formulário TEntrevistadoEndereco.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao recuperar o formulário!");
            }
        }

        #endregion

        #region [ FILL ]

        private void PopularCombos()
        {
            cmbAba1DataNascimentoDia.DisplayMember = "Value";
            cmbAba1DataNascimentoDia.ValueMember = "Key";
            cmbAba1DataNascimentoDia.DataSource = ControllerEnum.ListaDeDiaData(0);

            cmbAba1DataNascimentoMes.DisplayMember = "Value";
            cmbAba1DataNascimentoMes.ValueMember = "Key";
            cmbAba1DataNascimentoMes.DataSource = ControllerEnum.ListaDeMesData();

            cmbAba1DataNascimentoAno.DisplayMember = "Value";
            cmbAba1DataNascimentoAno.ValueMember = "Key";
            cmbAba1DataNascimentoAno.DataSource = ControllerEnum.ListaDeAnoDataNascimento(true);

            cmbAba2UF.DisplayMember = "Sigla";
            cmbAba2UF.ValueMember = "IDEstado";
            cmbAba2UF.DataSource = ControllerEstado.ListaDeEstado();
        }

        private void PesquisarCEP(string numeroTextCEP)
        {
            int numeroCEP = Convert.ToInt32(numeroTextCEP);

            DataTable tableEndereco = ControllerLogradouro.PesquisaCEP(numeroCEP);

            if (tableEndereco.Rows.Count > 0)
            {
                txtAba2Endereco.Text = tableEndereco.Rows[0]["NomeLogradouro"].ToString();
                txtAba2Bairro.Text = tableEndereco.Rows[0]["NomeBairro"].ToString();
                txtAba2Cidade.Text = tableEndereco.Rows[0]["NomeCidade"].ToString();
                cmbAba2UF.SelectedValue = tableEndereco.Rows[0]["IDEstado"].ToString();
            }
        }

        private void ValidarCampos()
        {
            try
            {
                #region [ ABA 1 ]

                if (string.IsNullOrEmpty(txtAba1CPF.Text))
                    throw new Exception("Campo CPF não informado!");
                                
                if (Convert.ToInt32(cmbAba1Sexo.SelectedIndex) == 0)
                    throw new Exception("Campo Sexo não informado!");

                if (Convert.ToInt32(cmbAba1DataNascimentoDia.SelectedValue) == 0)
                    throw new Exception("Campo Data Nascimento não informado!");

                if (Convert.ToInt32(cmbAba1DataNascimentoMes.SelectedValue) == 0)
                    throw new Exception("Campo Data Nascimento não informado!");

                if (Convert.ToInt32(cmbAba1DataNascimentoAno.SelectedValue) == 0)
                    throw new Exception("Campo Data Nascimento não informado!");

                if (string.IsNullOrEmpty(txtAba1Telefone.Text))
                    throw new Exception("Campo Telefone Residencial não informado!");

                if (txtAba1Telefone.Text.Length < 13)
                    throw new Exception("Campo Telefone Residencial inválido!");

                if (string.IsNullOrEmpty(txtAba1Celular.Text))
                    throw new Exception("Campo Telefone Celular não informado!");

                if (txtAba1Celular.Text.Length < 13)
                    throw new Exception("Campo Telefone Celular inválido!");

                if (string.IsNullOrEmpty(txtAba1Email.Text))
                    throw new Exception("Campo E-mail não informado!");

                #endregion

                #region [ ABA 2 ]

                if (string.IsNullOrEmpty(txtAba2CEPbox1.Text))
                    throw new Exception("Campo CEP não informado!");

                if (txtAba2CEPbox1.Text.Length != 5)
                    throw new Exception("Campo CEP inválido!");

                if (string.IsNullOrEmpty(txtAba2CEPbox2.Text))
                    throw new Exception("Campo CEP não informado!");

                if (txtAba2CEPbox2.Text.Length != 3)
                    throw new Exception("Campo CEP inválido!");

                if (string.IsNullOrEmpty(txtAba2Endereco.Text))
                    throw new Exception("Campo Endereço não informado!");

                if (string.IsNullOrEmpty(txtAba2Numero.Text))
                    throw new Exception("Campo Número não informado!");

                if (string.IsNullOrEmpty(txtAba2Bairro.Text))
                    throw new Exception("Campo Bairro não informado!");

                if (string.IsNullOrEmpty(txtAba2Cidade.Text))
                    throw new Exception("Campo Cidade não informado!");

                if (Convert.ToInt32(cmbAba2UF.SelectedValue) == 0)
                    throw new Exception("Campo UF não informado!");

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MapearCamposTEntrevistado()
        {
            if (Program.CodigoEntrevista > 0)
            {
                DadosTEntrevistado.CodigoEntrevista = Program.CodigoEntrevista;
                DadosTEntrevistado.CPF = txtAba1CPF.Text;

                string dataCompleta = cmbAba1DataNascimentoDia.Text + "/" + cmbAba1DataNascimentoMes.Text + "/" + cmbAba1DataNascimentoAno.Text;
                DadosTEntrevistado.DataNascimento = Convert.ToDateTime(dataCompleta);
                DadosTEntrevistado.Sexo = cmbAba1Sexo.Text;

                if (txtAba1Telefone.Text.Length > 4)
                {
                    DadosTEntrevistado.DDD = txtAba1Telefone.Text.Substring(1, 2);
                    DadosTEntrevistado.Telefone = txtAba1Telefone.Text.Substring(4);
                }

                if (txtAba1Celular.Text.Length > 4)
                {
                    DadosTEntrevistado.DDDCelular = txtAba1Celular.Text.Substring(1, 2);
                    DadosTEntrevistado.Celular = txtAba1Celular.Text.Substring(4);
                }

                DadosTEntrevistadoEndereco.Email = txtAba1Email.Text;
            }
        }

        private void MapearCamposTEntrevistadoEndereco()
        {
            if (Program.CodigoEntrevista > 0)
            {
                DadosTEntrevistadoEndereco.CodigoEntrevista = Program.CodigoEntrevista;
                DadosTEntrevistadoEndereco.Endereco = txtAba2Endereco.Text;
                DadosTEntrevistadoEndereco.Numero = string.IsNullOrEmpty(txtAba2Numero.Text) ? 0 : Convert.ToInt32(txtAba2Numero.Text);
                DadosTEntrevistadoEndereco.Bairro = txtAba2Bairro.Text;
                DadosTEntrevistadoEndereco.Cidade = txtAba2Cidade.Text;
                DadosTEntrevistadoEndereco.UF = cmbAba2UF.Text;

                string cepCompleto = txtAba2CEPbox1.Text + txtAba2CEPbox2.Text;

                DadosTEntrevistadoEndereco.CEP = cepCompleto;

                DadosTEntrevistadoEndereco.Complemento = txtAba2Complemento.Text;
            }
        }

        #endregion

        #endregion

        #region [ CONTROLS ]

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

        private void UpperCase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0 && e.KeyChar != Convert.ToChar(8))
            {
                ((TextBox)sender).Text = char.ToUpper(e.KeyChar).ToString();
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                e.Handled = true;
                return;
            }
        }

        private void Texto_GotFocus(object sender, EventArgs e)
        {
            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teste = new Symbol.Keyboard.KeyPad();
            teste.SetKeyState(newstate, 0, true);
        }

        private void CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teste = new Symbol.Keyboard.KeyPad();
            teste.SetKeyState(newstate, 0, true);

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
                    string cpfsonumero = ((TextBox)sender).Text.Replace('.', ' ').Replace('-', ' ').Trim();
                    if (UtilValidacoes.isCPF(cpfsonumero))
                        cmbAba1Sexo.Focus();
                    else
                    {
                        CaixaMensagem.ExibirOk("Campo CPF inválido!");
                        txtAba1CPF.Focus();
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

        private void Telefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teste = new Symbol.Keyboard.KeyPad();
            teste.SetKeyState(newstate, 0, true);

            if (((TextBox)sender).Text.Length == 15 && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
                return;
            }

            verificado = new Util.Mask().ApenasNumero(e.KeyChar, ref digitoSaida);

            if (verificado)
            {
                if (((TextBox)sender).Text.Length == 0)
                    ((TextBox)sender).Text = "(" + digitoSaida;
                else if (((TextBox)sender).Text.Length == 3)
                    ((TextBox)sender).Text = ((TextBox)sender).Text + ")" + digitoSaida;
                else if (((TextBox)sender).Text.Length == 8)
                    ((TextBox)sender).Text = ((TextBox)sender).Text + "-" + digitoSaida;
                else
                    ((TextBox)sender).Text = ((TextBox)sender).Text + digitoSaida;

                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar != Convert.ToChar(8))
                    e.Handled = true;
            }
        }

        private void CEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teste = new Symbol.Keyboard.KeyPad();
            teste.SetKeyState(newstate, 0, true);

            if (((TextBox)sender).Name.Equals("txtAba2CEPbox1") && txtAba2CEPbox1.Text.Length == 5 && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
                return;
            }

            if (((TextBox)sender).Name.Equals("txtAba2CEPbox2") && txtAba2CEPbox2.Text.Length == 3 && e.KeyChar != Convert.ToChar(8))
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
            {
                if (e.KeyChar != Convert.ToChar(8))
                    e.Handled = true;
            }

            int tamanho = txtAba2CEPbox1.Text.Length + txtAba2CEPbox2.Text.Length;
            if (tamanho == 8)
            {
                Util.MostraCursor.CursorAguarde(true);
                PesquisarCEP(txtAba2CEPbox1.Text + txtAba2CEPbox2.Text);
                Util.MostraCursor.CursorAguarde(false);
            }
        }

        private void Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teste = new Symbol.Keyboard.KeyPad();
            teste.SetKeyState(newstate, 0, true);

            if (((TextBox)sender).Text.Length == 9 && e.KeyChar != Convert.ToChar(8))
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
            {
                if (e.KeyChar != Convert.ToChar(8))
                    e.Handled = true;
            }
        }

        private void Numero_GotFocus(object sender, EventArgs e)
        {
            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teste = new Symbol.Keyboard.KeyPad();
            teste.SetKeyState(newstate, 0, true);
        }

        private void txtAba1Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teste = new Symbol.Keyboard.KeyPad();
            teste.SetKeyState(newstate, 0, true);

            if (e.KeyChar == Convert.ToChar('*'))
            {
                if (txtAba1Email.Text.Contains(".com"))
                    txtAba1Email.Text = txtAba1Email.Text + ".br";
                else
                    txtAba1Email.Text = txtAba1Email.Text + ".com";


                txtAba1Email.SelectionStart = txtAba1Email.Text.Length;
                e.Handled = true;
                return;
            }
            else
            {
                if (e.KeyChar == Convert.ToChar(','))
                {
                    txtAba1Email.Text = txtAba1Email.Text + "@";
                    txtAba1Email.SelectionStart = txtAba1Email.Text.Length;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void txtAba1Email_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabFeedBack.SelectedIndex = 1;
                e.Handled = true;
            }
        }

        private void cmbAba2UF_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar.Focus();
                e.Handled = true;
            }
        }

        private void DesativarKeyUpMudarAba()
        {
            txtAba1Email.KeyUp -= new KeyEventHandler(Program.txtBox_next);
        }

        #endregion

        #region [ BUTTONS ]

        private void bntSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {                
                if (Program.CodigoEntrevista > 0)
                {
                    Util.MostraCursor.CursorAguarde(true);
                    ValidarCampos();
                    MapearCamposTEntrevistado();
                    MapearCamposTEntrevistadoEndereco();

                    if (ControllerEntrevistado.SalvarPremioCompleto(DadosTEntrevistado, DadosTEntrevistadoEndereco))
                    {
                        Util.MostraCursor.CursorAguarde(false);
                        Program.AbreForm<frmFeedBackAlterado>();    
                        this.Close();
                    }
                    else
                    {
                        Util.MostraCursor.CursorAguarde(false);
                        Util.CaixaMensagem.ExibirOk("Erro ao salvar o Prêmio!");
                    }
                }
            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                Util.LogErro.GravaLog("Erro ao Salvar.", ex.Message);
            }
        }

        #endregion        
    }
}