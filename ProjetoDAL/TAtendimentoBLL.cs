using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TAtendimentoBLL
    {
        #region [ Inserir ]

        public int Inserir(TAtendimentoVO tatendimentovo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TAtendimento
            {
                IDBairro = tatendimentovo.IDBairro,

                IDCidade = tatendimentovo.IDCidade,
          
                TFilial = banco.TFilial.First(registro => registro.IDFilial == tatendimentovo.IDFilial),
            };

            banco.AddToTAtendimento(query);
            banco.SaveChanges();

            tatendimentovo.IDAtendimento = query.IDAtendimento;

            return query.IDAtendimento;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(TAtendimentoVO tatendimentovo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAtendimento
                         where registro.IDAtendimento.Equals(tatendimentovo.IDAtendimento)
                         select registro).First();

            query.IDBairro = tatendimentovo.IDBairro;

            query.IDCidade = tatendimentovo.IDCidade;

            query.TFilial = banco.TFilial.First(registro => registro.IDFilial == tatendimentovo.IDFilial);

            banco.SaveChanges();

        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDAtendimento)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAtendimento where registro.IDAtendimento == IDAtendimento select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public TAtendimentoVO Obter(int IDAtendimento)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAtendimento
                         where registro.IDAtendimento == IDAtendimento
                         select new TAtendimentoVO
                         {
                             IDAtendimento = registro.IDAtendimento,

                             IDBairro = registro.IDBairro,

                             IDCidade = registro.IDCidade,

                             IDFilial = registro.TFilial.IDFilial,
                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ ObterAtendimento ]

        public Int32 ObterAtendimento(int IDFilial, int IDCidade, int IDBairro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAtendimento
                         where registro.TFilial.IDFilial == IDFilial
                         && registro.IDCidade == IDCidade
                         && registro.IDBairro == IDBairro
                         select registro.IDAtendimento );

            return query.FirstOrDefault() ;
        }

        #endregion

        #region [ ObterAtendimentoCallCenter ]

        public Int32 ObterAtendimentoCallCenter(int IDCidade, int IDBairro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAtendimento
                         where registro.IDCidade == IDCidade
                         && registro.IDBairro == IDBairro
                         select registro.IDAtendimento);

            return query.FirstOrDefault();
        }

        #endregion

        #region [ ObterAtendimentoFilial ]

        public Int32 ObterAtendimentoFilial(int IDFilial)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAtendimento
                         where registro.TFilial.IDFilial == IDFilial
                         select registro.IDAtendimento);

            return query.FirstOrDefault();
        }

        #endregion

        #region [ ListarAtendimentoFilial ]

        public List<int> ListarAtendimentoFilial(string NomeFilial)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAtendimento
                         join filial in banco.TFilial on registro.TFilial.IDFilial equals filial.IDFilial
                         where filial.NomeFilial.Equals(NomeFilial)
                         select registro.IDAtendimento);

            return query.ToList();
        }

        #endregion
    }
}
