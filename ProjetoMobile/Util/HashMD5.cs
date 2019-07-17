using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace ProjetoMobile.Util
{
    public static class HashMD5
    {

        /// <summary>
        /// Gera um Hash MD5 com a string informada.
        /// </summary>
        /// <param name="Texto">Texto que terá o Hash calculado.</param>
        /// <returns>Hash MD5 do texto (32 bytes).</returns>
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

    }
}
