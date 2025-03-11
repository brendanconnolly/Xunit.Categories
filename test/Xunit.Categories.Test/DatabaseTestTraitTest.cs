using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class DatabaseTestDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new DatabaseTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("DatabaseTest");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndDatabaseTestTrait()
        {
            var discoverer = new DatabaseTestDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("DatabaseTest")
            .And.ContainKey("DatabaseTest")
            .And.ContainValue("888");
        }
    }

    public class DatabaseTestTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(DatabaseTestTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [DatabaseTest]
        public void DatabaseTestTest()
        {
            var testMethod = typeof(DatabaseTestTraitTests).GetMethod(nameof(DatabaseTestTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DatabaseTestAttribute>();
        }

        [Fact]
        [DatabaseTest("888")]
        public void DatabaseTestWithIdentifierAsString()
        {
            var testMethod = typeof(DatabaseTestTraitTests).GetMethod(nameof( DatabaseTestWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DatabaseTestAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [DatabaseTest(888)]
        public void DatabaseTestWithIdentifierAsInteger()
        {
            var testMethod = typeof(DatabaseTestTraitTests).GetMethod(nameof( DatabaseTestWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<DatabaseTestAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}