using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(LocalTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class LocalTestAttribute:Attribute, ITraitAttribute
    {
        public LocalTestAttribute()
        {
            
        }
        public LocalTestAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public LocalTestAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}