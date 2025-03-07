using Xunit.Categories.Generator;
using Xunit;
using FluentAssertions;

namespace Xunit.Categories.Generator.Tests;

public class CategoryContentGeneratorTests
{
    [Fact]
    public void GenerateCategoryContentForAttributeShouldUseExpectedTemplate()
    {
        var categoryName = "Burrito";
        var expectedCodeSnippet = $"public class {categoryName}Attribute:Attribute, ITraitAttribute";

        var templateProvider = new CategoryContentGenerator();
        var content = templateProvider.GenerateCategoryFileContent(CategoryFile.Attribute,categoryName);

        content.Should().Contain(categoryName).And.Contain(expectedCodeSnippet);
    }
    
    [Fact]
    public void GenerateCategoryContentForDiscovererShouldUseExpectedTemplate()
    {
        var categoryName = "Burrito";
        var expectedCodeSnippet = $"public class {categoryName}Discoverer:ITraitDiscoverer";

        var templateProvider = new CategoryContentGenerator();
        var content = templateProvider.GenerateCategoryFileContent(CategoryFile.Discoverer,categoryName);

        content.Should().Contain(categoryName).And.Contain(expectedCodeSnippet);
    }
    
    [Fact]
    public void GenerateCategoryContentForTraitTestShouldUseExpectedTemplate()
    {
        var categoryName = "Burrito";
        var expectedCodeSnippet = $"public class {categoryName}TraitTests";

        var templateProvider = new CategoryContentGenerator();
        var content = templateProvider.GenerateCategoryFileContent(CategoryFile.TraitTest,categoryName);

        content.Should().Contain(categoryName).And.Contain(expectedCodeSnippet);
    }
}