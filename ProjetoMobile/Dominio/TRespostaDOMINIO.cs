using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    public class TRespostaDOMINIO
    {
        public Int32 IDResposta { get; set; }

        public Int64 CodigoEntrevista { get; set; }

        public Int32 CodigoPergunta { get; set; }

        public Int32 CodigoOpcao { get; set; }

        public Int32 CodigoSeqPergunta { get; set; }

        public String TextoResposta { get; set; }

        public String TextoSubResposta { get; set; }
    }
}
