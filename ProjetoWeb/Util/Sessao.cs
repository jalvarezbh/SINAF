using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoVO;

namespace ProjetoWeb.Util
{
    public class Sessao
    {
        #region [PROPRIEDADES]

        public static TServicoColetorVO ServicoColetorVO
        {
            get
            {
                return HttpContext.Current.Session["ServicoColetor"] == null
                    ? new TServicoColetorVO() : (TServicoColetorVO)(HttpContext.Current.Session["ServicoColetor"]);
            }

            set { HttpContext.Current.Session["ServicoColetor"] = value; }
        }
               
        public static string NomePaginaRetorno
        {
            get { return HttpContext.Current.Session["NomePaginaRetorno"] == null ? "~/default.aspx" : HttpContext.Current.Session["NomePaginaRetorno"].ToString(); }
            set { HttpContext.Current.Session["NomePaginaRetorno"] = value; }
        }

        public static Util.Cargo TipoUsuario
        {
            get { return Util.Cargo.ADMINISTRADOR;}// (Util.Cargo)(HttpContext.Current.Session["TipoUsuario"]); }
            set { HttpContext.Current.Session["TipoUsuario"] = value; }
        }

        public static TUsuarioVO UsuarioLogado
        {
            get {
                if ((TUsuarioVO)(HttpContext.Current.Session["UsuarioLogado"]) == null)
                    return new TUsuarioVO();
                else
                    return (TUsuarioVO)(HttpContext.Current.Session["UsuarioLogado"]);
            }
            set {
                TUsuarioVO usuario = (TUsuarioVO)value;
                if (usuario != null)
                {
                    switch (usuario.IDPerfil )
                    {
                        case (Int32)Util.Cargo.ADMINISTRADOR:
                            TipoUsuario = Util.Cargo.ADMINISTRADOR;
                            break;
                        case (Int32)Util.Cargo.GERENTE:
                            TipoUsuario = Util.Cargo.GERENTE;
                            break;
                        case (Int32)Util.Cargo.COORDENADOR:
                            TipoUsuario = Util.Cargo.COORDENADOR;
                            break;
                        case (Int32)Util.Cargo.VENDEDOR:
                            TipoUsuario = Util.Cargo.VENDEDOR;
                            break;
                        case (Int32)Util.Cargo.CALLCENTER:
                            TipoUsuario = Util.Cargo.CALLCENTER;
                            break;
                        default:
                            TipoUsuario = Util.Cargo.ADMINISTRADOR;//TODO #JOAO somente em teste desenvolvimeto
                            break;
                    }
                }

                HttpContext.Current.Session["UsuarioLogado"] = value; }
        }

        public static int idadeBase
        {
            get { return HttpContext.Current.Session["Idade" + UsuarioLogado.IDUsuario] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["Idade" + UsuarioLogado.IDUsuario].ToString()); }
            set { HttpContext.Current.Session["Idade" + UsuarioLogado.IDUsuario] = value; }
        }

