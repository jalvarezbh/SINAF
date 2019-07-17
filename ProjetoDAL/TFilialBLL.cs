using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TFilialBLL
    {
        #region [ Inserir ]

        public int Inserir(TFilialVO tfilialvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TFilial
            {
                NomeFilial = tfilialvo.NomeFilial,
            };

            banco.AddToTFilial(query);
            banco.SaveChanges();

            tfilialvo.IDFilial = query.IDFilial;

            return query.IDFilial;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(TFilialVO tfilialvo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TFilial
                         where registro.IDFilial.Equals(tfilialvo.IDFilial)
                         select registro).First();

            query.NomeFilial = tfilialvo.NomeFilial;

            banco.SaveChanges();

        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDFilial)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TFilial where registro.IDFilial == IDFilial select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public TFilialVO Obter(int IDFilial)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TFilial
                         where registro.IDFilial == IDFilial 
                         select new TFilialVO
                         {
                             IDFilial = registro.IDFilial,

                             NomeFilial = registro.NomeFilial,
                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ ObterIDFilial ]

        public int ObterIDFilial(string NomeFilial)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TFilial
                         where registro.NomeFilial.Equals(NomeFilial)
                         select registro.IDFilial);

            return query.FirstOrDefault() ;
        }

        #endregion
                
    }
}
