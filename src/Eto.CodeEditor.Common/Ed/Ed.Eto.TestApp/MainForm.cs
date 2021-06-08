using System;
using Eto.Forms;
using Eto.Drawing;
using Ed.Eto;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using ut = Eto.UnitTest;
using Workspace = Ed.Core.Workspace;

namespace Ed.Eto.TestApp
{
	public partial class MainForm : Form
	{
    static MainForm()
    {
        ut.NUnit.NUnitTestRunnerType.Register();
    }

		public MainForm()
		{
      IList<string> u = new[]{
        "System", "System.Collections", "System.Collections.Generic", "System.Linq",
        "Rhino", "Rhino.Geometry", "Rhino.RhinoDoc"
        //,"Grasshopper", "Grasshopper.Kernel", "Grasshopper.Kernel.Data", "Grasshopper.Kernel.Types"
      };
      IList<Assembly> assemblies = new[] {Assembly.GetAssembly(typeof(System.Linq.Enumerable)), Assembly.GetAssembly(typeof(Rhino.RhinoApp)) };
      var getCompletions = CSharpCompletionProvider.CompletionProvider.Create(u, assemblies);

			Title = "test app";
			MinimumSize = new Size(200, 200);

      Ed ed = null;

      #region unit tests panel
      var tests = new ut.UI.UnitTestPanel(true, Orientation.Vertical);

      LoadComplete += async (s, e) =>
      {
        var testSource = new ut.TestSource(System.Reflection.Assembly.GetExecutingAssembly());
        var mtr = new ut.Runners.MultipleTestRunner();
        await mtr.Load(testSource);
        tests.Runner = new ut.Runners.LoggingTestRunner(mtr);
        EdTests.ed = ed;
        //TestsThatRequireUserInteraction.editor = editor;
        //RegexTests.editor = editor;
      };
      #endregion

      #region controls
      ed = new Ed("csharp", false, getCompletions) { };
      var edOutputTextArea = new TextArea { Height = 200 };

      var textEditorOptionsPanel = new Panel();

      var insertSpacesCheckBox = new CheckBox() { Text = "insert spaces", Enabled = false, ThreeState = false };
      insertSpacesCheckBox.CheckedChanged += (s, e) => ed.Window.ActiveTextEditor.Options.SetInsertSpacesAsync(insertSpacesCheckBox.Checked ?? false);

      var lineNumbersDropDown = new EnumDropDown<Workspace.TextEditorLineNumbersStyle>() { Enabled = false };
      lineNumbersDropDown.SelectedValueChanged += (s, e) => ed.Window.ActiveTextEditor.Options.SetLineNumbersAsync(lineNumbersDropDown.SelectedValue);

      var tabSizeNum = new NumericStepper { Enabled = false, MinValue = 0, MaxValue = 16, DecimalPlaces = 0 };
      tabSizeNum.ValueChanged += (s, e) => ed.Window.ActiveTextEditor.Options.SetTabSizeAsync((int)tabSizeNum.Value);

      // color themes don't apply to the specific editor but all editors so it seems. Needs investigation
      var colorThemesDropDown = new DropDown { Enabled = false };
      #pragma warning disable 612, 618 
      colorThemesDropDown.SelectedKeyChanged += (s, e) => ed.Window.SetActiveColorThemeAsync(colorThemesDropDown.SelectedKey);
      #pragma warning restore 612, 618 

      var textDocumentPanel = new Panel();

      DropDown languagesDropDown = new DropDown { Enabled = false };
      languagesDropDown.SelectedKeyChanged += (s, e) => ed.Window.ActiveTextEditor.Document.SetLanguageIdAsync(languagesDropDown.SelectedKey);

      var docTextBtn = new Button { Text = "Show document text", Enabled = false };
      docTextBtn.Click += async (s, e) =>
      {
        string text = await ed.Window.ActiveTextEditor.Document.GetTextAsync();
        MessageBox.Show(text);
      };
      #endregion

      #region layout
      var edLayout = new StackLayout
      {
        Padding = 0,
        Items = { new StackLayoutItem(ed, true){VerticalAlignment=VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch } }
			};

      Font f = new Label().Font;
      Font bf = new Font(f.Family, f.Size, FontStyle.Bold);

      Func<string, Label> l = t => new Label { Text = t, VerticalAlignment = VerticalAlignment.Center };

      var propertiesTableLayout = new TableLayout
      {
        Padding = 3,
        Rows = {
          new TableLayout{Padding=new Padding(0, 0, 0, 1), Rows={ new Label { Text = "TextEditorOptions", Font = bf } }},
          new TableLayout{Padding=new Padding(5, 1, 0, 1), Rows ={ new TableRow { Cells = {insertSpacesCheckBox } } } },
          new TableLayout{Padding=new Padding(5, 1, 0, 1), Rows =
            {
              new TableRow{Cells={ l("Line numbers style  "), lineNumbersDropDown}},
              new TableRow{Cells={l("Tab size  "), tabSizeNum}}
            }
          },
          new TableLayout{Padding=new Padding(0,2,0,1), Rows={ new Label { Text = "Applies to all editors", Font = bf } } },
          new TableLayout{Padding=new Padding(5, 1, 0, 1), Rows={new TableRow { Cells = {l("Color theme  "), colorThemesDropDown}} }},
          new TableLayout{Padding=new Padding(0,2,0,1), Rows={ new Label { Text = "Applies to the TextDocument", Font = bf } }},
          new TableLayout{Padding=new Padding(5, 1, 0, 1), Rows={new TableRow { Cells = {l("Language  "), languagesDropDown}} }},
          null
        }
      };

      var tabControl = new TabControl { Pages = { new TabPage { Text = "Properties", Content = propertiesTableLayout }, new TabPage { Text = "Tests", Content = tests } } };
      var splitter = new Splitter
      {
          Panel1 = tabControl,
          Panel2 = edLayout //new Splitter { Panel1 = edLayout, Panel2 = edOutputTextArea, Orientation = Orientation.Vertical, Panel1MinimumSize = 100, FixedPanel = SplitterFixedPanel.Panel2 }
      };
      Content = new TableLayout { Rows = { splitter } };
      #endregion

      ed.EditorHasBeenInitialized += async (sender, ea) => {
        insertSpacesCheckBox.Enabled = true;
        insertSpacesCheckBox.Checked = await ed.Window.ActiveTextEditor.Options.GetInsertSpacesAsync();

        lineNumbersDropDown.Enabled = true;
        lineNumbersDropDown.SelectedValue = await ed.Window.ActiveTextEditor.Options.GetLineNumbersAsync();

        tabSizeNum.Enabled = true;
        tabSizeNum.Value = await ed.Window.ActiveTextEditor.Options.GetTabSizeAsync();

        colorThemesDropDown.Enabled = true;
        #pragma warning disable 612, 618
        IList<string> colorThemes = await ed.Window.GetColorThemesAsync();
        if (colorThemes != null)
          colorThemesDropDown.DataStore = colorThemes.Select(ct => new ListItem { Key = ct, Text = ct });
        string colorTheme = await ed.Window.GetActiveColorThemeAsync();
        if (colorTheme != null)
          colorThemesDropDown.SelectedKey = colorTheme;
        #pragma warning restore 612, 618 

        languagesDropDown.Enabled = true;
        IList<string> languageIds = await ed.Languages.GetLanguagesAsync();
        if (languageIds != null)
          languagesDropDown.DataStore = languageIds.Select(lid => new ListItem { Key = lid, Text = lid });
        string languageId = await ed.Window.ActiveTextEditor.Document.GetLanguageIdAsync();
        if (languageId != null)
          languagesDropDown.SelectedKey = languageId;

        docTextBtn.Enabled = true;
      };

			// create a few commands that can be used for the menu and toolbar
			var clickMe = new Command { MenuText = "Click Me!", ToolBarText = "Click Me!" };
			clickMe.Executed += (sender, e) => MessageBox.Show(this, "I was clicked!");

			var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
			quitCommand.Executed += (sender, e) => Application.Instance.Quit();

			var aboutCommand = new Command { MenuText = "About..." };
			aboutCommand.Executed += (sender, e) => new AboutDialog().ShowDialog(this);

			// create menu
			Menu = new MenuBar
			{
				Items =
				{
					// File submenu
					new ButtonMenuItem { Text = "&File", Items = { clickMe } },
					// new ButtonMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
					// new ButtonMenuItem { Text = "&View", Items = { /* commands/items */ } },
				},
				ApplicationItems =
				{
					// application (OS X) or file menu (others)
					new ButtonMenuItem { Text = "&Preferences..." },
				},
				QuitItem = quitCommand,
				AboutItem = aboutCommand
			};
		}
	}
}