        public static int respostaPergunta2
        {
            get { return HttpContext.Current.Session["Pergunta2" + UsuarioLogado.IDUsuario] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["Pergunta2" + UsuarioLogado.IDUsuario].ToString()); }
            set { HttpContext.Current.Session["Pergunta2" + UsuarioLogado.IDUsuario] = value; }
        }

        public static int respostaPergunta7
        {
            get { return HttpContext.Current.Session["Pergunta7" + UsuarioLogado.IDUsuario] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["Pergunta7" + UsuarioLogado.IDUsuario].ToString()); }
            set { HttpContext.Current.Session["Pergunta7" + UsuarioLogado.IDUsuario] = value; }
        }

        public static TPlanoProtecaoVO PlanoProtecaoVO
        {
            get { return HttpContext.Current.Session["TPlanoProtecaoVO" + UsuarioLogado.IDUsuario] == null ? new TPlanoProtecaoVO() : (TPlanoProtecaoVO)HttpContext.Current.Session["TPlanoProtecaoVO" + UsuarioLogado.IDUsuario]; }
            set { HttpContext.Current.Session["TPlanoProtecaoVO" + UsuarioLogado.IDUsuario] = value; }
        }

        public static TPlanoSeniorVO PlanoSeniorVO
        {
            get { return HttpContext.Current.Session["TPlanoSeniorVO" + UsuarioLogado.IDUsuario] == null ? new TPlanoSeniorVO() : (TPlanoSeniorVO)HttpContext.Current.Session["TPlanoSeniorVO" + UsuarioLogado.IDUsuario]; }
            set { HttpContext.Current.Session["TPlanoSeniorVO" + UsuarioLogado.IDUsuario] = value; }
        }

        public static TPlanoCasalVO PlanoCasalVO
        {
            get { return HttpContext.Current.Session["TPlanoCasalVO" + UsuarioLogado.IDUsuario] == null ? new TPlanoCasalVO() : (TPlanoCasalVO)HttpContext.Current.Session["TPlanoCasalVO" + UsuarioLogado.IDUsuario]; }
            set { HttpContext.Current.Session["TPlanoCasalVO" + UsuarioLogado.IDUsuario] = value; }
        }

        public static TPlanoProtecaoVO PlanoProtecaoVONovo
        {
            get { return HttpContext.Current.Session["TPlanoProtecaoVONovo" + UsuarioLogado.IDUsuario] == null ? new TPlanoProtecaoVO() : (TPlanoProtecaoVO)HttpContext.Current.Session["TPlanoProtecaoVONovo" + UsuarioLogado.IDUsuario]; }
            set { HttpContext.Current.Session["TPlanoProtecaoVONovo" + UsuarioLogado.IDUsuario] = value; }
        }

        public static TPlanoCasalVO PlanoCasalVONovo
        {
            get { return HttpContext.Current.Session["TPlanoCasalVONovo" + UsuarioLogado.IDUsuario] == null ? new TPlanoCasalVO() : (TPlanoCasalVO)HttpContext.Current.Session["TPlanoCasalVONovo" + UsuarioLogado.IDUsuario]; }
            set { HttpContext.Current.Session["TPlanoCasalVONovo" + UsuarioLogado.IDUsuario] = value; }
        }

        public static TPlanoSeniorVO PlanoSeniorVONovo
        {
            get { return HttpContext.Current.Session["TPlanoSeniorVONovo" + UsuarioLogado.IDUsuario] == null ? new TPlanoSeniorVO() : (TPlanoSeniorVO)HttpContext.Current.Session["TPlanoSeniorVONovo" + UsuarioLogado.IDUsuario]; }
            set { HttpContext.Current.Session["TPlanoSeniorVONovo" + UsuarioLogado.IDUsuario] = value; }
        }

        public static List<TAgregadoVO> ListaAgregadoVOTemp
        {
            get { return HttpContext.Current.Session["ListaAgregadoVOTemp" + UsuarioLogado.IDUsuario] == null ? new List<TAgregadoVO>() : (List<TAgregadoVO>)HttpContext.Current.Session["ListaAgregadoVOTemp" + UsuarioLogado.IDUsuario]; }
            set { HttpContext.Current.Session["ListaAgregadoVOTemp" + UsuarioLogado.IDUsuario] = value; }
        }

        public static List<TAgregadoVO> ListaAgregadoVONovo
        {
            get { return HttpContext.Current.Session["ListaAgregadoVONovo" + UsuarioLogado.IDUsuario] == null ? new List<TAgregadoVO>() : (List<TAgregadoVO>)HttpContext.Current.Session["ListaAgregadoVONovo" + UsuarioLogado.IDUsuario]; }
            set { HttpContext.Current.Session["ListaAgregadoVONovo" + UsuarioLogado.IDUsuario] = value; }
        }

        #endregion

        #region [ Login ]

        public static void Login()
        {
            //string matricula = Util.ObterMatricula();

            //LogarUsuario(matricula, String.Empty);
        }
        
        #endregion

        #region [ Logoff ]

         public static void Logoff()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session.Abandon();

                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
        }

        #endregion
    }
}
