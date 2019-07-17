using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;

namespace ProjetoController
{
    public class HistoricoTSincronismoCONTROLLER
    {
        #region [ BLL ]

        private HistoricoTSincronismoBLL _HistoricoTSincronismoBLL;

        public HistoricoTSincronismoBLL HistoricoTSincronismoBLL
        {
            get
            {
                if (_HistoricoTSincronismoBLL == null)
                    _HistoricoTSincronismoBLL = new HistoricoTSincronismoBLL();

                return _HistoricoTSincronismoBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ Salvar ]

        public Int32 Salvar(HistoricoTSincronismoVO sincronismoVO)
        {
            try
            {
                if (sincronismoVO.IDHistoricoSincronismo > 0)
                {
                    HistoricoTSincronismoBLL.Alterar(sincronismoVO);
                }
                else
                {
                    HistoricoTSincronismoBLL.Inserir(sincronismoVO);
                }

                return sincronismoVO.IDHistoricoSincronismo;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Salvar HistoricoTSincronismo.");
            }
        }

        #endregion
        
        #region [ Listar ]

        public List<HistoricoTSincronismoVO> Listar(HistoricoTSincronismoVO filtro)
        {
            try
            {
                if (filtro.IDHistoricoSincronismo > 0)
                {
                    List<HistoricoTSincronismoVO> listaRetorno = new List<HistoricoTSincronismoVO>();
                    listaRetorno.Add(HistoricoTSincronismoBLL.Obter(filtro.IDHistoricoSincronismo));
                    return listaRetorno;
                }
                else
                {
                    return HistoricoTSincronismoBLL.Listar(filtro).OrderByDescending(registro => registro.DataSincronismo).ToList();


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //throw new CABTECException("Erro ao Listar Coletor.");
            }
        }

        #endregion

        #endregion
    }
}