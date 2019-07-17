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
using ProjetoWeb.Service;

namespace ProjetoWeb
{
    public partial class cadastroParametro : PaginaBase
    {
        #region [ PROPERTIES ]

        private TParametroCONTROLLER controller;

        public TParametroCONTROLLER Controller
        {
            get
            {
                if (controller == null)
                    controller = new TParametroCONTROLLER();

                return controller;

            }
        }

        private ServicoSINAF servicoSINAF;

        public ServicoSINAF ServicoSINAF
        {
            get
            {
                if (servicoSINAF == null)
                    servicoSINAF = new ServicoSINAF();

                return servicoSINAF;

            }
        }

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ControleAcesso(Util.Util.Funcionalidade.CONFIGURACAOPARAMETROS, TipoUsuario);

                CarregarValores();
            }
        }

        #endregion

        #region [ METHODS ]

        private void CarregarValores()
        {
            try
            {
                List<TParametroVO> listaParametro = Controller.Listar(new TParametroVO());

                if (listaParametro.Count > 1)
                    throw new CABTECException("Existe mais de um parâmetro cadastrado. Por favor verifique tabela TParametro.");
                else
                {
                    if(listaParametro.Count>0)
                        PreencheTela(listaParametro[0]);
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

        private TParametroVO PreencheVO()
        {
            TParametroVO parametroVO = new TParametroVO();
            parametroVO.IDParametro = string.IsNullOrEmpty(hiddenIDParametro.Value) ? 0 : Convert.ToInt32(hiddenIDParametro.Value);
            parametroVO.EstoqueMaximoColetor = Convert.ToInt32(txtEstoqueMaximoColetor.Text);
            parametroVO.EstoqueMaximoWeb = Convert.ToInt32(txtEstoqueMaximoWEB.Text);
            parametroVO.EstoqueMinimoColetor = Convert.ToInt32(txtEstoqueMinimoColetor.Text);
            parametroVO.EstoqueMinimoWeb = Convert.ToInt32(txtEstoqueMinimoWEB.Text);
            parametroVO.PrazoSincronismoDia = Convert.ToInt32(txtPrazoSincronismoDia.Text);
            parametroVO.TempoDadosServidorDias = Convert.ToInt32(txtTempoDadosServidorDias.Text);
            parametroVO.TempoLogOff = Convert.ToInt32(txtTempoLogOff.Text);
            parametroVO.TempoVerificaERPDias = Convert.ToInt32(txtTempoVerificaERPDias.Text);
            parametroVO.VersaoBaseCorreio = Convert.ToInt32(txtVersaoCorreio.Text);
            parametroVO.TempoEntrevistaColetor = Convert.ToInt32(txtPrazoEntrevistaColetor.Text);
            parametroVO.TempoEntrevistaIncompleta = Convert.ToInt32(txtPrazoIncompletaColetor.Text);

            return parametroVO;
        }

        private void PreencheTela(TParametroVO parametroVO)
        {
            hiddenIDParametro.Value = parametroVO.IDParametro.ToString();
            txtEstoqueMaximoColetor.Text = parametroVO.EstoqueMaximoColetor.HasValue? parametroVO.EstoqueMaximoColetor.Value.ToString():string.Empty;
            txtEstoqueMaximoWEB.Text = parametroVO.EstoqueMaximoWeb.HasValue ? parametroVO.EstoqueMaximoWeb.Value.ToString() : string.Empty;
            txtEstoqueMinimoColetor.Text = parametroVO.EstoqueMinimoColetor.HasValue ? parametroVO.EstoqueMinimoColetor.Value.ToString() : string.Empty;
            txtEstoqueMinimoWEB.Text = parametroVO.EstoqueMinimoWeb.HasValue ? parametroVO.EstoqueMinimoWeb.Value.ToString() : string.Empty;
            txtPrazoSincronismoDia.Text = parametroVO.PrazoSincronismoDia.HasValue ? parametroVO.PrazoSincronismoDia.Value.ToString() : string.Empty;
            txtTempoDadosServidorDias.Text = parametroVO.TempoDadosServidorDias.HasValue ? parametroVO.TempoDadosServidorDias.Value.ToString() : string.Empty;
            txtTempoLogOff.Text = parametroVO.TempoLogOff.HasValue ? parametroVO.TempoLogOff.Value.ToString() : string.Empty;
            txtTempoVerificaERPDias.Text = parametroVO.TempoVerificaERPDias.HasValue ? parametroVO.TempoVerificaERPDias.Value.ToString() : string.Empty;
            txtVersaoCorreio.Text = parametroVO.VersaoBaseCorreio.HasValue ? parametroVO.VersaoBaseCorreio.Value.ToString() : string.Empty;
            txtPrazoEntrevistaColetor.Text = parametroVO.TempoEntrevistaColetor.HasValue ? parametroVO.TempoEntrevistaColetor.Value.ToString() : string.Empty;
            txtPrazoIncompletaColetor.Text = parametroVO.TempoEntrevistaIncompleta.HasValue ? parametroVO.TempoEntrevistaIncompleta.Value.ToString() : string.Empty;
        }

        #endregion

        #region [ BUTTONS ]

        protected void imgServicoUsuario_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ServicoSINAF.ImportarUsuario();

            }
            catch (Exception exception)
            {
                this.MostrarMensagem(exception.Message);
            }
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string mensagem = string.IsNullOrEmpty(hiddenIDParametro.Value)? this.MensagemIncluir: this.MensagemAlterar;
                Controller.Salvar(PreencheVO(), Sessao.UsuarioLogado.IDUsuario);
              
                this.MostrarMensagem(mensagem);

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
