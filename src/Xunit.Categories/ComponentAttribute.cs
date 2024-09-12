using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(ComponentDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ComponentAttribute:Attribute, ITraitAttribute
    {
        public ComponentAttribute()
        {

        }

        public ComponentAttribute(string name)
        {
            this.ComponentName = name;
        }

        public string ComponentName { get; private set; }
    }
}