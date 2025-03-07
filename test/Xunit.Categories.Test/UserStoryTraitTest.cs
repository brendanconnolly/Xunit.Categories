using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class UserStoryTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(UserStoryTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [UserStory]
        public void UserStoryTest()
        {
            var testMethod = typeof(UserStoryTraitTests).GetMethod(nameof(UserStoryTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<UserStoryAttribute>();
        }

        [Fact]
        [UserStory("888")]
        public void UserStoryWithIdentifierAsString()
        {
            var testMethod = typeof(UserStoryTraitTests).GetMethod(nameof( UserStoryWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<UserStoryAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [UserStory(888)]
        public void UserStoryWithIdentifierAsInteger()
        {
            var testMethod = typeof(UserStoryTraitTests).GetMethod(nameof( UserStoryWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<UserStoryAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}