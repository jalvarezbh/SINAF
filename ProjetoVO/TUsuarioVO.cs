using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
   [Serializable]
   public class TUsuarioVO
   {
     public Int32 IDUsuario { get; set; } 
 
     public String Nome { get; set; }

     public String Abreviado { get; set; } 
 
     public String Login { get; set; } 
 
     public String Senha { get; set; } 
 
     public Int32 IDPerfil { get; set; } 
 
     public String Email { get; set; }

     public bool PrimeiroAcesso { get; set; }
           
     public Int32 CodigoColaborador { get; set; }

     public String Unidade { get; set; }

     public bool Ativo { get; set; }
   }
}
        