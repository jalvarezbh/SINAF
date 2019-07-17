using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;

namespace ProjetoController
{
    public class TEstadoCONTROLLER
    {
        #region [ BLL ]

        private TEstadoBLL _TEstadoBLL;

        public TEstadoBLL TEstadoBLL
        {
            get
            {
                if (_TEstadoBLL == null)
                    _TEstadoBLL = new TEstadoBLL();

                return _TEstadoBLL;

            }
        }

        #endregion

        #region [ Métodos ]
           
        #region [ Listar ]

        public List<TEstadoVO> Listar()
        {
            try
            {
                List<TEstadoVO> listEstado = TEstadoBLL.Listar().ToList();
                TEstadoVO vazio = new TEstadoVO();
                vazio.IDEstado = 0;
                vazio.Sigla= string.Empty;
                listEstado.Insert(0, vazio);

                return listEstado;
               
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Estado.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Estado.");
            }
        }

        #endregion
                
        #endregion
    }
}
