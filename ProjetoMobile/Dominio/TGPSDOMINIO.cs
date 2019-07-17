using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    [Serializable]
    public class TGPSDOMINIO
    {
        public Int32 IDGPS { get; set; }

        public Int64 CodigoEntrevista { get; set; }

        public String Latitude { get; set; }

        public String Longitude { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
