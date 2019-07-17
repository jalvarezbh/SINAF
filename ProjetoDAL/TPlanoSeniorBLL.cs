using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TPlanoSeniorBLL
    {
        #region [ InserirPlanoSenior ]

        public int InserirPlanoSenior(TPlanoSeniorVO tplanoseniorvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TPlanoSenior
            {
                Codigo = tplanoseniorvo.Codigo,
                NomePlano = tplanoseniorvo.NomePlano,
                CoberturaMorte = tplanoseniorvo.CoberturaMorte,
                Premio_61_65 = tplanoseniorvo.Premio_61_65,
                Premio_66_70 = tplanoseniorvo.Premio_66_70,
                Premio_71_75 = tplanoseniorvo.Premio_71_75,
                Premio_76_80 = tplanoseniorvo.Premio_76_80,
              
            };

            banco.AddToTPlanoSenior(query);
            banco.SaveChanges();

            tplanoseniorvo.IDPlanoSenior = query.IDPlanoSenior;

            return query.IDPlanoSenior;
        }

        #endregion

        #region [ InserirPlanoSeniorFuneral ]

        public int InserirPlanoSeniorFuneral(TPlanoSeniorVO tplanoseniorvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TPlanoSeniorFuneral
            {
                Categoria = tplanoseniorvo.FuneralCategoria,
                Codigo = tplanoseniorvo.FuneralCodigo,
                Ate_20 = tplanoseniorvo.FuneralAte_20,
                De_21_40 = tplanoseniorvo.FuneralDe_21_40,
                De_41_50 = tplanoseniorvo.FuneralDe_41_50,
                De_51_60 = tplanoseniorvo.FuneralDe_51_60,
                De_61_65 = tplanoseniorvo.FuneralDe_61_65,
                De_66_70 = tplanoseniorvo.FuneralDe_66_70,
                De_71_75 = tplanoseniorvo.FuneralDe_71_75,
                De_76_80 = tplanoseniorvo.FuneralDe_76_80,
            };

            banco.AddToTPlanoSeniorFuneral(query);
            banco.SaveChanges();

            tplanoseniorvo.IDPlanoSeniorFuneral = query.IDPlanoSeniorFuneral;

            return query.IDPlanoSeniorFuneral;
        }

        #endregion

        #region [ ExcluirPlanoSenior ]

        public void ExcluirPlanoSenior(int IDPlanoSenior)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoSenior where registro.IDPlanoSenior == IDPlanoSenior select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ ExcluirPlanoSeniorFuneral ]

        public void ExcluirPlanoSeniorFuneral(int IDPlanoSeniorFuneral)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoSeniorFuneral where registro.IDPlanoSeniorFuneral == IDPlanoSeniorFuneral select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ ExcluirTodosPlanoSenior ]

        public void ExcluirTodosPlanoSenior()
        {
            var banco = new SINAF_WebEntities();

            List<TPlanoSenior> query = (from registro in banco.TPlanoSenior select registro).ToList();

            if (query.Count() > 0)
            {
                foreach (TPlanoSenior item in query)
                {
                    banco.DeleteObject(item);
                }
                banco.SaveChanges();
            }
        }

        #endregion

        #region [ ExcluirTodosPlanoSeniorFuneral ]

        public void ExcluirTodosPlanoSeniorFuneral()
        {
            var banco = new SINAF_WebEntities();

            List<TPlanoSeniorFuneral> query = (from registro in banco.TPlanoSeniorFuneral select registro).ToList();

            if (query.Count() > 0)
            {
                foreach (TPlanoSeniorFuneral item in query)
                {
                    banco.DeleteObject(item);
                }
                banco.SaveChanges();
            }
        }

        #endregion

        #region [ SelecionarPlanoCategoriaSuperior ]

        public TPlanoSeniorVO SelecionarPlanoCategoriaSuperior(int faixa, decimal valor)
        {
            List<TPlanoSeniorVO> queryMenor;
            List<TPlanoSeniorVO> queryMaior;

            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoSenior
                         where registro.NomePlano == "Superior"
                         select new TPlanoSeniorVO
                         {
                             IDPlanoSenior = registro.IDPlanoSenior,
                             NomePlano = registro.NomePlano,
                             Codigo = registro.Codigo,
                             CoberturaMorte = registro.CoberturaMorte,
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

                        return new TPlanoSeniorVO();
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

                        return new TPlanoSeniorVO();
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

                        return new TPlanoSeniorVO();
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

                        return new TPlanoSeniorVO();
                    }
                default:
                    break;
            }


            return new TPlanoSeniorVO();
        }

        #endregion

        #region [ ListarTodosFuneralPrincipal ]

        public Dictionary<decimal, string> ListarTodosFuneralPrincipal()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoSenior
                         orderby registro.CoberturaMorte
                         select new
                         {
                             registro.CoberturaMorte,

                         }).Distinct().ToDictionary(registro => registro.CoberturaMorte, registro => registro.CoberturaMorte.ToString());

            return query;
        }

        #endregion
                
        #region [ ListarTodosFuneralCategoria ]

        public Dictionary<int, string> ListarTodosFuneralCategoria()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoSenior
                         orderby registro.Codigo
                         select new
                         {
                             registro.Codigo,
                             registro.NomePlano,

                         }).Distinct().ToDictionary(registro => registro.Codigo, registro => registro.NomePlano);

            return query;
        }

        #endregion

        #region [ SelecionarPlanoSeniorFuneral ]

        public TPlanoSeniorVO SelecionarPlanoSeniorFuneral(decimal coberturaMorte, int codigoPlano)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoSenior
                         where registro.Codigo == codigoPlano
                         && registro.CoberturaMorte == coberturaMorte
                         select new TPlanoSeniorVO
                         {
                             IDPlanoSenior = registro.IDPlanoSenior,
                             NomePlano = registro.NomePlano,
                             Codigo = registro.Codigo,
                             CoberturaMorte = registro.CoberturaMorte,
                             Premio_61_65 = registro.Premio_61_65,
                             Premio_66_70 = registro.Premio_66_70,
                             Premio_71_75 = registro.Premio_71_75,
                             Premio_76_80 = registro.Premio_76_80,
                         }).AsQueryable();

            return query.FirstOrDefault();
        }

        #endregion

        #region [ SelecionarPlanoPremioAgregado ]

        public TPlanoSeniorVO SelecionarPlanoPremioAgregado(string nomePlano, int codigoFaixa)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoSeniorFuneral
                         where registro.Categoria == nomePlano
                         && registro.Codigo == codigoFaixa
                         select new TPlanoSeniorVO
                         {
                             IDPlanoSeniorFuneral = registro.IDPlanoSeniorFuneral,
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
