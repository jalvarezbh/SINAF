using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoWeb.Util;

namespace ProjetoWeb.Controle
{
    public partial class Menu : System.Web.UI.UserControl
    {
        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {
            bool indicadorMobile = Request.Browser.IsMobileDevice;
            CarregaMenu(new ProjetoController.TMenuCONTROLLER().ListarMenuUsuarioXML(Sessao.UsuarioLogado.IDUsuario, indicadorMobile));

            Page.PreRenderComplete += new EventHandler(Page_PreRenderComplete);
        }

        #endregion

        #region [ PAGE PRERENDER ]

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {          
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "DivMenu", "Sys.Application.add_init(function() { ModificarCSS('" + MenuPrincipal.ClientID + "', 'divMenu'); });", true);
        }

        #endregion

        #region [ METHODS ]

        private void CarregaMenu(String itens)
        {
            if (!string.IsNullOrEmpty(itens))
            {
                xmlDataSource.Data = itens;
                MenuSistema.DataBind();
            }
        }

        #endregion
    }
}