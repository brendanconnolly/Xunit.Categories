using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Scriban;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Xunit.Categories.V3.Test.SourceGenerators
{
    [Generator]
    public class CategoryTestsGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            IncrementalValuesProvider<AdditionalText> categories = context.AdditionalTextsProvider
                .Where(f => f.Path.EndsWith("Xunit.Categories.txt", StringComparison.Ordinal));

            IncrementalValueProvider<FileOptions> inputs = categories.Collect()
                .Select(
                    static (x, _) => new FileOptions { CategoryFiles = x });

            context.RegisterSourceOutput(inputs, Execute);
        }

        private static void Execute(SourceProductionContext context, FileOptions result)
        {
            IEnumerable<string> categoryNames = GetCategoryNames(result.CategoryFiles);

            string traitTestTemplateFileContent = GetTemplateContent("TraitTest.liquid");

            var traitTestTemplate = Template.Parse(traitTestTemplateFileContent);

            foreach (string categoryName in categoryNames)
            {
                CreateTraitTestFile(categoryName, traitTestTemplate, context);
            }
        }

        private static void CreateTraitTestFile(string categoryName, Template template, SourceProductionContext context)
        {
            string output = template.Render(new
            {
                categoryname = categoryName
            });

            context.AddSource($"{categoryName}TraitTest.cs", SourceText.From(output, Encoding.UTF8));
        }

        private static IEnumerable<string> GetCategoryNames(IEnumerable<AdditionalText> categoryFiles)
        {
            List<string> categoryNames = [];

            foreach (AdditionalText categoryFile in categoryFiles)
            {
                SourceText? categoryFileContent = categoryFile.GetText();

                if (categoryFileContent == null)
                {
                    continue;
                }

                categoryNames.AddRange(categoryFileContent.Lines.Select(l => l.ToString()));
            }

            return categoryNames;
        }

        private static string GetTemplateContent(string fileName)
        {
            using var stream = typeof(CategoryTestsGenerator).Assembly.GetManifestResourceStream($"{typeof(CategoryTestsGenerator).Namespace}.Templates.{fileName}");

            using var streamReader = new StreamReader(stream);

            return streamReader.ReadToEnd();
        }
    }
}
