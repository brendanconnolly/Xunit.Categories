using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class DescriptionDiscoverer : ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(DescriptionDiscoverer);

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var description = traitAttribute.GetNamedArgument<string>("Description");

            if (!string.IsNullOrWhiteSpace(description))
                yield return new KeyValuePair<string, string>("Description", description);
        }
    }
}