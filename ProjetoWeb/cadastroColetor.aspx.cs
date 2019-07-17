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

namespace ProjetoWeb
{
    public partial class cadastroColetor : PaginaBase
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

        public bool atualizar
        {
            get { return !string.IsNullOrEmpty(hiddenIDColetor.Value); }
        }

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ControleAcesso(Util.Util.Funcionalidade.COLETORCADASTRO, TipoUsuario);
            
                if (Request.QueryString["codigo"] != null)
                {
                    hiddenIDColetor.Value = Request.QueryString["codigo"];
                    CarregarValores();
                }
            }

        }

        #endregion

        #region [ METHODS ]

        private void CarregarValores()
        {
            try
            {
                TColetorVO coletorEditar = new TColetorVO();
                coletorEditar.IDColetor = Convert.ToInt32(hiddenIDColetor.Value);
                List<TColetorVO> listaColetor = Controller.Listar(coletorEditar);

                if (listaColetor.Count > 0)
                    PreencheTela(listaColetor[0]);

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
            coletorVO.IDColetor = atualizar ? Convert.ToInt32(hiddenIDColetor.Value) : 0;
            coletorVO.NumeroSerie = txtNumeroSerie.Text;
            coletorVO.IMEI = txtIMEI.Text;
            coletorVO.Fabricante = txtFabricante.Text;
            coletorVO.Modelo = txtModelo.Text;
            coletorVO.UsoBackup = chkUsoBackup.Checked;
            coletorVO.IDUsuarioCadastro = Sessao.UsuarioLogado.IDUsuario;
             
            return coletorVO;
        }

        private void PreencheTela(TColetorVO coletorVO)
        {
            hiddenIDColetor.Value = coletorVO.IDColetor.ToString();
            txtNumeroSerie.Text = coletorVO.NumeroSerie;
            txtIMEI.Text = coletorVO.IMEI;
            txtFabricante.Text = coletorVO.Fabricante;
            txtModelo.Text = coletorVO.Modelo;
            chkAtivo.Checked = coletorVO.Ativo;
            chkUsoBackup.Checked = coletorVO.UsoBackup;

            txtUsuarioCadastro.Text = coletorVO.NomeUsuarioCadastro;
            txtUsuarioResponsavel.Text = coletorVO.NomeUsuarioResponsavel;
            txtDataCadastro.Text = coletorVO.DataCadastro.ToShortDateString();
            txtDataInativacao.Text = coletorVO.DataInativacao.HasValue ? coletorVO.DataInativacao.Value.ToShortDateString() : string.Empty;
        }

        #endregion

        #region [ BUTTONS ]

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("consultaColetor.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string mensagem = string.IsNullOrEmpty(hiddenIDColetor.Value) ? this.MensagemIncluir : this.MensagemAlterar;

                hiddenIDColetor.Value = Controller.Salvar(PreencheVO()).ToString();

                this.MostrarMensagem(mensagem);

                CarregarValores();

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
        }

        #endregion
                
    }
}
