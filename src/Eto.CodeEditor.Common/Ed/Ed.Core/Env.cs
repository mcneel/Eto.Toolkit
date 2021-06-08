using System;
using System.Collections.Generic;
using System.Text;

namespace Ed.Core
{
  public static class Env
  {
    public static Uri Source => new Uri("file:///EdCoreAssembly/wwwroot/index.html");
    public static Uri SourceDebug => new Uri("http://localhost:8081/index.html");
    public static Uri SourceBlank => new Uri("http://localhost:8081/index-blank.html");
  }
}
