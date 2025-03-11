using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class ComponentDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new ComponentDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("Component");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndComponentTrait()
        {
            var discoverer = new ComponentDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("Component")
            .And.ContainKey("Component")
            .And.ContainValue("888");
        }
    }

    public class ComponentTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(ComponentTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Component]
        public void ComponentTest()
        {
            var testMethod = typeof(ComponentTraitTests).GetMethod(nameof(ComponentTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ComponentAttribute>();
        }

        [Fact]
        [Component("888")]
        public void ComponentWithIdentifierAsString()
        {
            var testMethod = typeof(ComponentTraitTests).GetMethod(nameof( ComponentWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ComponentAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Component(888)]
        public void ComponentWithIdentifierAsInteger()
        {
            var testMethod = typeof(ComponentTraitTests).GetMethod(nameof( ComponentWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<ComponentAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}