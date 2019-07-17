using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TParametroBLL
    {
        #region [ Inserir ]

        public int Inserir(TParametroVO tparametrovo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TParametro
            {
                  IDParametro = tparametrovo.IDParametro,
 
                  TempoLogOff = tparametrovo.TempoLogOff,
 
                  PrazoSincronismoDia = tparametrovo.PrazoSincronismoDia,
 
                  EstoqueMaximoWeb = tparametrovo.EstoqueMaximoWeb,
 
                  EstoqueMinimoWeb = tparametrovo.EstoqueMinimoWeb,
 
                  EstoqueMaximoColetor = tparametrovo.EstoqueMaximoColetor,
 
                  EstoqueMinimoColetor = tparametrovo.EstoqueMinimoColetor,
 
                  TempoDadosServidorDias = tparametrovo.TempoDadosServidorDias,
 
                  TempoVerificaERPDias = tparametrovo.TempoVerificaERPDias,

                  VersaoBaseCorreio = tparametrovo.VersaoBaseCorreio,

                  TempoEntrevistaColetor = tparametrovo.TempoEntrevistaColetor,

                  TempoEntrevistaIncompleta = tparametrovo.TempoEntrevistaIncompleta,
            };

            banco.AddToTParametro(query);
            banco.SaveChanges();

            tparametrovo.IDParametro = query.IDParametro;

            return query.IDParametro;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(TParametroVO tparametrovo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TParametro
                         where registro.IDParametro.Equals(tparametrovo.IDParametro)
                         select registro).First();

               
              query.TempoLogOff = tparametrovo.TempoLogOff;
 
              query.PrazoSincronismoDia = tparametrovo.PrazoSincronismoDia;
 
              query.EstoqueMaximoWeb = tparametrovo.EstoqueMaximoWeb;
 
              query.EstoqueMinimoWeb = tparametrovo.EstoqueMinimoWeb;
 
              query.EstoqueMaximoColetor = tparametrovo.EstoqueMaximoColetor;
 
              query.EstoqueMinimoColetor = tparametrovo.EstoqueMinimoColetor;
 
              query.TempoDadosServidorDias = tparametrovo.TempoDadosServidorDias;
 
              query.TempoVerificaERPDias = tparametrovo.TempoVerificaERPDias;

              query.VersaoBaseCorreio = tparametrovo.VersaoBaseCorreio;

              query.TempoEntrevistaColetor = tparametrovo.TempoEntrevistaColetor;

              query.TempoEntrevistaIncompleta = tparametrovo.TempoEntrevistaIncompleta;

              banco.SaveChanges();

        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDParametro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TParametro where registro.IDParametro == IDParametro select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public TParametroVO Obter(int IDParametro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TParametro
                         where registro.IDParametro == IDParametro
                         select new TParametroVO
                         {
                            IDParametro = registro.IDParametro,
 
                            TempoLogOff = registro.TempoLogOff,
 
                            PrazoSincronismoDia = registro.PrazoSincronismoDia,
 
                            EstoqueMaximoWeb = registro.EstoqueMaximoWeb,
 
                            EstoqueMinimoWeb = registro.EstoqueMinimoWeb,
 
                            EstoqueMaximoColetor = registro.EstoqueMaximoColetor,
 
                            EstoqueMinimoColetor = registro.EstoqueMinimoColetor,
 
                            TempoDadosServidorDias = registro.TempoDadosServidorDias,
 
                            TempoVerificaERPDias = registro.TempoVerificaERPDias,

                            VersaoBaseCorreio = registro.VersaoBaseCorreio,

                            TempoEntrevistaColetor = registro.TempoEntrevistaColetor,

                            TempoEntrevistaIncompleta = registro.TempoEntrevistaIncompleta,

                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ Listar ]

        public IQueryable<TParametroVO> Listar(TParametroVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TParametro
                         select new TParametroVO
                         {
                            IDParametro = registro.IDParametro,
 
                            TempoLogOff = registro.TempoLogOff,
 
                            PrazoSincronismoDia = registro.PrazoSincronismoDia,
 
                            EstoqueMaximoWeb = registro.EstoqueMaximoWeb,
 
                            EstoqueMinimoWeb = registro.EstoqueMinimoWeb,
 
                            EstoqueMaximoColetor = registro.EstoqueMaximoColetor,
 
                            EstoqueMinimoColetor = registro.EstoqueMinimoColetor,
 
                            TempoDadosServidorDias = registro.TempoDadosServidorDias,
 
                            TempoVerificaERPDias = registro.TempoVerificaERPDias,

                            VersaoBaseCorreio = registro.VersaoBaseCorreio,

                            TempoEntrevistaColetor = registro.TempoEntrevistaColetor,

                            TempoEntrevistaIncompleta = registro.TempoEntrevistaIncompleta,

                         }).AsQueryable();

          
          if(filtro.TempoLogOff.HasValue)
              query = query.Where(registro => registro.TempoLogOff == filtro.TempoLogOff.Value);
 
          if(filtro.PrazoSincronismoDia.HasValue)
              query = query.Where(registro => registro.PrazoSincronismoDia == filtro.PrazoSincronismoDia.Value);
 
          if(filtro.EstoqueMaximoWeb.HasValue)
              query = query.Where(registro => registro.EstoqueMaximoWeb == filtro.EstoqueMaximoWeb.Value);
 
          if(filtro.EstoqueMinimoWeb.HasValue)
              query = query.Where(registro => registro.EstoqueMinimoWeb == filtro.EstoqueMinimoWeb.Value);
 
          if(filtro.EstoqueMaximoColetor.HasValue)
              query = query.Where(registro => registro.EstoqueMaximoColetor == filtro.EstoqueMaximoColetor.Value);
 
          if(filtro.EstoqueMinimoColetor.HasValue)
              query = query.Where(registro => registro.EstoqueMinimoColetor == filtro.EstoqueMinimoColetor.Value);
 
          if(filtro.TempoDadosServidorDias.HasValue)
              query = query.Where(registro => registro.TempoDadosServidorDias == filtro.TempoDadosServidorDias.Value);
 
          if(filtro.TempoVerificaERPDias.HasValue)
              query = query.Where(registro => registro.TempoVerificaERPDias == filtro.TempoVerificaERPDias.Value);

          if (filtro.TempoEntrevistaColetor.HasValue)
              query = query.Where(registro => registro.TempoEntrevistaColetor == filtro.TempoEntrevistaColetor.Value);

          if (filtro.TempoEntrevistaIncompleta.HasValue)
              query = query.Where(registro => registro.TempoEntrevistaIncompleta == filtro.TempoEntrevistaIncompleta.Value);

            return query;
        }

        #endregion

        #region [ ObterPrimeiroServico ]

        public TParametroVO ObterPrimeiroServico()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TParametro
                         select new TParametroVO
                         {
                             IDParametro = registro.IDParametro,

                             TempoLogOff = registro.TempoLogOff,

                             PrazoSincronismoDia = registro.PrazoSincronismoDia,

                             EstoqueMaximoWeb = registro.EstoqueMaximoWeb,

                             EstoqueMinimoWeb = registro.EstoqueMinimoWeb,

                             EstoqueMaximoColetor = registro.EstoqueMaximoColetor,

                             EstoqueMinimoColetor = registro.EstoqueMinimoColetor,

                             TempoDadosServidorDias = registro.TempoDadosServidorDias,

                             TempoVerificaERPDias = registro.TempoVerificaERPDias,

                             VersaoBaseCorreio = registro.VersaoBaseCorreio,

                             TempoEntrevistaColetor = registro.TempoEntrevistaColetor,

                             TempoEntrevistaIncompleta = registro.TempoEntrevistaIncompleta,

                         }).AsQueryable();

            return query.FirstOrDefault();
        }

        #endregion
    }
}
