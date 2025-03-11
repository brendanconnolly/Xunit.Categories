using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class SystemTestDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new SystemTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("SystemTest");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndSystemTestTrait()
        {
            var discoverer = new SystemTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("SystemTest")
            .And.ContainKey("SystemTest")
            .And.ContainValue("888");
        }
    }

    public class SystemTestTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(SystemTestTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [SystemTest]
        public void SystemTestTest()
        {
            var testMethod = typeof(SystemTestTraitTests).GetMethod(nameof(SystemTestTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<SystemTestAttribute>();
        }

        [Fact]
        [SystemTest("888")]
        public void SystemTestWithIdentifierAsString()
        {
            var testMethod = typeof(SystemTestTraitTests).GetMethod(nameof( SystemTestWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<SystemTestAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [SystemTest(888)]
        public void SystemTestWithIdentifierAsInteger()
        {
            var testMethod = typeof(SystemTestTraitTests).GetMethod(nameof( SystemTestWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<SystemTestAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}