namespace Xunit.Categories.Generator;

public class CategoryContentWriter
{
    public static void WriteFiles( string categoryName, Dictionary<CategoryFile, string> categoryContent)
    {
        var projectName = "Xunit.Categories";
        foreach (CategoryFile categoryFile in Enum.GetValues(typeof(CategoryFile)))
        {
            var projectDirectory = categoryFile.Equals(CategoryFile.TraitTest)? $"{projectName}.Test": projectName;
            Directory.CreateDirectory($"./output/{projectDirectory}");
            File.WriteAllText($"./output/{projectDirectory}/{categoryName}{categoryFile}.cs", categoryContent[categoryFile]);
        }
    }
}