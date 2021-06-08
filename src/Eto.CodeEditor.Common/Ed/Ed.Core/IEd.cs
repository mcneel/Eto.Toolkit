using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ed.Core
{
  public interface IEd
  {
    void RegisterGetCompletions(Func<string, int, char, Task<List<string>>> getCompletions);
  }
}
