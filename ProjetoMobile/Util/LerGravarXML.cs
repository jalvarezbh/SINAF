using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace ProjetoMobile.Util
{
    public static class LerGravarXML
    {
        public static string ObterValor(String Chave, String ValorPadrao)
        {
            if (!File.Exists(Program.ARQUIVO_CONFIGURACAO))
                return ValorPadrao;

            XmlDocument doc = new XmlDocument();
            doc.Load(Program.ARQUIVO_CONFIGURACAO);
            string retorno = "";

            try
            {
                retorno = doc.DocumentElement[Chave].InnerText;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog(String.Format("Erro ao ler elemento {0}.", Chave), ex.Message);
                retorno = ValorPadrao;
            }

            doc = null;

            return retorno;
        }

        public static bool GravarValor(String Chave, String Valor)
        {
            if (!File.Exists(Program.ARQUIVO_CONFIGURACAO))
                return false;

            XmlDocument doc = new XmlDocument();
            doc.Load(Program.ARQUIVO_CONFIGURACAO);

            if (doc.DocumentElement[Chave] == null)
                doc.SelectSingleNode("/Configuracao").AppendChild(doc.CreateElement(Chave));

            doc.DocumentElement[Chave].InnerText = Valor;
            doc.Save(Program.ARQUIVO_CONFIGURACAO);

            doc = null;

            return true;
        }

        public static string ObterValorComponente(String Chave, String ValorPadrao)
        {
            if (!File.Exists(Program.ARQUIVO_COMPONENTE_XML))
                return ValorPadrao;

            XmlDocument doc = new XmlDocument();
            doc.Load(Program.ARQUIVO_COMPONENTE_XML);
            string retorno = "";

            try
            {
                retorno = doc.DocumentElement[Chave].InnerText;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog(String.Format("Erro ao ler elemento {0}.", Chave), ex.Message);
                retorno = ValorPadrao;
            }

            doc = null;

            return retorno;
        }

        public static Boolean ObterValor(String Chave, Boolean ValorPadrao)
        {
            try
            {
                return Convert.ToBoolean(ObterValor(Chave, Convert.ToString(ValorPadrao)));
            }
            catch
            {
                return ValorPadrao;
            }
        }
    }
}
