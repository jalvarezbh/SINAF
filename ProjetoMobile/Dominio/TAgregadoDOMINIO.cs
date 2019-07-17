using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Dominio
{
    [Serializable]
    public class TAgregadoDOMINIO
    {
        public Int32 Identificador { get; set; }

        public Int32 Idade { get; set; }

        public String GrauParentesco { get; set; }

        public Decimal Premio { get; set; }

        public String Funeral { get; set; }
    }
}
