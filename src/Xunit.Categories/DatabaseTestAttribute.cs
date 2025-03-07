using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(DatabaseTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DatabaseTestAttribute:Attribute, ITraitAttribute
    {
        public DatabaseTestAttribute()
        {
            
        }
        public DatabaseTestAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public DatabaseTestAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}