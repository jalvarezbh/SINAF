using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjetoVO
{
    public enum FaixaEtaria
    {
        PREMIO_18_30 = 1,
        PREMIO_31_40 = 8,
        PREMIO_41_45 = 2,
        PREMIO_46_50 = 3,
        PREMIO_51_55 = 4,
        PREMIO_56_60 = 5,
        PREMIO_61_65 = 6,
        PREMIO_66_70 = 7,
        PREMIO_71_75 = 9,
        PREMIO_76_80 = 10,
    }

    public enum PerguntaRenda
    {
        ATE_800 = 1,
        DE_801_1000 = 2,
        DE_1001_1200 = 3,
        DE_1201_1400 = 4,
        DE_1401_1600 = 5,
        DE_1601_2000 = 6,
        DE_2001_2500 = 7,
        ACIMA_2501 = 8,
        NAO_INFORMA = 9,
    }

    public enum PerguntaPremio
    {
        PREMIO_15 = 1,
        PREMIO_20 = 2,
        PREMIO_25 = 3,
        PREMIO_30 = 4,
        PREMIO_35 = 5,
        PREMIO_40 = 6,
        PREMIO_50 = 7,
        PREMIO_60 = 8,
    }

    public enum ProdutoPrincipal
    {
        [StringValue("Produto Proteção Família")]
        PLANOPROTECAO = 1,

        [StringValue("Produto Sênior Individual")]
        PLANOSENIOR = 2,

        [StringValue("Produto Sênior Casal")]
        PLANOCASAL = 3,
    }

    public enum GrauParentesco
    {
        [StringValue("CÔNJUGE / COMPANHEIRO (A)")]
        CONJUGE = 1,

        [StringValue("FILHO (A)")]
        FILHO = 2,

        [StringValue("PAI")]
        PAI = 3,

        [StringValue("MÃE")]
        MAE = 4,

        [StringValue("SOGRO (A)")]
        SOGRO = 5,

        [StringValue("GENRO")]
        GENRO = 6,

        [StringValue("NORA")]
        NORA = 7,
         
        [StringValue("IRMÃO (A)")]
        IRMAO = 8,

        [StringValue("NETO (A)")]
        NETO = 9,
 
        [StringValue("BISNETO (A) ")]
        BISNETO = 10,
 
    }

    public enum PeriodoRenda
    {
        [StringValue("Renda 3 Meses")]
        MESES_3 = 1,

        [StringValue("Renda 6 Meses")]
        MESES_6 = 2,

        [StringValue("Renda 12 Meses")]
        MESES_12 = 3,

        [StringValue("Renda 24 Meses")]
        MESES_24 = 4,

    }

    public enum ValorMensalRenda
    {
        [StringValue("500,00")]
        VALOR500 = 500,

        [StringValue("750,00")]
        VALOR750 = 750,

       [StringValue("1000,00")]
        VALOR1000 = 1000,

        [StringValue("1500,00")]
        VALOR1500 = 1500,

        [StringValue("2000,00")]
        VALOR2000 = 2000,
    }

    public static class EnumString
    {
        public static string GetStringValue(this System.Enum value)
        {
            StringValueAttribute valor = GetAtributeValue<StringValueAttribute>(value);

            if (valor != default(StringValueAttribute))
                return valor.Value;
            else
                return string.Empty;

        }

        public static int GetIDValue(this System.Enum value)
        {
            return Convert.ToInt32(value);
        }
                
        private static T GetAtributeValue<T>(System.Enum value)
        {
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());

            var res = fi.GetCustomAttributes(typeof(T), false) as T[];

            if (res.Length > 0)
                return res[0];
            else
                return default(T);
        }
    }

    public class StringValueAttribute : Attribute
    {
        private readonly string _value;
              
        public StringValueAttribute(string value)
        {
            _value = value;
        }
              
        public string Value
        {
            get { return _value; }
        }
    }

   


}
