using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TLogBLL
    {
        #region [ Inserir ]

        public int Inserir(TLogVO tlogvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TLog
            {
                Tabela = tlogvo.Tabela,

                TUsuario = banco.TUsuario.First(usuario => usuario.IDUsuario == tlogvo.IDUsuario),

                Data = tlogvo.Data,

                Tipo = tlogvo.Tipo,
                
            };

            banco.AddToTLog(query);
            banco.SaveChanges();

            tlogvo.IDLog = query.IDLog;

            return query.IDLog;
        }

        #endregion
    }
}
