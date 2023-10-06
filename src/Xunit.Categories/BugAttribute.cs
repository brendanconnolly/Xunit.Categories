using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(BugDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class BugAttribute : Attribute, ITraitAttribute
    {
        public BugAttribute(string id)
        {
            Id = id;
        }

        public BugAttribute(long id)
        {
            Id = id.ToString();
        }

        public BugAttribute()
        {
        }

        public string Id { get; private set; }
    }
}