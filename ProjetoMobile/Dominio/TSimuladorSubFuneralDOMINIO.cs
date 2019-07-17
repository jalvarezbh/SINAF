using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    [Serializable]
    public class TSimuladorSubFuneralDOMINIO
    {
        public Int32 IDSimuladorSubFuneral { get; set; }

        public Int32 IDSimuladorProduto { get; set; }

        public Decimal? ProtecaoCoberturaMorte { get; set; }
        public Decimal? ProtecaoCoberturaAcidente { get; set; }
        public Decimal? ProtecaoCoberturaEmergencia { get; set; }
        public String ProtecaoCategoria { get; set; }
        public Decimal? ProtecaoPremio { get; set; }

        public Decimal? SeniorCoberturaMorte { get; set; }
        public String SeniorCategoria { get; set; }
        public Decimal? SeniorPremio { get; set; }

        public Decimal? CasalCoberturaMorte { get; set; }
        public Decimal? CasalCoberturaConjuge { get; set; }
        public String CasalCategoria { get; set; }
        public Decimal? CasalPremio { get; set; }
    }
}
