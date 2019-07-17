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
using System.Web.Configuration;

namespace ProjetoWeb
{
    public partial class cadastroFilial : PaginaBase
    {
        #region [ PROPERTIES ]

        private TAtendimentoCONTROLLER controller;

        public TAtendimentoCONTROLLER Controller
        {
            get
            {
                if (controller == null)
                    controller = new TAtendimentoCONTROLLER();

                return controller;

            }
        }              

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ControleAcesso(Util.Util.Funcionalidade.CONFIGURACAOFILIALCADASTRO, TipoUsuario);
                DownloadNovaJanela();
            }
        }
        
        #endregion

        #region [ METHODS ]

        private void DownloadNovaJanela()
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "AbrirEmNovaJanela" + ClientID, ScriptComponentes.scriptAbrirEmNovaJanela, true);
            ScriptManager.RegisterOnSubmitStatement(this, GetType(), "AbrirEmNovaJanela", "AbrirEmNovaJanela();");
            imgDownload.Attributes.Add("onclick", "IDActiveElement = this.id;");
            imgDownload.Attributes.Add("AbrirEmNovaJanela", "true");
        }

        #endregion

        #region [ BUTTONS ]

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void imgUpload_Click(object sender, ImageClickEventArgs e)
        {
            if (fupUpload.HasFile)
            {
                txtUploadProgress.Text = "Inicio do Processo.\r\n";
               
                try
                {                    
                    
                    Util.Util.VerificarTamanhoArquivo(fupUpload.PostedFile.ContentLength);

                    if (string.IsNullOrEmpty(WebConfigurationManager.AppSettings["ExcelUPLOAD"]))
                        throw new CABTECException("O valor para chave ExcelUPLOAD não foi infomado no web.config");

                    string caminhoArquivosExcel = WebConfigurationManager.AppSettings["ExcelUPLOAD"];
                    caminhoArquivosExcel = HttpContext.Current.Server.MapPath(caminhoArquivosExcel + "\\" + fupUpload.FileName);

                    Util.Util.SalvarArquivo("ExcelUPLOAD", fupUpload);

                    txtUploadProgress.Text += "Salvar Arquivo no Servidor.\r\n";

                    int numeroIncluido = 0;
                    int numeroNaoIncluido = 0;

                    Controller.ImportarArquivo("ExcelUPLOAD", fupUpload.FileName, ref numeroIncluido, ref numeroNaoIncluido);

                    txtUploadProgress.Text += "Salvar Dados no Banco.\r\n";

                    txtUploadProgress.Text += "Número de Registro Incluídos: " + numeroIncluido + ".\r\n";

                    txtUploadProgress.Text += "Número de Registro Não Incluídos: " + numeroNaoIncluido + ".\r\n";

                    MostrarMensagem("Importação realizada com sucesso.");
                }
                catch (CABTECException exception)
                {
                    MostrarMensagem(exception.Message);
                }
                catch (Exception ex)
                {
                    MostrarMensagem(ex.Message);
                }
                finally
                {
                    Util.Util.ExcluirArquivo("ExcelUPLOAD", fupUpload.FileName);

                    txtUploadProgress.Text += "Excluir Arquivo no Servidor.\r\n";

                    txtUploadProgress.Text += "Fim do Processo.";
                }
            }
        }

        protected void imgDownload_Click(object sender, ImageClickEventArgs e)
        {
            try
            {              
                Util.Util.DownloadArquivo(this.Page, "CaminhoArquivosDownload", "TemplateFilial.xls");
             }
            catch (CABTECException exception)
            {
                MostrarMensagem(exception.Message);
            }
            catch (Exception ex)
            {
                MostrarMensagem(ex.Message);
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
