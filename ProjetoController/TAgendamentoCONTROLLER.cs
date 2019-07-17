using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;
using System.Web.Configuration;

namespace ProjetoController
{
    public class TAgendamentoCONTROLLER
    {
        #region [ BLL ]

        private TAgendamentoBLL _TAgendamentoBLL;

        public TAgendamentoBLL TAgendamentoBLL
        {
            get
            {
                if (_TAgendamentoBLL == null)
                    _TAgendamentoBLL = new TAgendamentoBLL();

                return _TAgendamentoBLL;

            }
        }

        private TAtendimentoBLL _TAtendimentoBLL;

        public TAtendimentoBLL TAtendimentoBLL
        {
            get
            {
                if (_TAtendimentoBLL == null)
                    _TAtendimentoBLL = new TAtendimentoBLL();

                return _TAtendimentoBLL;

            }
        }

        private TBairroBLL _TBairroBLL;

        public TBairroBLL TBairroBLL
        {
            get
            {
                if (_TBairroBLL == null)
                    _TBairroBLL = new TBairroBLL();

                return _TBairroBLL;

            }
        }
        
        private TCidadeBLL _TCidadeBLL;

        public TCidadeBLL TCidadeBLL
        {
            get
            {
                if (_TCidadeBLL == null)
                    _TCidadeBLL = new TCidadeBLL();

                return _TCidadeBLL;

            }
        }
              
        private TFilialBLL _TFilialBLL;

        public TFilialBLL TFilialBLL
        {
            get
            {
                if (_TFilialBLL == null)
                    _TFilialBLL = new TFilialBLL();

                return _TFilialBLL;

            }
        }
              
        private TUsuarioBLL _TUsuarioBLL;

