using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoVO;
using ProjetoController;
using WebControls;
using ProjetoWeb.Util;

namespace ProjetoWeb
{
    public partial class login : PaginaBase
    {
        #region [ PROPERTIES ]

        private TUsuarioCONTROLLER controller;

        public TUsuarioCONTROLLER Controller
        {
            get
            {
                if (controller == null)
                    controller = new TUsuarioCONTROLLER();

                return controller;

            }
        }

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region [ METHODS ]

        private void FecharNovaSenha()
        {
            trMensagemNovaSenha.Visible = false;
            txtSenhaNova.Text = string.Empty;
            txtSenhaConfirmar.Text = string.Empty;
            pnlDefinirSenha.Visible = false;
        }

        #endregion

        #region [ BUTTONS ]

        protected void linkEsqueciSenha_Click(object sender, EventArgs e)
        {
            try
            {
                trMensagemPageCadastro.Visible = false;
                Controller.EnvioSenha(txtLogin.Text);
                MostrarMensagem("Uma nova senha foi enviada ao e-mail cadastrado.");

            }
            catch (CABTECException ex)
            {
                this.MostrarMensagem(ex.Message);
            }
            catch (Exception exception)
            {
                this.MostrarMensagem(exception.Message);
            }

        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                trMensagemPageCadastro.Visible = false;
                Sessao.UsuarioLogado = Controller.ValidarAcesso(txtLogin.Text, txtSenha.Text);
                if (Sessao.UsuarioLogado.PrimeiroAcesso)
                    pnlDefinirSenha.Visible = true;
                else
                    Response.Redirect("default.aspx");
            }
            catch (CABTECException ex)
            {
                this.MostrarMensagem(ex.Message);
            }
            catch (Exception exception)
            {
                this.MostrarMensagem(exception.Message);
            }
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            FecharNovaSenha();
        }

        protected void btnMudarSenha_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                trMensagemPageCadastro.Visible = false;
                Controller.ValidarMudarSenha(Sessao.UsuarioLogado, txtSenhaNova.Text, txtSenhaConfirmar.Text);
                FecharNovaSenha();
                MostrarMensagem("Senha alterada com sucesso!");
            }
            catch (CABTECException ex)
            {
                this.MostrarMensagem(ex.Message);
            }
            catch (Exception exception)
            {
                this.MostrarMensagem(exception.Message);
            }
        }
       
        #endregion

        #region [ MESSAGE ]

        public void MostrarMensagem(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem))
            {
                trMensagemPageCadastro.Visible = true;
                imgMensagem.ImageUrl = "~/Images/info20.ico";
                lblMensagem.Text = mensagem;
                trMensagemPageCadastro.Focus();
            }
        }
              
        public void MostrarMensagemNova(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem))
            {
                trMensagemNovaSenha.Visible = true;
                imgMensagemNovaSenha.ImageUrl = "~/Images/info20.ico";
                lblMensagemNovaSenha.Text = mensagem;
                trMensagemNovaSenha.Focus();
            }
        }

        #endregion        
    }
}
