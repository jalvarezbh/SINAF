using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TLogradouroBLL
    {
        #region [ ListarPorCEP ]

        public IQueryable<TLogradouroVO> ListarPorCEP(int cep)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TLogradouro
                         where registro.CEP == cep 
                         select new TLogradouroVO
                         {
                             IDLogradouro  = registro.IDLogradouro ,

                             NomeLogradouro = registro.NomeLogradouro ,

                             CEP  = registro.CEP ,

                             IDBairro = registro.TBairro.IDBairro ,

                             NomeBairro = registro.TBairro.NomeBairro ,

                             IDCidade  = registro.TBairro.TCidade.IDCidade ,

                             NomeCidade  = registro.TBairro.TCidade.NomeCidade ,

                             IDEstado = registro.TBairro.TCidade.TEstado.IDEstado ,

                             Sigla = registro.TBairro.TCidade.TEstado.Sigla ,

                         }).AsQueryable();
            
            return query;
        }

        #endregion
    }
}
