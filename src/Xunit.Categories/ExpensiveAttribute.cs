using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(ExpensiveDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ExpensiveAttribute:Attribute, ITraitAttribute
    {
        public ExpensiveAttribute()
        {
            
        }
        public ExpensiveAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public ExpensiveAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}