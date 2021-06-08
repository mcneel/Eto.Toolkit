using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eto;
using Eto.Forms;
using Eto.CodeEditor;
using ScintillaNET;
using Eto.Drawing;
using System.Windows.Forms;
using Eto.Wpf.Forms;

[assembly: ExportHandler(typeof(CodeEditor), typeof(CodeEditorHandler))]

namespace Eto.CodeEditor
{
    //public partial class CodeEditorHandler : Eto.Wpf.Forms.WindowsFormsHostHandler<Scintilla.ScintillaControl, CodeEditor, CodeEditor.ICallback>, CodeEditor.IHandler
    //public partial class CodeEditorHandler : WindowsFormsHostHandler<Scintilla.ScintillaControl, CodeEditor, CodeEditor.ICallback>, CodeEditor.IHandler
    public partial class CodeEditorHandler : Eto.Wpf.Forms.Controls.WebView2Handler, CodeEditor.IHandler
    {

        //private Scintilla.ScintillaControl scintilla;

        public CodeEditorHandler()
        {
            //scintilla = new Scintilla.ScintillaControl(); // new ScintillaNET.Scintilla();
            //scintilla.DirectMessage(NativeMethods.SCI_AUTOCSETMAXHEIGHT, new IntPtr(10));
            //scintilla.DirectMessage(NativeMethods.SCI_SETAUTOMATICFOLD, new IntPtr(NativeMethods.SC_AUTOMATICFOLD_CLICK));
            
            FontName = "Consolas";
            FontSize = 11;
            LineNumberColumnWidth = 40;
        }

        Encoding Encoding
        {
            get
            {
                int codePage = scintilla.DirectMessage(NativeMethods.SCI_GETCODEPAGE, IntPtr.Zero, IntPtr.Zero).ToInt32();
                return (codePage == 0) ? Encoding.Default : Encoding.GetEncoding(codePage);
            }
        }

        public override Eto.Drawing.Color BackgroundColor
        {
          get
          {
            return Eto.Drawing.Colors.Transparent;
          }
          set
          {
            throw new NotImplementedException();
          }
        }

        public void RegisterGetCompletions(Func<string, int, char, Task<List<string>>> getCompletions)
        {
          Action rgc = () =>
          {
            var dnho = new CompletionProviderRemoteObject();
            dnho.SetGetCompletions(getCompletions);
            CoreWebView2.AddHostObjectToScript("csCompletions", dnho);
          };
          rgc.Invoke();
        }
    }


}
