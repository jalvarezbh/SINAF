using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TCidadeBLL
    {
        #region [ ObterIDCidade ]

        public int ObterIDCidade(string NomeCidade)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TCidade
                         where registro.NomeCidade.Equals(NomeCidade)
                         select registro.IDCidade
                         );

            return query.FirstOrDefault();
        }

        #endregion
    }
}
