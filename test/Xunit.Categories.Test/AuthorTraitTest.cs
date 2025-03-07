using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class AuthorTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(AuthorTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [Author]
        public void AuthorTest()
        {
            var testMethod = typeof(AuthorTraitTests).GetMethod(nameof(AuthorTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<AuthorAttribute>();
        }

        [Fact]
        [Author("888")]
        public void AuthorWithIdentifierAsString()
        {
            var testMethod = typeof(AuthorTraitTests).GetMethod(nameof( AuthorWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<AuthorAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [Author(888)]
        public void AuthorWithIdentifierAsInteger()
        {
            var testMethod = typeof(AuthorTraitTests).GetMethod(nameof( AuthorWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<AuthorAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}