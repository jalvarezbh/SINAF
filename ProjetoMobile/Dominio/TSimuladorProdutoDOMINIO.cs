using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    [Serializable]
    public class TSimuladorProdutoDOMINIO
    {
        public Int32 IDSimuladorProduto { get; set; }

        public Int64 IDEntrevista { get; set; }

        public String Produto { get; set; }
                
        public Decimal PremioTotal { get; set; }

        public Int32 FaixaEtaria { get; set; }

        public Int32 FaixaEtariaConjuge { get; set; }

        public Int32 RespostaBaseRenda { get; set; }

        public Int32 RespostaBaseDisposto { get; set; }

        public Char TipoRegistro { get; set; }
    }
}
