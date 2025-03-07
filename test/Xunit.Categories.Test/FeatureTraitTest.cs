using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
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