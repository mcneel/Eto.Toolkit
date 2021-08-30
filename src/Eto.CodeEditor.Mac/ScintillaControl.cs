using System;
using Scintilla;

namespace Scintilla
{
    public partial class ScintillaControl : ScintillaNET.ScintillaView, Eto.Mac.Forms.IMacControl
    {
        public WeakReference WeakHandler { get; set; }

        private IntPtr SciPointer => new IntPtr(-1); // not needed on macOS

        public ScintillaControl()
        {
            init();
        }
        
        internal IntPtr DirectMessage(IntPtr sciPtr, int msg, IntPtr wParam, IntPtr lParam)
        {
            return Message((uint)msg, wParam, lParam);
        }
        
    }
}
