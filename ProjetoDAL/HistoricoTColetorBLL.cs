using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class HistoricoTColetorBLL
    {
        #region [ Inserir ]

        public int Inserir(HistoricoTColetorVO tcoletorvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new HistoricoTColetor
            {                
                NumeroColetor = tcoletorvo.NumeroColetor,

                DataUltimoSincronismo = DateTime.Now,

                NumeroTotalSincronismo = 0,

                NumeroTotalEntrevista = 0,
            };

            banco.AddToHistoricoTColetor(query);
            banco.SaveChanges();

            tcoletorvo.IDHistoricoColetor = query.IDHistoricoColetor;

            return query.IDHistoricoColetor;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(HistoricoTColetorVO tcoletorvo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTColetor
                         where registro.IDHistoricoColetor.Equals(tcoletorvo.IDHistoricoColetor)
                         select registro).First();

            query.NumeroColetor = tcoletorvo.NumeroColetor;

            query.DataUltimoSincronismo = DateTime.Now;

            query.NumeroTotalSincronismo = query.NumeroTotalSincronismo + 1;

            query.NumeroTotalEntrevista = query.NumeroTotalEntrevista + tcoletorvo.NumeroTotalEntrevista;
                       
            banco.SaveChanges();
        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDHistoricoColetor)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTColetor where registro.IDHistoricoColetor == IDHistoricoColetor select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public HistoricoTColetorVO Obter(int IDHistoricoColetor)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTColetor
                         where registro.IDHistoricoColetor == IDHistoricoColetor
                         select new HistoricoTColetorVO
                         {
                             IDHistoricoColetor = registro.IDHistoricoColetor,

                             NumeroColetor = registro.NumeroColetor,

                             DataUltimoSincronismo = registro.DataUltimoSincronismo,

                             NumeroTotalSincronismo = registro.NumeroTotalSincronismo,

                             NumeroTotalEntrevista = registro.NumeroTotalEntrevista,

                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ ObterPorNumero ]

        public HistoricoTColetorVO ObterPorNumero(string numeroColetor)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTColetor
                         where registro.NumeroColetor.Equals(numeroColetor)
                         select new HistoricoTColetorVO
                         {
                             IDHistoricoColetor = registro.IDHistoricoColetor,

                             NumeroColetor = registro.NumeroColetor,

                             DataUltimoSincronismo = registro.DataUltimoSincronismo,

                             NumeroTotalSincronismo = registro.NumeroTotalSincronismo,

                             NumeroTotalEntrevista = registro.NumeroTotalEntrevista,

                          });

            return query.FirstOrDefault();
        }

        #endregion
        
        #region [ Listar ]

        public IQueryable<HistoricoTColetorVO> Listar(HistoricoTColetorVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.HistoricoTColetor
                          select new HistoricoTColetorVO
                         {
                             IDHistoricoColetor = registro.IDHistoricoColetor,

                             NumeroColetor = registro.NumeroColetor,

                             DataUltimoSincronismo = registro.DataUltimoSincronismo,

                             NumeroTotalSincronismo = registro.NumeroTotalSincronismo,

                             NumeroTotalEntrevista = registro.NumeroTotalEntrevista,

                          }).AsQueryable();

            return query;
        }

        #endregion

        #region [ ListarRelatorio ]

        public IQueryable<HistoricoTColetorVO> ListarRelatorio(HistoricoTColetorVO filtro)
        {
            var banco = new SINAF_WebEntities();
              
            var query = (from registro in banco.HistoricoTColetor
                         join sincronismo in banco.HistoricoTSincronismo  on registro.IDHistoricoColetor equals sincronismo.HistoricoTColetor.IDHistoricoColetor
                         orderby registro.NumeroColetor, registro.DataUltimoSincronismo, sincronismo.DataSincronismo
                         select new HistoricoTColetorVO
                         {
                             IDHistoricoColetor = registro.IDHistoricoColetor,

                             NumeroColetor = registro.NumeroColetor,

                             DataUltimoSincronismo = registro.DataUltimoSincronismo,

                             NumeroTotalSincronismo = registro.NumeroTotalSincronismo,

                             NumeroTotalEntrevista = registro.NumeroTotalEntrevista,
                                     
                             DataSincronismo = sincronismo.DataSincronismo,

                             Vendedor = sincronismo.TUsuario.Nome,
                             
                         }).AsQueryable();

            if (!string.IsNullOrEmpty(filtro.NumeroColetor))
                query = query.Where(registro => registro.NumeroColetor.Contains(filtro.NumeroColetor));

            if (!string.IsNullOrEmpty(filtro.Vendedor))
                query = query.Where(registro => registro.Vendedor.Contains(filtro.Vendedor));            
          
            if (filtro.DataRelatorioInicio.HasValue)
                query = query.Where(registro => registro.DataSincronismo >= filtro.DataRelatorioInicio);
           
            if (filtro.DataRelatorioFinal.HasValue)
                query = query.Where(registro => registro.DataSincronismo <= filtro.DataRelatorioFinal);
           
            return query;
        }

        #endregion
    }
}