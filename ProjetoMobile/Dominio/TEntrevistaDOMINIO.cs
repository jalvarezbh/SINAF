using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    [Serializable]
    public class TEntrevistaDOMINIO
    {
        public Int32 IDEntrevista { get; set; }

        public Int64 CodigoEntrevista { get; set; }

        public Int32 CodigoColaborador { get; set; }

        public DateTime DataEntrevista { get; set; }

        public Int32 CodigoUsuario { get; set; }

        public DateTime DataInclusao { get; set; }

        public Int32 CodigoQuestionario { get; set; }

        public String OrigemVenda { get; set; }

        public Boolean Completa { get; set; }

        public String Motivo { get; set; }
                
    }
}
