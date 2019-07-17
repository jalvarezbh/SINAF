using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TFaixaBLL
    {
        #region [ NumeroEntrevista ]

        public int NumeroEntrevista(int idResponsavel)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TFaixa
                         where registro.TUsuario.IDUsuario == idResponsavel
                         select new TFaixaVO
                         {
                             IDFaixa = registro.IDFaixa,

                             CodigoFaixa = registro.CodigoFaixa,

                             Usado = registro.Usado,

                             IDResponsavel = registro.TUsuario.IDUsuario,                             

                         }).AsQueryable();
                                  
            return query.Count();
        }

        #endregion

        #region [ FaixaCarregada ]

        public int FaixaCarregada(int idResponsavel)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TFaixa
                         where registro.TUsuario.IDUsuario == idResponsavel
                         && registro.Usado == true
                         select new TFaixaVO
                         {
                             IDFaixa = registro.IDFaixa,

                             CodigoFaixa = registro.CodigoFaixa,

                             Usado = registro.Usado,

                             IDResponsavel = registro.TUsuario.IDUsuario,

                         }).AsQueryable();

            return query.Count();
        }

        #endregion
    }
}
