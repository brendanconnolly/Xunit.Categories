using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class SystemTestDiscoverer : ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(SystemTestDiscoverer);

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var bugId = traitAttribute.GetNamedArgument<string>("Id");

            yield return new KeyValuePair<string, string>("Category", "SystemTest");

            if (!string.IsNullOrWhiteSpace(bugId))
                yield return new KeyValuePair<string, string>("SystemTest", bugId);
        }
    }
}
