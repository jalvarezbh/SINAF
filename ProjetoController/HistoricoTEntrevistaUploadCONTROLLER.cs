using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;

namespace ProjetoController
{
    public class HistoricoTEntrevistaUploadCONTROLLER
    {
        #region [ BLL ]

        private HistoricoTEntrevistaUploadBLL _HistoricoTEntrevistaUploadBLL;

        public HistoricoTEntrevistaUploadBLL HistoricoTEntrevistaUploadBLL
        {
            get
            {
                if (_HistoricoTEntrevistaUploadBLL == null)
                    _HistoricoTEntrevistaUploadBLL = new HistoricoTEntrevistaUploadBLL();

                return _HistoricoTEntrevistaUploadBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ Salvar ]

        public Int32 Salvar(HistoricoTEntrevistaUploadVO entrevistaVO)
        {
            try
            {
                if (entrevistaVO.IDHistoricoEntrevistaUpload > 0)
                {
                    HistoricoTEntrevistaUploadBLL.Alterar(entrevistaVO);
                }
                else
                {
                    HistoricoTEntrevistaUploadBLL.Inserir(entrevistaVO);
                }

                return entrevistaVO.IDHistoricoEntrevistaUpload;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Salvar HistoricoTEntrevistaUpload.");
            }
        }

        #endregion

        #region [ Listar ]

        public List<HistoricoTEntrevistaUploadVO> Listar(HistoricoTEntrevistaUploadVO filtro)
        {
            try
            {
                if (filtro.IDHistoricoEntrevistaUpload > 0)
                {
                    List<HistoricoTEntrevistaUploadVO> listaRetorno = new List<HistoricoTEntrevistaUploadVO>();
                    listaRetorno.Add(HistoricoTEntrevistaUploadBLL.Obter(filtro.IDHistoricoEntrevistaUpload));
                    return listaRetorno;
                }
                else
                {
                    return HistoricoTEntrevistaUploadBLL.Listar(filtro).ToList();


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