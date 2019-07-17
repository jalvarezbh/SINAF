using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using ProjetoMobile.Util;
using System.Text.RegularExpressions;
using System.Threading;
using ProjetoMobile.Dominio;
using ProjetoMobile.Persistencia;
using System.Reflection;
using ProjetoMobile.Dominio.Enumeradores;

namespace ProjetoMobile
{
    static class Program
    {
        #region [ DEFAULT SYSTEM ]

        public static string Versao = "Versão: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static string Coletor = "Número Coletor: " + System.Net.Dns.GetHostName();

        public static RespostaCaixaMensagem SenhaConfiguracao = RespostaCaixaMensagem.Nao;

        private static bool incluirRegistro;
        internal static bool IncluirRegistro
        {
            get { return incluirRegistro; }
            set { incluirRegistro = value; }
        }

        private static string usuario;
        internal static string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private static int idUsuario;
        internal static int IDUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        private static int codigoColaborador;
        internal static int CodigoColaborador
        {
            get { return codigoColaborador; }
            set { codigoColaborador = value; }
        }

        private static int idAgendamento;
        internal static int IDAgendamento
        {
            get { return idAgendamento; }
            set { idAgendamento = value; }
        }

        private static Int64 codigoEntrevista;
        internal static Int64 CodigoEntrevista
        {
            get { return codigoEntrevista; }
            set { codigoEntrevista = value; }
        }

        private static Int64 codigoFaixa;
        internal static Int64 CodigoFaixa
        {
            get { return codigoFaixa; }
            set { codigoFaixa = value; }// / 1000;}
        }

        private static bool registroAntigo;
        internal static bool RegistroAntigo
        {
            get { return registroAntigo; }
            set { registroAntigo = value; }
        }

        private static int countFaixa;
        internal static int CountFaixa
        {
            get { return countFaixa; }
            set { countFaixa = value; }
        }

        private static int tempoLogOff;
        internal static int TempoLogOff
        {
            get { return tempoLogOff; }
            set { tempoLogOff = value; }
        }

        private static string formularioSeleciona;
        internal static string FormularioSeleciona
        {
            get { return formularioSeleciona; }
            set { formularioSeleciona = value; }
        }

        #endregion

        #region [ DEFAULT FILES ]

        public static string ARQUIVO_COMPONENTE = PastaSistema.AppPath() + "Componente.cab";
        public static string ARQUIVO_COMPONENTE_XML = PastaSistema.AppPath() + "Componente.xml";
        public static string ARQUIVO_CONFIGURACAO = PastaSistema.AppPath() + "Configuracao.xml";
        public static string ARQUIVO_CORREIO = PastaSistema.AppPath() + @"BANCO\SINAF_Correio.sdf";
        public static string ARQUIVO_DADOS = PastaSistema.AppPath() + @"BANCO\SINAF_Mobile.sdf";
        public static string ARQUIVO_GPS = PastaSistema.AppPath() + @"ARQUIVOS\" + DateTime.Now.ToString("yyyyMMdd") + "_tracklog.txt";
        public static string ARQUIVO_GPS_ONTEM = PastaSistema.AppPath() + @"ARQUIVOS\" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "_tracklog.txt";
        public static string ARQUIVO_LOG = PastaSistema.AppPath() + @"LOG\LOG" + System.DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
        public static string DIRETORIO_ARQUIVO = PastaSistema.AppPath() + @"ARQUIVOS";
        public static string DIRETORIO_BANCO = PastaSistema.AppPath() + @"BANCO";
        public static string PROCESSO_GPS = @"GPSControl.exe";
        public static string PROCESSO_GPS_FULL = PastaSistema.AppPath() + @"GPSControl.exe";

        #endregion

        #region [ CONTROL FORM ]

        internal static frmFundo fundo = new frmFundo();

        public static T AbreForm<T>() where T : Form
        {
            return (T)frmFundo.AbreForm(typeof(T));
        }

        public static T DialogForm<T>() where T : Form
        {
            return (T)frmFundo.DialogForm(typeof(T));
        }

        //public static void DialogFormClose()
        //{
        //    frmFundo.DialogFormClose();
        //}

        public static T TrocaForm<T>() where T : Form
        {
            return (T)frmFundo.TrocaForm(typeof(T));
        }
                
        public static void LimparPilha()
        {
            frmFundo.LimparPilha();
        }

        #endregion

        #region [ ALL FIELDS ]
            
