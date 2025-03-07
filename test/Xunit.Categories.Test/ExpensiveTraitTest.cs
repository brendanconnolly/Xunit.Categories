using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class ExpensiveTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(ExpensiveTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Expensive]
        public void ExpensiveTest()
        {
            var testMethod = typeof(ExpensiveTraitTests).GetMethod(nameof(ExpensiveTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ExpensiveAttribute>();
        }

        [Fact]
        [Expensive("888")]
        public void ExpensiveWithIdentifierAsString()
        {
            var testMethod = typeof(ExpensiveTraitTests).GetMethod(nameof( ExpensiveWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ExpensiveAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Expensive(888)]
        public void ExpensiveWithIdentifierAsInteger()
        {
            var testMethod = typeof(ExpensiveTraitTests).GetMethod(nameof( ExpensiveWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ExpensiveAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}