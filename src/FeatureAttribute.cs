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

        public FeatureAttribute(string name)
        {
            this.Identifier = name;
        }

        public FeatureAttribute(long id)
        {
            this.Identifier = id.ToString();
        }

        public string Identifier { get; private set; }

    }
}