using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    /// <summary>
    /// For annotating tests that relate to a specific work item, not necessarily a bug.
    /// </summary>
    [TraitDiscoverer(WorkItemDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class WorkItemAttribute : Attribute, ITraitAttribute
    {
        public WorkItemAttribute(string workItemId)
        {
            WorkItemId = workItemId;
        }

        public WorkItemAttribute(long workItemId)
        {
            WorkItemId = workItemId.ToString();
        }

        public WorkItemAttribute()
        {
        }

        public string WorkItemId { get; private set; }
    }
}