using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoVO;
using ProjetoController;
using WebControls;

namespace ProjetoWeb
{
    public partial class consultaColetor : PaginaBase
    {
        #region [ PROPERTIES ]

        private TColetorCONTROLLER controller;

        public TColetorCONTROLLER Controller
        {
            get
            {
                if (controller == null)
                    controller = new TColetorCONTROLLER();

                return controller;

            }
        }
             
        #endregion
        
        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.ControleAcesso(Util.Util.Funcionalidade.COLETORCADASTRO, TipoUsuario);

                CarregarGrid();
            }
        }

        #endregion

        #region [ METHODS ]

        private void CarregarGrid()
        {
            try
            {
                List<TColetorVO> listaConsulta = Controller.Listar(PreencheVO());

                gridConsulta.DataSource = listaConsulta;
                gridConsulta.DataBind();
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

        private TColetorVO PreencheVO()
        {
            TColetorVO coletorVO = new TColetorVO();

            coletorVO.NumeroSerie = txtNumeroSerie.Text;
            coletorVO.IMEI = txtIMEI.Text;
            coletorVO.Fabricante = txtFabricante.Text;
            coletorVO.Modelo = txtModelo.Text;
            

            coletorVO.ConsultaAtivo = rdbAtivoTodos.Checked? false: true ;
            coletorVO.Ativo = rdbAtivoSim.Checked;

            coletorVO.ConsultaUsoBackup = rdbUsoBackupTodos.Checked ? false : true;
            coletorVO.UsoBackup = rdbUsoBackupSim.Checked;

            return coletorVO;
        }

        #endregion

        #region [ GRIDVIEW ]

        protected void gridConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Response.Redirect("~/cadastroColetor.aspx?codigo=" + gridConsulta.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                }
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

        protected void gridConsulta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
               Controller.Excluir(Convert.ToInt32(gridConsulta.DataKeys[Convert.ToInt32(e.RowIndex)].Value));
               
               CarregarGrid();

               this.MostrarMensagem(this.MensagemExcluir);
            }
            catch
            {
                e.Cancel = true;
            }
        }

        protected void gridConsulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridConsulta.PageIndex = e.NewPageIndex;

            CarregarGrid();
        }

        protected void gridConsulta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgExcluir = (ImageButton)e.Row.Cells[1].Controls[0];
                if (imgExcluir != null && imgExcluir.CommandName == "Delete")
                    imgExcluir.OnClientClick = "return ExibirMensagemConfirmacaoGridView('" + gridConsulta.UniqueID + "','" + imgExcluir.CommandArgument + "');";
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
