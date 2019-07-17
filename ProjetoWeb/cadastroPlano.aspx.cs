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
    public partial class cadastroPlano : PaginaBase
    {
        #region [ PROPERTIES ]

        private TPlanoProtecaoCONTROLLER controllerPlanoProtecao;

        public TPlanoProtecaoCONTROLLER ControllerPlanoProtecao
        {
            get
            {
                if (controllerPlanoProtecao == null)
                    controllerPlanoProtecao = new TPlanoProtecaoCONTROLLER();

                return controllerPlanoProtecao;

            }
        }

        private TPlanoSeniorCONTROLLER controllerPlanoSenior;

        public TPlanoSeniorCONTROLLER ControllerPlanoSenior
        {
            get
            {
                if (controllerPlanoSenior == null)
                    controllerPlanoSenior = new TPlanoSeniorCONTROLLER();

                return controllerPlanoSenior;

            }
        }

        private TPlanoCasalCONTROLLER controllerPlanoCasal;

        public TPlanoCasalCONTROLLER ControllerPlanoCasal
        {
            get
            {
                if (controllerPlanoCasal == null)
                    controllerPlanoCasal = new TPlanoCasalCONTROLLER();

                return controllerPlanoCasal;

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
            imgDownloadPF.Attributes.Add("onclick", "IDActiveElement = this.id;");
            imgDownloadPF.Attributes.Add("AbrirEmNovaJanela", "true");
            imgDownloadAS.Attributes.Add("onclick", "IDActiveElement = this.id;");
            imgDownloadAS.Attributes.Add("AbrirEmNovaJanela", "true");
            imgDownloadASC.Attributes.Add("onclick", "IDActiveElement = this.id;");
            imgDownloadASC.Attributes.Add("AbrirEmNovaJanela", "true");
            imgExemploProtecao.Attributes.Add("onclick", "IDActiveElement = this.id;");
            imgExemploProtecao.Attributes.Add("AbrirEmNovaJanela", "true");
            imgExemploSenior.Attributes.Add("onclick", "IDActiveElement = this.id;");
            imgExemploSenior.Attributes.Add("AbrirEmNovaJanela", "true");
            imgExemploCasal.Attributes.Add("onclick", "IDActiveElement = this.id;");
            imgExemploCasal.Attributes.Add("AbrirEmNovaJanela", "true");
        }

        #endregion

        #region [ BUTTONS ]

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void imgUploadPF_Click(object sender, ImageClickEventArgs e)
        {
            if (fupUploadPF.HasFile)
            {
                lblMSGUploadPF.Text = "Inicio do Processo.";

                try
                {

                    Util.Util.VerificarTamanhoArquivo(fupUploadPF.PostedFile.ContentLength);

                    if (string.IsNullOrEmpty(WebConfigurationManager.AppSettings["ExcelUPLOAD"]))
                        throw new CABTECException("O valor para chave ExcelUPLOAD não foi infomado no web.config");

                    string caminhoArquivosExcel = WebConfigurationManager.AppSettings["ExcelUPLOAD"];
                    caminhoArquivosExcel = HttpContext.Current.Server.MapPath(caminhoArquivosExcel + "\\" + fupUploadPF.FileName);

                    Util.Util.SalvarArquivo("ExcelUPLOAD", fupUploadPF);

                    ControllerPlanoProtecao.ImportarArquivo("ExcelUPLOAD", fupUploadPF.FileName);

                    lblMSGUploadPF.Text = "Processo realizado com sucesso.";

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
                    Util.Util.ExcluirArquivo("ExcelUPLOAD", fupUploadPF.FileName);
                }
            }
        }

        protected void imgUploadAS_Click(object sender, ImageClickEventArgs e)
        {
            if (fupUploadAS.HasFile)
            {
                lblMSGUploadAS.Text = "Inicio do Processo.";

                try
                {

                    Util.Util.VerificarTamanhoArquivo(fupUploadAS.PostedFile.ContentLength);

                    if (string.IsNullOrEmpty(WebConfigurationManager.AppSettings["ExcelUPLOAD"]))
                        throw new CABTECException("O valor para chave ExcelUPLOAD não foi infomado no web.config");

                    string caminhoArquivosExcel = WebConfigurationManager.AppSettings["ExcelUPLOAD"];
                    caminhoArquivosExcel = HttpContext.Current.Server.MapPath(caminhoArquivosExcel + "\\" + fupUploadAS.FileName);

                    Util.Util.SalvarArquivo("ExcelUPLOAD", fupUploadAS);

                    ControllerPlanoSenior.ImportarArquivo("ExcelUPLOAD", fupUploadAS.FileName);

                    lblMSGUploadAS.Text = "Processo realizado com sucesso.";

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
                    Util.Util.ExcluirArquivo("ExcelUPLOAD", fupUploadAS.FileName);
                }
            }
        }

        protected void imgUploadASC_Click(object sender, ImageClickEventArgs e)
        {
            if (fupUploadASC.HasFile)
            {
                lblMSGUploadASC.Text = "Inicio do Processo.";

                try
                {

                    Util.Util.VerificarTamanhoArquivo(fupUploadASC.PostedFile.ContentLength);

                    if (string.IsNullOrEmpty(WebConfigurationManager.AppSettings["ExcelUPLOAD"]))
                        throw new CABTECException("O valor para chave ExcelUPLOAD não foi infomado no web.config");

                    string caminhoArquivosExcel = WebConfigurationManager.AppSettings["ExcelUPLOAD"];
                    caminhoArquivosExcel = HttpContext.Current.Server.MapPath(caminhoArquivosExcel + "\\" + fupUploadASC.FileName);

                    Util.Util.SalvarArquivo("ExcelUPLOAD", fupUploadASC);

                    ControllerPlanoCasal.ImportarArquivo("ExcelUPLOAD", fupUploadASC.FileName);

                    lblMSGUploadASC.Text = "Processo realizado com sucesso.";

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
                    Util.Util.ExcluirArquivo("ExcelUPLOAD", fupUploadASC.FileName);
                }
            }
        }

        protected void imgDownloadPF_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Util.Util.DownloadArquivo(this.Page, "CaminhoArquivosDownload", "TemplatePlanoFamilia.xls");
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

        protected void imgDownloadAS_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Util.Util.DownloadArquivo(this.Page, "CaminhoArquivosDownload", "TemplatePlanoSenior.xls");
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

        protected void imgDownloadASC_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Util.Util.DownloadArquivo(this.Page, "CaminhoArquivosDownload", "TemplatePlanoSeniorCasal.xls");
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

        protected void imgExemploProtecao_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Util.Util.DownloadArquivo(this.Page, "CaminhoArquivosDownload", "ExemploTemplatePlanoFamilia.xls");
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

        protected void imgExemploSenior_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Util.Util.DownloadArquivo(this.Page, "CaminhoArquivosDownload", "ExemploTemplatePlanoSenior.xls");
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

        protected void imgExemploCasal_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Util.Util.DownloadArquivo(this.Page, "CaminhoArquivosDownload", "ExemploTemplatePlanoSeniorCasal.xls");
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