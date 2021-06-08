using System;
using System.Linq;
using Eto.Drawing;
using Eto.Wpf.Forms.Controls;
using Eto.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using ec = Ed.Core;

//using WebView2Control = Microsoft.Web.WebView2.Wpf.WebView2;
//using BaseHandler = Eto.Wpf.Forms.WpfFrameworkElement<Microsoft.Web.WebView2.Wpf.WebView2, Ed.Eto.Ed, Ed.Eto.Ed.ICallback>;

namespace Ed.Eto.Wpf
{
  public class EdHandler : WebView2Handler, Ed.IEd
  {
    static EdHandler()
    {
      var opts = new Microsoft.Web.WebView2.Core.CoreWebView2EnvironmentOptions {
        //AdditionalBrowserArguments = " --disable-web-security"
        // the FILE:// scheme doesn't allow web workers to run unless the following argument is set
        AdditionalBrowserArguments = " --allow-file-access-from-files"
      };
      var env = Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(userDataFolder: System.IO.Path.Combine(System.IO.Path.GetTempPath(),"ed_texteditor"), options: opts).Result;
      EdHandler.CoreWebView2Environment = env;
    }

    //private bool _domContentLoaded;
    //private List<Action> _actionsToInvokeAfterDomContentLoaded;

    private new async Task<string> ExecuteScriptAsync(string script) => await Control.ExecuteScriptAsync(script);

    private new string ExecuteScript(string script)
    {
			var task = Control.ExecuteScriptAsync(script);
			while (!task.IsCompleted)
			{
				if (!Widget.Loaded)
					return null;
				Application.Instance.RunIteration();
				System.Threading.Thread.Sleep(10);
			}
			return task.Result;
    }

    public EdHandler()
    {
      //InvokeWhenCoreWebView2InitializationCompletedReady(() => Control.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived);
      InvokeWhenCoreWebView2InitializationCompleted(() => ec.JsInterop.Init(ExecuteScript, ExecuteScriptAsync));
      InvokeWhenCoreWebView2InitializationCompleted(() => CoreWebView2.AddWebResourceRequestedFilter("*", Microsoft.Web.WebView2.Core.CoreWebView2WebResourceContext.All));
      InvokeWhenCoreWebView2InitializationCompleted(() => CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested);
    }

    private static List<(string, string)> contentTypes = new List<(string, string)> { (".html", "text/html"), (".js", "application/javascript"), (".css", "text/css") };

    private void CoreWebView2_WebResourceRequested(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebResourceRequestedEventArgs e)
    {
      using (System.IO.Stream contentStream = ec.JsInterop.WebContentAsStream(e.Request.Uri))
      {
        var contentType = contentTypes.FirstOrDefault(t => t.Item1 == System.IO.Path.GetExtension(e.Request.Uri)).Item2 ?? "";

        System.IO.Stream responseStream = new System.IO.MemoryStream();
        contentStream.CopyTo(responseStream);
        contentStream.Flush();
        //contentStream.Position = 0;
        //using (var sr = new System.IO.StreamReader(contentStream))
        //{
        //  string html = sr.ReadToEnd();
        //}
            
        contentStream.Close();
        var response = CoreWebView2Environment.CreateWebResourceResponse(responseStream, 200, "OK", $"Content-Type: {contentType}\r\nCache-Control: no-cache");
        e.Response = response;
        //var httpRespMsg = new System.Net.HttpWebResponse( HttpResponseMessage
      }
    }

    //private void CoreWebView2_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
    //{
    //  string msg = e.WebMessageAsJson;
    //  // todo: need to design a real protocol here. In a future version of WebView2 js events like 'DOMContentLoaded' will
    //  // be available directly in .Net. 'DOMContentLoaded' has already been added to a recent version WebView2 but only in C++ AFAICT: https://github.com/MicrosoftEdge/WebView2Feedback/issues/253
    //  if (msg.Contains("DOMContentLoaded"))
    //  {
    //    _domContentLoaded = true;
    //    if (_actionsToInvokeAfterDomContentLoaded != null)
    //    {
    //      foreach (Action action in _actionsToInvokeAfterDomContentLoaded)
    //        action();
    //      _actionsToInvokeAfterDomContentLoaded = null;
    //    }
    //    Control.SizeChanged += async (s, scea) =>
    //    {
    //      //string sz = $"{{height:{Math.Max(scea.NewSize.Height-20, 20)}}}";
    //      //await ExecuteScriptAsync($"ed.layout({sz});");
    //      await ExecuteScriptAsync($"ed.layout();");
    //    };
    //  }
    //}

    private void InvokeWhenCoreWebView2InitializationCompleted(Action action)
    {
      if (WebView2Ready)
        action();
      else
        RunWhenReady(action);
    }

    //private void InvokeNowOrAfterDomContentLoaded(Action action)
    //{
    //  if (_domContentLoaded)
    //    action();
    //  else
    //  {
    //    if (_actionsToInvokeAfterDomContentLoaded == null)
    //      _actionsToInvokeAfterDomContentLoaded = new List<Action>();
    //    _actionsToInvokeAfterDomContentLoaded.Add(action);
    //  }
    //}

    //public event EventHandler MyEvent;

    //private void Control_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core./*CoreWebView2InitializationCompletedEventArgs*/CoreWebView2ReadyEventArgs e)
    //{
    //  //MyEvent?.Invoke(Widget, EventArgs.Empty);
    //}

    public ec.Window Window => ec.Window.Instance;

    //public async Task<string> GetLanguageAsync() => await ec.api.Languages.GetLanguageAsync();

    //public async Task<IList<string>> GetLanguagesAsync() => await ec.Languages.Instance.GetLanguagesAsync();

    //public void SetLanguage(string languageId)
    //{
    //  InvokeNowOrAfterDomContentLoaded(() => ec.api.Languages.SetLanguageAsync(languageId));
    //}

		//public override Color BackgroundColor
		//{
		//	get => Colors.Transparent;
		//	set { }
		//}

    public void RegisterGetCompletions(Func<string, int, char, Task<List<string>>> getCompletions)
    {
      Action rgc = () =>
      {
        var dnho = new CompletionProviderRemoteObject();
        dnho.SetGetCompletions(getCompletions);
        CoreWebView2.AddHostObjectToScript("csCompletions", dnho);
      };
      //InvokeWhenCoreWebView2InitializationCompletedReady(rgc);
      rgc.Invoke();
    }

    //public IList<string> GetLanguages() => Control.
  }
}
