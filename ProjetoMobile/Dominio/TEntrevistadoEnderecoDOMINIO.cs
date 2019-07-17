using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    public class TEntrevistadoEnderecoDOMINIO
    {
        public Int64 CodigoEntrevista { get; set; }

        public String Endereco { get; set; }

        public Int32? Numero { get; set; }

        public String Bairro { get; set; }

        public String Cidade { get; set; }

        public String UF { get; set; }

        public String CEP { get; set; }

        public String Complemento { get; set; }

        public String Email { get; set; }
    }
}
