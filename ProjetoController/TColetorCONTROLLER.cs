using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;

namespace ProjetoController
{
    public class TColetorCONTROLLER
    {
        #region [ BLL ]

        private TColetorBLL _TColetorBLL;

        public TColetorBLL TColetorBLL
        {
            get
            {
                if (_TColetorBLL == null)
                    _TColetorBLL = new TColetorBLL();

                return _TColetorBLL;

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

        private TFaixaBLL _TFaixaBLL;

        public TFaixaBLL TFaixaBLL
        {
            get
            {
                if (_TFaixaBLL == null)
                    _TFaixaBLL = new TFaixaBLL();

                return _TFaixaBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ Salvar ]

        public Int32 Salvar(TColetorVO tcoletorvo)
        {
            try
            {
                if (tcoletorvo.IDColetor > 0)
                {
                    TColetorBLL.Alterar(tcoletorvo);
                }
                else
                {
                    TColetorBLL.Inserir(tcoletorvo);
                }

                return tcoletorvo.IDColetor;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Salvar Coletor.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Coletor.");
            }
        }

        #endregion

        #region [ Listar ]

        public List<TColetorVO> Listar(TColetorVO filtro)
        {
            try
            {
                if (filtro.IDColetor > 0)
                {
                    List<TColetorVO> listaRetorno = new List<TColetorVO>();
                    listaRetorno.Add(TColetorBLL.Obter(filtro.IDColetor));
                    return listaRetorno;
                }
                else
                {
                    return TColetorBLL.Listar(filtro).ToList();

                   
                }
            }
            catch (CABTECException ex)
            {
                throw new CABTECException(ex.Message);
          //      throw new CABTECException("Erro ao Listar Coletor.");
            }
            catch (Exception ex)
            {
                throw new CABTECException(ex.Message);
                //throw new CABTECException("Erro ao Listar Coletor.");
            }
        }

        #endregion
            
        #region [ Excluir ]

        public void Excluir(int IDColetor)
        {
            try
            {
                TColetorBLL.Excluir(IDColetor);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Excluir Coletor.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Excluir Coletor.");
            }
        }

        #endregion

        #region [ ListarColetorLivre ]

        public List<TColetorVO> ListarColetorLivre(int idTitular , ref bool coletorVinculo)
        {
            try
            {
                List<TColetorVO> listaRetorno = TColetorBLL.ListarColetorLivre().ToList();

                coletorVinculo = false;

                if (idTitular > 0)
                {
                    TColetorVO coletor = TColetorBLL.ObterPorVendedor(idTitular);
                    if (coletor != null)
                    {
                        listaRetorno.Insert(0, coletor);
                        coletorVinculo = true;
                        TColetorVO coletorEmpyt = new TColetorVO();
                        coletorEmpyt.NumeroSerie = "Retirar Associação";
                        listaRetorno.Add(coletorEmpyt);
                    }
                    
                }

                return listaRetorno;

            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Coletor Livre.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Coletor Livre.");
            }
        }
        
        #endregion

        #region [ AssociarColetorVendedor ]

        public string AssociarColetorVendedor(string idColetorEscolhido, string idVendedorEscolhido)
        {
            try
            {
                string mensagem = string.Empty;

                //Dois IDs Nulos
                if (string.IsNullOrEmpty(idColetorEscolhido) && string.IsNullOrEmpty(idVendedorEscolhido))
                    mensagem = "Não foi realizado a associação.";
                              

                if (!string.IsNullOrEmpty(idColetorEscolhido))
                {
                    TColetorVO coletorEscolhido = TColetorBLL.Obter(Convert.ToInt32(idColetorEscolhido));

                    //Limpar Associação
                    if (string.IsNullOrEmpty(idVendedorEscolhido))
                    {
                        coletorEscolhido.IDUsuarioResponsavel = 0;
                        TColetorBLL.Alterar(coletorEscolhido);
                        mensagem = "O Coletor: " + coletorEscolhido.NumeroSerie + " não está mais associado a nenhum Vendedor!";
                    }
                    else
                    {
                       
                        //Associar Coletor
                        if (coletorEscolhido != null)
                        {
                            //Limpar Associação Antiga
                            TColetorVO vendedorAntigo = TColetorBLL.ObterPorVendedor(coletorEscolhido.IDUsuarioResponsavel.GetValueOrDefault(0));

                            if (vendedorAntigo != null)
                            {
                                TUsuarioVO usuarioAntigo = TUsuarioBLL.Obter(vendedorAntigo.IDUsuarioResponsavel.Value);
                                vendedorAntigo.IDUsuarioResponsavel = 0;
                                TColetorBLL.Alterar(vendedorAntigo);
                                mensagem = "O Vendedor: " + usuarioAntigo.Nome + " não está mais associado a nenhum Coletor!<br/>";
                            }

                            //Limpar Associação Antiga
                            TColetorVO coletorAntigo = TColetorBLL.ObterPorVendedor(Convert.ToInt32(idVendedorEscolhido));

                            if (coletorAntigo != null)
                            {
                                TUsuarioVO usuarioAntigo = TUsuarioBLL.Obter(coletorAntigo.IDUsuarioResponsavel.Value);
                                coletorAntigo.IDUsuarioResponsavel = 0;
                                TColetorBLL.Alterar(coletorAntigo);
                                mensagem = "O Coletor: " + coletorAntigo.NumeroSerie + " não está mais associado a nenhum Vendedor!<br/>";
                            }

                            coletorEscolhido.IDUsuarioResponsavel = Convert.ToInt32(idVendedorEscolhido);
                            TColetorBLL.Alterar(coletorEscolhido);

                            TUsuarioVO usuarioAtual = TUsuarioBLL.Obter(Convert.ToInt32(idVendedorEscolhido));

                            if (usuarioAtual != null)
                            {
                                mensagem += "O Coletor: " + coletorEscolhido.NumeroSerie + " e o Vendedor: " + usuarioAtual.Nome + " foram associados com sucesso!";
                            }                            
                        }
                        else
                        {
                            TUsuarioVO usuarioAtual = TUsuarioBLL.Obter(Convert.ToInt32(idVendedorEscolhido));

                            if (usuarioAtual != null)
                            {
                                TColetorVO coletorAntigo = TColetorBLL.ObterPorVendedor(Convert.ToInt32(idVendedorEscolhido));

                                if (coletorAntigo != null)
                                {
                                    coletorAntigo.IDUsuarioResponsavel = 0;
                                    TColetorBLL.Alterar(coletorAntigo);
                                }

                                mensagem = "O Vendedor: " + usuarioAtual.Nome + " não está mais associado a nenhum Coletor!";
                            }
                        }                        
                    }
                }
                else
                {
                    TColetorVO coletorAntigo = TColetorBLL.ObterPorVendedor(Convert.ToInt32(idVendedorEscolhido));

                    if (coletorAntigo != null)
                    {
                        coletorAntigo.IDUsuarioResponsavel = 0;
                        TColetorBLL.Alterar(coletorAntigo);
                        
                        TUsuarioVO usuarioAtual = TUsuarioBLL.Obter(Convert.ToInt32(idVendedorEscolhido));

                        if (usuarioAtual != null)
                        {
                            mensagem = "O Vendedor: " + usuarioAtual.Nome + " não está mais associado a nenhum Coletor!";
                        }
                    }
                }

                return mensagem;
                
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Associar Coletor e Vendedor.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Associar Coletor e Vendedor.");
            }
        }

        #endregion

        #region [ ListarRelatorio ]

        public List<TColetorVO> ListarRelatorio(TColetorVO filtro)
        {
            try
            {
                List<TColetorVO> listaColetor =  TColetorBLL.ListarRelatorio(filtro).ToList();

                foreach (TColetorVO coletor in listaColetor)
                {
                    int numerofaixa = TFaixaBLL.NumeroEntrevista(coletor.IDUsuarioVendedor.GetValueOrDefault());
                    int numerocarregado = TFaixaBLL.FaixaCarregada(coletor.IDUsuarioVendedor.GetValueOrDefault());

                    coletor.NumeroFaixaCarregadas = numerofaixa ;
                    coletor.TodasFaixaCarregadas = numerofaixa == numerocarregado; 
                }

                return listaColetor;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Coletor.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Coletor.");
            }
        }

        #endregion

        #region [ ListarRelatorioVendedorColetor ]

        public List<TColetorVO> ListarRelatorioVendedorColetor(TColetorVO filtro)
        {
            try
            {
                List<TColetorVO> listaColetor = TColetorBLL.ListarRelatorioVendedorColetor(filtro).ToList();
                               
                return listaColetor;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Coletor.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Coletor.");
            }
        }

        #endregion

        #endregion

    }
}

