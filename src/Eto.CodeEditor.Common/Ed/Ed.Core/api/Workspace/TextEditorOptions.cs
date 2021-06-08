using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ed.Core.api.Workspace
{
  //public enum TextEditorLineNumbersStyle { Off, On, Relative };

  // https://code.visualstudio.com/api/references/vscode-api#TextEditorOptions
  public class TextEditorOptions
  {
    #region singleton
    private static TextEditorOptions _instance;
    private TextEditorOptions() { }
    public static TextEditorOptions Instance
    {
      get
      {
        if (_instance == null) _instance = new TextEditorOptions();
        return _instance;
      }
    }
    #endregion

    // https://microsoft.github.io/monaco-editor/api/interfaces/monaco.editor.ieditoroptions.html#usetabstops
    public async Task<bool> GetInsertSpacesAsync()
    {
      const string js = "ed.TextEditorOptions_GetInsertSpaces();";
      string insertSpacesStr = await JsInterop.ExecJsAsync(js);
      Boolean.TryParse(insertSpacesStr, out bool insertSpaces);
      return insertSpaces;
    }

    public async void SetInsertSpacesAsync(bool insertSpaces)
    {
      string insertSpacesStr = insertSpaces.ToString().ToLower();
      await JsInterop.ExecJsAsync($"ed.TextEditorOptions_SetInsertSpaces('{insertSpacesStr}');");
    }

    // https://microsoft.github.io/monaco-editor/api/enums/monaco.editor.renderlinenumberstype.html
    public async Task<Ed.Core.Workspace.TextEditorLineNumbersStyle> GetLineNumbersAsync()
    {
      string lineNumbersStr = await JsInterop.ExecJsAsync("ed.TextEditorOptions_GetLineNumbers();");
      Enum.TryParse<Ed.Core.Workspace.TextEditorLineNumbersStyle>(lineNumbersStr, out Ed.Core.Workspace.TextEditorLineNumbersStyle telns);
      return telns;
    }

    public async void SetLineNumbersAsync(Ed.Core.Workspace.TextEditorLineNumbersStyle style)
    {
      string lns = style.ToString().ToLower();
      await JsInterop.ExecJsAsync($"ed.TextEditorOptions_SetLineNumbers('{lns}');");
    }

    public async Task<int> GetTabSizeAsync()
    {
      const string js = "ed.TextEditorOptions_GetTabSize();";
      string tabSizeStr = await JsInterop.ExecJsAsync(js);
      Int32.TryParse(tabSizeStr, out int ts);
      return ts;
    }

    public async void SetTabSizeAsync(int size)
    {
      await JsInterop.ExecJsAsync($"ed.TextEditorOptions_SetTabSize('{size}');");
    }
  }
}
