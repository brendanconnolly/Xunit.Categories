using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class LocalTestDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new LocalTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("LocalTest");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndLocalTestTrait()
        {
            var discoverer = new LocalTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("LocalTest")
            .And.ContainKey("LocalTest")
            .And.ContainValue("888");
        }
    }

    public class LocalTestTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(LocalTestTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [LocalTest]
        public void LocalTestTest()
        {
            var testMethod = typeof(LocalTestTraitTests).GetMethod(nameof(LocalTestTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<LocalTestAttribute>();
        }

        [Fact]
        [LocalTest("888")]
        public void LocalTestWithIdentifierAsString()
        {
            var testMethod = typeof(LocalTestTraitTests).GetMethod(nameof( LocalTestWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<LocalTestAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [LocalTest(888)]
        public void LocalTestWithIdentifierAsInteger()
        {
            var testMethod = typeof(LocalTestTraitTests).GetMethod(nameof( LocalTestWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<LocalTestAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}