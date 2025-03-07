using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
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