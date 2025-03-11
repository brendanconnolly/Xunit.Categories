using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class ExpensiveDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new ExpensiveDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("Expensive");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndExpensiveTrait()
        {
            var discoverer = new ExpensiveDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("Expensive")
            .And.ContainKey("Expensive")
            .And.ContainValue("888");
        }
    }

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