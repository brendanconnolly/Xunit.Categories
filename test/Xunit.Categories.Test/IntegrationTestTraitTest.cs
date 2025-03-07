using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class IntegrationTestTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(IntegrationTestTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [IntegrationTest]
        public void IntegrationTestTest()
        {
            var testMethod = typeof(IntegrationTestTraitTests).GetMethod(nameof(IntegrationTestTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<IntegrationTestAttribute>();
        }

        [Fact]
        [IntegrationTest("888")]
        public void IntegrationTestWithIdentifierAsString()
        {
            var testMethod = typeof(IntegrationTestTraitTests).GetMethod(nameof( IntegrationTestWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<IntegrationTestAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [IntegrationTest(888)]
        public void IntegrationTestWithIdentifierAsInteger()
        {
            var testMethod = typeof(IntegrationTestTraitTests).GetMethod(nameof( IntegrationTestWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<IntegrationTestAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}