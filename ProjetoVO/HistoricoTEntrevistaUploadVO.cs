using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class HistoricoTEntrevistaUploadVO
    {
        public Int32 IDHistoricoEntrevistaUpload { get; set; }

        public double CodigoEntrevista { get; set; }

        public Int32 IDHistoricoSincronismo { get; set; }
    }
}