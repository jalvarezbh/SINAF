using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoMobile.Util
{
    public class PanelMobile
    {
        public void BorderPanel(Panel panelMobile)
        {
            Graphics g = panelMobile.CreateGraphics();

            Rectangle panelRect = panelMobile.ClientRectangle;

            Point p1 = new Point(panelRect.Left, panelRect.Top); //top left
            Point p2 = new Point(panelRect.Right-1, panelRect.Top); //Top Right
            Point p3 = new Point(panelRect.Left, panelRect.Bottom-1); //Bottom Left
            Point p4 = new Point(panelRect.Right - 1, panelRect.Bottom -1); //Bottom

            Pen pen1 = new Pen(System.Drawing.Color.Black);
            
            g.DrawLine(pen1, p1.X , p1.Y, p2.X,p2.Y);
            g.DrawLine(pen1, p1.X, p1.Y, p3.X, p3.Y);
            g.DrawLine(pen1, p2.X, p2.Y, p4.X, p4.Y);
            g.DrawLine(pen1, p3.X, p3.Y, p4.X, p4.Y);           
        }
    }
}
