using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;

namespace ProjetoController
{
    public class TMenuCONTROLLER
    {
        #region [ BLL ]

        private TMenuBLL _TMenuBLL;

        public TMenuBLL TMenuBLL
        {
            get
            {
                if (_TMenuBLL == null)
                    _TMenuBLL = new TMenuBLL();

                return _TMenuBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ Salvar ]

        public void Salvar(TMenuVO tmenuvo)
        {
            try
            {
                if (tmenuvo.IDMenu > 0)
                {
                    TMenuBLL.Alterar(tmenuvo);
                }
                else
                {
                    TMenuBLL.Inserir(tmenuvo);
                }
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Salvar Menu.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Menu.");
            }
        }

        #endregion

        #region [ Listar ]

        public List<TMenuVO> Listar(TMenuVO filtro)
        {
            try
            {
                if (filtro.IDMenu > 0)
                {
                    List<TMenuVO> listaRetorno = new List<TMenuVO>();
                    listaRetorno.Add(TMenuBLL.Obter(filtro.IDMenu));
                    return listaRetorno;
                }
                else
                {
                    return TMenuBLL.Listar(filtro).ToList();


                }
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Menu.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Menu.");
            }
        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDMenu)
        {
            try
            {
                TMenuBLL.Excluir(IDMenu);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Excluir Menu.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Excluir Menu.");
            }
        }

        #endregion

        #region [ ListarMenuUsuarioXML ]

        public string ListarMenuUsuarioXML(int codigoUsuario, bool indicadorMobile)
        {
            try
            {
                return TMenuBLL.ListarMenuUsuarioXML(codigoUsuario, indicadorMobile);

            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Menu/Usuario.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Menu/Usuario.");
            }
        }

        #endregion

        #endregion
    }
}

