using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class TServicoColetorVO
    {
        public String NumeroColetor { get; set; }

        public String ConnectionStringMobile { get; set; }

        public String ConnectionStringCorreio { get; set; }

        public String ConnectionStringWEB { get; set; }

        public String BancoMobile { get; set; }

        public String BancoERRO { get; set; }

        public String BancoCorreio { get; set; }

        public String DiretorioMobile { get; set; }

        public String DiretorioVersao { get; set; }

        public Int32 EstoqueMaximo { get; set; }

        public Int32 EstoqueMinimo { get; set; }

        public Int32 TempoEntrevistaColetor { get; set; }

        public Int32 TempoEntrevistaIncompleta { get; set; }
                        
    }
}
