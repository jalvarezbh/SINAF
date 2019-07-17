using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Security.Cryptography;
using System.Text;
using WebControls;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ProjetoWeb.Util
{
    public class Util
    {
        public enum Funcionalidade
        {
            AGENDAMENTOCADASTRO,
            AGENDAMENTOCONSULTA,
            COLETORASSOCIAR,
            COLETORBLOQUEIO,
            COLETORCADASTRO,
            CONFIGURACAOFILIALCADASTRO,
            CONFIGURACAOPARAMETROS,
            CONFIGURACAOMUDARSENHA,
            RELATORIOCOLETOR,

        }

        public enum Cargo
        {
            ADMINISTRADOR = 5,
            GERENTE = 4,
            COORDENADOR = 3,
            VENDEDOR = 2,
            CALLCENTER = 1,
        }

        private static List<Funcionalidade> AssociacaoCargoFuncionalidade(Cargo Perfil)
        {
            List<Funcionalidade> funcionalidadePermitida = new List<Funcionalidade>();

            switch (Perfil)
            {
                case Cargo.ADMINISTRADOR:
                    funcionalidadePermitida.Add(Funcionalidade.AGENDAMENTOCADASTRO);
                    funcionalidadePermitida.Add(Funcionalidade.AGENDAMENTOCONSULTA);
                    funcionalidadePermitida.Add(Funcionalidade.COLETORASSOCIAR);
                    funcionalidadePermitida.Add(Funcionalidade.COLETORBLOQUEIO);
                    funcionalidadePermitida.Add(Funcionalidade.COLETORCADASTRO);
                    funcionalidadePermitida.Add(Funcionalidade.CONFIGURACAOFILIALCADASTRO);
                    funcionalidadePermitida.Add(Funcionalidade.CONFIGURACAOPARAMETROS);
                    funcionalidadePermitida.Add(Funcionalidade.CONFIGURACAOMUDARSENHA);
                    funcionalidadePermitida.Add(Funcionalidade.RELATORIOCOLETOR);
                    break;
                case Cargo.GERENTE:
                    funcionalidadePermitida.Add(Funcionalidade.AGENDAMENTOCADASTRO);
                    funcionalidadePermitida.Add(Funcionalidade.AGENDAMENTOCONSULTA);
                    funcionalidadePermitida.Add(Funcionalidade.COLETORASSOCIAR);
                    funcionalidadePermitida.Add(Funcionalidade.COLETORBLOQUEIO);
                    funcionalidadePermitida.Add(Funcionalidade.COLETORCADASTRO);
                    funcionalidadePermitida.Add(Funcionalidade.CONFIGURACAOPARAMETROS);
                    funcionalidadePermitida.Add(Funcionalidade.CONFIGURACAOMUDARSENHA);
                    funcionalidadePermitida.Add(Funcionalidade.RELATORIOCOLETOR);
                    break;
                case Cargo.COORDENADOR:
                    funcionalidadePermitida.Add(Funcionalidade.AGENDAMENTOCADASTRO);
                    funcionalidadePermitida.Add(Funcionalidade.COLETORASSOCIAR);
                    funcionalidadePermitida.Add(Funcionalidade.COLETORBLOQUEIO);
                    funcionalidadePermitida.Add(Funcionalidade.COLETORCADASTRO);
                    funcionalidadePermitida.Add(Funcionalidade.CONFIGURACAOMUDARSENHA);
                    funcionalidadePermitida.Add(Funcionalidade.RELATORIOCOLETOR);
                    break;
                case Cargo.VENDEDOR:
                    funcionalidadePermitida.Add(Funcionalidade.AGENDAMENTOCADASTRO);
                    funcionalidadePermitida.Add(Funcionalidade.CONFIGURACAOMUDARSENHA);
                    break;
                case Cargo.CALLCENTER:
                    funcionalidadePermitida.Add(Funcionalidade.AGENDAMENTOCADASTRO);
                    funcionalidadePermitida.Add(Funcionalidade.CONFIGURACAOMUDARSENHA);
                    break;
                default:
                    break;
            }

            return funcionalidadePermitida;
        }

        public static bool ControleAcesso(Funcionalidade Tela, Cargo Perfil)
        {
            List<Funcionalidade> funcionalidadePermitida = AssociacaoCargoFuncionalidade(Perfil);

            return funcionalidadePermitida.Contains(Tela);
        }
        
        public static void Compactar(FileInfo fi)
        {
            // Get the stream of the source file.
            
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and already compressed files.
                if ((File.GetAttributes(fi.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (FileStream outFile = File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress))
                        {
                            // Copy the source file into the compression stream.
                            byte[] buffer = new byte[4096];
                            int numRead;
                            while ((numRead = inFile.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                Compress.Write(buffer, 0, numRead);
                            }
                        }
                    }
                }
            }
        }

        public static void Descompactar(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Get original file extension, for example "doc" from report.doc.gz.
                string curFile = fi.FullName;
                string origName = curFile.Remove(curFile.Length - fi.Extension.Length);

                //Create the decompressed file.
                using (FileStream outFile = File.Create(origName))
                {
                    using (GZipStream Decompress = new GZipStream(inFile, CompressionMode.Decompress))
                    {
                        //Copy the decompression stream into the output file.
                        byte[] buffer = new byte[4096];
                        int numRead;
                        while ((numRead = Decompress.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            outFile.Write(buffer, 0, numRead);
                        }
                    }
                }
            }
        }
        
        public static string GeraHashMD5(string Texto)
        {
            Byte[] bytOriginal;
            Byte[] bytCodigo;
            MD5 md5Objeto;
            string strResult = string.Empty;

            md5Objeto = new MD5CryptoServiceProvider();
            bytOriginal = ASCIIEncoding.Default.GetBytes(Texto);
            bytCodigo = md5Objeto.ComputeHash(bytOriginal);
            strResult = BitConverter.ToString(bytCodigo);
            strResult = strResult.Replace("-", string.Empty);

            return strResult;
        }
               
        public static void VerificarTamanhoArquivo(int tamanhoArquivo)
        {
            int tamanhoArquivoEmKB = (tamanhoArquivo / 1024);
            int tamanhoMaximoPermitido = 0;
            if (string.IsNullOrEmpty(WebConfigurationManager.AppSettings["ExcelTAMANHO"]))
                throw new CABTECException("Não foi informado no web.config o valor para chave tamanhoMaximoArquivo");

            tamanhoMaximoPermitido = Convert.ToInt32(WebConfigurationManager.AppSettings["ExcelTAMANHO"]);
            if (tamanhoArquivoEmKB > tamanhoMaximoPermitido)
                throw new CABTECException("O tamanho do arquivo importado é maior que o tamanho máximo permitido, que é de " + tamanhoMaximoPermitido + "kB.");
        }

        public static void SalvarArquivo(string keyNomeDiretorio, FileUpload fileUploadArquivo)
        {
            try
            {
                if (string.IsNullOrEmpty(keyNomeDiretorio))
                    throw new CABTECException("Para efetuar o Upload de arquivo, é necessário informar a chave com o diretório.");

                if (fileUploadArquivo == null || string.IsNullOrEmpty(fileUploadArquivo.FileName))
                    throw new CABTECException("Para efetuar o Upload de arquivo, é necessário informar o objeto fileUploadArquivo.");

                string diretorio = WebConfigurationManager.AppSettings[keyNomeDiretorio];
                if (string.IsNullOrEmpty(diretorio))
                    throw new CABTECException("Não foi informado no web.config o valor para a chave " + keyNomeDiretorio + ".");

                string nomeArquivo = fileUploadArquivo.FileName;

                string path = HttpContext.Current.Server.MapPath(diretorio);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                path += "/" + nomeArquivo;

                fileUploadArquivo.SaveAs(path);
            }
            catch (Exception e)
            {
                throw new CABTECException("Falha ao salvar o Arquivo no servidor. Erro: " + e.Message);
            }
        }

        public static void ExcluirArquivo(string keyNomeDiretorio, string nomeArquivo)
        {
            try
            {
                if (string.IsNullOrEmpty(keyNomeDiretorio))
                    throw new CABTECException("Para excluir o arquivo, é necessário informar a chave com o diretório.");

                if (string.IsNullOrEmpty(nomeArquivo))
                    throw new CABTECException("Para excluir o arquivo, é necessário informar o nome do arquivo.");

                string urlRepositorioArquivos = WebConfigurationManager.AppSettings[keyNomeDiretorio];

                string path = HttpContext.Current.Server.MapPath(urlRepositorioArquivos + nomeArquivo);

                if(File.Exists(path))
                    File.Delete(path);
            }
            catch (Exception e)
            {
                throw new CABTECException("Falha ao excluir o Arquivo do servidor. Erro: " + e.Message);
            }
        }

        public static void DownloadArquivo(System.Web.UI.Page pagina, string keyNomeDiretorio, string arquivoNome)
        {
            try
            {
                if (string.IsNullOrEmpty(keyNomeDiretorio))
                    throw new CABTECException("Para efetuar o Download do arquivo, é necessário informar a chave com o diretório.");

                if (string.IsNullOrEmpty(arquivoNome))
                    throw new CABTECException("Para efetuar o Download do arquivo, é necessário informar o nome do arquivo solicitado para download.");

                string diretorio = WebConfigurationManager.AppSettings[keyNomeDiretorio];
                if (string.IsNullOrEmpty(diretorio))
                    throw new CABTECException("Não foi informado no web.config o nome do diretório para chave " + keyNomeDiretorio + ".");

                if (diretorio[diretorio.Length - 1] == '/')
                    diretorio = diretorio.Remove(diretorio.Length - 1);

                FileInfo fileExcel = new FileInfo(@"" + HttpContext.Current.Server.MapPath(diretorio) + "\\" + arquivoNome);
                if (!fileExcel.Exists)
                    throw new Exception("Não existe o arquivo no servidor.");

                string url = MontarLink(HttpContext.Current, diretorio + "/" + arquivoNome, string.Empty);
                HttpContext.Current.Server.Transfer("downloadArquivo.aspx?caminho=" + HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings[keyNomeDiretorio]) + "\\" + arquivoNome);
                              
            }
            catch (CABTECException cabexception)
            {
                throw cabexception;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static string MontarLink(HttpContext contexto, string NomeArquivo, string QueryString)
        {
            string link = contexto.Request.Url.OriginalString;

            link = link.Substring(0, link.LastIndexOf("/"));

            link += "/" + NomeArquivo;

            if (!string.IsNullOrEmpty(QueryString))
                link += "?" + QueryString;

            return link;
        }
               
    }
}
