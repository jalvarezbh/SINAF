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
    public partial class cadastroAgendamento : PaginaBase
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

        private TEstadoCONTROLLER controllerEstado;

        public TEstadoCONTROLLER ControllerEstado
        {
            get
            {
                if (controllerEstado == null)
                    controllerEstado = new TEstadoCONTROLLER();

                return controllerEstado;

            }
        }

        private TLogradouroCONTROLLER controllerLogradouro;

        public TLogradouroCONTROLLER ControllerLogradouro
        {
            get
            {
                if (controllerLogradouro == null)
                    controllerLogradouro = new TLogradouroCONTROLLER();

                return controllerLogradouro;

            }
        }
               
        public bool atualizar
        {
            get { return !string.IsNullOrEmpty(hiddenIDAgendamento.Value); }
        }

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ControleAcesso(Util.Util.Funcionalidade.AGENDAMENTOCADASTRO, TipoUsuario);

                CarregarCombos();

                if (Request.QueryString["codigo"] != null)
                {
                    hiddenIDAgendamento.Value = Request.QueryString["codigo"];
                    CarregarValores();
                }
            }
        }

        #endregion

        #region [ METHODS ]

        private void CarregarCombos()
        {
            try
            {
                ddlEstado.DataTextField = "Sigla";
                ddlEstado.DataValueField = "Sigla";
                ddlEstado.DataSource = ControllerEstado.Listar();
                ddlEstado.DataBind();

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

        private void CarregarValores()
        {
            try
            {
                TAgendamentoVO agendamentoEditar = new TAgendamentoVO();
                agendamentoEditar.IDAgendamento = Convert.ToInt32(hiddenIDAgendamento.Value);
                List<TAgendamentoVO> listaAgendamento = Controller.Listar(agendamentoEditar);

                if (listaAgendamento.Count > 0)
                    PreencheTela(listaAgendamento[0]);

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
            agendamentoVO.IDAgendamento = atualizar ? Convert.ToInt32(hiddenIDAgendamento.Value) : 0;
            agendamentoVO.Nome = txtNome.Text;
            agendamentoVO.DataNascimento = !string.IsNullOrEmpty(txtDataNascimento.Text) ? Convert.ToDateTime(txtDataNascimento.Text) : DateTime.MinValue;
            agendamentoVO.Email = txtEmail.Text;
            agendamentoVO.Telefone = txtTelefone.Text;
            agendamentoVO.Celular = txtCelular.Text;

            agendamentoVO.CEP = !string.IsNullOrEmpty(txtCEP.Text) ? Convert.ToInt32(txtCEP.Text.Replace(".", string.Empty).Replace("-", string.Empty)) : 0;
            agendamentoVO.Logradouro = txtEndereco.Text;
            agendamentoVO.Numero = !string.IsNullOrEmpty(txtNumero.Text) ? Convert.ToInt32(txtNumero.Text): 0;
            agendamentoVO.Complemento = txtComplemento.Text;
            agendamentoVO.Bairro = txtBairro.Text;
            agendamentoVO.Cidade = txtCidade.Text;
            agendamentoVO.UF = ddlEstado.SelectedValue;
            agendamentoVO.PontoReferencia = txtPontoReferencia.Text;

            agendamentoVO.IDUsuarioAgendamento = Sessao.UsuarioLogado.IDUsuario;

            if(TipoUsuario == Util.Util.Cargo.VENDEDOR)
              agendamentoVO.IDUsuarioVendedor = Sessao.UsuarioLogado.IDUsuario;
            
            return agendamentoVO;
        }

        private void PreencheTela(TAgendamentoVO agendamentoVO)
        {
            hiddenIDAgendamento.Value = agendamentoVO.IDAgendamento.ToString();
            txtNome.Text = agendamentoVO.Nome;
            txtDataNascimento.Text = agendamentoVO.DataNascimento.ToShortDateString();
            txtEmail.Text = agendamentoVO.Email;
            txtTelefone.Text = agendamentoVO.Telefone;
            txtCelular.Text = agendamentoVO.Celular;

            txtCEP.Text = agendamentoVO.CEP.ToString();
            txtEndereco.Text = agendamentoVO.Logradouro;
            txtNumero.Text = agendamentoVO.Numero.GetValueOrDefault().ToString();
            txtComplemento.Text = agendamentoVO.Complemento;
            txtBairro.Text = agendamentoVO.Bairro;
            txtCidade.Text = agendamentoVO.Cidade;
            ddlEstado.SelectedValue = agendamentoVO.UF;
            txtPontoReferencia.Text = agendamentoVO.PontoReferencia;
        }

        private void PreencheTelaLogradouro(TLogradouroVO logradouroVO)
        {
            txtCEP.Text = logradouroVO.CEP.ToString();
            txtEndereco.Text = logradouroVO.NomeLogradouro;
            txtBairro.Text = logradouroVO.NomeBairro;
            txtCidade.Text = logradouroVO.NomeCidade;
            ddlEstado.SelectedValue = logradouroVO.Sigla;
        }

        private void LimparTela()
        {
            hiddenIDAgendamento.Value = string.Empty;
            txtNome.Text = string.Empty;
            txtDataNascimento.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtCelular.Text = string.Empty;

            txtCEP.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            ddlEstado.SelectedValue = string.Empty;
            txtPontoReferencia.Text = string.Empty;
        }

        #endregion

        #region [ BUTTONS ]

        protected void txtCEP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string digitadoCEP = txtCEP.Text.Replace(".", string.Empty).Replace("-", string.Empty);

                if (digitadoCEP.Length == 8)
                {
                    TLogradouroVO logradouro = ControllerLogradouro.ListarPorCEP(Convert.ToInt32(digitadoCEP));

                    if (logradouro == null)
                    {
                        throw new CABTECException("CEP Inválido!");
                    }

                    trMensagemPageCadastro.Visible = false;
                    PreencheTelaLogradouro(logradouro);
                }
                else
                    throw new CABTECException("CEP Inválido!");
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

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string mensagem = string.IsNullOrEmpty(hiddenIDAgendamento.Value) ? this.MensagemIncluir : this.MensagemAlterar;

                hiddenIDAgendamento.Value = Controller.Salvar(PreencheVO()).ToString();

                this.MostrarMensagem(mensagem);

                LimparTela();

            }
            catch (CABTECException ex)
            {
                this.MostrarMensagem(ex.Message);
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
