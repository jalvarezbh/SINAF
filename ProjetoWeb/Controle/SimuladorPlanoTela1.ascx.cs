using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoVO;
using ProjetoController;
using WebControls;
using System.Data;

namespace ProjetoWeb.Controle
{
    public partial class SimuladorPlanoTela1 : System.Web.UI.UserControl
    {
        #region [ PROPERTIES ]

        private TPlanoCONTROLLER controller;

        public TPlanoCONTROLLER Controller
        {
            get
            {
                if (controller == null)
                    controller = new TPlanoCONTROLLER();

                return controller;

            }
        }

        private TPlanoProtecaoCONTROLLER controllerPlanoProtecao;

        public TPlanoProtecaoCONTROLLER ControllerPlanoProtecao
        {
            get
            {
                if (controllerPlanoProtecao == null)
                    controllerPlanoProtecao = new TPlanoProtecaoCONTROLLER();

                return controllerPlanoProtecao;

            }
        }

        private TPlanoSeniorCONTROLLER controllerPlanoSenior;

        public TPlanoSeniorCONTROLLER ControllerPlanoSenior
        {
            get
            {
                if (controllerPlanoSenior == null)
                    controllerPlanoSenior = new TPlanoSeniorCONTROLLER();

                return controllerPlanoSenior;

            }
        }

        private TPlanoCasalCONTROLLER controllerPlanoCasal;

        public TPlanoCasalCONTROLLER ControllerPlanoCasal
        {
            get
            {
                if (controllerPlanoCasal == null)
                    controllerPlanoCasal = new TPlanoCasalCONTROLLER();

                return controllerPlanoCasal;

            }
        }

        public TPlanoProtecaoVO PlanoProtecaoVO
        {
            get { return Util.Sessao.PlanoProtecaoVO; }
            set { Util.Sessao.PlanoProtecaoVO = value; }
        }

        public TPlanoSeniorVO PlanoSeniorVO
        {
            get { return Util.Sessao.PlanoSeniorVO; }
            set { Util.Sessao.PlanoSeniorVO = value; }
        }

        public TPlanoCasalVO PlanoCasalVO
        {
            get { return Util.Sessao.PlanoCasalVO; }
            set { Util.Sessao.PlanoCasalVO = value; }
        }

        private List<ProdutoPrincipal> _produtoDisponivel;
        public List<ProdutoPrincipal> ProdutoDisponivel
        {
            get { return _produtoDisponivel; }
            set { _produtoDisponivel = value; }
        }

        public int FaixaBase
        {
            get { return Util.Sessao.idadeBase; }
        }

        public int Resposta2
        {
            get { return Util.Sessao.respostaPergunta2; }
        }

        public int Resposta7
        {
            get { return Util.Sessao.respostaPergunta7; }
        }

        public TPlanoProtecaoVO PlanoProtecaoFuneralNovoVO
        {
            get { return Util.Sessao.PlanoProtecaoVONovo; }
            set { Util.Sessao.PlanoProtecaoVONovo = value; }
        }

        public TPlanoProtecaoVO PlanoProtecaoRendaNovoVO
        {
            get { return Util.Sessao.PlanoProtecaoVONovo; }
            set { Util.Sessao.PlanoProtecaoVONovo = value; }
        }

        public TPlanoCasalVO PlanoCasalFuneralNovoVO
        {
            get { return Util.Sessao.PlanoCasalVONovo; }
            set { Util.Sessao.PlanoCasalVONovo = value; }
        }

        public TPlanoSeniorVO PlanoSeniorFuneralNovoVO
        {
            get { return Util.Sessao.PlanoSeniorVONovo; }
            set { Util.Sessao.PlanoSeniorVONovo = value; }
        }

        public List<TAgregadoVO> ListaAgregadoVONovo
        {
            get { return Util.Sessao.ListaAgregadoVONovo; }
            set { Util.Sessao.ListaAgregadoVONovo = value; }
        }

        public List<TAgregadoVO> ListaAgregadoVOTemp
        {
            get { return Util.Sessao.ListaAgregadoVOTemp; }
            set { Util.Sessao.ListaAgregadoVOTemp = value; }
        }

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        #endregion

        #region [ METHODS ]

        #region [ POPULAR ]

        private void Popular()
        {
            OcultarTodosProdutos();

            if (PlanoProtecaoVO.IDPlanoProtecao > 0)
            {
                txtProdutoDefinido.Text = ProdutoPrincipal.PLANOPROTECAO.GetStringValue();
                trPlanoProtecaoRenda.Visible = true;
                trPlanoAgregados.Visible = true;
                trPlanoProtecaoFuneral.Visible = true;
                trPlanoProtecaoRendaEspaco.Visible = true;
                PopularPlanoProtecaoMorteAcidental();
                PopularPlanoProtecaoInvalidezAcidente();
                PopularPlanoProtecaoAssisteciaEmergencial();
                PopularPlanoProtecaoFuneralCategoria();
                PopularPlanoProtecaoAgregados();
                PopularPlanoProtecaoRendaMeses();
                PopularPlanoProtecaoVOIncial();
                CalcularValorTotalPlanoProtecao();

            }

            if (PlanoSeniorVO.IDPlanoSenior > 0)
            {
                txtProdutoDefinido.Text = ProdutoPrincipal.PLANOSENIOR.GetStringValue();
                trPlanoAgregados.Visible = true;
                trPlanoSeniorFuneral.Visible = true;
                PopularPlanoSeniorFuneralPrincipal();
                PopularPlanoSeniorFuneralCategoria();
                PopularPlanoProtecaoAgregados();
                PopularPlanoSeniorVOIncial();
                CalcularValorTotalPlanoSenior();
            }

            if (PlanoCasalVO.IDPlanoCasal > 0)
            {
                txtProdutoDefinido.Text = ProdutoPrincipal.PLANOCASAL.GetStringValue();
                trPlanoAgregados.Visible = true;
                trPlanoCasalFuneral.Visible = true;
                PopularPlanoCasalFuneralPrincipal();
                PopularPlanoCasalFuneralConjuge();
                PopularPlanoCasalFuneralCategoria();
                PopularPlanoProtecaoAgregados();
                PopularPlanoCasalVOIncial();
                CalcularValorTotalPlanoCasal();
            }

            if(ProdutoDisponivel!=null)
                PopularProduto();

        }

