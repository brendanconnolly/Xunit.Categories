using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(DocumentationDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DocumentationAttribute:Attribute, ITraitAttribute
    {
        public DocumentationAttribute()
        {
            
        }
        public DocumentationAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public DocumentationAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}