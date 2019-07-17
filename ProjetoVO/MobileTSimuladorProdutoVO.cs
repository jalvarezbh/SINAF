using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class MobileTSimuladorProdutoVO
    {
        public Int64 IDSimuladorProduto { get; set; }

        public Int64 CodigoEntrevista { get; set; }

        public String Produto { get; set; }

        public Decimal PremioTotal { get; set; }

        public Int32 FaixaEtaria { get; set; }
        
        public Int32 FaixaEtariaConjuge { get; set; }

        public Int32 RespostaBaseRenda { get; set; }

        public Int32 RespostaBaseDisposto { get; set; }

        public String TipoRegistro { get; set; }

        public String NomeVendedor { get; set; }

        public String NumeroColetor { get; set; }

        public DateTime DataEntrevista { get; set; }

        public String NomeEntrevistado { get; set; }

        public String CPFEntrevistado { get; set; }

        public String FonteDados { 
            get
            {
                if(TipoRegistro.Equals("S"))
                    return "Simulador";

                if(TipoRegistro.Equals("A"))
                    return "Atual";

                return "Histórico";
            } 
        }

        public String CategoriaFuneral
        {
            get
            {
                switch (Produto)
                {
                    case "Proteção Família":
                        return ProtecaoCategoriaFuneral;
                    case "Sênior Casal":
                        return CasalCategoriaFuneral;
                    case "Sênior Individual":
                        return SeniorCategoriaFuneral;
                    default:
                        return String.Empty;
                }               
            }
        }

        public Decimal PremioFuneral 
        {
            get
            {
                switch (Produto)
                {
                    case "Proteção Família":
                        return ProtecaoPremioFuneral.HasValue?ProtecaoPremioFuneral.Value:0;
                    case "Sênior Casal":
                        return CasalPremioFuneral.HasValue ? CasalPremioFuneral.Value : 0;
                    case "Sênior Individual":
                        return SeniorPremioFuneral.HasValue ? SeniorPremioFuneral.Value : 0;
                    default:
                        return 0;
                }
            }
        }

        public Decimal CapitalFuneral 
        {
            get
            {
                switch (Produto)
                {
                    case "Proteção Família":
                        return ProtecaoCapitalFuneral.HasValue ? ProtecaoCapitalFuneral.Value : 0;
                    case "Sênior Casal":
                        return CasalCapitalFuneral.HasValue ? CasalCapitalFuneral.Value : 0;
                    case "Sênior Individual":
                        return SeniorCapitalFuneral.HasValue ? SeniorCapitalFuneral.Value : 0;
                    default:
                        return 0;
                }
            }
        }

        public Int32 NumeroAgregados { get; set; }

        public Decimal? PremioAgregados { get; set; }

        public Decimal? PremioRenda { get; set; }

        public String Proposta { get; set; }

        public String ProtecaoCategoriaFuneral { get; set; }

        public Decimal? ProtecaoPremioFuneral { get; set; }

        public Decimal? ProtecaoCapitalFuneral { get; set; }

        public String CasalCategoriaFuneral { get; set; }

        public Decimal? CasalPremioFuneral { get; set; }

        public Decimal? CasalCapitalFuneral { get; set; }

        public String SeniorCategoriaFuneral { get; set; }

        public Decimal? SeniorPremioFuneral { get; set; }

        public Decimal? SeniorCapitalFuneral { get; set; }

        public DateTime? DataEntrevistaInicio { get; set; }

        public DateTime? DataEntrevistaFinal { get; set; }

        public Boolean ExibirCompleto { get; set; }
    }
}
