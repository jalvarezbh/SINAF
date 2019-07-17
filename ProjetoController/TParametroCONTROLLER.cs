using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;

namespace ProjetoController
{
    public class TParametroCONTROLLER
    {
        #region [ BLL ]

        private TParametroBLL _TParametroBLL;

        public TParametroBLL TParametroBLL
        {
            get
            {
                if (_TParametroBLL == null)
                    _TParametroBLL = new TParametroBLL();

                return _TParametroBLL;

            }
        }

        private TLogBLL _TLogBLL;

        public TLogBLL TLogBLL
        {
            get
            {
                if (_TLogBLL == null)
                    _TLogBLL = new TLogBLL();

                return _TLogBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ Salvar ]

        public void Salvar(TParametroVO tparametrovo, Int32 usuarioLogado)
        {
            try
            {
                TLogVO log = new TLogVO();
                log.Tabela = "TParametro";
                log.IDUsuario = usuarioLogado;
                log.Data = DateTime.Now;

                if (tparametrovo.IDParametro > 0)
                {
                    log.Tipo = "Alterar - " + tparametrovo.TempoEntrevistaColetor + "-" + tparametrovo.VersaoBaseCorreio;
                    TParametroBLL.Alterar(tparametrovo);
                }
                else
                {
                    log.Tipo = "Inserir" ;
                    TParametroBLL.Inserir(tparametrovo);
                }

                TLogBLL.Inserir(log);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Salvar Parâmetro.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Parâmetro.");
            }
        }

        #endregion

        #region [ Listar ]

        public List<TParametroVO> Listar(TParametroVO filtro)
        {
            try
            {
                if (filtro.IDParametro > 0)
                {
                    List<TParametroVO> listaRetorno = new List<TParametroVO>();
                    listaRetorno.Add(TParametroBLL.Obter(filtro.IDParametro));
                    return listaRetorno;
                }
                else
                {
                    return TParametroBLL.Listar(filtro).ToList();

                   
                }
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Parâmetro.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Parâmetro.");
            }
        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDParametros)
        {
            try
            {
                TParametroBLL.Excluir(IDParametros);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Excluir Parâmetro.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Excluir Parâmetro.");
            }
        }

        #endregion
         
        #endregion
    }
}

