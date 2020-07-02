using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using c = Microsoft.CodeAnalysis.Completion;
using System.Threading.Tasks;
using System;

namespace CompilerServices
{
    public class CompletionService
    {
        public static async Task GetCompletion(string code)
        {
            var host = MefHostServices.Create(MefHostServices.DefaultAssemblies);
            var workspace = new AdhocWorkspace(host);

//            var code = @"using System;
 
//public class MyClass
//{
//    public static void MyMethod(int value)
//    {
//        Guid.
//    }
//}";

            var projectInfo = ProjectInfo.Create(ProjectId.CreateNewId(), VersionStamp.Create(), "MyProject", "MyProject", LanguageNames.CSharp).
               WithMetadataReferences(new[]
               {
       MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
               });
            var project = workspace.AddProject(projectInfo);
            var document = workspace.AddDocument(project.Id, "MyFile.cs", SourceText.From(code));

            // position is the last occurrence of "Guid." in our test code
            // in real life scenarios the editor surface should inform us
            // about the current cursor position
            var position = code.LastIndexOf("Guid.") + 5;

            var completionService = c.CompletionService.GetService(document);
            var results = await completionService.GetCompletionsAsync(document, position);

            foreach (var i in results.Items)
            {
                Console.WriteLine(i.DisplayText);

                foreach (var prop in i.Properties)
                {
                    Console.Write($"{prop.Key}:{prop.Value}  ");
                }

                Console.WriteLine();
                foreach (var tag in i.Tags)
                {
                    Console.Write($"{tag}  ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
