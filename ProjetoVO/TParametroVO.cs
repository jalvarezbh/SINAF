using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
   [Serializable]
   public class TParametroVO
   {
     public Int32 IDParametro { get; set; } 
 
     public Int32? TempoLogOff { get; set; } 
 
     public Int32? PrazoSincronismoDia { get; set; } 
 
     public Int32? EstoqueMaximoWeb { get; set; } 
 
     public Int32? EstoqueMinimoWeb { get; set; } 
 
     public Int32? EstoqueMaximoColetor { get; set; } 
 
     public Int32? EstoqueMinimoColetor { get; set; } 
 
     public Int32? TempoDadosServidorDias { get; set; } 
 
     public Int32? TempoVerificaERPDias { get; set; }

     public Int32? VersaoBaseCorreio { get; set; }

     public Int32? TempoEntrevistaColetor { get; set; }

     public Int32? TempoEntrevistaIncompleta { get; set; } 
   }
}
        