using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(DescriptionDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DescriptionAttribute:Attribute, ITraitAttribute
    {
        public DescriptionAttribute()
        {
            
        }
        public DescriptionAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public DescriptionAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}