using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace ProjetoMobile.Util
{
    /// <summary>
    /// Helper class to programmatically operate scrollbars.
    /// </summary>
    public class ScrollBarHelper
    {
        private Int32 PosY, PosYc;

        private Panel ctr;

        /// <summary>
        /// Quando setado, define que os movimentos do cursor sobre o controle devem provocar o scroll vertical.
        /// Esta propriedade é setada por padrão.
        /// </summary>
        public Boolean ControlScroll { get; set; }

        public ScrollBarHelper(Panel c)
        {
            ctr = c;
            InscribeControls(c);
            ControlScroll = true;
        }

        private void InscribeControls(Control control)
        {
            control.MouseDown += new MouseEventHandler(MouseDown);
            control.MouseUp += new MouseEventHandler(MouseUp);
            foreach (var item in control.Controls.OfType<Control>())
                InscribeControls(item);
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            PosY = e.Y;
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (!ControlScroll)
                return;

            var delta = PosY - e.Y;
            PosYc += delta;
            if (PosYc < 0)
                PosYc = 0;
            else if (PosYc > ctr.Height)
                PosYc = ctr.Height;

            ctr.AutoScrollPosition = new Point(0, PosYc);
        }
    }
}