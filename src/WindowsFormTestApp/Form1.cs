using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormTestApp
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hWnd, String lpString);

        public Form1()
        {            
            InitializeComponent();
            var editor = new Scintilla.ScintillaControl { Location = new Point(0,0), Size = new Size(1500,500), BackColor = Color.Yellow };
            //editor.Text = "Hey there";
            this.Controls.Add(editor);
            this.Load += (s, e) =>
            {
                //SetWindowText(this.Handle, "hello winapi");
                editor.Text = "what is this?";
                var text = editor.Text;
                //SetWindowText(this.Handle, text);
            };
        }
    }
}
