namespace Xunit.Categories.Generator;

public class CategoryNameProvider
{
    private readonly string[] _categoryNames;

    public CategoryNameProvider()
    {
        _categoryNames =
        [
            "Author", "ArchitectureTest", "Bug", "Category", "Component", "DatabaseTest", "Description", "Documentation", "Expensive",
            "Exploratory", "Feature", "IntegrationTest", "KnownBug", "LocalTest", "SnapshotTest", "Specification", "SystemTest",
            "TestCase", "UnitTest", "UserStory", "WorkItem"
        ];
    }

    public CategoryNameProvider(string[] categoryNames)
    {
     _categoryNames = categoryNames;   
    }
    public string[] GetCategoryNames() => _categoryNames;
}