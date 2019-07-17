using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    [Serializable]
    public class TEntrevistadoDOMINIO
    {
        public Int32 IDEntrevistado { get; set; }

        public Int64 CodigoEntrevista { get; set; }

        public String Nome { get; set; }

        public String CPF { get; set; }

        public DateTime? DataNascimento { get; set; }

        public Int32 EstadoCivil { get; set; }

        public Int32 IDProfissao { get; set; }

        public Int32 FaixaEtaria { get; set; }

        public Int32 FaixaEtariaConjuge { get; set; }

        public Int32 IDProfissaoConjuge { get; set; }

        public DateTime? DataNascimentoConjuge { get; set; }

        public String CapitalLimitado { get; set; }

        public String CapitalLimitadoConjuge { get; set; }

        public String DDD { get; set; }

        public String Telefone { get; set; }

        public String DDDCelular { get; set; }

        public String Celular { get; set; }

        public String Sexo { get; set; }

        public bool Informacao { get; set; }
        
    }
}
