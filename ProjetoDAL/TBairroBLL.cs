using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TBairroBLL
    {
        #region [ ObterIDBairro ]

        public int ObterIDBairro(string NomeBairro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TBairro
                         where registro.NomeBairro.Equals(NomeBairro)
                         select registro.IDBairro
                         );

            return query.FirstOrDefault();
        }

        #endregion
    }
}
