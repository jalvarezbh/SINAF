using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoWeb.Util;
using System.Data.SqlClient;
using ProjetoWeb.Service;
using System.Web.Configuration;

namespace ProjetoWeb.Scripts
{
    public partial class WebControls : System.Web.UI.Page
    {
        private static string connectionString;

        public static string ConnectionString
        {
            get
            {
                if (connectionString == null)
                    connectionString = WebConfigurationManager.ConnectionStrings["ConnectionStringWEB"].ConnectionString;

                return connectionString;

            }
        }

        private ServicoSINAF servicoTeste;

        public ServicoSINAF ServicoTeste
        {
            get
            {
                if (servicoTeste == null)
                    servicoTeste = new ServicoSINAF();

                return servicoTeste;

            }
        }

        private ServicoColetor servicoColetor;

        public ServicoColetor ServicoColetor
        {
            get
            {
                if (servicoColetor == null)
                    servicoColetor = new ServicoColetor();

                return servicoColetor;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ValidaSenha()
        {
            try
            {
                if (string.IsNullOrEmpty(txtPassCode.Text))
                    throw new Exception("Sem Acesso");

                string senha = Util.Util.GeraHashMD5(txtPassCode.Text);

                if (!senha.Equals("97D64031978AE5C01671FD374E75A481"))
                    throw new Exception("Sem Acesso");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                if (!string.IsNullOrEmpty(txtScript.Text))
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmdScript = new SqlCommand(txtScript.Text, conn);
                        cmdScript.ExecuteNonQuery();
                    }
                }

                lblMensagem.Text = "Script Executado";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                lblMensagem.Text = ConnectionString;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnImportCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                ServicoTeste.ImportarBaseSINAF();

                lblMensagem.Text = "Metodo Executado";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        protected void btnImportUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                ServicoTeste.ImportarUsuario();

                lblMensagem.Text = "Metodo Executado";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnImportProfissao_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                ServicoTeste.ImportarProfissao();

                lblMensagem.Text = "Metodo Executado";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnImportOrigem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                ServicoTeste.ImportarOrigemVenda();

                lblMensagem.Text = "Metodo Executado";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnImportFaixa_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                ServicoTeste.ImportarFaixas();

                lblMensagem.Text = "Metodo Executado";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnExcluirEntrevista_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                ServicoTeste.ExcluirEntrevistas();

                lblMensagem.Text = "Metodo Executado";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnImportCorreio_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                ServicoTeste.ImportarBancoCorreio();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                ServicoTeste.ExportarBaseSINAF();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

        }
             
        protected void btnExcluirBackups_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSenha();

                ServicoColetor.ExcluirBackupColetor();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}