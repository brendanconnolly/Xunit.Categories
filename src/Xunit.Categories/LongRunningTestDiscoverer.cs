using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class LongRunningDiscoverer : ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(LongRunningDiscoverer);

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            const string categoryValue = "LongRunning";
            string identifier = traitAttribute.GetNamedArgument<string>("Identifier");

            yield return new KeyValuePair<string, string>("Category", categoryValue);

            if (!string.IsNullOrWhiteSpace(identifier))
                yield return new KeyValuePair<string, string>(categoryValue, identifier);
        }
    }
}
