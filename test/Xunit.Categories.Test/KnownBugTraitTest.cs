using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
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