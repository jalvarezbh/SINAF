using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class HistoricoTSincronismoBLL
    {
        #region [ Inserir ]

        public int Inserir(HistoricoTSincronismoVO tsincronismovo)
        {
            var banco = new SINAF_WebEntities();

            var query = new HistoricoTSincronismo
            {
                HistoricoTColetor = banco.HistoricoTColetor.First(coletor => coletor.IDHistoricoColetor == tsincronismovo.IDHistoricoColetor),
                
                DataSincronismo = DateTime.Now,

                NumeroUpload = 0,

                NumeroDownload = 0,

                TUsuario = banco.TUsuario.First(vendedor => vendedor.IDUsuario == tsincronismovo.IDVendedor),
            };

            banco.AddToHistoricoTSincronismo(query);
            banco.SaveChanges();

            tsincronismovo.IDHistoricoSincronismo = query.IDHistoricoSincronismo;

            return query.IDHistoricoSincronismo;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(HistoricoTSincronismoVO tsincronismovo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTSincronismo
                         where registro.IDHistoricoSincronismo.Equals(tsincronismovo.IDHistoricoSincronismo)
                         select registro).First();

            
            query.HistoricoTColetor = banco.HistoricoTColetor.First(coletor => coletor.IDHistoricoColetor == tsincronismovo.IDHistoricoColetor);
            
            query.DataSincronismo = tsincronismovo.DataSincronismo;

            query.NumeroUpload = tsincronismovo.NumeroUpload;

            query.NumeroDownload = tsincronismovo.NumeroDownload;

            query.TUsuario = banco.TUsuario.First(vendedor => vendedor.IDUsuario == tsincronismovo.IDVendedor);

            banco.SaveChanges();
        }

        #endregion
              
        #region [ Obter ]

        public HistoricoTSincronismoVO Obter(int IDHistoricoSincronismo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTSincronismo
                         where registro.IDHistoricoSincronismo == IDHistoricoSincronismo
                         select new HistoricoTSincronismoVO
                         {
                             IDHistoricoSincronismo = registro.IDHistoricoSincronismo,

                             IDHistoricoColetor = registro.HistoricoTColetor.IDHistoricoColetor,

                             DataSincronismo = registro.DataSincronismo,

                             NumeroUpload = registro.NumeroUpload,

                             NumeroDownload = registro.NumeroDownload,

                             IDVendedor = registro.TUsuario.IDUsuario,

                             NomeVendedor = registro.TUsuario.Nome,

                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ Listar ]

        public IQueryable<HistoricoTSincronismoVO> Listar(HistoricoTSincronismoVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTSincronismo
                         select new HistoricoTSincronismoVO
                         {
                             IDHistoricoSincronismo = registro.IDHistoricoSincronismo,

                             IDHistoricoColetor = registro.HistoricoTColetor.IDHistoricoColetor,

                             DataSincronismo = registro.DataSincronismo,

                             NumeroUpload = registro.NumeroUpload,

                             NumeroDownload = registro.NumeroDownload,

                             IDVendedor = registro.TUsuario.IDUsuario,

                             NomeVendedor = registro.TUsuario.Nome,

                         }).AsQueryable();


            if (filtro.IDHistoricoColetor > 0)
                query = query.Where(registro => registro.IDHistoricoColetor == filtro.IDHistoricoColetor);

            if (!string.IsNullOrEmpty(filtro.NomeVendedor))
                query = query.Where(registro => registro.NomeVendedor.Contains(filtro.NomeVendedor));

            if (filtro.DataRelatorioInicio.HasValue)
                query = query.Where(registro => registro.DataSincronismo >= filtro.DataRelatorioInicio);

            if (filtro.DataRelatorioFinal.HasValue)
                query = query.Where(registro => registro.DataSincronismo <= filtro.DataRelatorioFinal);
           

            return query;
        }

        #endregion
    }
}