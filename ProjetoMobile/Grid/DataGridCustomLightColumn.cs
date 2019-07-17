//--------------------------------------------------------------------- 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY 
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//PARTICULAR PURPOSE. 
//---------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;


namespace DataGridCustomColumns
{
    public class DataGridCustomLightColumn : DataGridCustomColumnBase
    {
        private object _nullValue = DBNull.Value;
        
        // Set up owr own NullValue. Let's use DBNull.Value by default.
        public override object NullValue
        {
            get { return _nullValue;  }
            set {
                if (value != _nullValue)
                {
                    _nullValue = value;
                    this.Invalidate();
                }
            }
        }

        
        protected override string GetBoundPropertyName()
        {
            return "CheckState";                                                    
        }

        protected override Control CreateHostedControl()
        {
            CheckBox box = new CheckBox();

            box.ThreeState = true;

            return box;
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            Object cellData;                                                    // Object to show in the cell 

            DrawBackground(g, bounds, rowNum, backBrush);                       // Draw cell background

            cellData = this.PropertyDescriptor.GetValue(source.List[rowNum]);   // Get data for this cell from data source.

            if((cellData != null) && (cellData != this.NullValue) && (cellData is IConvertible))
            {                                                                   // Data is IConvertale and not NULL?
                cellData = ((IConvertible)cellData).ToBoolean(this.FormatInfo); // Go ahead and convert it to boolean
            }

            DrawCheckBox(g, bounds, (cellData is Boolean) ? ((bool)cellData ? CheckState.Checked : CheckState.Unchecked) : CheckState.Unchecked);//CheckState.Indeterminate);
                                                                                // Draw the checkbox according to the data in data source.

            this.updateHostedControl();                                         // Have to do that.
        }
 

        private void DrawCheckBox(Graphics g, Rectangle bounds, CheckState state)
        {
            int boxTop;

            Image imgTamanho = ProjetoMobile.Properties.Resources.accept32_white;

            boxTop = bounds.Y + (bounds.Height - imgTamanho.Height) / 2;
                       
            if (state == CheckState.Checked)
                g.DrawImage(ProjetoMobile.Properties.Resources.accept32_white, bounds.X, boxTop);
            else
                g.DrawImage(ProjetoMobile.Properties.Resources.remove32_white, bounds.X, boxTop);
        }
    }
}
