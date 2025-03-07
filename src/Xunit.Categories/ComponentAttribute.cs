using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(ComponentDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ComponentAttribute:Attribute, ITraitAttribute
    {
        public ComponentAttribute()
        {
            
        }
        public ComponentAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public ComponentAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}