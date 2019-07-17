using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ProjetoMobile.wsColetor;
using System.Reflection;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace ProjetoMobile.Util
{
    /// <summary>
    /// Controle baseado em: http://msdn.microsoft.com/en-us/library/aa446487.aspx
    /// </summary>
    public class ControleAtualizacao
    {
        private const Int32 DataBlockSize = 102400;
        private HttpWebRequest request;
        private HttpWebResponse response;
        private FileStream fileStream;
        private Byte[] dataBuffer;
        private String nomeInstalador = PastaSistema.AppPath() + @"\Setup.cab";

        /// <summary>
        /// Caminho onde está disponível o instalador da nova versão
        /// </summary>
        public String Caminho { get; set; }

        /// <summary>
        /// Notifica o inicio do download e informa o tamanho do instalador em bytes
        /// </summary>
        public event Action<Int32> NotificarInicioDownload;

        /// <summary>
        /// Notifica quantos bytes já foram baixados do instalador
        /// </summary>
        public event Action<Int32> NotificarProgresso;

        /// <summary>
        /// Notifica o térmido do download
        /// </summary>
        public event Action NotificarTermino;

        /// <summary>
        /// Notifica a ocorrência de uma falha e cancelamento do processo
        /// </summary>
        public event Action<String> NotificarFalha;

        /// <summary>
        /// Verifica se existe uma atualização no servidor
        /// </summary>
        /// <returns>Setado apenas se o servidor responder com o caminho</returns>
        public Boolean Verificar(string url)
        {
            try
            {
                var service = new wsColetor.SyncColetor() { Url = url };
                Caminho = service.VerificarAtualizacaoDisponivel(Assembly.GetExecutingAssembly().GetName().Version.ToString(4));
                //Se versão estiver atualizada ou o usuário recusar a atualização abora o processo de atualização
                return Caminho != null;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Verificar atualização", ex.Message);
                if (NotificarFalha != null)
                    NotificarFalha("Ocorreu um erro ao verificar atualização");
            }
            return false;
        }

        /// <summary>
        /// Executa a atualização
        /// </summary>
        public void Executar()
        {
            try
            {
                if (String.IsNullOrEmpty(Caminho))
                {
                    NotificarFalha("Caminho de atualização não configurado");
                    return;
                }
                request = (HttpWebRequest)HttpWebRequest.Create(Caminho);
                request.BeginGetResponse(new AsyncCallback(ResponseReceived), null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inicio do download
        /// </summary>
        /// <param name="res">resposta</param>
        private void ResponseReceived(IAsyncResult res)
        {
            try
            {
                response = (HttpWebResponse)request.EndGetResponse(res);
                // Allocate data buffer
                dataBuffer = new Byte[DataBlockSize];
                // Set up progrees bar
                var TamanhoInstalador = (Int32)response.ContentLength;
                if (NotificarInicioDownload != null)
                    NotificarInicioDownload(TamanhoInstalador);
                // Open file stream to save received data
                fileStream = new FileStream(nomeInstalador, FileMode.Create);
                // Request the first chunk
                response.GetResponseStream().BeginRead(dataBuffer, 0, DataBlockSize,
                  new AsyncCallback(OnDataRead), this);
            }
            catch (WebException ex)
            {
                LogErro.GravaLog("Recuperar o instalador", ex.Message);
                if (NotificarFalha != null)
                    NotificarFalha("Ocorreu um erro ao recuperar o instalador");
            }
        }

        /// <summary>
        /// Trata a leitura de um bloco
        /// </summary>
        /// <param name="res">resposta</param>
        private void OnDataRead(IAsyncResult res)
        {
            try
            {
                // How many bytes did we get this time
                Int32 nBytes = response.GetResponseStream().EndRead(res);
                // Write buffer
                fileStream.Write(dataBuffer, 0, nBytes);
                // Update progress bar using Invoke()
                if (NotificarProgresso != null)
                    NotificarProgresso(nBytes);
                // Are we done yet?
                if (nBytes > 0)
                {
                    // No, keep reading
                    response.GetResponseStream().BeginRead(dataBuffer, 0,
                      DataBlockSize, new AsyncCallback(OnDataRead), this);
                }
                else
                {
                    // Yes, perform cleanup and update UI.
                    fileStream.Close();
                    fileStream = null;
                    if (NotificarTermino != null)
                        NotificarTermino();
                    Instalar();
                }
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Gravar o instalador", ex.Message);
                if (NotificarFalha != null)
                    NotificarFalha("Ocorreu um erro ao gravar o instalador");
            }
        }

        private void Instalar()
        {
            if (File.Exists(Program.ARQUIVO_CONFIGURACAO))
                File.Delete(Program.ARQUIVO_CONFIGURACAO);

            Thread.Sleep(2000);
            Process.Start("wceload", String.Format("/silent \"{0}\"", nomeInstalador));
            Application.Exit();
        }

        public void InstalarComponente()
        {
            Thread.Sleep(2000);
            Process.Start("wceload", String.Format("/silent \"{0}\"", Program.ARQUIVO_COMPONENTE));
            Application.Exit();
        }
    }
}
