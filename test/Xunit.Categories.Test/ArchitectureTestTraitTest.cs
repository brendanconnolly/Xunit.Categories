using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class ArchitectureTestDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new ArchitectureTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("ArchitectureTest");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndArchitectureTestTrait()
        {
            var discoverer = new ArchitectureTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("ArchitectureTest")
            .And.ContainKey("ArchitectureTest")
            .And.ContainValue("888");
        }
    }

    public class ArchitectureTestTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(ArchitectureTestTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [ArchitectureTest]
        public void ArchitectureTestTest()
        {
            var testMethod = typeof(ArchitectureTestTraitTests).GetMethod(nameof(ArchitectureTestTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ArchitectureTestAttribute>();
        }

        [Fact]
        [ArchitectureTest("888")]
        public void ArchitectureTestWithIdentifierAsString()
        {
            var testMethod = typeof(ArchitectureTestTraitTests).GetMethod(nameof( ArchitectureTestWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ArchitectureTestAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [ArchitectureTest(888)]
        public void ArchitectureTestWithIdentifierAsInteger()
        {
            var testMethod = typeof(ArchitectureTestTraitTests).GetMethod(nameof( ArchitectureTestWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ArchitectureTestAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}