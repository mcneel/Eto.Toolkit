using System;
using Eto.Forms;
using Ed.Eto.TestApp;
using e = Eto;
using eew = Ed.Eto.Wpf;

namespace Ed.Eto.Wpf.TestApp
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
      var platform = new e.Wpf.Platform();
      platform.Add<Ed.IEd>(() => new eew.EdHandler());

			new Application(platform).Run(new MainForm());
		}
	}
}
