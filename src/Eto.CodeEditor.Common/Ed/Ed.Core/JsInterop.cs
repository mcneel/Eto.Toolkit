using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace Ed.Core
{
  public class JsInterop
  {
    public static string ExecJs(string js)
    {
      if (_instance == null || _instance._execJs == null) throw new NullReferenceException("JsInterop has not been initialized. Call Init() and pass it a proper delegate");
      var r = _instance._execJs(js);
      return r;
    }

    private JsInterop() { }

    private static JsInterop _instance;

    public static Object Init(Func<string, string> execJs, Func<string, Task<string>> execJsAsync)
    {
      _instance = new JsInterop
      {
        _execJs = execJs,
        _execJsAsync = execJsAsync
      };
      return _instance;
    }

    private Func<string, string> _execJs;
    private Func<string, Task<string>> _execJsAsync;

    public static async Task<string> ExecJsAsync(string js)
    {
      if (_instance == null || _instance._execJsAsync == null) throw new NullReferenceException("JsInterop has not been initialized. Call Init() and pass it a proper delegate");
      var r = await _instance._execJsAsync(js);
      return r;
    }

    public static System.IO.Stream WebContentAsStream(string uri)
    {
      System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
      string[] names = a.GetManifestResourceNames();
      var name = names.FirstOrDefault(n => uri.Replace("/", "\\").Contains(n));
      return a.GetManifestResourceStream(name);
    }

    internal static IList<string> JsonToList(string json)
    {
      Utf8JsonReader utf8Reader = new Utf8JsonReader(UTF8Encoding.UTF8.GetBytes(json));
      var list = JsonSerializer.Deserialize<IList<string>>(ref utf8Reader);
      return list;
    }

    internal static string RemoveDoubleQuotes(string text) => text.Replace("\"", "");
  }
}
