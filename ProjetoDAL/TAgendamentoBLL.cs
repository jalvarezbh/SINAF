using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class TAgendamentoBLL
    {
        #region [ Inserir ]

        public int Inserir(TAgendamentoVO tagendamentovo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TAgendamento
            {
                Nome = tagendamentovo.Nome,

                DataNascimento = tagendamentovo.DataNascimento,

                Email = tagendamentovo.Email,

                Telefone = tagendamentovo.Telefone,

                Celular = tagendamentovo.Celular,

                CEP = tagendamentovo.CEP,

                Logradouro = tagendamentovo.Logradouro,

                Numero = tagendamentovo.Numero,

                Complemento = tagendamentovo.Complemento,

                Bairro = tagendamentovo.Bairro,

                Cidade = tagendamentovo.Cidade,

                UF = tagendamentovo.UF,

                PontoReferencia = tagendamentovo.PontoReferencia,

                TAtendimento = banco.TAtendimento.FirstOrDefault(registro => registro.IDAtendimento ==  tagendamentovo.IDAtendimento),

                TUsuario = banco.TUsuario.First(registro => registro.IDUsuario == tagendamentovo.IDUsuarioAgendamento),

                TUsuario1 = banco.TUsuario.FirstOrDefault(registro => registro.IDUsuario == tagendamentovo.IDUsuarioVendedor),
          
            };

            banco.AddToTAgendamento(query);
            banco.SaveChanges();

            tagendamentovo.IDAgendamento = query.IDAgendamento;

            return query.IDAgendamento;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(TAgendamentoVO tagendamentovo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAgendamento
                         where registro.IDAgendamento.Equals(tagendamentovo.IDAgendamento)
                         select registro).First();


            query.Nome = tagendamentovo.Nome;

            query.DataNascimento = tagendamentovo.DataNascimento;

            query.Email = tagendamentovo.Email;

            query.Telefone = tagendamentovo.Telefone;

            query.Celular = tagendamentovo.Celular;

            query.CEP = tagendamentovo.CEP;

            query.Logradouro = tagendamentovo.Logradouro;

            query.Numero = tagendamentovo.Numero;

            query.Complemento = tagendamentovo.Complemento;

            query.Bairro = tagendamentovo.Bairro;

            query.Cidade = tagendamentovo.Cidade;

            query.UF = tagendamentovo.UF;

            query.PontoReferencia = tagendamentovo.PontoReferencia;

            query.TAtendimento = banco.TAtendimento.FirstOrDefault(registro => registro.IDAtendimento ==  tagendamentovo.IDAtendimento);

            query.TUsuario = banco.TUsuario.First(registro => registro.IDUsuario == tagendamentovo.IDUsuarioAgendamento);

            query.TUsuario1 = banco.TUsuario.FirstOrDefault(registro => registro.IDUsuario == tagendamentovo.IDUsuarioVendedor);

            banco.SaveChanges();

        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDAgendamento)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAgendamento where registro.IDAgendamento == IDAgendamento select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public TAgendamentoVO Obter(int IDAgendamento)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAgendamento
                         where registro.IDAgendamento == IDAgendamento
                         select new TAgendamentoVO
                         {
                             IDAgendamento = registro.IDAgendamento,

                             Nome = registro.Nome,

                             DataNascimento = registro.DataNascimento,

                             Email = registro.Email,

                             Telefone = registro.Telefone,

                             Celular = registro.Celular,

                             CEP = registro.CEP,

                             Logradouro = registro.Logradouro,

                             Numero = registro.Numero,

                             Complemento = registro.Complemento,

                             Bairro = registro.Bairro,

                             Cidade = registro.Cidade,

                             UF = registro.UF,

                             PontoReferencia = registro.PontoReferencia,

                             IDAtendimento = registro.TAtendimento.IDAtendimento,

                             IDUsuarioAgendamento = registro.TUsuario.IDUsuario ,

                             IDUsuarioVendedor = registro.TUsuario1.IDUsuario,
                         });

            return query.FirstOrDefault();
        }

        #endregion

        #region [ Listar ]

        public IQueryable<TAgendamentoVO> Listar(TAgendamentoVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAgendamento
                         select new TAgendamentoVO
                         {
                             IDAgendamento = registro.IDAgendamento,

                             Nome = registro.Nome,

                             DataNascimento = registro.DataNascimento,

                             Email = registro.Email,

                             Telefone = registro.Telefone,

                             Celular = registro.Celular,

                             CEP = registro.CEP,

                             Logradouro = registro.Logradouro,

                             Numero = registro.Numero,

                             Complemento = registro.Complemento,

                             Bairro = registro.Bairro,

                             Cidade = registro.Cidade,

                             UF = registro.UF,

                             PontoReferencia = registro.PontoReferencia,

                             IDAtendimento = registro.TAtendimento.IDAtendimento,

                             IDUsuarioAgendamento = registro.TUsuario.IDUsuario,

                             IDUsuarioVendedor = registro.TUsuario1.IDUsuario,

                         }).AsQueryable();
            
            return query;
        }

        #endregion

        #region [ ListarGridConsulta ]

        public List<TAgendamentoVO> ListarGridConsulta(List<int> idsAtendimento, List<int> usuarioAtendente, List<int> usuarioVendedor)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TAgendamento
                         select new TAgendamentoVO
                         {
                             IDAgendamento = registro.IDAgendamento,

                             Nome = registro.Nome,

                             DataNascimento = registro.DataNascimento,

                             Email = registro.Email,

                             Telefone = registro.Telefone,

                             Celular = registro.Celular,

                             CEP = registro.CEP,

                             Logradouro = registro.Logradouro,

                             Numero = registro.Numero,

                             Complemento = registro.Complemento,

                             Bairro = registro.Bairro,

                             Cidade = registro.Cidade,

                             UF = registro.UF,

                             PontoReferencia = registro.PontoReferencia,

                             IDAtendimento = registro.TAtendimento.IDAtendimento,

                             IDUsuarioAgendamento = registro.TUsuario.IDUsuario,

                             NomeUsuarioAgendamento = registro.TUsuario.Nome,

                             IDUsuarioVendedor = registro.TUsuario1.IDUsuario,

                             NomeUsuarioVendedor = registro.TUsuario1.Nome,

                         }).ToList();

            if (idsAtendimento.Count > 0)
                query = query.Where(registro => idsAtendimento.Contains(registro.IDAtendimento.GetValueOrDefault())).ToList();
            
            if (usuarioAtendente.Count > 0)
                query = query.Where(registro => usuarioAtendente.Contains(registro.IDUsuarioAgendamento)).ToList();

            if (usuarioVendedor.Count > 0)
                query = query.Where(registro => usuarioVendedor.Contains(registro.IDUsuarioVendedor.GetValueOrDefault())).ToList();

            return query.ToList();
        }

        #endregion
          
    }
}
