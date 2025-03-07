using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
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