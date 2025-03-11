using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class DescriptionDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new DescriptionDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("Description");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndDescriptionTrait()
        {
            var discoverer = new DescriptionDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("Description")
            .And.ContainKey("Description")
            .And.ContainValue("888");
        }
    }

    public class DescriptionTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(DescriptionTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Description]
        public void DescriptionTest()
        {
            var testMethod = typeof(DescriptionTraitTests).GetMethod(nameof(DescriptionTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DescriptionAttribute>();
        }

        [Fact]
        [Description("888")]
        public void DescriptionWithIdentifierAsString()
        {
            var testMethod = typeof(DescriptionTraitTests).GetMethod(nameof( DescriptionWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DescriptionAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Description(888)]
        public void DescriptionWithIdentifierAsInteger()
        {
            var testMethod = typeof(DescriptionTraitTests).GetMethod(nameof( DescriptionWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DescriptionAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}