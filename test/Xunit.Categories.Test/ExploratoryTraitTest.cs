using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class ExploratoryDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new ExploratoryDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("Exploratory");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndExploratoryTrait()
        {
            var discoverer = new ExploratoryDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("Exploratory")
            .And.ContainKey("Exploratory")
            .And.ContainValue("888");
        }
    }

    public class ExploratoryTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(ExploratoryTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Exploratory]
        public void ExploratoryTest()
        {
            var testMethod = typeof(ExploratoryTraitTests).GetMethod(nameof(ExploratoryTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ExploratoryAttribute>();
        }

        [Fact]
        [Exploratory("888")]
        public void ExploratoryWithIdentifierAsString()
        {
            var testMethod = typeof(ExploratoryTraitTests).GetMethod(nameof( ExploratoryWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ExploratoryAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Exploratory(888)]
        public void ExploratoryWithIdentifierAsInteger()
        {
            var testMethod = typeof(ExploratoryTraitTests).GetMethod(nameof( ExploratoryWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ExploratoryAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}