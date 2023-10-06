using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class WorkItemDiscoverer : ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(WorkItemDiscoverer);

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var workItemId = traitAttribute.GetNamedArgument<string>("WorkItemId");

            yield return new KeyValuePair<string, string>("Category", "WorkItem");

            if (!string.IsNullOrWhiteSpace(workItemId))
                yield return new KeyValuePair<string, string>("WorkItem", workItemId);
        }
    }
}