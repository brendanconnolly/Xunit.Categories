using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(ArchitectureTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ArchitectureTestAttribute:Attribute, ITraitAttribute
    {
        public ArchitectureTestAttribute()
        {
            
        }
        public ArchitectureTestAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public ArchitectureTestAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}