using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Configuration;
using System.Reflection;
using System.Web.Security;
using System.Text;
using ProjetoWeb.Util;
using ProjetoVO;
using ProjetoController;

namespace ProjetoWeb
{
    public class PaginaBase : System.Web.UI.Page
    {
        #region [ PROPERTIES ]

        public int CodigoUsuario
        {
            get { return Sessao.UsuarioLogado.IDUsuario ; }
        }

        public Util.Util.Cargo TipoUsuario
        {
            get { return Sessao.TipoUsuario; }
        }
                      
        public string MensagemAlterar
        {
            get { return "Registro alterado com sucesso!";}
        }

        public string MensagemExcluir
        {
            get { return "Registro excluído com sucesso!"; }
        }

        public string MensagemIncluir
        {
            get { return "Registro incluído com sucesso!"; }
        }

        public void ControleAcesso(Util.Util.Funcionalidade Tela, Util.Util.Cargo Perfil)
        {
            if (!Util.Util.ControleAcesso(Tela, Perfil))
            {
                Response.Redirect("login.aspx");
            }
        }

        #endregion

        #region [ SIZE DYNAMIC CONTENT ]

        public const string divConteudo = "trConteudo";
        public const string ct100_divConteudo = "ctl00_trConteudo";
        
        private System.Collections.Generic.List<string> _scripts = new System.Collections.Generic.List<string>();

        public System.Collections.Generic.List<string> ListaDeScripts
        {
            get { return _scripts; }
            set { _scripts = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
                 
            PreRenderComplete += PaginaBase_PreRenderComplete;
        }

        protected void PaginaBase_PreRenderComplete(object sender, EventArgs e)
        {            
           ScriptManager.RegisterClientScriptBlock(this, GetType(), "TamanhoForm", "Sys.Application.add_init(function() { AlturaDoFormPrincipal('" + divConteudo + "','"+ct100_divConteudo+"',110);});", true);
            
           RegistrarClientScript();

           RegistraScriptAguarde();
        }

        private void RegistrarClientScript()
        {
            ListaDeScripts.ForEach(a => ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToBinary().ToString(), a, true));
        }

        public virtual void RegistraScriptAguarde()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "FinalizaAguarde", "$.unblockUI();", true);
            ScriptManager.RegisterOnSubmitStatement(this, GetType(), "Aguarde", " if (typeof(document.forms[0]) == 'undefined' || document.forms[0].target !='_blank') Aguarde();");
        }
                
        #endregion               
    }
}
