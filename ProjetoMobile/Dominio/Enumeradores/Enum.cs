using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ProjetoMobile.Dominio.Enumeradores
{   
    public enum RespostaCaixaMensagem
    {
        Sim = 0, Nao = 1, Cancelar = 2
    }

    public enum RespostaAutenticacao
    {
        Ok = 0, 
        Invalido = 1, 
        SenhaIncorreta = 2, 
        Erro = 3, 
        SemConexao = 4, 
        OkSemConexao = 5, 
        SenhaIncorretaSemConexao = 6, 
        InvalidoSemConexao = 7,
        SemSuperintendencia = 8
    }
       
    public enum TipoSinal
    {
        LOCAL = 0, GPRS = 1, OFF = 2
    }

    public enum TipoSinalGPS
    {
        ON = 0, INICIANDO = 1, OFF = 2, ESTABILIZANDO = 3
    }

    public enum EstadoCivil
    {
        [StringValue("Solteiro(a)")]
        Solteiro = 1 ,

        [StringValue("Casado(a)")]
        Casado = 2,

        [StringValue("Viúvo(a)")]
        Viuvo = 3,

        [StringValue("Desquitado(a)")]
        Desquitado = 4,

        [StringValue("Divorciado(a)")]
        Divorciado = 5,

        [StringValue("União Estável")]
        UniaoEstavel = 6,

        [StringValue("Separação Judicial")]
        SeparacaoJudicial = 7
    }

    public enum FaixaEtaria
    {
        [StringValue("18 - 30")]
        PREMIO_18_30 = 1,

        [StringValue("31 - 40")]
        PREMIO_31_40 = 8,

        [StringValue("41 - 45")]
        PREMIO_41_45 = 2,

        [StringValue("46 - 50")]
        PREMIO_46_50 = 3,

        [StringValue("51 - 55")]
        PREMIO_51_55 = 4,

        [StringValue("56 - 60")]
        PREMIO_56_60 = 5,

        [StringValue("61 - 65")]
        PREMIO_61_65 = 6,

        [StringValue("66 - 70")]
        PREMIO_66_70 = 7,

        [StringValue("71 - 75")]
        PREMIO_71_75 = 9,

        [StringValue("76 - 80")]
        PREMIO_76_80 = 10,

        [StringValue("Acima 80")]
        PREMIO_81 = 81,
    }

    public enum CapitalLimitado
    {
        [StringValue("Não")]
        Nao = 0,

        [StringValue("Sim")]
        Sim = 1,
    }

    public enum CodigoPergunta
    {
        ABA1 = 37,
        ABA2 = 38,
        ABA3 = 39,
        ABA4 = 40,
        ABA5 = 41,
        ABA6 = 42,
        ABA7 = 43,
        FEEDBACKABA1 = 44,
        FEEDBACKABA2 = 45,
    }

    public enum CodigoSeqPergunta
    {
        COMUM = 0,
        PARENTESCO = 1,
        IDADE = 2,
        AJUDADESPESA = 3,
    }

    public enum PerguntaRenda
    {
        [StringValue("Até R$ 800 (R$ 15,00)")]
        ATE_800 = 1,

        [StringValue("R$ 801 até R$ 1.000 (R$ 20,00)")]
        DE_801_1000 = 2,

        [StringValue("R$ 1.001 até R$ 1.200 (R$ 25,00)")]
        DE_1001_1200 = 3,

        [StringValue("R$ 1.201 até R$1.400 (R$ 30,00)")]
        DE_1201_1400 = 4,

        [StringValue("R$ 1.401 até R$ 1.600 (R$ 35,00)")]
        DE_1401_1600 = 5,

        [StringValue("R$ 1.601 até R$ 2.000 (R$ 45,00)")]
        DE_1601_2000 = 6,

        [StringValue("R$ 2.001 até R$ 2.500 (R$ 55,00)")]
        DE_2001_2500 = 7,

        [StringValue("R$ 2.501 até R$ 3.000 (R$ 65,00)")]
        DE_2501_3000 = 8,

        [StringValue("R$ 3.001 até R$ 3.500 (R$ 75,00)")]
        DE_3001_3500 = 9,

        [StringValue("R$ 3.501 até R$ 4.000 (R$ 90,00)")]
        DE_3501_4000 = 10,

        [StringValue("Acima de R$ 4.001 (R$ 110,00)")]
        ACIMA_4001 = 11,

        [StringValue("Não quis informar")]
        NAO_INFORMA = 12,
    }

    public enum PerguntaPremio
    {
        [StringValue("R$ 15,00")]
        PREMIO_15 = 1,

        [StringValue("R$ 20,00")]
        PREMIO_20 = 2,

        [StringValue("R$ 25,00")]
        PREMIO_25 = 3,

        [StringValue("R$ 30,00")]
        PREMIO_30 = 4,

        [StringValue("R$ 35,00")]
        PREMIO_35 = 5,

        [StringValue("R$ 45,00")]
        PREMIO_45 = 6,

        [StringValue("R$ 55,00")]
        PREMIO_55 = 7,

        [StringValue("R$ 65,00")]
        PREMIO_65 = 8,

        [StringValue("R$ 75,00")]
        PREMIO_75 = 9,
        
        [StringValue("R$ 90,00")]
        PREMIO_90 = 10,

        [StringValue("R$ 110,00")]
        PREMIO_110 = 11,
    }

    public enum ProdutoPrincipal
    {
        [StringValue("Proteção Família")]
        PLANOPROTECAO = 1,

        [StringValue("Sênior Individual")]
        PLANOSENIOR = 2,

        [StringValue("Sênior Casal")]
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

        [StringValue("ENTEADO (A) ")]
        ENTEADO = 11,

        [StringValue("AVÔ ")]
        AVOM = 12,

        [StringValue("AVÓ ")]
        AVOF = 13,

        [StringValue("OUTRO")]
        OUTRO = 14,

    }

    public enum PeriodoRenda
    {
        [StringValue("À Vista")]
        AVISTA = 0,

        [StringValue("3 Meses")]
        MESES_3 = 1,

        [StringValue("6 Meses")]
        MESES_6 = 2,

        [StringValue("12 Meses")]
        MESES_12 = 3,

        [StringValue("24 Meses")]
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

    public enum FeedBackRecepcao
    {
        [StringValue("Muito receptivo")]
        MuitoReceptivo = 1,

        [StringValue("Receptivo")]
        Receptivo = 2,

        [StringValue("Indiferente")]
        Indiferente = 3,

        [StringValue("Pouco receptivo")]
        PoucoReceptivo = 4,
    }

    public enum FeedBackProposta
    {        
        [StringValue("Sim")]
        Sim = 1,

        [StringValue("Não")]
        Nao = 2,
    }

    public enum FeedBackMotivoNao
    {
        [StringValue("Agendado")]
        Agendado = 1,

        [StringValue("Entrar em contato em 3 dias")]
        Contato3Dias = 2,

        [StringValue("Cliente SINAF")]
        Cliente = 3,

        [StringValue("Completou 81 anos")]
        Completo81Anos = 4,

        [StringValue("Agregado/Dependente outro plano")]
        AgregadoOutro = 5,

        [StringValue("Possui outro Seguro de Vida")]
        SeguroVidaOutro = 6,

        [StringValue("Possui outra Assistência Funeral")]
        FuneralOutro = 7,

        [StringValue("Sem condições financeiras")]
        SemFinanceiro = 8,

        [StringValue("Desempregado")]
        Desempregado = 9,

        [StringValue("Não informado")]
        NaoInformado = 10,

        [StringValue("Sem interesse")]
        SemInteresse = 11,
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
