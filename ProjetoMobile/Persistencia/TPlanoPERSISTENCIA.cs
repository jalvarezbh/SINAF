using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using ProjetoMobile.Dominio;
using ProjetoMobile.Dominio.Enumeradores;
using System.Data;
 
namespace ProjetoMobile.Persistencia
{
    public class TPlanoPERSISTENCIA
    {
        #region [ PERSISTENCE ]

        private TCombosEnumPERSISTENCIA _TCombosEnumPERSISTENCIA;

        public TCombosEnumPERSISTENCIA TCombosEnumPERSISTENCIA
        {
            get
            {
                if (_TCombosEnumPERSISTENCIA == null)
                    _TCombosEnumPERSISTENCIA = new TCombosEnumPERSISTENCIA();

                return _TCombosEnumPERSISTENCIA;

            }
        }

        private TPlanoProtecaoPERSISTENCIA _TPlanoProtecaoPERSISTENCIA;

        public TPlanoProtecaoPERSISTENCIA TPlanoProtecaoPERSISTENCIA
        {
            get
            {
                if (_TPlanoProtecaoPERSISTENCIA == null)
                    _TPlanoProtecaoPERSISTENCIA = new TPlanoProtecaoPERSISTENCIA();

                return _TPlanoProtecaoPERSISTENCIA;

            }
        }

        private TPlanoSeniorPERSISTENCIA _TPlanoSeniorPERSISTENCIA;

        public TPlanoSeniorPERSISTENCIA TPlanoSeniorPERSISTENCIA
        {
            get
            {
                if (_TPlanoSeniorPERSISTENCIA == null)
                    _TPlanoSeniorPERSISTENCIA = new TPlanoSeniorPERSISTENCIA();

                return _TPlanoSeniorPERSISTENCIA;

            }
        }

        private TPlanoCasalPERSISTENCIA _TPlanoCasalPERSISTENCIA;

        public TPlanoCasalPERSISTENCIA TPlanoCasalPERSISTENCIA
        {
            get
            {
                if (_TPlanoCasalPERSISTENCIA == null)
                    _TPlanoCasalPERSISTENCIA = new TPlanoCasalPERSISTENCIA();

                return _TPlanoCasalPERSISTENCIA;

            }
        }

        private TPlanoProtecaoDOMINIO _PlanoProtecaoDOMINIO;
        public TPlanoProtecaoDOMINIO PlanoProtecaoDOMINIO
        {
            get { return _PlanoProtecaoDOMINIO; }
            set { _PlanoProtecaoDOMINIO = value; }
        }

        private TPlanoSeniorDOMINIO _PlanoSeniorDOMINIO;
        public TPlanoSeniorDOMINIO PlanoSeniorDOMINIO
        {
            get { return _PlanoSeniorDOMINIO; }
            set { _PlanoSeniorDOMINIO = value; }
        }

        private TPlanoCasalDOMINIO _PlanoCasalDOMINIO;
        public TPlanoCasalDOMINIO PlanoCasalDOMINIO
        {
            get { return _PlanoCasalDOMINIO; }
            set { _PlanoCasalDOMINIO = value; }
        }

        private decimal _TotalMax;
        public decimal TotalMax
        {
            get { return _TotalMax; }
            set { _TotalMax = value; }
        }

        #endregion

        #region [ METHODS ]

        #region [ SimularPlano ]

