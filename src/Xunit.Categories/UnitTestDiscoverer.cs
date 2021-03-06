using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class UnitTestDiscoverer:ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(UnitTestDiscoverer);

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var name = traitAttribute.GetNamedArgument<string>("Identifier");

            yield return new KeyValuePair<string, string>("Category", "UnitTest");

            if (!string.IsNullOrWhiteSpace(name))
                yield return new KeyValuePair<string, string>("UnitTest", name);
        }
    }
}