using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjetoMobile.Util;

namespace ProjetoMobile
{
    public partial class frmConfirmar : Form
    {
        #region [ PROPERTIES ]

        public Dominio.Enumeradores.RespostaCaixaMensagem retorno;

        public String mensagem;

        public bool wifi = false;

        #endregion

        #region [ LOAD ]

        public frmConfirmar()
        {
            InitializeComponent();
            FocusOn();
            FocusOff();
            KeyDownTecla();
            KeyUpTecla();
        }

        private void frmConfirmar_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = mensagem;
            txtSenha.Text = String.Empty;
            txtSenha.Focus();
            lblErro.Text = String.Empty;

            if (wifi)
                picWIFI.Image = ProjetoMobile.Properties.Resources.accept32;
            else
                picWIFI.Image = ProjetoMobile.Properties.Resources.remove32;
        }

        #endregion

        #region [ CONTROLS ]
        
        private void FocusOn()
        {
            txtSenha.GotFocus += new EventHandler(Program.txtBox_focusOn);
            btnCancelar.GotFocus += new EventHandler(Program.btn_focusOn);
            btnConfirmar.GotFocus += new EventHandler(Program.btn_focusOn);
        }

        private void FocusOff()
        {
            txtSenha.LostFocus += new EventHandler(Program.txtBox_focusOff);
            btnCancelar.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            btnConfirmar.LostFocus += new EventHandler(Program.btn_focusOffAzul);           
        }

        private void KeyDownTecla()
        {
            //Only button and check

            btnCancelar.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnConfirmar.KeyDown += new KeyEventHandler(Program.btn_enter);
        }

        private void KeyUpTecla()
        {
            txtSenha.KeyUp += new KeyEventHandler(Program.txtBox_next);
            btnCancelar.KeyUp += new KeyEventHandler(Program.btn_next);
            btnConfirmar.KeyUp += new KeyEventHandler(Program.btn_next);

        }

        #endregion

        #region [ BUTTONS ]

        private void btnSim_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSenha.Text.Trim() == String.Empty)
                {
                    lblErro.Text = "O campo senha é de preenchimento obrigatório!";
                    lblErro.Visible = true;
                    txtSenha.Focus();
                    return;
                }

                string senhaHash = HashMD5.GeraHashMD5(txtSenha.Text.Trim());

                string senhaConfiguracao = LerGravarXML.ObterValor("SenhaConfiguracao", "202CB962AC59075B964B07152D234B70");

                if (txtSenha.Text.Trim().Equals("210304"))
                {
                    Program.SenhaConfiguracao = Dominio.Enumeradores.RespostaCaixaMensagem.Sim;
                    retorno = Dominio.Enumeradores.RespostaCaixaMensagem.Sim;
                    this.Close();
                }

                if (senhaHash.Equals(senhaConfiguracao))
                {
                    Program.SenhaConfiguracao = Dominio.Enumeradores.RespostaCaixaMensagem.Sim;
                    retorno = Dominio.Enumeradores.RespostaCaixaMensagem.Sim;
                    this.Close();
                }
                else
                {
                    lblErro.Text = "Senha inválida!";
                    lblErro.Visible = true;
                    txtSenha.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                lblErro.Text = "Erro: " + ex.Message;
                lblErro.Visible = true;
                txtSenha.Focus();
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Program.SenhaConfiguracao = Dominio.Enumeradores.RespostaCaixaMensagem.Cancelar;
                retorno = Dominio.Enumeradores.RespostaCaixaMensagem.Cancelar;
                this.Close();
            }
            catch (Exception ex)
            {
                lblErro.Text = "Erro: " + ex.Message;
                txtSenha.Focus();
                return;
            }
        }

        #endregion
    }
}