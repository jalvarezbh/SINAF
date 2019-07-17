using System;
using System.Windows.Forms;
using ProjetoMobile.Util;
using System.IO;
using FTP_Mobile.FTPLib;
using System.Reflection;
using ProjetoMobile.Dominio.Enumeradores;

namespace ProjetoMobile
{
    public partial class frmAtualizacao : Form
    {
        #region [ PROPERTIES ]

        private ControleAtualizacao Controle = new ControleAtualizacao();

        private String versao = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        private String mensagemUpload = string.Empty;

        private String mensagemDownload = string.Empty;

        private String mensagemCorreio = string.Empty;

        private String mensagemGPS = string.Empty;

        private String mensagemVersao = string.Empty;

        private TimeSpan timerUpload;

        private TimeSpan timerDownload;

        private TimeSpan timerCorreio;

        private TimeSpan timerGPS;

        private TimeSpan timerVersao;

        #endregion

        #region [ LOAD ]

        public frmAtualizacao()
        {
            InitializeComponent();
            FocusOn();
            FocusOff();
            KeyDownTecla();
            KeyUpTecla();
        }

        private void frmAtualizacao_Load(object sender, EventArgs e)
        {
            try
            {
                MostraCursor.CursorAguarde(true);

                this.Controle.NotificarInicioDownload += new Action<Int32>(Controle_NotificarInicioDownload);
                this.Controle.NotificarProgresso += new Action<Int32>(Controle_NotificarProgresso);
                this.Controle.NotificarTermino += new Action(Controle_NotificarTermino);
                this.Controle.NotificarFalha += new Action<String>(Controle_NotificarFalha);
                lblVersao.Text = "Versão Sistema:" + versao;
                lblCorreio.Text = "Versão Correio:" + LerGravarXML.ObterValor("VersaoCorreio", "0");


                if (Program.SenhaConfiguracao == RespostaCaixaMensagem.Sim)
                {
                    txtURL.Enabled = true;
                    txtFTP.Enabled = true;
                    txtURL.Focus();
                    btnDestravar.Text = "Travar";
                }
                else
                {
                    txtURL.Enabled = false;
                    txtFTP.Enabled = false;
                    btnExecutar.Focus();
                    btnDestravar.Text = "Destravar";
                }

                WIFI(true);
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro Tela Atualização", ex.Message);
            }
            finally
            {
                MostraCursor.CursorAguarde(false);
            }
        }

