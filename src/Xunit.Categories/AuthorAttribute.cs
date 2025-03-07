using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(AuthorDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute:Attribute, ITraitAttribute
    {
        public AuthorAttribute()
        {
            
        }
        public AuthorAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public AuthorAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}