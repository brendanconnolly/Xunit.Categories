using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
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