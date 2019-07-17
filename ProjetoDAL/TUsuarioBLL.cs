using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TUsuarioBLL
    {
        #region [ Inserir ]

        public int Inserir(TUsuarioVO tusuariovo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TUsuario
            {
                  IDUsuario = tusuariovo.IDUsuario,
 
                  Nome = tusuariovo.Nome,

                  Abreviado = tusuariovo.Abreviado,

                  Login = tusuariovo.Login,
 
                  Senha = tusuariovo.Senha,

                  TPerfil = banco.TPerfil.First(perfil => perfil.IDPerfil == tusuariovo.IDPerfil),
 
                  Email = tusuariovo.Email,

                  CodigoColaborador = tusuariovo.CodigoColaborador,

                  Unidade = tusuariovo.Unidade,

                  Ativo = tusuariovo.Ativo,
            };

            banco.AddToTUsuario(query);
            banco.SaveChanges();

            tusuariovo.IDUsuario = query.IDUsuario;

            return query.IDUsuario;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(TUsuarioVO tusuariovo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TUsuario
                         where registro.IDUsuario.Equals(tusuariovo.IDUsuario)
                         select registro).First();
                           
              query.Nome = tusuariovo.Nome;

              query.Abreviado = tusuariovo.Abreviado;
 
              query.Login = tusuariovo.Login;
 
              query.Senha = tusuariovo.Senha;

              query.TPerfil = banco.TPerfil.First(perfil => perfil.IDPerfil == tusuariovo.IDPerfil);
 
              query.Email = tusuariovo.Email;
                          
              query.CodigoColaborador = tusuariovo.CodigoColaborador;

              query.Unidade = tusuariovo.Unidade;

              query.Ativo = tusuariovo.Ativo;

              banco.SaveChanges();

        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDUsuario)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TUsuario where registro.IDUsuario == IDUsuario select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public TUsuarioVO Obter(int IDUsuario)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TUsuario
                         where registro.IDUsuario == IDUsuario
                         && registro.Ativo == true
                         select new TUsuarioVO
                         {
                            IDUsuario = registro.IDUsuario,
 
                            Nome = registro.Nome,

                            Abreviado = registro.Abreviado,

                            Login = registro.Login,
 
                            Senha = registro.Senha,
 
                            IDPerfil = registro.TPerfil.IDPerfil,
 
                            Email = registro.Email,
                         
                            CodigoColaborador = registro.CodigoColaborador,
 
                            Unidade = registro.Unidade,

                            Ativo = registro.Ativo,
                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ ObterCodigo ]

        public TUsuarioVO ObterCodigo(int CodigoColaborador)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TUsuario
                         where registro.CodigoColaborador == CodigoColaborador
                         && registro.Ativo == true
                         select new TUsuarioVO
                         {
                             IDUsuario = registro.IDUsuario,

                             Nome = registro.Nome,

                             Abreviado = registro.Abreviado,

                             Login = registro.Login,

                             Senha = registro.Senha,

                             IDPerfil = registro.TPerfil.IDPerfil,

                             Email = registro.Email,
                           
                             CodigoColaborador = registro.CodigoColaborador,

                             Unidade = registro.Unidade,

                             Ativo = registro.Ativo,
                         });

            return query.FirstOrDefault();
        }

        #endregion
        
        #region [ Listar ]

        public IQueryable<TUsuarioVO> Listar(TUsuarioVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TUsuario
                         where registro.Ativo == true
                         select new TUsuarioVO
                         {
                            IDUsuario = registro.IDUsuario,
 
                            Nome = registro.Nome,

                            Abreviado = registro.Abreviado,

                            Login = registro.Login,
 
                            Senha = registro.Senha,
 
                            IDPerfil = registro.TPerfil.IDPerfil,
 
                            Email = registro.Email,

                            CodigoColaborador = registro.CodigoColaborador,

                            Unidade = registro.Unidade,

                            Ativo = registro.Ativo,

                         }).AsQueryable();

       
          if(!string.IsNullOrEmpty(filtro.Nome))
              query = query.Where(registro => registro.Nome.Contains(filtro.Nome));

          if (!string.IsNullOrEmpty(filtro.Abreviado))
              query = query.Where(registro => registro.Abreviado.Contains(filtro.Abreviado));
 
          if(!string.IsNullOrEmpty(filtro.Login))
              query = query.Where(registro => registro.Login.Contains(filtro.Login));
 
          if(!string.IsNullOrEmpty(filtro.Senha))
              query = query.Where(registro => registro.Senha.Contains(filtro.Senha));
 
          if(filtro.IDPerfil > 0)
              query = query.Where(registro => registro.IDPerfil == filtro.IDPerfil);

          if (filtro.CodigoColaborador > 0)
              query = query.Where(registro => registro.CodigoColaborador == filtro.CodigoColaborador);
 
          if(!string.IsNullOrEmpty(filtro.Email))
              query = query.Where(registro => registro.Email.Contains(filtro.Email));

          if (!string.IsNullOrEmpty(filtro.Unidade))
              query = query.Where(registro => registro.Unidade.Contains(filtro.Unidade));

            return query;
        }

        #endregion
        
        #region [ LoginSistema ]

        public TUsuarioVO LoginSistema(string login, string senha)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TUsuario
                         where registro.Login == login
                         && registro.Senha == senha 
                         && registro.Ativo == true
                         select new TUsuarioVO
                         {
                             IDUsuario = registro.IDUsuario,

                             Nome = registro.Nome,

                             Abreviado = registro.Abreviado,

                             Login = registro.Login,

                             Senha = registro.Senha,

                             IDPerfil = registro.TPerfil.IDPerfil,

                             Email = registro.Email,

                             PrimeiroAcesso = false,

                             CodigoColaborador = registro.CodigoColaborador,

                             Unidade = registro.Unidade,

                             Ativo = registro.Ativo,
                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ LoginPrimeiroAcesso ]

        public TUsuarioVO LoginPrimeiroAcesso(string login)
        {
            var banco = new SINAF_WebEntities();
            
            var query = (from registro in banco.TUsuario
                         where registro.Login == login
                         && registro.Senha == "SINAF"
                         && registro.Ativo == true
                         select new TUsuarioVO
                         {
                             IDUsuario = registro.IDUsuario,

                             Nome = registro.Nome,

                             Abreviado = registro.Abreviado,

                             Login = registro.Login,

                             Senha = registro.Senha,

                             IDPerfil = registro.TPerfil.IDPerfil,

                             Email = registro.Email,

                             PrimeiroAcesso = true,

                             CodigoColaborador = registro.CodigoColaborador,

                             Unidade = registro.Unidade,

                             Ativo = registro.Ativo,
                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ ListarSemAtendimento ]

        public IQueryable<TUsuarioVO> ListarSemAtendimento(TUsuarioVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TUsuario
                         where registro.Ativo == true
                          && registro.TPerfil.IDPerfil != 1
                          && !string.IsNullOrEmpty(registro.Abreviado.Trim())
                         select new TUsuarioVO
                         {
                             IDUsuario = registro.IDUsuario,

                             Nome = registro.Nome,

                             Abreviado = registro.Abreviado,
                             
                             Login = registro.Login,

                             Senha = registro.Senha,

                             IDPerfil = registro.TPerfil.IDPerfil,

                             Email = registro.Email,

                             CodigoColaborador = registro.CodigoColaborador,

                             Unidade = registro.Unidade,

                             Ativo = registro.Ativo,

                         }).AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nome))
                query = query.Where(registro => registro.Nome.Contains(filtro.Nome));

            if (!string.IsNullOrEmpty(filtro.Abreviado))
                query = query.Where(registro => registro.Abreviado.Contains(filtro.Abreviado));

            if (!string.IsNullOrEmpty(filtro.Login))
                query = query.Where(registro => registro.Login.Contains(filtro.Login));

            if (!string.IsNullOrEmpty(filtro.Senha))
                query = query.Where(registro => registro.Senha.Contains(filtro.Senha));

            if (filtro.IDPerfil > 0)
                query = query.Where(registro => registro.IDPerfil == filtro.IDPerfil);

            if (filtro.CodigoColaborador > 0)
                query = query.Where(registro => registro.CodigoColaborador == filtro.CodigoColaborador);

            if (!string.IsNullOrEmpty(filtro.Email))
                query = query.Where(registro => registro.Email.Contains(filtro.Email));

            if (!string.IsNullOrEmpty(filtro.Unidade))
                query = query.Where(registro => registro.Unidade.Contains(filtro.Unidade));

            return query;
        }

        #endregion

        #region [ VendedorLivre ]

        public IQueryable<TUsuarioVO> VendedorLivre(TUsuarioVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TUsuario
                         where !banco.TColetor.Any(coletor => coletor.CodigoUsuarioResponsavel == registro.CodigoColaborador)
                         && registro.Ativo == true
                         && registro.TPerfil.IDPerfil != 1
                         && !string.IsNullOrEmpty(registro.Abreviado.Trim())
                         select new TUsuarioVO
                         {
                             IDUsuario = registro.IDUsuario,

                             Nome = registro.Nome,

                             Abreviado = registro.Abreviado,

                             Login = registro.Login,

                             Senha = registro.Senha,

                             IDPerfil = registro.TPerfil.IDPerfil,

                             Email = registro.Email,

                             CodigoColaborador = registro.CodigoColaborador,

                             Unidade = registro.Unidade,

                             Ativo = registro.Ativo,

                         }).AsQueryable();


            if (!string.IsNullOrEmpty(filtro.Nome))
                query = query.Where(registro => registro.Nome.Contains(filtro.Nome));

            if (!string.IsNullOrEmpty(filtro.Abreviado))
                query = query.Where(registro => registro.Abreviado.Contains(filtro.Abreviado));

            if (!string.IsNullOrEmpty(filtro.Login))
                query = query.Where(registro => registro.Login.Contains(filtro.Login));

            if (!string.IsNullOrEmpty(filtro.Senha))
                query = query.Where(registro => registro.Senha.Contains(filtro.Senha));

            if (filtro.IDPerfil > 0)
                query = query.Where(registro => registro.IDPerfil == filtro.IDPerfil);

            if (!string.IsNullOrEmpty(filtro.Email))
                query = query.Where(registro => registro.Email.Contains(filtro.Email));
                       
            return query;

        }

        #endregion

        #region [ ListarUsuarioAgendamento ]

        public IQueryable<int> ListarUsuarioAgendamento(string nome)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TUsuario
                         where registro.Nome.Contains(nome)
                         select registro.IDUsuario).AsQueryable();

            return query;
        }

        #endregion

        #region [ AlterarPerfilCargo ]

        public void AlterarPerfilCargo(string cargo , int idPerfil)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TUsuario
                         where registro.Cargo.Equals(cargo)
                         select registro).ToList();

            foreach (var item in query)
            {
                item.TPerfil = banco.TPerfil.First(perfil => perfil.IDPerfil == idPerfil);
            }                      

            banco.SaveChanges();

        }

        #endregion
    }
}