        private void PopularProduto()
        {
            DataTable dtProduto = new DataTable();
            DataColumn dcValor = new DataColumn("Valor");
            DataColumn dcTexto = new DataColumn("Texto");

            dtProduto.Columns.Add(dcValor);
            dtProduto.Columns.Add(dcTexto);

            DataRow drItems = dtProduto.NewRow();
            drItems = dtProduto.NewRow();
            drItems["Valor"] = 0;
            drItems["Texto"] = string.Empty;
            dtProduto.Rows.Add(drItems);

            foreach (ProdutoPrincipal item in ProdutoDisponivel)
            {
                drItems = dtProduto.NewRow();
                drItems["Valor"] = (int)item;
                drItems["Texto"] = item.GetStringValue();
                dtProduto.Rows.Add(drItems);
            }

            ddlProdutoAlterar.DataValueField = "Valor";
            ddlProdutoAlterar.DataTextField = "Texto";
            ddlProdutoAlterar.DataSource = dtProduto;
            ddlProdutoAlterar.DataBind();
        }

        private void PopularPlanoProtecaoRendaValor()
        {
            ddlPlanoProtecaoRendaValorNovo.DataValueField = "Key";
            ddlPlanoProtecaoRendaValorNovo.DataTextField = "Value";
            ddlPlanoProtecaoRendaValorNovo.DataSource = ControllerPlanoProtecao.ListarTodosRendaValor(true, Convert.ToInt32(ddlPlanoProtecaoRendaPeriodoNovo.SelectedValue), FaixaBase);
            ddlPlanoProtecaoRendaValorNovo.DataBind();
        }

        private void PopularPlanoProtecaoRendaMeses()
        {
            ddlPlanoProtecaoRendaPeriodoNovo.DataValueField = "Key";
            ddlPlanoProtecaoRendaPeriodoNovo.DataTextField = "Value";
            ddlPlanoProtecaoRendaPeriodoNovo.DataSource = ControllerPlanoProtecao.ListarTodosRendaPeriodo(true);
            ddlPlanoProtecaoRendaPeriodoNovo.DataBind();
        }

        private void PopularPlanoProtecaoAgregados()
        {
            DataTable dataParentesco = new DataTable();
            DataColumn dadosKey = new DataColumn("Key");
            DataColumn dadosValue = new DataColumn("Value");

            dataParentesco.Columns.Add(dadosKey);
            dataParentesco.Columns.Add(dadosValue);

            #region [ Grau de Parentesco do Enum ]

            DataRow dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = 0;
            dadosRow["Value"] = string.Empty;
            dataParentesco.Rows.Add(dadosRow);

            dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.CONJUGE;
            dadosRow["Value"] = GrauParentesco.CONJUGE.GetStringValue();
            dataParentesco.Rows.Add(dadosRow);

            dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.FILHO;
            dadosRow["Value"] = GrauParentesco.FILHO.GetStringValue();
            dataParentesco.Rows.Add(dadosRow);

            dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.PAI;
            dadosRow["Value"] = GrauParentesco.PAI.GetStringValue();
            dataParentesco.Rows.Add(dadosRow);

            dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.MAE;
            dadosRow["Value"] = GrauParentesco.MAE.GetStringValue();
            dataParentesco.Rows.Add(dadosRow);

            dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.SOGRO;
            dadosRow["Value"] = GrauParentesco.SOGRO.GetStringValue();
            dataParentesco.Rows.Add(dadosRow);

            dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.GENRO;
            dadosRow["Value"] = GrauParentesco.GENRO.GetStringValue();
            dataParentesco.Rows.Add(dadosRow);

            dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.NORA;
            dadosRow["Value"] = GrauParentesco.NORA.GetStringValue();
            dataParentesco.Rows.Add(dadosRow);

            dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.IRMAO;
            dadosRow["Value"] = GrauParentesco.IRMAO.GetStringValue();
            dataParentesco.Rows.Add(dadosRow);

            dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.NETO;
            dadosRow["Value"] = GrauParentesco.NETO.GetStringValue();
            dataParentesco.Rows.Add(dadosRow);

            dadosRow = dataParentesco.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.BISNETO;
            dadosRow["Value"] = GrauParentesco.BISNETO.GetStringValue();
            dataParentesco.Rows.Add(dadosRow);

            #endregion

            ddlPlanoProtecaoAgregadosGrauNovo.DataValueField = "Key";
            ddlPlanoProtecaoAgregadosGrauNovo.DataTextField = "Value";
            ddlPlanoProtecaoAgregadosGrauNovo.DataSource = dataParentesco;
            ddlPlanoProtecaoAgregadosGrauNovo.DataBind();

        }

        private void PopularPlanoProtecaoMorteAcidental()
        {
            ddlPlanoProtecaoFuneralMorteNovo.DataValueField = "Key";
            ddlPlanoProtecaoFuneralMorteNovo.DataTextField = "Value";
            ddlPlanoProtecaoFuneralMorteNovo.DataSource = ControllerPlanoProtecao.ListarTodosMorteAcidental(true, FaixaBase);
            ddlPlanoProtecaoFuneralMorteNovo.DataBind();

        }

        private void PopularPlanoProtecaoInvalidezAcidente()
        {
            ddlPlanoProtecaoFuneralIPANovo.DataValueField = "Key";
            ddlPlanoProtecaoFuneralIPANovo.DataTextField = "Value";
            ddlPlanoProtecaoFuneralIPANovo.DataSource = ControllerPlanoProtecao.ListarTodosInvalidezAcidente(true, FaixaBase);
            ddlPlanoProtecaoFuneralIPANovo.DataBind();

        }

        private void PopularPlanoProtecaoAssisteciaEmergencial()
        {
            ddlPlanoProtecaoFuneralAssistenciaNovo.DataValueField = "Key";
            ddlPlanoProtecaoFuneralAssistenciaNovo.DataTextField = "Value";
            ddlPlanoProtecaoFuneralAssistenciaNovo.DataSource = ControllerPlanoProtecao.ListarTodosAssisteciaEmergencial(true);
            ddlPlanoProtecaoFuneralAssistenciaNovo.DataBind();

        }

        private void PopularPlanoProtecaoFuneralCategoria()
        {
            ddlPlanoProtecaoFuneralCategoriaNovo.DataValueField = "Key";
            ddlPlanoProtecaoFuneralCategoriaNovo.DataTextField = "Value";
            ddlPlanoProtecaoFuneralCategoriaNovo.DataSource = ControllerPlanoProtecao.ListarTodosFuneralCategoria(true);
            ddlPlanoProtecaoFuneralCategoriaNovo.DataBind();

        }

