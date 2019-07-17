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
    public partial class simuladorPlano : PaginaBase
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
               
        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region [ METHODS ]

        protected int VerificaFaixaTitular()
        {
            if (rdbTitular18.Checked)
                return (int)FaixaEtaria.PREMIO_18_30;

            if (rdbTitular31.Checked)
                return (int)FaixaEtaria.PREMIO_31_40;

            if (rdbTitular41.Checked)
                return (int)FaixaEtaria.PREMIO_41_45;

            if (rdbTitular46.Checked)
                return (int)FaixaEtaria.PREMIO_46_50;

            if (rdbTitular51.Checked)
                return (int)FaixaEtaria.PREMIO_51_55;

            if (rdbTitular56.Checked)
                return (int)FaixaEtaria.PREMIO_56_60;

            if (rdbTitular61.Checked)
                return (int)FaixaEtaria.PREMIO_61_65;

            if (rdbTitular66.Checked)
                return (int)FaixaEtaria.PREMIO_66_70;

            if (rdbTitular71.Checked)
                return (int)FaixaEtaria.PREMIO_71_75;

            if (rdbTitular76.Checked)
                return (int)FaixaEtaria.PREMIO_76_80;

            return 0;
        }

        protected int VerificaFaixaConjuge()
        {

            if (rdbConjuge18.Checked)
                return (int)FaixaEtaria.PREMIO_18_30;

            if (rdbConjuge31.Checked)
                return (int)FaixaEtaria.PREMIO_31_40;

            if (rdbConjuge41.Checked)
                return (int)FaixaEtaria.PREMIO_41_45;

            if (rdbConjuge46.Checked)
                return (int)FaixaEtaria.PREMIO_46_50;

            if (rdbConjuge51.Checked)
                return (int)FaixaEtaria.PREMIO_51_55;

            if (rdbConjuge56.Checked)
                return (int)FaixaEtaria.PREMIO_56_60;

            if (rdbConjuge61.Checked)
                return (int)FaixaEtaria.PREMIO_61_65;

            if (rdbConjuge66.Checked)
                return (int)FaixaEtaria.PREMIO_66_70;

            if (rdbConjuge71.Checked)
                return (int)FaixaEtaria.PREMIO_71_75;

            if (rdbConjuge76.Checked)
                return (int)FaixaEtaria.PREMIO_76_80;

            return 0;

        }

        protected int VerificaPergunta2()
        {
            if (rdbPergunta2_15.Checked)
                return (int)PerguntaRenda.ATE_800;

            if (rdbPergunta2_20.Checked)
                return (int)PerguntaRenda.DE_801_1000;

            if (rdbPergunta2_25.Checked)
                return (int)PerguntaRenda.DE_1001_1200;

            if (rdbPergunta2_30.Checked)
                return (int)PerguntaRenda.DE_1201_1400;

            if (rdbPergunta2_35.Checked)
                return (int)PerguntaRenda.DE_1401_1600;

            if (rdbPergunta2_40.Checked)
                return (int)PerguntaRenda.DE_1601_2000;

            if (rdbPergunta2_50.Checked)
                return (int)PerguntaRenda.DE_2001_2500;

            if (rdbPergunta2_60.Checked)
                return (int)PerguntaRenda.ACIMA_2501;

            if (rdbPergunta2_00.Checked)
                return (int)PerguntaRenda.NAO_INFORMA;

            return 0;
        }

        protected int VerificaPergunta7()
        {
            if (rdbPergunta7_15.Checked)
                return (int)PerguntaPremio.PREMIO_15;

            if (rdbPergunta7_20.Checked)
                return (int)PerguntaPremio.PREMIO_20;

            if (rdbPergunta7_25.Checked)
                return (int)PerguntaPremio.PREMIO_25;

            if (rdbPergunta7_30.Checked)
                return (int)PerguntaPremio.PREMIO_30;

            if (rdbPergunta7_35.Checked)
                return (int)PerguntaPremio.PREMIO_35;

            if (rdbPergunta7_40.Checked)
                return (int)PerguntaPremio.PREMIO_40;

            if (rdbPergunta7_50.Checked)
                return (int)PerguntaPremio.PREMIO_50;

            if (rdbPergunta7_60.Checked)
                return (int)PerguntaPremio.PREMIO_60;

            return 0;
        }

        #endregion

        #region [ BUTTONS ]

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<ProdutoPrincipal> ProdutoDisponivel = new List<ProdutoPrincipal>();
                int idadeBase = 0;
                if (Controller.SimularPlano(VerificaFaixaTitular(), VerificaFaixaConjuge(), 0, VerificaPergunta2(), VerificaPergunta7(), ref ProdutoDisponivel, ref idadeBase))
                {
                    Util.Sessao.idadeBase = idadeBase;
                    Util.Sessao.respostaPergunta2 = VerificaPergunta2();
                    Util.Sessao.respostaPergunta7 = VerificaPergunta7();
                    SimuladorTela1.PlanoProtecaoVO = Controller.PlanoProtecaoVO;
                    SimuladorTela1.PlanoSeniorVO = Controller.PlanoSeniorVO;
                    SimuladorTela1.PlanoCasalVO = Controller.PlanoCasalVO;
                    SimuladorTela1.ProdutoDisponivel = ProdutoDisponivel;
                    SimuladorTela1.ExibirModal(true);
                }                                
            }
            catch (CABTECException cabEx)
            {
                MostrarMensagem(cabEx.Message);
            }
            catch (Exception)
            {
                MostrarMensagem("Erro ao Simular Plano.");
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