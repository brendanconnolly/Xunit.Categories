using FluentAssertions;
using System.Collections.Generic;

namespace Xunit.Categories.Test
{
    public class LongRunningDiscoverTests
    {
        private const string CategoryKey = "Category";
        private const string CategoryValue = "LongRunning";
        private const string IdentifierValue = "888";

        [Fact]
        public void WhenNoIdentifierSpecifiedShouldAddCategoryTrait()
        {
            LongRunningDiscoverer discoverer = new LongRunningDiscoverer();
            IEnumerable<KeyValuePair<string, string>> traits = discoverer.GetTraits(new MockAttributeInfo());
            traits.Should().HaveCount(1)
            .And.ContainKey(CategoryKey)
            .And.ContainValue(CategoryValue);
        }

        [Fact]
        public void WhenIdentifierSpecifiedShouldAddCategoryAndLongRunningTestTrait()
        {
            LongRunningDiscoverer discoverer = new LongRunningDiscoverer();
            IEnumerable<KeyValuePair<string, string>> traits = discoverer.GetTraits(new MockAttributeInfo(IdentifierValue));
            traits.Should().HaveCount(2)
            .And.ContainKey(CategoryKey)
            .And.ContainValue(CategoryValue)
            .And.ContainKey(CategoryValue)
            .And.ContainValue(IdentifierValue);
        }
    }

    public class LongRunningTraitTest
    {
        private const string IdentifierValue = "888";

        [Fact]
        public void FactTest()
        {
            System.Reflection.MethodInfo testMethod = typeof(LongRunningTraitTest).GetMethod(nameof(FactTest));
            testMethod.Should().BeDecoratedWith<FactAttribute>();
        }

        [Fact]
        [LongRunning]
        public void LongRunningTest()
        {
            System.Reflection.MethodInfo testMethod = typeof(LongRunningTraitTest).GetMethod(nameof(LongRunningTest));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<LongRunningAttribute>();
        }

        [Fact]
        [LongRunning(IdentifierValue)]
        public void LongRunningTestWithIdentifierAsString()
        {
            System.Reflection.MethodInfo testMethod = typeof(LongRunningTraitTest).GetMethod(nameof(LongRunningTestWithIdentifierAsString));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<LongRunningAttribute>()
                .Which.Identifier.Should().Be(IdentifierValue);
        }

        [Fact]
        [LongRunning(888)]
        public void LongRunningTestWithIdentifierAsInteger()
        {
            System.Reflection.MethodInfo testMethod = typeof(LongRunningTraitTest).GetMethod(nameof(LongRunningTestWithIdentifierAsInteger));
            testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
                .And.BeDecoratedWith<LongRunningAttribute>()
                    .Which.Identifier.Should().Be(IdentifierValue);
        }
    }
}
