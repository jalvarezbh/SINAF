using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProjetoMobile.Util
{
    public class MostraCursor
    {
        public static void CursorAguarde(bool ativo)
        {      
            Cursor.Current = ativo?Cursors.WaitCursor:Cursors.Default;

            if (ativo)
                Cursor.Show();
            else
                Cursor.Hide();
        }                
    }
}
