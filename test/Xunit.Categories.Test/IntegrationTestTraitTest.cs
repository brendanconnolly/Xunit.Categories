using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class IntegrationTestDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new IntegrationTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("IntegrationTest");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndIntegrationTestTrait()
        {
            var discoverer = new IntegrationTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("IntegrationTest")
            .And.ContainKey("IntegrationTest")
            .And.ContainValue("888");
        }
    }

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