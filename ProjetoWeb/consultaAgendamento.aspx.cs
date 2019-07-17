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
    public partial class consultaAgendamento : PaginaBase
    {
        #region [ PROPERTIES ]

        private TAgendamentoCONTROLLER controller;

        public TAgendamentoCONTROLLER Controller
        {
            get
            {
                if (controller == null)
                    controller = new TAgendamentoCONTROLLER();

                return controller;

            }
        }
        
        private TUsuarioCONTROLLER controllerUsuario;

        public TUsuarioCONTROLLER ControllerUsuario
        {
            get
            {
                if (controllerUsuario == null)
                    controllerUsuario = new TUsuarioCONTROLLER();

                return controllerUsuario;

            }
        }

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.ControleAcesso(Util.Util.Funcionalidade.AGENDAMENTOCONSULTA, TipoUsuario);

                CarregarGrid();
            }
        }

        #endregion

        #region [ METHODS ]

        private void CarregarGrid()
        {
            try
            {
                List<TAgendamentoVO> listaConsulta = Controller.Listar(PreencheVO());

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

        private TAgendamentoVO PreencheVO()
        {
            TAgendamentoVO agendamentoVO = new TAgendamentoVO();

            agendamentoVO.NomeUsuarioAgendamento = txtAtendente.Text;
            agendamentoVO.NomeUsuarioVendedor = txtVendedor.Text;
            agendamentoVO.Unidade = Sessao.UsuarioLogado.Unidade;

            return agendamentoVO;
        }

        #endregion

        #region [ GRIDVIEW ]

        protected void gridConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Response.Redirect("~/cadastroAgendamento.aspx?codigo=" + gridConsulta.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
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
                
                DropDownList ddlNomeVendedor = (DropDownList)e.Row.FindControl("ddlVendedor");
                ddlNomeVendedor.DataTextField = "Nome";
                ddlNomeVendedor.DataValueField = "IDUsuario";
                TUsuarioVO filtro = new TUsuarioVO();
                filtro.Unidade = Sessao.UsuarioLogado.Unidade;
                List<TUsuarioVO> usuarioList = ControllerUsuario.Listar(filtro);
                usuarioList.Insert(0,new TUsuarioVO());
                ddlNomeVendedor.DataSource = usuarioList;
                ddlNomeVendedor.DataBind();

                ddlNomeVendedor.SelectedValue = (e.Row.DataItem as TAgendamentoVO).IDUsuarioVendedor.GetValueOrDefault().ToString();
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
                List<int> idsAgendamentos = new List<int>();
                List<int> idsVendedores = new List<int>();

                foreach (GridViewRow item in gridConsulta.Rows)
                {
                    idsAgendamentos.Add(Convert.ToInt32(gridConsulta.DataKeys[item.RowIndex].Value));
                    idsVendedores.Add(Convert.ToInt32(((DropDownList)((System.Web.UI.WebControls.TableRow)(item)).Cells[6].Controls[1]).SelectedValue));
                }

                Controller.SalvarConsultaVendedor(idsAgendamentos, idsVendedores);
                
                CarregarGrid();

                this.MostrarMensagem(MensagemAlterar);
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