        public TUsuarioBLL TUsuarioBLL
        {
            get
            {
                if (_TUsuarioBLL == null)
                    _TUsuarioBLL = new TUsuarioBLL();

                return _TUsuarioBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ Salvar ]

        public Int32 Salvar(TAgendamentoVO tagendamentovo)
        {
            try
            {
                if (tagendamentovo.IDUsuarioVendedor == null && (tagendamentovo.IDAtendimento == 0 || tagendamentovo.IDAtendimento == null))
                    return SalvarCallCenter(tagendamentovo);

                if (tagendamentovo.IDUsuarioVendedor != null && (tagendamentovo.IDAtendimento == 0 || tagendamentovo.IDAtendimento == null))
                    return SalvarVendedor(tagendamentovo);

                if (tagendamentovo.IDAtendimento > 0)
                    return SalvarAdministrador(tagendamentovo);

                return 0;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Salvar Agendamento.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Agendamento.");
            }
        }

        #endregion

        #region [ Listar ]

        public List<TAgendamentoVO> Listar(TAgendamentoVO filtro)
        {
            try
            {
                if (filtro.IDAgendamento > 0)
                {
                    List<TAgendamentoVO> listaRetorno = new List<TAgendamentoVO>();
                    TAgendamentoVO retornoVO = TAgendamentoBLL.Obter(filtro.IDAgendamento);

                    if(retornoVO.IDUsuarioAgendamento>0)
                        retornoVO.NomeUsuarioAgendamento = TUsuarioBLL.Obter(retornoVO.IDUsuarioAgendamento).Nome;

                    if (retornoVO.IDUsuarioVendedor.HasValue)
                        if(retornoVO.IDUsuarioVendedor.Value > 0)
                            retornoVO.NomeUsuarioVendedor = TUsuarioBLL.Obter(retornoVO.IDUsuarioVendedor.Value).Nome;


                    listaRetorno.Add(retornoVO);
                    return listaRetorno;
                }
                else
                {
                    List<int> usuarioAtendente = new List<int>();

                    List<int> usuarioVendedor = new List<int>();

                    List<int> usuarioUnidade = new List<int>();

                    if (!string.IsNullOrEmpty(filtro.NomeUsuarioAgendamento))
                    {
                        usuarioAtendente = TUsuarioBLL.ListarUsuarioAgendamento(filtro.NomeUsuarioAgendamento).ToList();
                        if (usuarioAtendente.Count == 0)
                            usuarioAtendente.Add(0);
                    }

                    if (!string.IsNullOrEmpty(filtro.NomeUsuarioVendedor))
                    {
                        usuarioVendedor = TUsuarioBLL.ListarUsuarioAgendamento(filtro.NomeUsuarioVendedor).ToList();
                        if (usuarioVendedor.Count == 0)
                            usuarioVendedor.Add(0);
                    }

                    if (!string.IsNullOrEmpty(filtro.Unidade))
                    {
                        usuarioUnidade = TAtendimentoBLL.ListarAtendimentoFilial(filtro.Unidade);
                        if (usuarioUnidade.Count == 0)
                            usuarioUnidade.Add(0);
                    }

                    return TAgendamentoBLL.ListarGridConsulta(usuarioUnidade,usuarioAtendente,usuarioVendedor).ToList();
                }
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Agendamento.");
            }
            catch (Exception ex)
            {
                throw new CABTECException("Erro ao Listar Agendamento."+ex.Message);
            }
        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDAgendamento)
        {
            try
            {
                TAgendamentoBLL.Excluir(IDAgendamento);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Excluir Agendamento.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Excluir Coletor.");
            }
        }

        #endregion

        #region [ SalvarCallCenter ]

        public Int32 SalvarCallCenter(TAgendamentoVO tagendamentovo)
        {
            try
            {
                int IDBairro = 0;
                int IDCidade = 0;
                int IDAtendimento = 0;

                tagendamentovo.IDUsuarioVendedor = null;
                                
                IDBairro = TBairroBLL.ObterIDBairro(tagendamentovo.Bairro);
                IDCidade = TCidadeBLL.ObterIDCidade(tagendamentovo.Cidade);
                IDAtendimento = TAtendimentoBLL.ObterAtendimentoCallCenter(IDCidade, IDBairro);
                
                if(IDAtendimento == 0)
                    IDAtendimento = TAtendimentoBLL.ObterAtendimentoFilial(TFilialBLL.ObterIDFilial(WebConfigurationManager.AppSettings["WebMATRIZ"]));

                tagendamentovo.IDAtendimento = IDAtendimento;

                if (tagendamentovo.IDAgendamento > 0)
                {
                    TAgendamentoBLL.Alterar(tagendamentovo);
                }
                else
                {
                    TAgendamentoBLL.Inserir(tagendamentovo);
                }

                return tagendamentovo.IDAgendamento;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Salvar Agendamento.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Agendamento.");
            }
        }

        #endregion

        #region [ SalvarVendedor ]

        public Int32 SalvarVendedor(TAgendamentoVO tagendamentovo)
        {
            try
            { 
                int IDBairro = 0;
                int IDCidade = 0;
                int IDFilial = 0;
                int IDAtendimento = 0;

                TUsuarioVO vendedor = new TUsuarioVO();
                vendedor = TUsuarioBLL.Obter(tagendamentovo.IDUsuarioVendedor.Value);
                                
                IDBairro = TBairroBLL.ObterIDBairro(tagendamentovo.Bairro);
                IDCidade = TCidadeBLL.ObterIDCidade(tagendamentovo.Cidade);
                IDFilial = TFilialBLL.ObterIDFilial(vendedor.Unidade);
                IDAtendimento = TAtendimentoBLL.ObterAtendimento(IDFilial, IDCidade, IDBairro);

                if (IDAtendimento == 0)
                    IDAtendimento = TAtendimentoBLL.ObterAtendimentoFilial(IDFilial);

                if (tagendamentovo.IDAgendamento > 0)
                {
                    TAgendamentoBLL.Alterar(tagendamentovo);
                }
                else
                {
                    TAgendamentoBLL.Inserir(tagendamentovo);
                }

                return tagendamentovo.IDAgendamento;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Salvar Agendamento.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Agendamento.");
            }
        }

        #endregion

        #region [ SalvarAdministrador ]

        public Int32 SalvarAdministrador(TAgendamentoVO tagendamentovo)
        {
            try
            {
                if (tagendamentovo.IDAgendamento > 0)
                {
                    TAgendamentoBLL.Alterar(tagendamentovo);
                }
                else
                {
                    TAgendamentoBLL.Inserir(tagendamentovo);
                }

                return tagendamentovo.IDAgendamento;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Salvar Agendamento.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Agendamento.");
            }
        }

        #endregion

        #region [ SalvarConsultaVendedor ]

        public void SalvarConsultaVendedor(List<int> idsAgendamentos, List<int> idsVendedores)
        {
            try
            {
                for (int i = 0; i < idsAgendamentos.Count; i++)
			    {
			        TAgendamentoVO agendamentoVO = new TAgendamentoVO();
                    agendamentoVO = TAgendamentoBLL.Obter(idsAgendamentos[i]);
                    agendamentoVO.IDUsuarioVendedor = idsVendedores[i];
                    TAgendamentoBLL.Alterar(agendamentoVO);
			    }                
               
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Salvar Agendamento/Vendedor.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Agendamento/Vendedor.");
            }
        }

        #endregion

        #endregion
    }
}
