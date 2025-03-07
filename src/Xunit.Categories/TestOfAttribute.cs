using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(TestOfDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TestOfAttribute:Attribute, ITraitAttribute
    {
        public TestOfAttribute()
        {
            
        }
        public TestOfAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public TestOfAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}