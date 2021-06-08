using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Web.WebView2.Core;
using System.Reflection;

namespace Ed.Wpf.TestApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      
      InitializeAsync();

      foreach (var t in new[] { ("vs", "Light"), ("vs-dark", "Dark"), ("hc-black", "High Contrast Dark") })
        themes.Items.Add(new Ed.Core.Theme(t.Item1, t.Item2));
      themes.SelectedIndex = 0;
      themes.SelectionChanged += themes_SelectionChanged;
      themes.Visibility = Visibility.Collapsed;

      //edWebView2 = new Ed.Wpf.EdWebView2(
      //  new Lib.EditorOptions(
      //    new Ed.Lib.Language("csharp", "C#"),
      //    new Lib.Theme("vs", "Light")
      //  )
      //);
    }

    public static List<Assembly> DefaultAssemblies()
    {
      List<Assembly> list = new List<Assembly>();

      list.Add(Assembly.GetAssembly(typeof(System.Uri)));
      //list.Add(Assembly.GetAssembly(typeof(Grasshopper.Utility)));
      //list.Add(Assembly.GetAssembly(typeof(GH_IO.GH_ISerializable)));
      list.Add(Assembly.GetAssembly(typeof(Rhino.RhinoApp)));
      //list.Add(Assembly.GetAssembly(typeof(System.Xml.Formatting)));
      //list.Add(Assembly.GetAssembly(typeof(System.Xml.Linq.XText)));
      //list.Add(Assembly.GetAssembly(typeof(System.Linq.IQueryable)));
      //list.Add(Assembly.GetAssembly(typeof(System.Windows.Forms.Appearance)));
      //list.Add(Assembly.GetAssembly(typeof(System.Drawing.Color)));
      //list.Add(Assembly.GetAssembly(typeof(System.Data.ConflictOption)));
      //list.Add(Assembly.GetAssembly(typeof(System.Net.AuthenticationManager)));
      //list.Add(Assembly.GetAssembly(typeof(System.ServiceModel.AuditLevel)));
      //list.Add(Assembly.GetAssembly(typeof(Microsoft.VisualBasic.AppWinStyle)));
      //list.Add(Assembly.GetAssembly(typeof(Microsoft.SqlServer.Server.DataAccessKind)));
      //if (HostUtils.RunningOnOSX)
      //  list.Add(Assembly.GetAssembly(typeof(ObjCRuntime.Runtime)));

      return list;
    }

    async void InitializeAsync()
    {
      var env = await  CoreWebView2Environment.CreateAsync(userDataFolder: System.IO.Path.Combine(System.IO.Path.GetTempPath(),"ed_texteditor"));
      await edWebView2.EnsureCoreWebView2Async(env);

      // this can only be called after EnsureCoreWebView2Async
      edWebView2.Source = new Uri("http://localhost:8081/index.html");

      CSharpCompletionProvider.CompletionProvider.Init();
      IList<string> u = new[]{
        "System", "System.Collections", "System.Collections.Generic",
        "Rhino", "Rhino.Geometry",
        "Grasshopper", "Grasshopper.Kernel", "Grasshopper.Kernel.Data", "Grasshopper.Kernel.Types"
      };
      Func<string, int, char, Task<List<string>>> getCompletions = (text, position, ch) =>
        new CSharpCompletionProvider.CompletionProvider(DefaultAssemblies(), u).GetCompletion(text, position, ch);

      //var dnho = new DotnetHostObject();
      //dnho.SetGetCompletions(getCompletions);
      var dnho = new CompletionProviderRemoteObject();
      dnho.SetGetCompletions(getCompletions);
      edWebView2.CoreWebView2.AddHostObjectToScript("csCompletions", dnho);
      //edWebView2.HookupCompletionProvider();
    }

    private void themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var theme = (themes.SelectedItem as Ed.Core.Theme) ?? new Core.Theme("vs", "Light");
      edWebView2.Theme = theme;
    }
  }
}
