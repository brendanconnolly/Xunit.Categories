using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class ComponentDiscoverer: ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(ComponentDiscoverer);

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var name = traitAttribute.GetNamedArgument<string>("ComponentName");

            yield return new KeyValuePair<string, string>("Category", "Component");

            if (!string.IsNullOrWhiteSpace(name))
                yield return new KeyValuePair<string, string>("Component", name);
        }
    }
}