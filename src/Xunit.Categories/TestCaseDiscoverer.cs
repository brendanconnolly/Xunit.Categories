using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class TestCaseDiscoverer : ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(TestCaseDiscoverer);

        /// <summary>
        /// Gets the trait values from the trait attribute.
        /// </summary>
        /// <param name="traitAttribute"></param>
        /// <returns></returns>
		public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var testCaseId = traitAttribute.GetNamedArgument<string>("TestCaseId");

            yield return new KeyValuePair<string, string>("Category", "TestCase");

            if (!string.IsNullOrWhiteSpace(testCaseId))
                yield return new KeyValuePair<string, string>("TestCase", testCaseId);
        }
    }
}