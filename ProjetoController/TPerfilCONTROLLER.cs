using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;

namespace ProjetoController
{
    public class TPerfilCONTROLLER
    {
        #region [ BLL ]

        private TPerfilBLL _TPerfilBLL;

        public TPerfilBLL TPerfilBLL
        {
            get
            {
                if (_TPerfilBLL == null)
                    _TPerfilBLL = new TPerfilBLL();

                return _TPerfilBLL;

            }
        }

        private TUsuarioBLL _TUsuarioBLL;

        public TUsuarioBLL TUsuarioBLL
        {
            get
            {
                if (_TUsuarioBLL == null)
                    _TUsuarioBLL = new TUsuarioBLL();

                return _TUsuarioBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ Salvar ]

        public void Salvar(TPerfilVO tperfilvo)
        {
            try
            {
                if (tperfilvo.IDPerfil > 0)
                {
                    TPerfilBLL.Alterar(tperfilvo);
                }
                else
                {
                    TPerfilBLL.Inserir(tperfilvo);
                }
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Salvar Perfil.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Perfil.");
            }
        }

        #endregion

        #region [ Listar ]

        public List<TPerfilVO> Listar(TPerfilVO filtro)
        {
            try
            {
                if (filtro.IDPerfil > 0)
                {
                    List<TPerfilVO> listaRetorno = new List<TPerfilVO>();
                    listaRetorno.Add(TPerfilBLL.Obter(filtro.IDPerfil));
                    return listaRetorno;
                }
                else
                {
                    return TPerfilBLL.Listar(filtro).ToList();


                }
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Perfil.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Perfil.");
            }
        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDPerfil)
        {
            try
            {
                TPerfilBLL.Excluir(IDPerfil);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Excluir Perfil.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Excluir Perfil.");
            }
        }

        #endregion

        #region [ ListarPerfilCargo ]

        public List<TPerfilVO> ListarPerfilCargo(TPerfilVO filtro)
        {
            try
            {
                if (filtro.IDPerfilCargo > 0)
                {
                    List<TPerfilVO> listaRetorno = new List<TPerfilVO>();
                    listaRetorno.Add(TPerfilBLL.ObterPerfilCargo(filtro.IDPerfilCargo));
                    return listaRetorno;
                }
                else
                {
                    return TPerfilBLL.ListarPerfilCargo(filtro).ToList();


                }
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Perfil - Cargo.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Perfil - Cargo.");
            }
        }

        #endregion

        #region [ ValidarPerfilCargo ]

        public List<TPerfilVO> ValidarPerfilCargo(TPerfilVO filtro)
        {
            try
            {
                return TPerfilBLL.ValidarPerfilCargo(filtro).ToList();

            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Validar Perfil - Cargo.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Validar Perfil - Cargo.");
            }
        }

        #endregion

        #region [ SalvarPerfilCargo ]

        public void SalvarPerfilCargo(TPerfilVO tperfilvo)
        {
            try
            {
                if (ValidarPerfilCargo(tperfilvo).Count > 0)
                    throw new CABTECException("Este Cargo já esta relacionado a um Perfil.");

                if (tperfilvo.IDPerfilCargo > 0)
                {
                    TPerfilBLL.AlterarPerfilCargo(tperfilvo);
                }
                else
                {
                    TPerfilBLL.InserirPerfilCargo(tperfilvo);
                }

                TUsuarioBLL.AlterarPerfilCargo(tperfilvo.NomeCargo, tperfilvo.IDPerfil);
            }
            catch (CABTECException ex)
            {
                throw new CABTECException(ex.Message);
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Perfil - Cargo.");
            }
        }

        #endregion

        #region [ ExcluirPerfilCargo ]

        public void ExcluirPerfilCargo(int IDPerfilCargo)
        {
            try
            {
                TPerfilBLL.ExcluirPerfilCargo(IDPerfilCargo);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Excluir Perfil.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Excluir Perfil.");
            }
        }

        #endregion

        #endregion
    }
}

