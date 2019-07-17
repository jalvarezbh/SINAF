using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class TAgregadoVO
    {
        public Int32 Identificador { get; set; }

        public Int32 Idade { get; set; }

        public String GrauParentesco { get; set; }

        public Decimal Premio { get; set; }
    }
}
