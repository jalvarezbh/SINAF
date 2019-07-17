using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    [Serializable]
    public class TSimuladorSubAgregadoDOMINIO
    {
        public Int32 IDSimuladorSubAgregado { get; set; }

        public Int32 IDSimuladorProduto { get; set; }

        public String GrauParentesco { get; set; }

        public Int32 Idade { get; set; }

        public Decimal PremioAgregado { get; set; }

        public String Funeral { get; set; }
    }
}
