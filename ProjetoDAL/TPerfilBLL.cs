using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TPerfilBLL
    {
        #region [ Inserir ]

        public int Inserir(TPerfilVO tperfilvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TPerfil
            {
                  IDPerfil = tperfilvo.IDPerfil,
 
                  Descricao = tperfilvo.Descricao,
 
                  Ativo = tperfilvo.Ativo,
 
            };

            banco.AddToTPerfil(query);
            banco.SaveChanges();

            tperfilvo.IDPerfil = query.IDPerfil;

            return query.IDPerfil;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(TPerfilVO tperfilvo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPerfil
                         where registro.IDPerfil.Equals(tperfilvo.IDPerfil)
                         select registro).First();

              query.IDPerfil = tperfilvo.IDPerfil;
 
              query.Descricao = tperfilvo.Descricao;
 
              query.Ativo = tperfilvo.Ativo;
 
            banco.SaveChanges();

        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDPerfil)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPerfil where registro.IDPerfil == IDPerfil select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public TPerfilVO Obter(int IDPerfil)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPerfil
                         where registro.IDPerfil == IDPerfil
                         select new TPerfilVO
                         {
                            IDPerfil = registro.IDPerfil,
 
                            Descricao = registro.Descricao,
 
                            Ativo = registro.Ativo,
 
                         });

            return query.FirstOrDefault();
        }

        #endregion
          
        #region [ Listar ]

        public IQueryable<TPerfilVO> Listar(TPerfilVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPerfil
                         select new TPerfilVO
                         {
                            IDPerfil = registro.IDPerfil,
 
                            Descricao = registro.Descricao,
 
                            Ativo = registro.Ativo,
 
                         }).AsQueryable();

          if(!string.IsNullOrEmpty(filtro.Descricao))
              query = query.Where(registro => registro.Descricao.Contains(filtro.Descricao));
 
          if(filtro.Ativo.HasValue)
              query = query.Where(registro => registro.Ativo == filtro.Ativo.HasValue );
 


            return query;
        }

        #endregion

        #region [ InserirPerfilCargo ]

        public int InserirPerfilCargo(TPerfilVO tperfilvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TPerfilCargo
            {
                TPerfil = banco.TPerfil.First(perfil => perfil.IDPerfil == tperfilvo.IDPerfil),

                Cargo = tperfilvo.NomeCargo,                

            };

            banco.AddToTPerfilCargo(query);
            banco.SaveChanges();

            tperfilvo.IDPerfilCargo = query.IDPerfilCargo;

            return query.IDPerfilCargo;
        }

        #endregion

        #region [ AlterarPerfilCargo ]

        public void AlterarPerfilCargo(TPerfilVO tperfilvo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPerfilCargo
                         where registro.IDPerfilCargo.Equals(tperfilvo.IDPerfilCargo)
                         select registro).First();

            query.IDPerfilCargo = tperfilvo.IDPerfilCargo;

            query.TPerfil = banco.TPerfil.First(perfil => perfil.IDPerfil == tperfilvo.IDPerfil);

            query.Cargo = tperfilvo.NomeCargo;

            banco.SaveChanges();

        }

        #endregion

        #region [ ObterPerfilCargo ]

        public TPerfilVO ObterPerfilCargo(int IDPerfilCargo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPerfilCargo
                         where registro.IDPerfilCargo == IDPerfilCargo
                         select new TPerfilVO
                         {
                             IDPerfilCargo = registro.IDPerfilCargo,

                             IDPerfil = registro.TPerfil.IDPerfil,

                             Descricao = registro.TPerfil.Descricao,

                             Ativo = registro.TPerfil.Ativo,

                             NomeCargo = registro.Cargo,

                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ ListarPerfilCargo ]

        public IQueryable<TPerfilVO> ListarPerfilCargo(TPerfilVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPerfilCargo
                         select new TPerfilVO
                         {
                             IDPerfilCargo = registro.IDPerfilCargo,

                             IDPerfil = registro.TPerfil.IDPerfil,

                             Descricao = registro.TPerfil.Descricao,

                             Ativo = registro.TPerfil.Ativo,

                             NomeCargo = registro.Cargo,

                         }).AsQueryable();


            if (filtro.IDPerfil > 0)
                query = query.Where(registro => registro.IDPerfil == filtro.IDPerfil);

            if (!string.IsNullOrEmpty(filtro.NomeCargo))
                query = query.Where(registro => registro.NomeCargo.Contains(filtro.NomeCargo));

            if (!string.IsNullOrEmpty(filtro.Descricao))
                query = query.Where(registro => registro.Descricao.Contains(filtro.Descricao));

            if (filtro.Ativo.HasValue)
                query = query.Where(registro => registro.Ativo == filtro.Ativo.HasValue);



            return query;
        }

        #endregion

        #region [ ExcluirPerfilCargo ]

        public void ExcluirPerfilCargo(int IDPerfilCargo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPerfilCargo where registro.IDPerfilCargo == IDPerfilCargo select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ ValidarPerfilCargo ]

        public IQueryable<TPerfilVO> ValidarPerfilCargo(TPerfilVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TPerfilCargo
                         select new TPerfilVO
                         {
                             IDPerfilCargo = registro.IDPerfilCargo,

                             IDPerfil = registro.TPerfil.IDPerfil,

                             Descricao = registro.TPerfil.Descricao,

                             Ativo = registro.TPerfil.Ativo,

                             NomeCargo = registro.Cargo,

                         }).AsQueryable();


            query = query.Where(registro => registro.IDPerfil != filtro.IDPerfil);

            query = query.Where(registro => registro.NomeCargo.Equals(filtro.NomeCargo));
            
            return query;
        }

        #endregion
    }
}
