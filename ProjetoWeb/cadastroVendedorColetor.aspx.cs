using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ProjetoVO;
using ProjetoController;
using WebControls;

namespace ProjetoWeb
{
    public partial class cadastroVendedorColetor : PaginaBase
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
                this.ControleAcesso(Util.Util.Funcionalidade.COLETORASSOCIAR, TipoUsuario);
                rdbColetor.Checked = true;
                AssociarPor(rdbColetor.Checked);
                CarregarListColetor(new TColetorVO(), -1);
                CarregarListVendedor(new TUsuarioVO(),-1);
                
            }
        }

        #endregion

        #region [ METHODS ]

        private void LimparCampos()
        {
            txtColetorPesquisa.Text = string.Empty;
            txtVendedorPesquisa.Text = string.Empty;
            txtColetorSelecionado.Text = string.Empty;
            txtVendedorSelecionado.Text = string.Empty;
            hiddenIDColetor.Value = string.Empty;
            HiddenIDVendedor.Value = string.Empty;
        }

        private void CarregarListColetor(TColetorVO coletorVO, int idTitular)
        {
            try
            {
                List<TColetorVO> listaColetores = new List<TColetorVO>();
                bool coletorVinculo = false;

                if (idTitular == -1)
                    listaColetores = Controller.Listar(coletorVO);
                else
                    listaColetores = Controller.ListarColetorLivre(idTitular, ref coletorVinculo);

                lstColetor.DataTextField = "NumeroSerie";
                lstColetor.DataValueField = "IDColetorIDVendedor";
                lstColetor.DataSource = listaColetores;
                lstColetor.DataBind();

                if (listaColetores.Count > 0)
                    lstColetor.SelectedIndex = 0;

                if (idTitular > 0 && listaColetores.Count > 0 && coletorVinculo)
                {
                    hiddenIDColetor.Value = listaColetores[0].IDColetor.ToString();
                    txtColetorSelecionado.Text = listaColetores[0].NumeroSerie;
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

        private void CarregarListVendedor(TUsuarioVO usuarioVendedor, int idTitular)
        {
            try
            {                
                List<TUsuarioVO> listaVendedor = new List<TUsuarioVO>();

                if (idTitular == -1)
                    listaVendedor = ControllerUsuario.ListarSemAtendente(usuarioVendedor);
                else
                    listaVendedor = ControllerUsuario.ListarVendedorLivre(usuarioVendedor, idTitular);

                lstVendedor.DataTextField = "Abreviado";
                lstVendedor.DataValueField = "IDUsuario";
                lstVendedor.DataSource = listaVendedor;
                lstVendedor.DataBind();
                
                if(listaVendedor.Count > 0)
                    lstVendedor.SelectedIndex = 0;

                if (idTitular > 0 && listaVendedor.Count > 0)
                {
                    HiddenIDVendedor.Value = listaVendedor[0].IDUsuario.ToString(); 
                    txtVendedorSelecionado.Text = listaVendedor[0].Abreviado;
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

        private void ColetorSelecionado()
        {
            if (!string.IsNullOrEmpty(lstColetor.SelectedValue))
            {
                string[] valoresIDs = lstColetor.SelectedValue.Split('#');

                txtColetorSelecionado.Text = lstColetor.SelectedItem.Text;
                               
                hiddenIDColetor.Value = valoresIDs[0];

                if (rdbColetor.Checked)
                {
                    txtVendedorSelecionado.Text = string.Empty;
                    CarregarListVendedor(new TUsuarioVO(), Convert.ToInt32(valoresIDs[1]));
                }
            }
        }

        private void VendedorSelecionado()
        {
            if (!string.IsNullOrEmpty(lstVendedor.SelectedValue))
            {
                txtVendedorSelecionado.Text = lstVendedor.SelectedItem.Text;

                HiddenIDVendedor.Value = lstVendedor.SelectedValue;

                if (rdbVendedor.Checked)
                {
                    txtColetorSelecionado.Text = string.Empty;
                    CarregarListColetor(new TColetorVO(), Convert.ToInt32(lstVendedor.SelectedValue));
                }
            }
        }

        private void AssociarPor(bool coletor)
        {
            txtColetorPesquisa.Enabled = coletor;
            btnColetorPesquisa.Enabled = coletor;

            txtVendedorPesquisa.Enabled = !coletor;
            btnVendedorPesquisa.Enabled = !coletor;

            if (coletor)
            {
                txtVendedorPesquisa.BackColor = Color.LightGray;
                txtColetorPesquisa.BackColor = Color.White;
                imgVendedor.ValidationGroup = "Coletor";
                imgColetor.ValidationGroup = string.Empty;
            }
            else
            {
                txtVendedorPesquisa.BackColor = Color.White;
                txtColetorPesquisa.BackColor = Color.LightGray;
                imgVendedor.ValidationGroup = string.Empty;
                imgColetor.ValidationGroup = "Vendedor";
            }
        }

        private void RecuperarAssociar()
        {
            int indiceColetor = lstColetor.SelectedIndex;
            int indiceVendedor = lstVendedor.SelectedIndex; 

            TColetorVO filtro = new TColetorVO();
            filtro.NumeroSerie = txtColetorPesquisa.Text;
            CarregarListColetor(filtro, -1);

            TUsuarioVO filtroUsuario = new TUsuarioVO();
            filtroUsuario.Abreviado = txtVendedorPesquisa.Text;
            CarregarListVendedor(filtroUsuario, -1);

            if (rdbColetor.Checked)
            {
                lstColetor.SelectedIndex = indiceColetor;
                ColetorSelecionado();
            }
            else
            {
                lstVendedor.SelectedIndex = indiceVendedor;
                VendedorSelecionado();
            }

        }

        #endregion

        #region [ RADIOS ]

        protected void rdbColetor_CheckedChanged(object sender, EventArgs e)
        {
            LimparMensagem();
            AssociarPor(rdbColetor.Checked);
            LimparCampos();
            CarregarListColetor(new TColetorVO(), -1);
            CarregarListVendedor(new TUsuarioVO(), -1);
        }

        protected void rdbVendedor_CheckedChanged(object sender, EventArgs e)
        {
            LimparMensagem();
            AssociarPor(!rdbVendedor.Checked);
            LimparCampos();
            CarregarListColetor(new TColetorVO(), -1);
            CarregarListVendedor(new TUsuarioVO(), -1);
        }


        #endregion

        #region [ BUTTONS ]

        protected void btnColetorPesquisa_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LimparMensagem();
                TColetorVO filtro = new TColetorVO();
                filtro.NumeroSerie = txtColetorPesquisa.Text;
                CarregarListColetor(filtro, -1);
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

        protected void btnVendedorPesquisa_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LimparMensagem();
                TUsuarioVO filtro = new TUsuarioVO();
                filtro.Abreviado = txtVendedorPesquisa.Text;
                CarregarListVendedor(filtro, -1);
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

        protected void imgColetor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LimparMensagem();
                ColetorSelecionado();
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
         
        protected void imgVendedor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LimparMensagem();
                VendedorSelecionado();
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
                string mensagem = Controller.AssociarColetorVendedor(hiddenIDColetor.Value, HiddenIDVendedor.Value);
                               
                this.MostrarMensagem(mensagem);
                
                RecuperarAssociar();
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

        public void LimparMensagem()
        {
            trMensagemPageCadastro.Visible = false;
            lblMensagem.Text = string.Empty;
        }

        #endregion                     
    }
}
