using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(ManualDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ManualAttribute:Attribute, ITraitAttribute
    {
        public ManualAttribute()
        {
            
        }
        public ManualAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public ManualAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}