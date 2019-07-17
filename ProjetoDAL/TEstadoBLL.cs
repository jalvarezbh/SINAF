using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TEstadoBLL
    {
        #region [ Listar ]

        public IQueryable<TEstadoVO> Listar()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TEstado
                         select new TEstadoVO
                         {
                             IDEstado = registro.IDEstado,

                             Sigla = registro.Sigla,

                         }).AsQueryable();

            return query;
        }

        #endregion
    }
}
