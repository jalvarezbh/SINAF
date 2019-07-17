using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{  
    [Serializable]
    public class TPlanoProtecaoDOMINIO
    {
        #region [ TPlanoProtecao ]

        public Int32 IDPlanoProtecao { get; set; }

        public Int32 Codigo { get; set; }

        public String NomePlano { get; set; }

        public Decimal CoberturaMorte { get; set; }

        public Decimal CoberturaAcidente { get; set; }

        public Decimal CoberturaEmergencia { get; set; }

        public Decimal? Premio_18_30 { get; set; }

        public Decimal? Premio_31_40 { get; set; }

        public Decimal? Premio_41_45 { get; set; }

        public Decimal? Premio_46_50 { get; set; }

        public Decimal? Premio_51_55 { get; set; }

        public Decimal? Premio_56_60 { get; set; }

        public Decimal? Premio_61_65 { get; set; }

        public Decimal? ValorPremioIdadeBase { get; set; }

        #endregion

        #region [ TPlanoProtecaoFuneral ]

        public Int32 IDPlanoProtecaoFuneral { get; set; }

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

        #region [ TPlanoProtecaoRenda ]

        public Int32 IDPlanoProtecaoRenda { get; set; }

        public String RendaPeriodo { get; set; }

        public Decimal RendaCoberturaRendaMensal { get; set; }

        public Decimal RendaCoberturaCapitalTotal { get; set; }

        public Decimal? RendaPremio_18_30 { get; set; }

        public Decimal? RendaPremio_31_40 { get; set; }

        public Decimal? RendaPremio_41_45 { get; set; }

        public Decimal? RendaPremio_46_50 { get; set; }

        public Decimal? RendaPremio_51_55 { get; set; }

        public Decimal? RendaPremio_56_60 { get; set; }

        public Decimal? RendaPremio_61_65 { get; set; }

        public Decimal? RendaValorPremioIdadeBase { get; set; }

        #endregion

    }
}
