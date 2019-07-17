using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using ProjetoVO;
using ProjetoDAL;
using WebControls;
using System.Web.Configuration;

namespace ProjetoController
{
    public class TUsuarioCONTROLLER
    {
        #region [ BLL ]

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

        private TLogBLL _TLogBLL;

        public TLogBLL TLogBLL
        {
            get
            {
                if (_TLogBLL == null)
                    _TLogBLL = new TLogBLL();

                return _TLogBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ Salvar ]

        public void Salvar(TUsuarioVO tusuariovo, Int32 usuarioLogado)
        {
            try
            {
                TLogVO log = new TLogVO();
                log.Tabela = "TUsuario";
                log.IDUsuario = usuarioLogado;
                log.Data = DateTime.Now;

                if (tusuariovo.IDUsuario > 0)
                {
                    log.Tipo = "Alterar - " + tusuariovo.Login +"-"+ tusuariovo.Senha;
                    TUsuarioBLL.Alterar(tusuariovo);
                }
                else
                {
                    log.Tipo = "Inserir - " + tusuariovo.Login;
                    TUsuarioBLL.Inserir(tusuariovo);
                }

                TLogBLL.Inserir(log);
            }
            catch (CABTECException)
            {

                throw new CABTECException("Erro ao Salvar Usuário.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Salvar Usuário.");
            }
        }

        #endregion

        #region [ Listar ]

        public List<TUsuarioVO> Listar(TUsuarioVO filtro)
        {
            try
            {
                if (filtro.IDUsuario > 0)
                {
                    List<TUsuarioVO> listaRetorno = new List<TUsuarioVO>();
                    listaRetorno.Add(TUsuarioBLL.Obter(filtro.IDUsuario));
                    return listaRetorno;
                }
                else
                {
                    return TUsuarioBLL.Listar(filtro).ToList();


                }
            }
            catch (CABTECException)
            {

                throw new CABTECException("Erro ao Listar Usuário.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Usuário.");
            }
        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDUsuario)
        {
            try
            {
                TUsuarioBLL.Excluir(IDUsuario);
            }
            catch (CABTECException)
            {

                throw new CABTECException("Erro ao Excluir Usuário.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Excluir Usuário.");
            }
        }

        #endregion

        #region [ ValidarAcesso ]

        public TUsuarioVO ValidarAcesso(string login, string senha)
        {
            try
            {
                TUsuarioVO usuarioLogado = TUsuarioBLL.LoginPrimeiroAcesso(login);

                if (usuarioLogado == null)
                {
                    string password = Criptografia.EncryptSymmetric("DESCryptoServiceProvider", senha);
                    usuarioLogado = TUsuarioBLL.LoginSistema(login, password);

                    if (usuarioLogado == null)
                        throw new CABTECException("Login ou Senha inválido!");
                }

                return usuarioLogado;
            }
            catch (CABTECException)
            {
                throw new CABTECException("Login ou Senha inválido!");
            }
            catch (Exception ex)
            {
                throw new CABTECException("Login ou Senha inválido!");
            }
        }

        #endregion

        #region [ ValidarMudarSenha ]

        public void ValidarMudarSenha(TUsuarioVO usuarioLogado, string novaSenha, string confirmaSenha)
        {
            try
            {
                if (!novaSenha.Equals(confirmaSenha))
                    throw new CABTECException("A Nova Senha informada não confere!");

                if (usuarioLogado == null)
                    throw new CABTECException("O Usuário não foi informado!");

                usuarioLogado.Senha = Criptografia.EncryptSymmetric("DESCryptoServiceProvider", novaSenha);

                TUsuarioBLL.Alterar(usuarioLogado);

            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Alterar Senha.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Alterar Senha.");
            }
        }

        #endregion

        #region [ EnvioSenha ]

        public void EnvioSenha(string login)
        {
            try
            {
                if(string.IsNullOrEmpty(login))
                    throw new CABTECException("Informe o Login.");

                TUsuarioVO usuario = new TUsuarioVO();

                usuario.Login = login;
                
                List<TUsuarioVO> usuarioLogin = TUsuarioBLL.Listar(usuario).ToList();

                if(usuarioLogin.Count != 1)
                    throw new CABTECException("Login inválido!");

                string path = HttpContext.Current.Server.MapPath("Template\\EmailEsqueceuSenha.htm");

                Random number = new Random();

                int novaSenha = number.Next(10000000, 99999999);

                string password = Criptografia.EncryptSymmetric("DESCryptoServiceProvider", novaSenha.ToString());

                usuarioLogin[0].Senha = password;

                TUsuarioBLL.Alterar(usuarioLogin[0]);

                string html;

                using (var arquivoHtml = new StreamReader(path))
                {
                    html = arquivoHtml.ReadToEnd();
                    html = html.Replace("[LOGO]", WebConfigurationManager.AppSettings["DiretorioIMAGEM"] + @"LogoCliente.png");
                    html = html.Replace("[RODAPE]", WebConfigurationManager.AppSettings["DiretorioIMAGEM"] + @"sinafemail.png");
                    html = html.Replace("[SENHA]", novaSenha.ToString());
                }

                var de = WebConfigurationManager.AppSettings["EmailPADRAO"];

                List<string> emails = new List<string>();
                emails.Add(usuarioLogin[0].Email);
                                
                EnviarEmail.Enviar(de, emails, "SINAF - Nova Senha", html, new List<string>());
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Enviar Senha.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Enviar Senha.");
            }
        }

        #endregion

        #region [ AlterarSenha ]

        public void AlterarSenha(TUsuarioVO usuarioLogado, string senhaAtual, string senhaNova, string senhaConfirma)
        {
            try
            {
                if (usuarioLogado == null)
                    throw new CABTECException("Usuário inválido!");

                if (!usuarioLogado.Senha.Equals( Criptografia.EncryptSymmetric("DESCryptoServiceProvider", senhaAtual)))
                    throw new CABTECException("Senha Atual inválida!");

                if (!senhaNova.Equals(senhaConfirma))
                    throw new CABTECException("A Nova Senha informada não confere!");

                usuarioLogado.Senha = Criptografia.EncryptSymmetric("DESCryptoServiceProvider", senhaNova);

                TUsuarioBLL.Alterar(usuarioLogado);

                TLogVO log = new TLogVO();
                log.Tabela = "TUsuario";
                log.IDUsuario = usuarioLogado.IDUsuario;
                log.Data = DateTime.Now;
                log.Tipo = "Alterar - " + usuarioLogado.Login + " - " + senhaAtual + " - " + senhaNova;
                TLogBLL.Inserir(log);
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Alterar Senha.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Alterar Senha.");
            }
        }

        #endregion

        #region [ ListarVendedorLivre ]

        public List<TUsuarioVO> ListarVendedorLivre(TUsuarioVO filtro, int idTitular)
        {
            try
            {
                List<TUsuarioVO> listaRetorno = TUsuarioBLL.VendedorLivre(filtro).ToList();
                
                if (idTitular > 0)
                {
                    TUsuarioVO usuario = TUsuarioBLL.ObterCodigo(idTitular);
                    if(usuario != null)
                        listaRetorno.Insert(0,usuario );

                    TUsuarioVO usuarioEmpyt = new TUsuarioVO();
                    usuarioEmpyt.Nome = "Retirar Associação";
                    listaRetorno.Add(usuarioEmpyt);
                }

                return listaRetorno;
                
            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Vendedor Livre.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Vendedor Livre.");
            }
        }

        #endregion

        #region [ ListarSemAtendente ]

        public List<TUsuarioVO> ListarSemAtendente(TUsuarioVO filtro)
        {
            try
            {
                List<TUsuarioVO> listaRetorno = TUsuarioBLL.ListarSemAtendimento(filtro).ToList();
                                
                return listaRetorno;

            }
            catch (CABTECException)
            {
                throw new CABTECException("Erro ao Listar Vendedor Livre.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Listar Vendedor Livre.");
            }
        }

        #endregion

        #endregion
    }
}

