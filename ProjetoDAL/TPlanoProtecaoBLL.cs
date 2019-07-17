using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TPlanoProtecaoBLL
    {
        #region [ InserirPlanoProtecao ]

        public int InserirPlanoProtecao(TPlanoProtecaoVO tplanoprotecaovo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TPlanoProtecao
            {
                Codigo = tplanoprotecaovo.Codigo,
                NomePlano = tplanoprotecaovo.NomePlano,
                CoberturaMorte = tplanoprotecaovo.CoberturaMorte,
                CoberturaAcidente = tplanoprotecaovo.CoberturaAcidente,
                CoberturaEmergencia = tplanoprotecaovo.CoberturaEmergencia,
                Premio_18_30 = tplanoprotecaovo.Premio_18_30,
                Premio_31_40 = tplanoprotecaovo.Premio_31_40,
                Premio_41_45 = tplanoprotecaovo.Premio_41_45,
                Premio_46_50 = tplanoprotecaovo.Premio_46_50,
                Premio_51_55 = tplanoprotecaovo.Premio_51_55,
                Premio_56_60 = tplanoprotecaovo.Premio_56_60,
                Premio_61_65 = tplanoprotecaovo.Premio_61_65,

            };

            banco.AddToTPlanoProtecao(query);
            banco.SaveChanges();

            tplanoprotecaovo.IDPlanoProtecao = query.IDPlanoProtecao;

            return query.IDPlanoProtecao;
        }

        #endregion

        #region [ InserirPlanoProtecaoFuneral ]

        public int InserirPlanoProtecaoFuneral(TPlanoProtecaoVO tplanoprotecaovo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TPlanoProtecaoFuneral
            {
                Categoria = tplanoprotecaovo.FuneralCategoria,
                Codigo = tplanoprotecaovo.FuneralCodigo,
                Ate_20 = tplanoprotecaovo.FuneralAte_20,
                De_21_40 = tplanoprotecaovo.FuneralDe_21_40,
                De_41_50 = tplanoprotecaovo.FuneralDe_41_50,
                De_51_60 = tplanoprotecaovo.FuneralDe_51_60,
                De_61_65 = tplanoprotecaovo.FuneralDe_61_65,
                De_66_70 = tplanoprotecaovo.FuneralDe_66_70,
                De_71_75 = tplanoprotecaovo.FuneralDe_71_75,
                De_76_80 = tplanoprotecaovo.FuneralDe_76_80,
            };

            banco.AddToTPlanoProtecaoFuneral(query);
            banco.SaveChanges();

            tplanoprotecaovo.IDPlanoProtecaoFuneral = query.IDPlanoProtecaoFuneral;

            return query.IDPlanoProtecaoFuneral;
        }

        #endregion

        #region [ InserirPlanoProtecaoRenda ]

        public int InserirPlanoProtecaoRenda(TPlanoProtecaoVO tplanoprotecaovo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TPlanoProtecaoRenda
            {
                RendaPeriodo = tplanoprotecaovo.RendaPeriodo,
                CoberturaRendaMensal = tplanoprotecaovo.RendaCoberturaRendaMensal,
                CoberturaCapitalTotal = tplanoprotecaovo.RendaCoberturaCapitalTotal,
                Premio_18_30 = tplanoprotecaovo.RendaPremio_18_30,
                Premio_31_40 = tplanoprotecaovo.RendaPremio_31_40,
                Premio_41_45 = tplanoprotecaovo.RendaPremio_41_45,
                Premio_46_50 = tplanoprotecaovo.RendaPremio_46_50,
                Premio_51_55 = tplanoprotecaovo.RendaPremio_51_55,
                Premio_56_60 = tplanoprotecaovo.RendaPremio_56_60,
                Premio_61_65 = tplanoprotecaovo.RendaPremio_61_65,

            };

            banco.AddToTPlanoProtecaoRenda(query);
            banco.SaveChanges();

            tplanoprotecaovo.IDPlanoProtecaoRenda = query.IDPlanoProtecaoRenda;

            return query.IDPlanoProtecaoRenda;
        }

        #endregion

        #region [ ExcluirPlanoProtecao ]

        public void ExcluirPlanoProtecao(int IDPlanoProtecao)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecao where registro.IDPlanoProtecao == IDPlanoProtecao select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ ExcluirPlanoProtecaoFuneral ]

        public void ExcluirPlanoProtecaoFuneral(int IDPlanoProtecaoFuneral)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecaoFuneral where registro.IDPlanoProtecaoFuneral == IDPlanoProtecaoFuneral select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ ExcluirPlanoProtecaoRenda ]

        public void ExcluirPlanoProtecaoRenda(int IDPlanoProtecaoRenda)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecaoRenda where registro.IDPlanoProtecaoRenda == IDPlanoProtecaoRenda select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ ExcluirTodosPlanoProtecao ]

        public void ExcluirTodosPlanoProtecao()
        {
            var banco = new SINAF_WebEntities();

            List<TPlanoProtecao> query = (from registro in banco.TPlanoProtecao select registro).ToList();

            if (query.Count() > 0)
            {
                foreach (TPlanoProtecao item in query)
                {
                    banco.DeleteObject(item);
                }
                banco.SaveChanges();
            }
        }

        #endregion

        #region [ ExcluirTodosPlanoProtecaoFuneral ]

        public void ExcluirTodosPlanoProtecaoFuneral()
        {
            var banco = new SINAF_WebEntities();

            List<TPlanoProtecaoFuneral> query = (from registro in banco.TPlanoProtecaoFuneral select registro).ToList();

            if (query.Count() > 0)
            {
                foreach (TPlanoProtecaoFuneral item in query)
                {
                    banco.DeleteObject(item);
                }
                banco.SaveChanges();
            }
        }

        #endregion

        #region [ ExcluirTodosPlanoProtecaoRenda ]

        public void ExcluirTodosPlanoProtecaoRenda()
        {
            var banco = new SINAF_WebEntities();

            List<TPlanoProtecaoRenda> query = (from registro in banco.TPlanoProtecaoRenda select registro).ToList();

            if (query.Count() > 0)
            {
                foreach (TPlanoProtecaoRenda item in query)
                {
                    banco.DeleteObject(item);
                }
                banco.SaveChanges();
            }
        }

        #endregion

        #region [ SelecionarPlanoCategoriaSuperior ]

        public TPlanoProtecaoVO SelecionarPlanoCategoriaSuperior(int faixa, decimal valor)
        {
            List<TPlanoProtecaoVO> queryMenor;
            List<TPlanoProtecaoVO> queryMaior;

            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecao
                         where registro.NomePlano == "Superior"
                         select new TPlanoProtecaoVO
                         {
                             IDPlanoProtecao = registro.IDPlanoProtecao,
                             NomePlano = registro.NomePlano,
                             Codigo = registro.Codigo,
                             CoberturaMorte = registro.CoberturaMorte,
                             CoberturaAcidente = registro.CoberturaAcidente,
                             CoberturaEmergencia = registro.CoberturaEmergencia,
                             Premio_18_30 = registro.Premio_18_30,
                             Premio_31_40 = registro.Premio_31_40,
                             Premio_41_45 = registro.Premio_41_45,
                             Premio_46_50 = registro.Premio_46_50,
                             Premio_51_55 = registro.Premio_51_55,
                             Premio_56_60 = registro.Premio_56_60,
                             Premio_61_65 = registro.Premio_61_65,
                         }).AsQueryable();

            switch (faixa)
            {
                case (int)FaixaEtaria.PREMIO_18_30:
                    queryMenor = query.Where(registro => registro.Premio_18_30 <= valor).OrderByDescending(registro => registro.Premio_18_30).ToList();
                    queryMaior = query.Where(registro => registro.Premio_18_30 >= valor).OrderBy(registro => registro.Premio_18_30).ToList();
                    if ((queryMenor.Count > 0) && (queryMaior.Count > 0))
                    {
                        if (valor - queryMenor[0].Premio_18_30.GetValueOrDefault() > queryMaior[0].Premio_18_30.GetValueOrDefault() - valor)
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

                        return new TPlanoProtecaoVO();
                    }
                case (int)FaixaEtaria.PREMIO_31_40:
                    queryMenor = query.Where(registro => registro.Premio_31_40 <= valor).OrderByDescending(registro => registro.Premio_31_40).ToList();
                    queryMaior = query.Where(registro => registro.Premio_31_40 >= valor).OrderBy(registro => registro.Premio_31_40).ToList();
                    if ((queryMenor.Count > 0) && (queryMaior.Count > 0))
                    {
                        if (valor - queryMenor[0].Premio_31_40.GetValueOrDefault() > queryMaior[0].Premio_31_40.GetValueOrDefault() - valor)
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

                        return new TPlanoProtecaoVO();
                    }
                case (int)FaixaEtaria.PREMIO_41_45:
                    queryMenor = query.Where(registro => registro.Premio_41_45 <= valor).OrderByDescending(registro => registro.Premio_41_45).ToList();
                    queryMaior = query.Where(registro => registro.Premio_41_45 >= valor).OrderBy(registro => registro.Premio_41_45).ToList();
                    if ((queryMenor.Count > 0) && (queryMaior.Count > 0))
                    {
                        if (valor - queryMenor[0].Premio_41_45.GetValueOrDefault() > queryMaior[0].Premio_41_45.GetValueOrDefault() - valor)
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

                        return new TPlanoProtecaoVO();
                    }
                case (int)FaixaEtaria.PREMIO_46_50:
                    queryMenor = query.Where(registro => registro.Premio_46_50 <= valor).OrderByDescending(registro => registro.Premio_46_50).ToList();
                    queryMaior = query.Where(registro => registro.Premio_46_50 >= valor).OrderBy(registro => registro.Premio_46_50).ToList();
                    if ((queryMenor.Count > 0) && (queryMaior.Count > 0))
                    {
                        if (valor - queryMenor[0].Premio_46_50.GetValueOrDefault() > queryMaior[0].Premio_46_50.GetValueOrDefault() - valor)
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

                        return new TPlanoProtecaoVO();
                    }
                case (int)FaixaEtaria.PREMIO_51_55:
                    queryMenor = query.Where(registro => registro.Premio_51_55 <= valor).OrderByDescending(registro => registro.Premio_51_55).ToList();
                    queryMaior = query.Where(registro => registro.Premio_51_55 >= valor).OrderBy(registro => registro.Premio_51_55).ToList();
                    if ((queryMenor.Count > 0) && (queryMaior.Count > 0))
                    {
                        if (valor - queryMenor[0].Premio_51_55.GetValueOrDefault() > queryMaior[0].Premio_51_55.GetValueOrDefault() - valor)
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

                        return new TPlanoProtecaoVO();
                    }
                case (int)FaixaEtaria.PREMIO_56_60:
                    queryMenor = query.Where(registro => registro.Premio_56_60 <= valor).OrderByDescending(registro => registro.Premio_56_60).ToList();
                    queryMaior = query.Where(registro => registro.Premio_56_60 >= valor).OrderBy(registro => registro.Premio_56_60).ToList();
                    if ((queryMenor.Count > 0) && (queryMaior.Count > 0))
                    {
                        if (valor - queryMenor[0].Premio_56_60.GetValueOrDefault() > queryMaior[0].Premio_56_60.GetValueOrDefault() - valor)
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

                        return new TPlanoProtecaoVO();
                    }
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

                        return new TPlanoProtecaoVO();
                    }
                default:
                    break;
            }


            return new TPlanoProtecaoVO();
        }

        #endregion

        #region [ ListarTodosMorteAcidental ]

        public Dictionary<decimal, string> ListarTodosMorteAcidental()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecao
                         orderby registro.CoberturaMorte
                         select new
                         {
                             registro.CoberturaMorte

                         }).Distinct().ToDictionary(registro => registro.CoberturaMorte, registro => registro.CoberturaMorte.ToString());

            return query;
        }

        #endregion

        #region [ ListarTodosInvalidezAcidente ]

        public Dictionary<decimal, string> ListarTodosInvalidezAcidente()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecao
                         orderby registro.CoberturaAcidente
                         select new
                         {
                             registro.CoberturaAcidente

                         }).Distinct().ToDictionary(registro => registro.CoberturaAcidente, registro => registro.CoberturaAcidente.ToString());

            return query;
        }

        #endregion

        #region [ ListarTodosAssisteciaEmergencial ]

        public Dictionary<decimal, string> ListarTodosAssisteciaEmergencial()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecao
                         orderby registro.CoberturaEmergencia
                         select new
                         {
                             registro.CoberturaEmergencia

                         }).Distinct().ToDictionary(registro => registro.CoberturaEmergencia, registro => registro.CoberturaEmergencia.ToString());

            return query;
        }

        #endregion

        #region [ ListarTodosFuneralCategoria ]

        public Dictionary<int, string> ListarTodosFuneralCategoria()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecao
                         orderby registro.Codigo
                         select new
                         {
                             registro.Codigo,
                             registro.NomePlano,

                         }).Distinct().ToDictionary(registro => registro.Codigo, registro => registro.NomePlano);

            return query;
        }

        #endregion

        #region [ ListarTodosRendaValor ]

        public Dictionary<decimal, string> ListarTodosRendaValor()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecaoRenda
                         orderby registro.CoberturaRendaMensal
                         select new
                         {
                             registro.CoberturaRendaMensal

                         }).Distinct().ToDictionary(registro => registro.CoberturaRendaMensal, registro => registro.CoberturaRendaMensal.ToString());

            return query;
        }

        #endregion

        #region [ ListarTodosRendaPeriodo ]

        public Dictionary<int, string> ListarTodosRendaPeriodo()
        {
            //var banco = new SINAF_WebEntities();

            //var query = (from registro in banco.TPlanoProtecaoRenda
            //             orderby registro.RendaPeriodo
            //             select new
            //             {
            //                 registro.RendaPeriodo

            //             }).Distinct().ToDictionary(registro => registro.RendaPeriodo, registro => registro.RendaPeriodo);

            //return query;

            Dictionary<int, string> listaPeriodo = new Dictionary<int, string>();
            listaPeriodo.Add((int)PeriodoRenda.MESES_3, PeriodoRenda.MESES_3.GetStringValue());
            listaPeriodo.Add((int)PeriodoRenda.MESES_6, PeriodoRenda.MESES_6.GetStringValue());
            listaPeriodo.Add((int)PeriodoRenda.MESES_12, PeriodoRenda.MESES_12.GetStringValue());
            listaPeriodo.Add((int)PeriodoRenda.MESES_24, PeriodoRenda.MESES_24.GetStringValue());

            return listaPeriodo;
        }

        #endregion

        #region [ SelecionarPlanoProtecaoFuneral ]

        public TPlanoProtecaoVO SelecionarPlanoProtecaoFuneral(decimal coberturaMorte, decimal coberturaAcidente, decimal coberturaEmergencia, int codigoPlano)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecao
                         where registro.Codigo == codigoPlano
                         && registro.CoberturaMorte == coberturaMorte
                         && registro.CoberturaAcidente == coberturaAcidente
                         && registro.CoberturaEmergencia == coberturaEmergencia
                         select new TPlanoProtecaoVO
                         {
                             IDPlanoProtecao = registro.IDPlanoProtecao,
                             NomePlano = registro.NomePlano,
                             Codigo = registro.Codigo,
                             CoberturaMorte = registro.CoberturaMorte,
                             CoberturaAcidente = registro.CoberturaAcidente,
                             CoberturaEmergencia = registro.CoberturaEmergencia,
                             Premio_18_30 = registro.Premio_18_30,
                             Premio_31_40 = registro.Premio_31_40,
                             Premio_41_45 = registro.Premio_41_45,
                             Premio_46_50 = registro.Premio_46_50,
                             Premio_51_55 = registro.Premio_51_55,
                             Premio_56_60 = registro.Premio_56_60,
                             Premio_61_65 = registro.Premio_61_65,
                         }).AsQueryable();

            return query.FirstOrDefault();
        }

        #endregion

        #region [ SelecionarPlanoPremioAgregado ]

        public TPlanoProtecaoVO SelecionarPlanoPremioAgregado(string nomePlano, int codigoFaixa)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecaoFuneral
                         where registro.Categoria == nomePlano
                         && registro.Codigo == codigoFaixa
                         select new TPlanoProtecaoVO
                         {
                             IDPlanoProtecaoFuneral = registro.IDPlanoProtecaoFuneral,
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

        #region [ SelecionarPlanoProtecaoRenda ]

        public TPlanoProtecaoVO SelecionarPlanoProtecaoRenda(string periodoNovo, decimal valorRendaNovo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPlanoProtecaoRenda
                         where registro.RendaPeriodo == periodoNovo
                         && registro.CoberturaRendaMensal == valorRendaNovo
                         select new TPlanoProtecaoVO
                         {
                             IDPlanoProtecaoRenda = registro.IDPlanoProtecaoRenda,
                             RendaPeriodo = registro.RendaPeriodo,
                             RendaCoberturaRendaMensal = registro.CoberturaRendaMensal,
                             RendaCoberturaCapitalTotal = registro.CoberturaCapitalTotal,
                             RendaPremio_18_30 = registro.Premio_18_30,
                             RendaPremio_31_40 = registro.Premio_31_40,
                             RendaPremio_41_45 = registro.Premio_41_45,
                             RendaPremio_46_50 = registro.Premio_46_50,
                             RendaPremio_51_55 = registro.Premio_51_55,
                             RendaPremio_56_60 = registro.Premio_56_60,
                             RendaPremio_61_65 = registro.Premio_61_65,
                         }).AsQueryable();

            return query.FirstOrDefault();
        }

        #endregion
    }
}
