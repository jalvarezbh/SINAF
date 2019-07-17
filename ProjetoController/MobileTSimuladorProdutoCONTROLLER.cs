using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;

namespace ProjetoController
{
    public class MobileTSimuladorProdutoCONTROLLER
    {
        #region [ BLL ]

        private MobileTSimuladorProdutoBLL _MobileTSimuladorProdutoBLL;

        public MobileTSimuladorProdutoBLL MobileTSimuladorProdutoBLL
        {
            get
            {
                if (_MobileTSimuladorProdutoBLL == null)
                    _MobileTSimuladorProdutoBLL = new MobileTSimuladorProdutoBLL();

                return _MobileTSimuladorProdutoBLL;

            }
        }
              
        #endregion

        #region [ Métodos ]
              
        #region [ ListarRelatorioVendedorColetor ]

        public List<MobileTSimuladorProdutoVO> ListarRelatorioHistoricoSimulador(MobileTSimuladorProdutoVO filtro)
        {
            try
            {
                List<MobileTSimuladorProdutoVO> listaHistorico = MobileTSimuladorProdutoBLL.ListarRelatorioHistoricoSimulador(filtro).ToList();

                return listaHistorico;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro Historico Simulador.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro Historico Simulador.");
            }
        }

        #endregion

        #endregion
    }
}
