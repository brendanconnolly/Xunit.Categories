using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class SnapshotTestTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(SnapshotTestTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [SnapshotTest]
        public void SnapshotTestTest()
        {
            var testMethod = typeof(SnapshotTestTraitTests).GetMethod(nameof(SnapshotTestTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<SnapshotTestAttribute>();
        }

        [Fact]
        [SnapshotTest("888")]
        public void SnapshotTestWithIdentifierAsString()
        {
            var testMethod = typeof(SnapshotTestTraitTests).GetMethod(nameof( SnapshotTestWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<SnapshotTestAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [SnapshotTest(888)]
        public void SnapshotTestWithIdentifierAsInteger()
        {
            var testMethod = typeof(SnapshotTestTraitTests).GetMethod(nameof( SnapshotTestWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<SnapshotTestAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}