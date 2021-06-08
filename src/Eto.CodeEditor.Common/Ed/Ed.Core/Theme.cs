using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ed.Core
{
  public enum ThemeEnum { vs, vs_dark, hc_black };

  public class Theme
  {
    public string Key { get; }
    public string Description { get; }

    public Theme(string key, string desc) => (Key, Description) = (key, desc);
  }

}