        private void PopularPlanoCasalFuneralPrincipal()
        {
            ddlPlanoCasalFuneralPrincipalNovo.DataValueField = "Key";
            ddlPlanoCasalFuneralPrincipalNovo.DataTextField = "Value";
            ddlPlanoCasalFuneralPrincipalNovo.DataSource = ControllerPlanoCasal.ListarTodosFuneralPrincipal(true, FaixaBase);
            ddlPlanoCasalFuneralPrincipalNovo.DataBind();
        }

        private void PopularPlanoCasalFuneralConjuge()
        {
            ddlPlanoCasalFuneralConjugeNovo.DataValueField = "Key";
            ddlPlanoCasalFuneralConjugeNovo.DataTextField = "Value";
            ddlPlanoCasalFuneralConjugeNovo.DataSource = ControllerPlanoCasal.ListarTodosFuneralConjuge(true,FaixaBase);
            ddlPlanoCasalFuneralConjugeNovo.DataBind();
        }

        private void PopularPlanoCasalFuneralCategoria()
        {
            ddlPlanoCasalFuneralCategoriaNovo.DataValueField = "Key";
            ddlPlanoCasalFuneralCategoriaNovo.DataTextField = "Value";
            ddlPlanoCasalFuneralCategoriaNovo.DataSource = ControllerPlanoCasal.ListarTodosFuneralCategoria(true);
            ddlPlanoCasalFuneralCategoriaNovo.DataBind();
        }

        private void PopularPlanoSeniorFuneralPrincipal()
        {
            ddlPlanoSeniorFuneralPrincipalNovo.DataValueField = "Key";
            ddlPlanoSeniorFuneralPrincipalNovo.DataTextField = "Value";
            ddlPlanoSeniorFuneralPrincipalNovo.DataSource = ControllerPlanoSenior.ListarTodosFuneralPrincipal(true,FaixaBase);
            ddlPlanoSeniorFuneralPrincipalNovo.DataBind();
        }

        private void PopularPlanoSeniorFuneralCategoria()
        {
            ddlPlanoSeniorFuneralCategoriaNovo.DataValueField = "Key";
            ddlPlanoSeniorFuneralCategoriaNovo.DataTextField = "Value";
            ddlPlanoSeniorFuneralCategoriaNovo.DataSource = ControllerPlanoSenior.ListarTodosFuneralCategoria(true);
            ddlPlanoSeniorFuneralCategoriaNovo.DataBind();
        }

        private void PopularPlanoProtecaoVOIncial()
        {
            txtAgregadoQuantidade.Text = ListaAgregadoVONovo.Count().ToString();
            txtAgregadoPremio.Text = ListaAgregadoVONovo.Sum(registro => registro.Premio).ToString();
            txtPlanoProtecaoFuneralMorte.Text = PlanoProtecaoVO.CoberturaMorte.ToString();
            txtPlanoProtecaoFuneralIPA.Text = PlanoProtecaoVO.CoberturaAcidente.ToString();
            txtPlanoProtecaoFuneralAssistencia.Text = PlanoProtecaoVO.CoberturaEmergencia.ToString();
            txtPlanoProtecaoFuneralDescricao.Text = PlanoProtecaoVO.NomePlano;
            txtPlanoProtecaoFuneralPremio.Text = PlanoProtecaoVO.ValorPremioIdadeBase.GetValueOrDefault().ToString();
        }

        private void PopularPlanoCasalVOIncial()
        {
            txtAgregadoQuantidade.Text = ListaAgregadoVONovo.Count().ToString();
            txtAgregadoPremio.Text = ListaAgregadoVONovo.Sum(registro => registro.Premio).ToString();
            txtPlanoCasalFuneralPrincipal.Text = PlanoCasalVO.CoberturaMorte.ToString();
            txtPlanoCasalFuneralConjuge.Text = PlanoCasalVO.CoberturaConjuge.ToString();
            txtPlanoCasalFuneralCategoria.Text = PlanoCasalVO.NomePlano;
            txtPlanoCasalFuneralPremio.Text = PlanoCasalVO.ValorPremioIdadeBase.GetValueOrDefault().ToString();
        }

        private void PopularPlanoSeniorVOIncial()
        {
            txtAgregadoQuantidade.Text = ListaAgregadoVONovo.Count().ToString();
            txtAgregadoPremio.Text = ListaAgregadoVONovo.Sum(registro => registro.Premio).ToString();
            txtPlanoSeniorFuneralPrincipal.Text = PlanoSeniorVO.CoberturaMorte.ToString();
            txtPlanoSeniorFuneralCategoria.Text = PlanoSeniorVO.NomePlano;
            txtPlanoSeniorFuneralPremio.Text = PlanoSeniorVO.ValorPremioIdadeBase.GetValueOrDefault().ToString();
        }

        #endregion

        #region [ CHECK ]

        private void VerificaPlanoProtecaoFuneral()
        {
            if (ddlPlanoProtecaoFuneralMorteNovo.SelectedIndex > 0 && ddlPlanoProtecaoFuneralIPANovo.SelectedIndex > 0 && ddlPlanoProtecaoFuneralAssistenciaNovo.SelectedIndex > 0 && ddlPlanoProtecaoFuneralCategoriaNovo.SelectedIndex > 0)
            {
                PlanoProtecaoFuneralNovoVO = ControllerPlanoProtecao.CalcularPremioFuneral(Convert.ToDecimal(ddlPlanoProtecaoFuneralMorteNovo.SelectedValue), Convert.ToDecimal(ddlPlanoProtecaoFuneralIPANovo.SelectedValue), Convert.ToDecimal(ddlPlanoProtecaoFuneralAssistenciaNovo.SelectedValue), Convert.ToInt32(ddlPlanoProtecaoFuneralCategoriaNovo.SelectedValue), FaixaBase);
                txtPlanoProtecaoFuneralPremioNovo.Text = PlanoProtecaoFuneralNovoVO.ValorPremioIdadeBase.GetValueOrDefault().ToString();
            }
        }

