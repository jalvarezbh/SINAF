using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class TFaixaVO
    {
        public Int32 IDFaixa { get; set; }

        public double CodigoFaixa { get; set; }

        public Boolean Usado { get; set; }

        public Int32 IDResponsavel { get; set; }
    }
}