        public bool SimularPlano(DateTime dataTitular, DateTime? dataConjuge, int respPergunta2, int respPergunta7, ref List<ProdutoPrincipal> ProdutoDisponivel, ref int idadeBase)
        {
            try
            {
                PlanoProtecaoDOMINIO = new TPlanoProtecaoDOMINIO();
                PlanoCasalDOMINIO = new TPlanoCasalDOMINIO();
                PlanoSeniorDOMINIO = new TPlanoSeniorDOMINIO();
                idadeBase = 0;

                int faixaTitular = TCombosEnumPERSISTENCIA.FaixaEtariaDataNascimento(dataTitular);

                int faixaConjuge = 0;
                if (dataConjuge.HasValue)
                {
                    faixaConjuge = TCombosEnumPERSISTENCIA.FaixaEtariaDataNascimento(dataConjuge.Value);

                    if ((dataTitular - dataConjuge.Value).TotalDays <= 0)
                        idadeBase = faixaTitular;
                    else
                        idadeBase = faixaConjuge;
                }
                else
                    idadeBase = faixaTitular;

                //Adiciona a lista de opções de acordo com a Faixa Etária
                #region [ Opções de Produtos ]

                if ((faixaTitular < 7) || (faixaTitular == 8))
                    ProdutoDisponivel.Add(ProdutoPrincipal.PLANOPROTECAO);

                if ((faixaTitular >= 6) && (faixaTitular != 8))
                {
                    ProdutoDisponivel.Add(ProdutoPrincipal.PLANOSENIOR);

                    ProdutoDisponivel.Add(ProdutoPrincipal.PLANOCASAL);
                }

                #endregion

                //Verificar o Produto a ser oferecido pela faixa etária do titular e do cônjuge
                #region [ Produto Plano Proteção Familia ]

                if ((idadeBase <= 6) || (idadeBase == 8))
                {
                    PlanoProtecao(faixaTitular, idadeBase, respPergunta2, respPergunta7);
                    return true;
                }

                if (((faixaTitular <= 5) || (faixaTitular == 8)) && (faixaConjuge >= 7 && faixaConjuge <= 10 && faixaConjuge != 8))
                {
                    PlanoProtecao(faixaTitular, faixaTitular, respPergunta2, respPergunta7);
                    return true;
                }

                #endregion

                #region [ Produto Sênior Individual ]

                if ((faixaTitular >= 6) && (faixaTitular != 8))
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
            catch (Exception)
            {
                throw new Exception("Erro ao Simular Plano.");
            }
        }

        #endregion

        #region [ FaixaBase ]

        public bool FaixaBase(int faixaTitular, int faixaConjuge, ref int idadeBase)
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
                                if ((faixaTitular == 8) && (faixaConjuge <= 1))
                                    idadeBase = faixaTitular;
                                else
                                    if ((faixaConjuge == 8) && (faixaTitular >= 2))
                                        idadeBase = faixaTitular;
                                    else
                                        if ((faixaConjuge == 8) && (faixaTitular == 1))
                                            idadeBase = faixaConjuge;

                #endregion

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region [ SimularPlanoAlterarProduto ]

        public bool SimularPlanoAlterarProduto(DateTime dataTitular, DateTime? dataConjuge, int respPergunta2, int respPergunta7,int produtoEscolhido, ref List<ProdutoPrincipal> ProdutoDisponivel, ref int idadeBase)
        {
            try
            {
                idadeBase = 0;

                int faixaTitular = TCombosEnumPERSISTENCIA.FaixaEtariaDataNascimento(dataTitular);

                int faixaConjuge = 0;
                if (dataConjuge.HasValue)
                {
                    faixaConjuge = TCombosEnumPERSISTENCIA.FaixaEtariaDataNascimento(dataConjuge.Value);

                    if ((dataTitular - dataConjuge.Value).TotalDays <= 0)
                        idadeBase = faixaTitular;
                    else
                        idadeBase = faixaConjuge;
                }
                else
                    idadeBase = faixaTitular;

                //Adiciona a lista de opções de acordo com a Faixa Etária
                #region [ Opções de Produtos ]

                if ((faixaTitular < 7) || (faixaTitular == 8))
                    ProdutoDisponivel.Add(ProdutoPrincipal.PLANOPROTECAO);

                if ((faixaTitular >= 6) && (faixaTitular != 8))
                {
                    ProdutoDisponivel.Add(ProdutoPrincipal.PLANOSENIOR);

                    ProdutoDisponivel.Add(ProdutoPrincipal.PLANOCASAL);
                }

                #endregion

                switch (produtoEscolhido)
                {
                    case (int)ProdutoPrincipal.PLANOPROTECAO:
                        PlanoProtecao(faixaTitular, idadeBase, respPergunta2, respPergunta7);
                        return true;
                        break;
                    case (int)ProdutoPrincipal.PLANOSENIOR:
                        PlanoSenior(idadeBase, respPergunta2, respPergunta7);
                        return true;
                        break;
                    case (int)ProdutoPrincipal.PLANOCASAL:
                        PlanoSeniorCasal(idadeBase, respPergunta2, respPergunta7);
                        return true;
                        break;
                    default:
                        break;
                }
                      
                return false;
            }
            catch
            {
                throw new Exception("Erro ao Simular Plano.");
            }
        }

        #endregion

        #region [ ConsultarPlano ]

        public bool ConsultarPlano(int produto, int faixaBase , ref DataTable dadosPlanos, ref DataTable dadosAgregados, ref DataTable dadosRenda)
        {
            try
            {
                switch (produto)
                {
                    case (int)ProdutoPrincipal.PLANOPROTECAO:
                        dadosPlanos = TPlanoProtecaoPERSISTENCIA.ConsultarPlanoProtecaoFuneral(faixaBase);
                        dadosAgregados = TPlanoProtecaoPERSISTENCIA.ConsultarPlanoProtecaoAgregado();
                        dadosRenda = TPlanoProtecaoPERSISTENCIA.ConsultarPlanoProtecaoRenda(faixaBase);
                        break;
                    case (int)ProdutoPrincipal.PLANOSENIOR:
                        dadosPlanos = TPlanoSeniorPERSISTENCIA.ConsultarPlanoSeniorFuneral(faixaBase);
                        dadosAgregados = TPlanoSeniorPERSISTENCIA.ConsultarPlanoSeniorAgregado();
                        break;
                    case (int)ProdutoPrincipal.PLANOCASAL:
                        dadosPlanos = TPlanoCasalPERSISTENCIA.ConsultarPlanoCasalFuneral(faixaBase);
                        dadosAgregados = TPlanoCasalPERSISTENCIA.ConsultarPlanoCasalAgregado();
                        break;
                    default:
                        break;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
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

            if (((respPergunta2 == 0) || (respPergunta2 == 12)) && (respPergunta7 == 0))
                throw new Exception("É necessário responder as perguntas 2 e 7 para realizar os cálculos.");

            if (respPergunta2 > 0 && respPergunta2 < 12)
                codigoValorConsiderado = respPergunta2;
            else
                if (respPergunta7 > 0 && respPergunta7 < 12)
                    codigoValorConsiderado = respPergunta7;
                else
                    throw new Exception("É necessário responder as perguntas 2 e 7 para realizar os cálculos.");

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
                    premioMax = 45;
                    break;
                case (int)PerguntaRenda.DE_2001_2500:
                    premioMax = 55;
                    break;
                case (int)PerguntaRenda.DE_2501_3000:
                    premioMax = 65;
                    break;
                case (int)PerguntaRenda.DE_3001_3500:
                    premioMax = 75;
                    break;
                case (int)PerguntaRenda.DE_3501_4000:
                    premioMax = 90;
                    break;
                case (int)PerguntaRenda.ACIMA_4001:
                    premioMax = 110;
                    break;
                default:
                    break;
            }

            TotalMax = premioMax;
            premioAP = premioMax / 3;

            #endregion

            #region [ Consulta categoria SUPERIOR ]

            if (faixaPadrao > (int)FaixaEtaria.PREMIO_61_65)
                faixaPadrao = faixaTitular;

            PlanoProtecaoDOMINIO = TPlanoProtecaoPERSISTENCIA.ConsultaCategoriaSuperior(faixaPadrao, premioAP);

            switch (faixaPadrao)
            {
                case (int)FaixaEtaria.PREMIO_18_30:
                    PlanoProtecaoDOMINIO.ValorPremioIdadeBase = PlanoProtecaoDOMINIO.Premio_18_30;
                    break;
                case (int)FaixaEtaria.PREMIO_31_40:
                    PlanoProtecaoDOMINIO.ValorPremioIdadeBase = PlanoProtecaoDOMINIO.Premio_31_40;
                    break;
                case (int)FaixaEtaria.PREMIO_41_45:
                    PlanoProtecaoDOMINIO.ValorPremioIdadeBase = PlanoProtecaoDOMINIO.Premio_41_45;
                    break;
                case (int)FaixaEtaria.PREMIO_46_50:
                    PlanoProtecaoDOMINIO.ValorPremioIdadeBase = PlanoProtecaoDOMINIO.Premio_46_50;
                    break;
                case (int)FaixaEtaria.PREMIO_51_55:
                    PlanoProtecaoDOMINIO.ValorPremioIdadeBase = PlanoProtecaoDOMINIO.Premio_51_55;
                    break;
                case (int)FaixaEtaria.PREMIO_56_60:
                    PlanoProtecaoDOMINIO.ValorPremioIdadeBase = PlanoProtecaoDOMINIO.Premio_56_60;
                    break;
                case (int)FaixaEtaria.PREMIO_61_65:
                    PlanoProtecaoDOMINIO.ValorPremioIdadeBase = PlanoProtecaoDOMINIO.Premio_61_65;
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
            int codigoValorConsiderado = 0;

            #region [ Verifica Pergunta 2 e 7 para obter o Prêmio ]

            if (((respPergunta2 == 0) || (respPergunta2 == 12)) && (respPergunta7 == 0))
                throw new Exception("É necessário responder as perguntas 2 e 7 para realizar os cálculos.");

            if (respPergunta2 > 0 && respPergunta2 < 12)
                codigoValorConsiderado = respPergunta2;
            else
                if (respPergunta7 > 0 && respPergunta7 < 12)
                    codigoValorConsiderado = respPergunta7;
                else
                    throw new Exception("É necessário responder as perguntas 2 e 7 para realizar os cálculos.");


            switch (codigoValorConsiderado)
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
                case (int)PerguntaRenda.DE_2501_3000:
                    premioMax = 3000;
                    break;
                case (int)PerguntaRenda.DE_3001_3500:
                    premioMax = 3500;
                    break;
                case (int)PerguntaRenda.DE_3501_4000:
                    premioMax = 4000;
                    break;               
                case (int)PerguntaRenda.ACIMA_4001:
                    premioMax = 5000;
                    break;
                default:
                    break;
            }

            premioAP = (premioMax * 5 / 100) * 2 / 3;

            #endregion

            #region [ Consulta categoria SUPERIOR ]

            PlanoSeniorDOMINIO = TPlanoSeniorPERSISTENCIA.ConsultaCategoriaSuperior(faixaPadrao, premioAP);

            switch (faixaPadrao)
            {
                case (int)FaixaEtaria.PREMIO_61_65:
                    PlanoSeniorDOMINIO.ValorPremioIdadeBase = PlanoSeniorDOMINIO.Premio_61_65;
                    break;
                case (int)FaixaEtaria.PREMIO_66_70:
                    PlanoSeniorDOMINIO.ValorPremioIdadeBase = PlanoSeniorDOMINIO.Premio_66_70;
                    break;
                case (int)FaixaEtaria.PREMIO_71_75:
                    PlanoSeniorDOMINIO.ValorPremioIdadeBase = PlanoSeniorDOMINIO.Premio_71_75;
                    break;
                case (int)FaixaEtaria.PREMIO_76_80:
                    PlanoSeniorDOMINIO.ValorPremioIdadeBase = PlanoSeniorDOMINIO.Premio_76_80;
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
            int codigoValorConsiderado = 0;

            #region [ Verifica Pergunta 2 e 7 para obter o Prêmio ]

            if (((respPergunta2 == 0) || (respPergunta2 == 12)) && (respPergunta7 == 0))
                throw new Exception("É necessário responder as perguntas 2 e 7 para realizar os cálculos.");

            if (respPergunta2 > 0 && respPergunta2 < 12)
                codigoValorConsiderado = respPergunta2;
            else
                if (respPergunta7 > 0 && respPergunta7 < 12)
                    codigoValorConsiderado = respPergunta7;
                else
                    throw new Exception("É necessário responder as perguntas 2 e 7 para realizar os cálculos.");


            switch (codigoValorConsiderado)
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
                case (int)PerguntaRenda.DE_2501_3000:
                    premioMax = 3000;
                    break;
                case (int)PerguntaRenda.DE_3001_3500:
                    premioMax = 3500;
                    break;
                case (int)PerguntaRenda.DE_3501_4000:
                    premioMax = 4000;
                    break;
                case (int)PerguntaRenda.ACIMA_4001:
                    premioMax = 5000;
                    break;
                default:
                    break;
            }

            premioAP = (premioMax * 5 / 100) * 2 / 3;

            #endregion

            #region [ Consulta categoria SUPERIOR ]

            PlanoCasalDOMINIO = TPlanoCasalPERSISTENCIA.ConsultaCategoriaSuperior(faixaPadrao, premioAP);

            switch (faixaPadrao)
            {
                case (int)FaixaEtaria.PREMIO_61_65:
                    PlanoCasalDOMINIO.ValorPremioIdadeBase = PlanoCasalDOMINIO.Premio_61_65;
                    break;
                case (int)FaixaEtaria.PREMIO_66_70:
                    PlanoCasalDOMINIO.ValorPremioIdadeBase = PlanoCasalDOMINIO.Premio_66_70;
                    break;
                case (int)FaixaEtaria.PREMIO_71_75:
                    PlanoCasalDOMINIO.ValorPremioIdadeBase = PlanoCasalDOMINIO.Premio_71_75;
                    break;
                case (int)FaixaEtaria.PREMIO_76_80:
                    PlanoCasalDOMINIO.ValorPremioIdadeBase = PlanoCasalDOMINIO.Premio_76_80;
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
