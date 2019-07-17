using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class HistoricoTSincronismoVO
    {
        public Int32 IDHistoricoSincronismo { get; set; }

        public Int32 IDHistoricoColetor { get; set; }
               
        public DateTime DataSincronismo { get; set; }

        public Int32 NumeroUpload { get; set; }

        public Int32 NumeroDownload { get; set; }

        public Int32 IDVendedor { get; set; }

        public String NomeVendedor { get; set; }

        public DateTime? DataRelatorioInicio { get; set; }

        public DateTime? DataRelatorioFinal { get; set; }
                
    }
}