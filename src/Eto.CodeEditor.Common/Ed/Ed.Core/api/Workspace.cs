using System;
using System.Collections.Generic;
using System.Text;

namespace Ed.Core
{
  public class Workspace// : IWorkspace
  {
    #region singleton
    private static Workspace _instance;
    private Workspace() { }
    public static Workspace Instance
    {
      get
      {
        if (_instance == null) _instance = new Workspace();
        return _instance;
      }
    }
    #endregion

    public enum TextEditorLineNumbersStyle { Off, On, Relative };
  }
}
