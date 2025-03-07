using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class DocumentationTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(DocumentationTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Documentation]
        public void DocumentationTest()
        {
            var testMethod = typeof(DocumentationTraitTests).GetMethod(nameof(DocumentationTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DocumentationAttribute>();
        }

        [Fact]
        [Documentation("888")]
        public void DocumentationWithIdentifierAsString()
        {
            var testMethod = typeof(DocumentationTraitTests).GetMethod(nameof( DocumentationWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DocumentationAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Documentation(888)]
        public void DocumentationWithIdentifierAsInteger()
        {
            var testMethod = typeof(DocumentationTraitTests).GetMethod(nameof( DocumentationWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DocumentationAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}