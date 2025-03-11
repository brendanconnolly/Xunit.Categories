using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class SpecificationDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new SpecificationDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("Specification");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndSpecificationTrait()
        {
            var discoverer = new SpecificationDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("Specification")
            .And.ContainKey("Specification")
            .And.ContainValue("888");
        }
    }

    public class SpecificationTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(SpecificationTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Specification]
        public void SpecificationTest()
        {
            var testMethod = typeof(SpecificationTraitTests).GetMethod(nameof(SpecificationTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<SpecificationAttribute>();
        }

        [Fact]
        [Specification("888")]
        public void SpecificationWithIdentifierAsString()
        {
            var testMethod = typeof(SpecificationTraitTests).GetMethod(nameof( SpecificationWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<SpecificationAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Specification(888)]
        public void SpecificationWithIdentifierAsInteger()
        {
            var testMethod = typeof(SpecificationTraitTests).GetMethod(nameof( SpecificationWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<SpecificationAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}