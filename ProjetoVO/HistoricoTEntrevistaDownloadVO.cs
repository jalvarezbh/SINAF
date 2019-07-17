using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class HistoricoTEntrevistaDownloadVO
    {
        public Int32 IDHistoricoEntrevistaDownload { get; set; }

        public double CodigoEntrevista { get; set; }
              
        public Int32 IDHistoricoSincronismo { get; set; }
    }
}