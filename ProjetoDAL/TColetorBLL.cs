using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TColetorBLL
    {
        #region [ Inserir ]

        public int Inserir(TColetorVO tcoletorvo)
        {
            var banco = new SINAF_WebEntities();
            
            var query = new TColetor
            {
                  IDColetor = tcoletorvo.IDColetor,
 
                  NumeroSerie = tcoletorvo.NumeroSerie,
 
                  IMEI = tcoletorvo.IMEI,
 
                  Fabricante = tcoletorvo.Fabricante,
 
                  Modelo = tcoletorvo.Modelo,

                  CodigoUsuarioCadastro =  banco.TUsuario.First(coletor => coletor.IDUsuario == tcoletorvo.IDUsuarioCadastro).CodigoColaborador,
   
                  DataCadastro = DateTime.Now,
 
                  UsoBackup = tcoletorvo.UsoBackup,

                  Ativo = true,                                  
            };

           banco.AddToTColetor(query);
           banco.SaveChanges();

           tcoletorvo.IDColetor = query.IDColetor;

           return query.IDColetor;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(TColetorVO tcoletorvo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TColetor
                         where registro.IDColetor.Equals(tcoletorvo.IDColetor)
                         select registro).First();

              query.NumeroSerie = tcoletorvo.NumeroSerie;
 
              query.IMEI = tcoletorvo.IMEI;
 
              query.Fabricante = tcoletorvo.Fabricante;
 
              query.Modelo = tcoletorvo.Modelo;

              query.DataCadastro = DateTime.Now;

              if (tcoletorvo.IDUsuarioResponsavel.HasValue)
                  if (tcoletorvo.IDUsuarioResponsavel.Value > 0)
                      query.CodigoUsuarioResponsavel = banco.TUsuario.FirstOrDefault(coletor => coletor.IDUsuario == tcoletorvo.IDUsuarioResponsavel.Value).CodigoColaborador;
                  else
                      query.CodigoUsuarioResponsavel = null;

              query.UsoBackup = tcoletorvo.UsoBackup;
                          
              banco.SaveChanges();
        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDColetor)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TColetor where registro.IDColetor == IDColetor select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public TColetorVO Obter(int IDColetor)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TColetor
                         where registro.IDColetor == IDColetor
                         select new TColetorVO
                         {
                            IDColetor = registro.IDColetor,
 
                            NumeroSerie = registro.NumeroSerie,
 
                            IMEI = registro.IMEI,
 
                            Fabricante = registro.Fabricante,
 
                            Modelo = registro.Modelo,
 
                            IDUsuarioResponsavel = registro.CodigoUsuarioResponsavel,
 
                            IDUsuarioCadastro = registro.CodigoUsuarioCadastro ,

                            NomeUsuarioResponsavel = banco.TUsuario.FirstOrDefault(coletor => coletor.CodigoColaborador == registro.CodigoUsuarioResponsavel).Nome,

                            NomeUsuarioCadastro = banco.TUsuario.FirstOrDefault(coletor => coletor.CodigoColaborador == registro.CodigoUsuarioCadastro).Nome,
 
                            DataCadastro = registro.DataCadastro,
 
                            Ativo = registro.Ativo,
 
                            DataInativacao = registro.DataInativacao,
 
                            UsoBackup = registro.UsoBackup,
  
                            MotivoInativacao = registro.MotivoInativacao,
  
                            DataUltimaSincronizacao = registro.DataUltimaSincronizacao,

                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ ObterPorVendedor ]

        public TColetorVO ObterPorVendedor(int IDVendedor)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TColetor
                         where registro.CodigoUsuarioResponsavel == banco.TUsuario.FirstOrDefault(coletor => coletor.IDUsuario == IDVendedor).CodigoColaborador
                         select new TColetorVO
                         {
                             IDColetor = registro.IDColetor,

                             NumeroSerie = registro.NumeroSerie,

                             IMEI = registro.IMEI,

                             Fabricante = registro.Fabricante,

                             Modelo = registro.Modelo,

                             IDUsuarioResponsavel = registro.CodigoUsuarioResponsavel,

                             IDUsuarioCadastro = registro.CodigoUsuarioCadastro,

                             NomeUsuarioResponsavel = banco.TUsuario.FirstOrDefault(coletor => coletor.CodigoColaborador == registro.CodigoUsuarioResponsavel).Nome,

                             NomeUsuarioCadastro = banco.TUsuario.FirstOrDefault(coletor => coletor.CodigoColaborador == registro.CodigoUsuarioCadastro).Nome,
 
                             DataCadastro = registro.DataCadastro,

                             Ativo = registro.Ativo,

                             DataInativacao = registro.DataInativacao,

                             UsoBackup = registro.UsoBackup,

                             MotivoInativacao = registro.MotivoInativacao,

                             DataUltimaSincronizacao = registro.DataUltimaSincronizacao,

                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ Listar ]

        public IQueryable<TColetorVO> Listar(TColetorVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TColetor
                         select new TColetorVO
                         {
                            IDColetor = registro.IDColetor,
 
                            NumeroSerie = registro.NumeroSerie,
 
                            IMEI = registro.IMEI,
 
                            Fabricante = registro.Fabricante,
 
                            Modelo = registro.Modelo,
 
                            IDUsuarioResponsavel = registro.CodigoUsuarioResponsavel,
 
                            IDUsuarioCadastro = registro.CodigoUsuarioCadastro,
 
                            DataCadastro = registro.DataCadastro,
 
                            Ativo = registro.Ativo,
 
                            DataInativacao = registro.DataInativacao,
 
                            UsoBackup = registro.UsoBackup,
                            
                            MotivoInativacao = registro.MotivoInativacao,

                            DataUltimaSincronizacao = registro.DataUltimaSincronizacao,

                         }).AsQueryable();

        
          if(!string.IsNullOrEmpty(filtro.NumeroSerie))
              query = query.Where(registro => registro.NumeroSerie.Contains(filtro.NumeroSerie));
 
          if(!string.IsNullOrEmpty(filtro.IMEI))
              query = query.Where(registro => registro.IMEI.Contains(filtro.IMEI));
 
          if(!string.IsNullOrEmpty(filtro.Fabricante))
              query = query.Where(registro => registro.Fabricante.Contains(filtro.Fabricante));
 
          if(!string.IsNullOrEmpty(filtro.Modelo))
              query = query.Where(registro => registro.Modelo.Contains(filtro.Modelo));

          if (filtro.ConsultaAtivo.HasValue)
              if (filtro.ConsultaAtivo.Value)
                  query = query.Where(registro => registro.Ativo == filtro.Ativo);

          if (filtro.ConsultaUsoBackup.HasValue)
              if (filtro.ConsultaUsoBackup.Value)
                  query = query.Where(registro => registro.UsoBackup == filtro.UsoBackup);

          if (filtro.DataUltimaSincronizacaoInicio.HasValue)
              query = query.Where(registro => registro.DataUltimaSincronizacao >= filtro.DataUltimaSincronizacaoInicio.Value);

          if (filtro.DataUltimaSincronizacaoFim.HasValue)
              query = query.Where(registro => registro.DataUltimaSincronizacao <= filtro.DataUltimaSincronizacaoFim.Value);

          if (filtro.DataInativacaoInicio.HasValue)
              query = query.Where(registro => registro.DataInativacao >= filtro.DataInativacaoInicio.Value);

          if (filtro.DataInativacaoFim.HasValue)
              query = query.Where(registro => registro.DataInativacao <= filtro.DataInativacaoFim.Value);
                       
          return query;
        }

        #endregion

        #region [ ListarColetorLivre ]

        public IQueryable<TColetorVO> ListarColetorLivre()
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TColetor
                         where registro.CodigoUsuarioResponsavel == null
                         select new TColetorVO
                         {
                             IDColetor = registro.IDColetor,

                             NumeroSerie = registro.NumeroSerie,

                             IMEI = registro.IMEI,

                             Fabricante = registro.Fabricante,

                             Modelo = registro.Modelo,

                             IDUsuarioResponsavel = registro.CodigoUsuarioResponsavel,

                             IDUsuarioCadastro = registro.CodigoUsuarioCadastro,

                             DataCadastro = registro.DataCadastro,

                             Ativo = registro.Ativo,

                             DataInativacao = registro.DataInativacao,

                             UsoBackup = registro.UsoBackup,

                             MotivoInativacao = registro.MotivoInativacao,

                             DataUltimaSincronizacao = registro.DataUltimaSincronizacao,

                         }).AsQueryable();

            return query;
        }

        #endregion
                
        #region [ ListarRelatorio ]

        public IQueryable<TColetorVO> ListarRelatorio(TColetorVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TColetor
                         select new TColetorVO
                         {
                             IDColetor = registro.IDColetor,

                             NumeroSerie = registro.NumeroSerie,

                             IMEI = registro.IMEI,

                             Fabricante = registro.Fabricante,

                             Modelo = registro.Modelo,

                             IDUsuarioResponsavel = registro.CodigoUsuarioResponsavel,

                             IDUsuarioCadastro = registro.CodigoUsuarioCadastro,

                             DataCadastro = registro.DataCadastro,

                             Ativo = registro.Ativo,

                             DataInativacao = registro.DataInativacao,

                             UsoBackup = registro.UsoBackup,

                             MotivoInativacao = registro.MotivoInativacao,

                             DataUltimaSincronizacao = registro.DataUltimaSincronizacao,

                             IDUsuarioVendedor = banco.TUsuario.FirstOrDefault(usuario => usuario.CodigoColaborador == registro.CodigoUsuarioResponsavel).IDUsuario,
                        
                             NomeVendedor = banco.TUsuario.FirstOrDefault(usuario => usuario.CodigoColaborador == registro.CodigoUsuarioResponsavel).Nome,

                             UnidadeVendedor = banco.TUsuario.FirstOrDefault(usuario => usuario.CodigoColaborador == registro.CodigoUsuarioResponsavel).Unidade,

                         }).AsQueryable();


            if (!string.IsNullOrEmpty(filtro.NumeroSerie))
                query = query.Where(registro => registro.NumeroSerie.Contains(filtro.NumeroSerie));

            if (!string.IsNullOrEmpty(filtro.NomeVendedor))
                query = query.Where(registro => registro.NomeVendedor.Contains(filtro.NomeVendedor));

            if (!string.IsNullOrEmpty(filtro.UnidadeVendedor))
                if(!filtro.UnidadeVendedor.Contains("TODAS"))
                    query = query.Where(registro => registro.UnidadeVendedor.Contains(filtro.UnidadeVendedor));

            if (filtro.DataRelatorioInicio.HasValue)
                query = query.Where(registro => registro.DataUltimaSincronizacao >= filtro.DataRelatorioInicio.Value);

            if (filtro.DataRelatorioFinal.HasValue)
                query = query.Where(registro => registro.DataUltimaSincronizacao <= filtro.DataRelatorioFinal.Value);
                                  
            return query;
        }

        #endregion

        #region [ ListarRelatorioVendedorColetor ]

        public IQueryable<TColetorVO> ListarRelatorioVendedorColetor(TColetorVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TColetor
                         select new TColetorVO
                         {
                             IDColetor = registro.IDColetor,

                             NumeroSerie = registro.NumeroSerie,

                             IMEI = registro.IMEI,

                             Fabricante = registro.Fabricante,

                             Modelo = registro.Modelo,

                             IDUsuarioResponsavel = registro.CodigoUsuarioResponsavel,

                             IDUsuarioCadastro = registro.CodigoUsuarioCadastro,

                             DataCadastro = registro.DataCadastro,

                             Ativo = registro.Ativo,

                             DataInativacao = registro.DataInativacao,

                             UsoBackup = registro.UsoBackup,

                             MotivoInativacao = registro.MotivoInativacao,

                             DataUltimaSincronizacao = registro.DataUltimaSincronizacao,

                             IDUsuarioVendedor = banco.TUsuario.FirstOrDefault(usuario => usuario.CodigoColaborador == registro.CodigoUsuarioResponsavel).IDUsuario,

                             NomeVendedor = banco.TUsuario.FirstOrDefault(usuario => usuario.CodigoColaborador == registro.CodigoUsuarioResponsavel).Abreviado,

                             UnidadeVendedor = banco.TUsuario.FirstOrDefault(usuario => usuario.CodigoColaborador == registro.CodigoUsuarioResponsavel).Unidade,

                         }).AsQueryable();


            if (!string.IsNullOrEmpty(filtro.NumeroSerie))
                query = query.Where(registro => registro.NumeroSerie.Contains(filtro.NumeroSerie));

            if (!string.IsNullOrEmpty(filtro.NomeVendedor))
                query = query.Where(registro => registro.NomeVendedor.Contains(filtro.NomeVendedor));

            if (!string.IsNullOrEmpty(filtro.TipoRelatorio))
            {
                switch (filtro.TipoRelatorio)
                {
                    case "S":
                        query = query.Where(registro => string.IsNullOrEmpty(registro.NomeVendedor));
                        break;
                    case "N":
                        query = query.Where(registro => !string.IsNullOrEmpty(registro.NomeVendedor));
                        break;
                    case "T":
                        break;
                    default:
                        break;
                }
            }                
                       
            if (filtro.DataRelatorioInicio.HasValue)
                query = query.Where(registro => registro.DataCadastro >= filtro.DataRelatorioInicio.Value);

            if (filtro.DataRelatorioFinal.HasValue)
                query = query.Where(registro => registro.DataCadastro <= filtro.DataRelatorioFinal.Value);

            query = query.OrderBy(order => order.NomeVendedor);

            return query;
        }

        #endregion
    }
}
