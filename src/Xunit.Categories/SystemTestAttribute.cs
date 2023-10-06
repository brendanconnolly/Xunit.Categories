using System;
using Xunit.Sdk;

namespace Xunit.Categories
{

    [TraitDiscoverer(SystemTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SystemTestAttribute : Attribute, ITraitAttribute
    {
        public SystemTestAttribute(string id)
        {
            Id = id;
        }

        public SystemTestAttribute(long id)
        {
            Id = id.ToString();
        }

        public SystemTestAttribute()
        {
        }

        public string Id { get; private set; }
    }
}
