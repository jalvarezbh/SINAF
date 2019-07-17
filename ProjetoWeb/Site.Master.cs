using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoWeb.Util;

namespace ProjetoWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                labelPrincipalUsuarioLogado.Text = Sessao.UsuarioLogado.Nome;

        }

        protected void linkbuttonPrincipalSair_Click(object sender, EventArgs e)
        {
            Sessao.Logoff();
        }
                      
    }
}
