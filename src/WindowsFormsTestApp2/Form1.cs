using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTestApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var editor = new ScintillaNET.Scintilla() { Location = new Point(0,0), Size = new Size(1500,500), BackColor = Color.White };
            Controls.Add(editor);
        }
    }
}
