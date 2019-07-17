using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class TLogVO
    {
        public Int32 IDLog { get; set; }

        public String Tabela { get; set; }

        public Int32 IDUsuario { get; set; }

        public DateTime Data { get; set; }

        public String Tipo { get; set; } 
    }
}
