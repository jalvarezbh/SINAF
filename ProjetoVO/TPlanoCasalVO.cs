using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class TPlanoCasalVO
    {
        #region [ TPlanoCasal ]

        public Int32 IDPlanoCasal { get; set; }

        public Int32 Codigo { get; set; }

        public String NomePlano { get; set; }

        public Decimal CoberturaMorte { get; set; }

        public Decimal CoberturaConjuge { get; set; }

        public Decimal? Premio_61_65 { get; set; }

        public Decimal? Premio_66_70 { get; set; }

        public Decimal? Premio_71_75 { get; set; }

        public Decimal? Premio_76_80 { get; set; }

        public Decimal? ValorPremioIdadeBase { get; set; }

        #endregion

        #region [ TPlanoCasalFuneral ]

        public Int32 IDPlanoCasalFuneral { get; set; }

        public Int32 FuneralCodigo { get; set; }

        public String FuneralCategoria { get; set; }

        public Decimal? FuneralAte_20 { get; set; }

        public Decimal? FuneralDe_21_40 { get; set; }

        public Decimal? FuneralDe_41_50 { get; set; }

        public Decimal? FuneralDe_51_60 { get; set; }

        public Decimal? FuneralDe_61_65 { get; set; }

        public Decimal? FuneralDe_66_70 { get; set; }

        public Decimal? FuneralDe_71_75 { get; set; }

        public Decimal? FuneralDe_76_80 { get; set; }

        #endregion
    }
}
