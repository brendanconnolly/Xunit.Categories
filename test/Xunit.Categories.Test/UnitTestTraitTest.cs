using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class UnitTestDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new UnitTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("UnitTest");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndUnitTestTrait()
        {
            var discoverer = new UnitTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("UnitTest")
            .And.ContainKey("UnitTest")
            .And.ContainValue("888");
        }
    }

    public class UnitTestTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(UnitTestTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [UnitTest]
        public void UnitTestTest()
        {
            var testMethod = typeof(UnitTestTraitTests).GetMethod(nameof(UnitTestTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<UnitTestAttribute>();
        }

        [Fact]
        [UnitTest("888")]
        public void UnitTestWithIdentifierAsString()
        {
            var testMethod = typeof(UnitTestTraitTests).GetMethod(nameof( UnitTestWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<UnitTestAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [UnitTest(888)]
        public void UnitTestWithIdentifierAsInteger()
        {
            var testMethod = typeof(UnitTestTraitTests).GetMethod(nameof( UnitTestWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<UnitTestAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}