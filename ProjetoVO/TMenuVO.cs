using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
   [Serializable]
   public class TMenuVO
   {
     public Int32 IDMenu { get; set; } 
 
     public String Descricao { get; set; } 
 
     public Int32? IDMenuPai { get; set; } 
 
     public Boolean? Mobile { get; set; } 
 
     public String Url { get; set; } 
 
     public Int32 Ordenacao { get; set; } 
 
     public List<TMenuPerfilVO> TMenuPerfil { get; set; } 
 

   }
}
        