using ProjetoVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebControls;


namespace ProjetoWeb
{
    public partial class filtroHistoricoSimulador : PaginaBase
    {
        #region [ PROPERTIES ]

        private string[] _valores;

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _valores = Request.QueryString.AllKeys;

                if (_valores.Length == 0)
                    return;

                if (Request.QueryString["action"] == "BACK")
                    CarregarValores();
            }
        }

        #endregion

        #region [ METHODS ]

        private void CarregarValores()
        {
            try
            {
                if (_valores.Contains("coletor"))
                    txtColetor.Text = Request.QueryString["coletor"];

                if (_valores.Contains("vendedor"))
                    txtVendedor.Text = Request.QueryString["vendedor"];

                if (_valores.Contains("entrevista"))
                    txtEntrevista.Text = Request.QueryString["entrevista"];

                if (_valores.Contains("tipo"))
                {
                    rdbTipoSim.Checked = false;
                    switch (Request.QueryString["tipo"])
                    {
                        case "S":
                            rdbTipoSim.Checked = true;
                            break;
                        case "N":
                            rdbTipoNao.Checked = true;
                            break;                        
                        default:
                            break;
                    }
                }

                if (_valores.Contains("inicio"))
                    txtDataInicial.Text = Request.QueryString["inicio"];

                if (_valores.Contains("final"))
                    txtDataFinal.Text = Request.QueryString["final"];

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

        private string MapearValores()
        {
            string parametros = "rel=HISTORICOSIMULADOR";

            if (!string.IsNullOrEmpty(txtColetor.Text))
                parametros += "&coletor=" + txtColetor.Text;

            if (!string.IsNullOrEmpty(txtVendedor.Text))
                parametros += "&vendedor=" + txtVendedor.Text;

            if (!string.IsNullOrEmpty(txtEntrevista.Text))
                parametros += "&entrevista=" + txtEntrevista.Text;

            if (rdbTipoSim.Checked)
                parametros += "&tipo=S";
            else if (rdbTipoNao.Checked)
                parametros += "&tipo=N";           

            if (!string.IsNullOrEmpty(txtDataInicial.Text))
                parametros += "&inicio=" + txtDataInicial.Text;

            if (!string.IsNullOrEmpty(txtDataFinal.Text))
                parametros += "&final=" + txtDataFinal.Text;

            return "exibeRelatorio.aspx?" + parametros;
        }

        #endregion

        #region [ BUTTONS ]
             
        protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect(MapearValores());
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