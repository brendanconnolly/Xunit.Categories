using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class CategoryDiscoverer:ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(CategoryDiscoverer);
    
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var identifier = traitAttribute.GetNamedArgument<string>("Identifier");
    
            if (!string.IsNullOrWhiteSpace(identifier))
                yield return new KeyValuePair<string, string>("Category", identifier);
        }
    }
}