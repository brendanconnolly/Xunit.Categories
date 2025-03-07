using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(WorkItemDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class WorkItemAttribute:Attribute, ITraitAttribute
    {
        public WorkItemAttribute()
        {
            
        }
        public WorkItemAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public WorkItemAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}