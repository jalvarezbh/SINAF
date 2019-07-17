using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class HistoricoTEntrevistaUploadBLL
    {
        #region [ Inserir ]

        public int Inserir(HistoricoTEntrevistaUploadVO tentrevistavo)
        {
            var banco = new SINAF_WebEntities();

            var query = new HistoricoTEntrevistaUpload
            {                
                CodigoEntrevista = tentrevistavo.CodigoEntrevista,

                HistoricoTSincronismo = banco.HistoricoTSincronismo.First(sincronismo => sincronismo.IDHistoricoSincronismo == tentrevistavo.IDHistoricoSincronismo),
            };

            banco.AddToHistoricoTEntrevistaUpload(query);
            banco.SaveChanges();

            tentrevistavo.IDHistoricoEntrevistaUpload = query.IDHistoricoEntrevistaUpload;

            return query.IDHistoricoEntrevistaUpload;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(HistoricoTEntrevistaUploadVO tentrevistavo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTEntrevistaUpload
                         where registro.IDHistoricoEntrevistaUpload.Equals(tentrevistavo.IDHistoricoEntrevistaUpload)
                         select registro).First();

            query.IDHistoricoEntrevistaUpload = tentrevistavo.IDHistoricoEntrevistaUpload;

            query.CodigoEntrevista = tentrevistavo.CodigoEntrevista;

            query.HistoricoTSincronismo = banco.HistoricoTSincronismo.First(sincronismo => sincronismo.IDHistoricoSincronismo == tentrevistavo.IDHistoricoSincronismo);
                  

            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public HistoricoTEntrevistaUploadVO Obter(int IDHistoricoEntrevistaUpload)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTEntrevistaUpload
                         where registro.IDHistoricoEntrevistaUpload == IDHistoricoEntrevistaUpload
                         select new HistoricoTEntrevistaUploadVO
                         {
                             IDHistoricoEntrevistaUpload = registro.IDHistoricoEntrevistaUpload,

                             CodigoEntrevista = registro.CodigoEntrevista,

                             IDHistoricoSincronismo = registro.HistoricoTSincronismo.IDHistoricoSincronismo,
                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ Listar ]

        public IQueryable<HistoricoTEntrevistaUploadVO> Listar(HistoricoTEntrevistaUploadVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTEntrevistaUpload
                         select new HistoricoTEntrevistaUploadVO
                         {
                             IDHistoricoEntrevistaUpload = registro.IDHistoricoEntrevistaUpload,

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