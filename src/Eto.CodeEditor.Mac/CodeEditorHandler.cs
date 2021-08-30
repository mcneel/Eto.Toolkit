using System;
using System.Text;
using Eto;
using Eto.CodeEditor;
using Eto.CodeEditor.XamMac2;
using AppKit;
using ScintillaNET;
using Foundation;
using System.IO;
using ObjCRuntime;
using System.Collections.Generic;
using Scintilla;

[assembly: ExportHandler(typeof(CodeEditor), typeof(CodeEditorHandler))]

namespace Eto.CodeEditor
{
    public partial class CodeEditorHandler : Eto.Mac.Forms.MacView<Scintilla.ScintillaControl, CodeEditor, CodeEditor.ICallback>, CodeEditor.IHandler
    {
        static CodeEditorHandler()
        {
            var path = Path.Combine(NSBundle.MainBundle.PrivateFrameworksPath, "Scintilla.framework", "Scintilla");
            Dlfcn.dlopen(path, 4);
        }
        
        private Scintilla.ScintillaControl scintilla;

        private EtoScintillaNotificationProtocol notificationProtocol;
        public CodeEditorHandler()
        {
            scintilla = new Scintilla.ScintillaControl();
            scintilla.Callback = this;
            
            notificationProtocol = new EtoScintillaNotificationProtocol();
            notificationProtocol.Callback = this;
            scintilla.WeakDelegate = notificationProtocol;
            
            Control = scintilla;

            FontName = "Menlo";
            FontSize = 14;
            LineNumberColumnWidth = 40;
            ShowIndentationGuides();
            Control.Message(NativeMethods.SCI_AUTOCSETMAXHEIGHT, new IntPtr(10), IntPtr.Zero);
        }

        public override NSView ContainerControl => Control;

        public override bool Enabled { get; set; }

        public void SetKeywords(int set, string keywords)
        {
            Control.SetKeywords(set, keywords);
        }

        public void TriggerNotify(int message, char c, int position, int margin)
        {
            Control.HandleScintillaMessage(message, c, position, margin);
        }

        Encoding Encoding
        {
            get
            {
                int codePage = (int)Control.Message(NativeMethods.SCI_GETCODEPAGE, IntPtr.Zero, IntPtr.Zero);
                return (codePage == 0) ? Encoding.Default : Encoding.GetEncoding(codePage);
            }
        }
    }
}
