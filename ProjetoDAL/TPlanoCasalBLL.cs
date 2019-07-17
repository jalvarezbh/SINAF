using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TPlanoCasalBLL
    {
        #region [ InserirPlanoCasal ]

        public int InserirPlanoCasal(TPlanoCasalVO tplanocasalvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TPlanoCasal
            {
                Codigo = tplanocasalvo.Codigo,
                NomePlano = tplanocasalvo.NomePlano,
                CoberturaMorte = tplanocasalvo.CoberturaMorte,
                CoberturaConjuge = tplanocasalvo.CoberturaConjuge,
                Premio_61_65 = tplanocasalvo.Premio_61_65,
                Premio_66_70 = tplanocasalvo.Premio_66_70,
                Premio_71_75 = tplanocasalvo.Premio_71_75,
                Premio_76_80 = tplanocasalvo.Premio_76_80,

            };

            banco.AddToTPlanoCasal(query);
            banco.SaveChanges();

            tplanocasalvo.IDPlanoCasal = query.IDPlanoCasal;

            return query.IDPlanoCasal;
        }

        #endregion

        #region [ InserirPlanoCasalFuneral ]

        public int InserirPlanoCasalFuneral(TPlanoCasalVO tplanocasalvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TPlanoCasalFuneral
            {
                Categoria = tplanocasalvo.FuneralCategoria,
                Codigo = tplanocasalvo.FuneralCodigo,
                Ate_20 = tplanocasalvo.FuneralAte_20,
                De_21_40 = tplanocasalvo.FuneralDe_21_40,
                De_41_50 = tplanocasalvo.FuneralDe_41_50,
                De_51_60 = tplanocasalvo.FuneralDe_51_60,
                De_61_65 = tplanocasalvo.FuneralDe_61_65,
                De_66_70 = tplanocasalvo.FuneralDe_66_70,
                De_71_75 = tplanocasalvo.FuneralDe_71_75,
                De_76_80 = tplanocasalvo.FuneralDe_76_80,
            };

            banco.AddToTPlanoCasalFuneral(query);
            banco.SaveChanges();

            tplanocasalvo.IDPlanoCasalFuneral = query.IDPlanoCasalFuneral;

            return query.IDPlanoCasalFuneral;
        }

        #endregion

        #region [ ExcluirPlanoCasal ]

        public void ExcluirPlanoCasal(int IDPlanoCasal)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoCasal where registro.IDPlanoCasal == IDPlanoCasal select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ ExcluirPlanoCasalFuneral ]

        public void ExcluirPlanoCasalFuneral(int IDPlanoCasalFuneral)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoCasalFuneral where registro.IDPlanoCasalFuneral == IDPlanoCasalFuneral select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ ExcluirTodosPlanoCasal ]

        public void ExcluirTodosPlanoCasal()
        {
            var banco = new SINAF_WebEntities();

            List<TPlanoCasal> query = (from registro in banco.TPlanoCasal select registro).ToList();

            if (query.Count() > 0)
            {
                foreach (TPlanoCasal item in query)
                {
                    banco.DeleteObject(item);
                }
                banco.SaveChanges();
            }
        }

        #endregion

        #region [ ExcluirTodosPlanoCasalFuneral ]

        public void ExcluirTodosPlanoCasalFuneral()
        {
            var banco = new SINAF_WebEntities();

            List<TPlanoCasalFuneral> query = (from registro in banco.TPlanoCasalFuneral select registro).ToList();

            if (query.Count() > 0)
            {
                foreach (TPlanoCasalFuneral item in query)
                {
                    banco.DeleteObject(item);
                }
                banco.SaveChanges();
            }
        }

        #endregion

        #region [ SelecionarPlanoCategoriaSuperior ]

        public TPlanoCasalVO SelecionarPlanoCategoriaSuperior(int faixa, decimal valor)
        {
            List<TPlanoCasalVO> queryMenor;
            List<TPlanoCasalVO> queryMaior;

            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoCasal
                         where registro.NomePlano == "Superior"
                         select new TPlanoCasalVO
                         {
                             IDPlanoCasal = registro.IDPlanoCasal,
                             NomePlano = registro.NomePlano,
                             Codigo = registro.Codigo,
                             CoberturaMorte = registro.CoberturaMorte,
                             CoberturaConjuge = registro.CoberturaConjuge,
                             Premio_61_65 = registro.Premio_61_65,
                             Premio_66_70 = registro.Premio_66_70,
                             Premio_71_75 = registro.Premio_71_75,
                             Premio_76_80 = registro.Premio_76_80,
                         }).AsQueryable();   

            switch (faixa)
            {
                case (int)FaixaEtaria.PREMIO_61_65:
                    queryMenor = query.Where(registro => registro.Premio_61_65 <= valor).OrderByDescending(registro => registro.Premio_61_65).ToList();
                    queryMaior = query.Where(registro => registro.Premio_61_65 >= valor).OrderBy(registro => registro.Premio_61_65).ToList();
                    if ((queryMenor.Count > 0) && (queryMaior.Count > 0))
                    {
                        if (valor - queryMenor[0].Premio_61_65.GetValueOrDefault() > queryMaior[0].Premio_61_65.GetValueOrDefault() - valor)
                            return queryMaior[0];
                        else
                            return queryMenor[0];
                    }
                    else
                    {
                        if (queryMenor.Count > 0)
                            return queryMenor[0];

                        if (queryMaior.Count > 0)
                            return queryMaior[0];

                        return new TPlanoCasalVO();
                    }
                case (int)FaixaEtaria.PREMIO_66_70:
                    queryMenor = query.Where(registro => registro.Premio_66_70 <= valor).OrderByDescending(registro => registro.Premio_66_70).ToList();
                    queryMaior = query.Where(registro => registro.Premio_66_70 >= valor).OrderBy(registro => registro.Premio_66_70).ToList();
                    if ((queryMenor.Count > 0) && (queryMaior.Count > 0))
                    {
                        if (valor - queryMenor[0].Premio_66_70.GetValueOrDefault() > queryMaior[0].Premio_66_70.GetValueOrDefault() - valor)
                            return queryMaior[0];
                        else
                            return queryMenor[0];
                    }
                    else
                    {
                        if (queryMenor.Count > 0)
                            return queryMenor[0];

                        if (queryMaior.Count > 0)
                            return queryMaior[0];

                        return new TPlanoCasalVO();
                    }
                case (int)FaixaEtaria.PREMIO_71_75:
                    queryMenor = query.Where(registro => registro.Premio_71_75 <= valor).OrderByDescending(registro => registro.Premio_71_75).ToList();
                    queryMaior = query.Where(registro => registro.Premio_71_75 >= valor).OrderBy(registro => registro.Premio_71_75).ToList();
                    if ((queryMenor.Count > 0) && (queryMaior.Count > 0))
                    {
                        if (valor - queryMenor[0].Premio_71_75.GetValueOrDefault() > queryMaior[0].Premio_71_75.GetValueOrDefault() - valor)
                            return queryMaior[0];
                        else
                            return queryMenor[0];
                    }
                    else
                    {
                        if (queryMenor.Count > 0)
                            return queryMenor[0];

                        if (queryMaior.Count > 0)
                            return queryMaior[0];

                        return new TPlanoCasalVO();
                    }
                case (int)FaixaEtaria.PREMIO_76_80:
                    queryMenor = query.Where(registro => registro.Premio_76_80 <= valor).OrderByDescending(registro => registro.Premio_76_80).ToList();
                    queryMaior = query.Where(registro => registro.Premio_76_80 >= valor).OrderBy(registro => registro.Premio_76_80).ToList();
                    if ((queryMenor.Count > 0) && (queryMaior.Count > 0))
                    {
                        if (valor - queryMenor[0].Premio_76_80.GetValueOrDefault() > queryMaior[0].Premio_76_80.GetValueOrDefault() - valor)
                            return queryMaior[0];
                        else
                            return queryMenor[0];
                    }
                    else
                    {
                        if (queryMenor.Count > 0)
                            return queryMenor[0];

                        if (queryMaior.Count > 0)
                            return queryMaior[0];

                        return new TPlanoCasalVO();
                    }
                default:
                    break;
            }


            return new TPlanoCasalVO();
        }

        #endregion

        #region [ ListarTodosFuneralPrincipal ]

        public Dictionary<decimal, string> ListarTodosFuneralPrincipal()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoCasal
                         orderby registro.CoberturaMorte
                         select new
                         {
                             registro.CoberturaMorte,
                        
                         }).Distinct().ToDictionary(registro => registro.CoberturaMorte, registro => registro.CoberturaMorte.ToString());

            return query;
        }

        #endregion

        #region [ ListarTodosFuneralConjuge ]

        public Dictionary<decimal, string> ListarTodosFuneralConjuge()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoCasal
                         orderby registro.CoberturaConjuge
                         select new
                         {
                             registro.CoberturaConjuge,

                         }).Distinct().ToDictionary(registro => registro.CoberturaConjuge, registro => registro.CoberturaConjuge.ToString());

            return query;
        }

        #endregion

        #region [ ListarTodosFuneralCategoria ]

        public Dictionary<int, string> ListarTodosFuneralCategoria()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoCasal
                         orderby registro.Codigo
                         select new
                         {
                             registro.Codigo,
                             registro.NomePlano,

                         }).Distinct().ToDictionary(registro => registro.Codigo, registro => registro.NomePlano);

            return query;
        }

        #endregion

        #region [ SelecionarPlanoCasalFuneral ]

        public TPlanoCasalVO SelecionarPlanoCasalFuneral(decimal coberturaMorte, decimal coberturaConjuge, int codigoPlano)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoCasal
                         where registro.Codigo == codigoPlano
                         && registro.CoberturaMorte == coberturaMorte
                         && registro.CoberturaConjuge == coberturaConjuge
                         select new TPlanoCasalVO
                         {
                             IDPlanoCasal = registro.IDPlanoCasal,
                             NomePlano = registro.NomePlano,
                             Codigo = registro.Codigo,
                             CoberturaMorte = registro.CoberturaMorte,
                             CoberturaConjuge = registro.CoberturaConjuge,
                             Premio_61_65 = registro.Premio_61_65,
                             Premio_66_70 = registro.Premio_66_70,
                             Premio_71_75 = registro.Premio_71_75,
                             Premio_76_80 = registro.Premio_76_80,
                         }).AsQueryable();

            return query.FirstOrDefault();
        }

        #endregion

        #region [ SelecionarPlanoPremioAgregado ]

        public TPlanoCasalVO SelecionarPlanoPremioAgregado(string nomePlano, int codigoFaixa)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoCasalFuneral
                         where registro.Categoria == nomePlano
                         && registro.Codigo == codigoFaixa
                         select new TPlanoCasalVO
                         {
                             IDPlanoCasalFuneral = registro.IDPlanoCasalFuneral,
                             FuneralCodigo = registro.Codigo,
                             FuneralCategoria = registro.Categoria,
                             FuneralAte_20 = registro.Ate_20,
                             FuneralDe_21_40 = registro.De_21_40,
                             FuneralDe_41_50 = registro.De_41_50,
                             FuneralDe_51_60 = registro.De_51_60,
                             FuneralDe_61_65 = registro.De_61_65,
                             FuneralDe_66_70 = registro.De_66_70,
                             FuneralDe_71_75 = registro.De_71_75,
                             FuneralDe_76_80 = registro.De_76_80,

                         }).AsQueryable();

            return query.FirstOrDefault();
        }

        #endregion
    }
}
