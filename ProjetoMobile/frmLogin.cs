using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjetoMobile.Util;
using FTP_Mobile.FTPLib;
using System.IO;
using ProjetoMobile.Persistencia;
using System.Data;
using Symbol;
using Symbol.ResourceCoordination;
using ProjetoMobile.Dominio.Enumeradores;
using System.Reflection;

namespace ProjetoMobile
{
    public partial class frmLogin : Form
    {
        #region [ PROPERTIES ]

        private TUsuarioPERSISTENCIA controllerUsuario;

        public TUsuarioPERSISTENCIA ControllerUsuario
        {
            get
            {
                if (controllerUsuario == null)
                    controllerUsuario = new TUsuarioPERSISTENCIA();

                return controllerUsuario;

            }
        }

        private TParametroPERSISTENCIA controllerParametro;

        public TParametroPERSISTENCIA ControllerParametro
        {
            get
            {
                if (controllerParametro == null)
                    controllerParametro = new TParametroPERSISTENCIA();

                return controllerParametro;

            }
        }

        #endregion

        #region [ LOAD ]

        public frmLogin()
        {
            InitializeComponent();

            FocusOn();
            FocusOff();
            KeyDownTecla();
            KeyUpTecla();

            picFundo.Image = ProjetoMobile.Properties.Resources.fundo_azul;

            ControleHardware wifi = new ControleHardware();
            wifi.ControlarRadioWiFi(false);
            wifi = null;            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.lblMensagem.Top = this.lblUsuario.Top;
            txtUsuario.Text = "";
            txtSenha.Text = "";
            lblVersao.Text = "Versão:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblNumeroColetor.Text = "Coletor " + new Symbol.ResourceCoordination.TerminalInfo().ESN;

            txtUsuario.Focus();
        }
        
        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(27))
                btnSair_Click(sender, e);
        }               
        
        #endregion

        #region [ METHODS ]

        private void AtivaCampos(bool ativa)
        {
            try
            {
                //Ativa ou desativa os campos durante a conexão com o web service
                this.btnOK.Visible = ativa;
                this.btnOK.Enabled = ativa;
                this.btnSair.Visible = ativa;
                this.btnSair.Enabled = ativa;
                this.lblUsuario.Visible = ativa;
                this.lblSenha.Visible = ativa;
                this.txtUsuario.Visible = ativa;
                this.txtUsuario.Enabled = ativa;
                this.txtSenha.Visible = ativa;
                this.txtSenha.Enabled = ativa;
                this.lblMensagem.Visible = !ativa;
                this.Refresh();
            }
            catch (Exception)
            {
            }
        }

        private void VerificaBateria()
        {
            try
            {
                Bateria bateria = new Bateria();
                picBateria.Image = bateria.BatteryImage();
                lblBateria.Text = bateria.BatteryLifePercent.ToString() + "%";
                lblBateria.Refresh();
            }
            catch { /*Não importa*/ }
        }

        #endregion

        #region [ CONTROLS ]

        private void txtUsuario_GotFocus(object sender, EventArgs e)
        {
            this.txtUsuario.SelectAll();
        }

        private void txtSenha_GotFocus(object sender, EventArgs e)
        {
            this.txtSenha.SelectAll();
        }

        private void timStatusConexao_Tick(object sender, EventArgs e)
        {
            try
            {
                timStatusConexao.Enabled = false;
                VerificaBateria();
                timStatusConexao.Enabled = true;
            }
            catch
            {
            }
        }

        private void frmLogin_Closed(object sender, EventArgs e)
        {
            timStatusConexao.Dispose();
        }

        private void FocusOn()
        {
            txtUsuario.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtSenha.GotFocus += new EventHandler(Program.txtBox_focusOn);
            btnSair.GotFocus += new EventHandler(Program.btn_focusOn);
            btnOK.GotFocus += new EventHandler(Program.btn_focusOn);
            btnSincronismo.GotFocus += new EventHandler(Program.btn_focusOn);
        }

        private void FocusOff()
        {
            txtUsuario.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtSenha.LostFocus += new EventHandler(Program.txtBox_focusOff);
            btnSair.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            btnOK.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            btnSincronismo.LostFocus += new EventHandler(Program.btn_focusOffAzul);
        }

        private void KeyDownTecla()
        {
            //Only button and check
            btnSair.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnOK.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnSincronismo.KeyDown += new KeyEventHandler(Program.btn_enter);
        }

        private void KeyUpTecla()
        {           
            txtUsuario.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtSenha.KeyUp += new KeyEventHandler(Program.txtBox_next);
            btnSair.KeyUp += new KeyEventHandler(btn_nextsair);
            btnOK.KeyUp += new KeyEventHandler(Program.btn_next);
            btnSincronismo.KeyUp += new KeyEventHandler(btn_nextsincronismo);
        }

        public void btn_nextsair(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSincronismo.Focus();
            }
        }        

        public void btn_nextsincronismo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                txtUsuario.Focus();
            }
        }

        #endregion

        #region [ BUTTONS ]

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                MostraCursor.CursorAguarde(true);

                if (txtUsuario.Text.Trim() == String.Empty)
                    throw new Exception("Os campos usuário é de preenchimento obrigatório!");

                if (txtSenha.Text.Trim() == String.Empty)
                    throw new Exception("Os campos senha é de preenchimento obrigatório!");

                if (!Convert.ToBoolean(LerGravarXML.ObterValor("ColetorAtivo", "false")))
                    throw new Exception("O coletor está bloqueado. Favor Procurar uma filial.");

                if (!ControllerUsuario.LoginVerificar(txtUsuario.Text.Trim()))
                    throw new Exception("O usuário não está associado ao coletor.");

                if (!ControllerUsuario.LoginSistema(txtUsuario.Text.Trim(), txtSenha.Text.Trim()))
                    throw new Exception("Senha inválida.");

                DataTable tableParametro = ControllerParametro.SelecioneParametros();
                DateTime dataUltima = DateTime.ParseExact(LerGravarXML.ObterValor("UltimaAtualizacao", "01/01/01"), "dd/MM/yy", null);
                if (tableParametro.Rows.Count > 0)
                {
                    int prazoSincronismo = Convert.ToInt32(tableParametro.Rows[0]["PrazoSincronismoDia"]);
                    if (dataUltima.AddDays(prazoSincronismo) < DateTime.Now)
                        throw new Exception("O coletor está com prazo de dias sem sincronismo expirado. Favor Procurar uma filial.");
                }

                if (DateTime.Now.Year > 2007)
                    DataHora.AcertaDataHora(DateTime.Now);
                else
                    DataHora.AcertaDataHora(dataUltima);

                MostraCursor.CursorAguarde(false);

                FileInfo bancoCorreio = new FileInfo(Program.ARQUIVO_CORREIO);
                if (!bancoCorreio.Exists)
                {
                    if (CaixaMensagem.ExibirSimNao("Não foi identificado nenhum banco de correio, deseja continuar?") == RespostaCaixaMensagem.Nao)
                        return;
                }

                Program.AbreForm<frmMenuAcesso>();
            }
            catch (Exception ex)
            {
                MostraCursor.CursorAguarde(false);
                CaixaMensagem.ExibirErro(ex.Message, "Erro Login");
            }
        }
        
        private void picSincronismo_Click(object sender, EventArgs e)
        {
            Program.AbreForm<frmAtualizacao>();
        }

        #endregion  
    }
}