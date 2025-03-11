using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Xunit.Categories.Test
{
    public class TestCaseDiscoverTests
        {
        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            var discoverer = new TestCaseDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey("Category")
            .And.ContainValue("TestCase");
        }
        
        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndTestCaseTrait()
        {
            var discoverer = new TestCaseDiscoverer();
            var traits = discoverer.GetTraits( new MockAttributeInfo("888"));
            traits.Should().HaveCount(2)
            .And.ContainKey("Category")
            .And.ContainValue("TestCase")
            .And.ContainKey("TestCase")
            .And.ContainValue("888");
        }
    }

    public class TestCaseTraitTests
    {
        [Fact]
        public void FactTest()
        {
            var testMethod = typeof(TestCaseTraitTests).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }
        
        [Fact]
        [TestCase]
        public void TestCaseTest()
        {
            var testMethod = typeof(TestCaseTraitTests).GetMethod(nameof(TestCaseTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<TestCaseAttribute>();
        }

        [Fact]
        [TestCase("888")]
        public void TestCaseWithIdentifierAsString()
        {
            var testMethod = typeof(TestCaseTraitTests).GetMethod(nameof( TestCaseWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<TestCaseAttribute>()
                .Which.Identifier.Should().Be("888");
        }

        [Fact]
        [TestCase(888)]
        public void TestCaseWithIdentifierAsInteger()
        {
            var testMethod = typeof(TestCaseTraitTests).GetMethod(nameof( TestCaseWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<TestCaseAttribute>()
                    .Which.Identifier.Should().Be("888");
        }
                    
    }
}