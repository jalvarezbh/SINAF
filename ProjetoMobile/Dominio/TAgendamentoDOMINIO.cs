using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    [Serializable]
    public class TAgendamentoDOMINIO
    {
        public Int32 IDAgendamento { get; set; }

        public String Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public String Telefone { get; set; }

        public String Celular { get; set; }

        public String Email { get; set; }

        public String CEP { get; set; }

        public String Logradouro { get; set; }

        public String Numero { get; set; }

        public String Complemento { get; set; }

        public String Bairro { get; set; }

        public String Cidade { get; set; }

        public String UF { get; set; }

        public String PontoReferencia { get; set; }

        public DateTime DataAgendada { get; set; }
    }
}
