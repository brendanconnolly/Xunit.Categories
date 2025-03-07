using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(CategoryDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CategoryAttribute:Attribute, ITraitAttribute
    {
        public CategoryAttribute()
        {
            
        }
        public CategoryAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public CategoryAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}