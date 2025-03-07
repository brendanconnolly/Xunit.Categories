using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(SnapshotTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SnapshotTestAttribute:Attribute, ITraitAttribute
    {
        public SnapshotTestAttribute()
        {
            
        }
        public SnapshotTestAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public SnapshotTestAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}