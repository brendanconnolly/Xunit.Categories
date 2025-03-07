using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
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