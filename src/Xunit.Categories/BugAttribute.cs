using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(BugDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class BugAttribute:Attribute, ITraitAttribute
    {
        public BugAttribute()
        {
            
        }
        public BugAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public BugAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}