using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;

namespace ProjetoController
{
    public class TMenuPerfilCONTROLLER
    {
        #region [ BLL ]

        private TMenuPerfilBLL _TMenuPerfilBLL;

        public TMenuPerfilBLL TMenuPerfilBLL
        {
            get
            {
                if (_TMenuPerfilBLL == null)
                    _TMenuPerfilBLL = new TMenuPerfilBLL();

                return _TMenuPerfilBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ Salvar ]

        public void Salvar(TMenuPerfilVO tmenuperfilvo)
        {
            try
            {
                if (tmenuperfilvo.IDMenuPerfil > 0)
                {
                    TMenuPerfilBLL.Alterar(tmenuperfilvo);
                }
                else
                {
                    TMenuPerfilBLL.Inserir(tmenuperfilvo);
                }
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Salvar Menu/Perfil.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Menu/Perfil.");
            }
        }

        #endregion

        #region [ Listar ]

        public List<TMenuPerfilVO> Listar(TMenuPerfilVO filtro)
        {
            try
            {
                if (filtro.IDMenuPerfil > 0)
                {
                    List<TMenuPerfilVO> listaRetorno = new List<TMenuPerfilVO>();
                    listaRetorno.Add(TMenuPerfilBLL.Obter(filtro.IDMenuPerfil));
                    return listaRetorno;
                }
                else
                {
                    return TMenuPerfilBLL.Listar(filtro).ToList();

                   
                }
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Menu/Perfil.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Menu/Perfil.");
            }
        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDMenuPerfil)
        {
            try
            {
                TMenuPerfilBLL.Excluir(IDMenuPerfil);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Excluir Menu/Perfil.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Excluir Menu/Perfil.");
            }
        }

        #endregion
         
        #endregion
    }
}