        public static void txtBox_focusOn(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            txtbox.BackColor = System.Drawing.Color.LightBlue;
        }

        public static void txtBox_focusOff(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            txtbox.BackColor = System.Drawing.Color.White;
        }

        public static void txtBox_next(object sender, KeyEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                txtbox.Parent.SelectNextControl(txtbox, true, true, true, true);
            }
        }

        public static void cmbBox_focusOn(object sender, EventArgs e)
        {
            ComboBox cmbbox = (ComboBox)sender;
            cmbbox.BackColor = System.Drawing.Color.LightBlue;
        }

        public static void cmbBox_focusOff(object sender, EventArgs e)
        {
            ComboBox cmbbox = (ComboBox)sender;
            cmbbox.BackColor = System.Drawing.Color.White;
        }

        public static void cmbBox_next(object sender, KeyEventArgs e)
        {
            ComboBox cmbbox = (ComboBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                cmbbox.Parent.SelectNextControl(cmbbox, true, true, true, true);
            }
        }
               
        public static void chkBox_next(object sender, KeyEventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                chkBox.Parent.SelectNextControl(chkBox, true, true, true, true);
            }
        }

        public static void chkBox_enter(object sender, KeyEventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            if (e.KeyCode == Keys.Enter)
                e.Handled = true;

        }

        public static void btn_focusOn(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.LightBlue;
        }

        public static void btn_focusOffAzul(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.FromArgb(34,61,118);
        }

        public static void btn_focusOffWhite(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.White;
        }

        public static void btn_next(object sender, KeyEventArgs e)
        {
            Button btnBox = (Button)sender;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnBox.Parent.SelectNextControl(btnBox, true, true, true, true);
            }
        }

        public static void btn_enter(object sender, KeyEventArgs e)
        {
            Button btnBox = (Button)sender;
            if (e.KeyCode == Keys.Enter)
                e.Handled = true;
        }

        #endregion

        #region [ EXCEPTION ]

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (e.ExceptionObject as Exception);
            LogErro.GravaLog("Um erro fatal ocorreu no programa e o mesmo será finalizado.\r\nVeja o log de erros para maiores detalhes.", ex.Message);
            LogErro.GravaStackTrace(ex);
            Application.Exit();
        }

        #endregion

        #region [ CONFIGURATION ]

        private static void CriaConfiguracao()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode raiz = doc.CreateElement("Configuracao");
            doc.AppendChild(raiz);

            //---- BANCO DE DADOS --------------------------------------------------------------------------------------------------
            XmlNode stringConexao = doc.CreateElement("ConnectionString");
            stringConexao.InnerText = "data source=" + ARQUIVO_DADOS + "; LCID=1033; Password ='PassPeP';";
            doc.SelectSingleNode("/Configuracao").AppendChild(stringConexao);

            //---- WEBSERVICES -----------------------------------------------------------------------------------------------------

            //Sincronizacao
            XmlNode urlSincronizacao = doc.CreateElement("urlSincronizacao");
            urlSincronizacao.InnerText = "http://cabtec.sinaf.com.br/Interfcabetec/Service/SyncColetor.asmx";
            doc.SelectSingleNode("/Configuracao").AppendChild(urlSincronizacao);


            //---- SENHA DE CONFIGURAÇÃO -------------------------------------------------------------------------------------
            XmlNode senhaConfiguracao = doc.CreateElement("SenhaConfiguracao");
            senhaConfiguracao.InnerText = "787D682CFA1C7E32D865CB47175275B6";
            doc.SelectSingleNode("/Configuracao").AppendChild(senhaConfiguracao);

            //---- FTP -------------------------------------------------------------------------------------------------------
            XmlNode FTPEnderecoServidor = doc.CreateElement("FTPEnderecoServidor");
            XmlNode FTPTempoEspera = doc.CreateElement("FTPTempoEspera");
            XmlNode FTPPassivo = doc.CreateElement("FTPPassivo");
            XmlNode FTPPorta = doc.CreateElement("FTPPorta");
            XmlNode FTPDiretorio = doc.CreateElement("FTPDiretorio");
            XmlNode FTPUser = doc.CreateElement("FTPUser");
            XmlNode FTPPassword = doc.CreateElement("FTPPassword");
            
            FTPEnderecoServidor.InnerText = "cabtec.sinaf.com.br";
            FTPTempoEspera.InnerText = "60";
            FTPPassivo.InnerText = "N";
            FTPPorta.InnerText = "21";
            FTPDiretorio.InnerText = @"/TEMP/";
            FTPUser.InnerText = "cabtec";
            FTPPassword.InnerText = "cab003";

            doc.SelectSingleNode("/Configuracao").AppendChild(FTPEnderecoServidor);
            doc.SelectSingleNode("/Configuracao").AppendChild(FTPTempoEspera);
            doc.SelectSingleNode("/Configuracao").AppendChild(FTPPassivo);
            doc.SelectSingleNode("/Configuracao").AppendChild(FTPPorta);
            doc.SelectSingleNode("/Configuracao").AppendChild(FTPDiretorio);
            doc.SelectSingleNode("/Configuracao").AppendChild(FTPUser);
            doc.SelectSingleNode("/Configuracao").AppendChild(FTPPassword);

            //---- DATA DA ULTIMA ATUALIZAÇÃO---------------------------------------------------------------------
            XmlNode DataAtualizacao = doc.CreateElement("UltimaAtualizacao");
            DataAtualizacao.InnerText = DateTime.Now.ToString("dd/MM/yy");
            doc.SelectSingleNode("/Configuracao").AppendChild(DataAtualizacao);

            //---- VERSÃO BASE CORREIOS---------------------------------------------------------------------------
            XmlNode VersaoCorreios = doc.CreateElement("VersaoCorreio");
            VersaoCorreios.InnerText = "0";
            doc.SelectSingleNode("/Configuracao").AppendChild(VersaoCorreios);

            //---- COLETOR BLOQUEADO------------------------------------------------------------------------------
            XmlNode ColetorAtivo = doc.CreateElement("ColetorAtivo");
            ColetorAtivo.InnerText = "true";
            doc.SelectSingleNode("/Configuracao").AppendChild(ColetorAtivo);

            //---- VERSÃO COMPONENTE------------------------------------------------------------------------------
            XmlNode VersaoComponente = doc.CreateElement("VersaoComponente");
            VersaoComponente.InnerText = "1";
            doc.SelectSingleNode("/Configuracao").AppendChild(VersaoComponente);

            //---- ENTREVISTAS ENVIADAS--------------------------------------------------------------------------
            XmlNode EntrevistasEnviadas = doc.CreateElement("EntrevistasEnviadas");
            EntrevistasEnviadas.InnerText = "0";
            doc.SelectSingleNode("/Configuracao").AppendChild(EntrevistasEnviadas);

            //---- ENTREVISTAS RECEBIDAS-------------------------------------------------------------------------
            XmlNode EntrevistasRecebidas = doc.CreateElement("EntrevistasRecebidas");
            EntrevistasRecebidas.InnerText = "0";
            doc.SelectSingleNode("/Configuracao").AppendChild(EntrevistasRecebidas);

            //---- THREAD ENTREVISTA-------------------------------------------------------------------------
            XmlNode ThreadEntrevista = doc.CreateElement("ThreadEntrevista");
            ThreadEntrevista.InnerText = "false";
            doc.SelectSingleNode("/Configuracao").AppendChild(ThreadEntrevista);

            //Salva arquivo
            doc.Save(ARQUIVO_CONFIGURACAO);

            //---- LIMPEZA DOS OBJETOS ---------------------------------------------------------------------------------------------
            urlSincronizacao = null;
            doc = null;
            raiz = null;
            senhaConfiguracao = null;
            FTPEnderecoServidor = null;
            FTPTempoEspera = null;
            FTPPassivo = null;
            FTPPorta = null;
        }

        private static void AjustaConfiguracao()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Program.ARQUIVO_CONFIGURACAO);

            //---- BANCO DE DADOS --------------------------------------------------------------------------------------------------
            if (doc.DocumentElement["ConnectionString"] == null)
                IncluirChave(doc, "ConnectionString", "data source=" + ARQUIVO_DADOS + "; LCID=1033; Password ='PassPeP';");
            
            //---- WEBSERVICES -----------------------------------------------------------------------------------------------------
            if (doc.DocumentElement["urlSincronizacao"] == null)
                IncluirChave(doc, "urlSincronizacao", "http://cabtec.sinaf.com.br/Interfcabetec/Service/SyncColetor.asmx");
           
            //---- SENHA DE CONFIGURAÇÃO -------------------------------------------------------------------------------------
            if (doc.DocumentElement["SenhaConfiguracao"] == null)
                IncluirChave(doc, "SenhaConfiguracao", "787D682CFA1C7E32D865CB47175275B6");
            
            //---- FTP -------------------------------------------------------------------------------------------------------
            if (doc.DocumentElement["FTPEnderecoServidor"] == null)
                IncluirChave(doc, "FTPEnderecoServidor", "cabtec.sinaf.com.br");

            if (doc.DocumentElement["FTPTempoEspera"] == null)
                IncluirChave(doc, "FTPTempoEspera", "60");

            if (doc.DocumentElement["FTPPassivo"] == null)
                IncluirChave(doc, "FTPPassivo", "N");

            if (doc.DocumentElement["FTPPorta"] == null)
                IncluirChave(doc, "FTPPorta", "21");

            if (doc.DocumentElement["FTPDiretorio"] == null)
                IncluirChave(doc, "FTPDiretorio", @"/TEMP/");

            if (doc.DocumentElement["FTPUser"] == null)
                IncluirChave(doc, "FTPUser", "cabtec");

            if (doc.DocumentElement["FTPPassword"] == null)
                IncluirChave(doc, "FTPPassword", "cab003");

            //---- DATA DA ULTIMA ATUALIZAÇÃO---------------------------------------------------------------------
            if (doc.DocumentElement["UltimaAtualizacao"] == null)
                IncluirChave(doc, "UltimaAtualizacao", DateTime.Now.ToString("dd/MM/yy"));
           
            //---- VERSÃO BASE CORREIOS---------------------------------------------------------------------------
            if (doc.DocumentElement["VersaoCorreio"] == null)
                IncluirChave(doc, "VersaoCorreio", "0");
            
            //---- COLETOR BLOQUEADO------------------------------------------------------------------------------
            if (doc.DocumentElement["ColetorAtivo"] == null)
                IncluirChave(doc, "ColetorAtivo", "true");
            
            //---- VERSÃO COMPONENTE------------------------------------------------------------------------------
            if (doc.DocumentElement["VersaoComponente"] == null)
                IncluirChave(doc, "VersaoComponente", "1");
            
            //---- ENTREVISTAS ENVIADAS--------------------------------------------------------------------------
            if (doc.DocumentElement["EntrevistasEnviadas"] == null)
                IncluirChave(doc, "EntrevistasEnviadas", "0");
            
            //---- ENTREVISTAS RECEBIDAS-------------------------------------------------------------------------
            if (doc.DocumentElement["EntrevistasRecebidas"] == null)
                IncluirChave(doc, "EntrevistasRecebidas", "0");
            
            //---- THREAD ENTREVISTA-------------------------------------------------------------------------
            if (doc.DocumentElement["ThreadEntrevista"] == null)
                IncluirChave(doc, "ThreadEntrevista", "false");
                     
        }

        private static void IncluirChave(XmlDocument doc, string chave, string valor)
        {
            doc.SelectSingleNode("/Configuracao").AppendChild(doc.CreateElement(chave));
            doc.DocumentElement[chave].InnerText = valor;
            doc.Save(Program.ARQUIVO_CONFIGURACAO);
        }

        #endregion

        #region [ MAIN ]

        [MTAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            if (File.Exists(ARQUIVO_COMPONENTE))
            {
                int versaoComponenteAtual = Convert.ToInt32(LerGravarXML.ObterValor("VersaoComponente", "0"));

                int versaoComponenteNovo = Convert.ToInt32(LerGravarXML.ObterValorComponente("VersaoComponente", "0"));

                if (versaoComponenteNovo > versaoComponenteAtual)
                {
                    if (versaoComponenteAtual == 0)
                        CriaConfiguracao();

                    LerGravarXML.GravarValor("VersaoComponente", versaoComponenteNovo.ToString());

                    ControleAtualizacao atualizarComponente = new ControleAtualizacao();
                    atualizarComponente.InstalarComponente();
                    Application.Exit();
                }
                else
                {
                    File.Delete(ARQUIVO_COMPONENTE);
                }
            }

            if (!Directory.Exists(DIRETORIO_ARQUIVO))
                Directory.CreateDirectory(DIRETORIO_ARQUIVO);

            if (!Directory.Exists(DIRETORIO_BANCO))
                Directory.CreateDirectory(DIRETORIO_BANCO);

            if (!File.Exists(ARQUIVO_CONFIGURACAO))
                CriaConfiguracao();
            else
                AjustaConfiguracao();

            Application.Run(fundo);
        }        

        #endregion
    }
}