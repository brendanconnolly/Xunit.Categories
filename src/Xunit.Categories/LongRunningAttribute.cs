using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(LongRunningDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class LongRunningAttribute : Attribute, ITraitAttribute
    {
        public LongRunningAttribute()
        {
        }

        public LongRunningAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public LongRunningAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}