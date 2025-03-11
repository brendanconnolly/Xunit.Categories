using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class FeatureDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new FeatureDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("Feature");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndFeatureTrait()
        {
            var discoverer = new FeatureDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("Feature")
            .And.ContainKey("Feature")
            .And.ContainValue("888");
        }
    }

    public class FeatureTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(FeatureTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Feature]
        public void FeatureTest()
        {
            var testMethod = typeof(FeatureTraitTests).GetMethod(nameof(FeatureTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<FeatureAttribute>();
        }

        [Fact]
        [Feature("888")]
        public void FeatureWithIdentifierAsString()
        {
            var testMethod = typeof(FeatureTraitTests).GetMethod(nameof( FeatureWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<FeatureAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Feature(888)]
        public void FeatureWithIdentifierAsInteger()
        {
            var testMethod = typeof(FeatureTraitTests).GetMethod(nameof( FeatureWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<FeatureAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}