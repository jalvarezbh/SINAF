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
using System.Data;

namespace ProjetoWeb
{
    public partial class cadastroPerfilCargo : PaginaBase
    {
        #region [ PROPERTIES ]

        private TPerfilCONTROLLER controller;

        public TPerfilCONTROLLER Controller
        {
            get
            {
                if (controller == null)
                    controller = new TPerfilCONTROLLER();

                return controller;

            }
        }

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //this.ControleAcesso(Util.Util.Funcionalidade.AGENDAMENTOCONSULTA, TipoUsuario);

                PreencheCombo();
                CarregarGrid();
            }
        }
     
        #endregion

        #region [ METHODS ]

        private void PreencheCombo()
        {
            ddlPerfil.DataTextField = "Descricao";
            ddlPerfil.DataValueField = "IDPerfil";
            TPerfilVO filtro = new TPerfilVO();
            filtro.Ativo = true;
            List<TPerfilVO> perfilList = Controller.Listar(filtro);
            perfilList.Insert(0, new TPerfilVO());
            ddlPerfil.DataSource = perfilList;
            ddlPerfil.DataBind();
        }

        private void CarregarGrid()
        {
            try
            {
                List<TPerfilVO> listaConsulta = Controller.ListarPerfilCargo(PreencheVO());

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

        private TPerfilVO PreencheVO()
        {
            TPerfilVO perfilVO = new TPerfilVO();

            perfilVO.IDPerfil = string.IsNullOrEmpty(ddlPerfil.SelectedValue)?0: Convert.ToInt32(ddlPerfil.SelectedValue);
            perfilVO.NomeCargo = txtCargo.Text;
            perfilVO.Ativo = true;

            return perfilVO;
        }

        #endregion

        #region [ GRIDVIEW ]
             
        protected void gridConsulta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Controller.ExcluirPerfilCargo(Convert.ToInt32(gridConsulta.DataKeys[Convert.ToInt32(e.RowIndex)].Value));

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
                ImageButton imgExcluir = (ImageButton)e.Row.Cells[0].Controls[0];
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

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Controller.SalvarPerfilCargo(PreencheVO());

                ddlPerfil.SelectedValue = "0";
                txtCargo.Text = string.Empty;
                CarregarGrid();

                this.MostrarMensagem(MensagemIncluir);
            }
            catch (CABTECException ex)
            {
                this.MostrarMensagem(ex.Message);
            }
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