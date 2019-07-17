using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Util
{
    public static class LogErro
    {
        public static void GravaLog(string mensagem, string erro)
        {
            if (File.Exists(Program.ARQUIVO_LOG))
            {
                StreamWriter arquivo = new StreamWriter(Program.ARQUIVO_LOG, true, System.Text.Encoding.Default);
                arquivo.WriteLine("--> [" + System.DateTime.Now + "] - [" + Program.Usuario + "] - [" + mensagem + "] - [" + erro + "]");
                arquivo.Close();
                arquivo = null;
            }
        }

        public static void GravaStackTrace(Exception ex)
        {
            StreamWriter arquivo = new StreamWriter(Program.ARQUIVO_LOG, true, System.Text.Encoding.Default);
            arquivo.WriteLine("--> [" + System.DateTime.Now + "] - [" + Program.Usuario + "] - [" + ex.StackTrace + "]");
            arquivo.Close();
            arquivo = null;
        }
    }
}
