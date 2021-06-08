using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;

namespace Ed.Wpf.TestApp
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public class App : Application
  {
    [STAThread]
    static void Main(string[] args)
    {
      var app = new App();
      app.Startup += App_Startup;
      app.Run();
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

    private static void App_Startup(object sender, StartupEventArgs e)
    {
      IList<string> u = new[]{
        "System", "System.Collections", "System.Collections.Generic",
        "Rhino", "Rhino.Geometry"
        //,"Grasshopper", "Grasshopper.Kernel", "Grasshopper.Kernel.Data", "Grasshopper.Kernel.Types"
      };
      var getCompletions = CSharpCompletionProvider.CompletionProvider.Create(u, DefaultAssemblies());

      var ed = new Ed.Wpf.EdWindow(u, getCompletions);
      ed.Height = 600;
      ed.Width = 800;
      ed.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      ed.Show();
    }
  }
}
