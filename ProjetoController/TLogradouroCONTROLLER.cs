using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;

namespace ProjetoController
{
    public class TLogradouroCONTROLLER
    {
        #region [ BLL ]

        private TLogradouroBLL _TLogradouroBLL;

        public TLogradouroBLL TLogradouroBLL
        {
            get
            {
                if (_TLogradouroBLL == null)
                    _TLogradouroBLL = new TLogradouroBLL();

                return _TLogradouroBLL;

            }
        }

        #endregion

        #region [ Métodos ]
           
        #region [ Listar ]

        public TLogradouroVO ListarPorCEP(int cep)
        {
            try
            {
                return TLogradouroBLL.ListarPorCEP(cep).FirstOrDefault();
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Buscar pelo CEP.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Buscar pelo CEP.");
            }
        }

        #endregion
          
        #endregion

    }
}
