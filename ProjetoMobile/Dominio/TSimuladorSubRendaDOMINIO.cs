using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    [Serializable]
    public class TSimuladorSubRendaDOMINIO
    {
        public Int32 IDSimuladorSubRenda { get; set; }

        public Int32 IDSimuladorProduto { get; set; }

        public String Periodo { get; set; }

        public Decimal ValorRenda { get; set; }
        
        public Decimal Capital { get; set; }
        
        public Decimal PremioRenda { get; set; }

    }
}
