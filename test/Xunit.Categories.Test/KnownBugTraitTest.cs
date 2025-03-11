using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class KnownBugDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new KnownBugDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("KnownBug");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndKnownBugTrait()
        {
            var discoverer = new KnownBugDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("KnownBug")
            .And.ContainKey("KnownBug")
            .And.ContainValue("888");
        }
    }

    public class KnownBugTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(KnownBugTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [KnownBug]
        public void KnownBugTest()
        {
            var testMethod = typeof(KnownBugTraitTests).GetMethod(nameof(KnownBugTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<KnownBugAttribute>();
        }

        [Fact]
        [KnownBug("888")]
        public void KnownBugWithIdentifierAsString()
        {
            var testMethod = typeof(KnownBugTraitTests).GetMethod(nameof( KnownBugWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<KnownBugAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [KnownBug(888)]
        public void KnownBugWithIdentifierAsInteger()
        {
            var testMethod = typeof(KnownBugTraitTests).GetMethod(nameof( KnownBugWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<KnownBugAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}