using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class TAgendamentoVO
    {
        public Int32 IDAgendamento { get; set; }

        public String Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public String Email { get; set; }

        public String Telefone { get; set; }

        public String Celular { get; set; }

        public Int32 CEP { get; set; }

        public String Logradouro { get; set; }

        public Int32? Numero { get; set; }

        public String Complemento { get; set; }

        public String Bairro { get; set; }

        public String Cidade { get; set; }

        public String UF { get; set; }

        public String PontoReferencia { get; set; }

        public Int32 IDUsuarioAgendamento { get; set; }

        public Int32? IDUsuarioVendedor { get; set; }

        public Int32? IDAtendimento { get; set; }

        public String NomeUsuarioAgendamento { get; set; }

        public String NomeUsuarioVendedor { get; set; }

        public String Unidade { get; set; }

    }
}
