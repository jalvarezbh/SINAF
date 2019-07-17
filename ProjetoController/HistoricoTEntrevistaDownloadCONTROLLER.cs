using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;

namespace ProjetoController
{
    public class HistoricoTEntrevistaDownloadCONTROLLER
    {
        #region [ BLL ]

        private HistoricoTEntrevistaDownloadBLL _HistoricoTEntrevistaDownloadBLL;

        public HistoricoTEntrevistaDownloadBLL HistoricoTEntrevistaDownloadBLL
        {
            get
            {
                if (_HistoricoTEntrevistaDownloadBLL == null)
                    _HistoricoTEntrevistaDownloadBLL = new HistoricoTEntrevistaDownloadBLL();

                return _HistoricoTEntrevistaDownloadBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ Salvar ]

        public Int32 Salvar(HistoricoTEntrevistaDownloadVO entrevistaVO)
        {
            try
            {
                if (entrevistaVO.IDHistoricoEntrevistaDownload > 0)
                {
                    HistoricoTEntrevistaDownloadBLL.Alterar(entrevistaVO);
                }
                else
                {
                    HistoricoTEntrevistaDownloadBLL.Inserir(entrevistaVO);
                }

                return entrevistaVO.IDHistoricoEntrevistaDownload;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Salvar HistoricoTEntrevistaDownload.");
            }
        }

        #endregion

        #region [ Listar ]

        public List<HistoricoTEntrevistaDownloadVO> Listar(HistoricoTEntrevistaDownloadVO filtro)
        {
            try
            {
                if (filtro.IDHistoricoEntrevistaDownload > 0)
                {
                    List<HistoricoTEntrevistaDownloadVO> listaRetorno = new List<HistoricoTEntrevistaDownloadVO>();
                    listaRetorno.Add(HistoricoTEntrevistaDownloadBLL.Obter(filtro.IDHistoricoEntrevistaDownload));
                    return listaRetorno;
                }
                else
                {
                    return HistoricoTEntrevistaDownloadBLL.Listar(filtro).ToList();


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