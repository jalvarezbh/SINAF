using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
   [Serializable]
   public class TPerfilVO
   {
     public Int32 IDPerfil { get; set; } 
 
     public String Descricao { get; set; } 
 
     public Boolean? Ativo { get; set; } 
 
     public List<TMenuPerfilVO> TMenuPerfil { get; set; } 
 
     public List<TUsuarioVO> TUsuario { get; set; }

     public Int32 IDPerfilCargo { get; set; }

     public String NomeCargo { get; set; }

   }
}
        