using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(ExploratoryDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ExploratoryAttribute:Attribute, ITraitAttribute
    {
        public ExploratoryAttribute()
        {
            
        }
        public ExploratoryAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public ExploratoryAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}