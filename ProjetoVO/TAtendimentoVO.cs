using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class TAtendimentoVO
    {
        public Int32 IDAtendimento { get; set; }

        public Int32 IDFilial { get; set; }

        public Int32 IDBairro { get; set; }

        public Int32 IDCidade { get; set; }
    }
}
