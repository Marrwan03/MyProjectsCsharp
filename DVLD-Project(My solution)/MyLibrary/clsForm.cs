using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary
{
    public partial class clsForm : Form
    {
        public clsForm()
        {
            InitializeComponent();
        }

        public static void SetForm(Form frm, int Width, int Height)
        {
            frm.Size = new Size(Width, Height);
            frm.Location = new Point(0, 0);
        }

        public static void ShowPassword(object sender, EventArgs e)
        {
          
            char CharPassword = default;
            TextBox textBox = (TextBox)sender;
            textBox.PasswordChar = CharPassword;
        }

        public static void HidePassword(object sender, EventArgs e, char Symbol)
        {
            char CharPassword = Symbol;
            TextBox textBox = (TextBox)sender;
            textBox.PasswordChar = CharPassword;
        }

        

        private void clsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
