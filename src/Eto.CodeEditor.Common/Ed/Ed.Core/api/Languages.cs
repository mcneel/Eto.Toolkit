using System;
using System.Collections.Generic;
using System.Text;
using Ed.Core.api.Workspace;
using System.Threading.Tasks;
using System.Text.Json;

namespace Ed.Core
{
  public class Languages
  {
    #region singleton
    private static Languages _instance;
    private Languages() { }
    public static Languages Instance
    {
      get
      {
        if (_instance == null) _instance = new Languages();
        return _instance;
      }
    }
    #endregion

    public async Task<IList<string>> GetLanguagesAsync()
    {
      string json = await JsInterop.ExecJsAsync($"ed.Languages_GetLanguages();");
      return JsInterop.JsonToList(json);
    }
  }
}
