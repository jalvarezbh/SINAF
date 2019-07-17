using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Util
{
    public static class PastaSistema
    {
        /// <summary>
        /// Retornar a pasta da aplicacao
        /// É necessário usar o assembly devido ao framework do coletor não possuir objeto direto para isso
        /// </summary>
        /// <returns></returns>
        public static string AppPath()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName.Replace(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name, "").ToString();
        }
    }
}
