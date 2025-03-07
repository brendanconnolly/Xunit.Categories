using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class ManualTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(ManualTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Manual]
        public void ManualTest()
        {
            var testMethod = typeof(ManualTraitTests).GetMethod(nameof(ManualTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ManualAttribute>();
        }

        [Fact]
        [Manual("888")]
        public void ManualWithIdentifierAsString()
        {
            var testMethod = typeof(ManualTraitTests).GetMethod(nameof( ManualWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ManualAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Manual(888)]
        public void ManualWithIdentifierAsInteger()
        {
            var testMethod = typeof(ManualTraitTests).GetMethod(nameof( ManualWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ManualAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}