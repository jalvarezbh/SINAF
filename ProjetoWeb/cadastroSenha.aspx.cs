using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoVO;
using ProjetoController;
using ProjetoWeb.Util;
using WebControls;

namespace ProjetoWeb
{
    public partial class cadastroSenha : PaginaBase
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
            if (!IsPostBack)
                this.ControleAcesso(Util.Util.Funcionalidade.CONFIGURACAOMUDARSENHA, TipoUsuario);
        }

        #endregion

        #region [ BUTTONS ]

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                trMensagemPageCadastro.Visible = false;
                Controller.AlterarSenha(Sessao.UsuarioLogado,txtSenhaAtual.Text, txtSenhaNova.Text, txtCofirmarSenha.Text);
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

        #endregion        
    }
}
