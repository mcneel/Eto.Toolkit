using System;
using System.Collections.Generic;
using System.Text;
using Ed.Core.api.Workspace;
using System.Threading.Tasks;

namespace Ed.Core
{
  public class Window // : IWindow
  {
    #region singleton
    private static Window _instance;
    private Window() {
      // only one for now
      _textEditor = new TextEditor();
    }
    public static Window Instance
    {
      get
      {
        if (_instance == null) _instance = new Window();
        return _instance;
      }
    }
    #endregion

    private TextEditor _textEditor;

    public TextEditor ActiveTextEditor
    {
      get
      {
        // only one editor supported for now
        return _textEditor;
      }
    }

    // maybe Obsolete is not the correct attribute. Wanting to convey that the following functions are not part of the VSCode api and something more appropriate may replace them at some point.
    [Obsolete("Not part of the vscode api")]
    public async Task<IList<string>> GetColorThemesAsync()
    {
      string json = await JsInterop.ExecJsAsync($"ed.Window_GetColorThemes();");
      //return new[] { "vs", "vs-dark", "hc-black" };
      return JsInterop.JsonToList(json);
    }

    [Obsolete("Not part of the vscode api")]
    public async Task<string> GetActiveColorThemeAsync()
    {
      string colorTheme = await JsInterop.ExecJsAsync("ed.Window_GetActiveColorTheme();");
      return JsInterop.RemoveDoubleQuotes(colorTheme);
    }

    [Obsolete("Not part of the vscode api")]
    public async void SetActiveColorThemeAsync(string theme) => await JsInterop.ExecJsAsync($"ed.Window_SetActiveColorTheme('{theme}');");
  }
}
