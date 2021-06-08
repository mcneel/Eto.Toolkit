using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using c = Microsoft.CodeAnalysis.Completion;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.Completion;
using System.IO;
using System;

namespace CSharpCompletionProvider
{

  public class CompletionProvider
  {
    public static Func<string, int, char, Task<List<string>>> Create(IList<string> usings, IList<Assembly> references)
    {
      Init();
      return (text, position, ch) =>
        new CompletionProvider(references, usings).GetCompletion(text, position, ch);
    }

    private AdhocWorkspace workspace;
    private Project scriptProject;

    private readonly List<MetadataReference> baseReferences = new List<MetadataReference>();

    private Action<string> logger;

    private static MefHostServices host;

    internal static void Init()
    {
            try
            {
                host = MefHostServices.Create(/*assemblies*/MefHostServices.DefaultAssemblies);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                Console.WriteLine(msg);
            }
    }

    private IList<string> usings;
    internal CompletionProvider(IEnumerable<Assembly> extraAssemblies, IList<string> usings, Action<string> logger = null)
    {
      if (host == null) Init();
      if (usings != null) this.usings = usings;
      if (logger != null) this.logger = logger;

      logger?.Invoke("CompletionProvider ctor begin");

      //var host = MefHostServices.Create(/*assemblies*/MefHostServices.DefaultAssemblies);
      
      workspace = new AdhocWorkspace(host);
      //workspace.AddProject()

      var compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, usings: usings ?? new[] { "System" });
      //var projectInfo = ProjectInfo.Create(ProjectId.CreateNewId(), VersionStamp.Create(), "MyProject", "MyProject", LanguageNames.CSharp).
      //  WithMetadataReferences(new[]
      //  {
      //     MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
      //  });
      //  project = workspace.AddProject(projectInfo);
      baseReferences.Add(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
      if (extraAssemblies != null)
        baseReferences.AddRange(extraAssemblies.Select(a => MetadataReference.CreateFromFile(a.Location)).ToList());

      var scriptProjectInfo = ProjectInfo.Create(ProjectId.CreateNewId(), VersionStamp.Create(), "Script", "Script", LanguageNames.CSharp, isSubmission: true)
         .WithMetadataReferences(baseReferences)
         .WithCompilationOptions(compilationOptions);

      scriptProject = workspace.AddProject(scriptProjectInfo);
      logger?.Invoke("CompletionProvider ctor end");
    }

    private List<string> GetSignatureCompletion(string code, int position)
    {
      if (usings != null || usings.Count > 0) {
        var nl = Environment.NewLine;
        var s = usings.Select(u => $"using {u};").Aggregate((a,b) => $"{a}{nl}{b}");
        //code = $"{s}{nl}{code}";
        //position = position + s.Length + 1;
      }
      position = position - 1; // todo: why?
      logger?.Invoke($"position: {position}");
      var signatures = new List<string>();
      SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
      CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
      var node = root.FindToken(position).Parent;

      while (node != null)
      {
        var typeName = node.GetType().Name;
        logger?.Invoke(/*node.GetType().Name*/typeName);
      	if (node is InvocationExpressionSyntax ies && ies.ArgumentList.Span.Contains(position)) {
      		node = ies.Expression;
      		break;
      	}
      	if (node is ObjectCreationExpressionSyntax oces && oces.ArgumentList.Span.Contains(position)) {
      		node = oces;
      		break;
      	}
      	if (node is AttributeSyntax attSyn && attSyn.ArgumentList.Span.Contains(position)) {
      		node = attSyn;
      		break;
      	}
      	node = node.Parent;
      }

      if (node != null)
      {
        var compilation = CSharpCompilation.Create("ScriptPadCompilation")
          //.AddReferences(MetadataReference.CreateFromFile(
          //	typeof(Point3d).Assembly.Location))
          //.AddReferences(
          //  MetadataReference.CreateFromFile(typeof(Guid).Assembly.Location)//,
          //  //MetadataReference.CreateFromFile(typeof(GeometryBase).Assembly.Location)
          //)
          .AddReferences(baseReferences)
          .AddSyntaxTrees(tree);

        SemanticModel model = compilation.GetSemanticModel(tree);

        IEnumerable<IMethodSymbol> mg = model.GetMemberGroup(node).OfType<IMethodSymbol>();
        if (mg != null)
        {
          var sigs = mg.Select(ims => ims.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat));
          if (sigs != null)
            signatures = sigs.ToList();
        }
      }
      return signatures;
    }

    public async Task<List<string>> GetCompletion(string code, int position, char ch)
    {
      //logger?.Invoke($"code:{Environment.NewLine}{code}{Environment.NewLine}position: {position}, char: {ch}");
      //var document = workspace.AddDocument(project.Id, "MyFile.cs", SourceText.From(code));

      //// position is the last occurrence of "Guid." in our test code
      //// in real life scenarios the editor surface should inform us
      //// about the current cursor position
      //var position = code.LastIndexOf("Guid.") + 5;

      //var completionService = c.CompletionService.GetService(document);
      //var results = await completionService.GetCompletionsAsync(document, position);
      var scriptDocumentInfo = DocumentInfo.Create(
          DocumentId.CreateNewId(scriptProject.Id), "Script",
          sourceCodeKind: SourceCodeKind.Script,
          loader: TextLoader.From(TextAndVersion.Create(SourceText.From(code), VersionStamp.Create())));
      var scriptDocument = workspace.AddDocument(scriptDocumentInfo);

      // cursor position is at the end
      //var position = code.Length - 1;

      List<string> results = null;
      if (ch == '(')
      {
        results = GetSignatureCompletion(code, position);
      }
      else
      {
        var completionService = c.CompletionService.GetService(scriptDocument);
        var cl = await completionService.GetCompletionsAsync(scriptDocument, position);
        if (cl != null)
        {
          Func<CompletionItem, bool> p = ci =>
            ci.Properties.TryGetValue("SymbolKind", out string sk)
              ? true
              : sk != "11";
          results = cl.Items.Where(ps => p(ps)/*ps.ps.Properties["SymbolKind"] != "11"*/).Select(i => i.DisplayText).ToList();
        }
      }

       return results == null
        ? new List<string>()
        : results;
    }
  }
}
