using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class HistoricoTEntrevistaDownloadBLL
    {
        #region [ Inserir ]

        public int Inserir(HistoricoTEntrevistaDownloadVO tentrevistavo)
        {
            var banco = new SINAF_WebEntities();

            var query = new HistoricoTEntrevistaDownload
            {
                CodigoEntrevista = tentrevistavo.CodigoEntrevista,

                HistoricoTSincronismo = banco.HistoricoTSincronismo.First(sincronismo => sincronismo.IDHistoricoSincronismo == tentrevistavo.IDHistoricoSincronismo),
            };

            banco.AddToHistoricoTEntrevistaDownload(query);
            banco.SaveChanges();

            tentrevistavo.IDHistoricoEntrevistaDownload = query.IDHistoricoEntrevistaDownload;

            return query.IDHistoricoEntrevistaDownload;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(HistoricoTEntrevistaDownloadVO tentrevistavo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTEntrevistaDownload
                         where registro.IDHistoricoEntrevistaDownload.Equals(tentrevistavo.IDHistoricoEntrevistaDownload)
                         select registro).First();

            query.IDHistoricoEntrevistaDownload = tentrevistavo.IDHistoricoEntrevistaDownload;

            query.CodigoEntrevista = tentrevistavo.CodigoEntrevista;

            query.HistoricoTSincronismo = banco.HistoricoTSincronismo.First(sincronismo => sincronismo.IDHistoricoSincronismo == tentrevistavo.IDHistoricoSincronismo);

            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public HistoricoTEntrevistaDownloadVO Obter(int IDHistoricoEntrevistaDownload)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTEntrevistaDownload
                         where registro.IDHistoricoEntrevistaDownload == IDHistoricoEntrevistaDownload
                         select new HistoricoTEntrevistaDownloadVO
                         {
                             IDHistoricoEntrevistaDownload = registro.IDHistoricoEntrevistaDownload,

                             CodigoEntrevista = registro.CodigoEntrevista,

                             IDHistoricoSincronismo = registro.HistoricoTSincronismo.IDHistoricoSincronismo,
                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ Listar ]

        public IQueryable<HistoricoTEntrevistaDownloadVO> Listar(HistoricoTEntrevistaDownloadVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTEntrevistaDownload
                         select new HistoricoTEntrevistaDownloadVO
                         {
                             IDHistoricoEntrevistaDownload = registro.IDHistoricoEntrevistaDownload,

                             CodigoEntrevista = registro.CodigoEntrevista,

                             IDHistoricoSincronismo = registro.HistoricoTSincronismo.IDHistoricoSincronismo,
                         
                         }).AsQueryable();


            if (filtro.IDHistoricoSincronismo > 0)
                query = query.Where(registro => registro.IDHistoricoSincronismo == filtro.IDHistoricoSincronismo);

            return query;
        }

        #endregion
    }
}