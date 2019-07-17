using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoVO;
using ProjetoController;
using WebControls;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace ProjetoWeb
{
    public partial class exibeRelatorio : PaginaBase
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

                ReportViewer1.Width = 800;               
                ReportViewer1.LocalReport.EnableExternalImages = true;

                switch (Request.QueryString["rel"])
                {
                    case "VENDEDORCOLETOR":
                        RelatorioVendedorColetor();
                        break;
                    case "HISTORICOSIMULADOR":
                        RelatorioHistoricoSimulador();
                        break;
                    default:
                        break;
                }
            }
        }

        protected void ReportViewer1_Load(object sender, EventArgs e)
        {
            OcultarOpcaoExportar("Word 2003");
            OcultarOpcaoExportar("Word");
            OcultarOpcaoExportar("PDF");
        }
        
        #endregion

        #region [ METHODS ]

        private void OcultarOpcaoExportar(string tipo)
        {
            string exportOption = tipo;
            RenderingExtension extension = ReportViewer1.LocalReport.ListRenderingExtensions().ToList().Find(x => x.LocalizedName.Equals(exportOption, StringComparison.CurrentCultureIgnoreCase));
            if (extension != null)
            {
                System.Reflection.FieldInfo fieldInfo = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                fieldInfo.SetValue(extension, false);
            }
        }


        private void RelatorioVendedorColetor()
        {
            TColetorVO filtro = new TColetorVO();

            if (_valores.Contains("coletor"))
                filtro.NumeroSerie = Request.QueryString["coletor"];

            if (_valores.Contains("vendedor"))
                filtro.NomeVendedor = Request.QueryString["vendedor"];

            if (_valores.Contains("tipo"))
                filtro.TipoRelatorio = Request.QueryString["tipo"];

            if (_valores.Contains("inicio"))
                filtro.DataRelatorioInicio = Convert.ToDateTime(Request.QueryString["inicio"]);

            if (_valores.Contains("final"))
                filtro.DataRelatorioFinal =  Convert.ToDateTime(Request.QueryString["final"]);


            ReportDataSource dtSource = new ReportDataSource("VendedorColetor", new TColetorCONTROLLER().ListarRelatorioVendedorColetor(filtro));

            ReportViewer1.LocalReport.ReportPath = Path.Combine(HttpRuntime.AppDomainAppPath,"Reports/VendedorColetor.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(dtSource);
            ReportViewer1.LocalReport.Refresh();
        }

        private string VoltarVendedorColetor()
        {
            string parametros = "action=BACK";

            _valores = Request.QueryString.AllKeys;

            if (_valores.Length == 0)
                return "filtroVendedorColetor.aspx";

            if (_valores.Contains("coletor"))
                parametros += "&coletor=" + Request.QueryString["coletor"];

            if (_valores.Contains("vendedor"))
                parametros += "&vendedor=" + Request.QueryString["vendedor"];

            if (_valores.Contains("tipo"))
                parametros += "&tipo=" + Request.QueryString["tipo"];

            if (_valores.Contains("inicio"))
                parametros += "&inicio=" + Request.QueryString["inicio"];

            if (_valores.Contains("final"))
                parametros += "&final=" + Request.QueryString["final"];

            return "filtroVendedorColetor.aspx?" + parametros;
        }

        private void RelatorioHistoricoSimulador()
        {
            MobileTSimuladorProdutoVO filtro = new MobileTSimuladorProdutoVO();

            if (_valores.Contains("coletor"))
                filtro.NumeroColetor = Request.QueryString["coletor"];

            if (_valores.Contains("vendedor"))
                filtro.NomeVendedor = Request.QueryString["vendedor"];

            if (_valores.Contains("entrevista"))
                filtro.CodigoEntrevista = Convert.ToInt64(Request.QueryString["entrevista"]);

            if (_valores.Contains("tipo"))
                filtro.ExibirCompleto = Request.QueryString["tipo"].Equals("S");

            if (_valores.Contains("inicio"))
                filtro.DataEntrevistaInicio = Convert.ToDateTime(Request.QueryString["inicio"]);

            if (_valores.Contains("final"))
                filtro.DataEntrevistaFinal = Convert.ToDateTime(Request.QueryString["final"]);

            ReportDataSource dtSource = new ReportDataSource("HistoricoSimulador", new MobileTSimuladorProdutoCONTROLLER().ListarRelatorioHistoricoSimulador(filtro));
            ReportViewer1.LocalReport.ReportPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Reports/HistoricoSimulador.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(dtSource);
            ReportViewer1.LocalReport.Refresh();
        }

        private string VoltarHistoricoSimulador()
        {
            string parametros = "action=BACK";

            _valores = Request.QueryString.AllKeys;

            if (_valores.Length == 0)
                return "filtroHistoricoSimulador.aspx";

            if (_valores.Contains("coletor"))
                parametros += "&coletor=" + Request.QueryString["coletor"];

            if (_valores.Contains("vendedor"))
                parametros += "&vendedor=" + Request.QueryString["vendedor"];

            if (_valores.Contains("entrevista"))
                parametros += "&entrevista=" + Request.QueryString["entrevista"];

            if (_valores.Contains("tipo"))
                parametros += "&tipo=" + Request.QueryString["tipo"];

            if (_valores.Contains("inicio"))
                parametros += "&inicio=" + Request.QueryString["inicio"];

            if (_valores.Contains("final"))
                parametros += "&final=" + Request.QueryString["final"];

            return "filtroHistoricoSimulador.aspx?" + parametros;
        }

        #endregion

        #region [ BUTTONS ]

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            switch (Request.QueryString["rel"])
            {
                case "VENDEDORCOLETOR":
                    Response.Redirect(VoltarVendedorColetor());
                    break;
                case "HISTORICOSIMULADOR":
                    Response.Redirect(VoltarHistoricoSimulador());
                    break;
                default:
                    break;
            }
        }
        
        #endregion
      
    }
}