        private void VerificaPlanoProtecaoRenda()
        {
            if (ddlPlanoProtecaoRendaValorNovo.SelectedIndex > 0 && ddlPlanoProtecaoRendaPeriodoNovo.SelectedIndex > 0)
            {
                PlanoProtecaoRendaNovoVO = ControllerPlanoProtecao.CalcularPremioRenda(ddlPlanoProtecaoRendaPeriodoNovo.SelectedItem.Text, Convert.ToDecimal(ddlPlanoProtecaoRendaValorNovo.SelectedValue), FaixaBase);
                txtPlanoProtecaoRendaPremioNovo.Text = PlanoProtecaoRendaNovoVO.RendaValorPremioIdadeBase.GetValueOrDefault().ToString();
                txtPlanoProtecaoRendaCapitalNovo.Text = PlanoProtecaoRendaNovoVO.RendaCoberturaCapitalTotal.ToString();
            }
        }

        private void VerificaPlanoCasalFuneral()
        {
            if (ddlPlanoCasalFuneralPrincipalNovo.SelectedIndex > 0 && ddlPlanoCasalFuneralConjugeNovo.SelectedIndex > 0 && ddlPlanoCasalFuneralCategoriaNovo.SelectedIndex > 0)
            {
                PlanoCasalFuneralNovoVO = ControllerPlanoCasal.CalcularPremioFuneral(Convert.ToDecimal(ddlPlanoCasalFuneralPrincipalNovo.SelectedValue), Convert.ToDecimal(ddlPlanoCasalFuneralConjugeNovo.SelectedValue), Convert.ToInt32(ddlPlanoCasalFuneralCategoriaNovo.SelectedValue), FaixaBase);
                txtPlanoCasalFuneralPremioNovo.Text = PlanoCasalFuneralNovoVO.ValorPremioIdadeBase.GetValueOrDefault().ToString();
            }
        }

        private void VerificaPlanoSeniorFuneral()
        {
            if (ddlPlanoSeniorFuneralPrincipalNovo.SelectedIndex > 0 && ddlPlanoSeniorFuneralCategoriaNovo.SelectedIndex > 0)
            {
                PlanoSeniorFuneralNovoVO = ControllerPlanoSenior.CalcularPremioFuneral(Convert.ToDecimal(ddlPlanoSeniorFuneralPrincipalNovo.SelectedValue), Convert.ToInt32(ddlPlanoSeniorFuneralCategoriaNovo.SelectedValue), FaixaBase);
                txtPlanoSeniorFuneralPremioNovo.Text = PlanoSeniorFuneralNovoVO.ValorPremioIdadeBase.GetValueOrDefault().ToString();
            }
        }

        #endregion

        #region [ FILL ]

        private void PreencherPlanoProtecaoFuneral()
        {
            PlanoProtecaoVO.IDPlanoProtecao = PlanoProtecaoFuneralNovoVO.IDPlanoProtecao;
            PlanoProtecaoVO.Codigo = PlanoProtecaoFuneralNovoVO.Codigo;
            PlanoProtecaoVO.NomePlano = PlanoProtecaoFuneralNovoVO.NomePlano;
            PlanoProtecaoVO.CoberturaMorte = PlanoProtecaoFuneralNovoVO.CoberturaMorte;
            PlanoProtecaoVO.CoberturaAcidente = PlanoProtecaoFuneralNovoVO.CoberturaAcidente;
            PlanoProtecaoVO.CoberturaEmergencia = PlanoProtecaoFuneralNovoVO.CoberturaEmergencia;
            PlanoProtecaoVO.Premio_18_30 = PlanoProtecaoFuneralNovoVO.Premio_18_30;
            PlanoProtecaoVO.Premio_31_40 = PlanoProtecaoFuneralNovoVO.Premio_31_40;
            PlanoProtecaoVO.Premio_41_45 = PlanoProtecaoFuneralNovoVO.Premio_41_45;
            PlanoProtecaoVO.Premio_46_50 = PlanoProtecaoFuneralNovoVO.Premio_46_50;
            PlanoProtecaoVO.Premio_51_55 = PlanoProtecaoFuneralNovoVO.Premio_51_55;
            PlanoProtecaoVO.Premio_56_60 = PlanoProtecaoFuneralNovoVO.Premio_56_60;
            PlanoProtecaoVO.Premio_61_65 = PlanoProtecaoFuneralNovoVO.Premio_61_65;
            PlanoProtecaoVO.ValorPremioIdadeBase = PlanoProtecaoFuneralNovoVO.ValorPremioIdadeBase;

            txtPlanoProtecaoFuneralMorte.Text = PlanoProtecaoVO.CoberturaMorte.ToString();
            txtPlanoProtecaoFuneralIPA.Text = PlanoProtecaoVO.CoberturaAcidente.ToString();
            txtPlanoProtecaoFuneralAssistencia.Text = PlanoProtecaoVO.CoberturaEmergencia.ToString();
            txtPlanoProtecaoFuneralDescricao.Text = PlanoProtecaoVO.NomePlano;
            txtPlanoProtecaoFuneralPremio.Text = PlanoProtecaoVO.ValorPremioIdadeBase.ToString();
        }

        private void PreencherPlanoProtecaoAgregado()
        {
            ListaAgregadoVONovo = ListaAgregadoVOTemp;
            ListaAgregadoVOTemp = new List<TAgregadoVO>();
            txtAgregadoQuantidade.Text = ListaAgregadoVONovo.Count().ToString();
            txtAgregadoPremio.Text = ListaAgregadoVONovo.Sum(registro => registro.Premio).ToString();
        }

        private void PreencherPlanoProtecaoRenda()
        {
            PlanoProtecaoVO.IDPlanoProtecaoRenda = PlanoProtecaoRendaNovoVO.IDPlanoProtecaoRenda;
            PlanoProtecaoVO.RendaPeriodo = PlanoProtecaoRendaNovoVO.RendaPeriodo;
            PlanoProtecaoVO.RendaCoberturaRendaMensal = PlanoProtecaoRendaNovoVO.RendaCoberturaRendaMensal;
            PlanoProtecaoVO.RendaCoberturaCapitalTotal = PlanoProtecaoRendaNovoVO.RendaCoberturaCapitalTotal;
            PlanoProtecaoVO.RendaPremio_18_30 = PlanoProtecaoRendaNovoVO.RendaPremio_18_30;
            PlanoProtecaoVO.RendaPremio_31_40 = PlanoProtecaoRendaNovoVO.RendaPremio_31_40;
            PlanoProtecaoVO.RendaPremio_41_45 = PlanoProtecaoRendaNovoVO.RendaPremio_41_45;
            PlanoProtecaoVO.RendaPremio_46_50 = PlanoProtecaoRendaNovoVO.RendaPremio_46_50;
            PlanoProtecaoVO.RendaPremio_51_55 = PlanoProtecaoRendaNovoVO.RendaPremio_51_55;
            PlanoProtecaoVO.RendaPremio_56_60 = PlanoProtecaoRendaNovoVO.RendaPremio_56_60;
            PlanoProtecaoVO.RendaPremio_61_65 = PlanoProtecaoRendaNovoVO.RendaPremio_61_65;
            PlanoProtecaoVO.RendaValorPremioIdadeBase = PlanoProtecaoRendaNovoVO.RendaValorPremioIdadeBase;


            txtPlanoProtecaoRendaValor.Text = PlanoProtecaoVO.RendaCoberturaRendaMensal.ToString();
            txtPlanoProtecaoRendaPeriodo.Text = PlanoProtecaoVO.RendaPeriodo.ToString();
            txtPlanoProtecaoRendaCapital.Text = PlanoProtecaoVO.RendaCoberturaCapitalTotal.ToString();
            txtPlanoProtecaoRendaPremio.Text = PlanoProtecaoVO.RendaValorPremioIdadeBase.ToString();

        }

