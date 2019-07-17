using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TMenuPerfilBLL
    {
        #region [ Inserir ]

        public int Inserir(TMenuPerfilVO tmenuperfilvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TMenuPerfil
            {
                IDMenuPerfil = tmenuperfilvo.IDMenuPerfil,

                TMenu = banco.TMenu.First(menu => menu.IDMenu == tmenuperfilvo.IDMenu.Value),

                TPerfil = banco.TPerfil.First(perfil => perfil.IDPerfil == tmenuperfilvo.IDPerfil.Value),
                                
                Ativo = tmenuperfilvo.Ativo,


            };

            banco.AddToTMenuPerfil(query);
            banco.SaveChanges();

            tmenuperfilvo.IDMenuPerfil = query.IDMenuPerfil;

            return query.IDMenuPerfil;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(TMenuPerfilVO tmenuperfilvo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TMenuPerfil
                         where registro.IDMenuPerfil.Equals(tmenuperfilvo.IDMenuPerfil)
                         select registro).First();

              query.IDMenuPerfil = tmenuperfilvo.IDMenuPerfil;

              query.TMenu = banco.TMenu.First(menu => menu.IDMenu == tmenuperfilvo.IDMenu.Value);

              query.TPerfil = banco.TPerfil.First(perfil => perfil.IDPerfil == tmenuperfilvo.IDPerfil.Value);
 
              query.Ativo = tmenuperfilvo.Ativo;
 

            banco.SaveChanges();

        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDMenuPerfil)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TMenuPerfil where registro.IDMenuPerfil == IDMenuPerfil select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public TMenuPerfilVO Obter(int IDMenuPerfil)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TMenuPerfil
                         where registro.IDMenuPerfil == IDMenuPerfil
                         select new TMenuPerfilVO
                         {
                            IDMenuPerfil = registro.IDMenuPerfil,
 
                            IDMenu = registro.TMenu.IDMenu,
 
                            IDPerfil = registro.TPerfil.IDPerfil,
 
                            Ativo = registro.Ativo,
 

                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ Listar ]

        public IQueryable<TMenuPerfilVO> Listar(TMenuPerfilVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TMenuPerfil
                         select new TMenuPerfilVO
                         {
                            IDMenuPerfil = registro.IDMenuPerfil,
 
                            IDMenu = registro.TMenu.IDMenu,
 
                            IDPerfil = registro.TPerfil.IDPerfil,
 
                            Ativo = registro.Ativo,
 

                         }).AsQueryable();
               
          if(filtro.IDMenu.HasValue)
              query = query.Where(registro => registro.IDMenu == filtro.IDMenu.Value);
 
          if(filtro.IDPerfil.HasValue)
              query = query.Where(registro => registro.IDPerfil == filtro.IDPerfil.Value);
 
          if(filtro.Ativo.HasValue)
              query = query.Where(registro => registro.Ativo == filtro.Ativo.Value );
 

            return query;
        }

        #endregion
    }
}
