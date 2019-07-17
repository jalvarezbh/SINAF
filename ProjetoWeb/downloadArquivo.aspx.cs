using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ProjetoWeb
{
    public partial class downloadArquivo : System.Web.UI.Page
    {
        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["caminho"]))
                {
                    string caminhoArquivo = Request.QueryString["caminho"].ToString();

                    FileInfo info = new FileInfo(caminhoArquivo);
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=\"" + info.Name + "\"");
                    Response.Charset = "utf8";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/octet-stream";
                    Response.Flush();
                    Response.WriteFile(info.FullName);
                    Response.Flush();
                    Response.Close();
                                       
                }
            }
        }
        
        #endregion
    }
}
