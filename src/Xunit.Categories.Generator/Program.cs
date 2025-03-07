// See https://aka.ms/new-console-template for more information

using Xunit.Categories.Generator;

var contentGenerator = new CategoryContentGenerator();
var categoriesToCreate = new CategoryNameProvider().GetCategoryNames();

foreach (var categoryName in categoriesToCreate)
{
    var categoryContent = contentGenerator.Generate(categoryName);
    CategoryContentWriter.WriteFiles(categoryName, categoryContent);
}
