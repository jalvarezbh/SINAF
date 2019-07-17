using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;

namespace ProjetoController
{
    public class HistoricoTColetorCONTROLLER
    {
        #region [ BLL ]

        private HistoricoTColetorBLL _HistoricoTColetorBLL;

        public HistoricoTColetorBLL HistoricoTColetorBLL
        {
            get
            {
                if (_HistoricoTColetorBLL == null)
                    _HistoricoTColetorBLL = new HistoricoTColetorBLL();

                return _HistoricoTColetorBLL;

            }
        }       

        #endregion

        #region [ Métodos ]

        #region [ VerificaInserirInicial ]

        public HistoricoTColetorVO VerificaInserirInicial(string numeroColetor)
        {
            try
            {
                HistoricoTColetorVO historico = HistoricoTColetorBLL.ObterPorNumero(numeroColetor);

                if (historico == null || historico.IDHistoricoColetor <= 0)
                {
                    historico = new HistoricoTColetorVO();
                    historico.NumeroColetor = numeroColetor;
                    HistoricoTColetorBLL.Inserir(historico);
                }

                return historico;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region [ Listar ]

        public List<HistoricoTColetorVO> Listar(HistoricoTColetorVO filtro)
        {
            try
            {
                if (filtro.IDHistoricoColetor > 0)
                {
                    List<HistoricoTColetorVO> listaRetorno = new List<HistoricoTColetorVO>();
                    listaRetorno.Add(HistoricoTColetorBLL.Obter(filtro.IDHistoricoColetor));
                    return listaRetorno;
                }
                else
                {
                    return HistoricoTColetorBLL.Listar(filtro).ToList();


                }
            }            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //throw new CABTECException("Erro ao Listar Coletor.");
            }
        }

        #endregion

        #region [ ListarRelatorio ]

        public List<HistoricoTColetorVO> ListarRelatorio(HistoricoTColetorVO filtro)
        {
            try
            {
                return HistoricoTColetorBLL.ListarRelatorio(filtro).ToList().Distinct(new ColetorDistinct()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //throw new CABTECException("Erro ao Listar Coletor.");
            }
        }

        public class ColetorDistinct : IEqualityComparer<HistoricoTColetorVO>
        {
            public bool Equals(HistoricoTColetorVO x, HistoricoTColetorVO y)
            {
                if (x.IDHistoricoColetor == y.IDHistoricoColetor)
                    return true;
                else
                    return false;
            }

            public int GetHashCode(HistoricoTColetorVO obj)
            {
                return obj.IDHistoricoColetor.GetHashCode();
            }
        }        

        #endregion

        #endregion
    }
}