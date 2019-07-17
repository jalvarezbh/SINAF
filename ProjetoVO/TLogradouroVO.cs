using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class TLogradouroVO
    {
        public Int32 IDLogradouro { get; set; }

        public String NomeLogradouro { get; set; }

        public Int32 CEP { get; set; }

        public Int32 IDBairro { get; set; }

        public String NomeBairro { get; set; }

        public Int32 IDCidade { get; set; }

        public String NomeCidade { get; set; }

        public Int32 IDEstado { get; set; }

        public String Sigla { get; set; }
    }
}
