using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
   [Serializable]
   public class TMenuPerfilVO
   {
     public Int32 IDMenuPerfil { get; set; } 
 
     public Int32? IDMenu { get; set; } 
 
     public Int32? IDPerfil { get; set; } 
 
     public Boolean? Ativo { get; set; } 
 

   }
}
        