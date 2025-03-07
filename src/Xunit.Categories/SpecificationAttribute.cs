using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(SpecificationDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SpecificationAttribute:Attribute, ITraitAttribute
    {
        public SpecificationAttribute()
        {
            
        }
        public SpecificationAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public SpecificationAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}