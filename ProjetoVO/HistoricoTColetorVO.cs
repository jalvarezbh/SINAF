using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class HistoricoTColetorVO
    {
        public Int32 IDHistoricoColetor { get; set; }

        public String NumeroColetor { get; set; }

        public DateTime DataUltimoSincronismo { get; set; }

        public Int32 NumeroTotalSincronismo { get; set; }

        public Int32 NumeroTotalEntrevista { get; set; }

        public List<HistoricoTSincronismoVO> listSincronismo { get; set; }

        public String Vendedor { get; set; }

        public DateTime? DataRelatorioInicio { get; set; }

        public DateTime? DataRelatorioFinal { get; set; }

        public DateTime DataSincronismo { get; set; }
                
    }
}