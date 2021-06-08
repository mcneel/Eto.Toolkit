using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Web.WebView2.Wpf;
using Microsoft.Web.WebView2.Core;

namespace Ed.Wpf
{
  public class EdWebView2 : WebView2
  {
    private string ExecJs(string js)
    {
      string r = CoreWebView2.ExecuteScriptAsync($"{js}").Result;
      return r;
    }

    private /*async*/ Task<string> ExecJsAsync(string js)
    {
      Task<string> r = /*await*/ CoreWebView2.ExecuteScriptAsync($"{js}");
      return r;
    }

    private Ed.Core.api.Workspace.TextEditor TextEditor;

    //public new Ed.Core.Language Language { get; }
    public Ed.Core.Theme Theme
    {
      get
      {
        string theme_key = CoreWebView2.ExecuteScriptAsync($"monaco.editor.theme").Result;
        return new Ed.Core.Theme(theme_key, "<desc>");
      }
      set
      {
        //CoreWebView2.ExecuteScriptAsync($"monaco.editor.setTheme('{value.Key}');");
        CoreWebView2.ExecuteScriptAsync($"ed.setTheme('{value.Key}');");
      }
    }

    public void HookupCompletionProvider()
    {
      CoreWebView2.ExecuteScriptAsync("ed.HookupCompletionProvider();");
    }

    //async void InitializeAsync()
    //{
    //  await EnsureCoreWebView2Async(null);
    //}

    public EdWebView2(/*IList<string> usings,*/ Func<string, int, char, Task<List<string>>> getCompletions = null) : base() {
      //DefaultBackgroundColor = System.Drawing.SystemColors.Control;
      InitializeAsync(getCompletions);
    }

    public EdWebView2() : base() {
      WebMessageReceived += EdWebView2_WebMessageReceived;
      InitializeAsync(null);
    }

    async public void RegisterGetCompletions(Func<string, int, char, Task<List<string>>> getCompletions)
    {
      if (getCompletions != null)
      {
        var env = await CoreWebView2Environment.CreateAsync(userDataFolder: System.IO.Path.Combine(System.IO.Path.GetTempPath(),"ed_texteditor"));
        await EnsureCoreWebView2Async(env);

        var dnho = new CompletionProviderRemoteObject();
        dnho.SetGetCompletions(getCompletions);
        CoreWebView2.AddHostObjectToScript("csCompletions", dnho);
        //edWebView2.HookupCompletionProvider();
      }
    }

    async void InitializeAsync(Func<string, int, char, Task<List<string>>> getCompletions)
    {
      var env = await CoreWebView2Environment.CreateAsync(userDataFolder: System.IO.Path.Combine(System.IO.Path.GetTempPath(),"ed_texteditor"));
      await EnsureCoreWebView2Async(env);

      Source = new Uri("http://localhost:8081/index.html");
      //Source = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"wwwroot\index.html"));

      RegisterGetCompletions(getCompletions);

      //Ed.Core.JsInterop.Init(js => CoreWebView2.ExecuteScriptAsync(js).Result);
      //obj = Ed.Core.JsInterop.Init(ExecJs);
      //CoreWebView2.NavigationCompleted += (s,e) => TextEditor = Ed.Core.api.Window.ActiveTextEditor;
      obj = Ed.Core.JsInterop.Init(ExecJs, ExecJsAsync);
      //CoreWebView2.NavigationCompleted += async (s,e) => TextEditor = await Ed.Core.api.Window.GetActiveTextEditorAsync();
      //CoreWebView2.NavigationCompleted += (s, e) => this.NavigationCompleted?.Invoke(this, e);
    }

    //public event EventHandler<EventArgs> InitCompleted;

    private Object obj; // try to hold on to the obj to see if it makes a difference. NOT

    private void doit()
    {
      CoreWebView2.ExecuteScriptAsync($"alert('{TextEditor.Msg}')");
    }

    private void EdWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
    {
      //var msg = e.TryGetWebMessageAsString();
      //CoreWebView2.ExecuteScriptAsync($"alert('{msg}');");
      doit();
    }
  }
}
