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
    public partial class relatorioColetor : PaginaBase
    {
        #region [ PROPERTIES ]

        private HistoricoTColetorCONTROLLER controller;

        public HistoricoTColetorCONTROLLER Controller
        {
            get
            {
                if (controller == null)
                    controller = new HistoricoTColetorCONTROLLER();

                return controller;

            }
        }

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //this.ControleAcesso(Util.Util.Funcionalidade.COLETORCADASTRO, TipoUsuario);

                CarregarGrid();
            }
        }

        #endregion

        #region [ METHODS ]

        private void CarregarGrid()
        {
            try
            {
                List<HistoricoTColetorVO> listaConsulta = Controller.ListarRelatorio(PreencheVO());

                rptColetor.DataSource = listaConsulta;
                rptColetor.DataBind();
                MostrarMensagem(string.Empty);
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

        private HistoricoTColetorVO PreencheVO()
        {
            HistoricoTColetorVO historicoColetorVO = new HistoricoTColetorVO();

            historicoColetorVO.Vendedor = txtVendedor.Text;
            historicoColetorVO.NumeroColetor = txtColetor.Text;
            historicoColetorVO.DataRelatorioInicio = string.IsNullOrEmpty(txtDataInicial.Text) ? new DateTime?() : Convert.ToDateTime(txtDataInicial.Text);
            historicoColetorVO.DataRelatorioFinal = string.IsNullOrEmpty(txtDataFinal.Text) ? new DateTime?() : Convert.ToDateTime(txtDataFinal.Text);

            return historicoColetorVO;
        }

        #endregion

        #region [ REPEATER ]

        protected void rptColetor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton numeroColetor = (LinkButton)e.Item.FindControl("itemNumColetor");

                numeroColetor.Text = ((HistoricoTColetorVO)(e.Item.DataItem)).NumeroColetor;
                numeroColetor.CommandArgument = ((HistoricoTColetorVO)(e.Item.DataItem)).IDHistoricoColetor.ToString();

                Repeater repeaterSincronismo = (Repeater)e.Item.FindControl("rptSincronismo");
                numeroColetor.CommandName = repeaterSincronismo.ID;
                repeaterSincronismo.Visible = false;

                Label dataUltimo = (Label)e.Item.FindControl("itemDataUltimo");

                dataUltimo.Text = ((HistoricoTColetorVO)(e.Item.DataItem)).DataUltimoSincronismo.ToString("dd/MM/yyyy");

                Label totalSincronismo = (Label)e.Item.FindControl("itemTotalSincronismo");

                totalSincronismo.Text = ((HistoricoTColetorVO)(e.Item.DataItem)).NumeroTotalSincronismo.ToString();

                Label totalEntrevista = (Label)e.Item.FindControl("itemTotalEntrevista");

                totalEntrevista.Text = ((HistoricoTColetorVO)(e.Item.DataItem)).NumeroTotalEntrevista.ToString();

            }
        }

        protected void rptSincronismo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label dataSincronismo = (Label)e.Item.FindControl("itemDataSincronismo");

                dataSincronismo.Text = ((HistoricoTSincronismoVO)(e.Item.DataItem)).DataSincronismo.ToString("dd/MM/yyyy");

                LinkButton numeroUpload = (LinkButton)e.Item.FindControl("itemNumeroUpload");

                numeroUpload.Text = ((HistoricoTSincronismoVO)(e.Item.DataItem)).NumeroUpload.ToString();

                numeroUpload.CommandArgument = ((HistoricoTSincronismoVO)(e.Item.DataItem)).IDHistoricoSincronismo.ToString();

                Repeater repeaterUpdate = (Repeater)e.Item.FindControl("rptUpload");
                numeroUpload.CommandName = repeaterUpdate.ID;
                repeaterUpdate.Visible = false;

                LinkButton numeroDownload = (LinkButton)e.Item.FindControl("itemNumeroDownload");

                numeroDownload.Text = ((HistoricoTSincronismoVO)(e.Item.DataItem)).NumeroDownload.ToString();

                numeroDownload.CommandArgument = ((HistoricoTSincronismoVO)(e.Item.DataItem)).IDHistoricoSincronismo.ToString();

                Repeater repeaterDownload = (Repeater)e.Item.FindControl("rptDownload");
                numeroDownload.CommandName = repeaterDownload.ID;
                repeaterDownload.Visible = false;
            }
        }

        protected void rptUpload_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label entrevistaUpload = (Label)e.Item.FindControl("itemEntrevistaUpload");

                entrevistaUpload.Text = ((HistoricoTEntrevistaUploadVO)(e.Item.DataItem)).CodigoEntrevista.ToString();
            }
        }

        protected void rptDownload_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label entrevistaDownload = (Label)e.Item.FindControl("itemEntrevistaDownload");

                entrevistaDownload.Text = ((HistoricoTEntrevistaDownloadVO)(e.Item.DataItem)).CodigoEntrevista.ToString();
            }
        }

        protected void lnkColetor_Click(object sender, EventArgs e)
        {
            Repeater repeaterSincronismo = (Repeater)((LinkButton)sender).FindControl(((LinkButton)sender).CommandName);

            if (repeaterSincronismo.Visible)
            {
                repeaterSincronismo.Visible = false;
            }
            else
            {
                repeaterSincronismo.Visible = true;
                HistoricoTSincronismoCONTROLLER sincronismoController = new HistoricoTSincronismoCONTROLLER();
                HistoricoTSincronismoVO sincronismoVO = new HistoricoTSincronismoVO();

                sincronismoVO.IDHistoricoColetor = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                sincronismoVO.NomeVendedor = txtVendedor.Text;
                sincronismoVO.DataRelatorioInicio = string.IsNullOrEmpty(txtDataInicial.Text) ? new DateTime?() : Convert.ToDateTime(txtDataInicial.Text);
                sincronismoVO.DataRelatorioFinal = string.IsNullOrEmpty(txtDataFinal.Text) ? new DateTime?() : Convert.ToDateTime(txtDataFinal.Text);

                repeaterSincronismo.DataSource = sincronismoController.Listar(sincronismoVO);
                repeaterSincronismo.DataBind();
            }
        }

        protected void lnkUpload_Click(object sender, EventArgs e)
        {
            Repeater repeaterUpload = (Repeater)((LinkButton)sender).FindControl(((LinkButton)sender).CommandName);

            if (repeaterUpload.Visible)
            {
                repeaterUpload.Visible = false;
            }
            else
            {
                repeaterUpload.Visible = true;
                HistoricoTEntrevistaUploadCONTROLLER uploadController = new HistoricoTEntrevistaUploadCONTROLLER();
                HistoricoTEntrevistaUploadVO uploadVO = new HistoricoTEntrevistaUploadVO();

                uploadVO.IDHistoricoSincronismo = Convert.ToInt32(((LinkButton)sender).CommandArgument);

                repeaterUpload.DataSource = uploadController.Listar(uploadVO);
                repeaterUpload.DataBind();
            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            Repeater repeaterDownload = (Repeater)((LinkButton)sender).FindControl(((LinkButton)sender).CommandName);

            if (repeaterDownload.Visible)
            {
                repeaterDownload.Visible = false;
            }
            else
            {
                repeaterDownload.Visible = true;
                HistoricoTEntrevistaDownloadCONTROLLER downloadController = new HistoricoTEntrevistaDownloadCONTROLLER();
                HistoricoTEntrevistaDownloadVO downloadVO = new HistoricoTEntrevistaDownloadVO();

                downloadVO.IDHistoricoSincronismo = Convert.ToInt32(((LinkButton)sender).CommandArgument);

                repeaterDownload.DataSource = downloadController.Listar(downloadVO);
                repeaterDownload.DataBind();
            }
        }

        #endregion

        #region [ BUTTONS ]

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btnNovo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastroColetor.aspx");
        }

        protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CarregarGrid();
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
            else
            {
                trMensagemPageCadastro.Visible = false;
            }
        }

        #endregion
    }
}