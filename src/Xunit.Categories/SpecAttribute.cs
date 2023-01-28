using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(SpecDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SpecAttribute:Attribute, ITraitAttribute
    {
        public SpecAttribute()
        {

        }

        public SpecAttribute(string id)
        {
            this.Identifier = id;
        }

        public SpecAttribute(long id)
        {
            this.Identifier = id.ToString();
        }

        public string Identifier { get; private set; }

    }
}