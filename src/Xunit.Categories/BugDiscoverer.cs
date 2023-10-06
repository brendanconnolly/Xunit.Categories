using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class BugDiscoverer : ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(BugDiscoverer);

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var bugId = traitAttribute.GetNamedArgument<string>("Id");


            yield return new KeyValuePair<string, string>("Category", "Bug");

            if (!string.IsNullOrWhiteSpace(bugId))
                yield return new KeyValuePair<string, string>("Bug", bugId);
        }
    }
}