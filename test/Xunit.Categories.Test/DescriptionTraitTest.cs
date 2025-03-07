using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class DescriptionTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(DescriptionTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Description]
        public void DescriptionTest()
        {
            var testMethod = typeof(DescriptionTraitTests).GetMethod(nameof(DescriptionTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DescriptionAttribute>();
        }

        [Fact]
        [Description("888")]
        public void DescriptionWithIdentifierAsString()
        {
            var testMethod = typeof(DescriptionTraitTests).GetMethod(nameof( DescriptionWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DescriptionAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Description(888)]
        public void DescriptionWithIdentifierAsInteger()
        {
            var testMethod = typeof(DescriptionTraitTests).GetMethod(nameof( DescriptionWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DescriptionAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}