        private void FrmAtualizacao_Activated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LerGravarXML.ObterValor("urlSincronizacao", "")))
                txtURL.Text = LerGravarXML.ObterValor("urlSincronizacao", "");

            if (!string.IsNullOrEmpty(LerGravarXML.ObterValor("FTPEnderecoServidor", "")))
                txtFTP.Text = LerGravarXML.ObterValor("FTPEnderecoServidor", "");
        }

        #endregion

        #region [ CONTROL ]

        private void Controle_NotificarInicioDownload(Int32 tamanhoArquivo)
        {
            if (pgbAtualizacao.InvokeRequired)
            {
                pgbAtualizacao.Invoke(new Action<Int32>(Controle_NotificarInicioDownload), new Object[] { tamanhoArquivo });
                return;
            }
            pgbAtualizacao.Minimum = pgbAtualizacao.Value = 0;
            pgbAtualizacao.Maximum = tamanhoArquivo;
        }

        private void Controle_NotificarProgresso(Int32 bytesLidos)
        {
            if (pgbAtualizacao.InvokeRequired)
                pgbAtualizacao.Invoke(new Action<Int32>(Controle_NotificarProgresso), new Object[] { bytesLidos });
            else
                pgbAtualizacao.Value += bytesLidos;
        }

        private void Controle_NotificarTermino()
        {
            Notificar("Término do download.\r\nIniciando instalador...");

            //Sai do sistema não informando o nome de nenhum formulário
            //Program.FormularioAtivo = "";
            //this.Close();

        }

        private void Controle_NotificarFalha(String mensagem)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<String>(Controle_NotificarFalha), new Object[] { mensagem });
                return;
            }
            this.Close();
        }

        private void Notificar(String mensagem)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<String>(Notificar), new Object[] { mensagem });
                return;
            }
            this.tbxStatus.Text += mensagem + "\r\n";
            this.tbxStatus.SelectionStart = tbxStatus.Text.Length;
            this.tbxStatus.ScrollToCaret();
        }

        private void FocusOn()
        {
            txtURL.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtFTP.GotFocus += new EventHandler(Program.txtBox_focusOn);
            btnVoltar.GotFocus += new EventHandler(Program.btn_focusOn);
            btnDestravar.GotFocus += new EventHandler(Program.btn_focusOn);
            btnExecutar.GotFocus += new EventHandler(Program.btn_focusOn);
        }

        private void FocusOff()
        {
            txtURL.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtFTP.LostFocus += new EventHandler(Program.txtBox_focusOff);
            btnVoltar.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            btnDestravar.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            btnExecutar.LostFocus += new EventHandler(Program.btn_focusOffAzul);
        }

        private void KeyDownTecla()
        {
            //Only button and check
            btnVoltar.KeyDown += new KeyEventHandler(Program.btn_enter);            
            btnDestravar.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnExecutar.KeyDown += new KeyEventHandler(Program.btn_enter);
        }

        private void KeyUpTecla()
        {
            txtURL.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtFTP.KeyUp += new KeyEventHandler(Program.txtBox_next);
            btnVoltar.KeyUp += new KeyEventHandler(Program.btn_next);
            btnDestravar.KeyUp += new KeyEventHandler(Program.btn_next);
            btnExecutar.KeyUp += new KeyEventHandler(Program.btn_next);
        }

        #endregion

        #region [ METHODS ]

        private void WIFI(bool ligar)
        {
            try
            {
                MostraCursor.CursorAguarde(true);

                ControleHardware wifi = new ControleHardware();

                wifi.ControlarRadioWiFi(true);

                bool ligado = false;

                ligado = wifi.VerificarRadioWiFi();
                if (ligado)
                    picWIFI.Image = ProjetoMobile.Properties.Resources.accept32;
                else
                    picWIFI.Image = ProjetoMobile.Properties.Resources.remove32;

                wifi = null;
            }
            catch (Exception)
            {


            }
            finally
            {
                MostraCursor.CursorAguarde(false);
            }



        }

        private void UploadBanco()
        {
            DateTime inicioUpload = DateTime.Now;
            try
            {
                string arquivo = Program.ARQUIVO_DADOS;

                if (File.Exists(arquivo))
                {
                    Notificar("----------------------------");
                    Notificar("UPLOAD");
                    Notificar("----------------------------");
                    pgbUpDown.Value = 10;
                    Notificar("INICIO - Upload do banco. -- " + DateTime.Now + " --");
                    pgbUpDown.Value = 20;
                    Notificar("COLETOR - Compactar banco. -- " + DateTime.Now + " --");

                    CompactarBancoDados(arquivo);

                    pgbUpDown.Value = 30;
                    Notificar("WIFI UPLOAD- Enviar banco. -- " + DateTime.Now + " --");

                    MandarArquivoServidorFTP(arquivo + ".gz");

                    if (File.Exists(arquivo + ".gz"))
                        File.Delete(arquivo + ".gz");

                    pgbUpDown.Value = 60;
                    Notificar("SERVIDOR WEB - Executar o serviço. -- " + DateTime.Now + " --");

                    string numero = new Symbol.ResourceCoordination.TerminalInfo().ESN;
                    int numeroUpload = 0;
                    bool executarUpload = new wsColetor.SyncColetor() { Url = txtURL.Text }.ExportarBanco(numero, versao, out numeroUpload);

                    Notificar(numeroUpload + " - Entrevistas enviadas com sucesso.");

                    LerGravarXML.GravarValor("EntrevistasEnviadas", numeroUpload.ToString());

                    pgbUpDown.Value = 100;

                    Notificar("FIM - Upload do banco. -- " + DateTime.Now + " --");

                    mensagemUpload = "OK";

                    if (File.Exists(arquivo))
                        File.Delete(arquivo);
                }
            }
            catch (Exception ex)
            {
                mensagemUpload = "ERRO";
                throw ex;
            }
            finally
            {
                DateTime fimUpload = DateTime.Now;
                timerUpload = fimUpload.Subtract(inicioUpload);
            }
        }

        private void DownloadBanco()
        {
            DateTime inicioDownload = DateTime.Now;
            try
            {
                Notificar("----------------------------");
                Notificar("DOWNLOAD");
                Notificar("----------------------------");
                pgbUpDown.Value = 10;
                Notificar("INICIO - Download do banco. -- " + DateTime.Now + " --");

                string strArquivoGzipLocal = Program.ARQUIVO_DADOS + ".gz";
                string arquivo = Program.ARQUIVO_DADOS;

                string numero = new Symbol.ResourceCoordination.TerminalInfo().ESN;

                pgbUpDown.Value = 20;
                Notificar("SERVIDOR WEB - Executar o serviço. -- " + DateTime.Now + " --");

                int numeroDownload = 0;
                string strArquivoBancoDadosWebService = new wsColetor.SyncColetor() { Url = txtURL.Text }.ImportarBanco(numero, versao, out numeroDownload);

                pgbUpDown.Value = 60;
                Notificar("WIFI DOWNLOAD- Receber o banco. -- " + DateTime.Now + " --");
                CopiarArquivoServidorFTP(strArquivoBancoDadosWebService + ".gz", strArquivoGzipLocal);

                if (File.Exists(arquivo))
                    File.Delete(arquivo);

                pgbUpDown.Value = 80;
                Notificar("COLETOR - Descompactar o banco. -- " + DateTime.Now + " --");
                DescompactarBancoDados(strArquivoGzipLocal, arquivo);

                Notificar(numeroDownload + " - Entrevistas carregadas com sucesso.");
                LerGravarXML.GravarValor("EntrevistasRecebidas", numeroDownload.ToString());

                pgbUpDown.Value = 100;
                Notificar("FIM - Download do banco. -- " + DateTime.Now + " --");

                mensagemDownload = "OK";
            }
            catch (Exception ex)
            {
                mensagemDownload = "ERRO";
                throw ex;
            }
            finally
            {
                DateTime fimDownload = DateTime.Now;
                timerDownload = fimDownload.Subtract(inicioDownload);
            }
        }

        private void CorreioBanco()
        {
            DateTime inicioCorreio = DateTime.Now;
            try
            {
                Notificar("----------------------------");
                Notificar("VERSÃO BASE CORREIO");
                Notificar("----------------------------");
                pgbUpDown.Value = 10;
                Notificar("INICIO - Verifica a versão do correio. -- " + DateTime.Now + " --");

                int versaoAtual = Convert.ToInt32(LerGravarXML.ObterValor("VersaoCorreio", "0"));
                int versaoServidor = 0;
                string numero = new Symbol.ResourceCoordination.TerminalInfo().ESN;

                pgbUpDown.Value = 20;
                Notificar("SERVIDOR WEB - Executar o serviço. -- " + DateTime.Now + " --");

                string strArquivoBancoDadosWebService = new wsColetor.SyncColetor() { Url = txtURL.Text }.ImportarBancoCorreios(numero, "RJ", versaoAtual, out versaoServidor);

                pgbUpDown.Value = 60;

                if (!string.IsNullOrEmpty(strArquivoBancoDadosWebService))
                {
                    Notificar("WIFI DOWNLOAD- Receber o banco. -- " + DateTime.Now + " --");
                    string strArquivoGzipLocal = Program.ARQUIVO_CORREIO + ".gz";
                    string arquivo = Program.ARQUIVO_CORREIO;

                    CopiarArquivoServidorFTP(strArquivoBancoDadosWebService + ".gz", strArquivoGzipLocal);

                    if (File.Exists(strArquivoGzipLocal))
                        if (File.Exists(arquivo))
                            File.Delete(arquivo);

                    pgbUpDown.Value = 80;
                    Notificar("COLETOR - Descompactar o banco. -- " + DateTime.Now + " --");
                    DescompactarBancoDados(strArquivoGzipLocal, arquivo);

                    LerGravarXML.GravarValor("VersaoCorreio", versaoServidor.ToString());
                }

                pgbUpDown.Value = 100;
                Notificar("FIM - Verifica a versão do correio. -- " + DateTime.Now + " --");

                mensagemCorreio = "OK";

            }
            catch (Exception ex)
            {
                mensagemCorreio = "ERRO";
                throw ex;
            }
            finally
            {
                DateTime fimCorreio = DateTime.Now;
                timerCorreio = fimCorreio.Subtract(inicioCorreio);
            }
        }

        private void UploadGPS()
        {
            DateTime inicioGPS = DateTime.Now;
            try
            {
                string arquivo = Program.ARQUIVO_GPS_ONTEM;

                if (File.Exists(arquivo))
                {
                    Notificar("----------------------------");
                    Notificar("GPS");
                    Notificar("----------------------------");
                    pgbUpDown.Value = 10;
                    Notificar("INICIO - Upload do GPS. -- " + DateTime.Now + " --");

                    pgbUpDown.Value = 30;
                    Notificar("WIFI GPS - Enviar GPS. -- " + DateTime.Now + " --");

                    MandarArquivoServidorFTP(arquivo);

                    if (File.Exists(arquivo))
                        File.Delete(arquivo);

                    pgbUpDown.Value = 100;

                    Notificar("FIM - Upload do GPS. -- " + DateTime.Now + " --");

                    mensagemGPS = "OK";
                }
            }
            catch (Exception ex)
            {
                mensagemGPS = "ERRO";
                throw ex;
            }
            finally
            {
                DateTime fimGPS = DateTime.Now;
                timerGPS = fimGPS.Subtract(inicioGPS);
            }
        }

        private void VersaoSistema(bool erro)
        {
            DateTime inicioVersao = DateTime.Now;
            try
            {
                pgbAtualizacao.Visible = false;
                pgbUpDown.Visible = true;

                Notificar("----------------------------");
                Notificar("VERSÃO");
                Notificar("----------------------------");
                Notificar("Verifica versão do sistema. -- " + DateTime.Now + " --");

                if (Controle.Verificar(txtURL.Text))
                {
                    if (erro)
                    {
                        string bancoMobile = Program.ARQUIVO_DADOS;

                        if (File.Exists(bancoMobile))
                            File.Delete(bancoMobile);

                        string bancoCorreio = Program.ARQUIVO_DADOS;

                        if (File.Exists(bancoCorreio))
                            File.Delete(bancoCorreio);
                    }

                    Notificar("Instalar nova versão do sistema. -- " + DateTime.Now + " --");
                    Controle.Executar();
                    Notificar("----------------------------");
                    Notificar("AGUARDE TERMINAR A INSTALAÇÃO");
                    Notificar("----------------------------");
                }
                else
                {
                    Notificar("O sistema está com a versão atual.");

                    Notificar("----------------------------");
                    Notificar("FIM");
                    Notificar("----------------------------");
                }

                LerGravarXML.GravarValor("UltimaAtualizacao", DateTime.Now.ToString("dd/MM/yy"));

                mensagemVersao = "OK";

                pgbAtualizacao.Visible = true;
                pgbUpDown.Visible = false;
            }
            catch (Exception ex)
            {
                mensagemVersao = "ERRO";
                throw ex;
            }
            finally
            {
                DateTime fimVersao = DateTime.Now;
                timerVersao = fimVersao.Subtract(inicioVersao);
            }
        }

        private void VerificarColetorAtivo()
        {
            try
            {
                string numero = new Symbol.ResourceCoordination.TerminalInfo().ESN;

                bool dadosWebService = new wsColetor.SyncColetor() { Url = txtURL.Text }.VerificaColetorAtivo(numero);

                LerGravarXML.GravarValor("ColetorAtivo", dadosWebService.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ExecutarAtualizacao()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtURL.Text))
                {
                    LerGravarXML.GravarValor("urlSincronizacao", txtURL.Text);

                    if (!string.IsNullOrEmpty(txtFTP.Text))
                        LerGravarXML.GravarValor("FTPEnderecoServidor", txtFTP.Text);

                    //Upload do Bando de Entrevista
                    UploadBanco();

                    //Download do Banco de Entrevista
                    DownloadBanco();

                    //Verificar e Atualizar Banco Correios
                    CorreioBanco();

                    //Upload do Arquivo GPS
                    UploadGPS();

                    //Verificar e Atualizar Versão Sistema
                    VersaoSistema(false);

                    //Resumo das Ações do Sincronismo
                    ResumoSincronismo();
                }
                else
                    CaixaMensagem.ExibirOk("URL do servidor não foi informado!");

            }
            catch (Exception ex)
            {
                //Verificar e Atualizar Versão Sistema
                VersaoSistema(true);

                MostraCursor.CursorAguarde(false);
                CaixaMensagem.ExibirErro("Erro ao sincronizar com  o servidor. Realize a sincronização novamente.", ex.Message);
            }

        }

        private void TestarConectividade()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtURL.Text))
                {
                    LerGravarXML.GravarValor("urlSincronizacao", txtURL.Text);

                    Notificar("----------------------------");
                    Notificar("TESTE SERVIDOR");
                    Notificar("----------------------------");
                    Notificar("Verifica a conectividade.");


                    DataHora.AcertaDataHora(new wsColetor.SyncColetor() { Url = txtURL.Text }.SetDateTime());

                    Notificar("Servidor conectado com sucesso.");
                    Notificar("----------------------------");
                    Notificar("FIM TESTE SERVIDOR");
                    Notificar("----------------------------");
                }
                else
                    CaixaMensagem.ExibirOk("URL do servidor não foi informado!");

            }
            catch (Exception ex)
            {
                MostraCursor.CursorAguarde(false);
                Notificar("Servidor não conectado.");
                Notificar("----------------------------");
                Notificar("FIM TESTE SERVIDOR");
                Notificar("----------------------------");

                throw ex;
            }
        }

        private void ResumoSincronismo()
        {
            try
            {
                Notificar("----------------------------");
                Notificar("RESUMO SINCRONISMO ");
                Notificar("----------------------------");
                Notificar("UPLOAD: " + mensagemUpload + " - " + timerUpload.Minutes.ToString().PadLeft(2, '0') + ":" + timerUpload.Seconds.ToString().PadLeft(2, '0'));
                Notificar("DOWNLOAD: " + mensagemDownload + " - " + timerDownload.Minutes.ToString().PadLeft(2, '0') + ":" + timerDownload.Seconds.ToString().PadLeft(2, '0'));
                Notificar("CORREIOS: " + mensagemCorreio + " - " + timerCorreio.Minutes.ToString().PadLeft(2, '0') + ":" + timerCorreio.Seconds.ToString().PadLeft(2, '0'));
                Notificar("GPS: " + mensagemGPS + " - " + timerGPS.Minutes.ToString().PadLeft(2, '0') + ":" + timerGPS.Seconds.ToString().PadLeft(2, '0'));
                Notificar("VERSÃO: " + mensagemVersao + " - " + timerVersao.Minutes.ToString().PadLeft(2, '0') + ":" + timerVersao.Seconds.ToString().PadLeft(2, '0'));

                lblVersao.Text = "Versão Sistema:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                lblCorreio.Text = "Versão Correio:" + LerGravarXML.ObterValor("VersaoCorreio", "0");

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region [ FTP ]

        private static void CopiarArquivoServidorFTP(string NomeArquivoFTP, string NomeArquivoLocal)
        {
            try
            {
                clsFTP ftp = new clsFTP();
                ftp.RemotePort = Convert.ToInt32(LerGravarXML.ObterValor("FTPPorta", "21"));
                ftp.RemoteHost = LerGravarXML.ObterValor("FTPEnderecoServidor", "cabtec.sinaf.com.br");
                ftp.UsarLan = (LerGravarXML.ObterValor("FTPPassivo", "N") == "S" ? true : false);
                ftp.RemoteUser = LerGravarXML.ObterValor("FTPUser", "cabtec");
                ftp.RemotePassword = LerGravarXML.ObterValor("FTPPassword", "cab003");

                ftp.Login();

                string ftpCaminho = NomeArquivoFTP.Substring(NomeArquivoFTP.LastIndexOf("TEMP"));
                ftpCaminho = ftpCaminho.Substring(0, ftpCaminho.LastIndexOf("\\") + 1);
                ftpCaminho = ftpCaminho.Replace('\\', '/');
                ftp.ChangeDirectory(@"/" + ftpCaminho);

                NomeArquivoFTP = NomeArquivoFTP.Substring(NomeArquivoFTP.LastIndexOf("\\") + 1);
                ftp.DownloadFile(NomeArquivoFTP, NomeArquivoLocal);
                ftp.DeleteFile(NomeArquivoFTP);

                ftp.CloseConnection();
                ftp = null;

            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Acessando servidor FTP!", ex.Message);
                throw ex;
            }
        }

        private static void MandarArquivoServidorFTP(string NomeArquivoLocal)
        {
            try
            {
                clsFTP ftp = new clsFTP();
                ftp.RemotePort = Convert.ToInt32(LerGravarXML.ObterValor("FTPPorta", "21"));
                ftp.RemoteHost = LerGravarXML.ObterValor("FTPEnderecoServidor", "cabtec.sinaf.com.br");
                ftp.UsarLan = (LerGravarXML.ObterValor("FTPPassivo", "N") == "S" ? true : false);
                ftp.RemoteUser = LerGravarXML.ObterValor("FTPUser", "cabtec");
                ftp.RemotePassword = LerGravarXML.ObterValor("FTPPassword", "cab003");

                ftp.Login();

                string numero = new Symbol.ResourceCoordination.TerminalInfo().ESN;
                string diretorio = LerGravarXML.ObterValor("FTPDiretorio", @"/TEMP/");

                ftp.ChangeDirectory(diretorio + numero);

                ftp.UploadFile(NomeArquivoLocal);

                ftp.CloseConnection();
                ftp = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ COMPACT ]

        private static void CompactarBancoDados(string NomeArquivo)
        {
            try
            {
                GZip.Compactar(new FileInfo(NomeArquivo));
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Compactar Arquivo!", ex.Message);
            }
        }

        private static void DescompactarBancoDados(string NomeArquivo, string NomeArquivoNovo)
        {
            try
            {
                GZip.Descompactar(new FileInfo(NomeArquivo));

                if (File.Exists(NomeArquivoNovo))
                    File.Delete(NomeArquivo);
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Descompactar Arquivo!", ex.Message);
            }
        }

        #endregion

        #region [ BUTTONS ]

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Program.SenhaConfiguracao = RespostaCaixaMensagem.Nao;
            this.Close();
        }

        private void btnDestravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtURL.Enabled)
                {
                    txtURL.Enabled = false;
                    txtFTP.Enabled = false;
                    btnDestravar.Text = "Destravar";
                    Program.SenhaConfiguracao = RespostaCaixaMensagem.Nao;
                    if (!string.IsNullOrEmpty(txtURL.Text))
                        LerGravarXML.GravarValor("urlSincronizacao", txtURL.Text);

                    if (!string.IsNullOrEmpty(txtFTP.Text))
                        LerGravarXML.GravarValor("FTPEnderecoServidor", txtFTP.Text);
                }
                else
                    CaixaMensagem.ConfirmarSenha("Informe a senha de configuração para alterar os dados da rede!", true);

            }
            catch (Exception)
            {

            }
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            try
            {
                MostraCursor.CursorAguarde(true);
                TestarConectividade();
                ExecutarAtualizacao();
            }
            catch (Exception)
            {

            }
            finally
            {
                MostraCursor.CursorAguarde(false);
            }
        }

        #endregion
    }
}