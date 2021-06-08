using System;
using System.Collections.Generic;
using System.Text;
using ec=Ed.Core;
using ef=Eto.Forms;
using e=Eto;
using System.Threading.Tasks;

namespace Ed.Eto
{
  [e.Handler(typeof(IEd))]
  public partial class Ed : ef.WebView//, ec.api.IApiNamespaces
  {
    public event EventHandler<EventArgs> EditorHasBeenInitialized;
    public bool EditorIsInitialized { get; private set; }
    private void OnEditorHasBeenInitialized(EventArgs e)
    {
      EditorIsInitialized = true;
      EditorHasBeenInitialized?.Invoke(this, e);
    }

    public Ed(/*ProgrammingLanguage*/string languageId, bool darkMode=false, 
            Func<string, int, char, Task<List<string>>> getCompletions = null,
            Action<string> logger = null)
    {
      this.Url = ec.Env.Source;
      //SetLanguage(language);

      //Handler.InvokeNowOrAfterDomContentLoaded(() => Window.ActiveTextEditor.Document.SetLanguageIdAsync(language));
      //var lanugages = GetLanguages();
      DocumentLoaded += (s, e) =>
      {
        Window.ActiveTextEditor.Document.SetLanguageIdAsync(languageId);
        RegisterGetCompletions(getCompletions);
        OnEditorHasBeenInitialized(EventArgs.Empty);
        SizeChanged += async (sender, ea) =>
        {
          await ExecuteScriptAsync($"ed.layout();");
        };
      };
    }

    public ec.Languages Languages => ec.Languages.Instance;
    public ec.Window Window => ec.Window.Instance;
    public ec.Workspace Workspace => ec.Workspace.Instance;

    new IEd Handler { get { return (IEd)base.Handler; } }

    //public async Task<string> GetLanguageAsync() => await Handler.GetLanguageAsync();

    //public void SetLanguage(string languageId)
    //{
    //  Handler.SetLanguage(languageId);
    //}

    //public event EventHandler MyEvent
    //{
    //  add => Handler.MyEvent += value;
    //  remove => Handler.MyEvent -= value;
    //}

    public void RegisterGetCompletions(Func<string, int, char, Task<List<string>>> getCompletions)
    {
      Handler.RegisterGetCompletions(getCompletions);
    }

    //public async Task<IList<string>> GetLanguagesAsync() => await Handler.GetLanguagesAsync(); 

    public interface IEd : ef.WebView.IHandler
    {
      //void InvokeNowOrAfterDomContentLoaded(Action action);
      //Task<string> GetLanguageAsync();
      //Task<IList<string>> GetLanguagesAsync();
      //void SetLanguage(string languageId);
      void RegisterGetCompletions(Func<string, int, char, Task<List<string>>> getCompletions);
      //IList<string> GetLanguages();

      //event EventHandler MyEvent;
    }
  }
}