        private void PreencherPlanoCasalFuneral()
        {
            PlanoCasalVO.IDPlanoCasal = PlanoCasalFuneralNovoVO.IDPlanoCasal;
            PlanoCasalVO.Codigo = PlanoCasalFuneralNovoVO.Codigo;
            PlanoCasalVO.NomePlano = PlanoCasalFuneralNovoVO.NomePlano;
            PlanoCasalVO.CoberturaMorte = PlanoCasalFuneralNovoVO.CoberturaMorte;
            PlanoCasalVO.CoberturaConjuge = PlanoCasalFuneralNovoVO.CoberturaConjuge;
            PlanoCasalVO.Premio_61_65 = PlanoCasalFuneralNovoVO.Premio_61_65;
            PlanoCasalVO.Premio_66_70 = PlanoCasalFuneralNovoVO.Premio_66_70;
            PlanoCasalVO.Premio_71_75 = PlanoCasalFuneralNovoVO.Premio_71_75;
            PlanoCasalVO.Premio_76_80 = PlanoCasalFuneralNovoVO.Premio_76_80;
            PlanoCasalVO.ValorPremioIdadeBase = PlanoCasalFuneralNovoVO.ValorPremioIdadeBase;

            txtPlanoCasalFuneralPrincipal.Text = PlanoCasalVO.CoberturaMorte.ToString();
            txtPlanoCasalFuneralConjuge.Text = PlanoCasalVO.CoberturaConjuge.ToString();
            txtPlanoCasalFuneralCategoria.Text = PlanoCasalVO.NomePlano;
            txtPlanoCasalFuneralPremio.Text = PlanoCasalVO.ValorPremioIdadeBase.ToString();
        }

        private void PreencherPlanoSeniorFuneral()
        {
            PlanoSeniorVO.IDPlanoSenior = PlanoSeniorFuneralNovoVO.IDPlanoSenior;
            PlanoSeniorVO.Codigo = PlanoSeniorFuneralNovoVO.Codigo;
            PlanoSeniorVO.NomePlano = PlanoSeniorFuneralNovoVO.NomePlano;
            PlanoSeniorVO.CoberturaMorte = PlanoSeniorFuneralNovoVO.CoberturaMorte;
            PlanoSeniorVO.Premio_61_65 = PlanoSeniorFuneralNovoVO.Premio_61_65;
            PlanoSeniorVO.Premio_66_70 = PlanoSeniorFuneralNovoVO.Premio_66_70;
            PlanoSeniorVO.Premio_71_75 = PlanoSeniorFuneralNovoVO.Premio_71_75;
            PlanoSeniorVO.Premio_76_80 = PlanoSeniorFuneralNovoVO.Premio_76_80;
            PlanoSeniorVO.ValorPremioIdadeBase = PlanoSeniorFuneralNovoVO.ValorPremioIdadeBase;

            txtPlanoSeniorFuneralPrincipal.Text = PlanoSeniorVO.CoberturaMorte.ToString();
            txtPlanoSeniorFuneralCategoria.Text = PlanoSeniorVO.NomePlano;
            txtPlanoSeniorFuneralPremio.Text = PlanoSeniorVO.ValorPremioIdadeBase.ToString();
        }

        #endregion

        #region [ CALCULATE PRIZE ]

        private void CalcularValorTotalPlanoProtecao()
        {
            decimal premioRenda = 0;
            decimal premioAgregado = 0;
            decimal premioFuneral = 0;
            decimal premioTotal = 0;

            if (!string.IsNullOrEmpty(txtPlanoProtecaoRendaPremio.Text))
                premioRenda = Convert.ToDecimal(txtPlanoProtecaoRendaPremio.Text);

            if (!string.IsNullOrEmpty(txtAgregadoPremio.Text))
                premioAgregado = Convert.ToDecimal(txtAgregadoPremio.Text);

            if (!string.IsNullOrEmpty(txtPlanoProtecaoFuneralPremio.Text))
                premioFuneral = Convert.ToDecimal(txtPlanoProtecaoFuneralPremio.Text);

            premioTotal = premioRenda + premioAgregado + premioFuneral;
            txtValorTotalPremio.Text = premioTotal.ToString();

        }

        private void CalcularValorTotalPlanoCasal()
        {
            decimal premioAgregado = 0;
            decimal premioFuneral = 0;
            decimal premioTotal = 0;

            if (!string.IsNullOrEmpty(txtAgregadoPremio.Text))
                premioAgregado = Convert.ToDecimal(txtAgregadoPremio.Text);

            if (!string.IsNullOrEmpty(txtPlanoCasalFuneralPremio.Text))
                premioFuneral = Convert.ToDecimal(txtPlanoCasalFuneralPremio.Text);

            premioTotal = premioAgregado + premioFuneral;
            txtValorTotalPremio.Text = premioTotal.ToString();
        }

        private void CalcularValorTotalPlanoSenior()
        {
            decimal premioAgregado = 0;
            decimal premioFuneral = 0;
            decimal premioTotal = 0;

            if (!string.IsNullOrEmpty(txtAgregadoPremio.Text))
                premioAgregado = Convert.ToDecimal(txtAgregadoPremio.Text);

            if (!string.IsNullOrEmpty(txtPlanoSeniorFuneralPremio.Text))
                premioFuneral = Convert.ToDecimal(txtPlanoSeniorFuneralPremio.Text);

            premioTotal = premioAgregado + premioFuneral;
            txtValorTotalPremio.Text = premioTotal.ToString();
        }

