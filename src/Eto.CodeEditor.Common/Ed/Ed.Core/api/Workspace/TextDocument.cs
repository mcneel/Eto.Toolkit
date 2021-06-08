using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ed.Core.api.Workspace
{
    public class TextDocument
    {
        internal TextDocument() { }

        public EndOfLine Eol { get; set; }
        public string FileName { get; set; }
        public bool IsClosed { get; }
        public bool IsDirty { get; }
        public bool IsUntitled { get; }

        //public string LanguageId
        //{
        //  get {
        //    return "";
        //  }
        //  set
        //  {
        //    //pass
        //  }
        //}

        public async Task<string> GetLanguageIdAsync()
        {
          string languageId = await JsInterop.ExecJsAsync("ed.TextDocument_GetLanguageId();");
          return JsInterop.RemoveDoubleQuotes(languageId);
        }
    
        public async void SetLanguageIdAsync(string languageId)
        {
          await JsInterop.ExecJsAsync($"ed.TextDocument_SetLanguageId('{languageId}');");
        }

        public int LineCount { get; }
        public Uri Uri { get; set; }
        public int Version { get; }

        //public string GetText(Range range = null)
        //{
        //    return "not implemented"; 
        //}
        public async Task<string> GetTextAsync(Range range = null)
        {
          if (range != null) throw new NotSupportedException("GetText does not support the Range argument yet");
          const string js = "ed.TextDocument_GetText();";
          string text = await JsInterop.ExecJsAsync(js);
          return text;
        }
    
        public async void SetTextAsync(string text)
        {
          await JsInterop.ExecJsAsync($"ed.TextDocument_SetText('{text}');");
        }

        public TextLine LineAt(Position position)
        {
            return null; // not implemented
        }

        public TextLine LineAt(int lineNumber)
        {
            return null; // not implemented

        }
    }
}
