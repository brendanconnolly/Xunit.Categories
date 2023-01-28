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

        public SpecificationAttribute(string id)
        {
            this.Identifier = id;
        }

        public SpecificationAttribute(long id)
        {
            this.Identifier = id.ToString();
        }

        public string Identifier { get; private set; }

    }
}