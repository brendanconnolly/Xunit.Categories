using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class CategoryDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new CategoryDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("Category");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndCategoryTrait()
        {
            var discoverer = new CategoryDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("Category")
            .And.ContainKey("Category")
            .And.ContainValue("888");
        }
    }

    public class CategoryTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(CategoryTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Category]
        public void CategoryTest()
        {
            var testMethod = typeof(CategoryTraitTests).GetMethod(nameof(CategoryTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<CategoryAttribute>();
        }

        [Fact]
        [Category("888")]
        public void CategoryWithIdentifierAsString()
        {
            var testMethod = typeof(CategoryTraitTests).GetMethod(nameof( CategoryWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<CategoryAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Category(888)]
        public void CategoryWithIdentifierAsInteger()
        {
            var testMethod = typeof(CategoryTraitTests).GetMethod(nameof( CategoryWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<CategoryAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}