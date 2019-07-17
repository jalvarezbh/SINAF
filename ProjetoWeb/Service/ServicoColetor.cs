using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoVO;
using ProjetoController;
using ProjetoWeb.Util;
using System.Data.SqlServerCe;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ErikEJ.SqlCe;
using System.IO;
using FTP_Windows.FTPLib;
using System.Security.Cryptography;
using WebControls;
using System.Web.Configuration;

namespace ProjetoWeb.Service
{
    public class ServicoColetor
    {
        #region [ PROPERTIES ]

        private TUsuarioCONTROLLER controllerUsuario;

        public TUsuarioCONTROLLER ControllerUsuario
        {
            get
            {
                if (controllerUsuario == null)
                    controllerUsuario = new TUsuarioCONTROLLER();

                return controllerUsuario;

            }
        }

        private TColetorCONTROLLER controllerColetor;

        public TColetorCONTROLLER ControllerColetor
        {
            get
            {
                if (controllerColetor == null)
                    controllerColetor = new TColetorCONTROLLER();

                return controllerColetor;

            }
        }

        private TParametroCONTROLLER controllerParametro;

        public TParametroCONTROLLER ControllerParametro
        {
            get
            {
                if (controllerParametro == null)
                    controllerParametro = new TParametroCONTROLLER();

                return controllerParametro;

            }
        }

        private HistoricoTColetorCONTROLLER controllerHistorico;

        public HistoricoTColetorCONTROLLER ControllerHistorico
        {
            get
            {
                if (controllerHistorico == null)
                    controllerHistorico = new HistoricoTColetorCONTROLLER();

                return controllerHistorico;

            }
        }

        private HistoricoTSincronismoCONTROLLER controllerHistoricoSincronismo;

        public HistoricoTSincronismoCONTROLLER ControllerHistoricoSincronismo
        {
            get
            {
                if (controllerHistoricoSincronismo == null)
                    controllerHistoricoSincronismo = new HistoricoTSincronismoCONTROLLER();

                return controllerHistoricoSincronismo;

            }
        }

        private HistoricoTEntrevistaDownloadCONTROLLER controllerHistoricoEntrevistaDownload;

        public HistoricoTEntrevistaDownloadCONTROLLER ControllerHistoricoEntrevistaDownload
        {
            get
            {
                if (controllerHistoricoEntrevistaDownload == null)
                    controllerHistoricoEntrevistaDownload = new HistoricoTEntrevistaDownloadCONTROLLER();

                return controllerHistoricoEntrevistaDownload;

            }
        }

        private HistoricoTEntrevistaUploadCONTROLLER controllerHistoricoEntrevistaUpload;

        public HistoricoTEntrevistaUploadCONTROLLER ControllerHistoricoEntrevistaUpload
        {
            get
            {
                if (controllerHistoricoEntrevistaUpload == null)
                    controllerHistoricoEntrevistaUpload = new HistoricoTEntrevistaUploadCONTROLLER();

                return controllerHistoricoEntrevistaUpload;

            }
        }

        private TServicoColetorVO servicoColetorVO;

        public TServicoColetorVO ServicoColetorVO
        {
            get
            {
                if (servicoColetorVO == null)
                    servicoColetorVO = new TServicoColetorVO();

                return servicoColetorVO;

            }
            set { servicoColetorVO = value; }
        }

        private long idHistoricoColetor;

        public long IDHistoricoColetor
        {
            get { return idHistoricoColetor; }

            set { idHistoricoColetor = value; }
        }

        private long idHistoricoTSincronismo;

        public long IDHistoricoTSincronismo
        {
            get { return idHistoricoTSincronismo; }

            set { idHistoricoTSincronismo = value; }
        }

        private int numeroUpload;

        public int NumeroUpload
        {
            get { return numeroUpload; }

            set { numeroUpload = value; }
        }

        private int numeroDownload;

        public int NumeroDownload
        {
            get { return numeroDownload; }

            set { numeroDownload = value; }
        }

        private string versaoSistema;

        public string VersaoSistema
        {
            get
            {
                if (string.IsNullOrEmpty(versaoSistema))
                    versaoSistema = "1.0.1.0";

                return versaoSistema;
            }

            set { versaoSistema = value; }
        }

        private string queryFaixa;

        public string QueryFaixa
        {
            get { return queryFaixa; }

            set { queryFaixa = value; }
        }

        private string queryIncompleta;

        public string QueryIncompleta
        {
            get { return queryIncompleta; }

            set { queryIncompleta = value; }
        }

        #endregion

        #region [ METHODS ]

