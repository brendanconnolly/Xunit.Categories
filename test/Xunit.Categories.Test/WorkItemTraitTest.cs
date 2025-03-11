using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class WorkItemDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new WorkItemDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("WorkItem");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndWorkItemTrait()
        {
            var discoverer = new WorkItemDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("WorkItem")
            .And.ContainKey("WorkItem")
            .And.ContainValue("888");
        }
    }

    public class WorkItemTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(WorkItemTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [WorkItem]
        public void WorkItemTest()
        {
            var testMethod = typeof(WorkItemTraitTests).GetMethod(nameof(WorkItemTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<WorkItemAttribute>();
        }

        [Fact]
        [WorkItem("888")]
        public void WorkItemWithIdentifierAsString()
        {
            var testMethod = typeof(WorkItemTraitTests).GetMethod(nameof( WorkItemWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<WorkItemAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [WorkItem(888)]
        public void WorkItemWithIdentifierAsInteger()
        {
            var testMethod = typeof(WorkItemTraitTests).GetMethod(nameof( WorkItemWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<WorkItemAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}