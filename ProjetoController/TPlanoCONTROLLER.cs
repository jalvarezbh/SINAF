using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;
using System.Web;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace ProjetoController
{
    public class TPlanoCONTROLLER
    {
        #region [ CONTROLLER ]

        private TPlanoProtecaoCONTROLLER _TPlanoProtecaoCONTROLLER;

        public TPlanoProtecaoCONTROLLER TPlanoProtecaoCONTROLLER
        {
            get
            {
                if (_TPlanoProtecaoCONTROLLER == null)
                    _TPlanoProtecaoCONTROLLER = new TPlanoProtecaoCONTROLLER();

                return _TPlanoProtecaoCONTROLLER;

            }
        }

        private TPlanoSeniorCONTROLLER _TPlanoSeniorCONTROLLER;

        public TPlanoSeniorCONTROLLER TPlanoSeniorCONTROLLER
        {
            get
            {
                if (_TPlanoSeniorCONTROLLER == null)
                    _TPlanoSeniorCONTROLLER = new TPlanoSeniorCONTROLLER();

                return _TPlanoSeniorCONTROLLER;

            }
        }

        private TPlanoCasalCONTROLLER _TPlanoCasalCONTROLLER;

        public TPlanoCasalCONTROLLER TPlanoCasalCONTROLLER
        {
            get
            {
                if (_TPlanoCasalCONTROLLER == null)
                    _TPlanoCasalCONTROLLER = new TPlanoCasalCONTROLLER();

                return _TPlanoCasalCONTROLLER;

            }
        }

        private TPlanoProtecaoVO _planoProtecaoVO;
        public TPlanoProtecaoVO PlanoProtecaoVO
        {
            get { return _planoProtecaoVO; }
            set { _planoProtecaoVO = value; }
        }

        private TPlanoSeniorVO _planoSeniorVO;
        public TPlanoSeniorVO PlanoSeniorVO
        {
            get { return _planoSeniorVO; }
            set { _planoSeniorVO = value; }
        }

        private TPlanoCasalVO _planoCasalVO;
        public TPlanoCasalVO PlanoCasalVO
        {
            get { return _planoCasalVO; }
            set { _planoCasalVO = value; }
        }

        #endregion

        #region [ Métodos ]

        #region [ SimularPlano ]

        public bool SimularPlano(int faixaTitular, int faixaConjuge, int faixaFilho, int respPergunta2, int respPergunta7, ref List<ProdutoPrincipal> ProdutoDisponivel , ref int idadeBase)
        {
            try
            {
                idadeBase = 0;

                //Define a idade base
                #region [ Define a Idade Base ]

                if (faixaTitular == faixaConjuge)
                    idadeBase = faixaTitular;
                else
                    if ((faixaTitular > faixaConjuge) && (faixaTitular != 8))
                        idadeBase = faixaTitular;
                    else
                        if ((faixaTitular < faixaConjuge) && (faixaConjuge != 8))
                            idadeBase = faixaConjuge;
                        else
                            if ((faixaTitular == 8) && (faixaConjuge >= 2))
                                idadeBase = faixaConjuge;
                            else
                                if ((faixaTitular == 8) && (faixaConjuge == 1))
                                    idadeBase = faixaTitular;
                                else
                                    if ((faixaConjuge == 8) && (faixaTitular >= 2))
                                        idadeBase = faixaTitular;
                                    else
                                        if ((faixaConjuge == 8) && (faixaTitular == 1))
                                            idadeBase = faixaConjuge;

                #endregion

                //Adiciona a lista de opções de acordo com a Faixa Etária
                #region [ Opções de Produtos ]

                if ((faixaTitular < 7)||(faixaTitular == 8))
                    ProdutoDisponivel.Add(ProdutoPrincipal.PLANOPROTECAO);

                if ((faixaTitular >= 6) && (faixaTitular != 8))
                {
                    ProdutoDisponivel.Add(ProdutoPrincipal.PLANOSENIOR);

                    ProdutoDisponivel.Add(ProdutoPrincipal.PLANOCASAL);
                }
                
                #endregion

                //Verificar o Produto a ser oferecido pela faixa etária do titular e do cônjuge
                #region [ Produto Plano Proteção Familia ]

                if ((faixaTitular > 0) && (faixaTitular < 6 || faixaTitular == 8))
                {
                    PlanoProtecao(faixaTitular,idadeBase, respPergunta2, respPergunta7);
                    return true;
                }

                if ((faixaTitular == 6) && (faixaConjuge == 1 || faixaFilho < 25))
                {
                    PlanoProtecao(faixaTitular,idadeBase, respPergunta2, respPergunta7);
                    return true;
                }

                #endregion

                #region [ Produto Sênior Individual ]

                if ((faixaTitular >= 6) || (faixaTitular != 8))
                {
                    if (faixaConjuge == 0)
                    {
                        PlanoSenior(idadeBase, respPergunta2, respPergunta7);
                        return true;
                    }

                    if ((faixaTitular >= 7) && (((1 <= faixaConjuge) && (faixaConjuge <= 5)) || (faixaConjuge == 8)))
                    {
                        PlanoSenior(idadeBase, respPergunta2, respPergunta7);
                        return true;
                    }
                }

                #endregion

                #region [ Produto Sênior Casal ]

                if (((faixaTitular >= 6) && (faixaTitular != 8)) && ((faixaConjuge >= 6) && (faixaConjuge != 8)))
                {
                    PlanoSeniorCasal(idadeBase, respPergunta2, respPergunta7);
                    return true;
                }

                #endregion

                return false;
            }


            catch (CABTECException cabEx)
            {
                throw new CABTECException(cabEx.Message);
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Simular Plano.");
            }
        }
         
        #endregion

        #region[ PlanoProtecao ]

        public void PlanoProtecao(int faixaTitular, int faixaPadrao, int respPergunta2, int respPergunta7)
        {
            decimal premioMax = 0;
            decimal premioAP = 0;           
            int codigoValorConsiderado = 0;

           #region [ Verifica Pergunta 2 e 7 para obter o Prêmio ]

            if (((respPergunta2 == 0) || (respPergunta2 == 9)) && (respPergunta7 == 0))
                throw new CABTECException("É necessário responder as perguntas 2 e 7 para realizar os cálculos.");

            if (respPergunta2 > 0 && respPergunta2 < 9)
                codigoValorConsiderado = respPergunta2;
            else
                if (respPergunta7 > 0 && respPergunta7 < 9)
                    codigoValorConsiderado = respPergunta7;
                else
                    throw new CABTECException("É necessário responder as perguntas 2 e 7 para realizar os cálculos.");

            switch (codigoValorConsiderado)
            {
                case (int)PerguntaRenda.ATE_800:
                    premioMax = 15;
                    break;
                case (int)PerguntaRenda.DE_801_1000:
                    premioMax = 20;
                    break;
                case (int)PerguntaRenda.DE_1001_1200:
                    premioMax = 25;
                    break;
                case (int)PerguntaRenda.DE_1201_1400:
                    premioMax = 30;
                    break;
                case (int)PerguntaRenda.DE_1401_1600:
                    premioMax = 35;
                    break;
                case (int)PerguntaRenda.DE_1601_2000:
                    premioMax = 40;
                    break;
                case (int)PerguntaRenda.DE_2001_2500:
                    premioMax = 50;
                    break;
                case (int)PerguntaRenda.ACIMA_2501:
                    premioMax = 60;
                    break;
                default:
                    break;
            }

            premioAP = premioMax / 3;

            #endregion

           #region [ Consulta categoria SUPERIOR ]

            if (faixaPadrao > (int)FaixaEtaria.PREMIO_61_65)
                faixaPadrao = faixaTitular;

           PlanoProtecaoVO =  TPlanoProtecaoCONTROLLER.ConsultaCategoriaSuperior(faixaPadrao, premioAP);

           switch (faixaPadrao)
           {
               case (int)FaixaEtaria.PREMIO_18_30:
                   PlanoProtecaoVO.ValorPremioIdadeBase = PlanoProtecaoVO.Premio_18_30;
                   break;
               case (int)FaixaEtaria.PREMIO_31_40:
                   PlanoProtecaoVO.ValorPremioIdadeBase = PlanoProtecaoVO.Premio_31_40;
                   break;
               case (int)FaixaEtaria.PREMIO_41_45:
                   PlanoProtecaoVO.ValorPremioIdadeBase = PlanoProtecaoVO.Premio_41_45;
                   break;
               case (int)FaixaEtaria.PREMIO_46_50:
                   PlanoProtecaoVO.ValorPremioIdadeBase = PlanoProtecaoVO.Premio_46_50;
                   break;
               case (int)FaixaEtaria.PREMIO_51_55:
                   PlanoProtecaoVO.ValorPremioIdadeBase = PlanoProtecaoVO.Premio_51_55;
                   break;
               case (int)FaixaEtaria.PREMIO_56_60:
                   PlanoProtecaoVO.ValorPremioIdadeBase = PlanoProtecaoVO.Premio_56_60;
                   break;
               case (int)FaixaEtaria.PREMIO_61_65:
                   PlanoProtecaoVO.ValorPremioIdadeBase = PlanoProtecaoVO.Premio_61_65;
                   break;
               default:
                   break;
           }
          
           #endregion

        }

        #endregion

        #region[ PlanoSenior ]

        public void PlanoSenior(int faixaPadrao, int respPergunta2, int respPergunta7)
        {
            decimal premioMax = 0;
            decimal premioAP = 0;

            #region [ Verifica Pergunta 2 para obter o Prêmio ]

            if ((respPergunta2 == 0) || (respPergunta2 == (int)PerguntaRenda.NAO_INFORMA))
                throw new CABTECException("É necessário responder a pergunta 2 para realizar os cálculos.");

            switch (respPergunta2)
            {
                case (int)PerguntaRenda.ATE_800:
                    premioMax = 800;
                    break;
                case (int)PerguntaRenda.DE_801_1000:
                    premioMax = 1000;
                    break;
                case (int)PerguntaRenda.DE_1001_1200:
                    premioMax = 1200;
                    break;
                case (int)PerguntaRenda.DE_1201_1400:
                    premioMax = 1400;
                    break;
                case (int)PerguntaRenda.DE_1401_1600:
                    premioMax = 1600;
                    break;
                case (int)PerguntaRenda.DE_1601_2000:
                    premioMax = 2000;
                    break;
                case (int)PerguntaRenda.DE_2001_2500:
                    premioMax = 2500;
                    break;
                case (int)PerguntaRenda.ACIMA_2501:
                    premioMax = 3000;
                    break;
                default:
                    break;
            }

            premioAP = (premioMax * 5 / 100) * 2 / 3;

            #endregion

            #region [ Consulta categoria SUPERIOR ]

            PlanoSeniorVO = TPlanoSeniorCONTROLLER.ConsultaCategoriaSuperior(faixaPadrao, premioAP);

            switch (faixaPadrao)
            {
                case (int)FaixaEtaria.PREMIO_61_65:
                    PlanoSeniorVO.ValorPremioIdadeBase = PlanoSeniorVO.Premio_61_65;
                    break;
                case (int)FaixaEtaria.PREMIO_66_70:
                    PlanoSeniorVO.ValorPremioIdadeBase = PlanoSeniorVO.Premio_66_70;
                    break;
                case (int)FaixaEtaria.PREMIO_71_75:
                    PlanoSeniorVO.ValorPremioIdadeBase = PlanoSeniorVO.Premio_71_75;
                    break;
                case (int)FaixaEtaria.PREMIO_76_80:
                    PlanoSeniorVO.ValorPremioIdadeBase = PlanoSeniorVO.Premio_76_80;
                    break;
                default:
                    break;
            }

            #endregion
        }
        
        #endregion

        #region[ PlanoSeniorCasal ]

        public void PlanoSeniorCasal(int faixaPadrao, int respPergunta2, int respPergunta7)
        {
            decimal premioMax = 0;
            decimal premioAP = 0;
           
            #region [ Verifica Pergunta 2 para obter o Prêmio ]

            if ((respPergunta2 == 0) || (respPergunta2 == (int)PerguntaRenda.NAO_INFORMA))
                throw new CABTECException("É necessário responder a pergunta 2 para realizar os cálculos.");
                        
            switch (respPergunta2)
            {
                case (int)PerguntaRenda.ATE_800:
                    premioMax = 800;
                    break;
                case (int)PerguntaRenda.DE_801_1000:
                    premioMax = 1000;
                    break;
                case (int)PerguntaRenda.DE_1001_1200:
                    premioMax = 1200;
                    break;
                case (int)PerguntaRenda.DE_1201_1400:
                    premioMax = 1400;
                    break;
                case (int)PerguntaRenda.DE_1401_1600:
                    premioMax = 1600;
                    break;
                case (int)PerguntaRenda.DE_1601_2000:
                    premioMax = 2000;
                    break;
                case (int)PerguntaRenda.DE_2001_2500:
                    premioMax = 2500;
                    break;
                case (int)PerguntaRenda.ACIMA_2501:
                    premioMax = 2500;
                    break;
                default:
                    break;
            }

            premioAP = (premioMax * 5 / 100) * 2 / 3;

            #endregion

            #region [ Consulta categoria SUPERIOR ]

            PlanoCasalVO = TPlanoCasalCONTROLLER.ConsultaCategoriaSuperior(faixaPadrao, premioAP);

            switch (faixaPadrao)
            {
                case (int)FaixaEtaria.PREMIO_61_65:
                    PlanoCasalVO.ValorPremioIdadeBase = PlanoCasalVO.Premio_61_65;
                    break;
                case (int)FaixaEtaria.PREMIO_66_70:
                    PlanoCasalVO.ValorPremioIdadeBase = PlanoCasalVO.Premio_66_70;
                    break;
                case (int)FaixaEtaria.PREMIO_71_75:
                    PlanoCasalVO.ValorPremioIdadeBase = PlanoCasalVO.Premio_71_75;
                    break;
                case (int)FaixaEtaria.PREMIO_76_80:
                    PlanoCasalVO.ValorPremioIdadeBase = PlanoCasalVO.Premio_76_80;
                    break;
                default:
                    break;
            }

            #endregion
        }

        #endregion

        #endregion
    }
}
