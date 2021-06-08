using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Eto.UnitTest.NUnit;
using System.Threading;

namespace Ed.Eto.TestApp
{
  [TestFixture]
  class EdTests
  {
    public static Ed ed { get; set; }

    [Test, InvokeOnUI]
    public void TextEditorOptions_TabSize_DefaultZero()
    {
      var task = ed.Window.ActiveTextEditor.Options.GetTabSizeAsync();
      task.Wait();
      //while (!task.IsCompleted)
      //  Thread.Sleep(10);
      Assert.AreEqual(0, task.Result);
    }
  }
}
