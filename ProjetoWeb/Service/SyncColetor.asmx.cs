using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;

namespace ProjetoWeb.Service
{
    /// <summary>
    /// Summary description for SyncColetor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]  

    public class SyncColetor : System.Web.Services.WebService
    {
        /// <summary>
        /// Faz o teste de conecxão do coletor
        /// </summary>
        /// <returns>Data e Hora do Servidor</returns>
        [WebMethod(Description = "Data e Hora.")]
        public DateTime SetDateTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Faz o teste de para ver a senha após o hash
        /// </summary>
        /// <returns>Password</returns>
        [WebMethod(Description = "Password.")]
        public string VerSenhaHash(string password)
        {
            return new ServicoColetor().VerSenhaHash(password);
        }

        /// <summary>
        /// Verifica se o coletor está ativo 
        /// </summary>
        /// <param name="numeroSerie">Número de Série do Coletor</param>
        /// <returns>Retorna true para ativo</returns>
        [WebMethod(Description = "Verifica se o Coletor está Ativo.")]
        public bool VerificaColetorAtivo(string numeroSerie)
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            return new ServicoColetor().VerificaColetorAtivo(numeroSerie);
        }

        /// <summary>
        /// Realiza a Importação do Banco Correios
        /// </summary>
        /// <param name="numeroSerie">Número de Série do Coletor para o qual será criado o Banco</param>
        /// <param name="siglaUF">Sigla do Estado que o Coletor é utilizado</param>
        /// <param name="versaoAtual">Versão do Correio que está no Coletor</param>
        /// <param name="versaoNova">Retornar a Versão do Correio do Servidor</param>
        /// <returns>Retorna o Caminho do Banco no Servidor</returns>
        [WebMethod(Description = "Importa o Banco do Correio para o Coletor.")]
        public string ImportarBancoCorreios(string numeroSerie, string siglaUF, int versaoAtual, out int versaoNova)
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            return new ServicoColetor().ImportarBancoCorreios(numeroSerie, siglaUF, versaoAtual, out versaoNova);
        }

        /// <summary>
        /// Realiza a Importação do Banco Correios Teste
        /// </summary>
        /// <param name="numeroSerie">Número de Série do Coletor para o qual será criado o Banco</param>
        /// <param name="siglaUF">Sigla do Estado que o Coletor é utilizado</param>
        /// <param name="versaoAtual">Versão do Correio que está no Coletor</param>
        /// <returns>Retorna o Caminho do Banco no Servidor</returns>
        [WebMethod(Description = "Importa o Banco do Correio para o Coletor.")]
        public string ImportarBancoCorreiosTeste(string numeroSerie, string siglaUF, int versaoAtual)
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            return new ServicoColetor().ImportarBancoCorreiosTeste(numeroSerie, siglaUF, versaoAtual);
        }

        /// <summary>
        /// Realiza a Importação do Banco
        /// </summary>
        /// <param name="numeroSerie">Número de Série do Coletor para o qual será criado o Banco</param>
        /// <param name="numeroDownload">Retorna o Número de Entrevistas baixadas para o Coletor</param>
        /// <returns>Retorna o Caminho do Banco no Servidor</returns>
        [WebMethod(Description = "Importa o Banco para o Coletor.")]
        public string ImportarBanco(string numeroSerie, string versao, out int numeroDownload)
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting",true);
            return new ServicoColetor().ImportarBanco(numeroSerie, versao, out numeroDownload);
        }

        /// <summary>
        /// Realiza a Exportação do Banco 
        /// </summary>
        /// <param name="numeroSerie">Número de Série do Coletor define o endereço do arquivo no Servidor</param>
        /// <param name="numeroUpload">Retorna o Número de Entrevistas enviadas pelo Coletor</param>
        /// <returns>Retorna True ou a Exception</returns>
        [WebMethod(Description = "Exportar o Banco para a Web.")]
        public bool ExportarBanco(string numeroSerie, string versao, out int numeroUpload)
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            return new ServicoColetor().ExportarBanco(numeroSerie, versao, out numeroUpload);
        }

        /// <summary>
        /// Realiza a Importação do Banco - Teste sem variável out
        /// </summary>
        /// <param name="numeroSerie">Número de Série do Coletor para o qual será criado o Banco</param>
        /// <returns>Retorna o Caminho do Banco no Servidor</returns>
        [WebMethod(Description = "Importa o Banco para o Coletor.")]
        public string ImportarBancoTeste(string numeroSerie, string versao)
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            return new ServicoColetor().ImportarBancoTeste(numeroSerie, versao);
        }

        /// <summary>
        /// Realiza a Exportação do Banco - Teste sem variável out
        /// </summary>
        /// <param name="numeroSerie">Número de Série do Coletor define o endereço do arquivo no Servidor</param>
        /// <returns>Retorna True ou a Exception</returns>
        [WebMethod(Description = "Exportar o Banco para a Web.")]
        public bool ExportarBancoTeste(string numeroSerie, string versao)
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            return new ServicoColetor().ExportarBancoTeste(numeroSerie, versao);
        }

        /// <summary>
        /// Realiza a exclusão dos arquivos backups
        /// </summary>
        /// <returns>Retorna True ou a Exception</returns>
        [WebMethod(Description = "Realiza a exclusão dos arquivos backups.")]
        public bool ExcluirBackupColetor()
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            return new ServicoColetor().ExcluirBackupColetor();
        }


        /// <summary>
        /// Verifica se o coletor está executando com a versão atual
        /// </summary>
        /// <param name="coletor">Versão do coletor</param>
        /// <returns>NULL caso o coletor esteja atualiza. Caso contrário retorna o caminho da atualização</returns>
        [WebMethod]
        public String VerificarAtualizacaoDisponivel(String coletor)
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            if (new Version(coletor) < new Version(WebConfigurationManager.AppSettings["ColetorVersao"]))
               return WebConfigurationManager.AppSettings["ColetorCaminho"];
                       
            return null;
        }
              
    }
}
