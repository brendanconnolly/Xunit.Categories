using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class BugTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(BugTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Bug]
        public void BugTest()
        {
            var testMethod = typeof(BugTraitTests).GetMethod(nameof(BugTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<BugAttribute>();
        }

        [Fact]
        [Bug("888")]
        public void BugWithIdentifierAsString()
        {
            var testMethod = typeof(BugTraitTests).GetMethod(nameof( BugWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<BugAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Bug(888)]
        public void BugWithIdentifierAsInteger()
        {
            var testMethod = typeof(BugTraitTests).GetMethod(nameof( BugWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<BugAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}