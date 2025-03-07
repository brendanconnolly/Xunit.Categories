using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
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