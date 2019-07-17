using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProjetoWeb.Service
{
    /// <summary>
    /// Summary description for SyncSINAF
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SyncSINAF : System.Web.Services.WebService
    {
        [WebMethod(Description = "Obter Tempo Verficação em Dias.")]
        public int ObterPrimeiroServico()
        {
            ServicoSINAF servico = new ServicoSINAF();
            return servico.ObterTempoVerificaSINAF();
        } 
       
        [WebMethod(Description = "Importa o Banco do Correio para base Web.")]
        public bool ImportarBancoCorreio()
        {
            ServicoSINAF servico = new ServicoSINAF();
            servico.ImportarBancoCorreio();

            return true;
        }

        [WebMethod(Description = "Importa Base SINAF TUsuario, TProfissao, TOrigemVenda, TFaixa.")]
        public bool ImportarBaseSINAF()
        {
            ServicoSINAF servico = new ServicoSINAF();
            return servico.ImportarBaseSINAF();
        }

        [WebMethod(Description = "Importa Base SINAF TUsuario -- TESTE.")]
        public bool ImportarBaseSINAF_TUsuario()
        {
            ServicoSINAF servico = new ServicoSINAF();
            return servico.ImportarUsuario();
        }

        [WebMethod(Description = "Importa Base SINAF TProfissao -- TESTE.")]
        public bool ImportarBaseSINAF_TProfissao()
        {
            ServicoSINAF servico = new ServicoSINAF();
            return servico.ImportarProfissao();
        }

        [WebMethod(Description = "Importa Base SINAF TOrigemVenda -- TESTE.")]
        public bool ImportarBaseSINAF_TOrigemVenda()
        {
            ServicoSINAF servico = new ServicoSINAF();
            return servico.ImportarOrigemVenda();
        }

        [WebMethod(Description = "Importa Base SINAF TFaixa -- TESTE.")]
        public bool ImportarBaseSINAF_TFaixa()
        {
            ServicoSINAF servico = new ServicoSINAF();
            return servico.ImportarFaixas();
        }

        [WebMethod(Description = "Exportar Base SINAF Entrevistas.")]
        public bool ExportarBaseSINAF()
        {
            ServicoSINAF servico = new ServicoSINAF();
            return servico.ExportarBaseSINAF();
        }
    }
}
