using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(SystemTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SystemTestAttribute:Attribute, ITraitAttribute
    {
        public SystemTestAttribute()
        {
            
        }
        public SystemTestAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public SystemTestAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}