        public bool VerificaColetorAtivo(string numeroColetor)
        {
            try
            {
                PreencherServiceColetorVO(numeroColetor);

                TColetorVO filtroColetor = new TColetorVO();
                filtroColetor.NumeroSerie = ServicoColetorVO.NumeroColetor;
                filtroColetor.ConsultaAtivo = true;
                filtroColetor.Ativo = true;
                List<TColetorVO> listColetor = ControllerColetor.Listar(filtroColetor);

                return listColetor.Count > 0;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public string ImportarBancoCorreios(string numeroColetor, string siglaUF, int versaoAtual, out int versaoNova)
        {
            try
            {
                versaoNova = 0;
                List<TParametroVO> listParametro = ControllerParametro.Listar(new TParametroVO());
                if (listParametro.Count > 0)
                {
                    versaoNova = listParametro[0].VersaoBaseCorreio.GetValueOrDefault();
                    if (versaoNova > versaoAtual)
                    {
                        PreencherServiceColetorVO(numeroColetor);

                        if (CriarBancoCorreio())
                        {
                            InserirEstado();
                            InserirCidade();
                            InserirBairro();
                            InserirLogradouro(siglaUF);

                            CompactarBancoEnviarFTP(ServicoColetorVO.BancoCorreio);

                            return ServicoColetorVO.BancoCorreio;
                        }
                        else
                        {
                            return String.Empty;
                        }
                    }
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                if (File.Exists(ServicoColetorVO.BancoCorreio))
                    File.Delete(ServicoColetorVO.BancoCorreio);
                throw;
            }

        }

        public string ImportarBancoCorreiosTeste(string numeroColetor, string siglaUF, int versaoAtual)
        {
            try
            {
                int versaoNova = 0;
                List<TParametroVO> listParametro = ControllerParametro.Listar(new TParametroVO());
                if (listParametro.Count > 0)
                {
                    versaoNova = listParametro[0].VersaoBaseCorreio.GetValueOrDefault();
                    if (versaoNova > versaoAtual)
                    {
                        PreencherServiceColetorVO(numeroColetor);

                        if (CriarBancoCorreio())
                        {
                            InserirEstado();
                            InserirCidade();
                            InserirBairro();
                            InserirLogradouro(siglaUF);

                            CompactarBancoEnviarFTP(ServicoColetorVO.BancoCorreio);

                            return ServicoColetorVO.BancoCorreio;
                        }
                        else
                        {
                            return String.Empty;
                        }
                    }
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                if (File.Exists(ServicoColetorVO.BancoCorreio))
                    File.Delete(ServicoColetorVO.BancoCorreio);
                throw;
            }

        }

        public string ImportarBanco(string numeroColetor, string versao, out int numDownload)
        {
            try
            {
                PreencherServiceColetorVO(numeroColetor);

                AlterarHistoricoTColetorVersao(versao, numeroColetor);

                numDownload = 0;

                if (CriarBancoDados())
                {
                    TColetorVO filtroColetor = new TColetorVO();
                    filtroColetor.NumeroSerie = ServicoColetorVO.NumeroColetor;
                    filtroColetor.ConsultaAtivo = true;
                    filtroColetor.Ativo = true;
                    List<TColetorVO> listColetor = ControllerColetor.Listar(filtroColetor);

                    if (listColetor.Count > 0)
                    {
                        TUsuarioVO filtroUsuario = new TUsuarioVO();
                        filtroUsuario.CodigoColaborador = listColetor[0].IDUsuarioResponsavel.GetValueOrDefault();
                        List<TUsuarioVO> listUsuario = ControllerUsuario.Listar(filtroUsuario);

                        if (listUsuario.Count > 0)
                        {
                            InserirUsuario(listUsuario[0]);

                            InserirAgendamento(listUsuario[0].IDUsuario);

                            VerificarParametros();

                            InserirEntrevistaAntiga(listUsuario[0].IDUsuario);

                            InserirEntrevistadoAntigo(listUsuario[0].IDUsuario);

                            InserirEntrevistadoEnderecoAntigo(listUsuario[0].IDUsuario);

                            InserirRespostaAntiga(listUsuario[0].IDUsuario);

                            InserirSimuladorProdutoAntigo(listUsuario[0].IDUsuario);

                            InserirSimuladorProdutoAntigoSubs(listUsuario[0].IDUsuario);

                            InserirIncompleta(listUsuario[0].IDUsuario, listUsuario[0].CodigoColaborador);

                            InserirIncompletaResposta(listUsuario[0].IDUsuario);

                            InserirHistoricoTColetor(ServicoColetorVO.NumeroColetor);

                            InserirHistoricoTSincronismo(listUsuario[0].IDUsuario);

                            InserirFaixa(listUsuario[0].IDUsuario);

                            AlterarHistoricoTSincronismoNumDownload();

                            AlterarHistoricoTColetorNumSincronismo();
                        }

                        InserirProfissao();
                        InserirOrigemVenda();
                        InserirParametro();
                        InserirPlanoProtecao();
                        InserirPlanoProtecaoFuneral();
                        InserirPlanoProtecaoRenda();
                        InserirPlanoSenior();
                        InserirPlanoSeniorFuneral();
                        InserirPlanoCasal();
                        InserirPlanoCasalFuneral();
                    }

                    CompactarBancoEnviarFTP(ServicoColetorVO.BancoMobile);

                    numDownload = NumeroDownload;

                    return ServicoColetorVO.BancoMobile;
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(ServicoColetorVO.BancoMobile))
                    File.Delete(ServicoColetorVO.BancoMobile);
                throw;
            }
        }

        public string ImportarBancoTeste(string numeroColetor, string versao)
        {
            try
            {
                PreencherServiceColetorVO(numeroColetor);

                AlterarHistoricoTColetorVersao(versao, numeroColetor);

                if (CriarBancoDados())
                {
                    TColetorVO filtroColetor = new TColetorVO();
                    filtroColetor.NumeroSerie = ServicoColetorVO.NumeroColetor;
                    filtroColetor.ConsultaAtivo = true;
                    filtroColetor.Ativo = true;
                    List<TColetorVO> listColetor = ControllerColetor.Listar(filtroColetor);

                    if (listColetor.Count > 0)
                    {
                        TUsuarioVO filtroUsuario = new TUsuarioVO();
                        filtroUsuario.CodigoColaborador = listColetor[0].IDUsuarioResponsavel.GetValueOrDefault();
                        List<TUsuarioVO> listUsuario = ControllerUsuario.Listar(filtroUsuario);

                        if (listUsuario.Count > 0)
                        {
                            InserirUsuario(listUsuario[0]);

                            InserirAgendamento(listUsuario[0].IDUsuario);

                            VerificarParametros();

                            InserirEntrevistaAntiga(listUsuario[0].IDUsuario);

                            InserirEntrevistadoAntigo(listUsuario[0].IDUsuario);

                            InserirEntrevistadoEnderecoAntigo(listUsuario[0].IDUsuario);

                            InserirRespostaAntiga(listUsuario[0].IDUsuario);

                            InserirSimuladorProdutoAntigo(listUsuario[0].IDUsuario);

                            InserirSimuladorProdutoAntigoSubs(listUsuario[0].IDUsuario);

                            InserirIncompleta(listUsuario[0].IDUsuario, listUsuario[0].CodigoColaborador);

                            InserirIncompletaResposta(listUsuario[0].IDUsuario);

                            InserirHistoricoTColetor(ServicoColetorVO.NumeroColetor);

                            InserirHistoricoTSincronismo(listUsuario[0].IDUsuario);

                            InserirFaixa(listUsuario[0].IDUsuario);

                            AlterarHistoricoTSincronismoNumDownload();

                            AlterarHistoricoTColetorNumSincronismo();
                        }

                        InserirProfissao();
                        InserirOrigemVenda();
                        InserirParametro();
                        InserirPlanoProtecao();
                        InserirPlanoProtecaoFuneral();
                        InserirPlanoProtecaoRenda();
                        InserirPlanoSenior();
                        InserirPlanoSeniorFuneral();
                        InserirPlanoCasal();
                        InserirPlanoCasalFuneral();
                    }

                    CompactarBancoEnviarFTP(ServicoColetorVO.BancoMobile);

                    return ServicoColetorVO.BancoMobile;
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(ServicoColetorVO.BancoMobile))
                    File.Delete(ServicoColetorVO.BancoMobile);
                throw;
            }
        }

        public bool ExportarBanco(string numeroColetor, string versao, out int numUpload)
        {
            try
            {
                VersaoSistema = versao;

                PreencherServiceColetorVO(numeroColetor);

                numUpload = 0;

                if (DescompactarBancoFTP(ServicoColetorVO.BancoMobile + ".gz"))
                {
                    //TODO BACKUP
                    BackupColetor();

                    //TODO ACERTAR BANCO PELA VERSAO
                    VersaoColetor();

                    TColetorVO filtroColetor = new TColetorVO();
                    filtroColetor.NumeroSerie = ServicoColetorVO.NumeroColetor;
                    List<TColetorVO> listColetor = ControllerColetor.Listar(filtroColetor);

                    if (listColetor.Count > 0)
                    {
                        TUsuarioVO filtroUsuario = new TUsuarioVO();
                        filtroUsuario.CodigoColaborador = listColetor[0].IDUsuarioResponsavel.GetValueOrDefault();
                        List<TUsuarioVO> listUsuario = ControllerUsuario.Listar(filtroUsuario);

                        if (listUsuario.Count > 0)
                        {
                            ValidarEntrevistaCompleta();

                            InserirHistoricoTColetor(ServicoColetorVO.NumeroColetor);

                            InserirHistoricoTSincronismo(listUsuario[0].IDUsuario);

                            InserirMobileTFaixa();                            

                            InserirMobileTEntrevista();

                            InserirMobileTEntrevistado();

                            InserirMobileTEntrevistadoEndereco();

                            InserirMobileTResposta();

                            InserirMobileTSimuladorProduto();

                            InserirMobileTSimuladorSubRenda();

                            InserirMobileTSimuladorSubAgregado();

                            InserirMobileTSimuladorSubFuneral();

                            InserirMobileTIncompleta();

                            InserirMobileTIncompletaResposta();

                            InserirMobileTAgendamento();

                            AlterarHistoricoTSincronismoNumUpload();

                            AlterarHistoricoTColetorNumSincronismo();
                        }
                    }
                }

                if (File.Exists(ServicoColetorVO.BancoMobile))
                    File.Delete(ServicoColetorVO.BancoMobile);

                numUpload = NumeroUpload;

                return true;
            }
            catch (Exception)
            {

                if (File.Exists(ServicoColetorVO.BancoMobile))
                {
                    string erroDiretorio = WebConfigurationManager.AppSettings["BancoERRO"];

                    if (!Directory.Exists(erroDiretorio))
                        Directory.CreateDirectory(erroDiretorio);

                    File.Copy(ServicoColetorVO.BancoMobile, ServicoColetorVO.BancoERRO);
                    File.Delete(ServicoColetorVO.BancoMobile);
                }

                throw;
            }
        }

        public bool ExportarBancoTeste(string numeroColetor, string versao)
        {
            try
            {
                VersaoSistema = versao;

                PreencherServiceColetorVO(numeroColetor);                              

                if (DescompactarBancoFTP(ServicoColetorVO.BancoMobile + ".gz"))
                {
                    //TODO BACKUP
                    BackupColetor();

                    //TODO ACERTAR BANCO PELA VERSAO
                    VersaoColetor();

                    TColetorVO filtroColetor = new TColetorVO();
                    filtroColetor.NumeroSerie = ServicoColetorVO.NumeroColetor;
                    List<TColetorVO> listColetor = ControllerColetor.Listar(filtroColetor);

                    if (listColetor.Count > 0)
                    {
                        TUsuarioVO filtroUsuario = new TUsuarioVO();
                        filtroUsuario.CodigoColaborador = listColetor[0].IDUsuarioResponsavel.GetValueOrDefault();
                        List<TUsuarioVO> listUsuario = ControllerUsuario.Listar(filtroUsuario);

                        if (listUsuario.Count > 0)
                        {
                            ValidarEntrevistaCompleta();

                            InserirHistoricoTColetor(ServicoColetorVO.NumeroColetor);

                            InserirHistoricoTSincronismo(listUsuario[0].IDUsuario);

                            InserirMobileTFaixa();

                            InserirMobileTEntrevista();

                            InserirMobileTEntrevistado();

                            InserirMobileTEntrevistadoEndereco();

                            InserirMobileTResposta();

                            InserirMobileTSimuladorProduto();

                            InserirMobileTSimuladorSubRenda();

                            InserirMobileTSimuladorSubAgregado();

                            InserirMobileTSimuladorSubFuneral();

                            InserirMobileTIncompleta();

                            InserirMobileTIncompletaResposta();

                            InserirMobileTAgendamento();

                            AlterarHistoricoTSincronismoNumUpload();

                            AlterarHistoricoTColetorNumSincronismo();
                        }
                    }
                }

                if (File.Exists(ServicoColetorVO.BancoMobile))
                    File.Delete(ServicoColetorVO.BancoMobile);
                               

                return true;
            }
            catch (Exception)
            {

                if (File.Exists(ServicoColetorVO.BancoMobile))
                {
                    File.Copy(ServicoColetorVO.BancoMobile, ServicoColetorVO.BancoERRO);
                    File.Delete(ServicoColetorVO.BancoMobile);
                }

                throw;
            }
        }

        public void PreencherServiceColetorVO(string numeroColetor)
        {
            ServicoColetorVO.NumeroColetor = numeroColetor;
            ServicoColetorVO.BancoCorreio = WebConfigurationManager.AppSettings["BancoCorreio"].Replace("#NUMEROCOLETOR#", ServicoColetorVO.NumeroColetor);
            ServicoColetorVO.BancoERRO = WebConfigurationManager.AppSettings["BancoERRO"] + @"\" + DateTime.Now.ToString("yyyymmddhhMMss") + ServicoColetorVO.NumeroColetor + ".sdf";
            ServicoColetorVO.BancoMobile = WebConfigurationManager.AppSettings["BancoMobile"].Replace("#NUMEROCOLETOR#", ServicoColetorVO.NumeroColetor);
            ServicoColetorVO.ConnectionStringCorreio = WebConfigurationManager.ConnectionStrings["ConnectionStringCorreio"].ConnectionString.Replace("#NUMEROCOLETOR#", ServicoColetorVO.NumeroColetor);
            ServicoColetorVO.ConnectionStringMobile = WebConfigurationManager.ConnectionStrings["ConnectionStringMobile"].ConnectionString.Replace("#NUMEROCOLETOR#", ServicoColetorVO.NumeroColetor);
            ServicoColetorVO.ConnectionStringWEB = WebConfigurationManager.ConnectionStrings["ConnectionStringWEB"].ConnectionString;
            ServicoColetorVO.DiretorioMobile = WebConfigurationManager.AppSettings["DiretorioMobile"].Replace("#NUMEROCOLETOR#", ServicoColetorVO.NumeroColetor);
            ServicoColetorVO.DiretorioVersao = WebConfigurationManager.AppSettings["DiretorioVersao"];
        }

        public string VerSenhaHash(string password)
        {
            return Util.Util.GeraHashMD5(password);
        }

        private void BackupColetor()
        {
            try
            {
                string backupDiretorio = WebConfigurationManager.AppSettings["DiretorioBACKUP"];

                if (!Directory.Exists(backupDiretorio))
                    Directory.CreateDirectory(backupDiretorio);

                string backupBanco = backupDiretorio + @"\" + ServicoColetorVO.NumeroColetor + @".sdf";

                if (File.Exists(backupBanco))
                    File.Delete(backupBanco);

                File.Copy(ServicoColetorVO.BancoMobile, backupBanco);
                
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void VersaoColetor()
        {
            try
            {    
                if (new Version(VersaoSistema) == new Version("1.0.3.0"))
                    ExecutarScriptBancoColetor("1_0_3_3.txt");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ExecutarScriptBancoColetor(string nomeVersao)
        {
            try
            {
                string caminho = ServicoColetorVO.DiretorioVersao + nomeVersao;

                FileInfo arquivoVersao = new FileInfo(caminho);

                if (arquivoVersao.Exists)
                {
                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        string[] script = arquivoVersao.OpenText().ReadToEnd().Split(new string[] { "GO" }, StringSplitOptions.None);

                        foreach (string command in script)
                        {
                            string textCommand = command.Replace(@"\n", string.Empty).Replace(@"\r", string.Empty);
                            if (!string.IsNullOrEmpty(textCommand) && !textCommand.Equals("\r\n"))
                            {
                                SqlCeCommand cmdScript = new SqlCeCommand(command, connMobile);
                                cmdScript.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExcluirBackupColetor()
        {
            try
            {
                string backupDiretorio = WebConfigurationManager.AppSettings["DiretorioBACKUP"];

                if (Directory.Exists(backupDiretorio))
                    Directory.Delete(backupDiretorio);

                if (!Directory.Exists(backupDiretorio))
                    Directory.CreateDirectory(backupDiretorio);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region [ CREATE ]

        private bool CriarBancoDados()
        {
            try
            {
                if (!Directory.Exists(ServicoColetorVO.DiretorioMobile))
                    Directory.CreateDirectory(ServicoColetorVO.DiretorioMobile);

                if (File.Exists(ServicoColetorVO.BancoMobile))
                    File.Delete(ServicoColetorVO.BancoMobile);

                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
                SqlCeEngine engine = new SqlCeEngine(ServicoColetorVO.ConnectionStringMobile);
                engine.CreateDatabase();
                engine.Dispose();
                return CriarTabelas();
            }
            catch
            {
                return false;
            }
        }

        private bool CriarTabelas()
        {
            bool retorno = true;
            try
            {

                SqlCeConnection myConn = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile);

                myConn.Open();

                try
                {
                    foreach (string command in TabelasSINAF())
                    {
                        SqlCeCommand myCommand = new SqlCeCommand(command, myConn);

                        try
                        {
                            myCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            retorno = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    retorno = false;
                }

                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                retorno = false;
            }
            return retorno;
        }

        private List<string> TabelasSINAF()
        {
            List<string> strTabelas = new List<string>();

            #region [ TUsuario ]

            strTabelas.Add("CREATE TABLE [TUsuario] ( " +
                        "  [IDUsuario] bigint NOT NULL " +
                        ", [Nome] nvarchar(50) NOT NULL " +
                        ", [Login] nvarchar(50) NOT NULL " +
                        ", [Senha] nvarchar(50) NOT NULL " +
                        ", [IDPerfil] int NOT NULL " +
                        ", [Email] nvarchar(50) NULL " +
                        ", [CodigoColaborador] int " +
                        ", [Unidade] nvarchar(50) " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TUsuario] ADD CONSTRAINT [TUsuario_PK] PRIMARY KEY ([IDUsuario]); ");

            #endregion

            #region [ TProfissao ]

            strTabelas.Add("CREATE TABLE [TProfissao]  ( " +
                        "  [IDProfissao] int NOT NULL " +
                        ", [NomeProfissao] nvarchar(100) NOT NULL " +
                        ", [CapitalLimitado] bit NOT NULL  " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TProfissao] ADD CONSTRAINT [TProfissao_PK] PRIMARY KEY ([IDProfissao]); ");

            #endregion

            #region [ TOrigemVenda ]

            strTabelas.Add("CREATE TABLE [TOrigemVenda] ( " +
                        "  [IDOrigemVenda] int NOT NULL " +
                        ", [CodigoOrigemVenda] nvarchar(3) NOT NULL " +
                        ", [NomeOrigemVenda] nvarchar(50) NOT NULL " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TOrigemVenda] ADD CONSTRAINT [TOrigemVenda_PK] PRIMARY KEY ([IDOrigemVenda]); ");

            #endregion

            #region [ TFaixa ]

            strTabelas.Add("CREATE TABLE [TFaixa] ( " +
                        "  [IDFaixa] int NOT NULL " +
                        ", [CodigoFaixa] bigint NOT NULL " +
                        ", [Usado] bit NULL " +
                        ", [IDResponsavel] int NULL " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TFaixa] ADD CONSTRAINT [TFaixa_PK] PRIMARY KEY ([IDFaixa]); ");

            #endregion

            #region [ TEntrevista ]

            strTabelas.Add("CREATE TABLE [TEntrevista] ( " +
                        "  [IDEntrevista] int IDENTITY " +
                        ", [CodigoEntrevista] bigint NOT NULL " +
                        ", [CodigoColaborador] smallint " +
                        ", [DataEntrevista] datetime " +
                        ", [CodigoUsuario] int NOT NULL " +
                        ", [DataInclusao] datetime " +
                        ", [CodigoQuestionario] smallint " +
                        ", [OrigemVenda] nvarchar(3) " +
                        ", [Completa] bit" +
                        ", [Motivo] nvarchar(50)" +
                        "); ");

            strTabelas.Add("ALTER TABLE [TEntrevista] ADD CONSTRAINT [TEntrevista_PK] PRIMARY KEY ([IDEntrevista]); ");

            #endregion

            #region [ TEntrevistado ]

            strTabelas.Add("CREATE TABLE [TEntrevistado] ( " +
                        "  [IDEntrevistado] int IDENTITY " +
                        ", [CodigoEntrevista] bigint NOT NULL " +
                        ", [Nome] nvarchar(50)" +
                        ", [CPF] nvarchar(14) " +
                        ", [DataNascimento] datetime " +
                        ", [EstadoCivil] smallint " +
                        ", [IDProfissao] smallint " +
                        ", [FaixaEtaria] smallint " +
                        ", [FaixaEtariaConjuge] smallint " +
                        ", [IDProfissaoConjuge] smallint " +
                        ", [DataNascimentoConjuge] datetime " +
                        ", [CapitalLimitado] nvarchar(1) " +
                        ", [CapitalLimitadoConjuge] nvarchar(1) " +
                        ", [DDD] nvarchar(2) " +
                        ", [Telefone] nvarchar(13) " +
                        ", [DDDCelular] nvarchar(2) " +
                        ", [Celular] nvarchar(13) " +
                        ", [Sexo] nvarchar(1) " +
                        ", [Informacao] bit " +
                       "); ");

            strTabelas.Add("ALTER TABLE [TEntrevistado] ADD CONSTRAINT [TEntrevistado_PK] PRIMARY KEY ([IDEntrevistado]); ");

            #endregion

            #region [ TEntrevistadoEndereco ]

            strTabelas.Add("CREATE TABLE [TEntrevistadoEndereco] ( " +
                        "  [IDEntrevistadoEndereco] int IDENTITY " +
                        ", [CodigoEntrevista] bigint NOT NULL " +
                        ", [Endereco] nvarchar(50)" +
                        ", [Numero] int " +
                        ", [Bairro] nvarchar(50) " +
                        ", [Cidade] nvarchar(50) " +
                        ", [UF] nvarchar(2) " +
                        ", [CEP] nvarchar(8) " +
                        ", [Complemento] nvarchar(50) " +
                        ", [Email] nvarchar(50) " +
                       "); ");

            strTabelas.Add("ALTER TABLE [TEntrevistadoEndereco] ADD CONSTRAINT [TEntrevistadoEndereco_PK] PRIMARY KEY ([IDEntrevistadoEndereco]); ");

            #endregion

            #region [ TResposta ]

            strTabelas.Add("CREATE TABLE [TResposta] ( " +
                        "  [IDResposta] int IDENTITY " +
                        ", [CodigoEntrevista] bigint NOT NULL " +
                        ", [CodigoPergunta] smallint" +
                        ", [CodigoOpcao] int " +
                        ", [CodigoSeqResposta] int " +
                        ", [TextoResposta] nvarchar(50) " +
                        ", [TextoSubResposta] nvarchar(50) " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TResposta] ADD CONSTRAINT [TResposta_PK] PRIMARY KEY ([IDResposta]); ");

            #endregion

            #region [ TPlanoProtecao ]

            strTabelas.Add("CREATE TABLE [TPlanoProtecao] ( " +
                        "  [IDPlanoProtecao] bigint NOT NULL " +
                        ", [Codigo] int NOT NULL " +
                        ", [NomePlano] nvarchar(50) NOT NULL " +
                        ", [CoberturaMorte] numeric(8,2) NOT NULL " +
                        ", [CoberturaAcidente] numeric(8,2) NOT NULL " +
                        ", [CoberturaEmergencia] numeric(8,2) NOT NULL " +
                        ", [Premio_18_30] numeric(8,2) " +
                        ", [Premio_31_40] numeric(8,2) " +
                        ", [Premio_41_45] numeric(8,2) " +
                        ", [Premio_46_50] numeric(8,2) " +
                        ", [Premio_51_55] numeric(8,2) " +
                        ", [Premio_56_60] numeric(8,2) " +
                        ", [Premio_61_65] numeric(8,2) " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TPlanoProtecao] ADD CONSTRAINT [TPlanoProtecao_PK] PRIMARY KEY ([IDPlanoProtecao]); ");

            #endregion

            #region [ TPlanoProtecaoFuneral ]

            strTabelas.Add("CREATE TABLE [TPlanoProtecaoFuneral] ( " +
                        "  [IDPlanoProtecaoFuneral] bigint NOT NULL " +
                        ", [Codigo] int NOT NULL " +
                        ", [Categoria] nvarchar(50) NOT NULL " +
                        ", [Ate_20] numeric(8,2) " +
                        ", [De_21_40] numeric(8,2) " +
                        ", [De_41_50] numeric(8,2) " +
                        ", [De_51_60] numeric(8,2) " +
                        ", [De_61_65] numeric(8,2) " +
                        ", [De_66_70] numeric(8,2) " +
                        ", [De_71_75] numeric(8,2) " +
                        ", [De_76_80] numeric(8,2) " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TPlanoProtecaoFuneral] ADD CONSTRAINT [TPlanoProtecaoFuneral_PK] PRIMARY KEY ([IDPlanoProtecaoFuneral]); ");

            #endregion

            #region [ TPlanoProtecaoRenda ]

            strTabelas.Add("CREATE TABLE [TPlanoProtecaoRenda] ( " +
                        "  [IDPlanoProtecaoRenda] bigint NOT NULL " +
                        ", [RendaPeriodo] nvarchar(50) NOT NULL " +
                        ", [CoberturaRendaMensal] numeric(8,2) NOT NULL " +
                        ", [CoberturaCapitalTotal] numeric(8,2) NOT NULL " +
                        ", [Premio_18_30] numeric(8,2) " +
                        ", [Premio_31_40] numeric(8,2) " +
                        ", [Premio_41_45] numeric(8,2) " +
                        ", [Premio_46_50] numeric(8,2) " +
                        ", [Premio_51_55] numeric(8,2) " +
                        ", [Premio_56_60] numeric(8,2) " +
                        ", [Premio_61_65] numeric(8,2) " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TPlanoProtecaoRenda] ADD CONSTRAINT [TPlanoProtecaoRenda_PK] PRIMARY KEY ([IDPlanoProtecaoRenda]); ");

            #endregion

            #region [ TPlanoSenior ]

            strTabelas.Add("CREATE TABLE [TPlanoSenior] ( " +
                        "  [IDPlanoSenior] bigint NOT NULL " +
                        ", [Codigo] int NOT NULL " +
                        ", [NomePlano] nvarchar(50) NOT NULL  " +
                        ", [CoberturaMorte] numeric(8,2) NOT NULL " +
                        ", [Premio_61_65] numeric(8,2) " +
                        ", [Premio_66_70] numeric(8,2) " +
                        ", [Premio_71_75] numeric(8,2) " +
                        ", [Premio_76_80] numeric(8,2) " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TPlanoSenior] ADD CONSTRAINT [TPlanoSenior_PK] PRIMARY KEY ([IDPlanoSenior]); ");

            #endregion

            #region [ TPlanoSeniorFuneral ]

            strTabelas.Add("CREATE TABLE [TPlanoSeniorFuneral] ( " +
                        "  [IDPlanoSeniorFuneral] bigint NOT NULL " +
                        ", [Codigo] int NOT NULL " +
                        ", [Categoria] nvarchar(50) NOT NULL " +
                        ", [Ate_20] numeric(8,2)  " +
                        ", [De_21_40] numeric(8,2) " +
                        ", [De_41_50] numeric(8,2) " +
                        ", [De_51_60] numeric(8,2) " +
                        ", [De_61_65] numeric(8,2) " +
                        ", [De_66_70] numeric(8,2) " +
                        ", [De_71_75] numeric(8,2) " +
                        ", [De_76_80] numeric(8,2) " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TPlanoSeniorFuneral] ADD CONSTRAINT [TPlanoSeniorFuneral_PK] PRIMARY KEY ([IDPlanoSeniorFuneral]); ");

            #endregion

            #region [ TPlanoCasal ]

            strTabelas.Add("CREATE TABLE [TPlanoCasal] ( " +
                        "  [IDPlanoCasal] bigint NOT NULL " +
                        ", [Codigo] int NOT NULL " +
                        ", [NomePlano] nvarchar(50) NOT NULL  " +
                        ", [CoberturaMorte] numeric(8,2) NOT NULL " +
                        ", [CoberturaConjuge] numeric(8,2) NOT NULL " +
                        ", [Premio_61_65] numeric(8,2) " +
                        ", [Premio_66_70] numeric(8,2) " +
                        ", [Premio_71_75] numeric(8,2) " +
                        ", [Premio_76_80] numeric(8,2) " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TPlanoCasal] ADD CONSTRAINT [TPlanoCasal_PK] PRIMARY KEY ([IDPlanoCasal]); ");

            #endregion

            #region [ TPlanoCasalFuneral ]

            strTabelas.Add("CREATE TABLE [TPlanoCasalFuneral] ( " +
                        "  [IDPlanoCasalFuneral] bigint NOT NULL " +
                        ", [Codigo] int NOT NULL " +
                        ", [Categoria] nvarchar(50) NOT NULL " +
                        ", [Ate_20] numeric(8,2)  " +
                        ", [De_21_40] numeric(8,2) " +
                        ", [De_41_50] numeric(8,2) " +
                        ", [De_51_60] numeric(8,2) " +
                        ", [De_61_65] numeric(8,2) " +
                        ", [De_66_70] numeric(8,2) " +
                        ", [De_71_75] numeric(8,2) " +
                        ", [De_76_80] numeric(8,2) " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TPlanoCasalFuneral] ADD CONSTRAINT [TPlanoCasalFuneral_PK] PRIMARY KEY ([IDPlanoCasalFuneral]); ");

            #endregion

            #region [ TSimuladorProduto ]

            strTabelas.Add("CREATE TABLE [TSimuladorProduto] ( " +
                        "  [IDSimuladorProduto] bigint IDENTITY " +
                        ", [IDEntrevista] bigint NOT NULL " +
                        ", [Produto] nvarchar(50) NOT NULL  " +
                        ", [PremioTotal] numeric(8,2) NOT NULL" +
                        ", [FaixaEtaria] int NULL " +
                        ", [FaixaEtariaConjuge] int NULL " +
                        ", [RespostaBaseRenda] int NULL " +
                        ", [RespostaBaseDisposto] int NULL " +
                        ", [TipoRegistro] nchar(1) NOT NULL  " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TSimuladorProduto] ADD CONSTRAINT [TSimuladorProduto_PK] PRIMARY KEY ([IDSimuladorProduto]); ");

            #endregion

            #region [ TSimuladorSubRenda ]

            strTabelas.Add("CREATE TABLE [TSimuladorSubRenda] ( " +
                        "  [IDSimuladorSubRenda] bigint IDENTITY " +
                        ", [IDSimuladorProduto] bigint NOT NULL " +
                        ", [Periodo] nvarchar(50) NOT NULL  " +
                        ", [ValorRenda] numeric(8,2) NOT NULL" +
                        ", [Capital] numeric(8,2) NOT NULL" +
                        ", [PremioRenda] numeric(8,2) NOT NULL" +
                        "); ");

            strTabelas.Add("ALTER TABLE [TSimuladorSubRenda] ADD CONSTRAINT [TSimuladorSubRenda_PK] PRIMARY KEY ([IDSimuladorSubRenda]); ");

            #endregion

            #region [ TSimuladorSubAgregado ]

            strTabelas.Add("CREATE TABLE [TSimuladorSubAgregado] ( " +
                        "  [IDSimuladorSubAgregado] bigint IDENTITY " +
                        ", [IDSimuladorProduto] bigint NOT NULL " +
                        ", [GrauParentesco] nvarchar(50) NOT NULL  " +
                        ", [Idade] int NOT NULL" +
                        ", [PremioAgregado] numeric(8,2) NOT NULL" +
                        ", [Funeral] nvarchar(50) NOT NULL" +
                        "); ");

            strTabelas.Add("ALTER TABLE [TSimuladorSubAgregado] ADD CONSTRAINT [TSimuladorSubAgregado_PK] PRIMARY KEY ([IDSimuladorSubAgregado]); ");

            #endregion

            #region [ TSimuladorSubFuneral ]

            strTabelas.Add("CREATE TABLE [TSimuladorSubFuneral] ( " +
                        "  [IDSimuladorSubFuneral] bigint IDENTITY " +
                        ", [IDSimuladorProduto] bigint NOT NULL " +
                        ", [ProtecaoCoberturaMorte] numeric(8,2) " +
                        ", [ProtecaoCoberturaAcidente] numeric(8,2) " +
                        ", [ProtecaoCoberturaEmergencia] numeric(8,2) " +
                        ", [ProtecaoCategoria] nvarchar(50) " +
                        ", [ProtecaoPremio] numeric(8,2) " +
                        ", [SeniorCoberturaMorte] numeric(8,2) " +
                        ", [SeniorCategoria] nvarchar(50) " +
                        ", [SeniorPremio] numeric(8,2) " +
                        ", [CasalCoberturaMorte] numeric(8,2) " +
                        ", [CasalCoberturaConjuge] numeric(8,2) " +
                        ", [CasalCategoria] nvarchar(50) " +
                        ", [CasalPremio] numeric(8,2) " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TSimuladorSubFuneral] ADD CONSTRAINT [TSimuladorSubFuneral_PK] PRIMARY KEY ([IDSimuladorSubFuneral]); ");

            #endregion

            #region [ TAgendamento ]

            strTabelas.Add("CREATE TABLE [TAgendamento] ( " +
                        "  [IDAgendamento] int NOT NULL " +
                        ", [Nome] nvarchar(50)" +
                        ", [DataNascimento] datetime " +
                        ", [Telefone] nvarchar(15) " +
                        ", [Celular] nvarchar(15) " +
                        ", [Email] nvarchar(50) " +
                        ", [CEP] nvarchar(8) " +
                        ", [Logradouro] nvarchar(100)" +
                        ", [Numero] int " +
                        ", [Complemento] nvarchar(50) " +
                        ", [Bairro] nvarchar(100) " +
                        ", [Cidade] nvarchar(100) " +
                        ", [UF] nvarchar(2) " +
                        ", [PontoReferencia] nvarchar(250) " +
                        ", [IDUsuarioAgendamento] int " +
                        ", [IDUsuarioVendedor] int " +
                        ", [IDAtendimento] int " +
                        ", [Site] bit " +
                        ", [Excluir] bit " +
                        ", [DataAgendada] datetime " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TAgendamento] ADD CONSTRAINT [TAgendamento_PK] PRIMARY KEY ([IDAgendamento]); ");

            #endregion

            #region [ TParametro ]

            strTabelas.Add("CREATE TABLE [TParametro] ( " +
                        "  [IDParametro] int NOT NULL " +
                        ", [TempoLogOff] int " +
                        ", [PrazoSincronismoDia] int  " +
                        ", [EstoqueMaximoColetor] int  " +
                        ", [EstoqueMinimoColetor] int  " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TParametro] ADD CONSTRAINT [TParametro_PK] PRIMARY KEY ([IDParametro]); ");

            #endregion

            #region [ TGPS ]

            strTabelas.Add("CREATE TABLE [TGPS] ( " +
                        "  [IDGPS] int IDENTITY " +
                        ", [CodigoEntrevista] bigint " +
                        ", [Latitude] nvarchar(15)  " +
                        ", [Longitude] nvarchar(15)  " +
                        ", [DataCadastro] datetime  " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TGPS] ADD CONSTRAINT [TGPS_PK] PRIMARY KEY ([IDGPS]); ");

            #endregion

            return strTabelas;
        }

        private bool CriarBancoCorreio()
        {
            try
            {
                if (!Directory.Exists(ServicoColetorVO.DiretorioMobile))
                    Directory.CreateDirectory(ServicoColetorVO.DiretorioMobile);

                if (File.Exists(ServicoColetorVO.BancoCorreio))
                    File.Delete(ServicoColetorVO.BancoCorreio);

                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
                SqlCeEngine engine = new SqlCeEngine(ServicoColetorVO.ConnectionStringCorreio);
                engine.CreateDatabase();
                engine.Dispose();
                return CriarTabelasCorreio();
            }
            catch
            {
                return false;
            }
        }

        private bool CriarTabelasCorreio()
        {
            bool retorno = true;
            try
            {

                SqlCeConnection myConn = new SqlCeConnection(ServicoColetorVO.ConnectionStringCorreio);

                myConn.Open();

                try
                {
                    foreach (string command in TabelasCorreio())
                    {
                        SqlCeCommand myCommand = new SqlCeCommand(command, myConn);

                        try
                        {
                            myCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            retorno = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    retorno = false;
                }

                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                retorno = false;
            }
            return retorno;
        }

        private List<string> TabelasCorreio()
        {
            List<string> strTabelas = new List<string>();

            #region [ TEstado ]

            strTabelas.Add("CREATE TABLE [TEstado] ( " +
                        "  [IDEstado] int NOT NULL " +
                        ", [Sigla] nvarchar(2) NOT NULL " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TEstado] ADD CONSTRAINT [TEstado_PK] PRIMARY KEY ([IDEstado]); ");

            #endregion

            #region [ TCidade ]

            strTabelas.Add("CREATE TABLE [TCidade] ( " +
                        "  [IDCidade] int NOT NULL " +
                        ", [NomeCidade] nvarchar(100) NOT NULL " +
                        ", [IDEstado] int NOT NULL " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TCidade] ADD CONSTRAINT [TCidade_PK] PRIMARY KEY ([IDCidade]); ");
            strTabelas.Add("ALTER TABLE [TCidade] ADD CONSTRAINT [TEstado_FK] FOREIGN KEY ([IDEstado]) REFERENCES [TEstado]([IDEstado]); ");

            #endregion

            #region [ TBairro ]

            strTabelas.Add("CREATE TABLE [TBairro] ( " +
                        "  [IDBairro] int NOT NULL " +
                        ", [NomeBairro] nvarchar(100) NOT NULL " +
                        ", [IDCidade] int NOT NULL " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TBairro] ADD CONSTRAINT [TBairro_PK] PRIMARY KEY ([IDBairro]); ");
            strTabelas.Add("ALTER TABLE [TBairro] ADD CONSTRAINT [TCidade_FK] FOREIGN KEY ([IDCidade]) REFERENCES [TCidade]([IDCidade]); ");

            #endregion

            #region [ TLogradouro ]

            strTabelas.Add("CREATE TABLE [TLogradouro] ( " +
                        "  [IDLogradouro] int NOT NULL " +
                        ", [NomeLogradouro] nvarchar(100) NOT NULL " +
                        ", [IDBairro] int NULL " +
                        ", [CEP] int NOT NULL " +
                        ", [IDCidade] int NULL " +
                        "); ");

            strTabelas.Add("ALTER TABLE [TLogradouro] ADD CONSTRAINT [TLogradouro_PK] PRIMARY KEY ([IDLogradouro]); ");
            strTabelas.Add("ALTER TABLE [TLogradouro] ADD CONSTRAINT [TBairro_FK] FOREIGN KEY ([IDBairro]) REFERENCES [TBairro]([IDBairro]); ");
            strTabelas.Add("ALTER TABLE [TLogradouro] ADD CONSTRAINT [TCidade_FK] FOREIGN KEY ([IDCidade]) REFERENCES [TCidade]([IDCidade]); ");

            #endregion

            return strTabelas;
        }

        #endregion

        #region [ SELECT ]

        private void VerificarParametros()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTParametro = new StringBuilder();

                queryTParametro.Append(@" SELECT EstoqueMaximoColetor          ");
                queryTParametro.Append(@"      , EstoqueMinimoColetor          ");
                queryTParametro.Append(@"      , TempoEntrevistaColetor        ");
                queryTParametro.Append(@"      , TempoEntrevistaIncompleta     ");
                queryTParametro.Append(@"   FROM TParametro                    ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaParametro = new SqlCommand(queryTParametro.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaParametro.ExecuteReader();
                    DataTable dadosParametros = new DataTable("TParametros");
                    dadosParametros.Load(reader);

                    if (dadosParametros.Rows.Count > 0)
                    {
                        ServicoColetorVO.EstoqueMaximo = Convert.ToInt32(dadosParametros.Rows[0]["EstoqueMaximoColetor"]);

                        ServicoColetorVO.EstoqueMinimo = Convert.ToInt32(dadosParametros.Rows[0]["EstoqueMinimoColetor"]);

                        ServicoColetorVO.TempoEntrevistaColetor = Convert.ToInt32(dadosParametros.Rows[0]["TempoEntrevistaColetor"]);

                        ServicoColetorVO.TempoEntrevistaIncompleta = Convert.ToInt32(dadosParametros.Rows[0]["TempoEntrevistaIncompleta"]);
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string VerificarIDAtendimento(int idUsuario, string bairro, string cidade)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTUsuario = new StringBuilder();

                queryTUsuario.Append(@" SELECT Unidade                 ");
                queryTUsuario.Append(@"   FROM TUsuario                ");
                queryTUsuario.Append(@"  WHERE IDUsuario = @IDUSUARIO  ");

                StringBuilder queryTBairro = new StringBuilder();

                queryTBairro.Append(@" SELECT IDBairro                ");
                queryTBairro.Append(@"   FROM TBairro                 ");
                queryTBairro.Append(@"  WHERE NomeBairro = '@BAIRRO'  ");

                StringBuilder queryTCidade = new StringBuilder();

                queryTCidade.Append(@" SELECT IDCidade                ");
                queryTCidade.Append(@"   FROM TCidade                 ");
                queryTCidade.Append(@"  WHERE NomeCidade = '@CIDADE'  ");

                StringBuilder queryTFilial = new StringBuilder();

                queryTFilial.Append(@" SELECT IDFilial                ");
                queryTFilial.Append(@"   FROM TFilial                 ");
                queryTFilial.Append(@"  WHERE NomeFilial = '@FILIAL'  ");

                StringBuilder queryTAtendimento = new StringBuilder();

                queryTAtendimento.Append(@" SELECT IDAtendimento                ");
                queryTAtendimento.Append(@"   FROM TAtendimento                 ");
                queryTAtendimento.Append(@"  WHERE IDFilial = @IDFILIAL         ");
                queryTAtendimento.Append(@"    AND IDCidade = @IDCIDADE         ");
                queryTAtendimento.Append(@"    AND IDBairro = @IDBAIRRO         ");

                #endregion

                #region [ EXECUTE ]

                int idBairro = 0;
                int idCidade = 0;
                int idFilial = 0;

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaUsuario = new SqlCommand(queryTUsuario.ToString().Replace("@IDUSUARIO", idUsuario.ToString()), connWEB);
                    IDataReader readerUsuario = cmdLerTabelaUsuario.ExecuteReader();
                    DataTable dadosUsuario = new DataTable("TUsuario");
                    dadosUsuario.Load(readerUsuario);

                    if (dadosUsuario.Rows.Count > 0)
                    {
                        SqlCommand cmdLerTabelaBairro = new SqlCommand(queryTBairro.ToString().Replace("@BAIRRO", bairro), connWEB);
                        IDataReader readerBairro = cmdLerTabelaBairro.ExecuteReader();
                        DataTable dadosBairro = new DataTable("TBairro");
                        dadosBairro.Load(readerBairro);
                        if (dadosBairro.Rows.Count > 0)
                            idBairro = Convert.ToInt32(dadosBairro.Rows[0]["IDBairro"]);

                        SqlCommand cmdLerTabelaCidade = new SqlCommand(queryTCidade.ToString().Replace("@CIDADE", cidade), connWEB);
                        IDataReader readerCidade = cmdLerTabelaCidade.ExecuteReader();
                        DataTable dadosCidade = new DataTable("TCidade");
                        dadosCidade.Load(readerCidade);
                        if (dadosCidade.Rows.Count > 0)
                            idCidade = Convert.ToInt32(dadosCidade.Rows[0]["IDCidade"]);

                        SqlCommand cmdLerTabelaFilial = new SqlCommand(queryTFilial.ToString().Replace("@FILIAL", dadosUsuario.Rows[0]["Unidade"].ToString()), connWEB);
                        IDataReader readerFilial = cmdLerTabelaFilial.ExecuteReader();
                        DataTable dadosFilial = new DataTable("TFilial");
                        dadosFilial.Load(readerFilial);
                        if (dadosFilial.Rows.Count > 0)
                            idFilial = Convert.ToInt32(dadosFilial.Rows[0]["IDFilial"]);

                        SqlCommand cmdLerTabelaAtendimento = new SqlCommand(queryTAtendimento.ToString().Replace("@IDFILIAL", idFilial.ToString()).Replace("@IDCIDADE", idCidade.ToString()).Replace("@IDBAIRRO", idBairro.ToString()), connWEB);
                        IDataReader readerAtendimento = cmdLerTabelaAtendimento.ExecuteReader();
                        DataTable dadosAtendimento = new DataTable("TAtendimento");
                        dadosAtendimento.Load(readerAtendimento);
                        if (dadosAtendimento.Rows.Count > 0)
                            return dadosAtendimento.Rows[0]["IDAtendimento"].ToString();
                        else
                            return "NULL";
                    }

                    return "NULL";
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ INSERT ]

        private void InserirHistoricoTColetor(string numeroColetor)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTabela = new StringBuilder();

                queryTabela.Append(@" SELECT IDHistoricoColetor                       ");
                queryTabela.Append(@"      , NumeroColetor                            ");
                queryTabela.Append(@"      , DataUltimoSincronismo                    ");
                queryTabela.Append(@"      , NumeroTotalSincronismo                   ");
                queryTabela.Append(@"      , NumeroTotalEntrevista                    ");
                queryTabela.Append(@"      , VersaoSistema                            ");
                queryTabela.Append(@"   FROM HistoricoTColetor                        ");
                queryTabela.Append(@"  WHERE NumeroColetor = '@COLETOR'               ");

                #endregion

                #region [ INSERT ]

                StringBuilder queryInsert = new StringBuilder();

                queryInsert.Append(@" INSERT INTO HistoricoTColetor                   ");
                queryInsert.Append(@"      ( NumeroColetor                            ");
                queryInsert.Append(@"      , DataUltimoSincronismo                    ");
                queryInsert.Append(@"      , NumeroTotalSincronismo                   ");
                queryInsert.Append(@"      , NumeroTotalEntrevista                    ");
                queryInsert.Append(@"      , VersaoSistema          )                 ");
                queryInsert.Append(@" VALUES                                          ");
                queryInsert.Append(@"      ( '@COLETOR'                               ");
                queryInsert.Append(@"      , GetDate()                                ");
                queryInsert.Append(@"      , 0                                        ");
                queryInsert.Append(@"      , 0                                        ");
                queryInsert.Append(@"      , '@VERSAO'               ) ;              ");
                queryInsert.Append(@"       SELECT SCOPE_IDENTITY();                  ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection bancoWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    bancoWEB.Open();

                    SqlCommand cmdLerTabela = new SqlCommand(queryTabela.ToString().Replace("@COLETOR", numeroColetor.ToString()), bancoWEB);
                    IDataReader reader = cmdLerTabela.ExecuteReader();

                    DataTable dadosTabela = new DataTable("HistoricoTColetor");
                    dadosTabela.Load(reader);

                    if (dadosTabela.Rows.Count == 0)
                    {
                        VersaoSistema = WebConfigurationManager.AppSettings["ColetorVersao"];
                        SqlCommand cmdInserirTabela = new SqlCommand(queryInsert.ToString().Replace("@COLETOR", numeroColetor.ToString()).Replace("@VERSAO", VersaoSistema), bancoWEB);
                        IDHistoricoColetor = Convert.ToInt64(cmdInserirTabela.ExecuteScalar());
                    }
                    else
                    {
                        IDHistoricoColetor = Convert.ToInt64(dadosTabela.Rows[0]["IDHistoricoColetor"]);
                    }

                }


                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirHistoricoTSincronismo(int idUsuario)
        {
            try
            {
                #region [ INSERT ]

                StringBuilder queryInsert = new StringBuilder();

                queryInsert.Append(@" INSERT INTO HistoricoTSincronismo               ");
                queryInsert.Append(@"      ( IDHistoricoColetor                       ");
                queryInsert.Append(@"      , DataSincronismo                          ");
                queryInsert.Append(@"      , NumeroUpload                             ");
                queryInsert.Append(@"      , NumeroDownload                           ");
                queryInsert.Append(@"      , IDVendedor              )                ");
                queryInsert.Append(@" VALUES                                          ");
                queryInsert.Append(@"      ( @IDCOLETOR                               ");
                queryInsert.Append(@"      , GetDate()                                ");
                queryInsert.Append(@"      , 0                                        ");
                queryInsert.Append(@"      , 0                                        ");
                queryInsert.Append(@"      , @IDUSUARIO       )                       ");
                queryInsert.Append(@"       SELECT SCOPE_IDENTITY();                  ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection bancoWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    bancoWEB.Open();
                    SqlCommand cmdInserirTabela = new SqlCommand(queryInsert.ToString().Replace("@IDCOLETOR", IDHistoricoColetor.ToString()).Replace("@IDUSUARIO", idUsuario.ToString()), bancoWEB);
                    IDHistoricoTSincronismo = Convert.ToInt64(cmdInserirTabela.ExecuteScalar());
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ UPDATE ]

        private void AlterarHistoricoTColetorNumSincronismo()
        {
            try
            {
                #region [ UPDATE ]

                StringBuilder queryTabelaSincronismo = new StringBuilder();

                queryTabelaSincronismo.Append(@" UPDATE HistoricoTColetor                                                   ");
                queryTabelaSincronismo.Append(@"    SET NumeroTotalSincronismo = NumeroTotalSincronismo + 1                 ");
                queryTabelaSincronismo.Append(@"    , DataUltimoSincronismo = GetDate()                                     ");
                queryTabelaSincronismo.Append(@"  WHERE IDHistoricoColetor = @IDHISTORICO                                   ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    destinationConnection.Open();

                    SqlCommand cmdSincronismo = new SqlCommand(queryTabelaSincronismo.ToString().Replace("@IDHISTORICO", IDHistoricoColetor.ToString()), destinationConnection);
                    cmdSincronismo.ExecuteNonQuery();
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AlterarHistoricoTColetorVersao(string versao, string numeroColetor)
        {
            try
            {
                #region [ UPDATE ]

                StringBuilder queryTabelaSincronismo = new StringBuilder();

                queryTabelaSincronismo.Append(@" UPDATE HistoricoTColetor                                         ");
                queryTabelaSincronismo.Append(@"    SET VersaoSistema = '@VERSAO'                                 ");
                queryTabelaSincronismo.Append(@"  WHERE NumeroColetor = '@NUMERO'                                 ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    destinationConnection.Open();

                    if (!versao.Equals(WebConfigurationManager.AppSettings["ColetorVersao"]))
                        versao = WebConfigurationManager.AppSettings["ColetorVersao"];

                    VersaoSistema = versao;
                    SqlCommand cmdSincronismo = new SqlCommand(queryTabelaSincronismo.ToString().Replace("@VERSAO", versao).Replace("@NUMERO", numeroColetor), destinationConnection);
                    cmdSincronismo.ExecuteNonQuery();
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AlterarHistoricoTSincronismoNumUpload()
        {
            try
            {
                #region [ UPDATE ]

                StringBuilder queryTabelaSincronismo = new StringBuilder();

                queryTabelaSincronismo.Append(@" UPDATE HistoricoTSincronismo                   ");
                queryTabelaSincronismo.Append(@"    SET NumeroUpload = @UPLOAD                  ");
                queryTabelaSincronismo.Append(@"  WHERE IDHistoricoSincronismo = @IDHISTORICO   ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    destinationConnection.Open();

                    SqlCommand cmdSincronismo = new SqlCommand(queryTabelaSincronismo.ToString().Replace("@UPLOAD", NumeroUpload.ToString()).Replace("@IDHISTORICO", IDHistoricoTSincronismo.ToString()), destinationConnection);
                    cmdSincronismo.ExecuteNonQuery();
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AlterarHistoricoTSincronismoNumDownload()
        {
            try
            {
                #region [ UPDATE ]

                StringBuilder queryTabelaSincronismo = new StringBuilder();

                queryTabelaSincronismo.Append(@" UPDATE HistoricoTSincronismo                  ");
                queryTabelaSincronismo.Append(@"    SET NumeroDownload = @DOWNLOAD             ");
                queryTabelaSincronismo.Append(@"  WHERE IDHistoricoSincronismo = @IDHISTORICO  ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    destinationConnection.Open();

                    SqlCommand cmdSincronismo = new SqlCommand(queryTabelaSincronismo.ToString().Replace("@DOWNLOAD", NumeroDownload.ToString()).Replace("@IDHISTORICO", IDHistoricoTSincronismo.ToString()), destinationConnection);
                    cmdSincronismo.ExecuteNonQuery();
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ DOWNLOAD ]

        private void InserirEstado()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTEstado = new StringBuilder();

                queryTEstado.Append(@" SELECT IDEstado     ");
                queryTEstado.Append(@"      , Sigla        ");
                queryTEstado.Append(@"   FROM TEstado      ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaEstado = new SqlCommand(queryTEstado.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaEstado.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringCorreio))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TEstado";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirCidade()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTCidade = new StringBuilder();

                queryTCidade.Append(@" SELECT IDCidade     ");
                queryTCidade.Append(@"      , NomeCidade   ");
                queryTCidade.Append(@"      , IDEstado     ");
                queryTCidade.Append(@"   FROM TCidade      ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaCidade = new SqlCommand(queryTCidade.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaCidade.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringCorreio))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TCidade";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirBairro()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTBairro = new StringBuilder();

                queryTBairro.Append(@" SELECT IDBairro     ");
                queryTBairro.Append(@"      , NomeBairro   ");
                queryTBairro.Append(@"      , IDCidade     ");
                queryTBairro.Append(@"   FROM TBairro      ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaBairro = new SqlCommand(queryTBairro.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaBairro.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringCorreio))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TBairro";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirLogradouro(string siglaUF)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTLogradouro = new StringBuilder();

                queryTLogradouro.Append(@" SELECT IDLogradouro                                             ");
                queryTLogradouro.Append(@"      , NomeLogradouro                                           ");
                queryTLogradouro.Append(@"      , CEP                                                      ");
                queryTLogradouro.Append(@"      , TLogradouro.IDBairro                                     ");
                queryTLogradouro.Append(@"      , TLogradouro.IDCidade                                     ");
                queryTLogradouro.Append(@"   FROM TLogradouro                                              ");
                queryTLogradouro.Append(@" INNER JOIN TBairro ON TLogradouro.IDBairro = TBairro.IDBairro   ");
                queryTLogradouro.Append(@" INNER JOIN TCidade ON TBairro.IDCidade = TCidade.IDCidade       ");
                queryTLogradouro.Append(@" INNER JOIN TEstado ON TCidade.IDEstado = TEstado.IDEstado       ");
                queryTLogradouro.Append(@" WHERE TEstado.Sigla = '@UFSIGLA'                                ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaLogradouro = new SqlCommand(queryTLogradouro.ToString().Replace("@UFSIGLA", siglaUF), connWEB);
                    IDataReader reader = cmdLerTabelaLogradouro.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringCorreio))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TLogradouro";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool InserirUsuario(TUsuarioVO usuario)
        {
            bool retorno = true;
            try
            {
                string password = Criptografia.DecryptSymmetric("DESCryptoServiceProvider", usuario.Senha);

                string InsertUsuario =
                       "  INSERT INTO [TUsuario] VALUES( " +
                                 usuario.IDUsuario
                       + ", '" + usuario.Nome + "'"
                       + ", '" + usuario.Login + "'"
                       + ", '" + Util.Util.GeraHashMD5(password) + "'"
                       + ", " + usuario.IDPerfil + ""
                       + ", '" + usuario.Email + "'"
                       + ", '" + usuario.CodigoColaborador + "'"
                       + ", '" + usuario.Unidade + "'"
                       + "); ";

                SqlCeConnection myConn = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile);

                myConn.Open();

                try
                {

                    SqlCeCommand myCommand = new SqlCeCommand(InsertUsuario, myConn);

                    try
                    {
                        myCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        retorno = false;
                    }

                }
                catch (Exception ex)
                {
                    retorno = false;
                }

                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                retorno = false;
            }
            return retorno;
        }

        private void InserirProfissao()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTProfissao = new StringBuilder();

                queryTProfissao.Append(@" SELECT IDProfissao               ");
                queryTProfissao.Append(@"      , NomeProfissao             ");
                queryTProfissao.Append(@"      , CapitalLimitado           ");
                queryTProfissao.Append(@"   FROM TProfissao                ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaProfissao = new SqlCommand(queryTProfissao.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaProfissao.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TProfissao";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirOrigemVenda()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTOrigemVenda = new StringBuilder();

                queryTOrigemVenda.Append(@" SELECT IDOrigemVenda             ");
                queryTOrigemVenda.Append(@"      , CodigoOrigemVenda         ");
                queryTOrigemVenda.Append(@"      , NomeOrigemVenda           ");
                queryTOrigemVenda.Append(@"   FROM TOrigemVenda              ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaOrigemVenda = new SqlCommand(queryTOrigemVenda.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaOrigemVenda.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TOrigemVenda";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirFaixa(int idUsuario)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTabelaFaixa = new StringBuilder();

                queryTabelaFaixa.Append(@" SELECT TOP (@ESTOQUEMAXIMO) IDFaixa                                          ");
                queryTabelaFaixa.Append(@"      , CodigoFaixa                                                           ");
                queryTabelaFaixa.Append(@"      , Usado                                                                 ");
                queryTabelaFaixa.Append(@"      , @IDUSUARIO AS IDResponsavel                                           ");
                queryTabelaFaixa.Append(@"   FROM  TFaixa                                                               ");
                queryTabelaFaixa.Append(@"  WHERE  Usado = 0                                                            ");
                queryTabelaFaixa.Append(@"    AND (IDResponsavel IS NULL OR IDResponsavel =  @IDUSUARIO )               ");

                #endregion

                #region [ UPDATE ]

                StringBuilder queryUpdate = new StringBuilder();

                queryUpdate.Append(@" UPDATE TOP (@ESTOQUEMAXIMO) TFaixa                                                         ");
                queryUpdate.Append(@"    SET IDResponsavel = @IDUSUARIO                                                          ");
                queryUpdate.Append(@"  WHERE  Usado = 0                                                                          ");
                queryUpdate.Append(@"    AND (IDResponsavel IS NULL OR IDResponsavel =  @IDUSUARIO )                             ");

                StringBuilder queryUpdateHistorioco = new StringBuilder();

                queryUpdateHistorioco.Append(@" UPDATE  TFaixa                                                                              ");
                queryUpdateHistorioco.Append(@"    SET  IDHistoricoTSincronismoDownload = @IDSINCRONISMO                                    ");
                queryUpdateHistorioco.Append(@"  WHERE  Usado = 0                                                                           ");
                queryUpdateHistorioco.Append(@"    AND  IDResponsavel =  @IDUSUARIO                                                         ");
                queryUpdateHistorioco.Append(@"    AND  (IDHistoricoTSincronismoDownload IS NULL OR IDHistoricoTSincronismoDownload =  0 )  ");
                
                StringBuilder queryUpdateIncompleta = new StringBuilder();

                queryUpdateIncompleta.Append(@" UPDATE TFaixa                                                            ");
                queryUpdateIncompleta.Append(@"    SET Usado = 1                                                         ");
                queryUpdateIncompleta.Append(@" WHERE EXISTS( SELECT CodigoEntrevista                                    ");
                queryUpdateIncompleta.Append(@"                 FROM TEntrevista                                         ");
                queryUpdateIncompleta.Append(@"                WHERE TEntrevista.CodigoEntrevista = TFaixa.CodigoFaixa ) ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdUPDATETabelaFaixa = new SqlCommand(queryUpdate.ToString().Replace("@ESTOQUEMAXIMO", ServicoColetorVO.EstoqueMaximo.ToString()).Replace("@IDUSUARIO", idUsuario.ToString()), connWEB);
                    cmdUPDATETabelaFaixa.ExecuteNonQuery();

                    SqlCommand cmdUPDATETabelaFaixaHistorico = new SqlCommand(queryUpdateHistorioco.ToString().Replace("@IDUSUARIO", idUsuario.ToString()).Replace("@IDSINCRONISMO", IDHistoricoTSincronismo.ToString()), connWEB);
                    NumeroDownload = cmdUPDATETabelaFaixaHistorico.ExecuteNonQuery();

                    SqlCommand cmdLerTabelaFaixa = new SqlCommand(queryTabelaFaixa.ToString().Replace("@ESTOQUEMAXIMO", ServicoColetorVO.EstoqueMaximo.ToString()).Replace("@IDUSUARIO", idUsuario.ToString()), connWEB);

                    IDataReader reader = cmdLerTabelaFaixa.ExecuteReader();

                    //if (tableFaixa.Rows.Count < EstoqueMinimo)
                    //    throw new Exception("Número de Faixa disponíveis abaixo do Mínimo.Favor entrar em contato com a Administração.");

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TFaixa";

                            try
                            {
                                bulkCopy.WriteToServer(reader);

                                if (!reader.IsClosed)
                                    reader.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                if (!reader.IsClosed)
                                    reader.Close();
                            }
                        }
                    }

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        SqlCeCommand cmdFaixaIncompleta = new SqlCeCommand(queryUpdateIncompleta.ToString(), destinationConnection);
                        cmdFaixaIncompleta.ExecuteNonQuery();
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirPlanoProtecao()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTPlanoProtecao = new StringBuilder();

                queryTPlanoProtecao.Append(@" SELECT IDPlanoProtecao        ");
                queryTPlanoProtecao.Append(@"      , Codigo                 ");
                queryTPlanoProtecao.Append(@"      , NomePlano              ");
                queryTPlanoProtecao.Append(@"      , CoberturaMorte         ");
                queryTPlanoProtecao.Append(@"      , CoberturaAcidente      ");
                queryTPlanoProtecao.Append(@"      , CoberturaEmergencia    ");
                queryTPlanoProtecao.Append(@"      , Premio_18_30           ");
                queryTPlanoProtecao.Append(@"      , Premio_31_40           ");
                queryTPlanoProtecao.Append(@"      , Premio_41_45           ");
                queryTPlanoProtecao.Append(@"      , Premio_46_50           ");
                queryTPlanoProtecao.Append(@"      , Premio_51_55           ");
                queryTPlanoProtecao.Append(@"      , Premio_56_60           ");
                queryTPlanoProtecao.Append(@"      , Premio_61_65           ");
                queryTPlanoProtecao.Append(@"   FROM TPlanoProtecao         ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaPlanoProtecao = new SqlCommand(queryTPlanoProtecao.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaPlanoProtecao.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TPlanoProtecao";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirPlanoProtecaoFuneral()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTPlanoProtecaoFuneral = new StringBuilder();

                queryTPlanoProtecaoFuneral.Append(@" SELECT IDPlanoProtecaoFuneral   ");
                queryTPlanoProtecaoFuneral.Append(@"      , Categoria                ");
                queryTPlanoProtecaoFuneral.Append(@"      , Codigo                   ");
                queryTPlanoProtecaoFuneral.Append(@"      , Ate_20                   ");
                queryTPlanoProtecaoFuneral.Append(@"      , De_21_40                 ");
                queryTPlanoProtecaoFuneral.Append(@"      , De_41_50                 ");
                queryTPlanoProtecaoFuneral.Append(@"      , De_51_60                 ");
                queryTPlanoProtecaoFuneral.Append(@"      , De_61_65                 ");
                queryTPlanoProtecaoFuneral.Append(@"      , De_66_70                 ");
                queryTPlanoProtecaoFuneral.Append(@"      , De_71_75                 ");
                queryTPlanoProtecaoFuneral.Append(@"      , De_76_80                 ");
                queryTPlanoProtecaoFuneral.Append(@"   FROM TPlanoProtecaoFuneral    ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaPlanoProtecaoFuneral = new SqlCommand(queryTPlanoProtecaoFuneral.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaPlanoProtecaoFuneral.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TPlanoProtecaoFuneral";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirPlanoProtecaoRenda()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTPlanoProtecaoRenda = new StringBuilder();

                queryTPlanoProtecaoRenda.Append(@" SELECT IDPlanoProtecaoRenda        ");
                queryTPlanoProtecaoRenda.Append(@"      , RendaPeriodo                ");
                queryTPlanoProtecaoRenda.Append(@"      , CoberturaRendaMensal        ");
                queryTPlanoProtecaoRenda.Append(@"      , CoberturaCapitalTotal       ");
                queryTPlanoProtecaoRenda.Append(@"      , Premio_18_30                ");
                queryTPlanoProtecaoRenda.Append(@"      , Premio_31_40                ");
                queryTPlanoProtecaoRenda.Append(@"      , Premio_41_45                ");
                queryTPlanoProtecaoRenda.Append(@"      , Premio_46_50                ");
                queryTPlanoProtecaoRenda.Append(@"      , Premio_51_55                ");
                queryTPlanoProtecaoRenda.Append(@"      , Premio_56_60                ");
                queryTPlanoProtecaoRenda.Append(@"      , Premio_61_65                ");
                queryTPlanoProtecaoRenda.Append(@"   FROM TPlanoProtecaoRenda         ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaPlanoProtecaoRenda = new SqlCommand(queryTPlanoProtecaoRenda.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaPlanoProtecaoRenda.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TPlanoProtecaoRenda";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirPlanoSenior()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTPlanoSenior = new StringBuilder();

                queryTPlanoSenior.Append(@" SELECT IDPlanoSenior          ");
                queryTPlanoSenior.Append(@"      , Codigo                 ");
                queryTPlanoSenior.Append(@"      , NomePlano              ");
                queryTPlanoSenior.Append(@"      , CoberturaMorte         ");
                queryTPlanoSenior.Append(@"      , Premio_61_65           ");
                queryTPlanoSenior.Append(@"      , Premio_66_70           ");
                queryTPlanoSenior.Append(@"      , Premio_71_75           ");
                queryTPlanoSenior.Append(@"      , Premio_76_80           ");
                queryTPlanoSenior.Append(@"   FROM TPlanoSenior           ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaPlanoSenior = new SqlCommand(queryTPlanoSenior.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaPlanoSenior.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TPlanoSenior";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirPlanoSeniorFuneral()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTPlanoSeniorFuneral = new StringBuilder();

                queryTPlanoSeniorFuneral.Append(@" SELECT IDPlanoSeniorFuneral     ");
                queryTPlanoSeniorFuneral.Append(@"      , Categoria                ");
                queryTPlanoSeniorFuneral.Append(@"      , Codigo                   ");
                queryTPlanoSeniorFuneral.Append(@"      , Ate_20                   ");
                queryTPlanoSeniorFuneral.Append(@"      , De_21_40                 ");
                queryTPlanoSeniorFuneral.Append(@"      , De_41_50                 ");
                queryTPlanoSeniorFuneral.Append(@"      , De_51_60                 ");
                queryTPlanoSeniorFuneral.Append(@"      , De_61_65                 ");
                queryTPlanoSeniorFuneral.Append(@"      , De_66_70                 ");
                queryTPlanoSeniorFuneral.Append(@"      , De_71_75                 ");
                queryTPlanoSeniorFuneral.Append(@"      , De_76_80                 ");
                queryTPlanoSeniorFuneral.Append(@"   FROM TPlanoSeniorFuneral      ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaPlanoSeniorFuneral = new SqlCommand(queryTPlanoSeniorFuneral.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaPlanoSeniorFuneral.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TPlanoSeniorFuneral";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirPlanoCasal()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTPlanoCasal = new StringBuilder();

                queryTPlanoCasal.Append(@" SELECT IDPlanoCasal           ");
                queryTPlanoCasal.Append(@"      , Codigo                 ");
                queryTPlanoCasal.Append(@"      , NomePlano              ");
                queryTPlanoCasal.Append(@"      , CoberturaMorte         ");
                queryTPlanoCasal.Append(@"      , CoberturaConjuge       ");
                queryTPlanoCasal.Append(@"      , Premio_61_65           ");
                queryTPlanoCasal.Append(@"      , Premio_66_70           ");
                queryTPlanoCasal.Append(@"      , Premio_71_75           ");
                queryTPlanoCasal.Append(@"      , Premio_76_80           ");
                queryTPlanoCasal.Append(@"   FROM TPlanoCasal            ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaPlanoCasal = new SqlCommand(queryTPlanoCasal.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaPlanoCasal.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TPlanoCasal";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirPlanoCasalFuneral()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTPlanoCasalFuneral = new StringBuilder();

                queryTPlanoCasalFuneral.Append(@" SELECT IDPlanoCasalFuneral      ");
                queryTPlanoCasalFuneral.Append(@"      , Categoria                ");
                queryTPlanoCasalFuneral.Append(@"      , Codigo                   ");
                queryTPlanoCasalFuneral.Append(@"      , Ate_20                   ");
                queryTPlanoCasalFuneral.Append(@"      , De_21_40                 ");
                queryTPlanoCasalFuneral.Append(@"      , De_41_50                 ");
                queryTPlanoCasalFuneral.Append(@"      , De_51_60                 ");
                queryTPlanoCasalFuneral.Append(@"      , De_61_65                 ");
                queryTPlanoCasalFuneral.Append(@"      , De_66_70                 ");
                queryTPlanoCasalFuneral.Append(@"      , De_71_75                 ");
                queryTPlanoCasalFuneral.Append(@"      , De_76_80                 ");
                queryTPlanoCasalFuneral.Append(@"   FROM TPlanoCasalFuneral       ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaPlanoCasalFuneral = new SqlCommand(queryTPlanoCasalFuneral.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaPlanoCasalFuneral.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TPlanoCasalFuneral";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirAgendamento(int idUsuario)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTAgendamento = new StringBuilder();

                queryTAgendamento.Append(@" SELECT IDAgendamento                        ");
                queryTAgendamento.Append(@"      , Nome                                 ");
                queryTAgendamento.Append(@"      , DataNascimento                       ");
                queryTAgendamento.Append(@"      , Email                                ");
                queryTAgendamento.Append(@"      , Telefone                             ");
                queryTAgendamento.Append(@"      , Celular                              ");
                queryTAgendamento.Append(@"      , CEP                                  ");
                queryTAgendamento.Append(@"      , Logradouro                           ");
                queryTAgendamento.Append(@"      , Numero                               ");
                queryTAgendamento.Append(@"      , Complemento                          ");
                queryTAgendamento.Append(@"      , Bairro                               ");
                queryTAgendamento.Append(@"      , Cidade                               ");
                queryTAgendamento.Append(@"      , UF                                   ");
                queryTAgendamento.Append(@"      , PontoReferencia                      ");
                queryTAgendamento.Append(@"      , IDUsuarioAgendamento                 ");
                queryTAgendamento.Append(@"      , IDUsuarioVendedor                    ");
                queryTAgendamento.Append(@"      , IDAtendimento                        ");
                queryTAgendamento.Append(@"      , 1 AS Site                            ");
                queryTAgendamento.Append(@"      , 0 AS Excluir                         ");
                queryTAgendamento.Append(@"      , DataAgendada                         ");
                queryTAgendamento.Append(@"   FROM TAgendamento                         ");
                queryTAgendamento.Append(@"   Where IDUsuarioVendedor = @IDVENDEDOR     ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaAgendamento = new SqlCommand(queryTAgendamento.ToString().Replace("@IDVENDEDOR", idUsuario.ToString()), connWEB);
                    IDataReader reader = cmdLerTabelaAgendamento.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TAgendamento";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirEntrevistaAntiga(int idUsuario)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTEntrevista = new StringBuilder();

                queryTEntrevista.Append(@" SET DATEFORMAT YMD;                           ");
                queryTEntrevista.Append(@" SELECT CodigoEntrevista                       ");
                queryTEntrevista.Append(@"      , CodigoColaborador                      ");
                queryTEntrevista.Append(@"      , DataEntrevista                         ");
                queryTEntrevista.Append(@"      , CodigoUsuario                          ");
                queryTEntrevista.Append(@"      , DataInclusao                           ");
                queryTEntrevista.Append(@"      , CodigoQuestionario                     ");
                queryTEntrevista.Append(@"      , OrigemVenda                            ");
                queryTEntrevista.Append(@"      , 'true' AS Completa                     ");
                queryTEntrevista.Append(@"      , '' AS Motivo                           ");
                queryTEntrevista.Append(@"  FROM MobileTEntrevista                       ");
                queryTEntrevista.Append(@" WHERE CodigoUsuario = @CODIGO                 ");
                queryTEntrevista.Append(@"   AND DataInclusao >= '@DATA'                 ");

                #endregion

                #region [ EXECUTE ]

                DateTime dataEntrevista = DateTime.Now.AddDays(ServicoColetorVO.TempoEntrevistaColetor * -1);
                string textoData = dataEntrevista.Year + "-" + dataEntrevista.Month + "-" + dataEntrevista.Day;

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerEntrevistaAntiga = new SqlCommand(queryTEntrevista.ToString().Replace("@CODIGO", idUsuario.ToString()).Replace("@DATA", textoData), connWEB);
                    IDataReader reader = cmdLerEntrevistaAntiga.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TEntrevista";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirEntrevistadoAntigo(int idUsuario)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTEntrevistado = new StringBuilder();

                queryTEntrevistado.Append(@" SET DATEFORMAT YMD;                                                            ");
                queryTEntrevistado.Append(@" SELECT MobileTEntrevistado.CodigoEntrevista                                    ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.Nome                                                ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.CPF                                                 ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.DataNascimento                                      ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.EstadoCivil                                         ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.IDProfissao                                         ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.FaixaEtaria                                         ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.FaixaEtariaConjuge                                  ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.IDProfissaoConjuge                                  ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.CapitalLimitado                                     ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.CapitalLimitadoConjuge                              ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.DDD                                                 ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.Telefone                                            ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.DDDCelular                                          ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.Celular                                             ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.Sexo                                                ");
                queryTEntrevistado.Append(@"      , MobileTEntrevistado.Informacao                                          ");
                queryTEntrevistado.Append(@"  FROM MobileTEntrevistado                                                      ");
                queryTEntrevistado.Append(@" INNER JOIN MobileTEntrevista                                                   ");
                queryTEntrevistado.Append(@" ON  MobileTEntrevista.CodigoEntrevista = MobileTEntrevistado.CodigoEntrevista  ");
                queryTEntrevistado.Append(@" WHERE MobileTEntrevista.CodigoUsuario = @CODIGO                                ");
                queryTEntrevistado.Append(@"   AND MobileTEntrevista.DataInclusao >= '@DATA'                                ");

                #endregion

                #region [ EXECUTE ]

                DateTime dataEntrevista = DateTime.Now.AddDays(ServicoColetorVO.TempoEntrevistaColetor * -1);
                string textoData = dataEntrevista.Year + "-" + dataEntrevista.Month + "-" + dataEntrevista.Day;

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerEntrevistadoAntigo = new SqlCommand(queryTEntrevistado.ToString().Replace("@CODIGO", idUsuario.ToString()).Replace("@DATA", textoData), connWEB);
                    IDataReader reader = cmdLerEntrevistadoAntigo.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TEntrevistado";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirEntrevistadoEnderecoAntigo(int idUsuario)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTEntrevistadoEND = new StringBuilder();

                queryTEntrevistadoEND.Append(@" SET DATEFORMAT YMD;                                                                    ");
                queryTEntrevistadoEND.Append(@" SELECT MobileTEntrevistadoEndereco.CodigoEntrevista                                    ");
                queryTEntrevistadoEND.Append(@"      , MobileTEntrevistadoEndereco.Endereco                                            ");
                queryTEntrevistadoEND.Append(@"      , MobileTEntrevistadoEndereco.Numero                                              ");
                queryTEntrevistadoEND.Append(@"      , MobileTEntrevistadoEndereco.Bairro                                              ");
                queryTEntrevistadoEND.Append(@"      , MobileTEntrevistadoEndereco.Cidade                                              ");
                queryTEntrevistadoEND.Append(@"      , MobileTEntrevistadoEndereco.UF                                                  ");
                queryTEntrevistadoEND.Append(@"      , MobileTEntrevistadoEndereco.CEP                                                 ");
                queryTEntrevistadoEND.Append(@"      , MobileTEntrevistadoEndereco.Complemento                                         ");
                queryTEntrevistadoEND.Append(@"      , MobileTEntrevistadoEndereco.Email                                               ");
                queryTEntrevistadoEND.Append(@" FROM MobileTEntrevistadoEndereco                                                       ");
                queryTEntrevistadoEND.Append(@" INNER JOIN MobileTEntrevista                                                           ");
                queryTEntrevistadoEND.Append(@" ON  MobileTEntrevista.CodigoEntrevista = MobileTEntrevistadoEndereco.CodigoEntrevista  ");
                queryTEntrevistadoEND.Append(@" WHERE MobileTEntrevista.CodigoUsuario = @CODIGO                                        ");
                queryTEntrevistadoEND.Append(@"   AND MobileTEntrevista.DataInclusao >= '@DATA'                                        ");

                #endregion

                #region [ EXECUTE ]

                DateTime dataEntrevista = DateTime.Now.AddDays(ServicoColetorVO.TempoEntrevistaColetor * -1);
                string textoData = dataEntrevista.Year + "-" + dataEntrevista.Month + "-" + dataEntrevista.Day;

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerEntrevistadoEnderecoAntigo = new SqlCommand(queryTEntrevistadoEND.ToString().Replace("@CODIGO", idUsuario.ToString()).Replace("@DATA", textoData), connWEB);
                    IDataReader reader = cmdLerEntrevistadoEnderecoAntigo.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TEntrevistadoEndereco";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirRespostaAntiga(int idUsuario)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTResposta = new StringBuilder();

                queryTResposta.Append(@" SET DATEFORMAT YMD;                                                         ");
                queryTResposta.Append(@" SELECT MobileTResposta.CodigoEntrevista                                     ");
                queryTResposta.Append(@"      , MobileTResposta.CodigoPergunta                                       ");
                queryTResposta.Append(@"      , MobileTResposta.CodigoOpcao                                          ");
                queryTResposta.Append(@"      , MobileTResposta.CodigoSeqResposta                                    ");
                queryTResposta.Append(@"      , MobileTResposta.TextoResposta                                        ");
                queryTResposta.Append(@"      , MobileTResposta.TextoSubResposta                                     ");
                queryTResposta.Append(@" FROM MobileTResposta                                                        ");
                queryTResposta.Append(@" INNER JOIN MobileTEntrevista                                                ");
                queryTResposta.Append(@" ON  MobileTEntrevista.CodigoEntrevista = MobileTResposta.CodigoEntrevista   ");
                queryTResposta.Append(@" WHERE MobileTEntrevista.CodigoUsuario = @CODIGO                             ");
                queryTResposta.Append(@"   AND MobileTEntrevista.DataInclusao >= '@DATA'                             ");

                #endregion

                #region [ EXECUTE ]

                DateTime dataEntrevista = DateTime.Now.AddDays(ServicoColetorVO.TempoEntrevistaColetor * -1);
                string textoData = dataEntrevista.Year + "-" + dataEntrevista.Month + "-" + dataEntrevista.Day;

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerRespostaAntiga = new SqlCommand(queryTResposta.ToString().Replace("@CODIGO", idUsuario.ToString()).Replace("@DATA", textoData), connWEB);
                    IDataReader reader = cmdLerRespostaAntiga.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TResposta";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirSimuladorProdutoAntigo(int idUsuario)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTSimuladorProduto = new StringBuilder();

                queryTSimuladorProduto.Append(@" SET DATEFORMAT YMD;                                                                ");
                queryTSimuladorProduto.Append(@" SELECT MobileTSimuladorProduto.CodigoEntrevista AS IDEntrevista                    ");
                queryTSimuladorProduto.Append(@"      , MobileTSimuladorProduto.Produto                                             ");
                queryTSimuladorProduto.Append(@"      , MobileTSimuladorProduto.PremioTotal                                         ");
                queryTSimuladorProduto.Append(@"      , MobileTSimuladorProduto.FaixaEtaria                                         ");
                queryTSimuladorProduto.Append(@"      , MobileTSimuladorProduto.FaixaEtariaConjuge                                  ");
                queryTSimuladorProduto.Append(@"      , MobileTSimuladorProduto.RespostaBaseRenda                                   ");
                queryTSimuladorProduto.Append(@"      , MobileTSimuladorProduto.RespostaBaseDisposto                                ");
                queryTSimuladorProduto.Append(@"      , MobileTSimuladorProduto.TipoRegistro                                        ");                
                queryTSimuladorProduto.Append(@" FROM MobileTSimuladorProduto                                                       ");
                queryTSimuladorProduto.Append(@" INNER JOIN MobileTEntrevista                                                       ");
                queryTSimuladorProduto.Append(@" ON  MobileTEntrevista.CodigoEntrevista = MobileTSimuladorProduto.CodigoEntrevista  ");
                queryTSimuladorProduto.Append(@" WHERE MobileTEntrevista.CodigoUsuario = @CODIGO                                    ");
                queryTSimuladorProduto.Append(@"   AND MobileTEntrevista.DataInclusao >= '@DATA'                                    ");

                #endregion

                #region [ EXECUTE ]

                DateTime dataEntrevista = DateTime.Now.AddDays(ServicoColetorVO.TempoEntrevistaColetor * -1);
                string textoData = dataEntrevista.Year + "-" + dataEntrevista.Month + "-" + dataEntrevista.Day;

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerSimuladorProdutoAntigo = new SqlCommand(queryTSimuladorProduto.ToString().Replace("@CODIGO", idUsuario.ToString()).Replace("@DATA", textoData), connWEB);
                    IDataReader reader = cmdLerSimuladorProdutoAntigo.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TSimuladorProduto";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirSimuladorProdutoAntigoSubs(int idUsuario)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTSimuladorProduto = new StringBuilder();

                queryTSimuladorProduto.Append(@" SELECT IDSimuladorProduto                                  ");
                queryTSimuladorProduto.Append(@"      , IDEntrevista                                        ");
                queryTSimuladorProduto.Append(@"      , Produto                                             ");
                queryTSimuladorProduto.Append(@"      , PremioTotal                                         ");
                queryTSimuladorProduto.Append(@"      , FaixaEtaria                                         ");
                queryTSimuladorProduto.Append(@"      , FaixaEtariaConjuge                                  ");
                queryTSimuladorProduto.Append(@"      , RespostaBaseRenda                                   ");
                queryTSimuladorProduto.Append(@"      , RespostaBaseDisposto                                ");
                queryTSimuladorProduto.Append(@" FROM TSimuladorProduto                                     ");

                #endregion

                #region [ EXECUTE ]

                using (SqlCeConnection connColetor = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connColetor.Open();

                    SqlCeCommand cmdLerSimuladorProdutoAntigo = new SqlCeCommand(queryTSimuladorProduto.ToString(), connColetor);
                    IDataReader reader = cmdLerSimuladorProdutoAntigo.ExecuteReader();
                    DataTable tableSimuladorProduto = new DataTable("TSimuladorProduto");
                    tableSimuladorProduto.Load(reader);

                    foreach (DataRow itemSimuladorProduto in tableSimuladorProduto.Rows)
                    {
                        InserirSimuladorSubAgregadoAntigo(itemSimuladorProduto);
                        InserirSimuladorSubFuneralAntigo(itemSimuladorProduto);
                        InserirSimuladorSubRendaAntiga(itemSimuladorProduto);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirSimuladorSubAgregadoAntigo(DataRow itemProduto)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTSimuladorSubAgregado = new StringBuilder();

                queryTSimuladorSubAgregado.Append(@" SELECT @IDSIMULADOR AS IDSimuladorProduto           ");
                queryTSimuladorSubAgregado.Append(@"      , GrauParentesco                               ");
                queryTSimuladorSubAgregado.Append(@"      , Idade                                        ");
                queryTSimuladorSubAgregado.Append(@"      , PremioAgregado                               ");
                queryTSimuladorSubAgregado.Append(@"      , Funeral                                      ");
                queryTSimuladorSubAgregado.Append(@"  FROM MobileTSimuladorSubAgregado                   ");
                queryTSimuladorSubAgregado.Append(@" WHERE CodigoEntrevista  =  @IDENTREVISTA            ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    connWEB.Open();

                    SqlCommand cmdLerSimuladorSubAgregadoAntigo = new SqlCommand(queryTSimuladorSubAgregado.ToString().Replace("@IDSIMULADOR", itemProduto["IDSimuladorProduto"].ToString()).Replace("@IDENTREVISTA", itemProduto["IDEntrevista"].ToString()), connWEB);
                    IDataReader reader = cmdLerSimuladorSubAgregadoAntigo.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TSimuladorSubAgregado";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirSimuladorSubFuneralAntigo(DataRow itemProduto)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTSimuladorSubFuneral = new StringBuilder();

                queryTSimuladorSubFuneral.Append(@" SELECT @IDSIMULADOR AS IDSimuladorProduto       ");
                queryTSimuladorSubFuneral.Append(@"      , ProtecaoCoberturaMorte                   ");
                queryTSimuladorSubFuneral.Append(@"      , ProtecaoCoberturaAcidente                ");
                queryTSimuladorSubFuneral.Append(@"      , ProtecaoCoberturaEmergencia              ");
                queryTSimuladorSubFuneral.Append(@"      , ProtecaoCategoria                        ");
                queryTSimuladorSubFuneral.Append(@"      , ProtecaoPremio                           ");
                queryTSimuladorSubFuneral.Append(@"      , SeniorCoberturaMorte                     ");
                queryTSimuladorSubFuneral.Append(@"      , SeniorCategoria                          ");
                queryTSimuladorSubFuneral.Append(@"      , SeniorPremio                             ");
                queryTSimuladorSubFuneral.Append(@"      , CasalCoberturaMorte                      ");
                queryTSimuladorSubFuneral.Append(@"      , CasalCoberturaConjuge                    ");
                queryTSimuladorSubFuneral.Append(@"      , CasalCategoria                           ");
                queryTSimuladorSubFuneral.Append(@"      , CasalPremio                              ");
                queryTSimuladorSubFuneral.Append(@"  FROM MobileTSimuladorSubFuneral                ");
                queryTSimuladorSubFuneral.Append(@" WHERE CodigoEntrevista  =  @IDENTREVISTA        ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerSimuladorSubFuneralAntigo = new SqlCommand(queryTSimuladorSubFuneral.ToString().Replace("@IDSIMULADOR", itemProduto["IDSimuladorProduto"].ToString()).Replace("@IDENTREVISTA", itemProduto["IDEntrevista"].ToString()), connWEB);
                    IDataReader reader = cmdLerSimuladorSubFuneralAntigo.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TSimuladorSubFuneral";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirSimuladorSubRendaAntiga(DataRow itemProduto)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTSimuladorSubRenda = new StringBuilder();

                queryTSimuladorSubRenda.Append(@" SELECT @IDSIMULADOR AS IDSimuladorProduto    ");
                queryTSimuladorSubRenda.Append(@"      , Periodo                               ");
                queryTSimuladorSubRenda.Append(@"      , ValorRenda                            ");
                queryTSimuladorSubRenda.Append(@"      , Capital                               ");
                queryTSimuladorSubRenda.Append(@"      , PremioRenda                           ");
                queryTSimuladorSubRenda.Append(@" FROM MobileTSimuladorSubRenda                ");
                queryTSimuladorSubRenda.Append(@" WHERE CodigoEntrevista  = @IDENTREVISTA      ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerSimuladorSubRendaAntiga = new SqlCommand(queryTSimuladorSubRenda.ToString().Replace("@IDSIMULADOR", itemProduto["IDSimuladorProduto"].ToString()).Replace("@IDENTREVISTA", itemProduto["IDEntrevista"].ToString()), connWEB);
                    IDataReader reader = cmdLerSimuladorSubRendaAntiga.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TSimuladorSubRenda";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirIncompleta(int idUsuario, int codigoColaborador)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTEntrevista = new StringBuilder();
                
                queryTEntrevista.Append(@" SET DATEFORMAT YMD;                                          ");
                queryTEntrevista.Append(@" SELECT CodigoEntrevista                                      ");
                queryTEntrevista.Append(@"      , CAST(@COLABORADOR as smallint) AS CodigoColaborador   ");
                queryTEntrevista.Append(@"      , DataEntrevista                                        ");
                queryTEntrevista.Append(@"      , CodigoUsuario                                         ");
                queryTEntrevista.Append(@"      , DataInclusao                                          ");
                queryTEntrevista.Append(@"      , CAST(3 as smallint) AS CodigoQuestionario             ");
                queryTEntrevista.Append(@"      , ' ' AS OrigemVenda                                    ");
                queryTEntrevista.Append(@"      , CAST('false' as bit) AS Completa                      ");
                queryTEntrevista.Append(@"      , Motivo                                                ");
                queryTEntrevista.Append(@"  FROM MobileTIncompleta                                      ");
                queryTEntrevista.Append(@" WHERE CodigoUsuario = @CODIGO                                ");
                queryTEntrevista.Append(@"   AND DataEntrevista >= '@DATA'                              ");

                StringBuilder queryTEntrevistado = new StringBuilder();

                queryTEntrevistado.Append(@" SET DATEFORMAT YMD;                         ");
                queryTEntrevistado.Append(@" SELECT CodigoEntrevista                     ");
                queryTEntrevistado.Append(@"      , Nome                                 ");
                queryTEntrevistado.Append(@"      , CPF                                  ");
                queryTEntrevistado.Append(@"      , DataNascimento                       ");
                queryTEntrevistado.Append(@"      , DataNascimentoConjuge                ");
                queryTEntrevistado.Append(@"      , EstadoCivil                          ");
                queryTEntrevistado.Append(@"      , IDProfissao                          ");
                queryTEntrevistado.Append(@"      , FaixaEtaria                          ");
                queryTEntrevistado.Append(@"      , FaixaEtariaConjuge                   ");
                queryTEntrevistado.Append(@"      , IDProfissaoConjuge                   ");
                queryTEntrevistado.Append(@"      , CapitalLimitado                      ");
                queryTEntrevistado.Append(@"      , CapitalLimitadoConjuge               ");
                queryTEntrevistado.Append(@"      , DDD                                  ");
                queryTEntrevistado.Append(@"      , Telefone                             ");
                queryTEntrevistado.Append(@"      , DDDCelular                           ");
                queryTEntrevistado.Append(@"      , Celular                              ");
                queryTEntrevistado.Append(@"      , Sexo                                 ");
                queryTEntrevistado.Append(@"      , CAST('false' as bit) AS Informacao   ");
                queryTEntrevistado.Append(@"  FROM MobileTIncompleta                     ");
                queryTEntrevistado.Append(@" WHERE CodigoUsuario = @CODIGO               ");
                queryTEntrevistado.Append(@"   AND DataEntrevista >= '@DATA'             ");

                StringBuilder queryTEntrevistadoEND = new StringBuilder();

                queryTEntrevistadoEND.Append(@" SET DATEFORMAT YMD;                      ");
                queryTEntrevistadoEND.Append(@" SELECT CodigoEntrevista                  ");
                queryTEntrevistadoEND.Append(@"      , Endereco                          ");
                queryTEntrevistadoEND.Append(@"      , Numero                            ");
                queryTEntrevistadoEND.Append(@"      , Bairro                            ");
                queryTEntrevistadoEND.Append(@"      , Cidade                            ");
                queryTEntrevistadoEND.Append(@"      , UF                                ");
                queryTEntrevistadoEND.Append(@"      , CEP                               ");
                queryTEntrevistadoEND.Append(@"      , Complemento                       ");
                queryTEntrevistadoEND.Append(@"      , Email                             ");
                queryTEntrevistadoEND.Append(@"  FROM MobileTIncompleta                  ");
                queryTEntrevistadoEND.Append(@" WHERE CodigoUsuario = @CODIGO            ");
                queryTEntrevistadoEND.Append(@"   AND DataEntrevista >= '@DATA'          ");

                #endregion

                #region [ EXECUTE ]

                DateTime dataEntrevista = DateTime.Now.AddDays(ServicoColetorVO.TempoEntrevistaIncompleta * -1);
                string textoData = dataEntrevista.Year + "-" + dataEntrevista.Month + "-" + dataEntrevista.Day;

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerEntrevistaAntiga = new SqlCommand(queryTEntrevista.ToString().Replace("@CODIGO", idUsuario.ToString()).Replace("@DATA", textoData).Replace("@COLABORADOR", codigoColaborador.ToString()), connWEB);
                    IDataReader reader = cmdLerEntrevistaAntiga.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TEntrevista";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerEntrevistaAntiga = new SqlCommand(queryTEntrevistado.ToString().Replace("@CODIGO", idUsuario.ToString()).Replace("@DATA", textoData).Replace("@COLABORADOR", codigoColaborador.ToString()), connWEB);
                    IDataReader reader = cmdLerEntrevistaAntiga.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TEntrevistado";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerEntrevistaAntiga = new SqlCommand(queryTEntrevistadoEND.ToString().Replace("@CODIGO", idUsuario.ToString()).Replace("@DATA", textoData), connWEB);
                    IDataReader reader = cmdLerEntrevistaAntiga.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TEntrevistadoEndereco";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirIncompletaResposta(int idUsuario)
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTResposta = new StringBuilder();

                queryTResposta.Append(@" SET DATEFORMAT YMD;                                                                    ");
                queryTResposta.Append(@" SELECT MobileTIncompletaResposta.CodigoEntrevista                                      ");
                queryTResposta.Append(@"      , MobileTIncompletaResposta.CodigoPergunta                                        ");
                queryTResposta.Append(@"      , MobileTIncompletaResposta.CodigoOpcao                                           ");
                queryTResposta.Append(@"      , MobileTIncompletaResposta.CodigoSeqResposta                                     ");
                queryTResposta.Append(@"      , MobileTIncompletaResposta.TextoResposta                                         ");
                queryTResposta.Append(@"      , MobileTIncompletaResposta.TextoSubResposta                                      ");
                queryTResposta.Append(@"  FROM MobileTIncompletaResposta                                                        ");
                queryTResposta.Append(@" INNER JOIN MobileTIncompleta                                                           ");
                queryTResposta.Append(@" ON  MobileTIncompleta.CodigoEntrevista = MobileTIncompletaResposta.CodigoEntrevista    ");
                queryTResposta.Append(@" WHERE MobileTIncompleta.CodigoUsuario = @CODIGO                                        ");
                queryTResposta.Append(@"   AND MobileTIncompleta.DataEntrevista >= '@DATA'                                      ");

                #endregion

                #region [ EXECUTE ]

                DateTime dataEntrevista = DateTime.Now.AddDays(ServicoColetorVO.TempoEntrevistaIncompleta * -1);
                string textoData = dataEntrevista.Year + "-" + dataEntrevista.Month + "-" + dataEntrevista.Day;

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerRespostaAntiga = new SqlCommand(queryTResposta.ToString().Replace("@CODIGO", idUsuario.ToString()).Replace("@DATA", textoData), connWEB);
                    IDataReader reader = cmdLerRespostaAntiga.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TResposta";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirParametro()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTParametro = new StringBuilder();

                queryTParametro.Append(@" SELECT IDParametro            ");
                queryTParametro.Append(@"      , TempoLogOff            ");
                queryTParametro.Append(@"      , PrazoSincronismoDia    ");
                queryTParametro.Append(@"      , EstoqueMaximoColetor   ");
                queryTParametro.Append(@"      , EstoqueMinimoColetor   ");
                queryTParametro.Append(@"   FROM TParametro             ");

                #endregion

                #region [ EXECUTE ]

                using (SqlConnection connWEB = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {

                    connWEB.Open();

                    SqlCommand cmdLerTabelaParametro = new SqlCommand(queryTParametro.ToString(), connWEB);
                    IDataReader reader = cmdLerTabelaParametro.ExecuteReader();

                    using (SqlCeConnection destinationConnection = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        destinationConnection.Open();

                        using (SqlCeBulkCopy bulkCopy = new SqlCeBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "TParametro";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ UPLOAD ]

        private void ValidarEntrevistaCompleta()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTabela = new StringBuilder();

                queryTabela.Append(@" SELECT TEntrevista.CodigoEntrevista                                        ");
                queryTabela.Append(@"      , TEntrevista.CodigoColaborador                                       ");
                queryTabela.Append(@"      , TEntrevista.DataEntrevista                                          ");
                queryTabela.Append(@"      , TEntrevista.CodigoUsuario                                           ");
                queryTabela.Append(@"      , TEntrevista.DataInclusao                                            ");
                queryTabela.Append(@"      , TEntrevista.CodigoQuestionario                                      ");
                queryTabela.Append(@"      , TEntrevista.OrigemVenda                                             ");
                queryTabela.Append(@"      , TEntrevista.Completa                                                ");
                queryTabela.Append(@"      , TEntrevistado.Nome                                                  ");
                queryTabela.Append(@"      , TEntrevistado.CPF                                                   ");
                queryTabela.Append(@"      , TEntrevistado.DataNascimento                                        ");
                queryTabela.Append(@"      , TEntrevistado.EstadoCivil                                           ");
                queryTabela.Append(@"      , TEntrevistado.IDProfissao                                           ");
                queryTabela.Append(@"      , TEntrevistado.FaixaEtaria                                           ");
                queryTabela.Append(@"      , TEntrevistado.FaixaEtariaConjuge                                    ");
                queryTabela.Append(@"      , TEntrevistado.IDProfissaoConjuge                                    ");
                queryTabela.Append(@"      , TEntrevistado.CapitalLimitado                                       ");
                queryTabela.Append(@"      , TEntrevistado.CapitalLimitadoConjuge                                ");
                queryTabela.Append(@"      , TEntrevistado.DDD                                                   ");
                queryTabela.Append(@"      , TEntrevistado.Telefone                                              ");
                queryTabela.Append(@"      , TEntrevistado.DDDCelular                                            ");
                queryTabela.Append(@"      , TEntrevistado.Celular                                               ");
                queryTabela.Append(@"      , TEntrevistado.Sexo                                                  ");
                queryTabela.Append(@"      , TEntrevistado.Informacao                                            ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Endereco                                      ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Numero                                        ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Bairro                                        ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Cidade                                        ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.UF                                            ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.CEP                                           ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Complemento                                   ");
                queryTabela.Append(@"      , TEntrevistadoEndereco.Email                                         ");
                queryTabela.Append(@"   FROM TEntrevista                                                         ");
                queryTabela.Append(@" LEFT JOIN TEntrevistado                                                    ");
                queryTabela.Append(@" ON TEntrevistado.CodigoEntrevista  = TEntrevista.CodigoEntrevista          ");
                queryTabela.Append(@" LEFT JOIN TEntrevistadoEndereco                                            ");
                queryTabela.Append(@" ON TEntrevistadoEndereco.CodigoEntrevista  = TEntrevista.CodigoEntrevista  ");

                StringBuilder queryResposta = new StringBuilder();

                queryResposta.Append(@" SELECT CodigoEntrevista                               ");
                queryResposta.Append(@"      , CodigoPergunta                                 ");
                queryResposta.Append(@"      , CodigoOpcao                                    ");
                queryResposta.Append(@"      , CodigoSeqResposta                              ");
                queryResposta.Append(@"      , TextoResposta                                  ");
                queryResposta.Append(@"      , TextoSubResposta                               ");
                queryResposta.Append(@"   FROM TResposta                                      ");
                queryResposta.Append(@" WHERE CodigoEntrevista =  @CODIGO                     ");
                queryResposta.Append(@"   AND CodigoPergunta =  @PERGUNTA                     ");

                #endregion

                #region [ UPLOAD ]

                StringBuilder queryUpdate = new StringBuilder();

                queryUpdate.Append(@" UPDATE TEntrevista                 ");
                queryUpdate.Append(@" SET Completa = '@COMPLETA'         ");
                queryUpdate.Append(@"   , Motivo = '@MOTIVO'             ");
                queryUpdate.Append(@" WHERE CodigoEntrevista =  @CODIGO  ");

                #endregion

                #region [ EXECUTE ]

                DataTable dadosTabela = new DataTable();

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabela = new SqlCeCommand(queryTabela.ToString(), connMobile);
                    IDataReader reader = cmdLerTabela.ExecuteReader();


                    dadosTabela.Load(reader);
                }

                foreach (DataRow dadosRow in dadosTabela.Rows)
                {
                    string queryIncompleta = queryUpdate.ToString().Replace("@COMPLETA", "false").Replace("@CODIGO", dadosRow["CodigoEntrevista"].ToString());
                    string queryCompleta = queryUpdate.ToString().Replace("@COMPLETA", "true").Replace("@CODIGO", dadosRow["CodigoEntrevista"].ToString());
                    string querySelectTResposta = queryResposta.ToString().Replace("@CODIGO", dadosRow["CodigoEntrevista"].ToString());

                    DateTime converterData = new DateTime();

                    #region [ ABA 1]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        if (string.IsNullOrEmpty(dadosRow["Nome"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Nome não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["EstadoCivil"].ToString()) || string.IsNullOrEmpty(dadosRow["EstadoCivil"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Estado Civil não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["IDProfissao"].ToString()) || string.IsNullOrEmpty(dadosRow["IDProfissao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Profissão não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ ABA 2]

                    #region [ PERGUNTA 2]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "29"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 3]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "30"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 3 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 3 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 3 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 4]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "31"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 4 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 4 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 4 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 5]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "32"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 5 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 5 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoSeqResposta"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoSeqResposta"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 5 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 5 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoSubResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 5 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 6]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "33"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 6 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 6 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 6 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 7]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "34"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 7 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 7 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Pergunta 7 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #endregion

                    #region [ ABA 3]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        if (string.IsNullOrEmpty(dadosRow["Sexo"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Sexo não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["DataNascimento"].ToString()) || !DateTime.TryParse(dadosRow["DataNascimento"].ToString(), out converterData))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Data Nascimento não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["Telefone"].ToString()) && string.IsNullOrEmpty(dadosRow["Celular"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Telefone não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ ABA 4]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        if (string.IsNullOrEmpty(dadosRow["CEP"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "CEP não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["Endereco"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Endereço não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["Bairro"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Bairro não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["Cidade"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Cidade não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["UF"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "UF não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosRow["Numero"].ToString()) && string.IsNullOrEmpty(dadosRow["Complemento"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "Número e Complemento não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ FEEDBACK ]

                    #region [ PERGUNTA 1]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "35"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 1 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 1 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 1 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #region [ PERGUNTA 2]

                    using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                    {
                        connMobile.Open();

                        DataTable dadosResposta = new DataTable();

                        SqlCeCommand cmdLerResposta = new SqlCeCommand(querySelectTResposta.Replace("@PERGUNTA", "36"), connMobile);
                        IDataReader reader = cmdLerResposta.ExecuteReader();

                        dadosResposta.Load(reader);

                        if (dadosResposta.Rows.Count != 1)
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()) || string.IsNullOrEmpty(dadosResposta.Rows[0]["CodigoOpcao"].ToString()).Equals("0"))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }

                        if (string.IsNullOrEmpty(dadosResposta.Rows[0]["TextoResposta"].ToString()))
                        {
                            SqlCeCommand cmdUpdateTabela = new SqlCeCommand(queryIncompleta.Replace("@MOTIVO", "FeedBack Pergunta 2 não preenchido."), connMobile);
                            cmdUpdateTabela.ExecuteNonQuery();
                            continue;
                        }
                    }

                    #endregion

                    #endregion

                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTFaixa()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTabelaFaixa = new StringBuilder();

                queryTabelaFaixa.Append(@" SELECT IDFaixa                                                               ");
                queryTabelaFaixa.Append(@"      , CodigoFaixa                                                           ");
                queryTabelaFaixa.Append(@"      , Usado                                                                 ");
                queryTabelaFaixa.Append(@"      , IDResponsavel                                                         ");
                queryTabelaFaixa.Append(@"   FROM TFaixa                                                                ");
                queryTabelaFaixa.Append(@" INNER JOIN TEntrevista ON TFaixa.CodigoFaixa = TEntrevista.CodigoEntrevista  ");
                queryTabelaFaixa.Append(@" WHERE TEntrevista.Completa = 'true'                                          ");

                #endregion

                #region [ INSERT ]

                StringBuilder queryInsert = new StringBuilder();

                queryInsert.Append(@" INSERT INTO HistoricoTEntrevistaUpload        ");
                queryInsert.Append(@"      ( CodigoEntrevista                       ");
                queryInsert.Append(@"      , IDHistoricoSincronismo )               ");
                queryInsert.Append(@" VALUES                                        ");
                queryInsert.Append(@"      ( @CODIGO                                ");
                queryInsert.Append(@"      ,  @IDHISTORICO     ) ;                  ");

                #endregion

                #region [ EXECUTE ]

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaFaixa = new SqlCeCommand(queryTabelaFaixa.ToString(), connMobile);
                    IDataReader reader = cmdLerTabelaFaixa.ExecuteReader();

                    DataTable dadosFaixa = new DataTable("TFaixa");
                    dadosFaixa.Load(reader);
                    int numeroUpload = 0;
                    QueryFaixa = string.Empty;

                    foreach (DataRow itemFaixa in dadosFaixa.Rows)
                    {
                        QueryFaixa += itemFaixa["CodigoFaixa"].ToString() + " ,";

                        using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                        {
                            destinationConnection.Open();
                            StringBuilder queryTabelaUPDATE = new StringBuilder();

                            if (Convert.ToBoolean(itemFaixa["Usado"]))
                            {
                                queryTabelaUPDATE.Append(@" UPDATE TFaixa SET Usado = 1 WHERE IDFaixa = " + itemFaixa["IDFaixa"].ToString());

                                SqlCommand cmdInserirTabela = new SqlCommand(queryInsert.ToString().Replace("@CODIGO", itemFaixa["CodigoFaixa"].ToString()).Replace("@IDHISTORICO", IDHistoricoTSincronismo.ToString()), destinationConnection);
                                cmdInserirTabela.ExecuteNonQuery();

                                numeroUpload++;
                            }
                            else
                                queryTabelaUPDATE.Append(@" UPDATE TFaixa SET IDResponsavel = NULL WHERE IDFaixa = " + itemFaixa["IDFaixa"].ToString());

                            SqlCommand cmdLerTabelaUPDATE = new SqlCommand(queryTabelaUPDATE.ToString(), destinationConnection);
                            cmdLerTabelaUPDATE.ExecuteNonQuery();

                            NumeroUpload = numeroUpload;
                        }
                    }

                    if (QueryFaixa.Length > 0)
                        QueryFaixa = QueryFaixa.Substring(0, QueryFaixa.Length - 1);
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTEntrevista()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTEntrevista = new StringBuilder();

                queryTEntrevista.Append(@" SELECT CodigoEntrevista                                        ");
                queryTEntrevista.Append(@"   FROM TEntrevista                                             ");
                queryTEntrevista.Append(@"  WHERE TEntrevista.Completa = 'true'                           ");

                StringBuilder querTEntrevistaWEB = new StringBuilder();

                querTEntrevistaWEB.Append(@" SELECT CodigoEntrevista                                      ");
                querTEntrevistaWEB.Append(@"   FROM MobileTEntrevista                                     ");
                querTEntrevistaWEB.Append(@"  WHERE MobileTEntrevista.CodigoEntrevista IN (@CODIGO)       ");

                StringBuilder querTEntrevistaBULK = new StringBuilder();

                querTEntrevistaBULK.Append(@" SELECT CodigoEntrevista                                     ");
                querTEntrevistaBULK.Append(@"      , CodigoColaborador                                    ");
                querTEntrevistaBULK.Append(@"      , DataEntrevista                                       ");
                querTEntrevistaBULK.Append(@"      , CodigoUsuario                                        ");
                querTEntrevistaBULK.Append(@"      , getdate() AS DataInclusao                            ");
                querTEntrevistaBULK.Append(@"      , CodigoQuestionario                                   ");
                querTEntrevistaBULK.Append(@"      , OrigemVenda                                          ");
                querTEntrevistaBULK.Append(@"   FROM TEntrevista                                          ");
                querTEntrevistaBULK.Append(@"  WHERE TEntrevista.CodigoEntrevista NOT IN (@CODIGO)        ");
                querTEntrevistaBULK.Append(@"    AND TEntrevista.Completa = 'true'                        ");

                #endregion

                #region [ DELETE ]

                StringBuilder queryTIncompleta = new StringBuilder();

                queryTIncompleta.Append(@" DELETE  FROM MobileTIncompleta                              ");
                queryTIncompleta.Append(@"  WHERE MobileTIncompleta.CodigoEntrevista NOT IN (@CODIGO)  ");

                StringBuilder queryTIncompletaResposta = new StringBuilder();

                queryTIncompletaResposta.Append(@" DELETE  FROM MobileTIncompletaResposta                              ");
                queryTIncompletaResposta.Append(@"  WHERE MobileTIncompletaResposta.CodigoEntrevista NOT IN (@CODIGO)  ");

                #endregion

                #region [ EXECUTE ]

                string queryTabela = string.Empty;

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTEntrevista = new SqlCeCommand(queryTEntrevista.ToString(), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTEntrevista.ExecuteReader();

                    DataTable dadosTabela = new DataTable("TEntrevista");
                    dadosTabela.Load(reader);

                    if (dadosTabela.Rows.Count == 0)
                        queryTabela = "0,";
                    else
                        queryTabela = string.Empty;

                    foreach (DataRow item in dadosTabela.Rows)
                    {
                        queryTabela += item["CodigoEntrevista"].ToString() + " ,";
                    }

                    if (queryTabela.Length > 0)
                        queryTabela = queryTabela.Substring(0, queryTabela.Length - 1);
                }

                using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    destinationConnection.Open();

                    SqlCommand cmdLerTabelaTEntrevista = new SqlCommand(querTEntrevistaWEB.ToString().Replace("@CODIGO", queryTabela), destinationConnection);
                    IDataReader reader = cmdLerTabelaTEntrevista.ExecuteReader();

                    DataTable dadosTabela = new DataTable("MobileTEntrevista");
                    dadosTabela.Load(reader);

                    if (dadosTabela.Rows.Count == 0)
                        queryTabela = "0,";
                    else
                        queryTabela = string.Empty;

                    foreach (DataRow item in dadosTabela.Rows)
                    {
                        queryTabela += item["CodigoEntrevista"].ToString() + " ,";
                    }

                    if (queryTabela.Length > 0)
                        queryTabela = queryTabela.Substring(0, queryTabela.Length - 1);
                }

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTEntrevista = new SqlCeCommand(querTEntrevistaBULK.ToString().Replace("@CODIGO", queryTabela), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTEntrevista.ExecuteReader();

                    using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                    {
                        destinationConnection.Open();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "MobileTEntrevista";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    destinationConnection.Open();

                    SqlCommand cmdTIncompletaResposta = new SqlCommand(queryTIncompletaResposta.ToString().Replace("@CODIGO", queryTabela), destinationConnection);
                    cmdTIncompletaResposta.ExecuteNonQuery();
                }

                using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    destinationConnection.Open();

                    SqlCommand cmdTIncompleta = new SqlCommand(queryTIncompleta.ToString().Replace("@CODIGO", queryTabela), destinationConnection);
                    cmdTIncompleta.ExecuteNonQuery();
                }

                QueryFaixa = queryTabela;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTEntrevistado()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTEntrevistado = new StringBuilder();

                queryTEntrevistado.Append(@" SELECT TEntrevistado.CodigoEntrevista                                                    ");
                queryTEntrevistado.Append(@"      , TEntrevistado.Nome                                                                ");
                queryTEntrevistado.Append(@"      , TEntrevistado.CPF                                                                 ");
                queryTEntrevistado.Append(@"      , TEntrevistado.DataNascimento                                                      ");
                queryTEntrevistado.Append(@"      , TEntrevistado.EstadoCivil                                                         ");
                queryTEntrevistado.Append(@"      , TEntrevistado.IDProfissao                                                         ");
                queryTEntrevistado.Append(@"      , TEntrevistado.FaixaEtaria                                                         ");
                queryTEntrevistado.Append(@"      , TEntrevistado.FaixaEtariaConjuge                                                  ");
                queryTEntrevistado.Append(@"      , TEntrevistado.IDProfissaoConjuge                                                  ");
                queryTEntrevistado.Append(@"      , TEntrevistado.CapitalLimitado                                                     ");
                queryTEntrevistado.Append(@"      , TEntrevistado.CapitalLimitadoConjuge                                              ");
                queryTEntrevistado.Append(@"      , TEntrevistado.DDD                                                                 ");
                queryTEntrevistado.Append(@"      , TEntrevistado.Telefone                                                            ");
                queryTEntrevistado.Append(@"      , TEntrevistado.DDDCelular                                                          ");
                queryTEntrevistado.Append(@"      , TEntrevistado.Celular                                                             ");
                queryTEntrevistado.Append(@"      , TEntrevistado.Sexo                                                                ");
                queryTEntrevistado.Append(@"      , TEntrevistado.Informacao                                                          ");
                queryTEntrevistado.Append(@"   FROM TEntrevistado                                                                     ");
                queryTEntrevistado.Append(@" INNER JOIN TEntrevista ON TEntrevista.CodigoEntrevista = TEntrevistado.CodigoEntrevista  ");
                queryTEntrevistado.Append(@"  WHERE TEntrevista.CodigoEntrevista NOT IN (@CODIGO)                                     ");
                queryTEntrevistado.Append(@"    AND TEntrevista.Completa = 'true'                                                     ");

                #endregion

                #region [ EXECUTE ]

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTEntrevistado = new SqlCeCommand(queryTEntrevistado.ToString().Replace("@CODIGO", QueryFaixa), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTEntrevistado.ExecuteReader();

                    using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                    {
                        destinationConnection.Open();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "MobileTEntrevistado";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTEntrevistadoEndereco()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTEntrevistadoEND = new StringBuilder();

                queryTEntrevistadoEND.Append(@" SELECT TEntrevistadoEndereco.CodigoEntrevista                                                    ");
                queryTEntrevistadoEND.Append(@"      , TEntrevistadoEndereco.Endereco                                                            ");
                queryTEntrevistadoEND.Append(@"      , TEntrevistadoEndereco.Numero                                                              ");
                queryTEntrevistadoEND.Append(@"      , TEntrevistadoEndereco.Bairro                                                              ");
                queryTEntrevistadoEND.Append(@"      , TEntrevistadoEndereco.Cidade                                                              ");
                queryTEntrevistadoEND.Append(@"      , TEntrevistadoEndereco.UF                                                                  ");
                queryTEntrevistadoEND.Append(@"      , TEntrevistadoEndereco.CEP                                                                 ");
                queryTEntrevistadoEND.Append(@"      , TEntrevistadoEndereco.Complemento                                                         ");
                queryTEntrevistadoEND.Append(@"      , TEntrevistadoEndereco.Email                                                               ");
                queryTEntrevistadoEND.Append(@"   FROM TEntrevistadoEndereco                                                                     ");
                queryTEntrevistadoEND.Append(@" INNER JOIN TEntrevista ON TEntrevista.CodigoEntrevista = TEntrevistadoEndereco.CodigoEntrevista  ");
                queryTEntrevistadoEND.Append(@"  WHERE TEntrevista.CodigoEntrevista NOT IN (@CODIGO)                                             ");
                queryTEntrevistadoEND.Append(@"    AND TEntrevista.Completa = 'true'                                                             ");

                #endregion

                #region [ EXECUTE ]

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTEntrevistadoEndereco = new SqlCeCommand(queryTEntrevistadoEND.ToString().Replace("@CODIGO", QueryFaixa), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTEntrevistadoEndereco.ExecuteReader();

                    using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                    {
                        destinationConnection.Open();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "MobileTEntrevistadoEndereco";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTResposta()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTResposta = new StringBuilder();

                queryTResposta.Append(@" SELECT TResposta.CodigoEntrevista                                                    ");
                queryTResposta.Append(@"      , TResposta.CodigoPergunta                                                      ");
                queryTResposta.Append(@"      , TResposta.CodigoOpcao                                                         ");
                queryTResposta.Append(@"      , TResposta.CodigoSeqResposta                                                   ");
                queryTResposta.Append(@"      , TResposta.TextoResposta                                                       ");
                queryTResposta.Append(@"      , TResposta.TextoSubResposta                                                    ");
                queryTResposta.Append(@"   FROM TResposta                                                                     ");
                queryTResposta.Append(@" INNER JOIN TEntrevista ON TEntrevista.CodigoEntrevista = TResposta.CodigoEntrevista  ");
                queryTResposta.Append(@"  WHERE TEntrevista.CodigoEntrevista NOT IN (@CODIGO)                                 ");
                queryTResposta.Append(@"    AND TEntrevista.Completa = 'true'                                                 ");

                #endregion

                #region [ EXECUTE ]

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTResposta = new SqlCeCommand(queryTResposta.ToString().Replace("@CODIGO", QueryFaixa), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTResposta.ExecuteReader();
                    DataTable dadosResposta = new DataTable("TResposta");
                    dadosResposta.Load(reader);


                    foreach (DataRow item in dadosResposta.Rows)
                    {
                        using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                        {
                            destinationConnection.Open();

                            StringBuilder queryResposta = new StringBuilder();
                            queryResposta.Append(@" INSERT INTO MobileTResposta ( CodigoEntrevista, CodigoPergunta, CodigoOpcao, ");
                            queryResposta.Append(@" CodigoSeqResposta, TextoResposta, TextoSubResposta )                         ");
                            queryResposta.Append(@" VALUES (" + item["CodigoEntrevista"] + "," + item["CodigoPergunta"] + ",     ");
                            queryResposta.Append(@"" + item["CodigoOpcao"] + "," + item["CodigoSeqResposta"] + ",                ");
                            queryResposta.Append(@"'" + item["TextoResposta"] + "','" + item["TextoSubResposta"] + "')           ");
                            SqlCommand cmdSubResposta = new SqlCommand(queryResposta.ToString(), destinationConnection);
                            cmdSubResposta.ExecuteNonQuery();
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTSimuladorProduto()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTSimuladorProduto = new StringBuilder();

                queryTSimuladorProduto.Append(@" SELECT TEntrevista.CodigoEntrevista                                                      ");
                queryTSimuladorProduto.Append(@"      , TSimuladorProduto.Produto                                                         ");
                queryTSimuladorProduto.Append(@"      , TSimuladorProduto.PremioTotal                                                     ");
                queryTSimuladorProduto.Append(@"      , TSimuladorProduto.FaixaEtaria                                                     ");
                queryTSimuladorProduto.Append(@"      , TSimuladorProduto.FaixaEtariaConjuge                                              ");
                queryTSimuladorProduto.Append(@"      , TSimuladorProduto.RespostaBaseRenda                                               ");
                queryTSimuladorProduto.Append(@"      , TSimuladorProduto.RespostaBaseDisposto                                            ");
                queryTSimuladorProduto.Append(@"      , TSimuladorProduto.IDSimuladorProduto                                              ");
                queryTSimuladorProduto.Append(@"      , TSimuladorProduto.TipoRegistro                                                    ");
                queryTSimuladorProduto.Append(@"   FROM TSimuladorProduto                                                                 ");
                queryTSimuladorProduto.Append(@" INNER JOIN TEntrevista ON TEntrevista.CodigoEntrevista = TSimuladorProduto.IDEntrevista  ");
                queryTSimuladorProduto.Append(@"  WHERE TEntrevista.CodigoEntrevista NOT IN (@CODIGO)                                     ");
                queryTSimuladorProduto.Append(@"    AND TEntrevista.Completa = 'true'                                                     ");

                #endregion

                #region [ EXECUTE ]

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTSimuladorProduto = new SqlCeCommand(queryTSimuladorProduto.ToString().Replace("@CODIGO", QueryFaixa), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTSimuladorProduto.ExecuteReader();

                    using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                    {
                        destinationConnection.Open();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "MobileTSimuladorProduto";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTSimuladorSubRenda()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTSimuladorSubRenda = new StringBuilder();

                queryTSimuladorSubRenda.Append(@" SELECT TEntrevista.CodigoEntrevista                                                      ");
                queryTSimuladorSubRenda.Append(@"      , TSimuladorSubRenda.Periodo                                                        ");
                queryTSimuladorSubRenda.Append(@"      , TSimuladorSubRenda.ValorRenda                                                     ");
                queryTSimuladorSubRenda.Append(@"      , TSimuladorSubRenda.Capital                                                        ");
                queryTSimuladorSubRenda.Append(@"      , TSimuladorSubRenda.PremioRenda                                                    ");
                queryTSimuladorSubRenda.Append(@"      , TSimuladorSubRenda.IDSimuladorProduto                                             ");
                queryTSimuladorSubRenda.Append(@"   FROM TSimuladorSubRenda                                                                ");
                queryTSimuladorSubRenda.Append(@" INNER JOIN TSimuladorProduto                                                             ");
                queryTSimuladorSubRenda.Append(@" ON TSimuladorProduto.IDSimuladorProduto = TSimuladorSubRenda.IDSimuladorProduto          ");
                queryTSimuladorSubRenda.Append(@" INNER JOIN TEntrevista ON TEntrevista.CodigoEntrevista = TSimuladorProduto.IDEntrevista  ");
                queryTSimuladorSubRenda.Append(@"  WHERE TEntrevista.CodigoEntrevista NOT IN (@CODIGO)                                     ");
                queryTSimuladorSubRenda.Append(@"    AND TEntrevista.Completa = 'true'                                                     ");

                #endregion

                #region [ EXECUTE ]

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTSimuladorrSubRenda = new SqlCeCommand(queryTSimuladorSubRenda.ToString().Replace("@CODIGO", QueryFaixa), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTSimuladorrSubRenda.ExecuteReader();

                    using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                    {
                        destinationConnection.Open();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "MobileTSimuladorSubRenda";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTSimuladorSubAgregado()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTSimuladorSubAgregado = new StringBuilder();

                queryTSimuladorSubAgregado.Append(@" SELECT TEntrevista.CodigoEntrevista                                                      ");
                queryTSimuladorSubAgregado.Append(@"      , TSimuladorSubAgregado.GrauParentesco                                              ");
                queryTSimuladorSubAgregado.Append(@"      , TSimuladorSubAgregado.Idade                                                       ");
                queryTSimuladorSubAgregado.Append(@"      , TSimuladorSubAgregado.PremioAgregado                                              ");
                queryTSimuladorSubAgregado.Append(@"      , TSimuladorSubAgregado.Funeral                                                     ");
                queryTSimuladorSubAgregado.Append(@"      , TSimuladorSubAgregado.IDSimuladorProduto                                          ");
                queryTSimuladorSubAgregado.Append(@"   FROM TSimuladorSubAgregado                                                             ");
                queryTSimuladorSubAgregado.Append(@" INNER JOIN TSimuladorProduto                                                             ");
                queryTSimuladorSubAgregado.Append(@" ON TSimuladorProduto.IDSimuladorProduto = TSimuladorSubAgregado.IDSimuladorProduto       ");
                queryTSimuladorSubAgregado.Append(@" INNER JOIN TEntrevista ON TEntrevista.CodigoEntrevista = TSimuladorProduto.IDEntrevista  ");
                queryTSimuladorSubAgregado.Append(@"  WHERE TEntrevista.CodigoEntrevista NOT IN (@CODIGO)                                     ");
                queryTSimuladorSubAgregado.Append(@"    AND TEntrevista.Completa = 'true'                                                     ");

                #endregion

                #region [ EXECUTE ]

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTSimuladorSubAgregado = new SqlCeCommand(queryTSimuladorSubAgregado.ToString().Replace("@CODIGO", QueryFaixa), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTSimuladorSubAgregado.ExecuteReader();
                    DataTable dadosAgregado = new DataTable("TSimuladorSubAgregado");
                    dadosAgregado.Load(reader);


                    foreach (DataRow item in dadosAgregado.Rows)
                    {
                        using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                        {
                            destinationConnection.Open();

                            StringBuilder queryAgregado = new StringBuilder();
                            queryAgregado.Append(@" INSERT INTO MobileTSimuladorSubAgregado ( CodigoEntrevista, GrauParentesco, Idade, PremioAgregado, Funeral , IDSimuladorProduto) ");
                            queryAgregado.Append(@" VALUES (" + item["CodigoEntrevista"] + ",'" + item["GrauParentesco"] + "'," + item["Idade"] + "," + item["PremioAgregado"].ToString().Replace(',', '.') + ",'" + item["Funeral"] + "'," + item["IDSimuladorProduto"] + ") ");
                            SqlCommand cmdSubAgregado = new SqlCommand(queryAgregado.ToString(), destinationConnection);
                            cmdSubAgregado.ExecuteNonQuery();
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTSimuladorSubFuneral()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTSimuladorSubFuneral = new StringBuilder();

                queryTSimuladorSubFuneral.Append(@" SELECT TEntrevista.CodigoEntrevista                                                      ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.ProtecaoCoberturaMorte                                       ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.ProtecaoCoberturaAcidente                                    ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.ProtecaoCoberturaEmergencia                                  ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.ProtecaoCategoria                                            ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.ProtecaoPremio                                               ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.SeniorCoberturaMorte                                         ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.SeniorCategoria                                              ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.SeniorPremio                                                 ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.CasalCoberturaMorte                                          ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.CasalCoberturaConjuge                                        ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.CasalCategoria                                               ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.CasalPremio                                                  ");
                queryTSimuladorSubFuneral.Append(@"      , TSimuladorSubFuneral.IDSimuladorProduto                                           ");
                queryTSimuladorSubFuneral.Append(@"   FROM TSimuladorSubFuneral                                                              ");
                queryTSimuladorSubFuneral.Append(@" INNER JOIN TSimuladorProduto                                                             ");
                queryTSimuladorSubFuneral.Append(@" ON TSimuladorProduto.IDSimuladorProduto = TSimuladorSubFuneral.IDSimuladorProduto        ");
                queryTSimuladorSubFuneral.Append(@" INNER JOIN TEntrevista ON TEntrevista.CodigoEntrevista = TSimuladorProduto.IDEntrevista  ");
                queryTSimuladorSubFuneral.Append(@"  WHERE TEntrevista.CodigoEntrevista NOT IN (@CODIGO)                                     ");
                queryTSimuladorSubFuneral.Append(@"    AND TEntrevista.Completa = 'true'                                                     ");

                #endregion

                #region [ EXECUTE ]

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTSimuladorSubFuneral = new SqlCeCommand(queryTSimuladorSubFuneral.ToString().Replace("@CODIGO", QueryFaixa), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTSimuladorSubFuneral.ExecuteReader();

                    using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                    {
                        destinationConnection.Open();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "MobileTSimuladorSubFuneral";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTIncompleta()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTIncompleta = new StringBuilder();

                queryTIncompleta.Append(@" SELECT TEntrevista.CodigoEntrevista                                            ");
                queryTIncompleta.Append(@"   FROM TEntrevista                                                             ");
                queryTIncompleta.Append(@"  WHERE TEntrevista.Completa = 'false'                                          ");


                StringBuilder queryTIncompletaWEB = new StringBuilder();

                queryTIncompletaWEB.Append(@" SELECT CodigoEntrevista                                                     ");
                queryTIncompletaWEB.Append(@"   FROM MobileTIncompleta                                                    ");
                queryTIncompletaWEB.Append(@"  WHERE MobileTIncompleta.CodigoEntrevista IN (@CODIGO)                      ");

                StringBuilder queryTIncompletaBULK = new StringBuilder();

                queryTIncompletaBULK.Append(@" SELECT TEntrevista.CodigoEntrevista                                        ");
                queryTIncompletaBULK.Append(@"      , TEntrevista.DataEntrevista                                          ");
                queryTIncompletaBULK.Append(@"      , TEntrevista.CodigoUsuario                                           ");
                queryTIncompletaBULK.Append(@" 	    , TEntrevistado.CapitalLimitado                                       ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.CapitalLimitadoConjuge                                ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.Celular                                               ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.CPF                                                   ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.DataNascimento                                        ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.DataNascimentoConjuge                                 ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.DDD                                                   ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.DDDCelular 	                                          ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.EstadoCivil                                           ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.FaixaEtaria                                           ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.FaixaEtariaConjuge                                    ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.IDProfissao                                           ");
                queryTIncompletaBULK.Append(@"      , TEntrevistado.IDProfissaoConjuge                                    ");
                queryTIncompletaBULK.Append(@" 	    , TEntrevistado.Nome                                                  ");
                queryTIncompletaBULK.Append(@" 	    , TEntrevistado.Sexo                                                  ");
                queryTIncompletaBULK.Append(@" 	    , TEntrevistado.Telefone                                              ");
                queryTIncompletaBULK.Append(@"      , TEntrevistadoEndereco.Bairro                                        ");
                queryTIncompletaBULK.Append(@"      , TEntrevistadoEndereco.CEP                                           ");
                queryTIncompletaBULK.Append(@"      , TEntrevistadoEndereco.Cidade                                        ");
                queryTIncompletaBULK.Append(@"      , TEntrevistadoEndereco.Complemento                                   ");
                queryTIncompletaBULK.Append(@"      , TEntrevistadoEndereco.Email                                         ");
                queryTIncompletaBULK.Append(@"      , TEntrevistadoEndereco.Endereco                                      ");
                queryTIncompletaBULK.Append(@"      , TEntrevistadoEndereco.Numero                                        ");
                queryTIncompletaBULK.Append(@"      , TEntrevistadoEndereco.UF                                            ");
                queryTIncompletaBULK.Append(@"      , TEntrevista.Motivo                                                  ");
                queryTIncompletaBULK.Append(@"      , getdate() AS DataInclusao                                           ");
                queryTIncompletaBULK.Append(@"   FROM TEntrevista                                                         ");
                queryTIncompletaBULK.Append(@" LEFT JOIN TEntrevistado                                                    ");
                queryTIncompletaBULK.Append(@" ON TEntrevistado.CodigoEntrevista  = TEntrevista.CodigoEntrevista          ");
                queryTIncompletaBULK.Append(@" LEFT JOIN TEntrevistadoEndereco                                            ");
                queryTIncompletaBULK.Append(@" ON TEntrevistadoEndereco.CodigoEntrevista  = TEntrevista.CodigoEntrevista  ");
                queryTIncompletaBULK.Append(@" WHERE TEntrevista.CodigoEntrevista NOT IN (@CODIGO)                        ");
                queryTIncompletaBULK.Append(@"   AND TEntrevista.Completa = 'false'                                       ");

                #endregion

                #region [ EXECUTE ]

                string queryTabela = string.Empty;

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTIncompleta = new SqlCeCommand(queryTIncompleta.ToString(), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTIncompleta.ExecuteReader();

                    DataTable dadosTabela = new DataTable("TEntrevista");
                    dadosTabela.Load(reader);

                    if (dadosTabela.Rows.Count == 0)
                        queryTabela = "0,";
                    else
                        queryTabela = string.Empty;

                    foreach (DataRow item in dadosTabela.Rows)
                    {
                        queryTabela += item["CodigoEntrevista"].ToString() + " ,";
                    }

                    if (queryTabela.Length > 0)
                        queryTabela = queryTabela.Substring(0, queryTabela.Length - 1);
                }

                using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    destinationConnection.Open();

                    SqlCommand cmdLerTabelaTIncompleta = new SqlCommand(queryTIncompletaWEB.ToString().Replace("@CODIGO", queryTabela), destinationConnection);
                    IDataReader reader = cmdLerTabelaTIncompleta.ExecuteReader();

                    DataTable dadosTabela = new DataTable("MobileTIncompleta");
                    dadosTabela.Load(reader);

                    if (dadosTabela.Rows.Count == 0)
                        queryTabela = "0,";
                    else
                        queryTabela = string.Empty;

                    foreach (DataRow item in dadosTabela.Rows)
                    {
                        queryTabela += item["CodigoEntrevista"].ToString() + " ,";
                    }

                    if (queryTabela.Length > 0)
                        queryTabela = queryTabela.Substring(0, queryTabela.Length - 1);
                }

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTIncompleta = new SqlCeCommand(queryTIncompletaBULK.ToString().Replace("@CODIGO", queryTabela), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTIncompleta.ExecuteReader();

                    using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                    {
                        destinationConnection.Open();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                        {
                            bulkCopy.DestinationTableName = "MobileTIncompleta";

                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }

                QueryIncompleta = queryTabela;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTIncompletaResposta()
        {
            try
            {
                #region [ SELECT ]

                StringBuilder queryTResposta = new StringBuilder();

                queryTResposta.Append(@" SELECT TResposta.CodigoEntrevista                                                    ");
                queryTResposta.Append(@"      , TResposta.CodigoPergunta                                                      ");
                queryTResposta.Append(@"      , TResposta.CodigoOpcao                                                         ");
                queryTResposta.Append(@"      , TResposta.CodigoSeqResposta                                                   ");
                queryTResposta.Append(@"      , TResposta.TextoResposta                                                       ");
                queryTResposta.Append(@"      , TResposta.TextoSubResposta                                                    ");
                queryTResposta.Append(@"   FROM TResposta                                                                     ");
                queryTResposta.Append(@" INNER JOIN TEntrevista ON TEntrevista.CodigoEntrevista = TResposta.CodigoEntrevista  ");
                queryTResposta.Append(@"  WHERE TEntrevista.CodigoEntrevista NOT IN (@CODIGO)                                 ");
                queryTResposta.Append(@"    AND TEntrevista.Completa = 'false'                                                ");

                #endregion

                #region [ EXECUTE ]

                using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
                {

                    connMobile.Open();

                    SqlCeCommand cmdLerTabelaMobileTResposta = new SqlCeCommand(queryTResposta.ToString().Replace("@CODIGO", QueryIncompleta), connMobile);
                    IDataReader reader = cmdLerTabelaMobileTResposta.ExecuteReader();
                    DataTable dadosResposta = new DataTable("TResposta");
                    dadosResposta.Load(reader);


                    foreach (DataRow item in dadosResposta.Rows)
                    {
                        using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                        {
                            destinationConnection.Open();

                            StringBuilder queryResposta = new StringBuilder();
                            queryResposta.Append(@" INSERT INTO MobileTIncompletaResposta ( CodigoEntrevista, CodigoPergunta, CodigoOpcao, ");
                            queryResposta.Append(@" CodigoSeqResposta, TextoResposta, TextoSubResposta )                                   ");
                            queryResposta.Append(@" VALUES (" + item["CodigoEntrevista"] + "," + item["CodigoPergunta"] + ",               ");
                            queryResposta.Append(@"" + item["CodigoOpcao"] + "," + item["CodigoSeqResposta"] + ",                          ");
                            queryResposta.Append(@"'" + item["TextoResposta"] + "','" + item["TextoSubResposta"] + "')                     ");
                            SqlCommand cmdSubResposta = new SqlCommand(queryResposta.ToString(), destinationConnection);
                            cmdSubResposta.ExecuteNonQuery();
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InserirMobileTAgendamento()
        {
            StringBuilder queryTabelaAgendamento = new StringBuilder();
            StringBuilder queryTabelaAgendamentoDelete = new StringBuilder();

            queryTabelaAgendamento.Append(@" SELECT IDAgendamento, Nome, DataNascimento,         ");
            queryTabelaAgendamento.Append(@" Email, Telefone, Celular, CEP, Logradouro,          ");
            queryTabelaAgendamento.Append(@" Numero, Complemento, Bairro, Cidade,                ");
            queryTabelaAgendamento.Append(@" UF, PontoReferencia, IDUsuarioAgendamento,          ");
            queryTabelaAgendamento.Append(@" IDUsuarioVendedor, IDAtendimento,                   ");
            queryTabelaAgendamento.Append(@" Site, Excluir, DataAgendada FROM TAgendamento       ");

            queryTabelaAgendamentoDelete.Append(@" DELETE FROM TAgendamento                     ");

            using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
            {

                connMobile.Open();

                SqlCeCommand cmdLerTabelaAgendamento = new SqlCeCommand(queryTabelaAgendamento.ToString(), connMobile);
                IDataReader reader = cmdLerTabelaAgendamento.ExecuteReader();
                DataTable dadosAgendamento = new DataTable("TAgendamento");
                dadosAgendamento.Load(reader);


                foreach (DataRow item in dadosAgendamento.Rows)
                {
                    using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                    {
                        destinationConnection.Open();

                        StringBuilder queryAgendamento = new StringBuilder();

                        if (Convert.ToBoolean(item["Site"]))
                        {
                            if (Convert.ToBoolean(item["Excluir"]))
                            {
                                queryAgendamento.Append(@" DELETE FROM TAgendamento WHERE IDAgendamento = " + item["IDAgendamento"]);
                            }
                            else
                            {
                                queryAgendamento.Append(@" UPDATE TAgendamento SET Nome = '" + item["Nome"] + "',                              ");
                                queryAgendamento.Append(@" DataNascimento = '" + item["DataNascimento"] + "' , Email = '" + item["Email"] + "',");
                                queryAgendamento.Append(@" Telefone = '" + item["Telefone"] + "' , Celular = '" + item["Celular"] + "',        ");
                                queryAgendamento.Append(@" CEP = " + item["CEP"] + " , Logradouro = '" + item["Logradouro"] + "',              ");
                                queryAgendamento.Append(@" Numero = '" + item["Numero"] + "' , Complemento = '" + item["Complemento"] + "',    ");
                                queryAgendamento.Append(@" Bairro = '" + item["Bairro"] + "' , Cidade = '" + item["Cidade"] + "',              ");
                                queryAgendamento.Append(@" UF = '" + item["UF"] + "' , PontoReferencia = '" + item["PontoReferencia"] + "',    ");
                                queryAgendamento.Append(@" DataAgendada = '" + item["DataAgendada"] + "'                                       ");
                                queryAgendamento.Append(@" WHERE IDAgendamento = " + item["IDAgendamento"]);
                            }
                        }
                        else
                        {
                            string atendimento = VerificarIDAtendimento(Convert.ToInt32(item["IDUsuarioVendedor"]), item["Bairro"].ToString(), item["Cidade"].ToString());

                            queryAgendamento.Append(@" INSERT INTO TAgendamento ( Nome, DataNascimento, Email, Telefone,                       ");
                            queryAgendamento.Append(@" Celular, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, UF,                      ");
                            queryAgendamento.Append(@" PontoReferencia, IDUsuarioAgendamento, IDUsuarioVendedor, IDAtendimento, DataAgendada ) ");
                            queryAgendamento.Append(@" VALUES('" + item["Nome"] + "','" + item["DataNascimento"] + "','" + item["Email"] + "', ");
                            queryAgendamento.Append(@" '" + item["Telefone"] + "','" + item["Celular"] + "'," + item["CEP"] + ",               ");
                            queryAgendamento.Append(@" '" + item["Logradouro"] + "','" + item["Numero"] + "','" + item["Complemento"] + "',    ");
                            queryAgendamento.Append(@" '" + item["Bairro"] + "','" + item["Cidade"] + "','" + item["UF"] + "',                 ");
                            queryAgendamento.Append(@" '" + item["PontoReferencia"] + "'," + item["IDUsuarioAgendamento"] + ",                 ");
                            queryAgendamento.Append(@" " + item["IDUsuarioVendedor"] + "," + atendimento + ",'" + item["DataAgendada"] + "')   ");
                        }


                        SqlCommand cmdAgendamento = new SqlCommand(queryAgendamento.ToString(), destinationConnection);
                        cmdAgendamento.ExecuteNonQuery();
                    }
                }

                SqlCeCommand cmdTabelaAgendamentoExcluir = new SqlCeCommand(queryTabelaAgendamentoDelete.ToString(), connMobile);
                cmdTabelaAgendamentoExcluir.ExecuteNonQuery();
            }
        }

        private void InserirMobileTGPS()
        {
            StringBuilder queryTabelaMobileTGPS = new StringBuilder();

            queryTabelaMobileTGPS.Append(@" SELECT CodigoEntrevista, Latitude,                       ");
            queryTabelaMobileTGPS.Append(@" Longitude, DataCadastro                                  ");
            queryTabelaMobileTGPS.Append(@" FROM TGPS                                                ");
            queryTabelaMobileTGPS.Append(@" WHERE TGPS.CodigoEntrevista NOT IN (" + QueryFaixa + ")  ");

            using (SqlCeConnection connMobile = new SqlCeConnection(ServicoColetorVO.ConnectionStringMobile))
            {

                connMobile.Open();

                SqlCeCommand cmdLerTabelaMobileTGPS = new SqlCeCommand(queryTabelaMobileTGPS.ToString(), connMobile);
                IDataReader reader = cmdLerTabelaMobileTGPS.ExecuteReader();

                using (SqlConnection destinationConnection = new SqlConnection(ServicoColetorVO.ConnectionStringWEB))
                {
                    destinationConnection.Open();

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                    {
                        bulkCopy.DestinationTableName = "MobileTGPS";

                        try
                        {
                            bulkCopy.WriteToServer(reader);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
            }
        }

        #endregion

        #region [ FTP ]

        public bool DescompactarBancoFTP(string strBancoMobile)
        {
            if (File.Exists(strBancoMobile))
            {
                try
                {
                    //Descompactando
                    Util.Util.Descompactar(new FileInfo(strBancoMobile));

                    //Apagando o arquivo descompactado
                    if (File.Exists(strBancoMobile))
                        File.Delete(strBancoMobile);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CompactarBancoEnviarFTP(string strNomeBancoDados)
        {
            if (File.Exists(strNomeBancoDados))
            {
                try
                {
                    //Compactando
                    Util.Util.Compactar(new FileInfo(strNomeBancoDados));

                    //Apagando o arquivo descompactado
                    if (File.Exists(strNomeBancoDados + ".gz"))
                    {
                        File.Delete(strNomeBancoDados);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                    ////Enviando para o servidor de FTP
                    //if (CopiarParaFTP(strNomeBancoDados + ".gz"))
                    //{
                    //    File.Delete(strNomeBancoDados + ".gz");
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool CopiarParaFTP(string NomeLocalArquivo)
        {
            clsFTP ftp = null;

            string erro = "";
            try
            {
                ftp = new clsFTP();
                ftp.RemoteHost = WebConfigurationManager.AppSettings["FTPIP"];
                ftp.RemotePort = Convert.ToInt32(WebConfigurationManager.AppSettings["FTPPORTA"]);
                ftp.RemotePath = WebConfigurationManager.AppSettings["FTPDIRETORIO"].Replace("#NUMEROCOLETOR#", ServicoColetorVO.NumeroColetor);
                ftp.RemoteUser = WebConfigurationManager.AppSettings["FTPUSER"];
                ftp.RemotePassword = WebConfigurationManager.AppSettings["FTPPASSWORD"];
                ftp.Login();
                ftp.SetBinaryMode(true);
                ftp.UploadFile(NomeLocalArquivo);

                if (ftp != null)
                {
                    ftp.CloseConnection();
                }
                ftp = null;

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                return false;
            }
        }

        #endregion
    }
}
