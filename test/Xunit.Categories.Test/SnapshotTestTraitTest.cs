using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class SnapshotTestDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new SnapshotTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("SnapshotTest");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndSnapshotTestTrait()
        {
            var discoverer = new SnapshotTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("SnapshotTest")
            .And.ContainKey("SnapshotTest")
            .And.ContainValue("888");
        }
    }

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