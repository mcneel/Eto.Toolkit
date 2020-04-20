using System;
using Eto.Drawing;
using Eto.Forms;

namespace Eto.CodeEditor.TestApp
{
    public class MainForm : Form
    {
        private FontDialog fd;
        public MainForm()
        {
            Title = $"CodeEditor Test, Platform: {Platform.ID}";
            Menu = new MenuBar();
            ClientSize = new Size(400, 400);


            var editor = new CodeEditor(ProgrammingLanguage.CSharp);
            editor.Text =
@"// Just some sample code
for( int i=0; i<10; i++ )
{
  print(i);
}";

            editor.SetupIndicatorStyles();
            editor.AddErrorIndicator(13, 6);

            Action<Font, string> pp = (f,pfx) => MessageBox.Show($"{pfx}: name: {editor.Font.FamilyName}, size: {editor.FontSize}");

            var btn = new Button { Text = "Font" };
            btn.Click += (s, e) =>
            {
                fd = new FontDialog();
                var originalFont = editor.Font ?? SystemFonts.Default();
                pp(originalFont, "original");
                fd.Font = originalFont;
                fd.FontChanged += (ss, ee) =>
                {
                    editor.Font = fd.Font;
                    pp(editor.Font, "FontChanged");
                };
                var r = fd.ShowDialog(this);

                // on windows
                editor.Font = (r == DialogResult.Ok || r == DialogResult.Yes)
                  ? fd.Font
                  : originalFont;

                pp(fd.Font, "fd");
            };
            Content = new TableLayout { Rows = { btn, editor } };
        }
    }
}
