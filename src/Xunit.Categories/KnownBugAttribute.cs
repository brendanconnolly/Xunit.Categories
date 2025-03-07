using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(KnownBugDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class KnownBugAttribute:Attribute, ITraitAttribute
    {
        public KnownBugAttribute()
        {
            
        }
        public KnownBugAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public KnownBugAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}