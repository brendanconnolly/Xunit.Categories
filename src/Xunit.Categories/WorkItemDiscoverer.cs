using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class WorkItemDiscoverer:ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(WorkItemDiscoverer);
    
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var identifier = traitAttribute.GetNamedArgument<string>("Identifier");
    
            if (!string.IsNullOrWhiteSpace(identifier))
                yield return new KeyValuePair<string, string>("WorkItem", identifier);
        }
    }
}