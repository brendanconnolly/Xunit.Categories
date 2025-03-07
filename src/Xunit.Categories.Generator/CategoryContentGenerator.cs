namespace Xunit.Categories.Generator;

public class CategoryContentGenerator
{
    private readonly TemplateRenderer _renderer;
    private readonly string[] _templateNames;

    public CategoryContentGenerator()
    {
        var provider = new CurrentAssemblyTemplateProvider();
        _renderer = new TemplateRenderer(provider);
        _templateNames = provider.GetTemplateNames();
    }

    public string GenerateCategoryFileContent(CategoryFile categoryFile, string categoryName)
    {
        var templateName = _templateNames.First(x =>
            x.Contains(categoryFile.ToString(), StringComparison.CurrentCultureIgnoreCase));
        return _renderer.RenderTemplate(templateName, new { categoryname= categoryName});
    }
    
    public Dictionary<CategoryFile, string> Generate(string categoryName)
    {
        Dictionary<CategoryFile, string> output = new Dictionary<CategoryFile, string>();
        foreach (CategoryFile categoryFile in Enum.GetValues(typeof(CategoryFile)))
        {
            output[categoryFile] = GenerateCategoryFileContent(categoryFile,categoryName);
        }

        return output;
    }
}