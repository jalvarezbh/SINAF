using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace ProjetoMobile.Persistencia.Common
{
    public static class DataBaseLocator
    {
        #region Propriedades

        private static string LerStringConexao()
        {
            string path = Util.PastaSistema.AppPath();
            string filename = Util.PastaSistema.AppPath() + "configuracao.xml";
            string valor = null;
            XmlDocument doc = null;

            if (!File.Exists(filename))
                throw new Exception(String.Format("Arquivo configuracao.xml não localizado em {0} !", path));

            try
            {
                doc = new XmlDocument();
                doc.Load(filename);
                valor = doc.DocumentElement["ConnectionString"].InnerText;
                if (valor.Equals(""))
                    throw new Exception("String de Conexão não informada !");
            }
            catch (Exception)
            {
                valor = "";
                throw;
            }
            finally
            {
                doc = null;
            }
            return valor;
        }

        private static string m_ConnectionString = "";
        public static string ConnectionString
        {
            get
            {
                m_ConnectionString = LerStringConexao();
                return m_ConnectionString;
            }
            set { m_ConnectionString = value; }
        }

        public static void LoadFromFile(string filename)
        {
            string backup = m_ConnectionString;
            try
            {
                using (StreamReader arq = new StreamReader(filename, Encoding.Default))
                {
                    m_ConnectionString = arq.ReadLine();
                    arq.Close();
                }
            }
            catch (Exception)
            {
                m_ConnectionString = backup;
            }
        }

        #endregion
    }
}
