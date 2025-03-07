using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(UnitTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UnitTestAttribute:Attribute, ITraitAttribute
    {
        public UnitTestAttribute()
        {
            
        }
        public UnitTestAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public UnitTestAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}