using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyLibrary
{
    public class clsColorControl
    {
        object _Sender;
       
       

        #region MoreDetails

       public static void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.ForeColor = Color.White;
        }
       
       public static void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.ForeColor = Color.Black;
        }
       public static void Label_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Cursor = Cursors.Hand;
            lbl.ForeColor = Color.White;
        }
       
       public static void Label_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Cursor = Cursors.Hand;
            lbl.ForeColor = Color.Black;
        }
       
     

   
    
       public static void TextBox_MouseEnter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.ForeColor = Color.White;
        }
       public static void TextBox_MouseLeave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.ForeColor = Color.Black;
        }
       public static void comboBox_MouseEnter(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.Cursor = Cursors.PanSouth;
            cb.ForeColor = Color.White;
        }
       public static void comboBox_MouseLeave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.Cursor = Cursors.PanSouth;
            cb.ForeColor = Color.Black;
        }

        public static void RadioButton_MouseEnter(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            rb.Cursor = Cursors.Hand;
            rb.ForeColor = Color.White;
        }
        public static void RadioButton_MouseLeave(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            rb.Cursor = Cursors.Hand;
            rb.ForeColor = Color.Black;
        }

        public static void CheckBox_MouseEnter(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            cb.Cursor = Cursors.Hand;   
            cb.ForeColor = Color.White;
        }
        public static void CheckBox_MouseLeave(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            cb.Cursor = Cursors.Hand;
            cb.ForeColor = Color.Black;
        }

       
        public static void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            //ToolStripMenuItem
            ToolStripMenuItem tb = (ToolStripMenuItem)sender;
           
            tb.ForeColor = Color.White;
        }
        public static void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            ToolStripMenuItem tb = (ToolStripMenuItem)sender;
            tb.ForeColor = Color.Black;
        }

        #endregion

    }
}
