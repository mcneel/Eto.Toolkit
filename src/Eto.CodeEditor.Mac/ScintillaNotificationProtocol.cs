using System;
using System.Runtime.InteropServices;
using System.Text;
using Scintilla;
using ScintillaNET;

namespace Eto.CodeEditor.XamMac2
{
    class EtoScintillaNotificationProtocol : ScintillaNotificationProtocol
    {
        WeakReference _callback;
        public CodeEditorHandler Callback
        {
            get => _callback?.Target as CodeEditorHandler;
            set => _callback = new WeakReference(value);
        }
        public override void Notification(IntPtr notification)
        {
            var n = Marshal.PtrToStructure<SCNotification>(notification);
            Callback?.TriggerNotify((int)n.nmhdr.code, (char)n.ch, (int)n.position, n.margin);
        }
    }
}