        #endregion
        
        private void OcultarTodosProdutos()
        {
            trPlanoProtecaoRenda.Visible = false;
            tblPlanoProtecaoRendaNovo.Visible = false;
            trPlanoProtecaoRendaEspaco.Visible = false;

            trPlanoAgregados.Visible = false;
            tblPlanoProtecaoAgregadosNovo.Visible = false;

            trPlanoProtecaoFuneral.Visible = false;
            tblPlanoProtecaoFuneralNovo.Visible = false;

            trPlanoCasalFuneral.Visible = false;
            tblPlanoCasalFuneralNovo.Visible = false;

            trPlanoSeniorFuneral.Visible = false;
            tblPlanoSeniorFuneralNovo.Visible = false;
        }

        private void LimparPlanos()
        {
            PlanoProtecaoVO = new TPlanoProtecaoVO();
            PlanoCasalVO = new TPlanoCasalVO();
            PlanoSeniorVO = new TPlanoSeniorVO();
            PlanoProtecaoFuneralNovoVO = new TPlanoProtecaoVO();
            PlanoProtecaoRendaNovoVO = new TPlanoProtecaoVO();
            PlanoCasalFuneralNovoVO = new TPlanoCasalVO();
            PlanoSeniorFuneralNovoVO = new TPlanoSeniorVO();
            ListaAgregadoVONovo = new List<TAgregadoVO>();
            ListaAgregadoVOTemp = new List<TAgregadoVO>();
        }

        private void LimparTela()
        {
            txtPlanoProtecaoFuneralMorte.Text = string.Empty;
            txtPlanoProtecaoFuneralIPA.Text = string.Empty;
            txtPlanoProtecaoFuneralAssistencia.Text = string.Empty;
            txtPlanoProtecaoFuneralDescricao.Text = string.Empty;
            txtPlanoProtecaoFuneralPremio.Text = string.Empty;
            txtAgregadoQuantidade.Text = string.Empty;
            txtAgregadoPremio.Text = string.Empty;
            txtPlanoProtecaoRendaValor.Text = string.Empty;
            txtPlanoProtecaoRendaPeriodo.Text = string.Empty;
            txtPlanoProtecaoRendaCapital.Text = string.Empty;
            txtPlanoProtecaoRendaPremio.Text = string.Empty;
            txtPlanoCasalFuneralPrincipal.Text = string.Empty;
            txtPlanoCasalFuneralConjuge.Text = string.Empty;
            txtPlanoCasalFuneralCategoria.Text = string.Empty;
            txtPlanoCasalFuneralPremio.Text = string.Empty;
            txtPlanoSeniorFuneralPrincipal.Text = string.Empty;
            txtPlanoSeniorFuneralCategoria.Text = string.Empty;
            txtPlanoSeniorFuneralPremio.Text = string.Empty;
            txtValorTotalPremio.Text = string.Empty;
            txtPlanoProtecaoRendaPremioNovo.Text = "0";
            txtPlanoProtecaoAgregadosPremioNovo.Text = "0";
            txtPlanoProtecaoFuneralPremioNovo.Text = "0";
            txtPlanoCasalFuneralPremioNovo.Text = "0";
            txtPlanoSeniorFuneralPremioNovo.Text = "0";
        }

        public void ExibirModal(bool exibir)
        {
            if (exibir)
            {
                ModalPopupExtender1.Show();
                panelModal.Visible = true;

                Popular();
            }
            else
            {
                ModalPopupExtender1.Hide();
            }
        }

        #endregion

        #region [ BUTTONS ]

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            LimparPlanos();

            ExibirModal(false);
        }

        #region [ PANEL PRODUTOS ]

