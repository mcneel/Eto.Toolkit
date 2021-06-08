using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Ed.Eto.Wpf
{
  [ClassInterface(ClassInterfaceType.AutoDual)]
  [ComVisible(true)]
  class DotnetHostObject
  {
    //private Func<string, int, char, Task<List<string>>> getCompletions;
    //internal void SetGetCompletions(Func<string, int, char, Task<List<string>>> getCompletions)
    //{
    //  this.getCompletions = getCompletions;
    //}

    public string GetCompletions(string request)
    {
      // parse the request (json?)
      return "not implemented"; // getCompletions()
    }
    public string GetObjectType(object obj)
    {
      return obj.GetType().Name;
    }
  }


  [ClassInterface(ClassInterfaceType.AutoDual)]
  [ComVisible(true)]
  public class AnotherRemoteObject
  {

    // Sample property.
    public string Prop { get; set; } = "AnotherRemoteObject.Prop";
  }

  public class CompletionRequest
  {
    public string code { get; set; }
    public int position { get; set; }
    public string ch { get; set; }
  }


  [ClassInterface(ClassInterfaceType.AutoDual)]
  [ComVisible(true)]
  public class CompletionProviderRemoteObject
  {
    private Func<string, int, char, Task<List<string>>> getCompletions;
    internal void SetGetCompletions(Func<string, int, char, Task<List<string>>> getCompletions)
    {
      this.getCompletions = getCompletions;
    }

    // Sample function that takes a parameter.
    public string GetCompletions(string request)
    {
      var utf8Reader = new Utf8JsonReader(UTF8Encoding.UTF8.GetBytes(request));
      var cr = JsonSerializer.Deserialize<CompletionRequest>(ref utf8Reader);
      char ch = cr.ch.First();
      var completions = getCompletions(cr.code, cr.position, ch);
      var strCompletions = JsonSerializer.Serialize(completions);
      return strCompletions;
    }

    // Sample function that takes no parameters.
    public string Func2()
    {
      return "BridgeAddRemoteObject.Func2()";
    }

    // Get type of an object.
    public string GetObjectType(object obj)
    {
      return obj.GetType().Name;
    }

    // Sample property.
    public string Prop { get; set; } = "BridgeAddRemoteObject.Prop";

    public AnotherRemoteObject AnotherObject { get; set; } = new AnotherRemoteObject();

    // Sample indexed property.
    [System.Runtime.CompilerServices.IndexerName("Items")]
    public string this[int index]
    {
      get { return m_dictionary[index]; }
      set { m_dictionary[index] = value; }
    }
    private Dictionary<int, string> m_dictionary = new Dictionary<int, string>();
  }
}
