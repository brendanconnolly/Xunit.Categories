using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(FeatureDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class FeatureAttribute:Attribute, ITraitAttribute
    {
        public FeatureAttribute()
        {
            
        }
        public FeatureAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public FeatureAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}