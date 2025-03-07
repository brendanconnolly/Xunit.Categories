using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class TestOfTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(TestOfTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [TestOf]
        public void TestOfTest()
        {
            var testMethod = typeof(TestOfTraitTests).GetMethod(nameof(TestOfTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<TestOfAttribute>();
        }

        [Fact]
        [TestOf("888")]
        public void TestOfWithIdentifierAsString()
        {
            var testMethod = typeof(TestOfTraitTests).GetMethod(nameof( TestOfWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<TestOfAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [TestOf(888)]
        public void TestOfWithIdentifierAsInteger()
        {
            var testMethod = typeof(TestOfTraitTests).GetMethod(nameof( TestOfWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<TestOfAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}