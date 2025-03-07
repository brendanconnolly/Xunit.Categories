using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class TestCaseTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(TestCaseTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [TestCase]
        public void TestCaseTest()
        {
            var testMethod = typeof(TestCaseTraitTests).GetMethod(nameof(TestCaseTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<TestCaseAttribute>();
        }

        [Fact]
        [TestCase("888")]
        public void TestCaseWithIdentifierAsString()
        {
            var testMethod = typeof(TestCaseTraitTests).GetMethod(nameof( TestCaseWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<TestCaseAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [TestCase(888)]
        public void TestCaseWithIdentifierAsInteger()
        {
            var testMethod = typeof(TestCaseTraitTests).GetMethod(nameof( TestCaseWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<TestCaseAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}