        protected void btnProdutoAltera_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlProdutoAlterar.SelectedIndex > 0)
            {
                LimparPlanos();
                LimparTela();
                switch (Convert.ToInt32(ddlProdutoAlterar.SelectedValue))
                {
                    case (int)ProdutoPrincipal.PLANOPROTECAO:
                        Controller.PlanoProtecao((int)FaixaEtaria.PREMIO_61_65, FaixaBase, Resposta2, Resposta7);
                        PlanoProtecaoVO = Controller.PlanoProtecaoVO;
                        break;
                    case (int)ProdutoPrincipal.PLANOCASAL:
                        Controller.PlanoSeniorCasal(FaixaBase, Resposta2, Resposta7);
                        PlanoCasalVO = Controller.PlanoCasalVO;
                        break;
                    case (int)ProdutoPrincipal.PLANOSENIOR:
                        Controller.PlanoSenior(FaixaBase, Resposta2, Resposta7);
                        PlanoSeniorVO = Controller.PlanoSeniorVO;
                        break;
                    default:
                        break;
                }

                OcultarTodosProdutos();

                Popular();

                ddlProdutoAlterar.SelectedIndex = 0;
            }
            ModalPopupExtender1.Show();
        }

        #endregion

        #region [ PANEL PROTEÇÃO RENDA ]

        protected void btnRendaNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoProtecaoRendaNovo.Visible = true;
            if (FaixaBase != (int)FaixaEtaria.PREMIO_18_30)
            {
                ddlPlanoProtecaoRendaValorNovo.Enabled = true;
                ddlPlanoProtecaoRendaPeriodoNovo.AutoPostBack = false;
                PopularPlanoProtecaoRendaValor();
            }
            else
            {
                ddlPlanoProtecaoRendaValorNovo.Enabled = false;
                ddlPlanoProtecaoRendaPeriodoNovo.AutoPostBack = true;
            }

            if(ddlPlanoProtecaoRendaValorNovo.Items.Count>0)
                ddlPlanoProtecaoRendaValorNovo.SelectedIndex = 0;
            
            ddlPlanoProtecaoRendaPeriodoNovo.SelectedIndex = 0;
            txtPlanoProtecaoRendaCapitalNovo.Text = string.Empty;       

            ModalPopupExtender1.Show();
        }

        protected void ddlPlanoProtecaoRendaPeriodoNovo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FaixaBase == (int)FaixaEtaria.PREMIO_18_30)
            {
                if (ddlPlanoProtecaoRendaPeriodoNovo.SelectedIndex == 0)
                {
                    ddlPlanoProtecaoRendaValorNovo.Enabled = false;
                    ddlPlanoProtecaoRendaValorNovo.SelectedIndex = 0;
                }
                else
                {
                    ddlPlanoProtecaoRendaValorNovo.Enabled = true;
                    PopularPlanoProtecaoRendaValor();
                }

                ModalPopupExtender1.Show();
            }
        }

        protected void btnPlanoProtecaoRendaVoltarNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoProtecaoRendaNovo.Visible = false;
            ModalPopupExtender1.Show();
        }

        protected void btnPlanoProtecaoRendaSalvarNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoProtecaoRendaNovo.Visible = false;
            PreencherPlanoProtecaoRenda();
            CalcularValorTotalPlanoProtecao();
            ModalPopupExtender1.Show();
        }

        protected void btnPlanoProtecaoRendaAtualizarNovo_Click(object sender, ImageClickEventArgs e)
        {
            VerificaPlanoProtecaoRenda();
            ModalPopupExtender1.Show();
        }

        #endregion

        #region [ PANEL AGREGADO ]

        protected void btnAgregadoNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoProtecaoAgregadosNovo.Visible = true;
            ListaAgregadoVOTemp = ListaAgregadoVONovo;
            txtPlanoProtecaoAgregadosPremioNovo.Text = ListaAgregadoVOTemp.Sum(registro => registro.Premio).ToString();
            grdPlanoProtecaoAgregadosNovo.DataSource = ListaAgregadoVOTemp;
            grdPlanoProtecaoAgregadosNovo.DataBind();

            ddlPlanoProtecaoAgregadosGrauNovo.SelectedIndex = 0;
            txtPlanoProtecaoAgregadosIdadeNovo.Text = string.Empty;
                        
            ModalPopupExtender1.Show();
        }

        protected void imgPlanoProtecaoAgregadosNovo_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlPlanoProtecaoAgregadosGrauNovo.SelectedIndex > 0 && !string.IsNullOrEmpty(txtPlanoProtecaoAgregadosIdadeNovo.Text))
            {
                if (Convert.ToInt32(txtPlanoProtecaoAgregadosIdadeNovo.Text) <= 80)
                {
                    if ((FaixaBase >= 7) && (txtProdutoDefinido.Text.Equals(ProdutoPrincipal.PLANOSENIOR.GetStringValue())) && (Convert.ToInt32(ddlPlanoProtecaoAgregadosGrauNovo.SelectedValue) == (int)GrauParentesco.CONJUGE) && (Convert.ToInt32(txtPlanoProtecaoAgregadosIdadeNovo.Text) <= 61))
                    {
                        RequiredFieldValidator required = new RequiredFieldValidator();
                        required.ValidationGroup = "PlanoProtecaoAgregadosNovo";
                        required.ErrorMessage = "O titular não poderá informar o cônjuge como agregado.";
                        required.IsValid = false;
                        required.ControlToValidate = ddlPlanoProtecaoAgregadosGrauNovo.ID;
                        ValidationSummary2.Controls.Add(required);
                    }
                    else
                    {
                        List<TAgregadoVO> ListaTemp = ListaAgregadoVOTemp;
                        TAgregadoVO temporario = new TAgregadoVO();
                        temporario.Identificador = ListaTemp.Count() + 1;
                        temporario.GrauParentesco = ddlPlanoProtecaoAgregadosGrauNovo.SelectedItem.Text;
                        temporario.Idade = Convert.ToInt32(txtPlanoProtecaoAgregadosIdadeNovo.Text);

                        if (PlanoProtecaoVO.IDPlanoProtecao > 0)
                            temporario.Premio = ControllerPlanoProtecao.CalcularPremioAgregado(Convert.ToInt32(ddlPlanoProtecaoAgregadosGrauNovo.SelectedValue), temporario.Idade, PlanoProtecaoVO.NomePlano);

                        if (PlanoCasalVO.IDPlanoCasal > 0)
                            temporario.Premio = ControllerPlanoCasal.CalcularPremioAgregado(Convert.ToInt32(ddlPlanoProtecaoAgregadosGrauNovo.SelectedValue), temporario.Idade, PlanoCasalVO.NomePlano);

                        if (PlanoSeniorVO.IDPlanoSenior > 0)
                            temporario.Premio = ControllerPlanoSenior.CalcularPremioAgregado(Convert.ToInt32(ddlPlanoProtecaoAgregadosGrauNovo.SelectedValue), temporario.Idade, PlanoSeniorVO.NomePlano);

                        ListaTemp.Add(temporario);
                        ListaAgregadoVOTemp = ListaTemp;
                        grdPlanoProtecaoAgregadosNovo.DataSource = ListaAgregadoVOTemp;
                        grdPlanoProtecaoAgregadosNovo.DataBind();

                        txtPlanoProtecaoAgregadosPremioNovo.Text = ListaAgregadoVOTemp.Sum(registro => registro.Premio).ToString();
                        ddlPlanoProtecaoAgregadosGrauNovo.SelectedIndex = 0;
                        txtPlanoProtecaoAgregadosIdadeNovo.Text = string.Empty;
                    }
                }
            }

            ModalPopupExtender1.Show();
        }

        protected void grdPlanoProtecaoAgregadosNovo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPlanoProtecaoAgregadosNovo.PageIndex = e.NewPageIndex;

            grdPlanoProtecaoAgregadosNovo.DataSource = ListaAgregadoVOTemp;
            grdPlanoProtecaoAgregadosNovo.DataBind();
            ModalPopupExtender1.Show();
        }

        protected void grdPlanoProtecaoAgregadosNovo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                List<TAgregadoVO> ListTemp = ListaAgregadoVOTemp;
                ListTemp.RemoveAt(e.RowIndex);
                ListaAgregadoVOTemp = ListTemp;
                txtPlanoProtecaoAgregadosPremioNovo.Text = ListaAgregadoVOTemp.Sum(registro => registro.Premio).ToString();
                grdPlanoProtecaoAgregadosNovo.DataSource = ListaAgregadoVOTemp;
                grdPlanoProtecaoAgregadosNovo.DataBind();
                ModalPopupExtender1.Show();

            }
            catch
            {
                e.Cancel = true;
            }
        }

        protected void grdPlanoProtecaoAgregadosNovo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgExcluir = (ImageButton)e.Row.Cells[0].Controls[0];
                if (imgExcluir != null && imgExcluir.CommandName == "Delete")
                    imgExcluir.OnClientClick = "return ExibirMensagemConfirmacaoGridView('" + grdPlanoProtecaoAgregadosNovo.UniqueID + "','" + imgExcluir.CommandArgument + "');";
            }
        }

        protected void btnPlanoProtecaoAgregadosVoltarNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoProtecaoAgregadosNovo.Visible = false;
            ModalPopupExtender1.Show();
        }

        protected void btnPlanoProtecaoAgregadosSalvarNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoProtecaoAgregadosNovo.Visible = false;
            grdPlanoProtecaoAgregadosNovo.DataSource = null;
            grdPlanoProtecaoAgregadosNovo.DataBind();
            PreencherPlanoProtecaoAgregado();

            if(txtProdutoDefinido.Text.Equals(ProdutoPrincipal.PLANOPROTECAO.GetStringValue()))
                CalcularValorTotalPlanoProtecao();

            if (txtProdutoDefinido.Text.Equals(ProdutoPrincipal.PLANOCASAL.GetStringValue())) 
                CalcularValorTotalPlanoCasal();

            if (txtProdutoDefinido.Text.Equals(ProdutoPrincipal.PLANOSENIOR.GetStringValue())) 
                CalcularValorTotalPlanoSenior();
            
            ModalPopupExtender1.Show();
        }

        #endregion

        #region [ PANEL PROTEÇÃO FUNERAL ]

        protected void btnFuneralNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoProtecaoFuneralNovo.Visible = true;

            ddlPlanoProtecaoFuneralMorteNovo.SelectedIndex = 0;
            ddlPlanoProtecaoFuneralIPANovo.SelectedIndex = 0;
            ddlPlanoProtecaoFuneralAssistenciaNovo.SelectedIndex = 0;
            ddlPlanoProtecaoFuneralCategoriaNovo.SelectedIndex = 0;
                  
            ModalPopupExtender1.Show();
        }

        protected void ddlPlanoProtecaoFuneralMorteNovo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlPlanoProtecaoFuneralMorteNovo.SelectedValue.Equals(ddlPlanoProtecaoFuneralIPANovo.SelectedValue))
                ddlPlanoProtecaoFuneralIPANovo.SelectedValue = ddlPlanoProtecaoFuneralMorteNovo.SelectedValue;

            ModalPopupExtender1.Show();
        }

        protected void ddlPlanoProtecaoFuneralIPANovo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlPlanoProtecaoFuneralIPANovo.SelectedValue.Equals(ddlPlanoProtecaoFuneralMorteNovo.SelectedValue))
                ddlPlanoProtecaoFuneralMorteNovo.SelectedValue = ddlPlanoProtecaoFuneralIPANovo.SelectedValue;

            ModalPopupExtender1.Show();
        }

        protected void btnPlanoProtecaoFuneralVoltarNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoProtecaoFuneralNovo.Visible = false;
            ModalPopupExtender1.Show();
        }

        protected void btnPlanoProtecaoFuneralSalvarNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoProtecaoFuneralNovo.Visible = false;
            PreencherPlanoProtecaoFuneral();
            CalcularValorTotalPlanoProtecao();
            ModalPopupExtender1.Show();
        }

        protected void btnPlanoProtecaoFuneralAtualizarNovo_Click(object sender, ImageClickEventArgs e)
        {
            VerificaPlanoProtecaoFuneral();
            ModalPopupExtender1.Show();
        }

        #endregion

        #region [ PANEL CASAL FUNERAL ]

        protected void btnPlanoCasalFuneralNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoCasalFuneralNovo.Visible = true;

            ddlPlanoCasalFuneralPrincipalNovo.SelectedIndex = 0;
            ddlPlanoCasalFuneralConjugeNovo.SelectedIndex = 0;
            ddlPlanoCasalFuneralCategoriaNovo.SelectedIndex = 0;
                   
            ModalPopupExtender1.Show();
        }

        protected void ddlPlanoCasalFuneralPrincipalNovo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPlanoCasalFuneralPrincipalNovo.SelectedIndex != ddlPlanoCasalFuneralConjugeNovo.SelectedIndex)
                ddlPlanoCasalFuneralConjugeNovo.SelectedIndex = ddlPlanoCasalFuneralPrincipalNovo.SelectedIndex;

            ModalPopupExtender1.Show();
        }

        protected void ddlPlanoCasalFuneralConjugeNovo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPlanoCasalFuneralConjugeNovo.SelectedIndex != ddlPlanoCasalFuneralPrincipalNovo.SelectedIndex)
                ddlPlanoCasalFuneralPrincipalNovo.SelectedIndex = ddlPlanoCasalFuneralConjugeNovo.SelectedIndex;

            ModalPopupExtender1.Show();
        }

        protected void btnPlanoCasalFuneralVoltarNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoCasalFuneralNovo.Visible = false;
            ModalPopupExtender1.Show();
        }

        protected void btnPlanoCasalFuneralSalvarNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoCasalFuneralNovo.Visible = false;
            PreencherPlanoCasalFuneral();
            CalcularValorTotalPlanoCasal();
            ModalPopupExtender1.Show();
        }

        protected void btnPlanoCasalFuneralAtualizarNovo_Click(object sender, ImageClickEventArgs e)
        {
            VerificaPlanoCasalFuneral();
            ModalPopupExtender1.Show();
        }

        #endregion

        #region [ PANEL SENIOR FUNERAL ]

        protected void btnPlanoSeniorFuneralNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoSeniorFuneralNovo.Visible = true;

            ddlPlanoSeniorFuneralPrincipalNovo.SelectedIndex = 0;
            ddlPlanoSeniorFuneralCategoriaNovo.SelectedIndex = 0;
                        
            ModalPopupExtender1.Show();
        }

        protected void btnPlanoSeniorFuneralVoltarNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoSeniorFuneralNovo.Visible = false;
            ModalPopupExtender1.Show();
        }

        protected void btnPlanoSeniorFuneralSalvarNovo_Click(object sender, ImageClickEventArgs e)
        {
            tblPlanoSeniorFuneralNovo.Visible = false;
            PreencherPlanoSeniorFuneral();
            CalcularValorTotalPlanoSenior();
            ModalPopupExtender1.Show();
        }

        protected void btnPlanoSeniorFuneralAtualizarNovo_Click(object sender, ImageClickEventArgs e)
        {
            VerificaPlanoSeniorFuneral();
            ModalPopupExtender1.Show();
        }

        #endregion
                    
        #endregion                

       
    }
}