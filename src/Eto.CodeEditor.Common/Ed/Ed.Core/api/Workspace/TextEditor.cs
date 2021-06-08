using System;
using System.Collections.Generic;
using System.Text;

namespace Ed.Core.api.Workspace
{
  public class TextEditor
  {
    //private static TextEditor _instance;
    //private TextEditor() { }
    //public static TextEditor Instance
    //{
    //  get
    //  {
    //    if (_instance == null) _instance = new TextEditor();
    //    return _instance;
    //  }
    //}
    internal TextEditor()
    {
      _document = new TextDocument();
    }

    public TextEditorOptions Options => TextEditorOptions.Instance;
  
    public string Msg { get; set; }


    private TextDocument _document;
    public TextDocument Document => _document;
  }
}
